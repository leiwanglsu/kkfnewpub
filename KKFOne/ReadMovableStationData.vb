Imports ESRI.ArcGIS.Geodatabase

Imports ESRI.ArcGIS.ArcMapUI
Imports NRMatrixNet
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geometry
Imports System.Threading.Tasks
Imports KKFClassLib
Public Class ReadMovableStationData
    Public m_application As ESRI.ArcGIS.Framework.IApplication
    Public pDataPoints() As Array
    Public pDataMatrix() As NRMatrixDotNet

    ' Public m_pKDTree() As KDTree(Of Point2D)
    Private Sub ButtonReadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReadData.Click
        'read the feature class
        Try
            'read each feature class in the map and get the data by the name
            If m_application Is Nothing Then
                Return
            End If
            Dim nTimes As Integer = Convert.ToInt16(TextBoxNLayers.Text)
            pDataPoints = Array.CreateInstance(GetType(Array), nTimes)
            pDataMatrix = Array.CreateInstance(GetType(NRMatrixDotNet), nTimes)
            Me.ToolStripStatusLabel1.Text = "Reading data"
            Dim threshold As Double = Convert.ToDouble(TextBoxNoData.Text)
            Dim nReady As Integer = 0
            'm_pKDTree = New KDTree(Of Point2D)(nTimes - 1) {}

            Parallel.For(0, nTimes, Sub(i)

                                        Dim Pnts As ArrayList = New ArrayList
                                        ' Dim pValues As ArrayList = New ArrayList
                                        'read layer by layer and put the coordinates and data into a 3D point structure?

                                        Dim pFeatCls As IFeatureClass = GetFeaturClassByOrder(m_application, i + 1)
                                        'calculate the H matrix at this site
                                        Dim nFeats As Integer = pFeatCls.FeatureCount(Nothing)
                                        ' m_pKDTree(i) = New KDTree(Of Point2D)(2)
                                        Dim pFeatCur As IFeatureCursor
                                        Dim pF As IFeature

                                        pFeatCur = pFeatCls.Search(Nothing, True)
                                        Dim nFields As Integer = pFeatCls.FindField(TextBoxFieldName.Text)
                                        Dim p2DPoint As Point2D
                                        For j As Integer = 0 To nFeats - 1
                                            pF = pFeatCur.NextFeature


                                            If pF.Value(nFields) > threshold Then 'skip nodata
                                                p2DPoint = New Point2D

                                                p2DPoint.X = CType(pF.Shape, IPoint).X
                                                p2DPoint.Y = CType(pF.Shape, IPoint).Y
                                                p2DPoint.Value = pF.Value(nFields)

                                                Pnts.Add(p2DPoint)

                                                '    m_pKDTree(i).Add(New Double() {pnt.X, pnt.Y}, p2DPoint)
                                            End If

                                        Next
                                        Dim nPnts As Integer = Pnts.Count
                                        pDataMatrix(i) = New NRMatrixDotNet(nPnts, 1)
                                        pDataPoints(i) = Array.CreateInstance(GetType(Point2D), nPnts)
                                        If nPnts > 0 Then
                                            For j As Integer = 0 To nPnts - 1
                                                pDataMatrix(i).SetValue(j, 0, CType(Pnts(j), Point2D).Value)
                                                pDataPoints(i)(j) = Pnts(j)
                                            Next
                                        End If
                                        nReady += 1
                                        Me.ToolStripStatusLabel1.Text = nReady & " of " & nTimes & " data are ready"
                                    End Sub)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Dim focusMap As IMap = CType(m_application.Document, IMxDocument).FocusMap
            focusMap = CType(m_application.Document, IMxDocument).FocusMap
            ' Add raster layers into  Combobox
            Dim iLayerCount As Short
            iLayerCount = CType(focusMap.LayerCount, Short)
            TextBoxNLayers.Text = iLayerCount
        Catch ex As Exception

        End Try
    End Sub
End Class