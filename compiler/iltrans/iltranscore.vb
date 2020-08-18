Public Class iltranscore
    Private _illocalinit(0) As ilformat._illocalinit
    Private methoddata As tknformat._method
    Private localinit As localinitdata
    Private path As String
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
            Case tokenhared.token.LET
                nv_let(clinecodestruc)
        End Select
    End Sub

    Private Sub nv_let(clinecodestruc() As xmlunpkd.linecodestruc)
        Dim ilmethodlen As Integer = _illocalinit.Length
        Dim index As Integer = ilmethodlen - 1
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
        'Check ":" in let statements.
        If clinecodestruc(2).tokenid <> tokenhared.token.ASSINQ Then
            dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(2).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(2)), clinecodestruc(2).value), "let name : str = ""Amin""")
        End If

        If clinecodestruc(3).tokenid = tokenhared.token.COMMONDATATYPE Then
            _illocalinit(index).name = clinecodestruc(1).value.ToLower
            _illocalinit(index).datatype = initcommondatatype.cdtype.find(clinecodestruc(3).value.ToLower).result
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
    End Sub

    Public Function get_target_info(clinecodestruc As xmlunpkd.linecodestruc) As lexer.targetinf
        Dim linecinf As New lexer.targetinf
        linecinf.lstart = clinecodestruc.ist
        linecinf.line = clinecodestruc.line
        linecinf.length = clinecodestruc.ile
        linecinf.lend = clinecodestruc.ien
        Return linecinf
    End Function
End Class
