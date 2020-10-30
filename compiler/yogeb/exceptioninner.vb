Imports YOCA

Public Class exceptioninner
    Friend Shared leavebrachlabel As New ArrayList
    Private _ilmethod As ilformat._ilmethodcollection
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_try_block(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.TRY)
        Dim leavelbl As String = set_leave_branch()
        cil.insert_il(_ilmethod.codes, ".try{")
        Dim iltrans As New iltranscore(ilbodybulider.path, clinecodestruc(1).value, _illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        _illocalinit = _ilmethod.locallinit
        cil.leave(_ilmethod.codes, leavelbl)
        cil.insert_il(_ilmethod.codes, "}")
        Return _ilmethod
    End Function

    Private Function set_leave_branch()
        Dim cline As String = lngen.get_line_prop("leavebr")
        leavebrachlabel.Add(cline)
        stjmper.set_new_jmper(tokenhared.token.TRY, cline, Nothing)
        Return cline
    End Function

    Public Function set_catch_block(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.CATCH)
        set_flag_exception(_illocalinit, clinecodestruc)
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
        stjmper.reset_jmper(tokenhared.token.TRY)
        Return _ilmethod
    End Function

    Private Sub set_flag_exception(ByRef _illocalinit() As ilformat._illocalinit, clinecodestruc() As xmlunpkd.linecodestruc)
        Dim locinit As New ilformat._illocalinit
        locinit.name = lngen.get_flag
        locinit.datatype = "System.Exception"
        locinit.hasdefaultvalue = False
        locinit.iscommondatatype = False
        illocalsinit.set_local_init(_illocalinit, locinit)
    End Sub

    Friend Function set_err(clinecodestruc() As xmlunpkd.linecodestruc) As ilformat._ilmethodcollection
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.ERR)
        cil.throw_simple(_ilmethod.codes, clinecodestruc(1).value)
        Return _ilmethod
    End Function
End Class
