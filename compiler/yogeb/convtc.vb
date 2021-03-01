Public Class convtc
    Friend Shared setconvmethod As Boolean = False
    Friend Shared ntypecast As String = String.Empty
    Friend Shared Sub is_type_casting(clinecodestruc As xmlunpkd.linecodestruc(), ByRef index As Integer)
        If clinecodestruc.Length <= index Then
            Return
        End If
        If clinecodestruc(index).tokenid = tokenhared.token.EXPLTYPECAST Then
            If clinecodestruc.Length > index + 1 Then
                setconvmethod = True
                get_type_cast(clinecodestruc(index))
                index += 1
            Else
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc(index).line, ilbodybulider.path, "After determining the data type, expect for Identifier / Method, etc." & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(index)), clinecodestruc(index).value))
            End If
        End If
    End Sub

    Private Shared Sub get_type_cast(clinecodestruc As xmlunpkd.linecodestruc)
        Dim ncommondatatype As String = clinecodestruc.value
        authfunc.rem_fr_and_en(ncommondatatype)
        servinterface.is_common_data_type(ncommondatatype, ntypecast)
    End Sub

    Friend Shared Sub set_type_cast(_ilmethod As ilformat._ilmethodcollection, newdtype As String, crdtype As String, nvar As String, cargcodestruc As xmlunpkd.linecodestruc)
        If crdtype <> ntypecast Then
            dserr.args.Add(crdtype)
            dserr.args.Add(ntypecast)
            dserr.new_error(conserr.errortype.EXPLICITCONVERSION, cargcodestruc.line, ilbodybulider.path, "Method : " & _ilmethod.name & " - identifier : " & nvar & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
        End If
        servinterface.is_common_data_type(newdtype, newdtype)
        Dim pconvertparam As New ArrayList
        pconvertparam.Add(newdtype)
        cil.call_extern_method(_ilmethod.codes, crdtype, "mscorlib", "System.Convert", get_convert_method(crdtype), pconvertparam)
        setconvmethod = False
        ntypecast = String.Empty
    End Sub
    Friend Shared Sub set_type_cast(_ilmethod As ilformat._ilmethodcollection, crdtype As String, nmethod As String, cargcodestruc As xmlunpkd.linecodestruc)
        servinterface.is_common_data_type(ntypecast, ntypecast)
        Dim pconvertparam As New ArrayList
        pconvertparam.Add(crdtype)
        cil.call_extern_method(_ilmethod.codes, ntypecast, "mscorlib", "System.Convert", get_convert_method(ntypecast), pconvertparam)
        setconvmethod = False
        ntypecast = String.Empty
    End Sub

    Friend Shared Function get_convert_method(crdtype As String) As String
        For index = 0 To conrex.msilcommondatatype.Length - 1
            If conrex.msilcommondatatype(index) = crdtype Then
                Return conrex.convmethod(index)
            End If
        Next
        Return conrex.NULL
    End Function

End Class
