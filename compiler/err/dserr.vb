Public Class dserr

    Friend Shared args As New ArrayList
    Public Shared Sub new_error(errtype As conserr.errortype, line As Integer, file As String, Optional description As String = "Not specified", Optional example As String = "Not specified")
        procresult.rs_set_result(False)
        Dim indexerr As Int16 = errtype
        Dim err As conserr.errorstruct = conserr.err(indexerr)
        Dim indexspaceolor As ConsoleColor = Console.ForegroundColor
        Dim hwall As String = String.Empty
        Dim consolebufferwidth As Integer = 80
        set_header_err(consolebufferwidth, hwall)
        If args.Count > 0 Then
            For index = 0 To args.Count - 1
                err.text = err.text.Replace("{" & index & "}", args(index))
            Next
            args.Clear()
        End If
        Console.WriteLine()
        print_value(ConsoleColor.DarkRed, hwall, ConsoleColor.DarkRed)
        Console.WriteLine()
        print_value(ConsoleColor.Red, err.title & " : ", ConsoleColor.Gray)
        Console.Write(err.text & vbCrLf)
        print_value(ConsoleColor.Red, "source : ", ConsoleColor.Gray)
        If file <> Nothing Then
            If line = -1 Then
                Console.WriteLine(file)
            Else
                Console.WriteLine(file & " - Line [" & line & "]")
            End If
        End If
        print_value(ConsoleColor.Red, "Error Code : ", ConsoleColor.Gray)
        Console.WriteLine("[Err-{0}-{1}]", errtype, indexerr)
        print_value(ConsoleColor.Red, "*** More Detials ***", ConsoleColor.Gray, True)
        Console.WriteLine(description)
        Dim indexspace As Int16 = (consolebufferwidth - 54) / 2
        print_value(ConsoleColor.DarkRed, Space(indexspace) & "***********************SNIPPT************************" & Space(indexspace), ConsoleColor.Green, True)
        Console.WriteLine("Example : ")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine(example)

        print_value(ConsoleColor.DarkRed, hwall, ConsoleColor.Gray)

        If compdt.DEVMOD Then set_stack_trace()
        If err.priority = conserr.errorpriority.STOP Then
            System.Environment.Exit(conrex.exitcode.ERROR)
        End If
        Console.WriteLine()
        Return
    End Sub

    Private Shared Sub set_stack_trace()
        Dim sb As New Text.StringBuilder
        Dim st As New StackTrace()
        For index = 2 To st.FrameCount - 1
            sb.AppendLine(String.Format("{0}->{1}", st.GetFrame(index).GetMethod.ReflectedType.ToString, st.GetFrame(index).GetMethod().Name))
        Next
        coutputdata.write_file_data("stacktrace.txt", sb.ToString)
    End Sub

    Private Shared Sub set_header_err(ByRef consolebufferwidth As Integer, ByRef hwall As String)
        If Console.IsOutputRedirected = False Then consolebufferwidth = Console.BufferWidth
        For index = 0 To consolebufferwidth - 1
            hwall &= conrex.EQU
        Next
    End Sub

    Private Shared Sub print_value(bfcolor As ConsoleColor, value As String, nxcolor As ConsoleColor, Optional newline As Boolean = False)
        Console.ForegroundColor = bfcolor
        If newline Then
            Console.WriteLine(value)
        Else
            Console.Write(value)
        End If
        Console.ForegroundColor = nxcolor
    End Sub
End Class
