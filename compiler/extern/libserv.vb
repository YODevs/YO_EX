Imports System.Reflection
Imports YOCA

Public Class libserv
    Friend Shared stdimportlist As New ArrayList
    Friend Shared overloadlist As String = String.Empty
    Friend Shared Sub import_std_library(path As String)
        If stdimportlist.Count > 0 Then
            For index = 0 To stdimportlist.Count - 1
                If stdimportlist(index) = path Then
                    Return
                End If
            Next
        End If
        stdimportlist.Add(path)
    End Sub
    Friend Shared Function find_extern_name(name As String) As Boolean
        Dim externresult As mapstoredata.dataresult = libreg.assemblymap.find(name, True)
        If externresult.issuccessful Then
            If externresult.result.StartsWith(conrex.STDPATH) Then import_std_library(externresult.result)
            Return True
        Else
            Return False
        End If
    End Function
    Friend Shared Function get_extern_assembly(indexasm As Integer) As String
        Dim getextername As String = String.Empty
        libreg.assemblymap.get_index(indexasm, getextername)
        If getextername.ToLower <> conrex.MSCORLIB Then funcdtproc.check_extern_assembly(getextername)
        Return getextername
    End Function
    Friend Shared Function get_extern_assembly(asm As Assembly, Optional checkassemblyresource As Boolean = False) As String
        Dim getextername As String = asm.ToString
        getextername = getextername.Remove(getextername.IndexOf(conrex.CMA))
        If getextername.ToLower <> conrex.MSCORLIB AndAlso checkassemblyresource Then funcdtproc.check_extern_assembly(getextername)
        Return getextername
    End Function
    Friend Shared Sub get_identifier_ns(_ilmethod As ilformat._ilmethodcollection, ByRef classname As String, ByRef isvirtualmethod As Boolean)
        If IsNothing(_ilmethod.locallinit) = False Then
            For index = 0 To _ilmethod.locallinit.Length - 1
                If _ilmethod.locallinit(index).name <> conrex.NULL AndAlso classname.ToLower = _ilmethod.locallinit(index).name.ToLower Then
                    classname = _ilmethod.locallinit(index).datatype
                    isvirtualmethod = True
                    Return
                End If
            Next
        End If
        If IsNothing(_ilmethod.parameter) = False Then
            For index = 0 To _ilmethod.parameter.Length - 1
                If _ilmethod.parameter(index).name <> conrex.NULL AndAlso classname.ToLower = _ilmethod.parameter(index).name.ToLower Then
                    classname = _ilmethod.parameter(index).datatype
                    servinterface.is_common_data_type(_ilmethod.parameter(index).datatype, classname)
                    isvirtualmethod = True
                    Return
                End If
            Next
        End If
        If IsNothing(ilasmgen.fields) = False Then
            For index = 0 To ilasmgen.fields.Length - 1
                If ilasmgen.fields(index).name <> conrex.NULL AndAlso classname.ToLower = ilasmgen.fields(index).name.ToLower Then
                    classname = ilasmgen.fields(index).ptype
                    servinterface.is_common_data_type(ilasmgen.fields(index).ptype, classname)
                    isvirtualmethod = True
                    Return
                End If
            Next
        End If
    End Sub
    Friend Shared Function get_nested_type(nestedtypeindex As Integer, namespaceindex As Integer, classindex As Integer) As Type
        Return libreg.types(namespaceindex)(classindex).GetNestedTypes()(nestedtypeindex)
    End Function
    Friend Shared Function get_extern_class_type(namespaceindex As Integer, classindex As Integer) As Type
        Return libreg.types(namespaceindex)(classindex)
    End Function
    Friend Shared Function get_extern_index_class(_ilmethod As ilformat._ilmethodcollection, ByRef classname As String, ByRef namespaceptr As Integer, ByRef classptr As Integer, Optional ByRef isvirtualmethod As Boolean = False, Optional ByRef reclassname As String = Nothing) As Integer
        Dim classchename As String = String.Empty
        Dim isarray As Boolean = False
        If classname.EndsWith(conrex.BRSTEN) Then
            classname = classname.Remove(classname.IndexOf(conrex.BRSTART))
            isarray = True
        ElseIf classname.Contains(conrex.BRSTART) AndAlso classname.EndsWith(conrex.BREND) Then
            classname = classname.Remove(classname.IndexOf(conrex.BRSTART))
            isarray = True
        End If
        If IsNothing(_ilmethod.locallinit) = False OrElse IsNothing(_ilmethod.parameter) = False OrElse IsNothing(ilasmgen.classdata.fields) = False Then
            get_identifier_ns(_ilmethod, classname, isvirtualmethod)
        End If
        check_common_data_type(classname, reclassname)

        Dim resultclassindex As mapstoredata.dataresult = libreg.externtypes.find(classname, True, classchename)
        If resultclassindex.issuccessful Then
            classname = classchename
            If isarray Then
                classname &= conrex.BRSTEN
            End If
            Dim spdata As String = resultclassindex.result
            namespaceptr = spdata.Remove(spdata.IndexOf(conrex.CMA))
            classptr = spdata.Remove(0, spdata.IndexOf(conrex.CMA) + 1)
            Return 1
        Else
            Return -1
        End If
    End Function

    Friend Shared Sub check_common_data_type(ByRef classname As String, ByRef reclassname As String)
        If servinterface.is_cil_common_data_type(classname) Then
            reclassname = classname
            classname = "System." & servinterface.cil_to_vb_common_data_type(classname)
        Else
            reclassname = String.Empty
        End If
    End Sub
    Friend Shared Sub get_return_type(methodname As String, namespaceindex As Integer, classindex As Integer, methodindex As Integer, ByRef greturntype As String, ByRef gexternassembly As String)
        greturntype = libreg.types(namespaceindex)(classindex).GetMethods()(methodindex).ReturnType.ToString
        gexternassembly = libreg.types(namespaceindex)(classindex).GetMethods()(methodindex).ReturnType.Assembly.GetName.Name
    End Sub
    Friend Shared Function get_extern_index_method(_ilmethod As ilformat._ilmethodcollection, cargcodestruc() As xmlunpkd.linecodestruc, ByRef funcname As String, namespaceindex As Integer, classindex As Integer, ByRef methodinfo As tknformat._method, leftassign As Boolean) As Integer
        Dim funcnametolower As String = funcname.ToLower
        Dim retstate As Integer = -1
        cargldr = Nothing
        Dim methodinf() As MethodInfo = libreg.types(namespaceindex)(classindex).GetMethods()
        Dim methodslen As Integer = methodinf.Length - 1
        For methodindex = 0 To methodslen
            Dim method As MethodInfo = libreg.types(namespaceindex)(classindex).GetMethods()(methodindex)
            If method.Name.ToLower = funcnametolower Then
                Dim tpcasttype As String = funcste.assignmentype
                If funcste.assignmentype <> conrex.NULL Then
                    servinterface.is_common_data_type(funcste.assignmentype, funcste.assignmentype)
                    funcste.assignmentype = servinterface.cil_to_vb_common_data_type(funcste.assignmentype)
                Else
                    funcste.assignmentype = conrex.VOID
                End If
                If leftassign OrElse illdloc.eq_data_types(funcste.assignmentype, method.ReturnType.ToString) OrElse convtc.setconvmethod AndAlso illdloc.eq_data_types(convtc.ntypecast, tpcasttype) Then
                    If check_overloading(_ilmethod, method.GetParameters, cargcodestruc) Then
                        funcname = method.Name
                        get_method_info(method, methodinfo)
                        funcste.assignmentype = Nothing
                        illdloc.frvarstruc = Nothing
                        Return methodindex
                    End If
                End If
                retstate = -2
            End If
        Next
        illdloc.frvarstruc = Nothing
        funcste.assignmentype = Nothing
        If retstate = -2 Then get_overloads_of_method(libreg.types(namespaceindex)(classindex).GetMethods, funcnametolower)
        Return retstate
    End Function

    Friend Shared Sub get_overloads_of_method(methodinfo As MethodInfo(), funcname As String)
        Dim sb As New Text.StringBuilder
        For Each method In methodinfo
            If method.Name.ToLower = funcname Then
                sb.Append(method.Name)
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
                sb.AppendLine()
                End If
        Next
        overloadlist = sb.ToString
    End Sub

    Friend Shared Function get_extern_index_constructor(_ilmethod As ilformat._ilmethodcollection, cargcodestruc() As xmlunpkd.linecodestruc, namespaceindex As Integer, classindex As Integer, ByRef ctorinfo As ConstructorInfo, ByRef methodinfo As tknformat._method) As Integer
        cargldr = Nothing
        Dim retcode As Integer = -1
        For Each gconstructor In libreg.types(namespaceindex)(classindex).GetConstructors()
            If check_overloading(_ilmethod, gconstructor.GetParameters, cargcodestruc) Then
                get_method_info(gconstructor, methodinfo)
                ctorinfo = gconstructor
                Return 1
            End If
            retcode = 0
        Next
        Return retcode
    End Function

    Friend Shared Function get_index_enum(ByRef enumname As String, namespaceindex As Integer, classindex As Integer) As Integer
        Dim enumtolower As String = enumname.ToLower
        Dim index As Integer = 0
        For Each gmember In libreg.types(namespaceindex)(classindex).GetNestedTypes
            If gmember.IsEnum = True AndAlso enumtolower = gmember.Name.ToLower Then
                enumname = gmember.Name
                Return index
            End If
            index += 1
        Next
        Return -1
    End Function
    Friend Shared Function get_extern_index_property(propertyname As String, namespaceindex As Integer, classindex As Integer, ByRef retproperty As PropertyInfo) As Integer
        propertyname = propertyname.ToLower
        For Each gproperty In libreg.types(namespaceindex)(classindex).GetProperties()
            If propertyname = gproperty.Name.ToLower Then
                retproperty = gproperty
                Return 1
            End If
        Next
        Return -1
    End Function

    Friend Shared Function get_extern_index_field(fieldname As String, namespaceindex As Integer, classindex As Integer, ByRef retfield As FieldInfo) As Integer
        fieldname = fieldname.ToLower
        For Each gfield In libreg.types(namespaceindex)(classindex).GetFields()
            If fieldname = gfield.Name.ToLower Then
                retfield = gfield
                Return 1
            End If
        Next
        Return -1
    End Function

    Friend Shared cargldr() As xmlunpkd.linecodestruc = Nothing
    Private Shared Function check_overloading(_ilmethod As ilformat._ilmethodcollection, gparameters() As ParameterInfo, cargcodestruc() As xmlunpkd.linecodestruc) As Boolean
        'TODO : Check Return-Type
        Dim cargcodelen As Integer = 0
        If IsNothing(cargcodestruc) = False Then cargcodelen = cargcodestruc.Length
        If cargcodelen <> gparameters.Length Then
            Return False
        ElseIf gparameters.Length = 0 AndAlso cargcodelen = 0 Then
            Return True
        End If
        cargldr = cargcodestruc
        Return parampt.check_param_types(_ilmethod, gparameters, cargcodestruc)
    End Function

    Friend Shared Sub get_method_info(method As Reflection.MethodInfo, ByRef methodinfo As tknformat._method)
        methodinfo.name = method.Name
        methodinfo.isexpr = False
        If method.ReturnType.Name = "Void" Then
            methodinfo.returntype = "void"
        Else
            methodinfo.returntype = servinterface.vb_to_cil_common_data_type(method.ReturnType.Name)
        End If
        For index = 0 To method.GetParameters().Length - 1
            Array.Resize(methodinfo.parameters, index + 1)
            methodinfo.parameters(index) = New tknformat._parameter
            methodinfo.parameters(index).name = method.GetParameters(index).Name
            methodinfo.parameters(index).ptype = method.GetParameters(index).ParameterType.Name
            methodinfo.parameters(index).typeinf = yotypecreator.convert_to_type_info(method.GetParameters(index).ParameterType)
        Next
    End Sub
    Friend Shared Sub get_method_info(ctormethod As Reflection.ConstructorInfo, ByRef methodinfo As tknformat._method)
        methodinfo.name = ctormethod.Name
        methodinfo.isexpr = False
        methodinfo.returntype = "void"
        For index = 0 To ctormethod.GetParameters().Length - 1
            Array.Resize(methodinfo.parameters, index + 1)
            methodinfo.parameters(index) = New tknformat._parameter
            methodinfo.parameters(index).name = ctormethod.GetParameters(index).Name
            If servinterface.is_cil_common_data_type(ctormethod.GetParameters(index).ParameterType.Name.ToLower) OrElse servinterface.is_common_data_type(ctormethod.GetParameters(index).ParameterType.Name.ToLower, Nothing) Then
                servinterface.get_yo_common_data_type(ctormethod.GetParameters(index).ParameterType.Name.ToLower, methodinfo.parameters(index).ptype)
                methodinfo.parameters(index).typeinf = New ilformat._typeinfo
                methodinfo.parameters(index).typeinf.externlib = compdt.CORELIB
            Else
                methodinfo.parameters(index).ptype = ctormethod.GetParameters(index).ParameterType.FullName
                methodinfo.parameters(index).typeinf = New ilformat._typeinfo
            End If
            methodinfo.parameters(index).typeinf.isarray = ctormethod.GetParameters(index).ParameterType.IsArray
        Next
    End Sub

End Class
