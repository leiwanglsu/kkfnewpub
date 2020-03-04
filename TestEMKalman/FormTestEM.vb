Imports NRMatrixNet
Imports KKFClassLib
Public Class FormTestEM
    Dim pKKF As KKFClass
    Dim H() As NRMatrixDotNet
    Private Sub ButtonInitialize_Click(sender As Object, e As EventArgs) Handles ButtonInitialize.Click
        Dim pDataMatrix() As NRMatrixDotNet = GetMatrixArrayWithNoData(TextBoxObservation.Text, -9999)
        Dim n As Integer = pDataMatrix.Length
        H = Array.CreateInstance(GetType(NRMatrixDotNet), n)

        For i As Integer = 0 To n - 1
            Dim m As Integer = pDataMatrix(i).NRows
            H(i) = New NRMatrixDotNet(m, 1)
            For j As Integer = 0 To m - 1
                H(i).SetValue(j, 0, 1)
            Next
        Next
        pKKF = New KKFClass
        pKKF.DataMatrix = pDataMatrix
        pKKF.InitializeKKF(1, 2500, 1.1, 100)

        TextBoxOutput.Text = ""

        For t As Integer = 0 To pDataMatrix.Length - 1

            PrintMatrix(H(t).T(), TextBoxOutput.Text)

        Next
        TextBoxOutput.Text += vbCrLf

    End Sub
    Private Function GetMatrixArrayWithNoData(ByVal text As String, ByVal nodata As Double) As NRMatrixDotNet()
        Dim matrix() As NRMatrixDotNet


        Dim separator1() As Char = {vbCrLf}
        Dim separator2() As Char = {vbCrLf, ",", ";", vbTab}
        Dim lines() As String = text.Split(separator1)

        Dim nlines As Integer = lines.Count
        matrix = Array.CreateInstance(GetType(NRMatrixDotNet), nlines)

        For i = 0 To nlines - 1
            Dim Vector As NRMatrixDotNet = GetVectorWithNoData(lines(i), nodata)
            matrix(i) = Vector.T()

        Next
        Return matrix

    End Function
    Private Function GetVectorWithNoData(ByVal text As String, ByVal nodata As Double) As NRMatrixDotNet
        Dim matrix As NRMatrixDotNet
        Dim separator1() As Char = {vbCrLf}
        Dim separator2() As Char = {vbCrLf, ",", ";", vbTab}

        Dim words() As String = text.Split(separator2)
        Dim ncols As Integer = words.Count


        Dim i, j As Integer
        Dim valuelist As ArrayList = New ArrayList
        Dim values(,) As Double
        For j = 0 To ncols - 1
            If Convert.ToDouble(words(j)) <> nodata Then
                valuelist.Add(Convert.ToDouble(words(j)))

            End If
        Next
        values = Array.CreateInstance(GetType(Double), valuelist.Count, 1)
        For j = 0 To valuelist.Count - 1
            values(j, 0) = valuelist(j)
        Next
        matrix = New NRMatrixDotNet(values)
        Return matrix
    End Function
    Public Sub PrintMatrix(ByVal matrix As NRMatrixDotNet, ByRef text As String)
        Try
            Dim values As System.Array = matrix.GetArray()
            Dim nrows, ncols As Integer
            nrows = values.GetUpperBound(1)
            ncols = values.GetUpperBound(0)
            For i As Integer = 0 To nrows
                For j As Integer = 0 To ncols
                    If j = ncols Then
                        text += String.Format("{0:N4}", values(j, i))
                    Else
                        text += String.Format("{0:N4}", values(j, i)) & ","
                    End If

                Next
                text += vbCrLf

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub ButtonIterate_Click(sender As Object, e As EventArgs) Handles ButtonIterate.Click
        pKKF.KKFIterate(1, H)
        TextBoxOutput.Text = ""
        TextBoxOutput.Text += String.Format("Likelihood = {0}",-2 * pKKF.Likelihood(pKKF.Likelihood.Count - 1))
        TextBoxOutput.Text += vbCrLf
        TextBoxOutput.Text += String.Format("R = {0}", pKKF.RT(pKKF.RT.Count - 1))
        TextBoxOutput.Text += vbCrLf
        TextBoxOutput.Text += String.Format("Q = ")
        PrintMatrix(pKKF.GetQ(), TextBoxOutput.Text)
        TextBoxOutput.Text += vbCrLf
        TextBoxOutput.Text += String.Format("Phi = ")
        PrintMatrix(pKKF.GetPhi(), TextBoxOutput.Text)
        TextBoxOutput.Text += vbCrLf
        For i As Integer = 1 To pKKF.nTimes
            TextBoxOutput.Text += String.Format("{0} x = {1}, sqrt(p) = {2}", i + 1948,
                                                pKKF.Alpha_s_t(i).GetValue(0, 0), Math.Sqrt(CType(pKKF.GetP()(i), NRMatrixDotNet).GetValue(0, 0)))
            TextBoxOutput.Text += vbCrLf
        Next

    End Sub
End Class
