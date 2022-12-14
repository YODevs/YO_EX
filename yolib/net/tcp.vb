Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class tcp
    Dim stcpclient As System.Net.Sockets.TcpClient
    Dim host As String, port As Integer
    Public Sub New(host As String, port As Integer)
        Me.host = host
        Me.port = port
        stcpclient = New TcpClient()
        stcpclient.Connect(host, port)
    End Sub
    Public Sub New(port As Integer)
        Me.New("127.0.0.1", port)
    End Sub

    Public Function send(text As String) As String
        If connected = False Then
            stcpclient.Connect(host, port)
        End If
        Dim networkstream As NetworkStream = stcpclient.GetStream()
        If networkstream.CanRead = False Then
            stcpclient.Close()
            Throw New Exception("cannot not write data to this stream.")
        ElseIf networkstream.CanWrite = False Then
            stcpclient.Close()
            Throw New Exception("cannot read data from this stream.")
        End If
        Dim sbytes As [Byte]() = encoding.ascii_get_bytes(text)
        networkstream.Write(sbytes, 0, sbytes.Length)
        Dim streader As New IO.StreamReader(networkstream)
        Dim sbuilder As New StringBuilder
        While streader.Peek > -1
            sbuilder.Append(Convert.ToChar(streader.Read()).ToString)
        End While
        Return sbuilder.ToString
    End Function

    Public Sub close()
        stcpclient.Close()
    End Sub

    Public ReadOnly Property connected() As Boolean
        Get
            Return stcpclient.Connected
        End Get
    End Property

    Public ReadOnly Property available() As Integer
        Get
            Return stcpclient.Available
        End Get
    End Property

    Public ReadOnly Property tcpclient() As TcpClient
        Get
            Return stcpclient
        End Get
    End Property

    Public Property nodelay() As Boolean
        Get
            Return stcpclient.NoDelay
        End Get
        Set(ByVal value As Boolean)
            stcpclient.NoDelay = value
        End Set
    End Property

    Public Property sendtimeout() As Integer
        Get
            Return stcpclient.SendTimeout
        End Get
        Set(ByVal value As Integer)
            stcpclient.SendTimeout = value
        End Set

    End Property
    Public Property receivetimeout() As Integer
        Get
            Return stcpclient.ReceiveTimeout
        End Get
        Set(ByVal value As Integer)
            stcpclient.ReceiveTimeout = value
        End Set
    End Property

    Public Property sendbuffersize() As Integer
        Get
            Return stcpclient.SendBufferSize
        End Get
        Set(ByVal value As Integer)
            stcpclient.SendBufferSize = value
        End Set

    End Property
    Public Property receivebuffersize() As Integer
        Get
            Return stcpclient.ReceiveBufferSize
        End Get
        Set(ByVal value As Integer)
            stcpclient.ReceiveBufferSize = value
        End Set
    End Property
End Class
