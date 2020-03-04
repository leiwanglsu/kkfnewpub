Imports ESRI.ArcGIS.Geodatabase
Imports System.IO
Imports ESRI.ArcGIS.ArcMapUI
Imports NRMatrixNet
Imports ESRI.ArcGIS.Geometry
Imports System.Threading.Tasks
Public Class FormCovariogram
    Public m_application As ESRI.ArcGIS.Framework.IApplication
    Dim m_xx, m_yy As NRMatrixDotNet
    Public pVariogram As Variogram
    Dim textboxaction As TextBox
    Public m_pDataPoints() As Array
    Public m_pDataMatrix() As NRMatrixDotNet
   

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReady.Click

        Try

            Dim bin As Double = Convert.ToDouble(TextBox2.Text)
            Dim nBins As Integer = Convert.ToInt32(TextBox3.Text)
            Dim nTimes As Integer = m_pDataPoints.Length
            Dim pVarList() As Double = Array.CreateInstance(GetType(Double), nBins)
            For Each v In pVarList
                v = 0
            Next
            Dim pcountlist() As Integer = Array.CreateInstance(GetType(Integer), nBins)
            For Each v In pcountlist
                v = 0
            Next

            Dim sync As Object = New Object
            Parallel.For(0, nTimes, Sub(n)
                                        Dim nPnts As Integer = m_pDataPoints(n).Length
                                        Dim i As Integer
                                        Dim pLocalVar() As Double
                                        Dim pLocalCount() As Integer
                                        pLocalVar = Array.CreateInstance(GetType(Double), nBins)
                                        pLocalCount = Array.CreateInstance(GetType(Integer), nBins)
                                        For i = 0 To nPnts - 1
                                            Dim j As Integer
                                            Dim z1 As Double = m_pDataMatrix(n).GetValue(i, 0)
                                            Dim pnt1 As IPoint = m_pDataPoints(n)(i)
                                            For j = 0 To nPnts - 1
                                                If i = j Then
                                                    Continue For
                                                End If
                                                Dim z2 As Double = m_pDataMatrix(n).GetValue(j, 0)

                                                Dim pnt2 As IPoint = m_pDataPoints(n)(j)

                                                Dim dist As Double = Math.Sqrt((pnt1.X - pnt2.X) * (pnt1.X - pnt2.X) + (pnt1.Y - pnt2.Y) * (pnt1.Y - pnt2.Y))
                                                Dim index As Integer = Math.Truncate(dist / bin)
                                                If index >= nBins Then
                                                    Continue For
                                                End If

                                                pLocalVar(index) += (z1 - z2) * (z1 - z2) / 2
                                                pLocalCount(index) += 1
                                            Next
                                        Next
                                        SyncLock sync
                                            For i = 0 To nBins - 1
                                                pVarList(i) += pLocalVar(i)
                                                pcountlist(i) += pLocalCount(i)
                                            Next
                                        End SyncLock
                                    End Sub)

            Dim sill_max As Double = 0
            Dim ii, nTotal As Integer
            nTotal = 0
            For ii = 0 To nBins - 1
                If pcountlist(ii) <> 0 Then
                    nTotal += 1
                    If sill_max < pVarList(ii) Then
                        sill_max = pVarList(ii)
                    End If

                End If

            Next
            pVariogram = New Variogram
            With pVariogram
                .c0_min = 0
                .c_min = 0
                .a_min = 0
                .a_max = (nBins * bin)
                .c_max = sill_max
                .c0_max = sill_max
                '.range_factor_ = Convert.ToDouble(TextBoxRangefactor.Text)

            End With
           

            m_xx = New NRMatrixDotNet(nTotal, 1)
            m_yy = New NRMatrixDotNet(nTotal, 1)
            ii = 0
            For index As Integer = 0 To nBins - 1
                If pcountlist(index) = 0 Then
                    Continue For
                End If
                Dim dist As Double = index * bin
                If pVariogram.c_ < pVarList(index) Then
                    pVariogram.c_ = pVarList(index)
                End If
                m_xx.SetValue(ii, 0, dist + bin * 0.5)
                m_yy.SetValue(ii, 0, pVarList(index) / pcountlist(index))
                ii += 1

            Next
            RichTextBox1.Text += "lag, variograph" & vbCrLf

            For i = 0 To m_xx.NRows - 1
                RichTextBox1.Text += m_xx.GetValue(i, 0) & ", " & m_yy.GetValue(i, 0) & ", "  & vbCrLf

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Close()

    End Sub


    Private Sub CopyAllTextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyAllTextToolStripMenuItem.Click

        My.Computer.Clipboard.SetText(textboxaction.Text)

    End Sub

    Private Sub ClearTextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearTextToolStripMenuItem.Click

        textboxaction.Clear()

    End Sub


    Private Sub ContextMenuStrip1_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim contextmenu1 As ContextMenuStrip = CType(sender, ContextMenuStrip)
        textboxaction = CType(contextmenu1.SourceControl, TextBox)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Dim pFileDia As OpenFileDialog = New OpenFileDialog

            pFileDia.Filter = "Station data (*.vario) |*.vario|All files (*.*) |*.*"
            pFileDia.RestoreDirectory = True
            If (pFileDia.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Dim myStream As System.IO.FileStream = pFileDia.OpenFile
                If Not myStream Is Nothing Then
                    Dim bf As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    pVariogram = bf.Deserialize(myStream)
                    TextBoxResult.Clear()
                    TextBoxResult.Text += "c0 = " & pVariogram.c0_ & vbCrLf
                    TextBoxResult.Text += "c = " & pVariogram.c_ & vbCrLf
                    TextBoxResult.Text += "a = " & pVariogram.a_ & vbCrLf
                    TextBoxResult.Text += "Kai = " & pVariogram.kai2_ & vbCrLf
                    'put the modeled variogram in the textbox
                    TextBoxResult.Text += "lag, variograph, model" & vbCrLf
                    Select Case pVariogram.Type
                        Case VariogramType.Gaussion
                            ComboBoxFunction1.Text = "Gaussian"

                        Case VariogramType.Linear
                            ComboBoxFunction1.Text = "Linear"


                        Case VariogramType.Spherical
                            ComboBoxFunction1.Text = "Spherical"


                        Case VariogramType.Exponential
                            ComboBoxFunction1.Text = "Exponential"

                    End Select

                    MsgBox("done")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCreate.Click
        pVariogram = New NRMatrixNet.Variogram
        pVariogram.a_ = Convert.ToDouble(TextBoxRange.Text)
        pVariogram.c0_ = Convert.ToDouble(TextBoxNuget.Text)
        pVariogram.c_ = Convert.ToDouble(TextBoxSill.Text)
        Select Case ComboBoxFunction2.Text
            Case "Gaussian"
                pVariogram.Type = VariogramType.Gaussion
            Case "Linear"
                pVariogram.Type = VariogramType.Linear

            Case "Spherical"
                pVariogram.Type = VariogramType.Spherical

            Case "Exponential"
                pVariogram.Type = VariogramType.Exponential
        End Select
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRead.Click
        Try

            Dim pFileDia As OpenFileDialog = New OpenFileDialog

            pFileDia.Filter = "Station data (*.vario) |*.vario|All files (*.*) |*.*"
            pFileDia.RestoreDirectory = True
            If (pFileDia.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Dim myStream As System.IO.FileStream = pFileDia.OpenFile
                If Not myStream Is Nothing Then
                    Dim bf As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    pVariogram = bf.Deserialize(myStream)
                    TextBoxNuget.Text = pVariogram.c0_
                    TextBoxSill.Text = pVariogram.c_
                    TextBoxRange.Text = pVariogram.a_
                    Select Case pVariogram.Type
                        Case VariogramType.Gaussion
                            ComboBoxFunction2.Text = "Gaussian"

                        Case VariogramType.Linear
                            ComboBoxFunction2.Text = "Linear"


                        Case VariogramType.Spherical
                            ComboBoxFunction2.Text = "Spherical"


                        Case VariogramType.Exponential
                            ComboBoxFunction2.Text = "Exponential"

                    End Select


                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Function TextBoxResult() As Object
        Throw New NotImplementedException
    End Function

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
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

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click

    End Sub

    Private Sub ButtonFit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFit.Click
        Try
            Dim tol As Double = 0.01


            Select Case ComboBoxFunction1.Text
                Case "Gaussian"
                    pVariogram.Type = VariogramType.Gaussion
                Case "Linear"
                    pVariogram.Type = VariogramType.Linear

                Case "Spherical"
                    pVariogram.Type = VariogramType.Spherical

                Case "Exponential"
                    pVariogram.Type = VariogramType.Exponential


            End Select

            pVariogram.Fit(m_xx, m_yy, tol)

            'Dim pPara As System.Collections.ArrayList = pVariogram.Parameters
            RichTextBox1.Clear()
            RichTextBox1.Text += "c0 = " & pVariogram.c0_ & vbCrLf
            RichTextBox1.Text += "c = " & pVariogram.c_ & vbCrLf
            RichTextBox1.Text += "a = " & pVariogram.a_ & vbCrLf
            RichTextBox1.Text += "Kai = " & pVariogram.kai2_ & vbCrLf
            'put the modeled variogram in the textbox
            RichTextBox1.Text += "lag, variograph, model" & vbCrLf

            For i = 0 To m_xx.NRows - 1
                RichTextBox1.Text += m_xx.GetValue(i, 0) & ", " & m_yy.GetValue(i, 0) & ", " & _
                    pVariogram.GetSemiVariance(m_xx.GetValue(i, 0)) & vbCrLf

            Next
        Catch ex As Exception
            RichTextBox1.Text = ex.Message
        End Try
        
    End Sub

    Private Sub FormCovariogram_Load(sender As Object, e As EventArgs) Handles Me.Load
        If pVariogram Is Nothing Then
            Return
        End If
        TextBoxNuget.Text = pVariogram.c0_
        TextBoxSill.Text = pVariogram.c_
        TextBoxRange.Text = pVariogram.a_
        Select Case pVariogram.Type
            Case VariogramType.Gaussion
                ComboBoxFunction2.Text = "Gaussian"

            Case VariogramType.Linear
                ComboBoxFunction2.Text = "Linear"


            Case VariogramType.Spherical
                ComboBoxFunction2.Text = "Spherical"


            Case VariogramType.Exponential
                ComboBoxFunction2.Text = "Exponential"

        End Select
    End Sub
End Class