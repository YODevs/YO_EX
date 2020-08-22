Public Class imp_cil_code

    Const codestr As String = "ldloc age
call void [mscorlib]System.Console::WriteLine(int32)"
    Friend Shared Sub import_test_code(ByRef funcdt As ilformat._ilmethodcollection)
        For Each cline In codestr.Split(vbCr)
            funcdt.codes.Add(cline.TrimStart)
        Next
    End Sub
End Class
