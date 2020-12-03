Public Class funcvalid

    Structure _resultfuncvaild
        Dim asmextern As String
        Dim exclass As String
        Dim clmethod As String
        Dim funcvalid As Boolean
        Dim callintern As Boolean
    End Structure
    Friend Shared Function check_func_syn(clinecodestruc() As xmlunpkd.linecodestruc) As Boolean
        For index = 0 To clinecodestruc.Length - 1

        Next
        Return True
    End Function

    Friend Shared Function get_func_valid(clinecodestruc() As xmlunpkd.linecodestruc) As _resultfuncvaild
        Dim resultvaild As New _resultfuncvaild
        resultvaild.funcvalid = False
        Dim len As Integer = clinecodestruc.Length
        If len < 2 Then
            Return resultvaild
        End If

        If check_intern_method(clinecodestruc, resultvaild) Then
            Return resultvaild
        ElseIf check_extern_method(clinecodestruc, resultvaild) Then
            Return resultvaild
        End If
        Return resultvaild
    End Function
    Friend Shared Function check_extern_method(clinecodestruc() As xmlunpkd.linecodestruc, ByRef resultvalid As _resultfuncvaild) As Boolean
        If clinecodestruc(0).tokenid = tokenhared.token.IDENTIFIER AndAlso
                clinecodestruc(1).tokenid = tokenhared.token.PRSTART Then

            If clinecodestruc(clinecodestruc.Length - 1).tokenid <> tokenhared.token.PREND Then
                set_expect_error(clinecodestruc, clinecodestruc.Length - 1, ")")
                Return False
            Else
                resultvalid.callintern = False
                set_func_vaild(clinecodestruc, resultvalid)
            End If
        End If
        Return False
    End Function
    Friend Shared Function check_intern_method(clinecodestruc() As xmlunpkd.linecodestruc, ByRef resultvalid As _resultfuncvaild) As Boolean
        If clinecodestruc(0).tokenid = tokenhared.token.IDENTIFIER AndAlso
                clinecodestruc(1).tokenid = tokenhared.token.PRSTART Then

            If clinecodestruc(clinecodestruc.Length - 1).tokenid <> tokenhared.token.PREND Then
                set_expect_error(clinecodestruc, clinecodestruc.Length - 1, ")")
                Return False
            Else
                resultvalid.funcvalid = True
                resultvalid.callintern = True
                set_func_vaild(clinecodestruc, resultvalid)
                Dim classindex As Integer = funcdtproc.get_index_class(resultvalid.exclass)
                If classindex <> -1 Then
                    resultvalid.funcvalid = True
                    resultvalid.callintern = True
                    Return True
                Else
                    resultvalid.funcvalid = False
                    resultvalid.callintern = False
                    Return False
                End If

            End If
        End If
        Return False
    End Function

    Private Shared Sub set_func_vaild(clinecodestruc() As xmlunpkd.linecodestruc, ByRef resultvalid As _resultfuncvaild)
        If resultvalid.callintern Then
            If clinecodestruc(0).value.Contains("::") Then
                Dim nsname As String = clinecodestruc(0).value
                Dim nmethod As String = nsname.Remove(0, nsname.IndexOf("::") + 2)
                nsname = nsname.Remove(nsname.IndexOf("::"))
                'Check exist class & method
                resultvalid.exclass = nsname
                resultvalid.clmethod = nmethod
            Else
                resultvalid.clmethod = clinecodestruc(0).value
                resultvalid.exclass = ilasmgen.classdata.attribute._app._classname
            End If
            Return
        Else
            If clinecodestruc(0).value.Contains("::") Then
                Dim nsname As String = clinecodestruc(0).value
                Dim nmethod As String = nsname.Remove(0, nsname.IndexOf("::") + 2)
                nsname = nsname.Remove(nsname.IndexOf("::"))
                resultvalid.exclass = nsname
                resultvalid.clmethod = nmethod
                resultvalid.asmextern = conrex.NULL
                resultvalid.funcvalid = True
            Else
                resultvalid.funcvalid = False
                set_expect_error(clinecodestruc, 0, "::")
            End If
        End If
    End Sub
    Private Shared Sub set_expect_error(clinecodestruc() As xmlunpkd.linecodestruc, index As Integer, expectcode As String)
        dserr.args.Add(expectcode)
        dserr.new_error(conserr.errortype.EXPECTEDERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(index)), clinecodestruc(index).value))
    End Sub
End Class