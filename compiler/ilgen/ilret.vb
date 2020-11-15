Imports YOCA

Public Class ilret
    Friend Shared Sub ret_to_route(ByRef ilmethod As ilformat._ilmethodcollection, clinecodestruc() As xmlunpkd.linecodestruc)
        'TODO : Return & Exit func
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.RET)
        Dim ldvar As New illdloc(ilmethod)
        ldvar.load_single_in_stack(ilmethod.returntype, clinecodestruc(1))
        cil.ret(ilmethod.codes)
    End Sub
End Class
