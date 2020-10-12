Public Class toiter
    Private _ilmethod As ilformat._ilmethodcollection
    Private counterflag, lastcounterflag, headerbranchlabel, endbranchlabel, bodybranchlabel, increasebranchlabel As String
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_to_iter(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        'Check syntax
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.TOITER)
        'Create a flag variable for [TO] iter
        set_flag_loop(_illocalinit, clinecodestruc)
        endbranchlabel = lngen.get_line_prop("toexit")

        increasebranchlabel = lngen.get_line_prop("toincr")

        'Set up Continue , Break statement
        stjmper.set_new_jmper(tokenhared.token.TO, endbranchlabel, increasebranchlabel)

        'Create & Set lebel for [TO] header
        headerbranchlabel = lngen.set_label("toheader", _ilmethod.codes)

        'Set condition of loops.
        set_condition_identifier()

        'Create & Set label for [TO] body
        bodybranchlabel = lngen.set_label("tobody", _ilmethod.codes)

        'Test constant code ... for body
        Dim iltrans As New iltranscore(ilbodybulider.path, clinecodestruc(4).value, _illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        _illocalinit = _ilmethod.locallinit
        'imp_cil_code.import_test_code2(_ilmethod)

        'Increase counter +1
        increase_counter()

        'Footer conditon
        set_condition_identifier(True)

        'Set exit TO label 
        lngen.set_direct_label(endbranchlabel, _ilmethod.codes)

        stjmper.reset_jmper(tokenhared.token.TO)
        Return _ilmethod
    End Function
    Private Sub increase_counter()
        lngen.set_direct_label(increasebranchlabel, _ilmethod.codes)
        cil.load_local_variable(_ilmethod.codes, counterflag)
        cil.push_int32_onto_stack(_ilmethod.codes, 1)
        cil.add(_ilmethod.codes)
        cil.set_stack_local(_ilmethod.codes, counterflag)
    End Sub
    Private Sub set_condition_identifier(Optional footercondition As Boolean = False)
        cil.load_local_variable(_ilmethod.codes, counterflag)
        cil.load_local_variable(_ilmethod.codes, lastcounterflag)
        cil.ceq(_ilmethod.codes)
        If footercondition Then
            cil.branch_if_false(_ilmethod.codes, bodybranchlabel)
        Else
            cil.branch_if_true(_ilmethod.codes, endbranchlabel)
        End If
    End Sub

    Private Sub set_flag_loop(ByRef _illocalinit() As ilformat._illocalinit, clinecodestruc() As xmlunpkd.linecodestruc)
        Dim locinit As New ilformat._illocalinit
        locinit.name = lngen.get_flag
        locinit.datatype = "int32"
        locinit.hasdefaultvalue = True
        locinit.iscommondatatype = True
        Array.Resize(locinit.clocalvalue, 1)
        locinit.clocalvalue(0).value = 0
        counterflag = locinit.name
        illocalsinit.set_local_init(_illocalinit, locinit)
        cil.push_int32_onto_stack(_ilmethod.codes, 0)
        cil.set_stack_local(_ilmethod.codes, counterflag)

        locinit = New ilformat._illocalinit
        locinit.name = lngen.get_flag
        locinit.datatype = "int32"
        locinit.hasdefaultvalue = True
        locinit.iscommondatatype = True
        Array.Resize(locinit.clocalvalue, 1)
        locinit.clocalvalue(0).value = 0
        lastcounterflag = locinit.name
        illocalsinit.set_local_init(_illocalinit, locinit)
        'Set initial value for [TO] flag
        set_initial_value(locinit.name, clinecodestruc(2))
    End Sub

    Private Sub set_initial_value(varname As String, clinecodestruc As xmlunpkd.linecodestruc)
        Dim optgen As New ilopt(_ilmethod)
        _ilmethod = optgen.assi_int(varname, clinecodestruc, "int32")
    End Sub
End Class
