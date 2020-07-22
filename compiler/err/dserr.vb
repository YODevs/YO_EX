Public Class dserr
    Public Shared Sub new_error(errtype As conserr.errortype, Optional description As String = "Not specified", Optional example As String = "Not specified")
        Dim indexerr As Int16 = errtype
        Dim err As conserr.errorstruct = conserr.err(indexerr)
        Dim indexspaceolor As ConsoleColor = Console.ForegroundColor
        Console.ForegroundColor = ConsoleColor.DarkRed
        Dim hwall As String = String.Empty
        For index = 0 To Console.BufferWidth - 1
            hwall &= "="
        Next
        Console.WriteLine()
        Console.Write(hwall)
        Console.ForegroundColor = ConsoleColor.Red
        Console.Write(err.title & " : ")
        Console.ForegroundColor = ConsoleColor.Gray
        Console.Write(err.text & vbCrLf)
        Console.ForegroundColor = ConsoleColor.Red
        Console.Write("More Detials : ")
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine(description)

        Dim indexspace As Int16 = (Console.BufferWidth - 54) / 2

        Console.ForegroundColor = ConsoleColor.DarkRed
        Console.WriteLine(Space(indexspace) & "***********************SNIPPT************************" & Space(indexspace))
        Console.ForegroundColor = ConsoleColor.Green
        Console.Write("Example : ")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine(example)


        Console.ForegroundColor = ConsoleColor.DarkRed
        Console.Write(hwall)
    End Sub
End Class
