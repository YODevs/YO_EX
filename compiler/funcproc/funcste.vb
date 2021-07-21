Imports System.Reflection
Imports YOCA

Public Class funcste
    Friend Shared attribute As yocaattribute.yoattribute
    Friend Shared assignmentype As String
    Friend Shared Sub invoke_method(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, funcresult As funcvalid._resultfuncvaild, Optional leftassign As Boolean = True)
        fscmawait = False
        If funcresult.callintern Then
            inv_internal_method(clinecodestruc, _ilmethod, funcresult.exclass, funcresult, leftassign)
        Else
            inv_external_method(clinecodestruc, _ilmethod, funcresult.exclass, funcresult, leftassign)
        End If
    End Sub

    Friend Shared Sub inv_external_method(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, classname As String, funcresult As funcvalid._resultfuncvaild, leftassign As Boolean)
        Dim classindex, namespaceindex As Integer
        Dim reclassname As String = String.Empty
        Dim isvirtualmethod As Boolean = False
        If libserv.get_extern_index_class(_ilmethod, classname, namespaceindex, classindex, isvirtualmethod, reclassname) = -1 Then
            dserr.args.Add("Class '" & classname & "' not found.")
            dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            Return
        End If
        funcresult.asmextern = libserv.get_extern_assembly(namespaceindex)
        Dim methodinfo As New tknformat._method
        Dim methodindex As Integer = libserv.get_extern_index_method(_ilmethod, get_argument_list(clinecodestruc), funcresult.clmethod, namespaceindex, classindex, methodinfo, leftassign)

        Select Case methodindex
            Case -1
                dserr.args.Add("Method " & funcresult.clmethod & "(...) not found.")
                dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            Case -2
                dserr.args.Add("Method " & funcresult.clmethod & "(...) , The parameters of the called function do not match its original function.")
                dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(1).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(2)), clinecodestruc(2).value), "Overloads :" & vbCrLf & libserv.overloadlist)
        End Select

        If isvirtualmethod Then
            Dim ldloc As New illdloc(_ilmethod)
            Dim gidentifier As xmlunpkd.linecodestruc = clinecodestruc(0)
            If gidentifier.value.Contains(conrex.DBCLN) Then
                gidentifier.value = gidentifier.value.Remove(gidentifier.value.IndexOf(conrex.DBCLN))
                gidentifier.ile = gidentifier.value.Length
            End If
            If reclassname <> String.Empty Then
                If reclassname <> conrex.STRING Then
                    illdloc.ldindx = True
                End If
            Else
                reclassname = classname
            End If
            ldloc.load_single_in_stack(reclassname, gidentifier)
        End If

        Dim paramtype As ArrayList
        Dim cargcodestruc() As xmlunpkd.linecodestruc = libserv.cargldr
        libserv.cargldr = Nothing

        If IsNothing(methodinfo.parameters) = False Then
            ' Print Tokens :
            ' coutputdata.print_token(clinecodestruc)
            load_param_in_stack(clinecodestruc, _ilmethod, methodinfo, funcresult, paramtype, cargcodestruc)
        End If
        Dim getdatatype As String = methodinfo.returntype
        If isvirtualmethod Then
            Dim gexternassembly As String = conrex.NULL
            Dim greturntype As String = conrex.NULL
            libserv.get_return_type(funcresult.clmethod, namespaceindex, classindex, methodindex, greturntype, gexternassembly)
            Dim freturntype As String = String.Format("[{0}]{1}", gexternassembly, greturntype)
            cil.call_virtual_method(_ilmethod.codes, freturntype, funcresult.asmextern, classname, funcresult.clmethod, paramtype)
        Else
            If getdatatype <> conrex.VOID AndAlso servinterface.is_cil_common_data_type(getdatatype) = False Then
                Dim gexternassembly As String = conrex.NULL
                Dim greturntype As String = conrex.NULL
                libserv.get_return_type(funcresult.clmethod, namespaceindex, classindex, methodindex, greturntype, gexternassembly)
                getdatatype = String.Format("class [{0}]{1}", gexternassembly, greturntype)
            End If
            cil.call_extern_method(_ilmethod.codes, getdatatype, funcresult.asmextern, classname, funcresult.clmethod, paramtype)
            End If
            If convtc.setconvmethod Then convtc.set_type_cast(_ilmethod, methodinfo.returntype, funcresult.clmethod, clinecodestruc(0))

        If leftassign AndAlso getdatatype <> Nothing AndAlso getdatatype <> "void" Then
            cil.pop(_ilmethod.codes)
        End If
    End Sub

    Friend Shared Sub inv_internal_method(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, classname As String, funcresult As funcvalid._resultfuncvaild, leftassign As Boolean)
        Dim isvirtualmethod As Boolean = False
        Dim classindex As Integer = funcdtproc.get_index_class(_ilmethod, classname, isvirtualmethod)
        If classindex = -1 Then
            dserr.args.Add("Class '" & classname & "' not found.")
            dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            Return
        End If

        Dim methodindex As Integer = funcdtproc.get_index_method(_ilmethod, get_argument_list(clinecodestruc), funcresult.clmethod, classindex, leftassign)
        Select Case methodindex
            Case -1
                dserr.args.Add("Method " & funcresult.clmethod & "(...) not found.")
                dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            Case -2
                dserr.args.Add("Method " & funcresult.clmethod & "(...) , The parameters of the called function do not match its original function.")
                dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(1).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(2)), clinecodestruc(2).value), "Overloads :" & vbCrLf & funcdtproc.overloadlist)
        End Select
        If isvirtualmethod Then
            Dim ldloc As New illdloc(_ilmethod)
            Dim gidentifier As xmlunpkd.linecodestruc = clinecodestruc(0)
            If gidentifier.value.Contains(conrex.DBCLN) Then
                gidentifier.value = gidentifier.value.Remove(gidentifier.value.IndexOf(conrex.DBCLN))
                gidentifier.ile = gidentifier.value.Length
            End If
            ldloc.load_single_in_stack(classname, gidentifier)
        End If

        Dim methodinfo As tknformat._method = funcdtproc.get_method_info(classindex, methodindex)
        Dim paramtype As ArrayList
        If IsNothing(methodinfo.parameters) = False Then
            ' Print Tokens :
            ' coutputdata.print_token(clinecodestruc)
            load_param_in_stack(clinecodestruc, _ilmethod, methodinfo, funcresult, paramtype)
        End If

        Dim getdatatype As String = methodinfo.returntype
        If getdatatype <> Nothing AndAlso getdatatype <> "void" AndAlso servinterface.is_cil_common_data_type(getdatatype) = False Then
            Dim retnamespaceindex, retclassindex As Integer
            If libserv.get_extern_index_class(_ilmethod, getdatatype, retnamespaceindex, retclassindex) = -1 Then
                dserr.args.Add("Class " & getdatatype & " not found.")
                dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            End If
            Dim freturntype As String = String.Format("class [{0}]{1}", libserv.get_extern_assembly(retnamespaceindex), getdatatype)
            cil.call_intern_method(_ilmethod.codes, freturntype, classname, funcresult.clmethod, paramtype, isvirtualmethod)
        Else
            cil.call_intern_method(_ilmethod.codes, getdatatype, classname, funcresult.clmethod, paramtype, isvirtualmethod)
        End If
        If convtc.setconvmethod Then convtc.set_type_cast(_ilmethod, methodinfo.returntype, funcresult.clmethod, clinecodestruc(0))

        If leftassign AndAlso getdatatype <> Nothing AndAlso getdatatype <> "void" Then
            cil.pop(_ilmethod.codes)
        End If
    End Sub

    Friend Shared Sub load_param_in_stack(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, methodinfo As tknformat._method, funcresult As funcvalid._resultfuncvaild, ByRef paramtypes As ArrayList, Optional cargcodestruc() As xmlunpkd.linecodestruc = Nothing)
        Dim setconvmethod As Boolean = convtc.setconvmethod
        Dim ntypecast As String = convtc.ntypecast

        If IsNothing(cargcodestruc) Then cargcodestruc = get_argument_list(clinecodestruc)

        If IsNothing(cargcodestruc) OrElse cargcodestruc.Length <> methodinfo.parameters.Length Then
            'TODO : PARAMARRAY
            dserr.args.Add("Argument Not specified For parameter")
            dserr.new_error(conserr.errortype.ARGUMENTERROR, clinecodestruc(clinecodestruc.Length - 1).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(clinecodestruc.Length - 1)), clinecodestruc(clinecodestruc.Length - 1).value))
            Return
        End If

        check_expression_method(clinecodestruc, methodinfo)
        paramtypes = New ArrayList
        Dim emptyparamtypes As New ArrayList
        For index = 0 To methodinfo.parameters.Length - 1
            Dim getcildatatype As String = servinterface.vb_to_cil_common_data_type(methodinfo.parameters(index).ptype)
            If methodinfo.parameters(index).ptype <> getcildatatype OrElse servinterface.is_common_data_type(getcildatatype, getcildatatype) Then
                If methodinfo.parameters(index).name.EndsWith(conrex.BRSTEN) Then
                    getcildatatype &= conrex.BRSTEN
                End If
                If methodinfo.parameters(index).byreference Then getcildatatype &= "&"
                paramtypes.Add(getcildatatype)
                emptyparamtypes.Add(getcildatatype)
            Else
                'Other Types...
                set_extern_assembly(_ilmethod, paramtypes, methodinfo.parameters(index), emptyparamtypes)
            End If
        Next
        set_stack_space(_ilmethod, emptyparamtypes, cargcodestruc)
        convtc.setconvmethod = setconvmethod
        convtc.ntypecast = ntypecast
    End Sub

    Private Shared Sub set_extern_assembly(_ilmethod As ilformat._ilmethodcollection, ByRef paramtypes As ArrayList, parameterinf As tknformat._parameter, ByRef emptyparamtypes As ArrayList)
        Dim gcodeparam As String = String.Empty
        If parameterinf.typeinf.asminfo = conrex.NULL Then

            Dim clinetypeinfostruct(2) As xmlunpkd.linecodestruc
            clinetypeinfostruct(0) = servinterface.get_line_code_struct(parameterinf.dtypetargetinfo, parameterinf.ptype, tokenhared.token.IDENTIFIER)
            clinetypeinfostruct(1) = New xmlunpkd.linecodestruc
            clinetypeinfostruct(1).tokenid = tokenhared.token.PRSTART
            clinetypeinfostruct(1).value = conrex.PRSTART
            clinetypeinfostruct(2) = New xmlunpkd.linecodestruc
            clinetypeinfostruct(2).tokenid = tokenhared.token.PREND
            clinetypeinfostruct(2).value = conrex.PREND
            parameterinf.typeinf = yotypecreator.get_type_info(_ilmethod, clinetypeinfostruct, 0, parameterinf.ptype)
            'TODO : Set type info for yomethod
        End If

        If parameterinf.typeinf.isenum = False Then
            If parameterinf.typeinf.isinternalclass Then
                gcodeparam = String.Format("class {0}", parameterinf.typeinf.fullname)
            Else
                gcodeparam = String.Format("class [{0}]{1}", parameterinf.typeinf.externlib, parameterinf.typeinf.fullname)
            End If
        Else
                If parameterinf.typeinf.isinternalclass Then
                gcodeparam = String.Format("valuetype {0}/{1}", parameterinf.typeinf.valtpinf.classname, parameterinf.typeinf.valtpinf.objectname)
            Else
                gcodeparam = String.Format("valuetype [{0}]{1}/{2}", parameterinf.typeinf.externlib, parameterinf.typeinf.valtpinf.classname, parameterinf.typeinf.valtpinf.objectname)
            End If
        End If
        paramtypes.Add(gcodeparam)
        emptyparamtypes.Add(parameterinf.typeinf.fullname)
    End Sub

    Private Shared Sub check_expression_method(clinecodestruc() As xmlunpkd.linecodestruc, methodinfo As tknformat._method)
        If methodinfo.isexpr Then
            For index = 0 To clinecodestruc.Length - 1
                If clinecodestruc(index).tokenid = tokenhared.token.NULL OrElse clinecodestruc(index).tokenid = tokenhared.token.TYPE_CO_STR OrElse clinecodestruc(index).tokenid = tokenhared.token.TYPE_DU_STR Then
                    dserr.args.Add(clinecodestruc(index).value)
                    dserr.new_error(conserr.errortype.EXPRMETHODERROR, clinecodestruc(index).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(index)), clinecodestruc(index).value))
                End If
            Next
        End If
    End Sub

    Private Shared Sub set_stack_space(ByRef _ilmethod As ilformat._ilmethodcollection, paramtypes As ArrayList, cargcodestruc As xmlunpkd.linecodestruc())
        Dim ldlc As New illdloc(_ilmethod)
        _ilmethod = ldlc.load_in_stack(paramtypes, cargcodestruc)
    End Sub
    Friend Shared Function get_argument_list(clinecodestruc() As xmlunpkd.linecodestruc) As xmlunpkd.linecodestruc()
        Dim cargcodestruc() As xmlunpkd.linecodestruc
        Dim icarg As Integer = 0
        Dim stateparam As Boolean = False
        fscmawait = False
        For index = 0 To clinecodestruc.Length - 1
            If stateparam = False AndAlso clinecodestruc(index).tokenid = tokenhared.token.PRSTART Then
                stateparam = True
                Continue For
            ElseIf stateparam = True AndAlso clinecodestruc(index).tokenid = tokenhared.token.PREND Then
                Return cargcodestruc
            ElseIf stateparam = False Then
                Continue For
            Else
                Dim cargprtester As xmlunpkd.linecodestruc
                If define_carg_store(clinecodestruc(index), cargprtester) Then
                    If IsNothing(cargcodestruc) = False Then
                        icarg = cargcodestruc.Length
                    End If
                    Array.Resize(cargcodestruc, icarg + 1)
                    cargcodestruc(icarg) = cargprtester
                End If
            End If
        Next
        Return cargcodestruc
    End Function

    Private Shared fscmawait As Boolean = False
    Private Shared Function define_carg_store(clinecodestruc As xmlunpkd.linecodestruc, ByRef cargcodestruc As xmlunpkd.linecodestruc) As Boolean
        If fscmawait Then
            If clinecodestruc.tokenid = tokenhared.token.CMA Then
                fscmawait = False
                Return False
            Else
                dserr.args.Add(conrex.CMA)
                dserr.new_error(conserr.errortype.EXPECTEDERROR, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
            End If
        Else
            If servinterface.check_argument_token(clinecodestruc.tokenid) Then
                cargcodestruc = clinecodestruc
                fscmawait = True
                Return True
            Else
                dserr.args.Add("'" & clinecodestruc.value & "' Cannot be identified as a parameter.")
                dserr.new_error(conserr.errortype.ARGUMENTERROR, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
            End If
        End If
        Return False
    End Function
End Class
