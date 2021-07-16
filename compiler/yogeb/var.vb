Imports YOCA

Public Class var

    Private Shared privelementindex As String
    Public Shared ReadOnly Property elementindex() As String
        Get
            Return privelementindex
        End Get
    End Property
    Friend Shared Function check_identifier_validation(ByRef _ilmethod As ilformat._ilmethodcollection, clinecodestruc() As xmlunpkd.linecodestruc, ilinc As Integer, ByRef varname As String, localinit As localinitdata, path As String, Optional loadbyreference As Boolean = True) As mapstoredata.dataresult
        privelementindex = conrex.NULL
        If iltranscore.isarrayinstack Then
            set_element(varname)
        End If
        Dim localvartype As mapstoredata.dataresult = localinit.datatypelocal.find(varname, True, varname)
        If localvartype.issuccessful = False Then
            If localinit.datatypeparameter.find(varname, True, varname).issuccessful Then
                localvartype = localinit.datatypeparameter.find(varname, True, varname)
                If loadbyreference AndAlso servinterface.is_pointer(_ilmethod, varname) Then
                    cil.load_argument(_ilmethod.codes, varname)
                End If
            ElseIf IsNothing(localinitdata.fieldst) = False AndAlso localinitdata.fieldst.find(varname, True, varname).issuccessful Then
                localvartype = localinitdata.fieldst.find(varname, True, varname)
                If servinterface.get_field_from_current_class(varname).objcontrol.modifier = tokenhared.token.UNDEFINED Then
                    cil.insert_il(_ilmethod.codes, compdt.LOAD_FIRST_ARGUMENT)
                End If
            Else
                Dim hfield As tknformat._pubfield
                If servinterface.get_identifier_gb(_ilmethod, varname, clinecodestruc(0), hfield) Then
                    localvartype.result = hfield.ptype
                Else
                    'Set Error
                    dserr.args.Add(varname)
                    dserr.new_error(conserr.errortype.TYPENOTFOUND, clinecodestruc(ilinc).line, path, authfunc.get_line_error(path, servinterface.get_target_info(clinecodestruc(ilinc)), varname))
                End If
            End If
        End If
        If iltranscore.isarrayinstack Then
            load_element_in_stack(varname, privelementindex, localvartype.result, _ilmethod, clinecodestruc(0))
        End If
        servinterface.get_yo_common_data_type(localvartype.result, localvartype.result)
        Return localvartype
    End Function

    Private Shared Sub set_element(ByRef varname As String)
        If varname.Contains(conrex.BRSTART) Then
            Dim elementid As String = varname.Remove(0, varname.IndexOf(conrex.BRSTART) + 1).Trim
            varname = varname.Remove(varname.IndexOf(conrex.BRSTART))
            If elementid = conrex.BREND Then Return
            privelementindex = elementid.Remove(elementid.Length - 1).Trim
        End If
    End Sub

    Friend Shared Sub load_element_in_stack(varname As String, elementsp As String, datatype As String, _ilmethod As ilformat._ilmethodcollection, clinecodestruc As xmlunpkd.linecodestruc, Optional justloadelement As Boolean = False)
        If justloadelement = False Then illdloc.ld_identifier(varname, _ilmethod, clinecodestruc, Nothing, datatype)
        If IsNumeric(elementsp) Then
            servinterface.ldc_i_checker(_ilmethod.codes, elementsp, False, "int32")
        Else
            illdloc.ld_identifier(elementsp, _ilmethod, clinecodestruc, Nothing, "int32")
        End If
    End Sub

    Friend Shared Sub load_arr_identifier(ByRef _ilmethod As ilformat._ilmethodcollection, clinecodestruc As xmlunpkd.linecodestruc, rlinecodestruc As xmlunpkd.linecodestruc(), datatype As String)
        Dim clinearrname As xmlunpkd.linecodestruc = clinecodestruc
        clinearrname.value = clinecodestruc.value.Remove(clinearrname.value.IndexOf(conrex.BRSTART))
        clinearrname.tokenid = tokenhared.token.IDENTIFIER
        clinearrname.ile = clinearrname.value.Length
        illdloc.ld_identifier(clinearrname.value, _ilmethod, clinearrname, rlinecodestruc, datatype)

        Dim varname As String = clinecodestruc.value
        set_element(varname)
        load_element_in_stack(varname, privelementindex, datatype, _ilmethod, clinecodestruc, True)

        cil.ldelem(_ilmethod.codes)
    End Sub
End Class
