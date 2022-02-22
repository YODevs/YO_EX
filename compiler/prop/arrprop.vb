Public Class arrprop
    Friend Shared Function check_array_property(ByRef ilmethod As ilformat._ilmethodcollection, propresult As identvalid._resultidentcvaild, varname As String) As Boolean
        Dim gtypeinfo As ilformat._typeinfo = servinterface.get_variable_type(ilmethod, varname)
        If gtypeinfo.isarray = False Then Return False
        Select Case propresult.clident.ToLower
            Case "length"
                get_length(ilmethod, propresult, varname, gtypeinfo)
            Case "longlength"
                get_longlength(ilmethod, propresult, varname, gtypeinfo)
            Case Else
                Return False
        End Select
        Return True
    End Function

    Private Shared Sub get_length(ByRef ilmethod As ilformat._ilmethodcollection, propresult As identvalid._resultidentcvaild, varname As String, gtypeinfo As ilformat._typeinfo)
        illdloc.ld_identifier(varname, ilmethod, Nothing, Nothing, "int32")
        cil.ldlen(ilmethod.codes)
        cil.conv_to_int32(ilmethod.codes)
    End Sub
    Private Shared Sub get_longlength(ByRef ilmethod As ilformat._ilmethodcollection, propresult As identvalid._resultidentcvaild, varname As String, gtypeinfo As ilformat._typeinfo)
        illdloc.ld_identifier(varname, ilmethod, Nothing, Nothing, "int32")
        cil.ldlen(ilmethod.codes)
        cil.conv_to_int64(ilmethod.codes)
    End Sub
End Class
