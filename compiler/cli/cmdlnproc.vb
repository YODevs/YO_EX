Public Class cmdlnproc
    Enum cmdtype
        TEST
        [EXIT]
        VERSION
    End Enum
    Structure cmdstruct
        Dim commandtype As cmdtype
        Dim command As String
        Dim withargs As Boolean
        Dim maxargs As Int16
    End Structure

    Public Shared cmd() As cmdstruct
    Public Shared Sub set_new_command(commandtype As cmdtype, command As String, Optional withargs As Boolean = False, Optional maxargs As Int16 = 0)
        Static Dim indexarray As Int16 = 0
        Array.Resize(cmd, indexarray + 1)
        cmd(indexarray) = New cmdstruct
        cmd(indexarray).commandtype = commandtype
        cmd(indexarray).command = command.ToLower
        cmd(indexarray).withargs = withargs
        cmd(indexarray).maxargs = maxargs
        indexarray += 1
        Return
    End Sub

    Public Shared Function check_master_key(command As String) As Int16
        command = command.ToLower
        For index = 0 To cmd.Length - 1
            If cmd(index).command = command Then
                Return index
            End If
        Next
        Return -1
    End Function
    Public Shared Sub init_command_struct()
        set_new_command(cmdtype.TEST, "test")
        set_new_command(cmdtype.EXIT, "exit")
        set_new_command(cmdtype.VERSION, "version")
    End Sub
End Class
