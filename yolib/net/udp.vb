Imports System.Net
Imports System.Net.Sockets

Public Class udp
    Dim udp As UdpClient
    Dim ipset As IPAddress
    Dim ip As String, port As Integer
    Public Sub New(ip As String, port As Integer)
        Me.ip = ip
        Me.port = port
        ipset = IPAddress.Parse(ip)
        udp = New UdpClient
    End Sub

    Public Sub send(text As String)
        Dim datagram As Byte()
        datagram = encoding.ascii_get_bytes(text)
        udp.Connect(ipset, port)
        udp.Send(datagram, datagram.Length)
    End Sub
End Class
