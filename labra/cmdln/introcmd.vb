Imports YOOrderList
Imports YODA
Imports System.IO

Public Class introcmd

    Public Shared Sub show_intro()
        If Console.CursorTop > 20 Then
            Console.Clear()
        End If
        Dim commandlist As ArrayList
        Dim yodaf As New YODA_Format
        Console.Write(constcli.introtext)
        get_command_list(commandlist)
        Dim result As String = YOList.ShowMenu(yodaf.WriteYODA(commandlist)).ToString
        proc_intro(result)
    End Sub

    Private Shared Sub proc_intro(result As String)
        If File.Exists(conrex.APPDIR & "\iniopt\introlabra.yoda") = False Then
            dserr.set_error("Intro error", "Labra command instruction file not found.")
            Return
        End If
        Dim getintro As String = File.ReadAllText(conrex.APPDIR & "\iniopt\introlabra.yoda")
        Dim yodaf As New YODA_Format
        Dim yodamap As YODA_Format.YODAMapFormat = yodaf.ReadYODA_Map(getintro)
        Dim menustore As New mapstoredata
        menustore.import_collection(yodamap.keys, yodamap.values)
        Dim resultmapstore As mapstoredata.dataresult = menustore.find(result)
        If resultmapstore.issuccessful Then
            print_intro(result, resultmapstore.result)
        Else
            dserr.set_error("Intro error", "No help for '" & result & "' command found.")
        End If
    End Sub

    Private Shared Sub print_intro(command As String, value As String)
        Dim defcolor As Int16 = Console.ForegroundColor
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine(vbCrLf & vbCrLf & "*** Command details [{0}] ***", command)
        Console.ForegroundColor = defcolor
        For Each cline In value.Split(vbCrLf)
            cline = cline.Trim
            Console.ForegroundColor = defcolor
            If cline.StartsWith("***") Then
                Console.ForegroundColor = ConsoleColor.Red
            ElseIf cline.StartsWith("--") Then
                Console.ForegroundColor = ConsoleColor.DarkCyan
            ElseIf cline.StartsWith("Usage :") Then
                Console.ForegroundColor = ConsoleColor.DarkGreen
            End If
            Console.WriteLine(cline)
        Next
        Console.ForegroundColor = defcolor
    End Sub

    Private Shared Sub get_command_list(ByRef commandlist As ArrayList)
        commandlist = New ArrayList
        For index = 0 To cmdlnproc.cmd.Length - 2
            commandlist.Add(cmdlnproc.cmd(index).command)
        Next
    End Sub
End Class
