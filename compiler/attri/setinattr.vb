Public Class setinattr

    Public Shared Sub init(ByRef yoattr As yocaattribute.yoattribute)
        yoattr._cfg._cilinject = False
    End Sub

    Public Shared Function get_bool_val(yoattr As yocaattribute.resultattribute, path As String) As Boolean
        Dim experssion As String = yoattr.valueattribute.ToLower
        If experssion = "0" OrElse experssion = "false" Then
            Return False
        ElseIf experssion = "1" OrElse experssion = "true" Then
            Return True
        Else
            'Set Error
            dserr.args.Add("constant typing")
            dserr.args.Add("bool")
            dserr.new_error(conserr.errortype.EXPLICITCONVERSION, attr.lastlinecinf.line, path, authfunc.get_line_error(path, attr.lastlinecinf, yoattr.valueattribute))
        End If
        Return False
    End Function
End Class
