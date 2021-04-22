Imports YOCA

Public Class var

    Private Shared elementindex As String
    Public ReadOnly Property get_element_index() As String
        Get
            Return elementindex
        End Get
    End Property
    Friend Shared Function check_identifier_validation(ByRef _ilmethod As ilformat._ilmethodcollection, clinecodestruc() As xmlunpkd.linecodestruc, ilinc As Integer, ByRef varname As String, localinit As localinitdata, path As String, Optional loadbyreference As Boolean = True) As mapstoredata.dataresult
        elementindex = conrex.NULL
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
                If servinterface.get_identifier_gb(varname, clinecodestruc(0), hfield) Then
                    localvartype.result = hfield.ptype
                Else
                    'Set Error
                    dserr.args.Add(varname)
                    dserr.new_error(conserr.errortype.TYPENOTFOUND, clinecodestruc(ilinc).line, path, authfunc.get_line_error(path, servinterface.get_target_info(clinecodestruc(ilinc)), varname))
                End If
            End If
        End If
        If iltranscore.isarrayinstack Then
            load_element_in_stack(varname, elementindex, localvartype.result, _ilmethod, clinecodestruc)
        End If
        servinterface.get_yo_common_data_type(localvartype.result, localvartype.result)
        Return localvartype
    End Function

    Private Shared Sub set_element(ByRef varname As String)
        If varname.Contains(conrex.BRSTART) Then
            Dim elementid As String = varname.Remove(0, varname.IndexOf(conrex.BRSTART)).Trim
            varname = varname.Remove(varname.IndexOf(conrex.BRSTART))
            If elementid = conrex.BREND Then Return
            elementindex = elementid.Remove(elementid.Length - 1).Trim
        End If
    End Sub

    Friend Shared Sub load_element_in_stack(varname As String, elementid As String, datatype As String, _ilmethod As ilformat._ilmethodcollection, clinecodestruc() As xmlunpkd.linecodestruc)
        illdloc.ld_identifier(varname, _ilmethod, clinecodestruc(0), Nothing, datatype)
    End Sub
End Class
