﻿Imports System.IO
Imports System.Net

Public Class http
    Private subthread As System.Threading.Thread
    Public backupwebreq As HttpWebRequest
    Public webreq As HttpWebRequest
    Public webres As WebResponse
    Public statuscode As Int32
    Public charset, contentencoding, contentlength, contenttype, method, server, protocolversion, status, isfromcache As String
    Public Event on_response(responsedata As String)
    Public Sub New()
        ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
        backupwebreq = HttpWebRequest.Create("http://localhost/")
        backupwebreq.Headers = New WebHeaderCollection
    End Sub

    Public Sub add_header(headers As map)
        Dim size As Integer = headers.size - 1
        For index = 0 To size
            Dim key, value As String
            headers.get_map(index, key, value)
            add_header(key, value)
        Next
    End Sub

    Public Sub add_header(key As String, value As String)
        backupwebreq.Headers.Add(key, value)
    End Sub

    Public Function send(url As String) As String
        webreq = HttpWebRequest.Create(url)
        set_properties()
        Return get_response_stream(webreq.GetResponse())
    End Function

    Public Sub send2(url As String)
        subthread = New System.Threading.Thread(AddressOf send_async)
        subthread.Start(url)
    End Sub

    Private Sub send_async(url As String)
        RaiseEvent on_response(send(url))
    End Sub

    Public Function send_post(url As String, postdata As String) As String
        Dim postdatabyte As Byte() = encoding.utf8_get_bytes(postdata)
        Return send_post(url, postdatabyte)
    End Function
    Public Sub send_post2(url As String, postdata As String)
        Dim param(2) As Object
        param(0) = url
        param(1) = postdata
        subthread = New System.Threading.Thread(AddressOf send_post_async)
        subthread.Start(param)
    End Sub

    Private Sub send_post_async(param() As Object)
        RaiseEvent on_response(send_post(param(0).ToString, param(1).ToString))
    End Sub

    Public Function send_post(url As String, postdata() As Byte) As String
        webreq = HttpWebRequest.Create(url)
        set_properties()
        webreq.Method = "POST"
        webreq.ContentType = "application/x-www-form-urlencoded"
        webreq.ContentLength = postdata.Length
        Dim stream As Stream = webreq.GetRequestStream()
        stream.Write(postdata, 0, postdata.Length)
        stream.Close()
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
