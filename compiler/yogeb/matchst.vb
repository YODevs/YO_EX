Public Class matchst
    Private _ilmethod As ilformat._ilmethodcollection
    Private clinecondstruc As xmlunpkd.linecodestruc
    Private counterflag, lastcounterflag, headerbranchlabel, endbranchlabel, bodybranchlabel, increasebranchlabel As String
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_match_st(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        'Check syntax
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.MATCH)
        clinecondstruc = clinecodestruc(2)
        Dim xmldata As xmlunpkd
        xmldata = New xmlunpkd(clinecodestruc(4).value, False)
        While xmldata.xmlreader.EOF = False
            Dim bodyclinecodestruc() As xmlunpkd.linecodestruc
            bodyclinecodestruc = xmldata.get_line_tokens()
            If bodyclinecodestruc.Length = 0 Then Continue While
            rev_cline_code(bodyclinecodestruc, _illocalinit, localinit)
        End While
        MsgBox(1)
        Return _ilmethod
    End Function

    Private Sub rev_cline_code(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        Select Case clinecodestruc(0).tokenid
            Case tokenhared.token.CASE
                set_condition(clinecodestruc)
                Return
                set_case_st(clinecodestruc, _illocalinit, localinit)
            Case Else
                dserr.args.Add("match")
                dserr.args.Add("case")
                dserr.new_error(conserr.errortype.EXPECTSYNTAX, clinecodestruc(0).line, ilbodybulider.path, "Case block not found." & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End Select
    End Sub

    Private Sub set_case_st(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.CASE)
        Dim iltrans As New iltranscore(ilbodybulider.path, clinecodestruc(4).value, _illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        _illocalinit = _ilmethod.locallinit
    End Sub

    Private Sub set_condition(clinecodestruc() As xmlunpkd.linecodestruc)
        Dim illdloc As New illdloc(_ilmethod)
        Select Case clinecodestruc(1).tokenid
            Case tokenhared.token.IDENTIFIER

        End Select
        _ilmethod = illdloc.load_single_in_stack("string", clinecondstruc)
        _ilmethod = illdloc.load_single_in_stack("string", clinecodestruc(1))
        cil.ceq(_ilmethod.codes)
    End Sub
End Class
