Imports YOCA

Public Class enumeration
    Friend Shared Function is_enum(ByRef _ilmethod As ilformat._ilmethodcollection, idenresult As identvalid._resultidentcvaild, cargcodestruc As xmlunpkd.linecodestruc) As Boolean
        If idenresult.identvalid = False Then Return False
        Dim exname As String = idenresult.exclass
        Dim classname As String = ilasmgen.classdata.attribute._app._classname
        Dim enumname As String = String.Empty
        Dim isvirtual As Boolean = False
        libserv.get_identifier_ns(_ilmethod, exname, isvirtual)
        If isvirtual Then
            classname = exname.Remove(exname.LastIndexOf(conrex.DOT))
            enumname = exname.Remove(0, exname.LastIndexOf(conrex.DOT) + 1)
        Else

        End If

        Dim classindex As Integer = funcdtproc.get_index_class(_ilmethod, classname, False)
        If classindex = -1 Then

            Return False
        Else
            Dim enumindex As Integer = funcdtproc.get_index_enum(enumname, classindex)
            If enumindex = -1 Then

                Return False
            End If

            Dim enumtp As tknformat._enum = funcdtproc.get_enum_info(classindex, enumindex)
            set_internal_enum_value(_ilmethod, enumtp, idenresult.clident, cargcodestruc, exname)
            Return True
        End If
        Return False
    End Function

    Private Shared Sub set_internal_enum_value(ByRef ilmethod As ilformat._ilmethodcollection, enumtp As tknformat._enum, clident As String, cargcodestruc As xmlunpkd.linecodestruc, exname As String)
        For index = 0 To enumtp.constkeys.Count - 1
            If enumtp.constkeys(index).ToString.ToLower = clident.ToLower Then
                cil.push_int32_onto_stack(ilmethod.codes, enumtp.constvalues(index))
                Return
            End If
        Next
        dserr.args.Add(clident)
        dserr.args.Add(exname)
        dserr.new_error(conserr.errortype.ENUMMEMBERERROR, cargcodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
    End Sub
End Class
