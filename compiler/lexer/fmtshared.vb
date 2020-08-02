Public Class fmtshared
    Public tknfmt As tknformat
    Private sourceloc As String
    Dim state As statecursor
    Dim xmethods(1) As tknformat._method
    Public Sub New(file As String)
        tknfmt = New tknformat
        sourceloc = file
        state = statecursor.OUT
        xmethods(0) = New tknformat._method
    End Sub

    Enum statecursor
        INFUNC
        INIMPORTS
        OUT
    End Enum

    Enum funcstatecursor
        ACCESSRESTR
        FUNCINTRO
        FUNCNAME
        FUNCPARA
        FUNCSTBLOCK
        FUNCBODY
        FUNCENBLOCK
    End Enum
    Public Sub imp_token(value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf)
        If state = statecursor.OUT Then
            Select Case rd_token
                Case tokenhared.token.FUNC
                    _rev_func(value, rd_token, linecinf)
            End Select
        End If
    End Sub



    Private Sub _rev_func(value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf)

    End Sub
End Class
