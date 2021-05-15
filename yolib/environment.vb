Public Class [environment]
    Public ReadOnly Property username() As String
        Get
            Return System.Environment.UserName
        End Get
    End Property
    Public ReadOnly Property userdomainname() As String
        Get
            Return System.Environment.UserDomainName
        End Get
    End Property
    Public ReadOnly Property stacktrace() As String
        Get
            Return System.Environment.StackTrace
        End Get
    End Property
    Public ReadOnly Property osversion() As String
        Get
            Return System.Environment.OSVersion.ToString
        End Get
    End Property
    Public ReadOnly Property machinename() As String
        Get
            Return System.Environment.MachineName
        End Get
    End Property
End Class
