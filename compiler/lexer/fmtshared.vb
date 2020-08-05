Public Class fmtshared
    Public tknfmt As tknformat
    Private sourceloc As String
    Dim bdyformatter As bodyformatter
    Dim state As statecursor
    Public xclass(0) As tknformat._class
    Public xmethods(0) As tknformat._method
    Dim funcstate As funcstatecursor
    Dim parastate As funcparastate
    Public Sub New(file As String)
        tknfmt = New tknformat
        sourceloc = file
        state = statecursor.OUT
        funcstate = funcstatecursor.OUT
        parastate = funcparastate.WAITFORSTARTBRACKET
        xmethods(0) = New tknformat._method
        xclass(0) = New tknformat._class
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

    Enum funcparastate
        WAITFORSTARTBRACKET
        WAITFORIDENTIFIER
        WAITFORASSIGNMENTOPERATOR
        WAITFORPARAMETERTYPE
        WAITFORNEWPARAMETER
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
                    dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "func main()
{...}")
                End If
            Case funcstatecursor.FUNCPARA
                Select Case parastate
                    Case funcparastate.WAITFORSTARTBRACKET
                        If rd_token = tokenhared.token.PRSTART Then
                            xmethods(i).nopara = True
                            parastate = funcparastate.WAITFORNEWPARAMETER
                            Return
                        Else
                            dserr.new_error(conserr.errortype.FUNCOPBRACKETEXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "func main()
{...}")
                        End If
                    Case funcparastate.WAITFORNEWPARAMETER
                        If rd_token = tokenhared.token.PREND Then
                            funcstate = funcstatecursor.FUNCSTBLOCK 'TODO : Return Type
                            Return
                        ElseIf rd_token = tokenhared.token.IDENTIFIER Then
                            xmethods(i).nopara = False
                            'TODO
                            Return
                        Else
                            dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "func get_data(id : i16)
{...}")
                        End If
                End Select

            Case funcstatecursor.FUNCSTBLOCK
                If rd_token = tokenhared.token.BLOCKOPEN Then
                    funcstate = funcstatecursor.FUNCBODY
                    bdyformatter = New bodyformatter("Func", sourceloc)
                    bdyformatter.new_token_shared(value, rd_token, linecinf)
                Else
                    dserr.new_error(conserr.errortype.BLOCKOPENEXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "func get_data(id : i16)
{...}")
                End If

            Case funcstatecursor.FUNCBODY
                If bdyformatter.new_token_shared(value, rd_token, linecinf) = True Then
                    xmethods(i).bodyxmlfmt = bdyformatter.xmlresult
                    _settingup()
                End If
        End Select

    End Sub

    Public Function _to_organize() As tknformat._class
        xclass(0).methods = xmethods
        xclass(0).name = conrex.NULL
        Return xclass(0)
    End Function
    Public Sub _settingup()
        state = statecursor.OUT
        funcstate = funcstatecursor.OUT
        parastate = funcparastate.WAITFORSTARTBRACKET
    End Sub

End Class
