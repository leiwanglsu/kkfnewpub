Imports ESRI.ArcGIS.Geodatabase
Imports System.IO
Imports ESRI.ArcGIS.ArcMapUI
Imports NRMatrixNet
Imports KKFClassLib

Public Class FormSTInterpolation
    Public pVariogram As NRMatrixNet.Variogram
    Public m_application As ESRI.ArcGIS.Framework.IApplication
    Public kriging As PrincipalKriging
    Public pKKF As KKFClass
    Dim textboxaction As TextBox
    Private Sub ButtonLink_Click(sender As System.Object, e As System.EventArgs) Handles ButtonLink.Click
        m_application = ObtainApplicationHandle()
    End Sub

    Private Sub ComboBoxInput_DropDown(sender As Object, e As System.EventArgs) Handles ComboBoxInput.DropDown

        Try
            ListFeatureLayers(m_application, sender, e)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonReadCoor_Click(sender As System.Object, e As System.EventArgs) Handles ButtonReadCoor.Click
        Try
            Dim pFeatCls As IFeatureClass = GetFeaturClassByLayerName(m_application, ComboBoxInput.Text)
            Dim pFeatCnt As Integer = pFeatCls.FeatureCount(Nothing)
            Dim n As Integer = Convert.ToInt32(TextBoxID.Text)
            Dim pFeatCur As IFeatureCursor
            Dim pF As IFeature
            pFeatCur = pFeatCls.Search(Nothing, True)
            For i = 0 To pFeatCnt - 1
                pF = pFeatCur.NextFeature
                If i = n Then
                    Dim pnt As ESRI.ArcGIS.Geometry.IPoint = pF.Shape
                    TextBoxX.Text = pnt.X
                    TextBoxY.Text = pnt.Y

                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonInterpolation.Click
        Try
            'calculate the covariance model
            Dim X, Y As Double
            X = Convert.ToDouble(TextBoxX.Text)
            Y = Convert.ToDouble(TextBoxY.Text)

            ' PrintMatrix(H, TextBoxResult.Text)
            Dim Pnts() As Point2D = Array.CreateInstance(GetType(Point2D), 1)
            Pnts(0) = New Point2D
            Pnts(0).X = X
            Pnts(0).Y = Y
            Dim timeSereis As NRMatrixDotNet() = pKKF.PredictByPoints(kriging, Pnts)

            'report the result
            TextBoxResult.Text = "Prediction" & vbCr
            For i As Integer = 0 To pKKF.nTimes - 1
                PrintMatrix(timeSereis(i), TextBoxResult.Text)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ComboBoxObservation_DropDown(sender As Object, e As System.EventArgs)

        Try
            ListFeatureLayers(m_application, sender, e)

        Catch ex As Exception

        End Try
    End Sub
End Class