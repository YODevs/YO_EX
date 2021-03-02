Public Class identvalid

    Structure _resultidentcvaild
        Dim asmextern As String
        Dim exclass As String
        Dim clident As String
        Dim classindex As Integer
        Dim identvalid As Boolean
        Dim callintern As Boolean
    End Structure

    Friend Shared Function get_identifier_valid(clinecodestruc As xmlunpkd.linecodestruc) As _resultidentcvaild
        Dim resultvaild As New _resultidentcvaild
        resultvaild.identvalid = False

        If check_intern_identifier(clinecodestruc, resultvaild) Then
            Return resultvaild
        ElseIf check_extern_identifier(clinecodestruc, resultvaild) Then
            Return resultvaild
        End If
        Return resultvaild
    End Function
    Friend Shared Function check_extern_identifier(clinecodestruc As xmlunpkd.linecodestruc, ByRef resultvalid As _resultidentcvaild) As Boolean
        If clinecodestruc.tokenid = tokenhared.token.IDENTIFIER AndAlso clinecodestruc.value.Contains("::") Then
            resultvalid.callintern = False
            set_identifier_valid(clinecodestruc, resultvalid)
        End If
        Return False
    End Function
    Friend Shared Function check_intern_identifier(clinecodestruc As xmlunpkd.linecodestruc, ByRef resultvalid As _resultidentcvaild) As Boolean
        If clinecodestruc.tokenid = tokenhared.token.IDENTIFIER AndAlso clinecodestruc.value.Contains("::") Then
            resultvalid.clident = True
            resultvalid.callintern = True
            set_identifier_valid(clinecodestruc, resultvalid)
            Dim classindex As Integer = funcdtproc.get_index_class(resultvalid.exclass)
            If classindex <> -1 Then
                resultvalid.classindex = classindex
                resultvalid.identvalid = True
                resultvalid.callintern = True
                Return True
            Else
                resultvalid.identvalid = False
                resultvalid.callintern = False
                Return False
            End If
        End If
        Return False
    End Function

    Private Shared Sub set_identifier_valid(clinecodestruc As xmlunpkd.linecodestruc, ByRef resultvalid As _resultidentcvaild)
        If resultvalid.callintern Then
            If clinecodestruc.value.Contains("::") Then
                Dim nsname As String = clinecodestruc.value
                Dim nmethod As String = nsname.Remove(0, nsname.IndexOf("::") + 2)
                nsname = nsname.Remove(nsname.IndexOf("::"))
                'Check exist class & method
                resultvalid.exclass = nsname
                resultvalid.clident = nmethod
            Else
                resultvalid.clident = clinecodestruc.value
                resultvalid.exclass = ilasmgen.classdata.attribute._app._classname
            End If
            Return
        Else
            If clinecodestruc.value.Contains("::") Then
                Dim nsname As String = clinecodestruc.value
                Dim nmethod As String = nsname.Remove(0, nsname.IndexOf("::") + 2)
                nsname = nsname.Remove(nsname.IndexOf("::"))
                resultvalid.exclass = nsname
                resultvalid.clident = nmethod
                resultvalid.asmextern = conrex.NULL
                resultvalid.identvalid = True
            Else
                resultvalid.identvalid = False
                set_expect_error(clinecodestruc, 0, "::")
            End If
        End If
    End Sub
    Private Shared Sub set_expect_error(clinecodestruc As xmlunpkd.linecodestruc, index As Integer, expectcode As String)
        dserr.args.Add(expectcode)
        dserr.new_error(conserr.errortype.EXPECTEDERROR, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
    End Sub
End Class
