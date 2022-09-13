Public Class methodattr

    Public Shared Function attribute_value_refinement(value As String, token As tokenhared.token, linecinf As lexer.targetinf, sourceloc As String) As String
        Select Case token
            Case tokenhared.token.TYPE_BOOL
                Return value.ToLower
            Case tokenhared.token.TYPE_CO_STR
                Return value
            Case tokenhared.token.TYPE_DU_STR
                Return value
            Case tokenhared.token.TYPE_FLOAT
                Return value
            Case tokenhared.token.TYPE_INT
                Return value
            Case Else
                dserr.args.Add("Attribute value format is not allowed.")
                dserr.new_error(conserr.errortype.METHODATTRIBUTEERROR, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), ".stacksize 8")
        End Select
    End Function
End Class
