Imports System.Text.RegularExpressions

Public Class interactioncmd

    Friend Shared Sub get_interaction(ByRef args() As String)
        Console.Write(vbCrLf)
        write_prefix_ch()
        args = Regex.Split(Console.ReadLine(), conrex.SPACE)
    End Sub

    Friend Shared Sub write_prefix_ch()
        Dim peconsolecolor As Int16 = Console.ForegroundColor
        Console.ForegroundColor = System.ConsoleColor.DarkCyan
        Console.Write(vbCr & "$YO CLI> ")
        Console.ForegroundColor = peconsolecolor
    End Sub
End Class
