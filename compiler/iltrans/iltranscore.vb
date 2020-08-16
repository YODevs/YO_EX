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
            For index = 0 To clinecodestruc.Length - 1

            Next
        End While
    End Sub
End Class
