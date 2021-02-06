Public Class forloop

    Private _ilmethod As ilformat._ilmethodcollection
    Private getbrcond As String = String.Empty
    Private getbrhead As String = String.Empty
    Private getbrstep As String = String.Empty
    Private getbrexit As String = String.Empty
    Private loopvar As String = String.Empty
    Private loopvarcodestruc As xmlunpkd.linecodestruc
    Private looprangecodestruc As xmlunpkd.linecodestruc
    Private rnginf As rangeserv.ranginf
    Private userange As Boolean = False
    Private isreverseloop As Boolean = False
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_for_st(clinecodestruc() As xmlunpkd.linecodestruc, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.FOR)
        loopvar = clinecodestruc(2).value
        loopvarcodestruc = clinecodestruc(2)
        If clinecodestruc(4).tokenid = tokenhared.token.RANGE Then
            userange = True
            rnginf = rangeserv.get_range_info(clinecodestruc(4))
        Else
            rnginf.startpoint = 0
            rnginf.endpoint = clinecodestruc(4).value
            rnginf.ignorelastpoint = False
            rnginf.stepsc = 1
        End If
        looprangecodestruc = clinecodestruc(4)
        set_flag_loop(illocalinit)
        getbrcond = lngen.get_line_prop("cond_for_")
        getbrstep = lngen.get_line_prop("step_for_")
        getbrhead = lngen.get_line_prop("head_for_")
        getbrexit = lngen.get_line_prop("exit_for_")
        cil.branch_to_target(_ilmethod.codes, getbrcond)
        set_body_loop(clinecodestruc(6), illocalinit, localinit)
        Return _ilmethod
    End Function

    Private Sub set_body_loop(bodycodestruc As xmlunpkd.linecodestruc, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        lngen.set_direct_label(getbrhead, _ilmethod.codes)
        stjmper.set_new_jmper(tokenhared.token.FOR, getbrexit, getbrstep, getbrhead)
        _ilmethod.locallinit = illocalinit
        Dim iltrans As New iltranscore(ilbodybulider.path, bodycodestruc.value, illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        illocalinit = _ilmethod.locallinit
        set_step_loop()
        lngen.set_direct_label(getbrcond, _ilmethod.codes)
        set_condition()
        lngen.set_direct_label(getbrexit, _ilmethod.codes)
        stjmper.reset_jmper(tokenhared.token.FOR)
    End Sub

    Private Sub set_step_loop()
        lngen.set_direct_label(getbrstep, _ilmethod.codes)
        cil.load_local_variable(_ilmethod.codes, loopvar)
        If IsNumeric(rnginf.stepsc) Then
            cil.push_int32_onto_stack(_ilmethod.codes, rnginf.stepsc)
            If rnginf.stepsc < 0 Then
                isreverseloop = True
            End If
        Else
            Dim stadderloop As New xmlunpkd.linecodestruc
            stadderloop.value = rnginf.stepsc
            stadderloop.tokenid = tokenhared.token.IDENTIFIER
            stadderloop.line = looprangecodestruc.line
            stadderloop.ist = looprangecodestruc.value.IndexOf(";") + 1
            stadderloop.ile = stadderloop.value.Length
            stadderloop.ien = stadderloop.value.Length
            Dim ldloc As New illdloc(_ilmethod)
            ldloc.load_single_in_stack("int32", stadderloop)
        End If
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
        If userange Then
            If isreverseloop = False Then
                If rnginf.ignorelastpoint Then
                    cil.blt(_ilmethod.codes, getbrhead)
                Else
                    cil.ble(_ilmethod.codes, getbrhead)
                End If
            Else
                cil.bge(_ilmethod.codes, getbrhead)
            End If
        Else
                cil.ble(_ilmethod.codes, getbrhead)
        End If
    End Sub
    Private Sub set_flag_loop(ByRef _illocalinit() As ilformat._illocalinit)
        Dim locinit As New ilformat._illocalinit
        locinit.name = loopvar
        'default common data type for 'FOR' loop
        locinit.datatype = "int32"
        locinit.hasdefaultvalue = False
        locinit.iscommondatatype = True
        Array.Resize(locinit.clocalvalue, 1)
        illocalsinit.set_local_init(_illocalinit, locinit)
        If IsNumeric(rnginf.startpoint) Then
            cil.push_int32_onto_stack(_ilmethod.codes, rnginf.startpoint)
        Else
            Dim ldloc As New illdloc(_ilmethod)
            Dim stvarloop As New xmlunpkd.linecodestruc
            stvarloop.value = rnginf.startpoint
            stvarloop.tokenid = tokenhared.token.IDENTIFIER
            stvarloop.line = looprangecodestruc.line
            stvarloop.ist = 0
            stvarloop.ile = looprangecodestruc.value.IndexOf("..")
            stvarloop.ien = looprangecodestruc.value.IndexOf("..")
            ldloc.load_single_in_stack("int32", stvarloop)
        End If
        cil.set_stack_local(_ilmethod.codes, loopvar)
    End Sub

End Class
