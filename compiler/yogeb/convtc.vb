Public Class convtc
    Friend Shared setconvmethod As Boolean = False
    Friend Shared Sub is_type_casting(clinecodestruc As xmlunpkd.linecodestruc(), ByRef index As Integer)
        If clinecodestruc.Length <= index Then
            Return
        End If
        If clinecodestruc(index).tokenid = tokenhared.token.EXPLTYPECAST Then
            If clinecodestruc.Length > index + 1 Then
                index += 1
                setconvmethod = True
            Else
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc(index).line, ilbodybulider.path, "After determining the data type, expect for Identifier / Method, etc." & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(index)), clinecodestruc(index).value))
            End If
        End If
    End Sub
End Class
