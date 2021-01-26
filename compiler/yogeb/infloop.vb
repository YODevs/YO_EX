Public Class infloop
    Private _ilmethod As ilformat._ilmethodcollection
    Private endbranchlabel, bodybranchlabel As String
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_infinity_loop(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.LOOP)
        endbranchlabel = lngen.get_line_prop("loopexit")
        bodybranchlabel = lngen.get_line_prop("loopbody")
        set_jmper()

        lngen.set_direct_label(bodybranchlabel, _ilmethod.codes)

        Dim iltrans As New iltranscore(ilbodybulider.path, clinecodestruc(1).value, _illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        _illocalinit = _ilmethod.locallinit

        set_condition()
        lngen.set_direct_label(endbranchlabel, _ilmethod.codes)

        stjmper.reset_jmper(tokenhared.token.LOOP)

        Return _ilmethod
    End Function

    Private Sub set_condition()
        cil.branch_to_target(_ilmethod.codes, bodybranchlabel)
    End Sub

    Private Sub set_jmper()
        stjmper.set_new_jmper(tokenhared.token.LOOP, endbranchlabel, bodybranchlabel, bodybranchlabel)
    End Sub
End Class
