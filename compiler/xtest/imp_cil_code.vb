Public Class imp_cil_code

    Const codestr As String = "
"
    Friend Shared Sub import_test_code(ByRef funcdt As ilformat._ilmethodcollection)
        For Each cline In codestr.Split(vbCr)
            funcdt.codes.Add(cline.TrimStart)
        Next
    End Sub
End Class
