Imports System.IO

Public Class lexer

    Structure targetinf
        Dim length As Integer
        Dim lstart, lend As Integer
    End Structure
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

    Public Sub lexme()
        Dim fsourcelen As Integer = fsource.Length - 1
        Dim getch As Char = conrex.NULL
        Dim linec As String = String.Empty
        Dim linecinf As New targetinf
        linecinf.lstart = 0
        For index = 0 To fsourcelen
            getch = fsource(index)
            If linecinf.lstart = -1 AndAlso getch <> conrex.SPACE Then
                linecinf.lstart = index
            End If

            Select Case getch
                Case conrex.SPACE
                    linecinf.lend = index - 1
                    linecinf.length = linec.Length
                    check_token(linecinf, linec)
                Case Chr(10)
                    linecinf.lend = index - 1
                    linecinf.length = linec.Length
                    check_token(linecinf, linec)
                Case Chr(13)
                    Continue For
                Case Else
                    linec &= getch
            End Select

            If fsourcelen = index Then
                check_token(linecinf, linec)
            End If
        Next
    End Sub

    Private Sub check_token(ByRef linecinf As targetinf, ByRef linec As String)
        linecinf.lstart = -1
        linec = conrex.NULL
    End Sub



End Class
