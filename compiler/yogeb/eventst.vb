Imports System.Reflection

Public Class eventst
    Private _ilmethod As ilformat._ilmethodcollection

    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Friend Function set_event_st(clinecodestruc() As xmlunpkd.linecodestruc, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.EVENT)
        Dim clineeventstruc As xmlunpkd.linecodestruc = clinecodestruc(1)
        Dim hresult As identvalid._resultidentcvaild = identvalid.get_identifier_valid(_ilmethod, clineeventstruc)
        If hresult.identvalid = True Then
            Dim eventname As String = hresult.clident
            Dim classindex, namespaceindex As Integer
            Dim reclassname As String = String.Empty
            Dim isvirtualmethod As Boolean = False
            If libserv.get_extern_index_class(_ilmethod, hresult.exclass, namespaceindex, classindex, isvirtualmethod, reclassname) = -1 Then
                dserr.args.Add("Class '" & hresult.exclass & "' not found.")
                dserr.new_error(conserr.errortype.EVENTERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value), "addhandler myobj::event , yourfuncname ")
            End If
            hresult.asmextern = libserv.get_extern_assembly(namespaceindex)
            Dim eventindex As Integer = libserv.get_index_event(eventname, namespaceindex, classindex)
            If eventindex = -1 Then
                dserr.args.Add("Event '" & hresult.clident & "' was not found in class " & hresult.exclass)
                dserr.new_error(conserr.errortype.EVENTERROR, clineeventstruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clineeventstruc), clineeventstruc.value), "addhandler myobj::event , yourfuncname ")
            End If
            Dim hevent As EventInfo = libserv.get_event_type(eventindex, namespaceindex, classindex)
            set_handler(clinecodestruc, hevent, hresult)
        End If
        Return _ilmethod
    End Function

    Private Sub set_handler(clinecodestruc() As xmlunpkd.linecodestruc, hevent As EventInfo, hresult As identvalid._resultidentcvaild)
        Dim methodinfo As tknformat._method = get_event_method(clinecodestruc(3))
        Dim invokemethod As MethodInfo = hevent.EventHandlerType.GetMethod("Invoke")
        check_event_signature(clinecodestruc, methodinfo, hevent, invokemethod)
        Dim objname As String = clinecodestruc(1).value
        load_event_object(objname, hresult)
        If methodinfo.objcontrol.modifier = tokenhared.token.STATIC OrElse methodinfo.objcontrol.modifierval = conrex.NULL Then
            cil.push_null_reference(_ilmethod.codes)
        Else
            cil.ldarg(_ilmethod.codes, 0)
        End If
        push_pointer_to_methodref(methodinfo)
        Dim asmextern As String = hevent.ReflectedType.Assembly.GetName.Name
        cil.insert_il(_ilmethod.codes, String.Format("newobj instance void class [{0}]{1}/{2}::.ctor(object,native int)", asmextern, hevent.DeclaringType.FullName, hevent.EventHandlerType.Name))
        cil.insert_il(_ilmethod.codes, String.Format("callvirt instance void [{0}]{1}::{2}(class [{0}]{1}/{3})", asmextern, hevent.DeclaringType.FullName, hevent.AddMethod.Name, hevent.EventHandlerType.Name))
    End Sub

    Private Sub push_pointer_to_methodref(methodinfo As tknformat._method)
        Dim paramtypes As New ArrayList
        For index = 0 To methodinfo.parameters.Length - 1
            Dim ciltype As String = conrex.NULL
            servinterface.is_common_data_type(methodinfo.parameters(index).ptype, ciltype)
            If ciltype = String.Empty Then ciltype = methodinfo.parameters(index).ptype
            If methodinfo.parameters(index).typeinf.isarray OrElse methodinfo.parameters(index).name.EndsWith(conrex.BRSTEN) Then
                ciltype &= conrex.BRSTEN
            End If
            If methodinfo.parameters(index).byreference Then
                ciltype &= conrex.AMP
            End If
            paramtypes.Add(ciltype)
        Next
        'TODO : Change Classname ...
        cil.push_pointer_to_methodref(_ilmethod.codes, conrex.VOID, ilgencode.attribute._app._classname, methodinfo.name, paramtypes, (methodinfo.objcontrol.modifier = tokenhared.token.INSTANCE))
    End Sub

    Private Sub load_event_object(ByRef objname As String, hresult As identvalid._resultidentcvaild)
        If objname.Contains("") = False Then Return
        objname = objname.Remove(objname.IndexOf("::"))
        Dim ldloc As New illdloc(_ilmethod)
        Dim singleobjstruc As xmlunpkd.linecodestruc = servinterface.create_fake_linecodestruc(tokenhared.token.IDENTIFIER, objname)
        _ilmethod = ldloc.load_single_in_stack(hresult.exclass, singleobjstruc)
    End Sub

    Private Sub check_event_signature(clinecodestruc As xmlunpkd.linecodestruc(), methodinfo As tknformat._method, hevent As EventInfo, invokemethod As MethodInfo)
        Dim methodinfolen, raisemethodlen As Integer
        If IsNothing(methodinfo.parameters) Then
            methodinfolen = 0
        Else
            methodinfolen = methodinfo.parameters.Length
        End If
        If IsNothing(invokemethod.GetParameters) Then
            raisemethodlen = 0
        Else
            raisemethodlen = invokemethod.GetParameters.Length
        End If
        If methodinfolen <> raisemethodlen Then
            set_signature_error(get_all_parameters(hevent.Name, invokemethod), clinecodestruc(3), methodinfo)
        End If
        Dim raiseparams() As ParameterInfo = invokemethod.GetParameters
        For index = 0 To raiseparams.Length - 1
            If methodinfo.parameters(index).typeinf.asminfo = conrex.NULL Then set_typeinf(methodinfo, index)
            Dim ciltype As String = methodinfo.parameters(index).typeinf.fullname
            If methodinfo.parameters(index).typeinf.isarray OrElse methodinfo.parameters(index).name.EndsWith(conrex.BRSTEN) Then
                ciltype &= conrex.BRSTEN
            End If
            If methodinfo.parameters(index).byreference Then
                ciltype &= conrex.AMP
            End If
            If raiseparams(index).ParameterType.Assembly.GetName.Name = methodinfo.parameters(index).typeinf.externlib AndAlso
                raiseparams(index).ParameterType.FullName = ciltype Then
                Continue For
            Else
                set_signature_error(get_all_parameters(hevent.Name, invokemethod), clinecodestruc(3), methodinfo)
            End If
        Next
    End Sub

    Private Sub set_signature_error(eventsc As String, clinecodestruc As xmlunpkd.linecodestruc, methodinfo As tknformat._method)
        dserr.args.Add(String.Format("Method '{0}' does not have a signature compatible with delegate '{1}'.", methodinfo.name, eventsc))
        dserr.new_error(conserr.errortype.EVENTERROR, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value), "The parameters of both functions must be the same.")
    End Sub

    Friend Shared Function get_all_parameters(methodname As String, method As MethodInfo) As String
        Dim sb As New Text.StringBuilder
        sb.Append(methodname)
        sb.Append(conrex.PRSTART)
        If IsNothing(method.GetParameters) = False Then
            For index = 0 To method.GetParameters.Length - 1
                Dim isbyref As Boolean = False
                Dim gparametername As String = method.GetParameters(index).Name
                Dim gtype As String = method.GetParameters(index).ParameterType.Name
                If method.GetParameters(index).ParameterType.IsArray Then
                    gtype = gtype.Remove(gtype.Length - 2)
                End If
                If gtype.EndsWith("*") Then
                    gtype = gtype.Remove(gtype.Length - 1)
                    isbyref = True
                End If
                gtype = servinterface.vb_to_cil_common_data_type(gtype)
                servinterface.get_yo_common_data_type(gtype, gtype)
                If method.GetParameters(index).ParameterType.IsArray Then gtype &= conrex.BRSTEN
                If isbyref Then gtype &= conrex.AMP
                If gtype = method.GetParameters(index).ParameterType.Name.ToLower Then
                    gtype = method.GetParameters(index).ParameterType.Name
                End If
                gtype = servinterface.get_yo_byte_types(gtype)
                sb.Append(gparametername & conrex.SPACE & gtype)

                If index + 1 < method.GetParameters.Length Then
                    sb.Append(conrex.CMA)
                End If
            Next
        End If

        sb.Append(conrex.PREND)
        Dim rettype As String = method.ReturnType.Name
        If method.ReturnType.IsArray Then
            rettype = rettype.Remove(rettype.Length - 2)
        End If
        rettype = servinterface.vb_to_cil_common_data_type(rettype)
        servinterface.get_yo_common_data_type(rettype, rettype)
        If method.ReturnType.IsArray Then rettype &= conrex.BRSTEN
        If rettype = method.ReturnType.Name.ToLower Then
            rettype = method.ReturnType.Name
        End If
        rettype = servinterface.get_yo_byte_types(rettype)
        sb.Append(conrex.SPACE & conrex.CLN & conrex.SPACE & rettype)
        Return sb.ToString
    End Function

    Private Sub set_typeinf(ByRef methodinfo As tknformat._method, index As Integer)
        Dim clinetypeinfostruct(2) As xmlunpkd.linecodestruc
        clinetypeinfostruct(0) = servinterface.get_line_code_struct(methodinfo.parameters(index).dtypetargetinfo, methodinfo.parameters(index).ptype, tokenhared.token.IDENTIFIER)
        clinetypeinfostruct(1) = New xmlunpkd.linecodestruc
        clinetypeinfostruct(1).tokenid = tokenhared.token.PRSTART
        clinetypeinfostruct(1).value = conrex.PRSTART
        clinetypeinfostruct(2) = New xmlunpkd.linecodestruc
        clinetypeinfostruct(2).tokenid = tokenhared.token.PREND
        clinetypeinfostruct(2).value = conrex.PREND
        methodinfo.parameters(index).typeinf = yotypecreator.get_type_info(_ilmethod, clinetypeinfostruct, 0, methodinfo.parameters(index).ptype)
    End Sub

    Private Function get_event_method(linecodestruc As xmlunpkd.linecodestruc) As tknformat._method
        Dim methodinfo As tknformat._method
        Dim eventhandlercodestruc(2) As xmlunpkd.linecodestruc
        eventhandlercodestruc(0) = linecodestruc
        eventhandlercodestruc(1) = servinterface.create_fake_linecodestruc(tokenhared.token.PRSTART, conrex.PRSTART)
        eventhandlercodestruc(2) = servinterface.create_fake_linecodestruc(tokenhared.token.PREND, conrex.PREND)
        Dim funcresult As funcvalid._resultfuncvaild = funcvalid.get_func_valid(_ilmethod, eventhandlercodestruc)
        If funcresult.funcvalid = False Then
            dserr.args.Add("'" & linecodestruc.value & "' The specified function is invalid.")
            dserr.new_error(conserr.errortype.EVENTERROR, linecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(linecodestruc), linecodestruc.value), "addhandler myobj::event , yourfuncname ")
        End If
        If funcresult.callintern = False Then
            dserr.args.Add("'" & linecodestruc.value & "' The specified event cannot be bound to external functions.")
            dserr.new_error(conserr.errortype.EVENTERROR, linecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(linecodestruc), linecodestruc.value), "addhandler myobj::event , yourfuncname ")
        End If
        Dim isvirtualmethod As Boolean = False
        Dim classindex As Integer = funcdtproc.get_index_class(_ilmethod, funcresult.exclass, isvirtualmethod)
        If classindex = -1 Then
            dserr.args.Add("Class '" & funcresult.exclass & "' not found.")
            dserr.new_error(conserr.errortype.METHODERROR, linecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(linecodestruc), linecodestruc.value))
        End If
        methodinfo = funcdtproc.get_method_info(classindex, funcresult.clmethod)
        If IsNothing(methodinfo) Then
            dserr.args.Add("Method " & funcresult.clmethod & "(...) not found.")
            dserr.new_error(conserr.errortype.METHODERROR, linecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(linecodestruc), linecodestruc.value))
        End If
        Return methodinfo
    End Function
End Class
