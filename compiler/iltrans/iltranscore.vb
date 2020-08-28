Public Class iltranscore
    Private _illocalinit(0) As ilformat._illocalinit
    Private methoddata As tknformat._method
    Private localinit As localinitdata
    Private path As String

    Structure identifierassignmentinfo
        Dim identifiers As ArrayList
        Dim optval As String
    End Structure
    Public Sub New(method As tknformat._method)
        methoddata = method
        localinit = New localinitdata
    End Sub

    Public Sub gen_transpile_code(ByRef _ilmethod As ilformat._ilmethodcollection)
        _ilmethod.codes = New ArrayList
        _ilmethod.line = New ArrayList
        Dim xmldata As New xmlunpkd(methoddata.bodyxmlfmt)
        path = xmldata.path
        While xmldata.xmlreader.EOF = False
            Dim clinecodestruc() As xmlunpkd.linecodestruc
            clinecodestruc = xmldata.get_line_tokens
            rev_cline_code(clinecodestruc, _ilmethod)
        End While
        Array.Resize(_illocalinit, _illocalinit.Length - 1)
        _ilmethod.locallinit = _illocalinit 'exc no local init
        xmldata.close()
    End Sub

    Private Sub rev_cline_code(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        If clinecodestruc.Length = 0 Then Return

        Select Case clinecodestruc(0).tokenid
            Case tokenhared.token.IDENTIFIER
                nv_st_identifier(clinecodestruc, _ilmethod)
            Case tokenhared.token.LET
                nv_let(clinecodestruc)
                _ilmethod.locallinit = _illocalinit 'exc no local init
            Case tokenhared.token.CIL_BLOCK
                nv_cil_commands(clinecodestruc, _ilmethod)
        End Select
    End Sub

    Private Sub nv_cil_commands(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
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
            dserr.new_error(conserr.errortype.CILCOMMANDSAUTH, clinecodestruc(0).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End If
    End Sub
    Private Sub nv_st_identifier(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        'TODO : Check Func Identifiers.
        Dim inline As Integer = 0
        Dim index As Integer = clinecodestruc.Length - 1
        If clinecodestruc.Length < 3 Then
            dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(index).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(index)), clinecodestruc(index).value))
            Return
        End If

        Dim dtassign As identifierassignmentinfo = get_iden_names(clinecodestruc, inline)

        Select Case tokenhared.check_sym(dtassign.optval)
            Case tokenhared.token.ASSIDB
                pv_iden_assidb(dtassign, clinecodestruc, inline, _ilmethod)
        End Select
    End Sub

    Private Sub pv_iden_assidb(dtassign As identifierassignmentinfo, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod)
        For index = 0 To dtassign.identifiers.Count - 1
            Dim varname As String = dtassign.identifiers(index)
            Dim localvartype As mapstoredata.dataresult = localinit.datatypelocal.find(varname)
            If localvartype.issuccessful = False Then
                'Set Error
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
                Case "ui64"
                Case "ui32"
                Case "ui16"
                Case "ui8"
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
    Private Sub nv_let(clinecodestruc() As xmlunpkd.linecodestruc)
        Dim ilmethodlen As Integer = _illocalinit.Length
        Dim index As Integer = ilmethodlen - 1
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
