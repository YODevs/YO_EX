Public Class matchst
    Private _ilmethod As ilformat._ilmethodcollection
    Private clinecondstruc As xmlunpkd.linecodestruc
    Private scount As Integer = 0
    Private conddtype As String
    Private endbranchlabel, nextblocklabel As String
    Private issetdefaultblock As Boolean = False
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_match_st(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        'Check syntax
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.MATCH)
        endbranchlabel = lngen.get_line_prop(scount)
        stjmper.set_new_jmper(tokenhared.token.MATCH, endbranchlabel, Nothing)
        scount += 1
        clinecondstruc = clinecodestruc(2)
        servinterface.get_dt_proc(_ilmethod, clinecondstruc, conddtype)
        Dim xmldata As xmlunpkd
        xmldata = New xmlunpkd(clinecodestruc(4).value, False)
        While xmldata.xmlreader.EOF = False
            Dim bodyclinecodestruc() As xmlunpkd.linecodestruc
            bodyclinecodestruc = xmldata.get_line_tokens()
            If bodyclinecodestruc.Length = 0 Then Continue While
            rev_cline_code(bodyclinecodestruc, _illocalinit, localinit)
        End While
        lngen.set_direct_label(endbranchlabel, _ilmethod.codes)
        stjmper.reset_jmper(tokenhared.token.MATCH)
        Return _ilmethod
    End Function

    Private Sub rev_cline_code(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        If issetdefaultblock Then
            dserr.args.Add("'" & clinecodestruc(0).value & "' cannot follow a 'Default' in the same 'Match' statement.")
            dserr.new_error(conserr.errortype.MATCHERROR, clinecodestruc(0).line, ilbodybulider.path)
        End If
        Select Case clinecodestruc(0).tokenid
            Case tokenhared.token.CASE
                set_condition(clinecodestruc)
                set_case_st(clinecodestruc, _illocalinit, localinit)
                cil.branch_to_target(_ilmethod.codes, endbranchlabel)
                lngen.set_direct_label(nextblocklabel, _ilmethod.codes)
            Case tokenhared.token.DEFAULT
                set_case_st(clinecodestruc, _illocalinit, localinit, True)
                issetdefaultblock = True
            Case Else
                dserr.args.Add("match")
                dserr.args.Add("case")
                dserr.new_error(conserr.errortype.EXPECTSYNTAX, clinecodestruc(0).line, ilbodybulider.path, "Case block not found." & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End Select
    End Sub

    Private Sub set_case_st(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata, Optional isdefaultblock As Boolean = False)
        Dim index As Integer = 2
        If isdefaultblock Then
            syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.DEFAULT)
            index = 1
        Else
            syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.CASE)
        End If
        Dim iltrans As New iltranscore(ilbodybulider.path, clinecodestruc(index).value, _illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        _illocalinit = _ilmethod.locallinit
    End Sub


    Private Sub set_condition(clinecodestruc() As xmlunpkd.linecodestruc)
        Dim getcasedt As String = String.Empty
        servinterface.get_dt_proc(_ilmethod, clinecodestruc(1), getcasedt)
        Dim illdloc As New illdloc(_ilmethod)
        'TODO : check data types and warning
        _ilmethod = illdloc.load_single_in_stack(conddtype, clinecondstruc)
        _ilmethod = illdloc.load_single_in_stack(getcasedt, clinecodestruc(1))
        If getcasedt = conrex.STRING AndAlso conddtype = conrex.STRING Then
            Dim param As New ArrayList
            param.Add(conrex.STRING)
            param.Add(conrex.STRING)
            cil.call_method(_ilmethod.codes, "bool", "mscorlib", "System.String", "op_Equality", param)
        Else
            cil.ceq(_ilmethod.codes)
        End If
        nextblocklabel = lngen.get_line_prop(scount)
        cil.branch_if_false(_ilmethod.codes, nextblocklabel)
        scount += 1
    End Sub

End Class
