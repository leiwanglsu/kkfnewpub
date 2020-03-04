Imports NRMatrixNet

<Serializable()> Public Class PrincipalKriging

    Public nPrincipalFields As Integer
    Public pVariogram As Variogram
    Public X(), Y() As Double
    Public U As NRMatrixNet.NRMatrixDotNet
    Public B As NRMatrixDotNet

    Public Sub ComputeU()
        Dim nX, nY As Integer
        nX = X.Length
        nY = Y.Length
        Dim nNorm As Integer = nX
        If pVariogram Is Nothing Then
            Throw New Exception("PrincipleKriging:ComputeU: Variogram is not ready")
        End If
        If nX <> nY Or nX = 0 Or nY = 0 Then
            Throw New Exception("PrincipleKriging:ComputeU: Wrong coordinate data!")
        End If

        Dim pCov As NRMatrixNet.NRMatrixDotNet = New NRMatrixNet.NRMatrixDotNet(nNorm, nNorm)
        For i = 0 To nNorm - 1
            For j = 0 To nNorm - 1
                Dim dist As Double = Math.Sqrt((X(i) - X(j)) * (X(i) - X(j)) + (Y(i) - Y(j)) * (Y(i) - Y(j)))
                Dim variance As Double = pVariogram.GetVariance(dist)
                pCov.SetValue(i, j, variance)
            Next
        Next
        Dim F As NRMatrixNet.NRMatrixDotNet
        Dim ncols, nrows As Integer
        nrows = pCov.NRows
        F = New NRMatrixNet.NRMatrixDotNet(nrows, 1) 'the trend component will be a flat surface in this implementation
        For i As Integer = 0 To nrows - 1
            F.SetValue(i, 0, 1)
        Next
        Dim theta_1 As NRMatrixNet.NRMatrixDotNet
        theta_1 = pCov.Inverse()
        B = theta_1 - theta_1 * F * (F.T() * theta_1 * F).Inverse() * F.T() * theta_1

        Dim eigen_vector As NRMatrixDotNet
        Dim eigen_value As NRMatrixDotNet
        eigen_vector = New NRMatrixDotNet(B.NRows, B.NCols)
        eigen_value = New NRMatrixDotNet(1, B.NRows)

        B.EigenValues(eigen_vector, eigen_value)

        nrows = eigen_vector.NRows
        ncols = eigen_vector.NCols

        U = New NRMatrixDotNet(nrows, nPrincipalFields)
        Dim smallest_eigen As Integer = ncols - 2 'the smallest eigen value is at location ncols - 2

        For i As Integer = 0 To nrows - 1
            For j As Integer = 0 To nPrincipalFields - 1
                U.SetValue(i, j, eigen_vector.GetValue(i, smallest_eigen - j))
            Next
        Next


    End Sub
    Public Function ExtractHMatrix(ByVal pDataPoints() As Array) As NRMatrixNet.NRMatrixDotNet()
        'pDataPoints stores the locations of observation data from each time frame
        If pVariogram Is Nothing Then
            Throw New Exception("PrincipleKriging:ExtractHMatrix:Variogram is not ready")
        End If
        Dim nX, nY As Integer
        nX = X.Length
        nY = Y.Length
        If nX <> nY Or nX = 0 Or nY = 0 Then
            Throw New Exception("PrincipleKriging:ExtractHMatrix: Wrong coordinate data!")
        End If
        If nPrincipalFields = 0 Or nPrincipalFields > nX Then
            Throw New Exception("PrincipleKriging:ExtractHMatrix: Wrong number of principal fields")
        End If
        Dim nTimes As Integer = pDataPoints.Length
        Dim nNorm As Integer = X.Length()
        Dim m_H() As NRMatrixDotNet
        m_H = Array.CreateInstance(GetType(NRMatrixDotNet), nTimes)
        Dim unused = Parallel.For(0, nTimes, Sub(n)
                                                 Dim i, j As Integer
                                                 Dim nPoints As Integer = pDataPoints(n).Length
                                                 Dim pCov As NRMatrixDotNet = New NRMatrixNet.NRMatrixDotNet(nPoints, nNorm)

                                                 For i = 0 To nPoints - 1
                                                     Dim pPnt As Point2D = pDataPoints(n)(i)
                                                     For j = 0 To nNorm - 1
                                                         Dim dist As Double = Math.Sqrt((pPnt.X - X(j)) * (pPnt.X - X(j)) + (pPnt.Y - Y(j)) * (pPnt.Y - Y(j)))
                                                         Dim variance As Double = pVariogram.GetVariance(dist)
                                                         pCov.SetValue(i, j, variance)
                                                     Next

                                                 Next


                                                 'note that the covariance matrix might be a sparse matrxi, the multiplication need to be improved
                                                 'covariance matrix is ready, get the m(n) matrix
                                                 Dim temp_matrix As NRMatrixDotNet = pCov * U
                                                 'add one column to the matrix
                                                 Dim H As NRMatrixDotNet = New NRMatrixDotNet(temp_matrix.NRows, temp_matrix.NCols + 1)

                                                 For m = 0 To temp_matrix.NRows - 1
                                                     H.SetValue(m, 0, 1)
                                                     For j = 1 To temp_matrix.NCols
                                                         H.SetValue(m, j, temp_matrix.GetValue(m, j - 1))
                                                     Next
                                                 Next
                                                 m_H(n) = H
                                             End Sub)
        Return m_H

    End Function
End Class
