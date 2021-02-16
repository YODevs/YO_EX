Imports System.IO
Imports System.Text

Public Class yocaproc
    Private dirs(), compoutput, execoutput As String
    Private compresult As Boolean = False
    Private acompile, ncompilesuccess, ncompilefailed, nrunsuccess, nrunfailed As Integer
    Public Sub New(dirlist As String())
        dirs = dirlist
    End Sub
    Public Sub check()
        If dirs.Length = 0 Then Return
        For index = 0 To dirs.Length - 1
            If check_project(dirs(index)) = False Then Continue For
            compresult = False
            compoutput = String.Empty
            execoutput = String.Empty
            If index <> 0 Then Console.WriteLine()
            Console.Write(index + 1 & "-Project '" & dirs(index).Remove(0, dirs(index).LastIndexOf("\")) & "' , Compile ")
            compile(dirs(index))
            acompile += 1
            If compresult Then
                ncompilesuccess += 1
                Console.ForegroundColor = ConsoleColor.DarkGreen
                Console.Write("[SUCCESS]")
                Console.ResetColor()
                Console.Write(" , Running ")
                Dim execpath As String = dirs(index) & "\target\release\" & dirs(index).Remove(0, dirs(index).LastIndexOf("\") + 1) & ".exe"
                If File.Exists(execpath) = False Then
                    nrunfailed += 1
                    Console.ForegroundColor = ConsoleColor.DarkRed
                    Console.Write("[FILENOTFOUND]")
                    Console.ResetColor()
                    Continue For
                End If
                run(execpath)
                Dim getpassoutput As String = File.ReadAllText(dirs(index) & "\output.txt")
                execoutput = execoutput.TrimEnd
                getpassoutput = getpassoutput.TrimEnd
                If getpassoutput = execoutput Then
                    nrunsuccess += 1
                    Console.ForegroundColor = ConsoleColor.DarkGreen
                    Console.Write("[PASS]")
                    Console.ResetColor()
                Else
                    nrunfailed += 1
                    Console.ForegroundColor = ConsoleColor.DarkRed
                    Console.Write("[FAILURE]")
                    Console.ResetColor()
                End If
            Else
                ncompilefailed += 1
                Console.ForegroundColor = ConsoleColor.DarkRed
                Console.Write("[FAILURE]")
                Console.ResetColor()
                Console.WriteLine(vbCrLf & compoutput)
            End If
        Next
        print_information()
    End Sub

    Private Sub print_information()
        Console.WriteLine(vbCrLf)
        Console.WriteLine("-The result of the operation")
        Console.Write("Overall result:")
        If acompile = ncompilesuccess AndAlso acompile = nrunsuccess Then
            Console.ForegroundColor = ConsoleColor.DarkGreen
            Console.WriteLine("[PASSED]")
            Console.Write("               [{0}/{0}]", acompile)
        Else
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("[FAILURE]")
            Console.Write("               compile:[{0}/{1}] - result:[{2}/{1}]", ncompilesuccess, acompile, nrunsuccess)
        End If
        Console.ResetColor()
        Console.Write(" Project(s)")
        Console.WriteLine()
    End Sub
    Private Function check_project(dir As String) As Boolean
        If File.Exists(dir & "\labra.yoda") = False Then
            Return False
        End If

        If File.Exists(dir & "\output.txt") = False Then
            Return False
        End If

        Return True
    End Function

    Private Sub run(path As String)
        Dim yoproc As New System.Diagnostics.Process()
        With yoproc.StartInfo
            .FileName = path
            .RedirectStandardOutput = True
            .RedirectStandardError = True
            .RedirectStandardInput = True
            .UseShellExecute = False
            .WindowStyle = ProcessWindowStyle.Normal
            .CreateNoWindow = False
        End With

        AddHandler yoproc.OutputDataReceived, AddressOf yoexecoutputhandler
        yoproc.Start()
        yoproc.BeginOutputReadLine()
        yoproc.WaitForExit()
    End Sub

    Private Sub yoexecoutputhandler(sender As Object, e As DataReceivedEventArgs)
        execoutput &= e.Data & vbCrLf
    End Sub

    Private Sub compile(dir As String)
        Dim yoproc As New System.Diagnostics.Process()
        With yoproc.StartInfo
            .FileName = conrex.APPDIR & "\yoca.exe"
            .Arguments = "build"
            .RedirectStandardOutput = True
            .RedirectStandardError = True
            .RedirectStandardInput = True
            .UseShellExecute = False
            .WorkingDirectory = dir
            .WindowStyle = ProcessWindowStyle.Normal
            .CreateNoWindow = False
        End With


        AddHandler yoproc.OutputDataReceived, AddressOf yooutputhandler
        yoproc.Start()
        yoproc.BeginOutputReadLine()
        yoproc.WaitForExit()

    End Sub

    Private Sub yooutputhandler(sender As Object, e As DataReceivedEventArgs)
        compoutput &= e.Data & vbCrLf
        If e.Data <> String.Empty AndAlso e.Data.Trim = "***** Operation completed successfully *****" Then
            compresult = True
        End If
    End Sub
End Class
