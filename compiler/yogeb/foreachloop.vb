Public Class foreachloop
    Private _ilmethod As ilformat._ilmethodcollection
    Private _typeinfo As ilformat._typeinfo
    Private getbrcond As String = String.Empty
    Private getbrhead As String = String.Empty
    Private getbrstep As String = String.Empty
    Private getbrexit As String = String.Empty
    Private singlevarname As String = String.Empty
    Private indexvarname As String = String.Empty
    Private loopvarcodestruc As xmlunpkd.linecodestruc
    Private loopcollectioncodestruc As xmlunpkd.linecodestruc
    Private rnginf As rangeserv.ranginf
    Private userange As Boolean = False
    Private isreverseloop As Boolean = False
    Public Sub New(ilmethod As ilformat._ilmethodcollection, typeinf As ilformat._typeinfo)
        Me._ilmethod = ilmethod
        Me._typeinfo = typeinf
        indexvarname = lngen.get_varname("_index_")
    End Sub

    Friend Function set_foreach_st(clinecodestruc() As xmlunpkd.linecodestruc, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        set_single_variable(clinecodestruc, illocalinit, localinit)
        set_flag_loop(illocalinit, localinit)
        _ilmethod.locallinit = illocalinit
        loopcollectioncodestruc = clinecodestruc(4)
        set_braches()
        set_body_loop(clinecodestruc(6), illocalinit, localinit)
        _ilmethod.locallinit = illocalinit
        set_condition()

        Return _ilmethod
    End Function

    Private Sub set_condition()
        'Load index
        lngen.set_direct_label(getbrcond, _ilmethod.codes)
        cil.load_local_variable(_ilmethod.codes, indexvarname)
        Dim ldloc As New illdloc(_ilmethod)
        ldloc.load_single_in_stack(_typeinfo.fullname, loopcollectioncodestruc)
        cil.ldlen(_ilmethod.codes)
        cil.conv_to_int32(_ilmethod.codes)
        cil.clt(_ilmethod.codes)
        cil.branch_if_true(_ilmethod.codes, getbrhead)
        lngen.set_direct_label(getbrexit, _ilmethod.codes)
    End Sub

    Private Sub set_braches()
        getbrcond = lngen.get_line_prop("cond_foreach_")
        getbrstep = lngen.get_line_prop("step_foreach_")
        getbrhead = lngen.get_line_prop("head_foreach_")
        getbrexit = lngen.get_line_prop("exit_foreach_")
        cil.branch_to_target(_ilmethod.codes, getbrcond)
        lngen.set_direct_label(getbrhead, _ilmethod.codes)
    End Sub

    Private Sub set_body_loop(bodycodestruc As xmlunpkd.linecodestruc, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        stjmper.set_new_jmper(tokenhared.token.FOR, getbrexit, getbrstep, getbrhead)
        _ilmethod.locallinit = illocalinit
        load_collection_to_variable()
        Dim iltrans As New iltranscore(ilbodybulider.path, bodycodestruc.value, illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        illocalinit = _ilmethod.locallinit
        set_step_loop()
        stjmper.reset_jmper(tokenhared.token.FOR)
    End Sub

    Private Sub load_collection_to_variable()
        Dim ldloc As New illdloc(_ilmethod)
        ldloc.load_single_in_stack(_typeinfo.fullname, loopcollectioncodestruc)
        cil.load_local_variable(_ilmethod.codes, indexvarname)
        Select Case _typeinfo.cdttypesymbol
            Case compdt.INT32
                cil.ldelem(_ilmethod.codes, compdt.INT32)
            Case compdt.INT64
                cil.ldelem(_ilmethod.codes, compdt.INT64)
            Case compdt.FLOAT32
                cil.ldelem(_ilmethod.codes, compdt.FLOAT32)
            Case compdt.FLOAT64
                cil.ldelem(_ilmethod.codes, compdt.FLOAT64)
            Case Else
                cil.ldelem(_ilmethod.codes)
        End Select
        cil.set_stack_local(_ilmethod.codes, singlevarname)
    End Sub

    Private Sub set_step_loop()
        lngen.set_direct_label(getbrstep, _ilmethod.codes)
        cil.nop(_ilmethod.codes)
        cil.load_local_variable(_ilmethod.codes, indexvarname)
        cil.push_int32_onto_stack(_ilmethod.codes, 1)
        cil.add(_ilmethod.codes)
        cil.set_stack_local(_ilmethod.codes, indexvarname)
    End Sub

    Private Sub set_single_variable(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        Dim locinit As New ilformat._illocalinit
        singlevarname = clinecodestruc(2).value
        locinit.name = singlevarname
        If _typeinfo.isprimitive Then
            locinit.datatype = _typeinfo.cdttypesymbol
            locinit.iscommondatatype = True
        Else
            locinit.datatype = _typeinfo.fullname
            locinit.iscommondatatype = False
        End If
        locinit.typeinf = _typeinfo
        locinit.typeinf.isarray = False
        locinit.hasdefaultvalue = False
        Array.Resize(locinit.clocalvalue, 1)
        illocalsinit.set_local_init(_illocalinit, locinit)
    End Sub

    Private Sub set_flag_loop(ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        Dim locinit As New ilformat._illocalinit
        locinit.name = indexvarname
        locinit.datatype = "int32"
        locinit.hasdefaultvalue = False
        locinit.iscommondatatype = True
        Array.Resize(locinit.clocalvalue, 1)
        illocalsinit.set_local_init(_illocalinit, locinit)
        localinit.add_local_init(locinit.name, locinit.datatype)
        cil.push_int32_onto_stack(_ilmethod.codes, 0)
        cil.set_stack_local(_ilmethod.codes, indexvarname)
    End Sub
End Class
