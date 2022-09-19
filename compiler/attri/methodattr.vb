Imports YOLIB

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
            Case tokenhared.token.TRUE
                Return value
            Case tokenhared.token.FALSE
                Return value
            Case Else
                dserr.args.Add("Attribute value format is not allowed.")
                dserr.new_error(conserr.errortype.METHODATTRIBUTEERROR, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), ".maxstack 8")
        End Select
    End Function

    Friend Shared Function get_attribute_by_i32(method As ilformat._ilmethodcollection, key As String, defresult As Integer) As Integer
        Dim result As Object
        Try
            result = method.attributes.get(key)
        Catch ex As Exception
            Return defresult
        End Try
        If IsNumeric(result) = False Then
            set_warning(method.name, key, defresult, result)
            Return defresult
        End If
        Return result
    End Function

    Private Shared Sub set_warning(name As String, key As String, defresult As Object, result As Object)
        dswar.set_warning("Worng data-type", String.Format("The attribute '{0}' in the method '{1}' has the wrong value '{2}', so the compiler sets the default value '{3}' for this attribute.", key, name, result, defresult), ilbodybulider.path)
    End Sub

    Friend Shared Function get_attribute_by_bool(method As ilformat._ilmethodcollection, key As String, defresult As Boolean) As Boolean
        Dim result As Object
        Try
            result = method.attributes.get(key).ToString.ToLower
        Catch ex As Exception
            Return defresult
        End Try
        If result <> "true" AndAlso result <> "false" Then
            set_warning(method.name, key, defresult, result)
            Return defresult
        End If
        Return result
    End Function
End Class
