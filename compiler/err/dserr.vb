Public Class dserr

    Friend Shared args As New ArrayList
    Public Shared Sub new_error(errtype As conserr.errortype, line As Integer, file As String, Optional description As String = "Not specified", Optional example As String = "Not specified")
        procresult.rs_set_result(False)
        Dim indexerr As Int16 = errtype
        Dim err As conserr.errorstruct = conserr.err(indexerr)
        Dim indexspaceolor As ConsoleColor = Console.ForegroundColor
        Console.ForegroundColor = ConsoleColor.DarkRed
        Dim hwall As String = String.Empty
        For index = 0 To Console.BufferWidth - 1
            hwall &= "="
        Next

        If args.Count > 0 Then
            For index = 0 To args.Count - 1
                err.text = err.text.Replace("{" & index & "}", args(index))
            Next
            args.Clear()
        End If
        Console.WriteLine()
        Console.Write(hwall)
        Console.ForegroundColor = ConsoleColor.Red
        Console.Write(err.title & " : ")
        Console.ForegroundColor = ConsoleColor.Gray
        Console.Write(err.text & vbCrLf)

        Console.ForegroundColor = ConsoleColor.Red
        Console.Write("Source : ")
        Console.ForegroundColor = ConsoleColor.Gray
        If file <> Nothing Then
            If line = -1 Then
                Console.WriteLine(file)
            Else
                Console.WriteLine(file & " - Line [" & line & "]")
            End If
        End If
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("*** More Detials ***")
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine(description)

        Dim indexspace As Int16 = (Console.BufferWidth - 54) / 2

        Console.ForegroundColor = ConsoleColor.DarkRed
        Console.WriteLine(Space(indexspace) & "***********************SNIPPT************************" & Space(indexspace))
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("Example : ")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine(example)


        Console.ForegroundColor = ConsoleColor.DarkRed
        Console.Write(hwall)
        Console.ForegroundColor = ConsoleColor.Gray

        If err.priority = conserr.errorpriority.STOP Then
            System.Environment.Exit(conrex.exitcode.ERROR)
        End If
        Return
    End Sub
End Class
