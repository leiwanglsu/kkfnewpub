Imports ESRI.ArcGIS.Geodatabase
Imports System.IO
Imports ESRI.ArcGIS.ArcMapUI
Imports NRMatrixNet

Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geometry
Imports Accord.Collections
Imports System.Windows.Forms
Imports KKFClassLib
'Imports KKFProgram2017
Public Class ReadFixedStationData
    Public m_application As ESRI.ArcGIS.Framework.IApplication
    Public pDataPoints() As Array
    Public pDataMatrix() As NRMatrixDotNet

    Private Sub ButtonReadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReadData.Click
        'read the feature class
        Try

            Dim pFeatCls As IFeatureClass = GetFeaturClassByLayerName(m_application, ComboBoxInput.Text)


            Dim i As Integer
            Dim pFeatCur As IFeatureCursor

            Dim pF As IFeature

            Dim scale As Double = Convert.ToDouble(TextBoxScale.Text)
            Dim nStartField As Integer = pFeatCls.FindField(ComboBoxFields.Text)
            Dim nEndFields As Integer = nStartField + Convert.ToInt32(TextBoxNumTimes.Text) - 1 'assuming the last one is the last field
            Dim nTrendField As Integer = pFeatCls.FindField(ComboBoxTrendField.Text)
            Dim nFeats As Integer = pFeatCls.FeatureCount(Nothing)
            Dim nTime As Integer = nEndFields - nStartField + 1
            pDataMatrix = Array.CreateInstance(GetType(NRMatrixDotNet), nTime)
            pDataPoints = Array.CreateInstance(GetType(Array), nTime)
            Dim nodata As Double = Convert.ToDouble(TextBoxNoData.Text)
            '  m_pTrans = New NRMatrixNet.Transformation
            ' m_pTrans.IsTransformed = CheckBox1.Checked

            ' m_pKDTree = New KDTree(Of Point2D)(nTime - 1) {}

            'check 


            Dim nTimes As Integer = nEndFields - nStartField + 1
            For n As Integer = 0 To nTimes - 1
                ' m_pKDTree(n - nStartField) = New KDTree(Of Point2D)(2)
                Dim pDataList As ArrayList = New ArrayList
                Dim p2DPoint As Point2D

                pFeatCur = pFeatCls.Search(Nothing, True)
                For i = 0 To nFeats - 1
                    pF = pFeatCur.NextFeature

                    Dim trend As Double = 0
                    If (nTrendField >= 0) Then
                        trend = pF.Value(nTrendField)

                    End If
                    Dim value As Double = pF.Value(n + nStartField)

                    If value > nodata Then
                        'pnt = New Point
                        p2DPoint = New Point2D
                        p2DPoint.X = CType(pF.Shape, IPoint).X
                        '  p2DPoint.X = pnt.X
                        p2DPoint.Y = CType(pF.Shape, IPoint).Y
                        '   p2DPoint.Y = pnt.Y

                        p2DPoint.Value = (value - trend) * scale
                        pDataList.Add(p2DPoint)

                    End If
                Next
                Dim nPnts As Integer = pDataList.Count
                pDataMatrix(n) = New NRMatrixDotNet(nPnts, 1)
                pDataPoints(n) = Array.CreateInstance(GetType(Point2D), nPnts)
                For i = 0 To nPnts - 1
                    pDataMatrix(n).SetValue(i, 0, CType(pDataList(i), Point2D).Value)
                    pDataPoints(n)(i) = pDataList(i)
                Next

                ShowProgressMessage("Reading time " & (n - nStartField + 1))

            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub ShowProgressMessage(ByVal msg As String)
        ToolStripStatusLabel1.Text = msg
        Windows.Forms.Application.DoEvents()
    End Sub
    Private Sub ComboBoxInput_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxInput.DropDown
        Try
            ListFeatureLayers(m_application, sender, e)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBoxFields_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxFields.DropDown
        Try
            Dim pCombobox As ComboBox = CType(sender, ComboBox)
            pCombobox.Items.Clear()

            Dim pfeatcls As IFeatureClass = GetFeaturClassByLayerName(m_application, ComboBoxInput.Text)
            For i As Integer = 0 To pfeatcls.Fields.FieldCount - 1
                pCombobox.Items.Add(pfeatcls.Fields.Field(i).Name)

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBoxTrendField_DropDown(sender As Object, e As EventArgs) Handles ComboBoxTrendField.DropDown
        Try
            Dim pCombobox As ComboBox = CType(sender, ComboBox)
            pCombobox.Items.Clear()

            Dim pfeatcls As IFeatureClass = GetFeaturClassByLayerName(m_application, ComboBoxInput.Text)
            For i As Integer = 0 To pfeatcls.Fields.FieldCount - 1
                pCombobox.Items.Add(pfeatcls.Fields.Field(i).Name)

            Next
        Catch ex As Exception

        End Try
    End Sub
End Class