Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.DataSourcesRaster
Imports ESRI.ArcGIS.DataSourcesGDB
Imports ESRI.ArcGIS.Catalog
Imports ESRI.ArcGIS.CatalogUI
Imports NRMatrixNet
Imports KKFClassLib
Public Class FormSTRaster
    Public outName, outPath As String
    Public m_application As ESRI.ArcGIS.Framework.IApplication
    ' Public a_ts As NRMatrixNet.NRMatrixDotNet
    Public kriging As PrincipalKriging

    Public pKKF As KKFClass
    Public nTime As Integer
    Dim textboxaction As TextBox
    Private Sub ButtonOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOpen.Click
        Dim m_pGXDialog As ESRI.ArcGIS.CatalogUI.IGxDialog
        m_pGXDialog = New GxDialog
        m_pGXDialog.ObjectFilter = New RasterFormatFGDBFilter

        m_pGXDialog.Title = "Enter New Output raster file"
        If m_pGXDialog.DoModalSave(Me.Handle.ToInt32) Then
            TextBoxOutput.Text = m_pGXDialog.FinalLocation.FullName & "\" & m_pGXDialog.Name
            outName = m_pGXDialog.Name
            outPath = m_pGXDialog.FinalLocation.FullName
        End If
    End Sub
    Public Function ObtainApplicationHandle() As ESRI.ArcGIS.Framework.IApplication
        Dim appRot As New ESRI.ArcGIS.Framework.AppROT
        Dim app As ESRI.ArcGIS.Framework.IApplication
        For i As Integer = 0 To appRot.Count - 1
            If TypeOf appRot.Item(i) Is IMxApplication Then
                app = appRot.Item(i)
                If MessageBox.Show("Use this ArcMap application? Number of layers: " & _
                     CType(app.Document, IMxDocument).FocusMap.LayerCount, Nothing, MessageBoxButtons.YesNo, _
                     MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Return app
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            m_application = ObtainApplicationHandle()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        Try



            'step 3 get the raster template
            Dim pFeatcls As IFeatureClass = GetFeaturClassByLayerName(m_application, ComboBoxInput.Text)
            Dim nFeats As Integer = pFeatcls.FeatureCount(Nothing)

            Dim pCursor As IFeatureCursor = pFeatcls.Search(Nothing, True)
            Dim pfeat As IFeature = pCursor.NextFeature
            Dim pspatial As ISpatialReference = pfeat.Shape.SpatialReference
            Dim x_max, x_min, y_max, y_min As Double
            Dim pPnt As IPoint = pfeat.Shape
            x_min = pPnt.X
            x_max = pPnt.X
            y_min = pPnt.Y
            y_max = pPnt.Y

            For n As Integer = 0 To nFeats - 1
                pPnt = pfeat.Shape


                If (x_max < pPnt.X) Then
                    x_max = pPnt.X
                End If
                If (x_min > pPnt.X) Then
                    x_min = pPnt.X

                End If
                If (y_max < pPnt.Y) Then
                    y_max = pPnt.Y
                End If
                If (y_min > pPnt.Y) Then
                    y_min = pPnt.Y
                End If
                pfeat = pCursor.NextFeature
                If pfeat Is Nothing Then
                    Exit For
                End If
            Next
            Dim cellsize As Double = Convert.ToDouble(TextBoxCellsize.Text)
            Dim extension As Double = Convert.ToDouble(TextBoxExtension.Text)

            x_min -= cellsize * extension
            x_max += cellsize * extension
            y_min -= cellsize * extension
            y_max += cellsize * extension

            Dim nrows As Integer = (y_max - y_min) / cellsize
            Dim ncols As Integer = (x_max - x_min) / cellsize
            Dim i, j As Integer
            Dim x, y As Double

            'get the output array

            Dim outArray() As System.Array

            'Dim nNorm As Integer = m_pNormX.Count
            '    Dim covar_matrix As NRMatrixDotNet = New NRMatrixDotNet(1, nNorm)
            Dim llcenter As Point2D = New Point2D
            llcenter.X = x_min
            llcenter.Y = y_min
            outArray = pKKF.PredictRaster(kriging, nrows, ncols, cellsize, llcenter)
            Dim nTime As Integer = outArray.Length
            'prediction is done, get array to the raster data
            'write to dataset
            Dim pOrg As IPoint = New Point
            pOrg.X = x_min - 0.5 * cellsize 'half pixel from the center
            pOrg.Y = y_min - 0.5 * cellsize
            Dim pSize As IPnt = New Pnt
            pSize.SetCoords(ncols, nrows)
            Dim pWSF As IWorkspaceFactory = New FileGDBWorkspaceFactory
            Dim pRWS As IRasterWorkspace2 = pWSF.OpenFromFile(outPath, m_application.hWnd)

            Dim pRasterSet As IRasterDataset2 = pRWS.CreateRasterDataset(Me.outName, "Imagine Image", pOrg, ncols, nrows, _
                                                                        cellsize, cellsize, nTime, rstPixelType.PT_DOUBLE, pspatial, True)

            Dim pOutRaster As IRaster = pRasterSet.CreateFullRaster
            Dim pEditRaster As IRasterEdit = pOutRaster
            Dim pPixelBlockWriter As IPixelBlock = pOutRaster.CreatePixelBlock(pSize)
            'write the image
            Dim pULPnt As IPnt = New Pnt
            pULPnt.SetCoords(0, 0)
            For t = 0 To nTime - 1
                pPixelBlockWriter.SafeArray(t) = outArray(t)
                Me.ToolStripStatusLabel1.Text = "Writing day " & t + 1
                Windows.Forms.Application.DoEvents()
            Next

            pEditRaster.Write(pULPnt, pPixelBlockWriter)
            Dim pRasterBands As IRasterBandCollection = pOutRaster
            For n As Integer = 0 To pRasterBands.Count - 1
                Me.ToolStripStatusLabel1.Text = "Computing statistics " & n + 1
                Windows.Forms.Application.DoEvents()
                pRasterBands.Item(n).ComputeStatsAndHist()
            Next
            Me.ToolStripStatusLabel1.Text = "done"
            Windows.Forms.Application.DoEvents()
        Catch ex As Exception
            MsgBox(ex.Message)


        End Try

    End Sub

    Private Sub ComboBoxInput_DropDown(sender As Object, e As System.EventArgs) Handles ComboBoxInput.DropDown

        Try
            ListFeatureLayers(m_application, sender, e)

        Catch ex As Exception

        End Try
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

   
End Class