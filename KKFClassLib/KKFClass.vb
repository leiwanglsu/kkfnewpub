Imports NRMatrixNet
<Serializable()> Public Class KKFClass
    Public nTimes As Integer
    ' Public DataPoints() As Array 'location of the points by time
    <NonSerialized> Public DataMatrix() As NRMatrixDotNet
    Public Likelihood As System.Collections.ArrayList
    <NonSerialized> Public Alpha_s_t() As NRMatrixDotNet
    Public TransitionMatrix As NRMatrixDotNet
    Public KKFMessage As String
    Public RT As ArrayList
    <NonSerialized()> Private pkkf As EMKalmanClassNew


    Public Function GetQ() As NRMatrixDotNet
        Return pkkf.Q

    End Function
    Public Function GetPhi() As NRMatrixDotNet
        Return pkkf.PHI

    End Function
    Public Function GetP() As Array
        Return pkkf.P
    End Function

    Public Sub InitializeKKF(ByVal nPF As Integer, ByVal u As Double, ByVal phi As Double, ByVal e As Double)
        KKFMessage = ""
        nTimes = DataMatrix.Length
        pkkf = New EMKalmanClassNew(nTimes, nPF)
        ' AddHandler pkkf.PrintMessageEvent1, AddressOf ShowKKFMessage
        ' pkkf.H = kriging.ExtractHMatrix(ObLocations)
        '  pkkf.BadData = -9999
        pkkf.Initialize(u, phi, e)

        RT = New ArrayList
        RT.Add(e * e)

        Likelihood = New ArrayList
        Alpha_s_t = pkkf.AST
    End Sub
    Public Sub ShowKKFMessage(ByVal msg As String)
        KKFMessage += msg
    End Sub
    Public Sub CalibrateByMaximumError(ByVal Tolarence As Double, ByRef M() As NRMatrixDotNet) 'use an error term as the stop condition
        'iterate until the maximum error is less than the tolarence
        Dim max_e As Double = 0
        Do
            Likelihood.Add(pkkf.Iterate(M, DataMatrix, RT))

            For Each v In RT
                If max_e < v Then
                    max_e = v
                End If
            Next
        Loop While (max_e > Tolarence)



    End Sub
    Public Sub CalibrateByMMinimuError(ByVal Tolarence As Double, ByRef M() As NRMatrixDotNet) 'use an error term as the stop condition
        'stop if the minimum error in the error list is less than the tolarance
        Dim min_e As Double = 9999
        Do
            Likelihood.Add(pkkf.Iterate(M, DataMatrix, RT))

            For Each v In RT
                If min_e > v Then
                    min_e = v
                End If
            Next
        Loop While (min_e > Tolarence)

    End Sub
    Public Sub KKFIterate(ByVal nSteps As Integer, ByRef M() As NRMatrixDotNet) 'iterate nSteps
        For i As Integer = 0 To nSteps - 1
            Likelihood.Add(pkkf.Iterate(M, DataMatrix, RT))
        Next
        Alpha_s_t = pkkf.AST
    End Sub
    Public Sub CalibrateByLogL(ByVal Tolarence As Double, ByRef M() As NRMatrixDotNet) 'iterate until the LogL stops growing
        Dim last_LL As Double = -9999
        Dim LL_d As Double

        Do
            Dim LL As Double = pkkf.Iterate(M, DataMatrix, RT)
            Likelihood.Add(LL)
            LL_d = LL - last_LL
            last_LL = LL

        Loop While (LL_d > Tolarence)


    End Sub

    Public Function PredictByPoints(ByRef kriging As PrincipalKriging, ByRef pDataPoints As Point2D()) As NRMatrixDotNet()



        If Alpha_s_t Is Nothing Then
            Throw New Exception("KKF model is not calibrated")
        End If
        If pDataPoints Is Nothing Then
            Throw New Exception("Data point list is null")
        End If
        If pDataPoints.Length = 0 Then
            Throw New Exception("Data point list is empty")
        End If
        Dim STPoints As Array = Array.CreateInstance(GetType(Point2D()), nTimes)
        For t As Integer = 0 To nTimes - 1
            STPoints(t) = pDataPoints
        Next

        Dim H1 As NRMatrixDotNet() = kriging.ExtractHMatrix(STPoints)
        Dim pred As NRMatrixDotNet() = Array.CreateInstance(GetType(NRMatrixDotNet), nTimes)
        For i As Integer = 0 To nTimes - 1
            pred(i) = H1(i) * Alpha_s_t(i + 1) 'ast is 1-based, not 0-based
        Next
        Return pred
    End Function
    Public Function PredictRaster(ByRef kriging As PrincipalKriging, ByVal nrows As Integer, ByVal ncols As Integer, ByVal cellsize As Double,
                                  ByVal lower_left_center As Point2D) As Array()

        Dim outSTArray As Array() = Array.CreateInstance(GetType(Array), nTimes)
        If Alpha_s_t Is Nothing Then
            Throw New Exception("KKF model is not calibrated")
        End If

        Dim pDataPoints As Array = Array.CreateInstance(GetType(Point2D), nrows * ncols)
        For i As Integer = 0 To ncols - 1
            For j As Integer = 0 To nrows - 1
                Dim pNewPnt As Point2D = New Point2D
                pNewPnt.X = i * cellsize + lower_left_center.X
                pNewPnt.Y = j * cellsize + lower_left_center.Y

                pDataPoints(j * ncols + i) = pNewPnt
            Next
        Next
        Dim STPoints As Array = Array.CreateInstance(GetType(Point2D()), nTimes)
        For t As Integer = 0 To nTimes - 1
            STPoints(t) = pDataPoints
        Next
        Dim H1 As NRMatrixDotNet() = kriging.ExtractHMatrix(STPoints)
        For t As Integer = 0 To nTimes - 1
            outSTArray(t) = Array.CreateInstance(GetType(Double), ncols, nrows)
            Dim pred As NRMatrixDotNet = H1(t) * Alpha_s_t(t + 1)
            For i As Integer = 0 To ncols - 1
                For j As Integer = 0 To nrows - 1
                    outSTArray(t)(i, j) = pred.GetValue(j * ncols + i, 0)
                Next
            Next
        Next
        Return outSTArray
    End Function
End Class
