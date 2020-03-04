Imports ESRI.ArcGIS.Geodatabase
Imports System.IO
Imports ESRI.ArcGIS.ArcMapUI
Imports KKFClassLib
Public Class FormNormativeSites
    Public m_application As ESRI.ArcGIS.Framework.IApplication
    Public kriging As principalKriging

    Dim textboxaction As TextBox

    Private Sub ComboBoxInput_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxInput.DropDown
        Try
            ListFeatureLayers(m_application, sender, e)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOpen.Click
        'read the feature class
        Try
            Dim pFeatCls As IFeatureClass = GetFeaturClassByLayerName(m_application, ComboBoxInput.Text)

            Dim nNorm As Integer
            Dim i, j As Integer
            Dim xmax, xmin, ymax, ymin As Double
            Dim pGeoDataset As IGeoDataset = pFeatCls

            xmax = pGeoDataset.Extent.XMax
            xmin = pGeoDataset.Extent.XMin
            ymax = pGeoDataset.Extent.YMax
            ymin = pGeoDataset.Extent.YMin

            Select Case ComboBoxNormative.Text
                Case "All" 'use all points from the input data
                    Dim pFeatCnt As Integer = pFeatCls.FeatureCount(Nothing)
                    nNorm = pFeatCnt

                    Dim pFeatCur As IFeatureCursor
                    pFeatCur = pFeatCls.Search(Nothing, True)
                    Dim pF As IFeature
                    Dim pnt As ESRI.ArcGIS.Geometry.IPoint

                    Dim nFeats As Integer = pFeatCls.FeatureCount(Nothing)

                    kriging.X = Array.CreateInstance(GetType(Double), nFeats)
                    kriging.Y = Array.CreateInstance(GetType(Double), nFeats)
                    For i = 0 To pFeatCnt - 1
                        pF = pFeatCur.NextFeature
                        pnt = pF.Shape
                        kriging.X(i) = pnt.X
                        kriging.Y(i) = pnt.Y

                    Next
                Case "Random" 'use a randomly created number of points
                    Dim pRand As Random = New Random

                    nNorm = Convert.ToInt32(TextBoxNumNorm.Text)
                    kriging.X = Array.CreateInstance(GetType(Double), nNorm)
                    kriging.Y = Array.CreateInstance(GetType(Double), nNorm)
                    For i = 0 To nNorm - 1
                        kriging.X(i) = pRand.NextDouble * (xmax - xmin) + xmin
                        kriging.Y(i) = pRand.NextDouble * (ymax - ymin) + ymin

                    Next

                Case "Regular"
                    nNorm = Convert.ToInt32(TextBoxNumNorm.Text)
                    Dim nX, nY As Integer
                    nX = Math.Sqrt(nNorm)
                    nY = nNorm / nX
                    nNorm = nX * nY
                    Dim xSpacing As Double = (xmax - xmin) / (nX - 1)
                    Dim ySpacing As Double = (ymax - ymin) / (nY - 1)
                    kriging.X = Array.CreateInstance(GetType(Double), nNorm)
                    kriging.Y = Array.CreateInstance(GetType(Double), nNorm)
                    kriging.X(0) = xmin
                    kriging.Y(0) = ymin

                    For i = 0 To nX - 1
                        For j = 0 To nY - 1
                            kriging.X(i * nY + j) = xmin + i * xSpacing
                            kriging.Y(i * nY + j) = ymin + j * ySpacing

                        Next
                    Next

                Case Else
                    Throw New Exception("Cannot recognize the normative site selection method")
            End Select
            For i = 0 To nNorm - 1
                TextBox1.Text += kriging.X(i) & ", " & kriging.Y(i) & vbCrLf
            Next




        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


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

   

    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExport.Click
        'write the coordinates to a shapefile
    End Sub
End Class