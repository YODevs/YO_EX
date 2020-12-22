Imports YOCA

Public Class condproc

    Dim sncond(0) As singlecondition
    Structure singlecondition
        Dim lvalue As xmlunpkd.linecodestruc
        Dim optcond As tokenhared.token
        Dim rvalue As xmlunpkd.linecodestruc
        Dim sepopt As tokenhared.token
    End Structure

    Enum sepstate
        lval
        opt
        rval
        sepopt
    End Enum
    Friend Shared Function get_condition(clinecodestruc As xmlunpkd.linecodestruc(), Optional stindex As Integer = 0) As xmlunpkd.linecodestruc()
        Dim conditioncodestruc(0) As xmlunpkd.linecodestruc
        If clinecodestruc.Length < 3 Then
            dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End If

        If clinecodestruc(stindex).tokenid <> tokenhared.token.PRSTART Then
            dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End If

        Dim cid As Integer = 0
        For index = stindex + 1 To clinecodestruc.Length - 1
            If clinecodestruc(index).tokenid <> tokenhared.token.PREND Then
                conditioncodestruc(cid) = clinecodestruc(index)
                cid += 1
                Array.Resize(conditioncodestruc, cid + 1)
            Else
                Exit For
            End If
        Next
        Array.Resize(conditioncodestruc, cid)
        Return conditioncodestruc
    End Function

    Friend Shared Function get_block_body(clinecodestruc() As xmlunpkd.linecodestruc) As xmlunpkd.linecodestruc
        For index = 0 To clinecodestruc.Length - 1
            If clinecodestruc(index).tokenid = tokenhared.token.BLOCKOP Then
                Return clinecodestruc(index)
            End If
        Next

        dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value) & vbCrLf & "Block body not found.")
        Return Nothing
    End Function

    Public Sub New()
        sncond(0) = New singlecondition
    End Sub

    Public Sub set_condition(ByRef _ilmethod As ilformat._ilmethodcollection, condlinecodestruc As xmlunpkd.linecodestruc())
        coutputdata.print_token(condlinecodestruc)
        sep_condition(condlinecodestruc)
    End Sub


    Private Sub sep_condition(condlinecodestruc As xmlunpkd.linecodestruc())
        Dim ibar As Integer = 0
        Dim opt As String = conrex.NULL
        Dim spstate As New sepstate
        spstate = sepstate.lval
        For index = 0 To condlinecodestruc.Length - 1
            Select Case spstate
                Case sepstate.lval
                    sncond(ibar).lvalue = condlinecodestruc(index)
                    spstate = sepstate.opt
                Case sepstate.opt
                    opt &= condlinecodestruc(index).value
                    If opt.Length = 2 Then
                        get_condition_opt(sncond(ibar).optcond, opt, condlinecodestruc(index))
                        spstate = sepstate.rval
                        opt = conrex.NULL
                    End If
                Case sepstate.rval
                    sncond(ibar).lvalue = condlinecodestruc(index)
                    spstate = sepstate.sepopt
                Case sepstate.sepopt

            End Select
        Next
    End Sub

    Private Sub get_condition_opt(ByRef optcond As tokenhared.token, optval As String, linecodestruc As xmlunpkd.linecodestruc)
        optcond = tokenhared.check_sym(optval)
        For index = 0 To tokenhared.conditiontoken.Length - 1
            If optval = tokenhared.conditiontoken(index) Then
                Return
            End If
        Next

        dserr.new_error(conserr.errortype.SYNTAXERROR, linecodestruc.line, ilbodybulider.path, "Expression expected , '" & optval & "' The operator could not be identified." & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(linecodestruc), optval))
    End Sub
End Class
