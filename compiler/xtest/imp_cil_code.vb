Public Class imp_cil_code

    Const codestr As String = ""
    Const codestr2 As String = "//ldstr ""Hello World!""
//call void [mscorlib]System.Console::WriteLine(string)
//ldloc.0
//call void [mscorlib]System.Console::WriteLine(int32)
ldloc.1
call void [mscorlib]System.Console::WriteLine(int32)

//call string [mscorlib]System.Console::ReadLine()
//pop
"

    Friend Shared Sub import_test_code(ByRef funcdt As ilformat._ilmethodcollection)
        For Each cline In codestr.Split(vbCr)
            funcdt.codes.Add(cline.TrimStart)
        Next
    End Sub

    Friend Shared Sub import_test_code2(ByRef funcdt As ilformat._ilmethodcollection)
        For Each cline In codestr2.Split(vbCr)
            funcdt.codes.Add(cline.TrimStart)
        Next
    End Sub
    Friend Shared Sub import_test_local_init(ByRef funcdt As ilformat._ilmethodcollection)
        Dim locinit As New ilformat._illocalinit
        locinit.name = "age"
        locinit.datatype = "int32"
        locinit.hasdefaultvalue = True
        locinit.iscommondatatype = True
        Array.Resize(locinit.clocalvalue, 1)
        locinit.clocalvalue(0).value = 0
        illocalsinit.set_local_init(funcdt.locallinit, locinit)
    End Sub
End Class
