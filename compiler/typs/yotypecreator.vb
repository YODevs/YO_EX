Public Class yotypecreator
    Public Shared Function get_type_info(ilmethod As ilformat._ilmethodcollection, clinecodestruc As xmlunpkd.linecodestruc(), indclass As Integer, typestr As String) As ilformat._typeinfo
        Dim tpinf As New ilformat._typeinfo
        If servinterface.is_cil_common_data_type(typestr) OrElse servinterface.is_common_data_type(typestr, Nothing) Then

        Else
            Dim classresult As funcvalid._resultfuncvaild = get_class_valid_rtype(ilmethod, clinecodestruc, indclass)
        End If
        Return tpinf
    End Function

    Private Shared Function get_class_valid_rtype(ilmethod As ilformat._ilmethodcollection, clinecodestruc As xmlunpkd.linecodestruc(), indclass As Integer) As funcvalid._resultfuncvaild
        Dim glinecodestruc() As xmlunpkd.linecodestruc = servinterface.trim_line_code_struc(clinecodestruc, indclass)
        glinecodestruc(0).value &= "::.ctor"
        Return funcvalid.get_func_valid(ilmethod, glinecodestruc)
    End Function
End Class
