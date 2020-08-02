Public Class fmtshared
    Public tknfmt As tknformat
    Private sourceloc As String
    Dim state As statecursor
    Dim xmethods(0) As tknformat._method
    Dim funcstate As funcstatecursor
    Public Sub New(file As String)
        tknfmt = New tknformat
        sourceloc = file
        state = statecursor.OUT
        funcstate = funcstatecursor.OUT
        xmethods(0) = New tknformat._method
    End Sub

    Enum statecursor
        INFUNC
        INIMPORTS
        OUT
    End Enum

    Enum funcstatecursor
        OUT
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

        ElseIf state = statecursor.INFUNC Then
            _rev_func(value, rd_token, linecinf)
        End If
    End Sub
    Private Sub _rev_func(value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf)
        Dim i As Integer = xmethods.Length - 1
        Select Case funcstate
            Case funcstatecursor.OUT
                If rd_token = tokenhared.token.FUNC Then
                    If xmethods.Length <> 1 Then
                        Array.Resize(xmethods, xmethods.Length)
                    End If
                    funcstate = funcstatecursor.FUNCNAME
                    state = statecursor.INFUNC
                    Return
                End If
            Case funcstatecursor.FUNCNAME
                If rd_token = tokenhared.token.IDENTIFIER Then
                    xmethods(i).name = value
                    funcstate = funcstatecursor.FUNCPARA
                Else
                    dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, authfunc.get_line_error(sourceloc, linecinf, value), "func main()
{...}")
                End If
        End Select

    End Sub

End Class
