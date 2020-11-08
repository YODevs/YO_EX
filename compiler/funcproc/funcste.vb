Public Class funcste
    Friend Shared attribute As yocaattribute.yoattribute
    Friend Shared Sub invoke_method(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, funcresult As funcvalid._resultfuncvaild, Optional leftassign As Boolean = True)
        fscmawait = False
        If funcresult.callintern Then
            inv_internal_method(clinecodestruc, _ilmethod, funcresult, leftassign)
        End If
    End Sub

    Friend Shared Sub inv_internal_method(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, funcresult As funcvalid._resultfuncvaild, leftassign As Boolean)
        Dim classindex As Integer = funcdtproc.get_index_class(attribute._app._classname)
        If classindex = -1 Then
            dserr.args.Add("Class " & attribute._app._classname & " not found.")
            dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            Return
        End If
        Dim methodindex As Integer = funcdtproc.get_index_method(funcresult.clmethod, classindex)
        If methodindex = -1 Then
            dserr.args.Add("Method " & funcresult.clmethod & "(...) not found.")
            dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End If

        Dim methodinfo As tknformat._method = funcdtproc.get_method_info(classindex, methodindex)
        If IsNothing(methodinfo.parameters) = False Then
            coutputdata.print_token(clinecodestruc)
            load_param_in_stack(clinecodestruc, _ilmethod, methodinfo, funcresult)
        End If
        Dim getdatatype As String = methodinfo.returntype
        cil.call_intern_method(_ilmethod.codes, getdatatype, attribute._app._classname, funcresult.clmethod, Nothing)
        If leftassign AndAlso getdatatype <> Nothing AndAlso getdatatype <> "void" Then
            cil.pop(_ilmethod.codes)
        End If
    End Sub

    Private Shared Sub load_param_in_stack(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, methodinfo As tknformat._method, funcresult As funcvalid._resultfuncvaild)
        Dim cargcodestruc() As xmlunpkd.linecodestruc = get_argument_list(clinecodestruc)
        If cargcodestruc.Length <> methodinfo.parameters.Length Then
            'Set error 
            'TODO : PARAMARRAY
            MsgBox("Error Len : " & clinecodestruc.Length & "-" & methodinfo.parameters.Length)
            Return
        End If

        For Index = 0 To methodinfo.parameters.Length - 1
            MsgBox(methodinfo.parameters(Index).ptype & vbCrLf & clinecodestruc(Index).name & " - " & clinecodestruc(Index).value)
        Next
    End Sub

    Private Shared Function get_argument_list(clinecodestruc() As xmlunpkd.linecodestruc) As xmlunpkd.linecodestruc()
        Dim cargcodestruc(0) As xmlunpkd.linecodestruc
        Dim icarg As Integer = 0
        Dim stateparam As Boolean = False
        For index = 0 To clinecodestruc.Length - 1
            If stateparam = False AndAlso clinecodestruc(index).tokenid = tokenhared.token.PRSTART Then
                stateparam = True
                Continue For
            ElseIf stateparam = False Then
                Continue For
            Else
                If IsNothing(cargcodestruc) Then
                    cargcodestruc(icarg) = New xmlunpkd.linecodestruc
                Else
                    icarg = cargcodestruc.Length
                    Array.Resize(cargcodestruc, icarg + 1)
                    cargcodestruc(icarg) = New xmlunpkd.linecodestruc
                End If
                define_carg_store(clinecodestruc(index), cargcodestruc(icarg))
            End If
        Next
        Return cargcodestruc
    End Function

    Private Shared fscmawait As Boolean = False
    Private Shared Sub define_carg_store(clinecodestruc As xmlunpkd.linecodestruc, ByRef cargcodestruc As xmlunpkd.linecodestruc)
        If fscmawait Then
            If clinecodestruc.tokenid = tokenhared.token.CMA Then

            End If
        Else

        End If
    End Sub
End Class
