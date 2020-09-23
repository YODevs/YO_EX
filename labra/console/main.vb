Module LabraMod

    Sub Main(args() As String)
        cli.init_cli(args.Length = 0)
        If args.Length = 0 Then
            goto_cmdln(args)
        Else
            parseargs.parse_data(args)
        End If
    End Sub

    Sub goto_cmdln(args() As String)
        While True
            interactioncmd.get_interaction(args)
            parseargs.parse_data(args)
        End While
    End Sub
End Module
