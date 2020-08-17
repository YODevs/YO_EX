Public Class iltranscore
    Private _illocallinit(0) As ilformat._illocalinit
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

        _ilmethod.locallinit = _illocallinit 'exc no local init
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
        Dim ilmethodlen As Integer = _illocallinit.Length
        Dim index As Integer = ilmethodlen - 1
        If ilmethodlen = 0 Then index = 0
        Array.Resize(_illocallinit, ilmethodlen + 1)
        If clinecodestruc(1).tokenid <> tokenhared.token.IDENTIFIER Then
            'IDENTIFIER EXPECTED
            dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, clinecodestruc(1).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(1)), clinecodestruc(1).value), "let name : str = ""Amin""")
        ElseIf localinit.check_local_init(clinecodestruc(1).value) Then
            'DECLARING ERROR
            dserr.new_error(conserr.errortype.DECLARINGERROR, clinecodestruc(1).line, path, authfunc.get_line_error(path, get_target_info(clinecodestruc(1)), clinecodestruc(1).value) & vbCrLf & "Choose another name.")
        End If

        _illocallinit(index).name = clinecodestruc(1).value

        localinit.add_local_init(clinecodestruc(1).value, clinecodestruc(2).value)
        MsgBox(_illocallinit(index).name)
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
