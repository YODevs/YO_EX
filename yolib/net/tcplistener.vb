Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class tcplistener
    Dim stcplistener As System.Net.Sockets.TcpListener
    Dim listofclients As New List(Of TcpClient)
    Dim ipset As IPAddress
    Dim host As String, port As Integer
    Public thgetdatagram As System.Threading.Thread
    Public Sub New(host As String, port As Integer)
        Me.host = host
        Me.port = port
        ipset = IPAddress.Parse(host)
        stcplistener = New System.Net.Sockets.TcpListener(ipset, port)
    End Sub
    Public Sub New(port As Integer)
        Me.New("127.0.0.1", port)
    End Sub

    Public Sub start()
        Try
            stcplistener.Start()
            Threading.ThreadPool.QueueUserWorkItem(AddressOf message_listener)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub message_listener()
        Dim tcpclient As TcpClient = stcplistener.AcceptTcpClient
        Try
            Threading.ThreadPool.QueueUserWorkItem(AddressOf message_listener)
            Dim networkstream As NetworkStream = tcpclient.GetStream()
            Dim streader As New IO.StreamReader(networkstream)
            Dim sbuilder As New StringBuilder
            While streader.Peek > -1
                sbuilder.Append(Convert.ToChar(streader.Read()).ToString)
            End While
            Dim message As String = sbuilder.ToString
            Dim response As String = String.Empty
            RaiseEvent on_message(message, response)
            Dim sbytes As [Byte]() = encoding.ascii_get_bytes(response)
            networkstream.Write(sbytes, 0, sbytes.Length)
        Catch ex As Exception

        End Try
    End Sub

    Public Event on_message(message As String, ByRef responsemessage As String)

End Class
