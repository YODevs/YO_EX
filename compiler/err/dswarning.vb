Public Class dswar
    Private Shared iwar As Integer = 1
    Friend Shared Sub new_warning(title As String, description As String)

        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.Write(vbCr & iwar & "-")
        Console.Write(title)
        Console.ResetColor()
        Console.WriteLine(" => " & description)
    End Sub
End Class
