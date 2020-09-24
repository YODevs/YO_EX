Public Class dserr
    Public Shared Sub set_error(title As String, caption As String)
        Dim peconsolecolor As Int16 = Console.ForegroundColor
        Console.ForegroundColor = System.ConsoleColor.DarkRed
        Console.Write("$Error> " & title & " > ")
        Console.ForegroundColor = System.ConsoleColor.Gray
        Console.Write(caption)
        Console.ForegroundColor = peconsolecolor
    End Sub
End Class
