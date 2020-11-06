Public Class funcste
    Friend Shared attribute As yocaattribute.yoattribute
    Friend Shared Sub invoke_method(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, funcresult As funcvalid._resultfuncvaild, Optional leftassign As Boolean = True)
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
        Dim getdatatype As String = methodinfo.returntype
        cil.call_intern_method(_ilmethod.codes, getdatatype, attribute._app._classname, funcresult.clmethod, Nothing)
        If leftassign AndAlso getdatatype <> Nothing AndAlso getdatatype <> "void" Then
            cil.pop(_ilmethod.codes)
        End If
    End Sub
End Class
