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
        End If
        Return resultvaild
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
                resultvalid.clmethod = clinecodestruc(0).value
                Return True
            End If
        End If
        Return False
    End Function

    Private Shared Sub set_expect_error(clinecodestruc() As xmlunpkd.linecodestruc, index As Integer, expectcode As String)
        dserr.args.Add(expectcode)
        dserr.new_error(conserr.errortype.EXPECTEDERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(index)), clinecodestruc(index).value))
    End Sub
End Class
