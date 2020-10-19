Imports System.IO

Public Class execln
    Friend Shared Sub nv_check_command(result As parseargs._parseresult)
        If result.command = Nothing Or result.command = conrex.SPACE Then
            Return
        End If
        Dim getindex As Int16 = cmdlnproc.check_master_key(result.command)
        If getindex = -1 Then
            'Set Error , command not found .
            dserr.set_error("Command Error", "'" & result.command & "' - Command not found." & vbLf & "This command may be used in updated versions of Labra.")
            Return
        End If

        If cmdlnproc.cmd(getindex).withargs = False AndAlso result.args.Count > 0 Then
            dserr.set_error("Parameter Error", "'" & result.command & "' - This command does not support any parameters, enter this command without entering a parameter.")
            Return
        ElseIf cmdlnproc.cmd(getindex).maxargs < result.args.Count Then
            dserr.set_error("Parameter Error", "'" & result.command & "' - The number of parameters of this command is too much.")
            Return
        End If

        Dim cmdexeclninstance As New execln
        If cmdlnproc.cmd(getindex).withargs = False Then
            CallByName(cmdexeclninstance, "rp_" & result.command, CallType.Method, Nothing)
        Else
            CallByName(cmdexeclninstance, "rp_" & result.command, CallType.Method, result.args)
        End If
    End Sub
    Public Sub New()
    End Sub
    Public Sub rp_test()
        Dim peconsolecolor As Int16 = Console.ForegroundColor
        Console.ForegroundColor = System.ConsoleColor.DarkGreen
        Console.Write("Bravo !!!!! Labra is ready to execute your commands.
You can type 'Help' to view commands.")
        Console.ForegroundColor = peconsolecolor
    End Sub

    Public Sub rp_exit()
        Environment.Exit(1)
    End Sub

    Public Sub rp_new()
        Dim projcreator As New crproj()
        projcreator.init_project()
    End Sub
    Public Sub rp_version()
        Console.Write(conrex.VER)
    End Sub

    Public Sub rp_add()
        Try
            Console.Write(vbLf & "# Select an item: " & vbCr)
            Select Case YOOrderList.YOList.ShowMenu("!['Class File [.yo]','New Folder','Custom File']")
                Case "New Folder"
                    Console.Write(vbLf & "# Enter a new folder name or route: ")
                    Dim path As String = conrex.ENVCURDIR & "\" & Console.ReadLine()
                    If Directory.Exists(path) = False Then
                        Directory.CreateDirectory(path)
                        Console.Write("Folder created successfully.")
                    Else
                        dserr.set_error("New item error", path & " - This route already exists.")
                    End If
                Case "Class File [.yo]"
                    Console.Write(vbLf & "# Enter a new file name: ")
                    Dim path As String = conrex.ENVCURDIR & "\" & Console.ReadLine()
                    If path.ToLower.EndsWith(conrex.YOFORMAT) = False Then path &= conrex.YOFORMAT
                    File.WriteAllText(path, String.Empty)
                    Console.Write("Empty file created successfully.")
                Case "Custom File"
                    Console.Write(vbLf & "# Enter a new file name with extension [ex:file.txt]: ")
                    Dim path As String = conrex.ENVCURDIR & "\" & Console.ReadLine()
                    File.WriteAllText(path, String.Empty)
                    Console.Write("Empty file created successfully.")
            End Select
        Catch ex As Exception
            dserr.set_error("New item error", ex.Message)
        End Try
    End Sub

    Public Sub rp_edit(args As ArrayList)
        Dim propertyname As String = String.Empty
        Dim propertyvalue As String = String.Empty
        Dim propertyindex As Integer = -1
        Dim yodadata As String = String.Empty
        If args.Count > 0 Then
            propertyname = args(0).ToString
        End If

        If File.Exists(conrex.ENVCURDIR & "\labra.yoda") = False Then
            dserr.set_error("Edit Command Error", conrex.ENVCURDIR & "\labra.yoda" & " - Labra file not found.")
            Return
        End If

        yodadata = File.ReadAllText(conrex.ENVCURDIR & "\labra.yoda")
        Dim yoda As New YODA.YODA_Format
        Dim yodaf As YODA.YODA_Format.YODAMapFormat = yoda.ReadYODA_Map(yodadata)

        If propertyname = String.Empty Then
            Console.Write(vbLf & "# Select a property :")
            propertyname = YOOrderList.YOList.ShowMenu(yoda.WriteYODA(yodaf.keys))
        End If

        For index = 0 To yodaf.keys.Count - 1
            If yodaf.keys(index).ToString = propertyname Then
                propertyvalue = yodaf.values(index)
                propertyindex = index
                Exit For
            End If
        Next

        If propertyindex = -1 Then
            dserr.set_error("Edit Command Error", propertyname & " - Property not found.")
            Return
        Else
            Console.WriteLine(vbCrLf & propertyname & " -> " & propertyvalue)
            Console.Write("New value : ")
            propertyvalue = Console.ReadLine()
        End If

        yodaf.values.Insert(propertyindex + 1, propertyvalue)
        yodaf.values.RemoveAt(propertyindex)

        File.WriteAllText(conrex.ENVCURDIR & "\labra.yoda", yoda.WriteYODA_Map(yodaf.keys, yodaf.values, False))

        Dim peconsolecolor As Int16 = Console.ForegroundColor
        Console.ForegroundColor = System.ConsoleColor.DarkGreen
        Console.Write(vbLf & "Property changed successfully.")
        Console.ForegroundColor = peconsolecolor

        Console.Write(vbLf & "# Select the next task: " & vbCr)
        Select Case YOOrderList.YOList.ShowMenu("!['Show folder','edit','Continue','Exit']")
            Case "Show folder"
                Process.Start(conrex.ENVCURDIR)
            Case "edit"
                rp_edit(args)
            Case "Contiune"
                Return
            Case "Exit"
                Environment.Exit(1)
        End Select
    End Sub
End Class
