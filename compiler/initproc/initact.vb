Imports System.IO

Public Class initact
    Friend Shared Sub set_initial_process()
        check_environment_variable()
        set_compiler_statistics()
        install_extension()
    End Sub

    Private Shared Sub install_extension()
        yoext.extensioninstaller.install_extensions()
    End Sub
    Private Shared Sub set_compiler_statistics()
        Console.Write("Generate data for compiler statistics :: ")
        Try
            If File.Exists(conrex.APPDIR & "\iniopt\cstatistics\compilerdata.labra") Then
                Console.ForegroundColor = ConsoleColor.DarkYellow
                Console.WriteLine("[IGNORED]")
                Console.ResetColor()
            Else
                Directory.CreateDirectory(conrex.APPDIR & "\iniopt\cstatistics\")
                'TODO : Set default value
                File.WriteAllText(conrex.APPDIR & "\iniopt\cstatistics\compilerdata.labra", Nothing)
                Console.ForegroundColor = ConsoleColor.DarkGreen
                Console.WriteLine("[TRUE]")
                Console.ResetColor()
            End If
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("[FALSE]")
            Console.ResetColor()
            dserr.new_error(conserr.errortype.RUNTIMEERROR, -1, Nothing, ex.Message)
        End Try
    End Sub

    Private Shared Sub check_environment_variable()
        Try
            Console.Write("Setting global environment variable :: ")
            Dim env As String = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User)
            If env = conrex.NULL Then
                Environment.SetEnvironmentVariable("Path", conrex.APPDIR, EnvironmentVariableTarget.User)
                Console.ForegroundColor = ConsoleColor.DarkGreen
                Console.WriteLine("[TRUE]")
                Console.ResetColor()
            Else
                If env.Contains(conrex.APPDIR & ";") Then
                    Console.ForegroundColor = ConsoleColor.DarkYellow
                    Console.WriteLine("[IGNORED]")
                    Console.ResetColor()
                Else
                    Environment.SetEnvironmentVariable("Path", conrex.APPDIR & ";" & env, EnvironmentVariableTarget.User)
                    Console.ForegroundColor = ConsoleColor.DarkGreen
                    Console.WriteLine("[TRUE]")
                    Console.ResetColor()
                End If
            End If
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("[FALSE]")
            Console.ResetColor()
            dserr.new_error(conserr.errortype.RUNTIMEERROR, -1, Nothing, ex.Message)
        End Try
    End Sub
End Class
