Module maincr
    Const BYPASSFLOW As Boolean = True
    Sub main(ByVal argsval() As String)
        conserr.init_error_struct()
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

End Module
