Public Class objvirmethod
    Friend Shared Function check_object_method(ByRef ilmethod As ilformat._ilmethodcollection, propresult As identvalid._resultidentcvaild, varname As String) As Boolean
        Dim gtypeinfo As ilformat._typeinfo = servinterface.get_variable_type(ilmethod, varname)
        illdloc.ld_identifier(varname, ilmethod, Nothing, Nothing, gtypeinfo.fullname)
        Select Case propresult.clident.ToLower
            Case "gettype"
                set_gettype(ilmethod)
            Case "gethashcode"
                set_gethashcode(ilmethod)
            Case Else
                Return False
        End Select
        Return True
    End Function

    Private Shared Sub set_gettype(ByRef ilmethod As ilformat._ilmethodcollection)
        cil.call_virtual_method(ilmethod.codes, String.Format("[{0}]System.Type", compdt.CORELIB), compdt.CORELIB, "System.Object", "GetType", Nothing)
    End Sub
    Private Shared Sub set_gethashcode(ByRef ilmethod As ilformat._ilmethodcollection)
        cil.call_virtual_method(ilmethod.codes, "int32", compdt.CORELIB, "System.String", "GetHashCode", Nothing)
    End Sub
End Class
