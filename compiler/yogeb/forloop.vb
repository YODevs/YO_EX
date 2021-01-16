﻿Public Class forloop

    Private _ilmethod As ilformat._ilmethodcollection
    Private getbrcond As String = String.Empty
    Private getbrhead As String = String.Empty
    Private getbrexit As String = String.Empty
    Private loopvar As String = String.Empty
    Private loopvarcodestruc As xmlunpkd.linecodestruc
    Private looprangecodestruc As xmlunpkd.linecodestruc
    Private rnginf As rangeserv.ranginf

    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_for_st(clinecodestruc() As xmlunpkd.linecodestruc, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.FOR)
        loopvar = clinecodestruc(2).value
        loopvarcodestruc = clinecodestruc(2)
        rnginf = rangeserv.get_range_info(clinecodestruc(4))
        looprangecodestruc = clinecodestruc(4)
        set_flag_loop(illocalinit)
        getbrcond = lngen.get_line_prop("cond_for_")
        getbrhead = lngen.get_line_prop("head_for_")
        getbrexit = lngen.get_line_prop("exit_for_")
        cil.branch_to_target(_ilmethod.codes, getbrcond)
        set_body_loop(clinecodestruc(6), illocalinit, localinit)
        Return _ilmethod
    End Function

    Private Sub set_body_loop(bodycodestruc As xmlunpkd.linecodestruc, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        lngen.set_direct_label(getbrhead, _ilmethod.codes)
        localinit.add_local_init("n", "i32")
        _ilmethod.locallinit = illocalinit
        Dim iltrans As New iltranscore(ilbodybulider.path, bodycodestruc.value, illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        illocalinit = _ilmethod.locallinit
        set_step_loop()
        lngen.set_direct_label(getbrcond, _ilmethod.codes)
        set_condition()
        lngen.set_direct_label(getbrexit, _ilmethod.codes)
    End Sub

    Private Sub set_step_loop()
        cil.load_local_variable(_ilmethod.codes, loopvar)
        cil.push_int32_onto_stack(_ilmethod.codes, rnginf.stepsc)
        cil.add(_ilmethod.codes)
        cil.set_stack_local(_ilmethod.codes, loopvar)
    End Sub
    Private Sub set_condition()
        Dim ldloc As New illdloc(_ilmethod)
        ldloc.load_single_in_stack("int32", loopvarcodestruc)
        Dim envarloop As New xmlunpkd.linecodestruc
        envarloop.value = rnginf.endpoint
        If IsNumeric(rnginf.endpoint) Then
            envarloop.tokenid = tokenhared.token.TYPE_INT
        Else
            envarloop.tokenid = tokenhared.token.IDENTIFIER
        End If

        envarloop.line = looprangecodestruc.line
        envarloop.ist = looprangecodestruc.value.IndexOf("..") + 2
        envarloop.ile = envarloop.value.Length
        envarloop.ien = envarloop.value.Length
        ldloc.load_single_in_stack("int32", envarloop)
        cil.ble(_ilmethod.codes, getbrhead)
    End Sub
    Private Sub set_flag_loop(ByRef _illocalinit() As ilformat._illocalinit)
        Dim locinit As New ilformat._illocalinit
        locinit.name = loopvar
        'default common data type for 'FOR' loop
        locinit.datatype = "int32"
        locinit.hasdefaultvalue = True
        locinit.iscommondatatype = True
        Array.Resize(locinit.clocalvalue, 1)
        locinit.clocalvalue(0).value = 0
        illocalsinit.set_local_init(_illocalinit, locinit)
        cil.push_int32_onto_stack(_ilmethod.codes, 0)
        cil.set_stack_local(_ilmethod.codes, loopvar)
    End Sub

End Class