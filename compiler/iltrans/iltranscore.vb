Public Class iltranscore
    Private _illocalinit(0) As ilformat._illocalinit
    Private methoddata As tknformat._method
    Private localinit As localinitdata
    Private jmp As jmp
    Private path As String
    Private bodyxmlformat As String
    Structure identifierassignmentinfo
        Dim identifiers As ArrayList
        Dim optval As String
    End Structure
    Public Sub New(method As tknformat._method)
        methoddata = method
        localinit = New localinitdata
        localinit.import_parameter(method)
        stjmper.init()
    End Sub

    Public Sub New(path As String, bodyxmlfmt As String, injillocalinit() As ilformat._illocalinit, injlocalinit As localinitdata)
        Me.path = path
        Me.bodyxmlformat = bodyxmlfmt
        localinit = injlocalinit
        _illocalinit = injillocalinit
    End Sub

    Public Sub gen_transpile_code(ByRef _ilmethod As ilformat._ilmethodcollection, Optional invokebymainproc As Boolean = True)
        Dim xmldata As xmlunpkd
        If invokebymainproc Then
            _ilmethod.codes = New ArrayList
            _ilmethod.line = New ArrayList
            xmldata = New xmlunpkd(methoddata.bodyxmlfmt)
            path = xmldata.path
        Else
            xmldata = New xmlunpkd(bodyxmlformat, False)
        End If
        jmp = New jmp(path)
        stjmper.reset_method(path)
        While xmldata.xmlreader.EOF = False
            Dim clinecodestruc() As xmlunpkd.linecodestruc
            clinecodestruc = xmldata.get_line_tokens()
            rev_cline_code(clinecodestruc, _ilmethod)
        End While
        If (_illocalinit.Length > 0 AndAlso _illocalinit(_illocalinit.Length - 1).name = Nothing) Then
            Array.Resize(_illocalinit, _illocalinit.Length - 1)
        End If
        _ilmethod.locallinit = _illocalinit 'exc no local init
        xmldata.close()
    End Sub

    Private Sub rev_cline_code(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        If clinecodestruc.Length = 0 Then Return

        Select Case clinecodestruc(0).tokenid
            Case tokenhared.token.IDENTIFIER
                nv_st_identifier(clinecodestruc, _ilmethod)
            Case tokenhared.token.LET
                Dim assignprocess As Boolean = False
                nv_let(clinecodestruc, assignprocess)
                _ilmethod.locallinit = _illocalinit 'exc no local init
                If assignprocess Then
                    assignmentcommondatatype.set_value(_ilmethod, _illocalinit.Length - 1, False)
                End If
            Case tokenhared.token.CIL_BLOCK
                nv_cil_commands(clinecodestruc, _ilmethod)
            Case tokenhared.token.TO
                Dim toit As New toiter(_ilmethod)
                _ilmethod = toit.set_to_iter(clinecodestruc, _illocalinit, localinit)
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
    Private Sub nv_st_identifier(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        'Print Tokens by xmlunpkd.linecodestruc
        '  coutputdata.print_token(clinecodestruc)
        Dim inline As Integer = 0
        Dim index As Integer = clinecodestruc.Length - 1
        Dim funcresult As funcvalid._resultfuncvaild = funcvalid.get_func_valid(clinecodestruc)
        If funcresult.funcvalid Then
            funcste.invoke_method(clinecodestruc, _ilmethod, funcresult)
            Return
        End If
        If clinecodestruc.Length < 3 Then
            dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), clinecodestruc(index).value))
            Return
        End If

        Dim dtassign As identifierassignmentinfo = get_iden_names(clinecodestruc, inline)

        Select Case tokenhared.check_sym(dtassign.optval)
            Case tokenhared.token.ASSIDB
                pv_iden_assidb(dtassign, clinecodestruc, inline, _ilmethod)
            Case tokenhared.token.ANDEQ
                pv_iden_andeq(dtassign, clinecodestruc, inline, _ilmethod)
            Case tokenhared.token.PLUSEQ
                pv_iden_add(dtassign, clinecodestruc, inline, _ilmethod)
            Case tokenhared.token.MINUSEQ
                pv_iden_sub(dtassign, clinecodestruc, inline, _ilmethod)
            Case Else
                dserr.args.Add(dtassign.optval)
                dserr.new_error(conserr.errortype.OPERATORUNKNOWN, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(1)), dtassign.optval))
        End Select
    End Sub

    Private Sub pv_iden_sub(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = localinit.datatypelocal.find(varname, True, varname)
            If localvartype.issuccessful = False Then
                If localinit.datatypeparameter.find(varname, True, varname).issuccessful Then
                    localvartype = localinit.datatypeparameter.find(varname, True, varname)
                Else
                    dserr.args.Add(varname)
                    dserr.new_error(conserr.errortype.TYPENOTFOUND, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), varname))
                End If
            End If

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
            Dim localvartype As mapstoredata.dataresult = localinit.datatypelocal.find(varname, True, varname)
            If localvartype.issuccessful = False Then
                If localinit.datatypeparameter.find(varname, True, varname).issuccessful Then
                    localvartype = localinit.datatypeparameter.find(varname, True, varname)
                Else
                    dserr.args.Add(varname)
                    dserr.new_error(conserr.errortype.TYPENOTFOUND, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), varname))
                End If
            End If

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

    Private Sub pv_iden_andeq(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = localinit.datatypelocal.find(varname, True, varname)
            If localvartype.issuccessful = False Then
                If localinit.datatypeparameter.find(varname, True, varname).issuccessful Then
                    localvartype = localinit.datatypeparameter.find(varname, True, varname)
                Else
                    dserr.args.Add(varname)
                    dserr.new_error(conserr.errortype.TYPENOTFOUND, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), varname))
                End If
            End If

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
    Private Sub pv_iden_assidb(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = localinit.datatypelocal.find(varname, True, varname)
            If localvartype.issuccessful = False Then
                If localinit.datatypeparameter.find(varname, True, varname).issuccessful Then
                    localvartype = localinit.datatypeparameter.find(varname, True, varname)
                    If servinterface.is_pointer(_ilmethod, varname) Then
                        cil.load_argument(_ilmethod.codes, varname)
                    End If
                Else
                    'Set Error
                    dserr.args.Add(varname)
                    dserr.new_error(conserr.errortype.TYPENOTFOUND, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), varname))
                End If
            End If

            Select Case localvartype.result
                Case "str"
                    _ilmethod = optgen.assi_str(varname, clinecodestruc(ilinc))
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
            End Select
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
                If clinecodestruc(index).tokenid <> tokenhared.token.IDENTIFIER Then
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
    Private Sub nv_let(clinecodestruc() As xmlunpkd.linecodestruc, ByRef assignprocess As Boolean)
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
        Array.Resize(_illocalinit, ilmethodlen + 1)
        If clinecodestruc(1).tokenid <> tokenhared.token.IDENTIFIER Then
            'IDENTIFIER EXPECTED
            dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, clinecodestruc(1).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(1)), clinecodestruc(1).value), "let name : str = ""Amin""")

            'TODO : Check Global Types.
        ElseIf localinit.check_local_init(clinecodestruc(1).value) Then
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

            If clinecodestruc(ilinc).tokenid = tokenhared.token.COMMONDATATYPE Then
                _illocalinit(index).name = clinecodestruc(1).value
                _illocalinit(index).datatype = initcommondatatype.cdtype.find(clinecodestruc(3).value).result
                _illocalinit(index).iscommondatatype = True
            Else
                'Check other type ...
                _illocalinit(index).iscommondatatype = False
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
                    assignprocess = True
                Else
                    'let name : str =
                    dserr.new_error(conserr.errortype.DECLARINGERROR, clinecodestruc(4).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(4)), clinecodestruc(4).value) & vbCrLf & "The initial value is expected")
                End If
            End If
            'TODO : Check init value .
            localinit.add_local_init(clinecodestruc(1).value, clinecodestruc(3).value)
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
