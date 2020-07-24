Module maincr
    Const BYPASSFLOW As Boolean = True
    Sub main(ByVal argsval() As String)
        init_class_data()
        If BYPASSFLOW Then
            cli.init_cli(False)
            cflowtester.lex_dir(conrex.APPDIR & "\myapp\")
            Console.ReadLine()
            Return
        End If
        If argsval.Length = 0 Then
            cli.init_cli(True)
            Console.ReadLine()
            Return
        End If
    End Sub

    Sub init_class_data()
        conserr.init_error_struct()
        tokenhared.init()
    End Sub
End Module
