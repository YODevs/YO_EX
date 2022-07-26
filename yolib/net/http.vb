Imports System.IO
Imports System.Net

Public Class http

    Public backupwebreq As HttpWebRequest
    Public webreq As HttpWebRequest
    Public webres As WebResponse
    Public statuscode As Int32
    Public charset, contentencoding, contentlength, contenttype, method, server, protocolversion, status, isfromcache As String
    Public Sub New()
        ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
        backupwebreq = HttpWebRequest.Create("http://localhost/")
    End Sub

    Public Function send(url As String) As String
        webreq = HttpWebRequest.Create(url)
        set_properties()
        Return get_response_stream(webreq.GetResponse())
    End Function

    Private Sub set_properties()
        webreq.Referer = backupwebreq.Referer
        webreq.UserAgent = backupwebreq.UserAgent
        webreq.AllowAutoRedirect = backupwebreq.AllowAutoRedirect
        webreq.Timeout = backupwebreq.Timeout
        webreq.KeepAlive = backupwebreq.KeepAlive
    End Sub

    Public Function send(uri As Uri) As String
        webreq = HttpWebRequest.Create(uri)
        set_properties()
        Return get_response_stream(webreq.GetResponse())
    End Function

    Private Function get_response_stream(result As WebResponse) As String
        statuscode = CType(result, HttpWebResponse).StatusCode
        charset = CType(result, HttpWebResponse).CharacterSet
        contentlength = CType(result, HttpWebResponse).ContentLength
        contentencoding = CType(result, HttpWebResponse).ContentEncoding
        contenttype = CType(result, HttpWebResponse).ContentType
        method = CType(result, HttpWebResponse).Method
        protocolversion = CType(result, HttpWebResponse).ProtocolVersion.ToString
        server = CType(result, HttpWebResponse).Server
        status = CType(result, HttpWebResponse).StatusDescription
        isfromcache = CType(result, HttpWebResponse).IsFromCache

        If statuscode = 200 Then
            Dim sreader As New StreamReader(result.GetResponseStream())
            Return sreader.ReadToEnd()
        Else
            Return String.Empty
        End If
    End Function


#Region "Properties"

    Public Property referer() As String
        Get
            Return backupwebreq.Referer
        End Get
        Set(ByVal value As String)
            backupwebreq.Referer = value
        End Set
    End Property

    Public Property useragent() As String
        Get
            Return backupwebreq.UserAgent
        End Get
        Set(ByVal value As String)
            backupwebreq.UserAgent = value
        End Set
    End Property

    Public Property allowautorediret() As String
        Get
            Return backupwebreq.AllowAutoRedirect
        End Get
        Set(ByVal value As String)
            backupwebreq.AllowAutoRedirect = value
            Dim e As System.Diagnostics.Process
        End Set
    End Property

    Public Property timeout() As Integer
        Get
            Return backupwebreq.Timeout
        End Get
        Set(ByVal value As Integer)
            backupwebreq.Timeout = value
        End Set
    End Property

    Public Property keepalive() As Boolean
        Get
            Return backupwebreq.KeepAlive
        End Get
        Set(ByVal value As Boolean)
            backupwebreq.KeepAlive = value
        End Set
    End Property

#End Region

End Class
