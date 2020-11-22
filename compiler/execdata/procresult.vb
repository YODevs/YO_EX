Public Class procresult
    Private Shared state As String = String.Empty
    Friend Shared Sub rp_lex_file(path As String)
        If compdt.MUTEPROCESS Then Return
        Console.Write(vbTab & "Lex ->" & path.Replace(conrex.ENVCURDIR, conrex.NULL))
    End Sub

    Friend Shared Sub rp_init(value As String)
        If compdt.MUTEPROCESS Then Return
        Console.Write(vbTab & "Init ->" & value)
    End Sub

    Friend Shared Sub rp_gen(value As String)
        If compdt.MUTEPROCESS Then Return
        Console.Write(vbTab & "Gen ->" & value.Replace(conrex.ENVCURDIR, conrex.NULL))
    End Sub

    Friend Shared Sub rp_asm(value As String)
        If compdt.MUTEPROCESS Then Return
        Console.Write(vbTab & "Asm ->" & value)
    End Sub
    Friend Shared Sub rs_proc_data(result As Boolean)
        If compdt.MUTEPROCESS Then Return
        Console.Write(" :: ")
        Dim ciden As Int16 = Console.ForegroundColor
        If result Then
            Console.ForegroundColor = ConsoleColor.DarkGreen
            Console.WriteLine("[PASSED]")
        Else
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("[REFUSED]")
        End If

        Console.ForegroundColor = ciden
    End Sub

    Friend Shared Sub rs_proc_data(result As Boolean, truestring As String, falsestring As String)
        If compdt.MUTEPROCESS Then Return
        Console.Write(" :: ")
        Dim ciden As Int16 = Console.ForegroundColor
        If result Then
            Console.ForegroundColor = ConsoleColor.DarkGreen
            Console.WriteLine(truestring)
        Else
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine(falsestring)
        End If

        Console.ForegroundColor = ciden
    End Sub
    Friend Shared Sub set_state(newstate As String)
        If compdt.MUTEPROCESS Then Return
        Select Case newstate
            Case "init"
                Console.WriteLine("-Initialization & Process Preparation")
            Case "lex"
                Console.WriteLine("-Lexical Analyzer")
            Case "gen"
                Console.WriteLine("-Intermediate Code Generation")
            Case "asm"
                Console.WriteLine("-Assembly Code Generation")
        End Select
        state = newstate
    End Sub

    Friend Shared Sub rs_set_result(result As Boolean)
        If compdt.MUTEPROCESS Then Return
        Select Case state
            Case "lex"
                rs_proc_data(result)
            Case "init"
                rs_proc_data(result)
            Case "gen"
                rs_proc_data(result, "[DONE]", "[FAILED]")
            Case "asm"
                rs_proc_data(result, "[DONE]", "[FAILED]")
        End Select
    End Sub
End Class
