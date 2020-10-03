Public Class procresult
    Private Shared state As String = String.Empty
    Friend Shared Sub rp_lex_file(path As String)
        Console.Write("Lex ->" & path.Replace(conrex.ENVCURDIR, conrex.NULL))
    End Sub

    Friend Shared Sub rs_lex_file(result As Boolean)
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

    Friend Shared Sub set_state(newstate As String)
        state = newstate
    End Sub

    Friend Shared Sub rs_set_result(result As Boolean)
        Select Case state
            Case "lex"
                rs_lex_file(result)
        End Select
    End Sub
End Class
