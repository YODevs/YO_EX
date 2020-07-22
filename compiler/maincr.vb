Module maincr

    Sub main(ByVal argsval() As String)
        If argsval.Length = 0 Then
            cli.init_cli(True)
            Console.ReadLine()
            Return
        End If
    End Sub

End Module
