Imports NRMatrixNet
Imports System.Threading
Imports System.Threading.Tasks
Imports KKFClassLib
Public Class FormMain

    Dim pVariogram As NRMatrixNet.Variogram

    ' Dim pKKF As EMKalmanAlgorithm.EMKalmanClass
    Dim pSingleKKF As KKFClass
    Dim kriging As PrincipalKriging

    Dim m_application As ESRI.ArcGIS.Framework.IApplication
    Dim textboxaction As TextBox
    Dim pKKFParameter As FormSTRaster
    Public pDataPoints() As Array
    Public pDataMatrix() As NRMatrixDotNet
    Dim H As NRMatrixDotNet()


    Private Sub CovariogramToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CovariogramToolStripMenuItem.Click
        If kriging Is Nothing Then
            kriging = New PrincipalKriging
        End If
        Dim pform As FormCovariogram = New FormCovariogram
        pform.m_application = m_application
        pform.m_pDataMatrix = pDataMatrix
        pform.m_pDataPoints = pDataPoints
        pform.pVariogram = kriging.pVariogram
        pform.ShowDialog()
        m_application = pform.m_application
        kriging.pVariogram = pform.pVariogram

    End Sub





    Private Sub TimeSeriesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TimeSeriesToolStripMenuItem.Click
        Try
            Dim pform As FormSTInterpolation = New FormSTInterpolation
            pform.kriging = kriging
            pform.pKKF = pSingleKKF
            pform.m_application = m_application
            pform.ShowDialog()
            m_application = pform.m_application
        Catch ex As Exception

        End Try


    End Sub



    Private Sub SpatialTemporalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SpatialTemporalToolStripMenuItem.Click
        If pKKFParameter Is Nothing Then
            pKKFParameter = New FormSTRaster
        End If
        pKKFParameter.m_application = m_application
        pKKFParameter.pKKF = pSingleKKF
        pKKFParameter.kriging = kriging
        '  pform.a_ts = alpha_s_t
        pKKFParameter.ShowDialog()

    End Sub



    Private Sub CopyAllTextToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyAllTextToolStripMenuItem.Click

        My.Computer.Clipboard.SetText(textboxaction.Text)

    End Sub

    Private Sub ClearTextToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearTextToolStripMenuItem.Click

        textboxaction.Clear()

    End Sub


    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim contextmenu1 As ContextMenuStrip = CType(sender, ContextMenuStrip)
        textboxaction = CType(contextmenu1.SourceControl, TextBox)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Dim pFileDia As SaveFileDialog = New SaveFileDialog
            pFileDia.Filter = "Station data (*.vario) |*.vario|All files (*.*) |*.*"
            pFileDia.RestoreDirectory = True
            If (pFileDia.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Dim myStream As System.IO.FileStream = pFileDia.OpenFile
                If Not myStream Is Nothing Then
                    Dim bf As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    bf.Serialize(myStream, pVariogram)
                    myStream.Close()
                    MsgBox("done")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub FixedStationDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixedStationDataToolStripMenuItem.Click
        Dim pform As ReadFixedStationData = New ReadFixedStationData

        pform.m_application = m_application
        pform.ShowDialog()

        pDataPoints = pform.pDataPoints
        pDataMatrix = pform.pDataMatrix




    End Sub

    Private Sub MovableStationDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovableStationDataToolStripMenuItem.Click
        Dim pform As ReadMovableStationData = New ReadMovableStationData

        pform.m_application = m_application
        pform.ShowDialog()

        pDataPoints = pform.pDataPoints
        pDataMatrix = pform.pDataMatrix
    End Sub


    Private Sub SaveVariogramToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Dim pFileDia As SaveFileDialog = New SaveFileDialog
            pFileDia.Filter = "Station data (*.vario) |*.vario|All files (*.*) |*.*"
            pFileDia.RestoreDirectory = True
            If (pFileDia.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Dim myStream As System.IO.FileStream = pFileDia.OpenFile
                If Not myStream Is Nothing Then
                    Dim bf As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    bf.Serialize(myStream, pVariogram)
                    myStream.Close()
                    MsgBox("done")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub OpenVariogramToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try

            Dim pFileDia As OpenFileDialog = New OpenFileDialog
            pFileDia.Filter = "Station data (*.vario) |*.vario|All files (*.*) |*.*"
            pFileDia.RestoreDirectory = True
            If (pFileDia.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Dim myStream As System.IO.FileStream = pFileDia.OpenFile
                If Not myStream Is Nothing Then

                    Dim bf As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

                    pVariogram = bf.Deserialize(myStream)
                    myStream.Close()
                    MsgBox("done")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub LinkArcMapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinkArcMapToolStripMenuItem.Click
        Try
            m_application = utilities.ObtainApplicationHandle
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim pform As FormNormativeSites = New FormNormativeSites
        pform.m_application = m_application
        If kriging Is Nothing Then
            kriging = New PrincipalKriging
        End If
        pform.kriging = kriging
        pform.ShowDialog()


    End Sub

    Private Sub ModelSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModelSetupToolStripMenuItem.Click

        Try
            If kriging Is Nothing Then
                Throw New Exception("Kriging model is not defined")
            End If
            kriging.nPrincipalFields = Convert.ToInt32(InputBox("Number of principal fields"))
            kriging.ComputeU()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub InitializeModelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InitializeModelToolStripMenuItem.Click
        Try
            If kriging Is Nothing Then
                Throw New Exception("Kriging model is not ready")
            End If
            If pSingleKKF Is Nothing Then
                pSingleKKF = New KKFClass

            End If
            With pSingleKKF
                .DataMatrix = pDataMatrix

            End With

            Dim pform As FormKKFParameter = New FormKKFParameter
            pform.ShowDialog()
            Dim Err As Double = Convert.ToDouble(pform.TextBoxInitError.Text)
            Dim phi As Double = Convert.ToDouble(pform.TextBoxTransit.Text)
            Dim x0 As Double = Convert.ToDouble(pform.TextBoxInitState.Text)
            pSingleKKF.InitializeKKF(kriging.nPrincipalFields + 1, x0, phi, Err)
            H = kriging.ExtractHMatrix(pDataPoints)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub CalibrateAutomaticallyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalibrateAutomaticallyToolStripMenuItem.Click
        Try
            Dim tolarence As Double = Convert.ToDouble(InputBox("Define error tolerance"))
            Throw New Exception("Function not implemented")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ButtonIterate_Click(sender As Object, e As EventArgs) Handles ButtonIterate.Click
        Try
            pSingleKKF.KKFIterate(1, H)
            TextBoxOutput.Text = ""
            TextBoxOutput.Text += String.Format("Likelihood = {0}", -2 * pSingleKKF.Likelihood(pSingleKKF.Likelihood.Count - 1))
            TextBoxOutput.Text += vbCrLf
            TextBoxOutput.Text += String.Format("R = {0}", pSingleKKF.RT(pSingleKKF.RT.Count - 1))
            TextBoxOutput.Text += vbCrLf
            TextBoxOutput.Text += String.Format("Q = {0}", pSingleKKF.GetQ())
            TextBoxOutput.Text += vbCrLf
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If (H Is Nothing) Then
                MsgBox("H is not defined")
                Return
            End If
            TextBoxOutput.Text = ""
            For i As Integer = 0 To H.Length - 1
                PrintMatrix(H(i), TextBoxOutput.Text)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub SaveModelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveModelToolStripMenuItem.Click
        Try

            Dim pFileDia As SaveFileDialog = New SaveFileDialog
            pFileDia.Filter = "KKF model (*.kkf) |*.kkf|All files (*.*) |*.*"
            pFileDia.RestoreDirectory = True
            If (pFileDia.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Dim myStream As System.IO.FileStream = pFileDia.OpenFile
                If Not myStream Is Nothing Then
                    Dim bf As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    'bf.Serialize(myStream, pVariogram)
                    bf.Serialize(myStream, kriging)
                    bf.Serialize(myStream, pDataMatrix.Length)
                    For i As Integer = 0 To pDataMatrix.Length - 1
                        bf.Serialize(myStream, pDataMatrix(i))
                    Next
                    bf.Serialize(myStream, pDataPoints.Length)
                    For i As Integer = 0 To pDataPoints.Length - 1
                        Dim pPoints As Array = pDataPoints(i)
                        bf.Serialize(myStream, pPoints.Length)
                        For j As Integer = 0 To pPoints.Length - 1
                            bf.Serialize(myStream, pPoints(j))
                        Next
                    Next

                    bf.Serialize(myStream, pSingleKKF)
                    myStream.Close()
                    MsgBox("done")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub LoadModelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadModelToolStripMenuItem.Click
        Try

            Dim pFileDia As OpenFileDialog = New OpenFileDialog

            pFileDia.Filter = "KKF model (*.kkf) |*.kkf|All files (*.*) |*.*"
            pFileDia.RestoreDirectory = True
            If (pFileDia.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Dim myStream As System.IO.FileStream = pFileDia.OpenFile
                If Not myStream Is Nothing Then
                    Dim bf As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

                    kriging = bf.Deserialize(myStream)
                    Dim length As Integer = bf.Deserialize(myStream)
                    pDataMatrix = Array.CreateInstance(GetType(NRMatrixDotNet), length)
                    For i As Integer = 0 To pDataMatrix.Length - 1
                        pDataMatrix(i) = bf.Deserialize(myStream)
                    Next
                    length = bf.Deserialize(myStream)
                    pDataPoints = Array.CreateInstance(GetType(Array), length)

                    For i As Integer = 0 To pDataPoints.Length - 1
                        Dim length_points As Integer = bf.Deserialize(myStream)
                        pDataPoints(i) = Array.CreateInstance(GetType(Point2D), length_points)
                        For j As Integer = 0 To length_points - 1
                            pDataPoints(i)(j) = bf.Deserialize(myStream)
                        Next
                        'pDataPoints(i) = bf.Deserialize(myStream)
                    Next
                    pSingleKKF = bf.Deserialize(myStream)

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
End Class
