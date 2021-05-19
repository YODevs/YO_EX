Public Class [environment]
    Public Shared ReadOnly Property username() As String
        Get
            Return System.Environment.UserName
        End Get
    End Property
    Public Shared ReadOnly Property userdomainname() As String
        Get
            Return System.Environment.UserDomainName
        End Get
    End Property
    Public Shared ReadOnly Property stacktrace() As String
        Get
            Return System.Environment.StackTrace
        End Get
    End Property
    Public Shared ReadOnly Property osversion() As String
        Get
            Return System.Environment.OSVersion.ToString
        End Get
    End Property
    Public Shared ReadOnly Property machinename() As String
        Get
            Return System.Environment.MachineName
        End Get
    End Property
    Public Shared ReadOnly Property is64bitprocess() As String
        Get
            Return System.Environment.Is64BitProcess
        End Get
    End Property
    Public Shared ReadOnly Property is64bitos() As String
        Get
            Return System.Environment.Is64BitOperatingSystem
        End Get
    End Property
    Public Shared ReadOnly Property commandline() As String
        Get
            Return System.Environment.CommandLine
        End Get
    End Property

    Public Shared ReadOnly Property crdir() As String
        Get
            Return System.Environment.CurrentDirectory
        End Get
    End Property

    Public Shared ReadOnly Property appdir() As String
        Get
            Return My.Application.Info.DirectoryPath
        End Get
    End Property

    Public Shared ReadOnly Property sysdir() As String
        Get
            Return System.Environment.SystemDirectory
        End Get
    End Property
    Public Shared ReadOnly Property arglen() As Integer
        Get
            Return System.Environment.GetCommandLineArgs.Length
        End Get
    End Property
    Public Shared Sub terminate()
        terminate(0)
    End Sub
    Public Shared Sub terminate(exitcode As Integer)
        System.Environment.Exit(exitcode)
    End Sub

    Public Shared Function get_env(envname As String) As String
        Return System.Environment.GetEnvironmentVariable(envname)
    End Function

    Public Shared Sub set_env(envname As String, value As String)
        System.Environment.SetEnvironmentVariable(envname, value)
    End Sub
    Public Shared Function get_arg(index As Integer) As String
        If System.Environment.GetCommandLineArgs.Length - 1 > index OrElse index < 0 Then Return Nothing
        Return System.Environment.GetCommandLineArgs(index)
    End Function
End Class
