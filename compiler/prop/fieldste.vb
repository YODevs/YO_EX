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
