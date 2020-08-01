Imports System.IO

Public Class lexer

    Enum targetaction
        NOOPERATION
        COSTRINGLOADER ' example : 'hello world !'
        DUCOSTRINGLOADER ' example : "hello world ! #nl"
        SINGLECOMMENTLOADER ' example : #>this is a comment
        MULTILINECOMMENTLOADER ' example #-This a comment -#
    End Enum
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
        Dim slinegrab As String = String.Empty
        Dim linecinf As New targetinf
        Dim chstatusaction As targetaction = targetaction.NOOPERATION
        linecinf.lstart = 0
        linecinf.line = 1
        For index = 0 To fsourcelen
            getch = fsource(index)

            If chstatusaction = targetaction.NOOPERATION AndAlso check_target_action(getch, index, chstatusaction) Then
                slinegrab = String.Empty
                linecinf.lstart = index
            End If
            If chstatusaction <> targetaction.NOOPERATION Then
                Select Case chstatusaction
                    Case targetaction.SINGLECOMMENTLOADER
                        get_single_comment(getch, slinegrab, chstatusaction, (fsourcelen = index))
                    Case targetaction.MULTILINECOMMENTLOADER
                        get_multiline_comment(index, getch, slinegrab, chstatusaction, (fsourcelen = index))
                    Case targetaction.COSTRINGLOADER
                        If get_co_string(getch, linecinf, slinegrab, chstatusaction, (fsourcelen = index)) Then
                            linecinf.lend = index - 1
                            linecinf.length = slinegrab.Length
                            linec = slinegrab
                            check_token(linecinf, linec)
                            slinegrab = conrex.NULL
                        End If
                    Case targetaction.DUCOSTRINGLOADER
                        If get_du_string(getch, linecinf, slinegrab, chstatusaction, (fsourcelen = index)) Then
                            linecinf.lend = index - 1
                            linecinf.length = slinegrab.Length
                            linec = slinegrab
                            check_token(linecinf, linec)
                            slinegrab = conrex.NULL
                        End If
                End Select
                If Chr(10) = getch Then
                    linecinf.line += 1
                End If
                Continue For
            End If

            If linecinf.lstart = -1 AndAlso getch <> conrex.SPACE Then
                linecinf.lstart = index
            End If



            If tokenhared.check_opt(getch) Then
                If linec = conrex.NULL Then
                    linecinf.lend = index - 1
                    linecinf.length = 1
                    linec = getch
                    check_token(linecinf, linec)
                    Continue For
                Else
                    linecinf.lend = index - 1
                    linecinf.length = linec.Length
                End If
                check_token(linecinf, linec)
                linec = getch
                check_token(linecinf, linec)
                Continue For
            End If

            Select Case getch
                Case Chr(10)
                    If linec = conrex.NULL Then
                        linecinf.lstart = -1
                        linec = conrex.NULL
                        linecinf.line += 1
                        Continue For
                    End If
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

    Private Function get_co_string(getch As Char, linecinf As targetinf, ByRef slinegrab As String, ByRef chstatus As targetaction, lastchar As Boolean) As Boolean
        If slinegrab.StartsWith(conrex.COSTR) AndAlso getch = conrex.COSTR Then
            chstatus = targetaction.NOOPERATION
            slinegrab &= getch
            Return True
        ElseIf lastchar Then
            slinegrab &= getch
            dserr.new_error(conserr.errortype.STRINGCOENDWITH, "error in line : " & linecinf.line & " -> " & slinegrab, "print 'Hello World!'")
        End If
        slinegrab &= getch
        Return False
    End Function

    Private Function get_du_string(getch As Char, linecinf As targetinf, ByRef slinegrab As String, ByRef chstatus As targetaction, lastchar As Boolean) As Boolean
        If slinegrab.StartsWith(conrex.DUSTR) AndAlso getch = conrex.DUSTR Then
            chstatus = targetaction.NOOPERATION
            slinegrab &= getch
            Return True
        ElseIf lastchar Then
            slinegrab &= getch
            dserr.new_error(conserr.errortype.STRINGDUENDWITH, "error in line : " & linecinf.line & " -> " & slinegrab, "print ""Hello World!""")
        End If
        slinegrab &= getch
        Return False
    End Function

    Private Sub get_single_comment(getch As Char, ByRef slinegrab As String, ByRef chstatus As targetaction, lastchar As Boolean)
        slinegrab &= getch
        If Chr(13) = getch Or Chr(10) = getch Or lastchar = True Then
            chstatus = targetaction.NOOPERATION
            slinegrab = String.Empty
        End If
    End Sub

    Private Sub get_multiline_comment(index As Integer, getch As Char, ByRef slinegrab As String, ByRef chstatus As targetaction, lastchar As Boolean)
        slinegrab &= getch
        If pervchar(index) = "-" And getch = "#" Or lastchar = True Then
            chstatus = targetaction.NOOPERATION
            slinegrab = String.Empty
        End If
    End Sub
    Private Sub check_token(ByRef linecinf As targetinf, ByRef linec As String)

        If linec.Trim = conrex.NULL Then
            linecinf.lstart = -1
            linec = conrex.NULL
            Return
        End If

        rd_token = tokenhared.token.UNDEFINED

        Select Case True

            Case rev_co_string(linec)

            Case rev_du_string(linec)

            Case rev_sym(linec, linecinf)

          '  Case rev_func(linec, linecinf)

            Case rev_numeric(linec, linecinf)

            Case rev_keywords(linec, linecinf)

        End Select

        If rd_token = tokenhared.token.UNDEFINED Then
            '    dserr.new_error(conserr.errortype.IDENTIFIERUNKNOWN, authfunc.get_line_error(sfile, linecinf, linec), "")
        End If

        'print tokens
        displaytokens(rd_token, linec)

        linecinf.lstart = -1
        linec = conrex.NULL
    End Sub

    Private Function rev_sym(ByRef value As String, ByRef linecinf As targetinf) As Boolean
        If value.Length > 2 Then Return False
        rd_token = tokenhared.check_sym(value)
        If rd_token = tokenhared.token.UNDEFINED Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function rev_func(ByRef value As String, ByRef linecinf As targetinf) As Boolean
        If value.Contains(conrex.PRSTART) = False Then Return False
        value = value.ToLower
        Dim funcio As String = value.Remove(value.IndexOf(conrex.PRSTART))
        If authfunc.check_identifier_vaild(funcio) Then
            rd_token = tokenhared.token.FUNCTIONIDENTIFIER
            Return True
        Else
            rd_token = tokenhared.token.UNDEFINED
            dserr.new_error(conserr.errortype.IDENTIFIERUNKNOWN, authfunc.get_line_error(sfile, linecinf, funcio), "sayhello('Hello World') / get_name()")
            Return False
        End If
        Return True
    End Function

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

    Private Function rev_co_string(ByRef value As String) As Boolean
        If value.StartsWith(conrex.COSTR) AndAlso value.EndsWith(conrex.COSTR) Then
            rd_token = tokenhared.token.TYPE_CO_STR
            Return True
        End If
        Return False
    End Function
    Private Function rev_du_string(ByRef value As String) As Boolean
        If value.StartsWith(conrex.DUSTR) AndAlso value.EndsWith(conrex.DUSTR) Then
            rd_token = tokenhared.token.TYPE_DU_STR
            Return True
        End If
        Return False
    End Function
    Public Function check_target_action(getch As Char, index As Integer, ByRef chstatus As lexer.targetaction) As Boolean
        Select Case getch
            Case "#"
                Select Case nextchar(index)
                    Case ">"
                        chstatus = targetaction.SINGLECOMMENTLOADER
                        Return True
                    Case "-"
                        chstatus = targetaction.MULTILINECOMMENTLOADER
                        Return True
                End Select
            Case conrex.COSTR
                chstatus = targetaction.COSTRINGLOADER
                        Return True
                    Case conrex.DUSTR
                        chstatus = targetaction.DUCOSTRINGLOADER
                        Return True
                End Select
                chstatus = targetaction.NOOPERATION
        Return False
    End Function
    Public Function nextchar(index As Integer) As Char
        If fsource.Length - 1 > index Then
            Return fsource(index + 1)
        Else
            Return Nothing
        End If
    End Function

    Public Function pervchar(index As Integer) As Char
        If fsource.Length - 1 > index AndAlso index - 1 > 0 Then
            Return fsource(index - 1)
        Else
            Return Nothing
        End If
    End Function

    Public Sub displaytokens(token As tokenhared.token, value As String)
        Console.WriteLine([Enum].GetName(GetType(tokenhared.token), token) & "[" & token & "]" & " ~> " & value)
    End Sub
End Class
