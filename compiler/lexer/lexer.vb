Imports System.IO

Public Class lexer
    Public Sub New(file As String)
        fsource = import_source(file)
        sfile = file
    End Sub


    Private ReadOnly fsource As String
    Public ReadOnly Property source() As String
        Get
            Return fsource
        End Get
    End Property
    Private ReadOnly sfile As String
    Public ReadOnly Property fileloc() As String
        Get
            Return sfile
        End Get
    End Property

    Private Function import_source(path As String) As String
        If File.Exists(path) Then
            Return File.ReadAllText(path)
        Else
            dserr.new_error(conserr.errortype.YOFILENOTFOUND, "path => " & Dir())
        End If
        Return conrex.NULL
    End Function
End Class
