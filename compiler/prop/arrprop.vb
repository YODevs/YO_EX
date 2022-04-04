Public Class arrprop
    Friend Shared Function check_array_property(ByRef ilmethod As ilformat._ilmethodcollection, linecodestruc As xmlunpkd.linecodestruc, propresult As identvalid._resultidentcvaild, varname As String) As Boolean
        Dim gtypeinfo As ilformat._typeinfo = servinterface.get_variable_type(ilmethod, varname)
        If gtypeinfo.isarray = False Then Return False
        Dim varlinecodestruc As xmlunpkd.linecodestruc = servinterface.create_fake_linecodestruc(tokenhared.token.IDENTIFIER, varname)
        varlinecodestruc.line = linecodestruc.line
        Select Case propresult.clident.ToLower
            Case "length"
                get_length(ilmethod, varlinecodestruc, varname, gtypeinfo)
            Case "longlength"
                get_longlength(ilmethod, varlinecodestruc, varname, gtypeinfo)
            Case Else
                Return False
        End Select
        Return True
    End Function

    Private Shared Sub get_length(ByRef ilmethod As ilformat._ilmethodcollection, varlinecodestruc As xmlunpkd.linecodestruc, varname As String, gtypeinfo As ilformat._typeinfo)
        illdloc.ld_identifier(varname, ilmethod, varlinecodestruc, Nothing, get_arr_type(gtypeinfo))
        cil.ldlen(ilmethod.codes)
        cil.conv_to_int32(ilmethod.codes)
    End Sub
    Private Shared Sub get_longlength(ByRef ilmethod As ilformat._ilmethodcollection, varlinecodestruc As xmlunpkd.linecodestruc, varname As String, gtypeinfo As ilformat._typeinfo)
        illdloc.ld_identifier(varname, ilmethod, varlinecodestruc, Nothing, get_arr_type(gtypeinfo))
        cil.ldlen(ilmethod.codes)
        cil.conv_to_int64(ilmethod.codes)
    End Sub

    Private Shared Function get_arr_type(gtypeinfo As ilformat._typeinfo) As String
        If gtypeinfo.namespace = "System" Then
            Return servinterface.vb_to_cil_common_data_type(gtypeinfo.name)
        End If
        Return gtypeinfo.fullname
    End Function

End Class
