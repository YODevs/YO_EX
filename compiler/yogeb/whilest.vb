Imports YOCA

Public Class whilest
    Private _ilmethod As ilformat._ilmethodcollection
    Private getbrcond As String = String.Empty
    Private headln As String
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_while_st(clinecodestruc() As xmlunpkd.linecodestruc, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        Dim condlinecodestruc() As xmlunpkd.linecodestruc = condproc.get_condition(clinecodestruc, 1)
        Dim whilenblock As xmlunpkd.linecodestruc = condproc.get_block_body(clinecodestruc)
        Dim nbranch As New condproc.branchtargetinfo
        nbranch.truebranch = lngen.get_line_prop("st_wh")
        nbranch.falsebranch = lngen.get_line_prop("en_wh")
        headln = lngen.get_line_prop("head_wh")
        set_while_body(whilenblock, nbranch, illocalinit, localinit)

        Dim cdproc As New condproc(nbranch)
        cdproc.set_condition(_ilmethod, condlinecodestruc)
        lngen.set_direct_label(nbranch.falsebranch, _ilmethod.codes)
        Return _ilmethod
    End Function

    Private Sub set_while_body(whilenblock As xmlunpkd.linecodestruc, nbranch As condproc.branchtargetinfo, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        getbrcond = lngen.get_line_prop("op_while")
        stjmper.set_new_jmper(tokenhared.token.WHILE, nbranch.falsebranch, getbrcond, headln)
        cil.branch_to_target(_ilmethod.codes, getbrcond)
        lngen.set_direct_label(nbranch.truebranch, _ilmethod.codes)
        lngen.set_direct_label(headln, _ilmethod.codes)
        Dim iltrans As New iltranscore(ilbodybulider.path, whilenblock.value, illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        illocalinit = _ilmethod.locallinit
        lngen.set_direct_label(getbrcond, _ilmethod.codes)
        stjmper.reset_jmper(tokenhared.token.WHILE)
    End Sub
End Class
