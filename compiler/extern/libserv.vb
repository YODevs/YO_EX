Imports System.Reflection
Imports YOCA

Public Class libserv

    Friend Shared Function find_extern_name(name As String) As Boolean
        Return libreg.assemblymap.find(name, True).issuccessful
    End Function
    Friend Shared Function get_extern_assembly(indexasm As Integer) As String
        Dim getextername As String = String.Empty
        libreg.assemblymap.get_index(indexasm, getextername)
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
        If IsNothing(ilasmgen.classdata.fields) = False Then
            For index = 0 To ilasmgen.classdata.fields.Length - 1
                If ilasmgen.classdata.fields(index).name <> conrex.NULL AndAlso classname.ToLower = ilasmgen.classdata.fields(index).name.ToLower Then
                    classname = ilasmgen.classdata.fields(index).ptype
                    servinterface.is_common_data_type(_ilmethod.parameter(index).datatype, classname)
                    isvirtualmethod = True
                    Return
                End If
            Next
        End If
    End Sub
    Friend Shared Function get_extern_index_class(_ilmethod As ilformat._ilmethodcollection, ByRef classname As String, ByRef namespaceptr As Integer, ByRef classptr As Integer, Optional ByRef isvirtualmethod As Boolean = False, Optional ByRef reclassname As String = Nothing) As Integer
        Dim classchename As String = String.Empty
        If IsNothing(_ilmethod.locallinit) = False OrElse IsNothing(_ilmethod.parameter) = False Then
            get_identifier_ns(_ilmethod, classname, isvirtualmethod)
        End If
        check_common_data_type(classname, reclassname)

        Dim resultclassindex As mapstoredata.dataresult = libreg.externtypes.find(classname, True, classchename)
        If resultclassindex.issuccessful Then
            classname = classchename
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
    Friend Shared Function get_extern_index_method(_ilmethod As ilformat._ilmethodcollection, cargcodestruc() As xmlunpkd.linecodestruc, ByRef funcname As String, namespaceindex As Integer, classindex As Integer, ByRef methodinfo As tknformat._method) As Integer
        Dim funcnametolower As String = funcname.ToLower
        Dim retstate As Integer = -1
        cargldr = Nothing
        Dim methodindex As Integer = 0
        For Each method In libreg.types(namespaceindex)(classindex).GetMethods()
            If method.Name.ToLower = funcnametolower Then
                If check_overloading(_ilmethod, method.GetParameters, cargcodestruc) Then
                    funcname = method.Name
                    get_method_info(method, methodinfo)
                    Return methodindex
                Else
                    retstate = -2
                End If
            End If
            methodindex += 1
        Next
        Return retstate
    End Function
    Friend Shared Function get_extern_index_constructor(_ilmethod As ilformat._ilmethodcollection, cargcodestruc() As xmlunpkd.linecodestruc, namespaceindex As Integer, classindex As Integer, ByRef ctorinfo As ConstructorInfo, ByRef methodinfo As tknformat._method) As Integer
        cargldr = Nothing
        For Each gconstructor In libreg.types(namespaceindex)(classindex).GetConstructors()
            If check_overloading(_ilmethod, gconstructor.GetParameters, cargcodestruc) Then
                get_method_info(gconstructor, methodinfo)
                ctorinfo = gconstructor
                Return 1
            End If
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
        Dim paramtypes As New ArrayList
        For index = 0 To gparameters.Length - 1
            paramtypes.Add(servinterface.vb_to_cil_common_data_type(gparameters(index).ParameterType.Name))
        Next

        cargldr = cargcodestruc
        Return parampt.check_param_types(_ilmethod, paramtypes, cargcodestruc)
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
            methodinfo.parameters(index).ptype = ctormethod.GetParameters(index).ParameterType.Name
        Next
    End Sub

End Class
