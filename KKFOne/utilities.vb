Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.ArcMapUI

Imports ESRI.ArcGIS.Geodatabase

Imports ESRI.ArcGIS.Geometry

Module utilities
   
    Public Function ObtainApplicationHandle() As ESRI.ArcGIS.Framework.IApplication
        Try
            Dim appRot As ESRI.ArcGIS.Framework.AppROT = New ESRI.ArcGIS.Framework.AppROT
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return Nothing
    End Function
    
    Public Sub ListFeatureLayers(ByRef pApp As ESRI.ArcGIS.Framework.IApplication, ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim iLyrIndex As Integer
            Dim pLyr As ILayer
            Dim focusMap As IMap = CType(pApp.Document, IMxDocument).FocusMap
            Dim pComboBox As Windows.Forms.ComboBox = CType(sender, Windows.Forms.ComboBox)

            pComboBox.Items.Clear()
            focusMap = CType(pApp.Document, IMxDocument).FocusMap
            ' Add raster layers into  Combobox
            Dim iLayerCount As Short
            iLayerCount = CType(focusMap.LayerCount, Short)
            If iLayerCount > 0 Then
                For iLyrIndex = 0 To iLayerCount - 1
                    pLyr = focusMap.Layer(iLyrIndex)
                    If (TypeOf (pLyr) Is IFeatureLayer) Then
                        pComboBox.Items.Add(pLyr.Name)
                    End If
                Next iLyrIndex
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Function GetFeaturClassByLayerName(ByRef pApp As ESRI.ArcGIS.Framework.IApplication, ByVal LayerName As String) As IFeatureClass
        Dim pLyr As IFeatureLayer = Nothing
        Try
            Dim focusmap As IMap = CType(pApp.Document, IMxDocument).FocusMap

            For nLyr = 0 To focusmap.LayerCount - 1
                If (focusmap.Layer(nLyr).Name = LayerName) Then
                    pLyr = focusmap.Layer(nLyr)
                    Return pLyr.FeatureClass
                End If
            Next

        Catch ex As Exception

        End Try
        Return Nothing
    End Function
    Public Function GetFeaturClassByOrder(ByRef pApp As ESRI.ArcGIS.Framework.IApplication, ByVal n As Integer) As IFeatureClass
        Dim pLyr As IFeatureLayer = Nothing
        Try
            Dim focusmap As IMap = CType(pApp.Document, IMxDocument).FocusMap
            If n > focusmap.LayerCount Then
                Return Nothing
            End If
            pLyr = focusmap.Layer(n - 1)
            Return pLyr.FeatureClass

        Catch ex As Exception

        End Try
        Return Nothing
    End Function
End Module
