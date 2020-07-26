Imports System.IO

Public Class lexer

    Structure targetinf
        Dim length As Integer
        Dim lstart, lend As Integer
        Dim line As Integer
    End Structure
    Public Sub New(file As String)
        fsource = import_source(file)
        sfile = file
    End Sub

    Private rd_token As tokenhared.token
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
        linecinf.line = -1
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
                    linecinf.line += 1
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
        If linec.Trim = conrex.NULL Then
            linecinf.lstart = -1
            linec = conrex.NULL
            Return
        End If

        rd_token = tokenhared.token.UNDEFINED
        Select Case True
            Case rev_keywords(linec, linecinf)

            Case rev_numeric(linec, linecinf)

        End Select

        linecinf.lstart = -1
        linec = conrex.NULL
    End Sub

    Private Function rev_keywords(ByRef value As String, ByRef linecinf As targetinf) As Boolean
        value = value.ToLower
        rd_token = tokenhared.check_keyword(value)
        If rd_token = tokenhared.token.UNDEFINED Then
            If authfunc.check_identifier_vaild(value) Then
                rd_token = tokenhared.token.IDENTIFIER
                Return True
            Else
                rd_token = tokenhared.token.UNDEFINED
                dserr.new_error(conserr.errortype.IDENTIFIERUNKNOWN, authfunc.get_line_error(sfile, linecinf, value), "name / mycity2 / get_name")
                Return False
            End If
        End If

        Return True
    End Function

    Private Function rev_numeric(ByRef value As String, ByRef linecinf As targetinf) As Boolean
        If IsNumeric(value) Then
            rd_token = tokenhared.token.TYPE_INT
            If value.Contains(conrex.DOT) Then
                If value(value.Length - 1) <> conrex.DOT AndAlso value.Count(Function(nindex) nindex = conrex.DOT) = 1 Then
                    rd_token = tokenhared.token.TYPE_FLOAT
                    Return True
                Else
                    rd_token = tokenhared.token.UNDEFINED
                    dserr.new_error(conserr.errortype.TYPEERRORNUMERIC, authfunc.get_line_error(sfile, linecinf, value), "3.14 / 54.545_152")
                End If
            End If
            Return True
        End If
        Return False
    End Function
End Class
