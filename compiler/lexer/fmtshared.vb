Public Class fmtshared
    Public tknfmt As tknformat
    Private sourceloc As String
    Public Sub New(file As String)
        tknfmt = New tknformat
        sourceloc = file
    End Sub

    Public Sub imp_token(value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf)
        MsgBox(value)
    End Sub

End Class
