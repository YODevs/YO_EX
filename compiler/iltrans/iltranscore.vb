Public Class iltranscore

    Private methoddata As tknformat._method
    Public Sub New(method As tknformat._method)
        methoddata = method
    End Sub

    Public Sub gen_transpile_code(ByRef _ilmethod As ilformat._ilmethodcollection)
        _ilmethod.codes = New ArrayList
        _ilmethod.line = New ArrayList
        Dim xmldata As New xmlunpkd(methoddata.bodyxmlfmt)

        While xmldata.xmlreader.EOF = False
            Dim clinecodestruc() As xmlunpkd.linecodestruc
            clinecodestruc = xmldata.get_line_tokens
            rev_cline_code(clinecodestruc, _ilmethod)
        End While

        xmldata.close()
    End Sub

    Private Sub rev_cline_code(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        If clinecodestruc.Length = 0 Then Return

        Select Case clinecodestruc(0).tokenid
            Case tokenhared.token.LET

        End Select
    End Sub
End Class
