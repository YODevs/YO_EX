Imports System.Reflection
Imports YOCA

Public Class propertyste
    Friend Shared assignmentype As String

    Friend Shared Sub invoke_property(clinecodestruc() As xmlunpkd.linecodestruc, ilmethod As ilformat._ilmethodcollection, propresult As identvalid._resultidentcvaild, inline As Integer, optval As tokenhared.token)
        If propresult.callintern = True Then
            'check internal property & fields ...
            fieldste.inv_internal_field(clinecodestruc, ilmethod, propresult, inline, optval)
        Else
            inv_external_property(clinecodestruc, ilmethod, propresult, inline, optval)
        End If
    End Sub

    Friend Shared Sub inv_external_property(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, propresult As identvalid._resultidentcvaild, inline As Integer, optval As tokenhared.token)
        Dim classindex, namespaceindex As Integer
        Dim reclassname As String = String.Empty
        Dim isvirtualmethod As Boolean = False
        If libserv.get_extern_index_class(_ilmethod, propresult.exclass, namespaceindex, classindex, isvirtualmethod, reclassname) = -1 Then
            dserr.args.Add("Class '" & propresult.exclass & "' not found.")
            dserr.new_error(conserr.errortype.PROPERTYERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            Return
        End If
        propresult.asmextern = libserv.get_extern_assembly(namespaceindex)
        Dim retpropertyinfo As PropertyInfo
        If libserv.get_extern_index_property(propresult.clident, namespaceindex, classindex, retpropertyinfo) = -1 Then
            Dim retfieldinfo As FieldInfo
            If libserv.get_extern_index_field(propresult.clident, namespaceindex, classindex, retfieldinfo) <> -1 Then
                fieldste.inv_external_field(clinecodestruc, _ilmethod, propresult, inline, optval, namespaceindex, classindex, retfieldinfo)
                Return
            End If
            dserr.args.Add("Property '" & propresult.clident.ToLower & "' not found.")
            dserr.new_error(conserr.errortype.PROPERTYERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), propresult.clident))
            Return
        End If
        can_write(retpropertyinfo, propresult, clinecodestruc)
        check_access_control(retpropertyinfo.SetMethod, isvirtualmethod, clinecodestruc, propresult)
        'TODO : Properties support operators
        If optval <> tokenhared.token.ASSIDB Then
            get_inv_property(clinecodestruc, _ilmethod, propresult, inline)
        End If
        set_property(_ilmethod, retpropertyinfo, isvirtualmethod, inline, clinecodestruc, propresult, optval)
    End Sub

    Private Shared Sub set_property(_ilmethod As ilformat._ilmethodcollection, retpropertyinfo As PropertyInfo, isvirtualmethod As Boolean, inline As Integer, clinecodestruc() As xmlunpkd.linecodestruc, propresult As identvalid._resultidentcvaild, optval As tokenhared.token)
        Dim ldloc As New illdloc(_ilmethod)
        Dim setconvmethod As Boolean = convtc.setconvmethod
        Dim ntypecast As String = convtc.ntypecast
        If isvirtualmethod AndAlso retpropertyinfo.GetMethod.IsStatic = False Then
            Dim gidentifier As xmlunpkd.linecodestruc = clinecodestruc(0)
            If gidentifier.value.Contains(conrex.DBCLN) Then
                gidentifier.value = gidentifier.value.Remove(gidentifier.value.IndexOf(conrex.DBCLN))
                gidentifier.ile = gidentifier.value.Length
            End If
            ldloc.load_single_in_stack(retpropertyinfo.ReflectedType.ToString, gidentifier)
        End If
        Dim gdatatype As String = retpropertyinfo.PropertyType.Name
        gdatatype = servinterface.vb_to_cil_common_data_type(gdatatype)
        If servinterface.is_cil_common_data_type(gdatatype) = False Then
            gdatatype = retpropertyinfo.PropertyType.ToString
        End If
        Dim paramtype As New ArrayList
        Dim propertyclass As String = retpropertyinfo.ReflectedType.ToString
        Dim propertymethod As String = String.Format("set_{0}", retpropertyinfo.Name)
        paramtype.Add(gdatatype)
        convtc.setconvmethod = setconvmethod
        convtc.ntypecast = ntypecast
        ldloc.load_single_in_stack(gdatatype, clinecodestruc(inline))
        If convtc.setconvmethod Then convtc.set_type_cast(_ilmethod, gdatatype, propertymethod, clinecodestruc(inline))
        check_operator(optval, _ilmethod)
        If isvirtualmethod AndAlso retpropertyinfo.GetMethod.IsStatic = False Then
            cil.call_virtual_method(_ilmethod.codes, "void", propresult.asmextern, propertyclass, propertymethod, paramtype)
        Else
            cil.call_extern_method(_ilmethod.codes, "void", propresult.asmextern, propertyclass, propertymethod, paramtype)
        End If
    End Sub

    Private Shared Sub check_operator(optval As tokenhared.token, _ilmethod As ilformat._ilmethodcollection)
        Select Case optval
            Case tokenhared.token.ANDEQ
                cil.concat_simple(_ilmethod.codes)
            Case tokenhared.token.PLUSEQ
                cil.add(_ilmethod.codes)
            Case tokenhared.token.MINUSEQ
                cil.sub(_ilmethod.codes)
            Case tokenhared.token.SLASHEQ
                cil.div(_ilmethod.codes)
            Case tokenhared.token.ASTERISKEQ
                cil.mul(_ilmethod.codes)
            Case tokenhared.token.REMEQ
                cil.[rem](_ilmethod.codes)
        End Select
    End Sub

    Private Shared Sub can_write(retpropertyinfo As PropertyInfo, propresult As identvalid._resultidentcvaild, clinecodestruc() As xmlunpkd.linecodestruc)
        If retpropertyinfo.CanWrite = False Then
            dserr.args.Add("Property '" & propresult.clident.ToLower & "' is read only.")
            dserr.new_error(conserr.errortype.PROPERTYERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), propresult.clident))
        End If
    End Sub

    Friend Shared Sub get_inv_property(clinecodestruc() As xmlunpkd.linecodestruc, ilmethod As ilformat._ilmethodcollection, propresult As identvalid._resultidentcvaild, inline As Integer)
        If propresult.callintern = True Then
            fieldste.get_internal_field(clinecodestruc, ilmethod, propresult, inline)
        Else
            get_external_property(clinecodestruc, ilmethod, propresult, inline)
        End If
        propertyste.assignmentype = conrex.NULL
    End Sub

    Friend Shared Sub get_external_property(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, propresult As identvalid._resultidentcvaild, inline As Integer)
        Dim classindex, namespaceindex As Integer
        Dim reclassname As String = String.Empty
        Dim isvirtualmethod As Boolean = False
        Dim fclass As String = propresult.exclass
        Dim c = servinterface.get_variable_type(_ilmethod, propresult.exclass)
        If libserv.get_extern_index_class(_ilmethod, propresult.exclass, namespaceindex, classindex, isvirtualmethod, reclassname) = -1 Then
            dserr.args.Add("Class '" & propresult.exclass & "' not found.")
            dserr.new_error(conserr.errortype.PROPERTYERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            Return
        End If
        propresult.asmextern = libserv.get_extern_assembly(namespaceindex)
        Dim retpropertyinfo As PropertyInfo
        If libserv.get_extern_index_property(propresult.clident, namespaceindex, classindex, retpropertyinfo) = -1 Then
            Dim retfieldinfo As FieldInfo
            If libserv.get_extern_index_field(propresult.clident, namespaceindex, classindex, retfieldinfo) <> -1 Then
                fieldste.get_external_field(clinecodestruc, _ilmethod, propresult, inline, namespaceindex, classindex, retfieldinfo, isvirtualmethod)
                Return
            End If
            If arrprop.check_array_property(_ilmethod,  propresult, fclass) Then Return
            If objvirmethod.check_object_method(_ilmethod, propresult, fclass) Then Return
            dserr.args.Add("Property '" & propresult.clident.ToLower & "' not found.")
            dserr.new_error(conserr.errortype.PROPERTYERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), propresult.clident))
            Return
            End If
            can_read(retpropertyinfo, propresult, clinecodestruc)
        check_access_control(retpropertyinfo.GetMethod, isvirtualmethod, clinecodestruc, propresult)
        get_property(_ilmethod, retpropertyinfo, isvirtualmethod, inline, clinecodestruc, propresult)
    End Sub

    Private Shared Sub check_access_control(methodinf As MethodInfo, isvirtualmethod As Boolean, clinecodestruc() As xmlunpkd.linecodestruc, propresult As identvalid._resultidentcvaild)
        If methodinf.IsStatic = False AndAlso isvirtualmethod = False Then
            dserr.args.Add("Property '" & propresult.clident.ToLower & "' , Reference to a non-shared member requires an object reference.")
            dserr.new_error(conserr.errortype.PROPERTYERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), propresult.clident))
        End If
    End Sub

    Private Shared Sub get_property(_ilmethod As ilformat._ilmethodcollection, retpropertyinfo As PropertyInfo, isvirtualmethod As Boolean, inline As Integer, clinecodestruc() As xmlunpkd.linecodestruc, propresult As identvalid._resultidentcvaild)
        Dim ldloc As New illdloc(_ilmethod)
        Dim setconvmethod As Boolean = convtc.setconvmethod
        Dim ntypecast As String = convtc.ntypecast
        Dim gdatatype As String = retpropertyinfo.PropertyType.Name
        gdatatype = servinterface.vb_to_cil_common_data_type(gdatatype)
        If servinterface.is_cil_common_data_type(gdatatype) = False Then
            gdatatype = retpropertyinfo.PropertyType.ToString
        End If
        Dim propertyclass As String = retpropertyinfo.ReflectedType.ToString
        If isvirtualmethod AndAlso retpropertyinfo.GetMethod.IsStatic = False Then
            Dim gidentifier As xmlunpkd.linecodestruc = clinecodestruc(0)
            If gidentifier.value.Contains(conrex.DBCLN) Then
                gidentifier.value = gidentifier.value.Remove(gidentifier.value.IndexOf(conrex.DBCLN))
                gidentifier.ile = gidentifier.value.Length
            End If
            ldloc.load_single_in_stack(retpropertyinfo.ReflectedType.ToString, gidentifier)
        End If
        Dim propertymethod As String = String.Format("get_{0}", retpropertyinfo.Name)
        If isvirtualmethod AndAlso retpropertyinfo.GetMethod.IsStatic = False Then
            cil.call_virtual_method(_ilmethod.codes, gdatatype, propresult.asmextern, propertyclass, propertymethod, Nothing)
        Else
            cil.call_extern_method(_ilmethod.codes, gdatatype, propresult.asmextern, propertyclass, propertymethod, Nothing)
        End If
        convtc.setconvmethod = setconvmethod
        convtc.ntypecast = ntypecast
        If convtc.setconvmethod Then convtc.set_type_cast(_ilmethod, gdatatype, propertymethod, clinecodestruc(inline))
    End Sub

    Private Shared Sub can_read(retpropertyinfo As PropertyInfo, propresult As identvalid._resultidentcvaild, clinecodestruc() As xmlunpkd.linecodestruc)
        If retpropertyinfo.CanRead = False Then
            dserr.args.Add("Property '" & propresult.clident.ToLower & "' is write only.")
            dserr.new_error(conserr.errortype.PROPERTYERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), propresult.clident))
        End If
    End Sub
End Class
