Imports YOCA

Public Class ulcond
    Private _ilmethod As ilformat._ilmethodcollection

    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        _ilmethod = ilmethod
    End Sub

    Friend Function set_ul_statement(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        Dim condlinecodestruc() As xmlunpkd.linecodestruc = condproc.get_condition(clinecodestruc, 1)
        Dim ifenblock As xmlunpkd.linecodestruc = condproc.get_block_body(clinecodestruc)
        Dim nbranch As New condproc.branchtargetinfo
        nbranch.truebranch = lngen.get_line_prop("st_ul")
        nbranch.falsebranch = lngen.get_line_prop("en_ul")
        Dim cdproc As New condproc(nbranch)
        cdproc.set_condition(_ilmethod, condlinecodestruc, True)
        set_ul_body(ifenblock, nbranch, _illocalinit, localinit)
        Return _ilmethod
    End Function

    Private Sub set_ul_body(ifenblock As xmlunpkd.linecodestruc, nbranch As condproc.branchtargetinfo, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        stjmper.set_new_jmper(tokenhared.token.UL, nbranch.truebranch, Nothing)
        lngen.set_direct_label(nbranch.falsebranch, _ilmethod.codes)
        Dim iltrans As New iltranscore(ilbodybulider.path, ifenblock.value, illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        illocalinit = _ilmethod.locallinit
        stjmper.reset_jmper(tokenhared.token.UL)
        lngen.set_direct_label(nbranch.truebranch, _ilmethod.codes)
    End Sub
End Class
