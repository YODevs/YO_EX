Imports YOCA

Public Class condproc

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
End Class
