Public Class setinattr

    Public Shared Sub init(ByRef yoattr As yocaattribute.yoattribute)
        yoattr._cfg._cilinject = False
        yoattr._cfg._optimize_expression = True

        yoattr._app._classname = compdt.yomainclass
    End Sub

    Public Shared Function get_bool_val(yoattr As yocaattribute.resultattribute, path As String) As Boolean
        Dim expression As String = yoattr.valueattribute.ToLower
        If expression = "0" OrElse expression = "false" Then
            Return False
        ElseIf expression = "1" OrElse expression = "true" Then
            Return True
        Else
            'Set Error
            dserr.args.Add("constant typing")
            dserr.args.Add("bool")
            dserr.new_error(conserr.errortype.EXPLICITCONVERSION, attr.lastlinecinf.line, path, authfunc.get_line_error(path, attr.lastlinecinf, yoattr.valueattribute))
        End If
        Return False
    End Function

    Public Shared Function get_str_val(yoattr As yocaattribute.resultattribute, path As String) As String
        Dim expression As String = yoattr.valueattribute
        If expression.StartsWith(conrex.COSTR) AndAlso expression.EndsWith(conrex.COSTR) Then
            authfunc.rem_fr_and_en(expression)
            Return expression
        ElseIf expression.StartsWith(conrex.DUSTR) AndAlso expression.EndsWith(conrex.DUSTR) Then
            authfunc.rem_fr_and_en(expression)
            Return expression
        Else
            'Set Error
            dserr.args.Add(expression)
            dserr.args.Add("str")
            dserr.new_error(conserr.errortype.EXPLICITCONVERSION, attr.lastlinecinf.line, path, authfunc.get_line_error(path, attr.lastlinecinf, yoattr.valueattribute))
        End If
        Return False
    End Function

End Class
