Imports NRMatrixNet
Module textboxmatrix
    Public Sub PrintMatrix(ByVal matrix As NRMatrixDotNet, ByRef text As String)
        Try
            Dim values As System.Array = matrix.GetArray()
            Dim nrows, ncols As Integer
            nrows = values.GetUpperBound(1)
            ncols = values.GetUpperBound(0)
            For i As Integer = 0 To nrows
                For j As Integer = 0 To ncols
                    text += Convert.ToString(values(j, i)) & ","
                Next
                text += vbCrLf

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
 
    Public Function GetMatrixArray(ByVal text As String) As NRMatrixDotNet()
        Dim matrix() As NRMatrixDotNet


        Dim separator1() As Char = {vbCrLf}
        Dim separator2() As Char = {vbCrLf, ",", ";", vbTab}
        Dim lines() As String = text.Split(separator1)

        Dim nlines As Integer = lines.Length
        matrix = Array.CreateInstance(GetType(NRMatrixDotNet), nlines)

        For i = 0 To nlines - 1
            matrix(i) = GetMatrix(lines(i)).T()

        Next
        Return matrix

    End Function
    Public Function GetMatrix(ByVal text As String) As NRMatrixDotNet
        Dim matrix As NRMatrixDotNet
        Try
            Dim separator1() As Char = {vbCrLf, vbCr, vbLf, vbNewLine}
            Dim separator2() As Char = {vbCrLf, ",", ";", vbTab}
            Dim lines() As String = text.Split(separator1)

            Dim nrows As Integer = lines.Length
            Dim words() As String = lines(0).Split(separator2)
            Dim ncols As Integer = words.Length


            Dim i, j As Integer
            Dim values(ncols - 1, nrows - 1) As Double


            For i = 0 To nrows - 1
                words = lines(i).Split(separator2)
                If (words.Length < ncols) Then
                    Continue For
                End If
                For j = 0 To ncols - 1

                    values(j, i) = Convert.ToDouble(words(j))
                Next
            Next
            matrix = New NRMatrixDotNet(values)

        Catch ex As Exception

        End Try
        Return matrix
    End Function
End Module
