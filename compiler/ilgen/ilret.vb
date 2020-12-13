Imports YOCA

Public Class ilret
    Friend Shared Sub ret_to_route(ByRef ilmethod As ilformat._ilmethodcollection, clinecodestruc() As xmlunpkd.linecodestruc)
        If clinecodestruc.Length = 1 Then
            If ilmethod.returntype = conrex.NULL Then
                cil.ret(ilmethod.codes)
            Else
                dserr.args.Add(ilmethod.returntype)
                dserr.new_error(conserr.errortype.RETURNERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            End If
            Return
        End If
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.RET)
        Dim ldvar As New illdloc(ilmethod)
        ldvar.load_single_in_stack(ilmethod.returntype, clinecodestruc(1))
        cil.ret(ilmethod.codes)
    End Sub
End Class
