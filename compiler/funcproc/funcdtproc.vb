Public Class funcdtproc
    Structure _referfuncdata
        Dim classname As String
        Dim filename As String
        Dim methods() As tknformat._method
        Dim fields() As tknformat._pubfield
        Dim enums() As tknformat._enum
        Dim externlist As ArrayList
    End Structure

    Friend Shared reffunc() As _referfuncdata
    Friend Shared refrecord As New mapstoredata
    Friend Shared overloadlist As String = String.Empty
    Friend Shared Sub import_method(classdt As tknformat._class)
        Dim index As Integer = 0
        If IsNothing(reffunc) Then
            Array.Resize(reffunc, 1)
            reffunc(0) = New _referfuncdata
        Else
            index = reffunc.Length
            Array.Resize(reffunc, reffunc.Length + 1)
            reffunc(index) = New _referfuncdata
        End If
        ' TODO : Fix Bug    reset_xml_data(classdt)
        reffunc(index).filename = classdt.name
        reffunc(index).fields = classdt.fields
        reffunc(index).methods = classdt.methods
        reffunc(index).enums = classdt.enums
        reffunc(index).externlist = classdt.externlist
        If classdt.attribute._app._namespace <> conrex.NULL Then
            reffunc(index).classname = classdt.attribute._app._namespace & conrex.DOT
        End If
        reffunc(index).classname &= classdt.attribute._app._classname
        refrecord.add(reffunc(index).classname, index)
    End Sub

    Private Shared Sub reset_xml_data(ByRef classdt As tknformat._class)
        If IsNothing(classdt.methods) Then Return
        For indexmethod = 0 To classdt.methods.Length - 1
            classdt.methods(indexmethod).bodyxmlfmt = String.Empty
        Next
    End Sub

    Friend Shared Sub set_type_info(classindex As Integer, methodindex As Integer, method As tknformat._method)
        reffunc(classindex).methods(methodindex).parameters = method.parameters
    End Sub
    Friend Shared Function get_index_method(_ilmethod As ilformat._ilmethodcollection, cargcodestruc() As xmlunpkd.linecodestruc, ByRef funcname As String, classindex As Integer, leftassign As Boolean) As Integer
        If IsNothing(reffunc(classindex).methods) Then Return -1
        Dim retstate As Integer = -1
        Dim settypeinfo As Boolean = False
        funcname = funcname.ToLower
        For index = 0 To reffunc(classindex).methods.Length - 1
            If reffunc(classindex).methods(index).name.ToLower = funcname Then
                Dim resulttype As String = reffunc(classindex).methods(index).returntype
                If reffunc(classindex).methods(index).returnarray Then
                    resulttype = resulttype.Remove(resulttype.Length - 2)
                End If
            If leftassign OrElse illdloc.eq_data_types(funcste.assignmentype, resulttype) OrElse convtc.setconvmethod AndAlso illdloc.eq_data_types(convtc.ntypecast, funcste.assignmentype) Then
                If check_overloading(_ilmethod, reffunc(classindex).methods(index), cargcodestruc, settypeinfo) Then
                    funcname = reffunc(classindex).methods(index).name
                    If settypeinfo Then
                        set_type_info(classindex, index, reffunc(classindex).methods(index))
                    End If
                    funcste.assignmentype = Nothing
                    Return index
                End If
            End If
            retstate = -2
            End If
        Next
        funcste.assignmentype = Nothing
        If retstate = -2 Then get_overloads_of_method(reffunc(classindex).methods, funcname.ToLower)
        Return retstate
    End Function

    Friend Shared Sub get_overloads_of_method(methodinfo As tknformat._method(), funcname As String)
        Dim sb As New Text.StringBuilder
        For Each method In methodinfo
            If method.name.ToLower = funcname Then
                sb.Append(method.name)
                sb.Append(conrex.PRSTART)
                If method.nopara = True Then
                    For index = 0 To method.parameters.Length - 1
                        Dim isarray As Boolean = False
                        Dim gparametername As String = method.parameters(index).name
                        Dim gtype As String = method.parameters(index).ptype
                        If gtype.EndsWith(conrex.BRSTEN) Then
                            gtype = gtype.Remove(gtype.Length - 2)
                            isarray = True
                        End If
                        If method.parameters(index).byreference = True Then
                            gtype = gtype.Remove(gtype.Length - 1)
                        End If
                        gtype = servinterface.vb_to_cil_common_data_type(gtype)
                        servinterface.get_yo_common_data_type(gtype, gtype)
                        If isarray Then gtype &= conrex.BRSTEN
                        If method.parameters(index).byreference Then gtype &= conrex.AMP
                        If gtype = method.parameters(index).name.ToLower Then
                            gtype = method.parameters(index).name
                        End If
                        gtype = servinterface.get_yo_byte_types(gtype)
                        sb.Append(gparametername & conrex.SPACE & gtype)
                        If index + 1 < method.parameters.Length Then
                            sb.Append(conrex.CMA)
                        End If
                    Next
                End If
                sb.Append(conrex.PREND)
                Dim rettype As String = method.returntype
                'Check return-type is an 'Array' types
                rettype = servinterface.vb_to_cil_common_data_type(rettype)
                servinterface.get_yo_common_data_type(rettype, rettype)
                rettype = servinterface.get_yo_byte_types(rettype)
                sb.Append(conrex.SPACE & conrex.CLN & conrex.SPACE & rettype)
                sb.AppendLine()
                End If
        Next
        overloadlist = sb.ToString
    End Sub
    Friend Shared Function get_index_constructor(_ilmethod As ilformat._ilmethodcollection, cargcodestruc() As xmlunpkd.linecodestruc, ByRef funcname As String, classindex As Integer) As Integer
        If IsNothing(reffunc(classindex).methods) Then Return -1
        Dim retstate As Integer = -1
        Dim settypeinfo As Boolean = False
        funcname = funcname.ToLower
        For index = 0 To reffunc(classindex).methods.Length - 1
            If reffunc(classindex).methods(index).name.ToLower = funcname Then
                If check_overloading(_ilmethod, reffunc(classindex).methods(index), cargcodestruc, settypeinfo) Then
                    funcname = reffunc(classindex).methods(index).name
                    If settypeinfo Then
                        set_type_info(classindex, index, reffunc(classindex).methods(index))
                    End If
                    Return index
                End If
                retstate = -2
            End If
        Next
        Return retstate
    End Function

    Friend Shared Function check_overloading(_ilmethod As ilformat._ilmethodcollection, ByRef _method As tknformat._method, cargcodestruc() As xmlunpkd.linecodestruc, ByRef settypeinfo As Boolean) As Boolean
        'TODO : Check Return-Type
        Dim cargcodelen As Integer = 0
        Dim methodlen As Integer = 0
        settypeinfo = False

        If IsNothing(_method.parameters) = False Then methodlen = _method.parameters.Length
        If IsNothing(cargcodestruc) = False Then cargcodelen = cargcodestruc.Length

        If cargcodelen <> methodlen Then
            Return False
        ElseIf methodlen = 0 AndAlso cargcodelen = 0 Then
            Return True
        End If

        Dim paramtypes As New ArrayList
        For index = 0 To _method.parameters.Length - 1
            Dim ciltype As String = conrex.NULL
            servinterface.is_common_data_type(_method.parameters(index).ptype, ciltype)
            If ciltype = String.Empty Then ciltype = _method.parameters(index).ptype
            paramtypes.Add(ciltype)
            If _method.parameters(index).typeinf.asminfo = conrex.NULL Then
                Dim clinetypeinfostruct(2) As xmlunpkd.linecodestruc
                clinetypeinfostruct(0) = servinterface.get_line_code_struct(_method.parameters(index).dtypetargetinfo, _method.parameters(index).ptype, tokenhared.token.IDENTIFIER)
                clinetypeinfostruct(1) = New xmlunpkd.linecodestruc
                clinetypeinfostruct(1).tokenid = tokenhared.token.PRSTART
                clinetypeinfostruct(1).value = conrex.PRSTART
                clinetypeinfostruct(2) = New xmlunpkd.linecodestruc
                clinetypeinfostruct(2).tokenid = tokenhared.token.PREND
                clinetypeinfostruct(2).value = conrex.PREND
                _method.parameters(index).typeinf = yotypecreator.get_type_info(_ilmethod, clinetypeinfostruct, 0, _method.parameters(index).ptype)
                settypeinfo = True
            End If
        Next


        libserv.cargldr = cargcodestruc
        Return parampt.check_param_types(_ilmethod, paramtypes, _method.parameters, cargcodestruc)
    End Function
    Friend Shared Function get_index_class(_ilmethod As ilformat._ilmethodcollection, ByRef classname As String, Optional ByRef isvirtualmethod As Boolean = False) As Integer
        Dim classchename As String = String.Empty
        If IsNothing(_ilmethod) = False Then
            libserv.get_identifier_ns(_ilmethod, classname, isvirtualmethod)
        End If
        Dim resultclassindex As mapstoredata.dataresult = refrecord.find(classname, True, classchename)
        If resultclassindex.issuccessful Then
            classname = classchename
            Return resultclassindex.result
        Else
            Return -1
        End If
    End Function

    Friend Shared Function get_class_name(classindex As Integer) As String
        Dim resultclassindex As mapstoredata.dataresult = refrecord.findkey(classindex)
        If resultclassindex.issuccessful Then
            Return resultclassindex.result
        Else
            Return Nothing
        End If
    End Function
    Friend Shared Function get_method_info(classindex As Integer, methodindex As Integer) As tknformat._method
        Return reffunc(classindex).methods(methodindex)
    End Function

    Friend Shared Function get_index_field(ByRef identifier As String, classindex As Integer) As Integer
        If IsNothing(reffunc(classindex).fields) Then Return -1
        identifier = identifier.ToLower
        For index = 0 To reffunc(classindex).fields.Length - 1
            If reffunc(classindex).fields(index).name.ToLower = identifier Then
                identifier = reffunc(classindex).fields(index).name
                Return index
            End If
        Next
        Return -1
    End Function
    Friend Shared Function get_field_info(classindex As Integer, fieldindex As Integer) As tknformat._pubfield
        Return reffunc(classindex).fields(fieldindex)
    End Function

    Friend Shared Function get_index_enum(ByRef identifier As String, classindex As Integer) As Integer
        If IsNothing(reffunc(classindex).enums) Then Return -1
        identifier = identifier.ToLower
        For index = 0 To reffunc(classindex).enums.Length - 1
            If reffunc(classindex).enums(index).name.ToLower = identifier Then
                identifier = reffunc(classindex).enums(index).name
                Return index
            End If
        Next
        Return -1
    End Function
    Friend Shared Function get_enum_info(classindex As Integer, enumsindex As Integer) As tknformat._enum
        Return reffunc(classindex).enums(enumsindex)
    End Function

    Friend Shared Function check_extern_assembly(externname As String) As Boolean
        Dim leref As Integer = reffunc.Length - 1
        Dim bextern As String = externname
        externname = externname.ToLower
        If externname = "system" Then Return True
        For iref = 0 To leref
            If IsNothing(reffunc(iref).externlist) Then Continue For
            For index = 0 To reffunc(iref).externlist.Count - 1
                If reffunc(iref).externlist(index).ToLower = externname Then
                    Return True
                End If
            Next
        Next
        dserr.args.Add(bextern)
        dserr.new_error(conserr.errortype.EXTERNERROR, -1, ilbodybulider.path, "Introduce the '" & bextern & "' library to the compiler with the Extern statement.", "extern " & bextern)
        Return False
    End Function
End Class
