Imports System.Net
Imports System.Net.Sockets

Public Class udp
    Dim udp As UdpClient
    Dim ipset As IPAddress
    Dim ip As String, port As Integer
    Public thgetdatagram As System.Threading.Thread
    Public ipendpoint As System.Net.IPEndPoint
    Private datalist As YOLIB.list
    Private _hasdata As Boolean = False
    Private _latestdata As String = String.Empty
    Public Sub New(ip As String, port As Integer)
        Me.ip = ip
        Me.port = port
        ipset = IPAddress.Parse(ip)
        udp = New UdpClient
        ipendpoint = New System.Net.IPEndPoint(System.Net.IPAddress.Any, 0)
        datalist = New list
    End Sub

    Public Sub send(text As String)
        Dim datagram As Byte()
        datagram = encoding.ascii_get_bytes(text)
        udp.Connect(ipset, port)
        udp.Send(datagram, datagram.Length)
    End Sub

    Public Sub listen(port As Integer)
        udp = New UdpClient(port)
        thgetdatagram = New System.Threading.Thread(AddressOf get_datagrams_event)
        thgetdatagram.Start()
    End Sub

    Private Sub get_datagrams_event()
        Dim recbytes As [Byte]() = udp.Receive(ipendpoint)
        Dim getdata As String = System.Text.Encoding.ASCII.GetChars(recbytes)
        If IsNothing(datalist) Then datalist = New list()
        datalist.add(getdata)
        _hasdata = True
        _latestdata = getdata
        thgetdatagram = New System.Threading.Thread(AddressOf get_datagrams_event)
        thgetdatagram.Start()
    End Sub

    Public ReadOnly Property has_data() As Boolean
        Get
            If IsNothing(udp) Then Return False
            Return _hasdata
        End Get
    End Property

    Public ReadOnly Property latest_data() As String
        Get
            If _hasdata = False Then
                Return String.Empty
            Else
                _hasdata = False
                Return _latestdata
            End If
        End Get
    End Property
End Class
