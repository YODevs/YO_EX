Imports System.IO
Imports System.Net

Public Class http

    Public webreq As HttpWebRequest
    Public webres As WebResponse
    Public statuscode As Int32
    Public charset, contentencoding, contentlength, contenttype, method, server, protocolversion, status, isfromcache As String
    Public Sub New()
        ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
    End Sub

    Public Function send(url As String) As String
        webreq = HttpWebRequest.Create(url)
        Return get_response_stream(webreq.GetResponse())
    End Function

    Public Function send(uri As Uri) As String
        webreq = HttpWebRequest.Create(uri)
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
End Class
