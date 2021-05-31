Imports System.Reflection
Imports YOCA

Public Class fieldste
    Friend Shared Sub inv_external_field(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, fieldresult As identvalid._resultidentcvaild, inline As Integer, optval As tokenhared.token, namespaceindex As Integer, classindex As Integer, retfieldinfo As FieldInfo)
        Dim ldloc As New illdloc(_ilmethod)
        Dim setconvmethod As Boolean = convtc.setconvmethod
        Dim ntypecast As String = convtc.ntypecast
        Dim gdatatype As String = retfieldinfo.FieldType.Name
        gdatatype = servinterface.vb_to_cil_common_data_type(gdatatype)
        If servinterface.is_cil_common_data_type(gdatatype) = False Then
            gdatatype = retfieldinfo.FieldType.ToString
        End If
        If retfieldinfo.IsStatic = False Then
            Dim gidentifier As xmlunpkd.linecodestruc = clinecodestruc(0)
            If gidentifier.value.Contains(conrex.DBCLN) Then
                gidentifier.value = gidentifier.value.Remove(gidentifier.value.IndexOf(conrex.DBCLN))
                gidentifier.ile = gidentifier.value.Length
            End If
            _ilmethod = ldloc.load_single_in_stack(retfieldinfo.ReflectedType.ToString, gidentifier)
        End If
        convtc.setconvmethod = setconvmethod
        convtc.ntypecast = ntypecast
        ldloc.load_single_in_stack(gdatatype, clinecodestruc(inline))
        Dim fieldname As String = retfieldinfo.Name
        If convtc.setconvmethod Then convtc.set_type_cast(_ilmethod, gdatatype, fieldname, clinecodestruc(inline))
        Dim fclass As String = String.Format("[{0}]{1}", libserv.get_extern_assembly(namespaceindex), retfieldinfo.DeclaringType.FullName)
        Dim ftype As String = String.Format("[{0}]{1}", libserv.get_extern_assembly(retfieldinfo.FieldType.Assembly), retfieldinfo.FieldType.ToString)
        If retfieldinfo.IsStatic Then
            cil.set_static_field(_ilmethod.codes, fieldname, ftype, fclass)
        Else
            cil.set_field(_ilmethod.codes, fieldname, ftype, fclass)
        End If
    End Sub

    Friend Shared Sub inv_internal_field(clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilmethod As ilformat._ilmethodcollection, fieldresult As identvalid._resultidentcvaild, inline As Integer, optval As tokenhared.token)
        Dim classindex As Integer
        Dim isvirtualmethod As Boolean = False
        Dim fieldname As String = fieldresult.clident
        classindex = funcdtproc.get_index_class(ilmethod, fieldresult.exclass, isvirtualmethod)
        If classindex = -1 Then
            dserr.args.Add("Class '" & fieldresult.exclass & "' not found.")
            dserr.new_error(conserr.errortype.FIELDERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            Return
        End If
        Dim ldloc As New illdloc(ilmethod)
        Dim setconvmethod As Boolean = convtc.setconvmethod
        Dim ntypecast As String = convtc.ntypecast
        Dim fieldindex As Integer = funcdtproc.get_index_field(fieldresult.clident, classindex)
        If fieldindex = -1 Then
            dserr.args.Add("Field '" & fieldresult.clident & "' not found.")
            dserr.new_error(conserr.errortype.FIELDERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), fieldresult.clident))
            Return
        End If
        Dim nfield As tknformat._pubfield = funcdtproc.get_field_info(classindex, fieldindex)
        Dim gdatatype As String = nfield.ptype
        If isvirtualmethod Then
            Dim gidentifier As xmlunpkd.linecodestruc = clinecodestruc(0)
            If gidentifier.value.Contains(conrex.DBCLN) Then
                gidentifier.value = gidentifier.value.Remove(gidentifier.value.IndexOf(conrex.DBCLN))
                gidentifier.ile = gidentifier.value.Length
            End If
            ldloc.load_single_in_stack(gdatatype, gidentifier)

            ldloc.load_single_in_stack(gdatatype, clinecodestruc(inline))
            cil.set_field(ilmethod.codes, fieldname, gdatatype, fieldresult.exclass)
        Else
            ldloc.load_single_in_stack(gdatatype, clinecodestruc(inline))
            cil.set_static_field(ilmethod.codes, fieldname, gdatatype, fieldresult.exclass)
        End If


        convtc.setconvmethod = setconvmethod
        convtc.ntypecast = ntypecast
        If convtc.setconvmethod Then convtc.set_type_cast(ilmethod, gdatatype, fieldname, clinecodestruc(inline))

    End Sub

    Friend Shared Sub get_external_field(clinecodestruc() As xmlunpkd.linecodestruc, _ilmethod As ilformat._ilmethodcollection, fieldresult As identvalid._resultidentcvaild, inline As Integer, namespaceindex As Integer, classindex As Integer, retfieldinfo As FieldInfo, isvirtualmethod As Boolean)
        Dim ldloc As New illdloc(_ilmethod)
        Dim setconvmethod As Boolean = convtc.setconvmethod
        Dim ntypecast As String = convtc.ntypecast
        Dim gdatatype As String = retfieldinfo.FieldType.Name
        gdatatype = servinterface.vb_to_cil_common_data_type(gdatatype)
        If servinterface.is_cil_common_data_type(gdatatype) = False Then
            gdatatype = retfieldinfo.FieldType.ToString
        End If
        If retfieldinfo.IsStatic = False Then
            Dim gidentifier As xmlunpkd.linecodestruc = clinecodestruc(0)
            If gidentifier.value.Contains(conrex.DBCLN) Then
                gidentifier.value = gidentifier.value.Remove(gidentifier.value.IndexOf(conrex.DBCLN))
                gidentifier.ile = gidentifier.value.Length
            End If
            ldloc.load_single_in_stack(retfieldinfo.ReflectedType.ToString, gidentifier)
        End If
        Dim fieldname As String = retfieldinfo.Name
        Dim fclass As String = String.Format("[{0}]{1}", libserv.get_extern_assembly(namespaceindex), retfieldinfo.DeclaringType.FullName)
        Dim ftype As String = String.Format("[{0}]{1}", libserv.get_extern_assembly(retfieldinfo.FieldType.Assembly), retfieldinfo.FieldType.ToString)
        If setconvmethod = False AndAlso illdloc.eq_data_types(propertyste.assignmentype, retfieldinfo.FieldType.ToString) = False Then
            dserr.args.Add(retfieldinfo.FieldType.ToString)
            dserr.args.Add(propertyste.assignmentype)
            dserr.new_error(conserr.errortype.EXPLICITCONVERSION, clinecodestruc(0).line, ilbodybulider.path, "Method : " & _ilmethod.name & " - identifier : " & clinecodestruc(0).value & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            Return
        End If
        If retfieldinfo.IsStatic Then
            cil.load_static_field(_ilmethod.codes, fieldname, ftype, fclass)
        Else
            cil.load_field(_ilmethod.codes, fieldname, ftype, fclass)
        End If
        convtc.setconvmethod = setconvmethod
        convtc.ntypecast = ntypecast
        If convtc.setconvmethod Then convtc.set_type_cast(_ilmethod, gdatatype, fieldname, clinecodestruc(inline))
    End Sub

End Class
