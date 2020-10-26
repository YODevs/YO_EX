Public Class exceptioninner
    Friend Shared leavebrachlabel As New ArrayList
    Private _ilmethod As ilformat._ilmethodcollection
    Private endbranchlabel, bodybranchlabel As String
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_try_block(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.TRY)
        cil.insert_il(_ilmethod.codes, ".try{")
        Dim iltrans As New iltranscore(ilbodybulider.path, clinecodestruc(1).value, _illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        _illocalinit = _ilmethod.locallinit
        cil.leave(_ilmethod.codes, set_leave_branch())
        cil.insert_il(_ilmethod.codes, "}")
        Return _ilmethod
    End Function

    Private Function set_leave_branch()
        Dim cline As String = lngen.get_line_prop("leavebr")
        leavebrachlabel.Add(cline)
        Return cline
    End Function

    Public Function set_catch_block(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.CATCH)
        cil.insert_il(_ilmethod.codes, "catch [mscorlib]System.Exception {")
        Dim iltrans As New iltranscore(ilbodybulider.path, clinecodestruc(1).value, _illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        _illocalinit = _ilmethod.locallinit
        Dim leavebr As String = String.Empty
        If leavebrachlabel.Count > 0 Then
            leavebr = leavebrachlabel(leavebrachlabel.Count - 1)
            leavebrachlabel.RemoveAt(leavebrachlabel.Count - 1)
        Else
            dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(0).line, ilbodybulider.path, "Block try code not found.
Before starting the Catch block, be sure to write the try block.")
        End If
        cil.leave(_ilmethod.codes, leavebr)
        cil.insert_il(_ilmethod.codes, "}")
        lngen.set_direct_label(leavebr, _ilmethod.codes)
        Return _ilmethod
    End Function
End Class
