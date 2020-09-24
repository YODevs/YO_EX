Module LabraMod

    Sub Main(args() As String)
        cmdlnproc.init_command_struct()
        cli.init_cli(args.Length = 0)
        If args.Length = 0 Then
            goto_cmdln(args)
        Else
            parseargs.parse_data(args)
        End If
    End Sub

    Sub goto_cmdln(args() As String)
        Console.Write(vbCrLf)
        While True
            interactioncmd.get_interaction(args)
            parseargs.parse_data(args)
        End While
    End Sub
End Module
