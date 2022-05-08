Public Class iltranscore
    Private _illocalinit(0) As ilformat._illocalinit
    Private methoddata As tknformat._method
    Private localinit As localinitdata
    Private path As String
    Private bodyxmlformat As String
    Friend Shared isarrayinstack As Boolean
    Private Shared privobjectcontrol As fmtshared.objectcontrol
    Friend Shared ReadOnly Property methodobjectcontrol() As fmtshared.objectcontrol
        Get
            Return privobjectcontrol
        End Get
    End Property

    Friend Shared Sub set_object_control(objectcontrol As fmtshared.objectcontrol)
        privobjectcontrol = objectcontrol
    End Sub
    Structure identifierassignmentinfo
        Dim identifiers As ArrayList
        Dim optval As String
    End Structure
    Public Sub New(method As tknformat._method)
        methoddata = method
        privobjectcontrol = method.objcontrol
        If privobjectcontrol.modifier = tokenhared.token.UNDEFINED Then
            privobjectcontrol.modifier = tokenhared.token.STATIC
        End If
        localinit = New localinitdata
        localinit.import_parameter(method)
        stjmper.init()
        jmp.init(ilbodybulider.path)
    End Sub

    Public Sub New(path As String, bodyxmlfmt As String, injillocalinit() As ilformat._illocalinit, injlocalinit As localinitdata)
        Me.path = path
        Me.bodyxmlformat = bodyxmlfmt
        localinit = injlocalinit
        _illocalinit = injillocalinit
    End Sub

    Private Sub gen_per_condition(ByRef _ilmethod As ilformat._ilmethodcollection)
        If methoddata.condxmlfmt = Nothing Then Return
        Dim condxmldata As New xmlunpkd(methoddata.condxmlfmt)
        condxmldata.path = path
        coutputdata.write_data(methoddata.condxmlfmt)
        Dim nbranch As New condproc.branchtargetinfo
        nbranch.truebranch = lngen.get_line_prop("per_ret_tr")
        nbranch.falsebranch = lngen.get_line_prop("per_ret_fa")
        While condxmldata.xmlreader.EOF = False
            Dim clinecodestruc() As xmlunpkd.linecodestruc
            clinecodestruc = condxmldata.get_line_tokens()
            clinecodestruc = condproc.get_condition(clinecodestruc, 0)
            Dim cdproc As New condproc(nbranch)
            cdproc.set_condition(_ilmethod, clinecodestruc)
        End While
        lngen.set_direct_label(nbranch.falsebranch, _ilmethod.codes)
        If methoddata.returntype <> Nothing AndAlso methoddata.returntype <> "void" Then
            cil.push_null_reference(_ilmethod.codes)
        End If
        cil.ret(_ilmethod.codes)
        lngen.set_direct_label(nbranch.truebranch, _ilmethod.codes)

        condxmldata.close()
    End Sub
    Public Sub gen_transpile_code(ByRef _ilmethod As ilformat._ilmethodcollection, Optional invokebymainproc As Boolean = True)
        Dim xmldata As xmlunpkd
        If invokebymainproc Then
            _ilmethod.codes = New ArrayList
            _ilmethod.line = New ArrayList
            xmldata = New xmlunpkd(methoddata.bodyxmlfmt)
            path = xmldata.path
            If methoddata.condxmlfmt <> Nothing Then
                gen_per_condition(_ilmethod)
            End If
        Else
                xmldata = New xmlunpkd(bodyxmlformat, False)
        End If
        stjmper.reset_method(path)
        While xmldata.xmlreader.EOF = False
            Dim clinecodestruc() As xmlunpkd.linecodestruc
            clinecodestruc = xmldata.get_line_tokens()
            rev_cline_code(clinecodestruc, _ilmethod)
        End While
        If ifcond.incond = True Then
            Dim cond As New ifcond(_ilmethod)
            _ilmethod = cond.set_condition_statement(_illocalinit, localinit)
        End If
        If (_illocalinit.Length > 0 AndAlso _illocalinit(_illocalinit.Length - 1).name = Nothing) Then
            Array.Resize(_illocalinit, _illocalinit.Length - 1)
        End If
        _ilmethod.locallinit = _illocalinit 'exc no local init
        xmldata.close()
    End Sub

    Private Sub rev_cline_code(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        If clinecodestruc.Length = 0 Then Return
        ' coutputdata.print_token(clinecodestruc)
        If ifcond.incond = True AndAlso ifcond.check_cond_statement(clinecodestruc(0)) = False Then
            Dim cond As New ifcond(_ilmethod)
            _ilmethod = cond.set_condition_statement(_illocalinit, localinit)
        End If
        Select Case clinecodestruc(0).tokenid
            Case tokenhared.token.IDENTIFIER
                nv_st_identifier(clinecodestruc, _ilmethod)
            Case tokenhared.token.ARR
                nv_st_identifier(clinecodestruc, _ilmethod, True)
            Case tokenhared.token.LET
                Dim assignprocess As Boolean = False
                nv_let(_ilmethod, clinecodestruc, assignprocess)
                _ilmethod.locallinit = _illocalinit 'exc no local init
                If arr.setloc Then
                    _illocalinit(_illocalinit.Length - 1).typeinf.isarray = True
                    arr.set_loc(_ilmethod, _illocalinit(_illocalinit.Length - 1), clinecodestruc(1))
                End If
                If assignprocess Then
                    assignmentcommondatatype.varnamecodestruc = clinecodestruc(1)
                    assignmentcommondatatype.set_value(_ilmethod, _illocalinit.Length - 1, False)
                End If
            Case tokenhared.token.CONST
                Dim assignprocess As Boolean = False
                nv_let(_ilmethod, clinecodestruc, assignprocess, True)
                _ilmethod.locallinit = _illocalinit 'exc no local init
                If assignprocess Then
                    assignmentcommondatatype.set_value(_ilmethod, _illocalinit.Length - 1, False)
                Else
                    dserr.new_error(conserr.errortype.CONSTANTVALERROR, clinecodestruc(0).line, path, Nothing, "const name : str = ""RUZES""")
                End If
            Case tokenhared.token.CIL_BLOCK
                nv_cil_commands(clinecodestruc, _ilmethod)
            Case tokenhared.token.IF
                ifcond.imp_cond_statement(clinecodestruc)
            Case tokenhared.token.ELSEIF
                ifcond.imp_cond_statement(clinecodestruc)
            Case tokenhared.token.ELSE
                ifcond.imp_cond_statement(clinecodestruc)
            Case tokenhared.token.UL
                Dim cond As New ulcond(_ilmethod)
                _ilmethod = cond.set_ul_statement(clinecodestruc, _illocalinit, localinit)
            Case tokenhared.token.FOR
                Dim forlp As New forloop(_ilmethod)
                _ilmethod = forlp.set_for_st(clinecodestruc, _illocalinit, localinit)
            Case tokenhared.token.TO
                Dim toit As New toiter(_ilmethod)
                _ilmethod = toit.set_to_iter(clinecodestruc, _illocalinit, localinit)
            Case tokenhared.token.MATCH
                Dim matchclass As New matchst(_ilmethod)
                _ilmethod = matchclass.set_match_st(clinecodestruc, _illocalinit, localinit)
            Case tokenhared.token.WHILE
                Dim whileclass As New whilest(_ilmethod)
                _ilmethod = whileclass.set_while_st(clinecodestruc, _illocalinit, localinit)
            Case tokenhared.token.LOOP
                Dim infinityloop As New infloop(_ilmethod)
                _ilmethod = infinityloop.set_infinity_loop(clinecodestruc, _illocalinit, localinit)
            Case tokenhared.token.TRY
                Dim trysys As New exceptioninner(_ilmethod)
                _ilmethod = trysys.set_try_block(clinecodestruc, _illocalinit, localinit)
            Case tokenhared.token.CATCH
                Dim trysys As New exceptioninner(_ilmethod)
                _ilmethod = trysys.set_catch_block(clinecodestruc, _illocalinit, localinit)
            Case tokenhared.token.ERR
                Dim trysys As New exceptioninner(_ilmethod)
                _ilmethod = trysys.set_err(clinecodestruc)
            Case tokenhared.token.RETURN
                ilret.ret_to_route(_ilmethod, clinecodestruc)
            Case tokenhared.token.LABELJMP
                jmp.set_label(clinecodestruc, _ilmethod)
            Case tokenhared.token.JMP
                jmp.jmp_statement(clinecodestruc, _ilmethod)
            Case tokenhared.token.CONTINUE
                stjmper.continue_jmper(clinecodestruc, _ilmethod)
            Case tokenhared.token.BREAK
                stjmper.break_jmper(clinecodestruc, _ilmethod)
            Case tokenhared.token.REPEAT
                stjmper.repeat_jmper(clinecodestruc, _ilmethod)
            Case Else
                If clinecodestruc(0).tokenid = tokenhared.token.EXPRESSION AndAlso _ilmethod.isexpr Then
                    nv_expr_method(clinecodestruc, _ilmethod)
                Else
                    dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(0).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
                End If
        End Select
    End Sub

    Private Sub nv_expr_method(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim yodatatype As String = String.Empty
        If illdloc.check_integer_type(_ilmethod.returntype) = _ilmethod.returntype Then
            servinterface.get_yo_common_data_type(_ilmethod.returntype, yodatatype)
        ElseIf illdloc.check_float_type(_ilmethod.returntype) = _ilmethod.returntype Then
            servinterface.get_yo_common_data_type(_ilmethod.returntype, yodatatype)
        Else
            dserr.args.Add(_ilmethod.returntype & " - This data type is not allowed for the expr function ['" & _ilmethod.name & "']")
            dserr.new_error(conserr.errortype.EXPRESSIONERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End If
        Dim convtoi8 As Boolean = servinterface.is_i8(_ilmethod.returntype)

        Dim expr As New expressiondt(_ilmethod, yodatatype)
        Try
            _ilmethod = expr.parse_expression_data(clinecodestruc(0).value, convtoi8)
        Catch ex As Exception
            dserr.args.Add(ex.Message)
            dserr.new_error(conserr.errortype.EXPRESSIONERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End Try
    End Sub
    Private Sub nv_cil_commands(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        If ilasmgen.classdata.attribute._cfg._cilinject = False Then
            dserr.args.Add("CIL Injection Code")
            dserr.args.Add("#[cfg::CIL(true)]")
            dserr.new_error(conserr.errortype.ATTRIBUTEDISABLED, clinecodestruc(0).line, path, Nothing, "#[cfg::CIL(true)]")
            Return
        End If
        If clinecodestruc.Length = 1 Then
            Dim ilcode As String = clinecodestruc(0).value
            authfunc.rem_fr_and_en(ilcode)
            If ilcode.Trim <> String.Empty Then
                For Each illinecode In ilcode.Split(vbLf)
                    illinecode = illinecode.Trim
                    If illinecode <> Nothing Then
                        Dim retresult As cillazychecker.resultlazycheck = cillazychecker.lazy_check(illinecode)
                        If retresult.result Then
                            _ilmethod.codes.Add(illinecode)
                        Else
                            dserr.new_error(conserr.errortype.CILLAZYERROR, clinecodestruc(0).line, path, retresult.errtext)
                        End If
                    End If
                Next
            End If
        Else
            dserr.new_error(conserr.errortype.CILCOMMANDSAUTH, clinecodestruc(0).line, path, Nothing)
        End If
    End Sub
    Private Sub nv_st_identifier(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, Optional isarray As Boolean = False)
        'Print Tokens by xmlunpkd.linecodestruc
        'coutputdata.print_token(clinecodestruc)
        isarrayinstack = isarray
        Dim inline As Integer = 0
        Dim index As Integer = clinecodestruc.Length - 1
        Dim funcresult As funcvalid._resultfuncvaild = funcvalid.get_func_valid(_ilmethod, clinecodestruc)
        'coutputdata.print_token(clinecodestruc)
        If funcresult.funcvalid Then
            funcste.invoke_method(clinecodestruc, _ilmethod, funcresult)
            isarrayinstack = False
            Return
        End If
        Dim propresult As identvalid._resultidentcvaild = identvalid.get_identifier_valid(_ilmethod, clinecodestruc(0))
        If clinecodestruc.Length < 3 Then
            dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), clinecodestruc(index).value))
            Return
        End If
        Dim dtassign As identifierassignmentinfo = get_iden_names(clinecodestruc, inline)
        convtc.is_type_casting(clinecodestruc, inline)
        If propresult.identvalid Then
            propertyste.invoke_property(clinecodestruc, _ilmethod, propresult, inline, tokenhared.check_sym(dtassign.optval))
            isarrayinstack = False
            Return
        End If
        illdloc.frvarstruc = clinecodestruc(0)
        Select Case tokenhared.check_sym(dtassign.optval)
            Case tokenhared.token.ASSIDB
                pv_iden_assidb(dtassign, clinecodestruc, inline, _ilmethod)
            Case tokenhared.token.ANDEQ
                pv_iden_andeq(dtassign, clinecodestruc, inline, _ilmethod)
            Case tokenhared.token.APPEQ
                pv_iden_appeq(dtassign, clinecodestruc, inline, _ilmethod)
            Case tokenhared.token.QESEQ
                pv_iden_qeseq(dtassign, clinecodestruc, inline, _ilmethod)
            Case tokenhared.token.PLUSEQ
                pv_iden_add(dtassign, clinecodestruc, inline, _ilmethod)
            Case tokenhared.token.MINUSEQ
                pv_iden_sub(dtassign, clinecodestruc, inline, _ilmethod)
            Case tokenhared.token.ASTERISKEQ
                pv_iden_mul(dtassign, clinecodestruc, inline, _ilmethod)
            Case tokenhared.token.SLASHEQ
                pv_iden_div(dtassign, clinecodestruc, inline, _ilmethod)
            Case tokenhared.token.REMEQ
                pv_iden_rem(dtassign, clinecodestruc, inline, _ilmethod)
            Case tokenhared.token.POWEQ
                pv_iden_pow(dtassign, clinecodestruc, inline, _ilmethod)
            Case Else
                dserr.args.Add(dtassign.optval)
                dserr.new_error(conserr.errortype.OPERATORUNKNOWN, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(1)), dtassign.optval))
        End Select
        isarrayinstack = False
    End Sub

    Private Sub pv_iden_div(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = var.check_identifier_validation(_ilmethod, clinecodestruc, ilinc, varname, localinit, path)

            Select Case localvartype.result
                Case illdloc.check_yo_integer_type(localvartype.result)
                    _ilmethod = optgen.assidiv(varname, clinecodestruc(ilinc), localvartype.result)
                Case illdloc.check_yo_float_type(localvartype.result)
                    _ilmethod = optgen.assidiv(varname, clinecodestruc(ilinc), localvartype.result, True)
                Case Else
                    dserr.args.Add(varname & " -> " & localvartype.result)
                    dserr.args.Add("i64/i32/i16/i8/...")
                    dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), varname))
            End Select
        Next
    End Sub

    Private Sub pv_iden_mul(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = var.check_identifier_validation(_ilmethod, clinecodestruc, ilinc, varname, localinit, path)

            Select Case localvartype.result
                Case illdloc.check_yo_integer_type(localvartype.result)
                    _ilmethod = optgen.assimul(varname, clinecodestruc(ilinc), localvartype.result)
                Case illdloc.check_yo_float_type(localvartype.result)
                    _ilmethod = optgen.assimul(varname, clinecodestruc(ilinc), localvartype.result, True)
                Case Else
                    dserr.args.Add(varname & " -> " & localvartype.result)
                    dserr.args.Add("i64/i32/i16/i8/...")
                    dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), varname))
            End Select
        Next
    End Sub

    Private Sub pv_iden_sub(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = var.check_identifier_validation(_ilmethod, clinecodestruc, ilinc, varname, localinit, path)

            Select Case localvartype.result
                Case illdloc.check_yo_integer_type(localvartype.result)
                    _ilmethod = optgen.assisub(varname, clinecodestruc(ilinc), localvartype.result)
                Case illdloc.check_yo_float_type(localvartype.result)
                    _ilmethod = optgen.assisub(varname, clinecodestruc(ilinc), localvartype.result, True)
                Case Else
                    dserr.args.Add(varname & " -> " & localvartype.result)
                    dserr.args.Add("i64/i32/i16/i8/...")
                    dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), varname))
            End Select
        Next
    End Sub

    Private Sub pv_iden_add(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = var.check_identifier_validation(_ilmethod, clinecodestruc, ilinc, varname, localinit, path)

            Select Case localvartype.result
                Case illdloc.check_yo_integer_type(localvartype.result)
                    _ilmethod = optgen.assiadd(varname, clinecodestruc(ilinc), localvartype.result)
                Case illdloc.check_yo_float_type(localvartype.result)
                    _ilmethod = optgen.assiadd(varname, clinecodestruc(ilinc), localvartype.result, True)
                Case Else
                    dserr.args.Add(varname & " -> " & localvartype.result)
                    dserr.args.Add("i64/i32/i16/i8/...")
                    dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), varname))
            End Select
        Next
    End Sub

    Private Sub pv_iden_pow(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = var.check_identifier_validation(_ilmethod, clinecodestruc, ilinc, varname, localinit, path)

            Select Case localvartype.result
                Case illdloc.check_yo_integer_type(localvartype.result)
                    _ilmethod = optgen.assipow(varname, clinecodestruc(ilinc), localvartype.result)
                Case illdloc.check_yo_float_type(localvartype.result)
                    _ilmethod = optgen.assipow(varname, clinecodestruc(ilinc), localvartype.result, True)
                Case Else
                    dserr.args.Add(varname & " -> " & localvartype.result)
                    dserr.args.Add("i64/i32/i16/i8/...")
                    dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), varname))
            End Select
        Next
    End Sub

    Private Sub pv_iden_rem(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = var.check_identifier_validation(_ilmethod, clinecodestruc, ilinc, varname, localinit, path)

            Select Case localvartype.result
                Case illdloc.check_yo_integer_type(localvartype.result)
                    _ilmethod = optgen.assirem(varname, clinecodestruc(ilinc), localvartype.result)
                Case illdloc.check_yo_float_type(localvartype.result)
                    _ilmethod = optgen.assirem(varname, clinecodestruc(ilinc), localvartype.result, True)
                Case Else
                    dserr.args.Add(varname & " -> " & localvartype.result)
                    dserr.args.Add("i64/i32/i16/i8/...")
                    dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), varname))
            End Select
        Next
    End Sub
    Private Sub pv_iden_andeq(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = var.check_identifier_validation(_ilmethod, clinecodestruc, ilinc, varname, localinit, path)

            Select Case localvartype.result
                Case "str"
                    _ilmethod = optgen.assiandeq(varname, clinecodestruc(ilinc))
                Case Else
                    dserr.args.Add(varname & " -> " & localvartype.result)
                    dserr.args.Add("str")
                    dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), varname))
            End Select
        Next
    End Sub

    Private Sub pv_iden_appeq(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = var.check_identifier_validation(_ilmethod, clinecodestruc, ilinc, varname, localinit, path)

            Select Case localvartype.result
                Case "str"
                    _ilmethod = optgen.assiappeq(varname, clinecodestruc(ilinc))
                Case Else
                    dserr.args.Add(varname & " -> " & localvartype.result)
                    dserr.args.Add("str")
                    dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), varname))
            End Select
        Next
    End Sub
    Private Sub pv_iden_assidb(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = var.check_identifier_validation(_ilmethod, clinecodestruc, ilinc, varname, localinit, path)

            Select Case localvartype.result
                Case "str"
                    _ilmethod = optgen.assi_str(varname, clinecodestruc(ilinc))
                Case "obj"
                    _ilmethod = optgen.assi_obj(varname, clinecodestruc(ilinc))
                Case "i128"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "valuetype [mscorlib]System.Decimal")
                Case "i64"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "int64")
                Case "i32"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "int32")
                Case "i16"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "int16")
                Case "i8"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "int8")
                Case "u64"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "uint64")
                Case "u32"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "uint32")
                Case "u16"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "uint16")
                Case "u8"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "uint8")
                Case "f32"
                    _ilmethod = optgen.assi_float(varname, clinecodestruc(ilinc), "float32")
                Case "f64"
                    _ilmethod = optgen.assi_float(varname, clinecodestruc(ilinc), "float64")
                Case "bool"
                    _ilmethod = optgen.assi_bool(varname, clinecodestruc(ilinc), "bool")
                Case "char"
                    _ilmethod = optgen.assi_char(varname, clinecodestruc(ilinc), "char")
                Case Else
                    If clinecodestruc(ilinc).tokenid = tokenhared.token.INIT Then
                        check_constructor_assignment(clinecodestruc, ilinc, optgen)
                    End If
                    _ilmethod = optgen.assi_identifier(varname, clinecodestruc(ilinc), localvartype.result)
            End Select
        Next
    End Sub

    Private Sub check_constructor_assignment(clinecodestruc() As xmlunpkd.linecodestruc, ilinc As Integer, ByRef optgen As ilopt)
        If clinecodestruc.Length <= ilinc + 1 Then
            dserr.new_error(conserr.errortype.TYPEEXPECTEDERROR, clinecodestruc(ilinc).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(ilinc)), clinecodestruc(ilinc).value) & vbCrLf & "Type must be specified after the INIT keyword.", "sb := init system.text.stringbuilder()")
        End If
        Dim ctorlinecodestruc() As xmlunpkd.linecodestruc = servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc + 1)
        optgen.ctorlinecodestruc = ctorlinecodestruc
    End Sub
    Private Sub pv_iden_qeseq(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = var.check_identifier_validation(_ilmethod, clinecodestruc, ilinc, varname, localinit, path, False)
            _ilmethod = optgen.assiqes(varname, clinecodestruc(ilinc), localvartype.result)
        Next
    End Sub
    Friend Shared Function check_opt_assignment(clinecodestruc() As xmlunpkd.linecodestruc, index As Integer, ByRef opt As String) As Boolean
        If clinecodestruc(index).tokenid = tokenhared.token.CMA Then Return False

        If clinecodestruc.Length > index + 1 Then
            For indloop = 0 To tokenhared.tokenassign.Length - 1
                Dim optval As String = String.Empty
                optval = clinecodestruc(index).value
                If tokenhared.tokenassign(indloop) = optval Then
                    If clinecodestruc(index + 1).tokenid = tokenhared.token.EQUALS Then
                        opt = optval & "="
                        Return True
                    Else
                        'Set Error '=' not found.
                    End If
                End If
            Next
        Else
            'Set Error 
        End If
        Return False
    End Function
    Public Function get_iden_names(clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer) As identifierassignmentinfo
        Dim waitforcma As Boolean = False
        Dim resultassign As New identifierassignmentinfo
        Dim dtnames As New ArrayList
        Dim optval As String = String.Empty
        For index = 0 To clinecodestruc.Length - 1
            If waitforcma = False Then
                If clinecodestruc(index).tokenid <> tokenhared.token.IDENTIFIER AndAlso clinecodestruc(index).tokenid <> tokenhared.token.ARR Then
                    'IDENTIFIER EXPECTED
                    dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), clinecodestruc(index).value), "let name : str = ""Amin""")
                End If

                dtnames.Add(clinecodestruc(index).value)
                waitforcma = True
            Else
                'Check operators
                If check_opt_assignment(clinecodestruc, index, optval) Then
                    ilinc = index + 2
                    resultassign.identifiers = dtnames
                    resultassign.optval = optval
                    Return resultassign
                ElseIf clinecodestruc(index).tokenid = tokenhared.token.CMA Then
                    waitforcma = False
                End If
            End If
        Next

        'Check ":" in let statements.
        dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(clinecodestruc.Length - 1).line, path, "':' is expected." & vbCrLf & authfunc.get_line_error(path, get_target_info(clinecodestruc(clinecodestruc.Length - 1)), clinecodestruc(clinecodestruc.Length - 1).value), "let name : str = ""Amin""")

        Return resultassign
    End Function
    Private Sub nv_let(ByRef ilmethod As ilformat._ilmethodcollection, clinecodestruc() As xmlunpkd.linecodestruc, ByRef assignprocess As Boolean, Optional isconst As Boolean = False)
        Dim ilmethodlen As Integer = _illocalinit.Length
        Dim index As Integer = ilmethodlen
        Dim ilinc As Integer = 2
        Dim multideclare As Boolean = False
        Dim mulitdclarelistinf As ArrayList
        If ilmethodlen = 0 Then index = 0
        If clinecodestruc.Length < 3 Then
            dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(2).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(2)), clinecodestruc(2).value), "let name : str = ""Amin""")
            Return
        End If
        Dim singleidentifiername As String = servinterface.get_array_name(clinecodestruc(1).value)
        Array.Resize(_illocalinit, ilmethodlen + 1)
        If clinecodestruc(1).tokenid <> tokenhared.token.IDENTIFIER AndAlso clinecodestruc(1).tokenid <> tokenhared.token.ARR Then
            'IDENTIFIER EXPECTED
            dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, clinecodestruc(1).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(1)), clinecodestruc(1).value), "let name : str = ""Amin""")

            'TODO : Check Global Types.
        ElseIf localinit.check_local_init(singleidentifiername) Then
            'DECLARING ERROR
            dserr.new_error(conserr.errortype.DECLARINGERROR, clinecodestruc(1).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(1)), clinecodestruc(1).value) & vbCrLf & "Choose another name.")
        End If

        'Multi Declare types
        If clinecodestruc(2).tokenid = tokenhared.token.CMA Then
            mulitdclarelistinf = get_dt_names(clinecodestruc, ilinc)
            multideclare = True
        End If

        'Check ":" in let statements.
        If clinecodestruc(ilinc).tokenid <> tokenhared.token.ASSINQ Then
            dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(ilinc).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(ilinc)), clinecodestruc(ilinc).value), "let name : str = ""Amin""")
        End If

        ilinc += 1
        If multideclare Then
#Region "Multi Declaring"
            Array.Resize(_illocalinit, _illocalinit.Length + mulitdclarelistinf.Count - 1)
            For iname = 0 To mulitdclarelistinf.Count - 1
                If localinit.check_local_init(mulitdclarelistinf(iname)) Then
                    'DECLARING ERROR
                    dserr.new_error(conserr.errortype.DECLARINGERROR, clinecodestruc(ilinc).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(ilinc)), mulitdclarelistinf(iname)) & vbCrLf & "Choose another name.")
                End If
                If clinecodestruc(ilinc).tokenid = tokenhared.token.COMMONDATATYPE Then
                    _illocalinit(index).name = mulitdclarelistinf(iname)
                    _illocalinit(index).datatype = initcommondatatype.cdtype.find(clinecodestruc(ilinc).value).result
                    _illocalinit(index).iscommondatatype = True
                    _illocalinit(index).isconstant = isconst
                Else
                    'Check other type ...
                    _illocalinit(index).iscommondatatype = False
                End If
                _illocalinit(index).hasdefaultvalue = False
                localinit.add_local_init(mulitdclarelistinf(iname), clinecodestruc(ilinc).value)
                index += 1
            Next
            If clinecodestruc.Length <> ilinc + 1 Then
                ilinc += 1
                dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(ilinc).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(ilinc)), clinecodestruc(ilinc).value), "let name , city , description : str")
            End If
            Return
#End Region
        Else
#Region "Single Declaring"
            _illocalinit(index).name = clinecodestruc(1).value
            arr.check_array_struct(_illocalinit(index).name, _illocalinit(index).arrayinf, _illocalinit(index).isarrayobj)
            If clinecodestruc(ilinc).tokenid = tokenhared.token.COMMONDATATYPE Then
                _illocalinit(index).datatype = initcommondatatype.cdtype.find(clinecodestruc(3).value).result
                _illocalinit(index).iscommondatatype = True
                _illocalinit(index).isconstant = isconst
                _illocalinit(index).ctor = False
                _illocalinit(index).isvaluetypes = False
                localinit.add_local_init(_illocalinit(index).name, _illocalinit(index).datatype)
                _illocalinit(index).typeinf = yotypecreator.get_type_info(ilmethod, clinecodestruc, 3, _illocalinit(index).datatype)
                If IsNothing(_illocalinit(index).arrayinf) = False AndAlso _illocalinit(index).arrayinf.isarrayref = True Then
                    _illocalinit(index).typeinf.isarray = True
                    _illocalinit(index).isarrayobj = True
                End If
                If _illocalinit(index).isarrayobj Then arr.set_new_arr(ilmethod, _illocalinit(index), clinecodestruc(0))
            Else
                'Check other type ...
                _illocalinit(index).iscommondatatype = False
                If clinecodestruc(3).tokenid = tokenhared.token.INIT Then
                    If clinecodestruc.Length > 4 Then
                        If libserv.get_extern_index_class(ilmethod, clinecodestruc(4).value, Nothing, Nothing, Nothing, Nothing) = -1 AndAlso funcdtproc.get_index_class(ilmethod, clinecodestruc(4).value) = -1 Then
                            If valtp.check_value_type(ilmethod, _illocalinit(index).typeinf, clinecodestruc(4).value) Then
                                _illocalinit(index).isvaluetypes = True
                                _illocalinit(index).datatype = _illocalinit(index).typeinf.fullname
                                clinecodestruc(4).value = _illocalinit(index).datatype
                            Else
                                dserr.args.Add("Class '" & clinecodestruc(4).value & "' not found.")
                                dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(4)), clinecodestruc(4).value))
                            End If
                        End If
                        _illocalinit(index).datatype = clinecodestruc(4).value
                        _illocalinit(index).ctor = True
                    Else
                        dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(ilinc).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(ilinc)), clinecodestruc(ilinc).value))
                    End If
                Else
                    _illocalinit(index).ctor = False
                    If libserv.get_extern_index_class(ilmethod, clinecodestruc(3).value, Nothing, Nothing, Nothing, Nothing) = -1 AndAlso funcdtproc.get_index_class(ilmethod, clinecodestruc(3).value) = -1 Then
                        If valtp.check_value_type(ilmethod, _illocalinit(index).typeinf, clinecodestruc(3).value) Then
                            _illocalinit(index).isvaluetypes = True
                            _illocalinit(index).datatype = _illocalinit(index).typeinf.fullname
                            clinecodestruc(3).value = _illocalinit(index).datatype
                        Else
                            dserr.args.Add("Class '" & clinecodestruc(3).value & "' not found.")
                            dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(3)), clinecodestruc(3).value))
                        End If
                    End If

                    _illocalinit(index).datatype = clinecodestruc(3).value
                    If clinecodestruc.Length > 4 Then
                        If clinecodestruc(4).tokenid <> tokenhared.token.EQUALS Then
                            'DECLARING ERROR
                            dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(4).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(4)), clinecodestruc(4).value), "let name : str = ""Amin""")
                        End If

                        If clinecodestruc.Length >= 5 Then
                            Dim crenvalue(clinecodestruc.Length - 6) As xmlunpkd.linecodestruc
                            Dim icren As Integer = 0
                            For clindex = 5 To clinecodestruc.Length - 1
                                crenvalue(icren) = New xmlunpkd.linecodestruc
                                crenvalue(icren) = clinecodestruc(clindex)
                                icren += 1
                            Next
                            _illocalinit(index).clocalvalue = crenvalue
                            _illocalinit(index).hasdefaultvalue = True
                            assignprocess = True
                        Else
                            'let name : str =
                            dserr.new_error(conserr.errortype.DECLARINGERROR, clinecodestruc(4).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(4)), clinecodestruc(4).value) & vbCrLf & "The initial value is expected")
                        End If
                    Else
                        If compdt.NULLSAFETYMODE Then
                            dserr.args.Add(_illocalinit(index).name)
                            dserr.new_error(conserr.errortype.NULLSAFETYMODEINIT, clinecodestruc(1).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(1)), clinecodestruc(1).value), "let ls : init yolib.list()" & vbCrLf & "let sb : init system.text.stringbuilder()")
                        End If
                    End If
                End If
                If _illocalinit(index).isvaluetypes = False Then
                    Dim ctor As New ilctor(ilmethod)
                    ilmethod = ctor.set_new_ctor(index, clinecodestruc, _illocalinit, localinit)
                    localinit.add_local_init(_illocalinit(index).name, _illocalinit(index).datatype)
                    Dim indclass As Integer = 3
                    If _illocalinit(index).ctor Then
                        indclass = 4
                    End If
                    _illocalinit(index).typeinf = yotypecreator.get_type_info(ilmethod, clinecodestruc, indclass, _illocalinit(index).datatype)
                    If _illocalinit(index).isarrayobj Then arr.set_new_arr(ilmethod, _illocalinit(index), clinecodestruc(0))
                Else
                    localinit.add_local_init(_illocalinit(index).name, _illocalinit(index).datatype)
                End If
                If IsNothing(_illocalinit(index).arrayinf) = False AndAlso _illocalinit(index).arrayinf.isarrayref = True Then
                    _illocalinit(index).typeinf.isarray = True
                End If
                Return
            End If
            _illocalinit(index).hasdefaultvalue = False
            If clinecodestruc.Length > 4 Then
                If clinecodestruc(4).tokenid <> tokenhared.token.EQUALS Then
                    'DECLARING ERROR
                    dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(4).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(4)), clinecodestruc(4).value), "let name : str = ""Amin""")
                End If

                If clinecodestruc.Length > 4 Then
                    Dim crenvalue(clinecodestruc.Length - 6) As xmlunpkd.linecodestruc
                    Dim icren As Integer = 0
                    For clindex = 5 To clinecodestruc.Length - 1
                        crenvalue(icren) = New xmlunpkd.linecodestruc
                        crenvalue(icren) = clinecodestruc(clindex)
                        icren += 1
                    Next
                    _illocalinit(index).clocalvalue = crenvalue
                    _illocalinit(index).hasdefaultvalue = True
                    If IsNothing(_illocalinit(index).arrayinf) = False AndAlso _illocalinit(index).arrayinf.isarrayref = True Then
                        illdloc.frvarstruc = clinecodestruc(1)
                    End If
                    assignprocess = True
                Else
                    'let name : str =
                    dserr.new_error(conserr.errortype.DECLARINGERROR, clinecodestruc(4).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(4)), clinecodestruc(4).value) & vbCrLf & "The initial value is expected.")
                End If
            End If
            'TODO : Check init value .
            If _illocalinit(index).hasdefaultvalue = False AndAlso compdt.NULLSAFETYMODE Then
                Dim examplecode As String = "let s : str = 'James'" & vbCrLf & "let i : i32 = 0" & vbCrLf & "let f : f32 = 3.2436"
                If (_illocalinit(index).isarrayobj) Then
                    examplecode = "let s[] : str = {'James','John','Tom'}" & vbCrLf & "let i[] : i32 = {5,6,7,8,9,10}"
                End If
                dserr.args.Add(_illocalinit(index).name)
                dserr.new_error(conserr.errortype.NULLSAFETYMODEINIT, clinecodestruc(1).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(1)), clinecodestruc(1).value) & vbCrLf & "The initial value is expected.", examplecode)
            End If
            localinit.add_local_init(_illocalinit(index).name, clinecodestruc(3).value)
#End Region

        End If
    End Sub

    Public Function get_target_info(clinecodestruc As xmlunpkd.linecodestruc) As lexer.targetinf
        Dim linecinf As New lexer.targetinf
        linecinf.lstart = clinecodestruc.ist
        linecinf.line = clinecodestruc.line
        linecinf.length = clinecodestruc.ile
        linecinf.lend = clinecodestruc.ien
        Return linecinf
    End Function

    Public Function get_dt_names(clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer) As ArrayList
        Dim waitforcma As Boolean = False
        Dim dtnames As New ArrayList
        For index = 1 To clinecodestruc.Length - 1
            If waitforcma = False Then
                If clinecodestruc(index).tokenid <> tokenhared.token.IDENTIFIER Then
                    'IDENTIFIER EXPECTED
                    dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), clinecodestruc(index).value), "let name : str = ""Amin""")
                End If

                dtnames.Add(clinecodestruc(index).value)
                waitforcma = True
            Else
                'Check ":" in let statements.
                If clinecodestruc(index).tokenid = tokenhared.token.ASSINQ Then
                    ilinc = index
                    Return dtnames
                ElseIf clinecodestruc(index).tokenid = tokenhared.token.CMA Then
                    waitforcma = False
                Else
                    dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(index).line, path, "',' is expected." & vbCrLf & authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), clinecodestruc(index).value), "let name , city : str ")
                End If
            End If
        Next

        'Check ":" in let statements.
        dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(clinecodestruc.Length - 1).line, path, "':' is expected." & vbCrLf & authfunc.get_line_error(path, get_target_info(clinecodestruc(clinecodestruc.Length - 1)), clinecodestruc(clinecodestruc.Length - 1).value), "let name : str = ""Amin""")
        Return dtnames
    End Function
End Class
