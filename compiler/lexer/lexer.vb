Imports System.IO
Imports System.Text.RegularExpressions

Public Class lexer

    Enum targetaction
        NOOPERATION
        COSTRINGLOADER ' example : 'hello world !'
        EXPRESSIONLOADER ' example : [5 * (6 + 2)]
        DUCOSTRINGLOADER ' example : "hello world ! #nl"
        CILCOMMANDSLOADER ' example : < codes >
        SINGLECOMMENTLOADER ' example : #>this is a comment
        MULTILINECOMMENTLOADER ' example : #-This a comment -#
        COMPILERATTRIBUTELOADER ' example  : #[cfg::CIL(true)]
    End Enum
    Structure targetinf
        Dim length As Integer
        Dim lstart, lend As Integer
        Dim line As Integer
    End Structure
    Public Sub New(file As String)
        fsource = import_source(file)
        sfile = file
        wfile = file
        fmtdata = New fmtshared(file)
        attribute = New attr(file)
        procresult.rp_lex_file(file)
    End Sub

    Friend Shared wfile As String
    Private strline As Integer = 0
    Private qucheck As Boolean = False
    Public fmtdata As fmtshared
    Public attribute As attr
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
            dserr.new_error(conserr.errortype.YOFILENOTFOUND, 0, sfile, "path => " & Dir())
        End If
        Return conrex.NULL
    End Function

    Public Sub lexme(ByRef tknfmtclass As tknformat._class)
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

            If chstatusaction = targetaction.NOOPERATION AndAlso check_target_action(getch, index, chstatusaction, linecinf.line) Then
                slinegrab = String.Empty
                linecinf.lstart = index
                strline = linecinf.line
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
                            Dim afline As Integer = linecinf.line
                            linecinf.line = strline
                            check_token(linecinf, linec)
                            linecinf.line = afline
                            slinegrab = conrex.NULL
                        End If
                    Case targetaction.DUCOSTRINGLOADER
                        If get_du_string(getch, linecinf, slinegrab, chstatusaction, (fsourcelen = index)) Then
                            linecinf.lend = index - 1
                            linecinf.length = slinegrab.Length
                            linec = slinegrab
                            Dim afline As Integer = linecinf.line
                            linecinf.line = strline
                            check_token(linecinf, linec)
                            linecinf.line = afline
                            slinegrab = conrex.NULL
                        End If
                    Case targetaction.CILCOMMANDSLOADER
                        If get_cil_commands(getch, linecinf, slinegrab, chstatusaction, (fsourcelen = index)) Then
                            linecinf.lend = index - 1
                            linecinf.length = slinegrab.Length
                            linec = slinegrab
                            Dim afline As Integer = linecinf.line
                            linecinf.line = strline
                            check_token(linecinf, linec)
                            linecinf.line = afline
                            slinegrab = conrex.NULL
                        End If
                    Case targetaction.EXPRESSIONLOADER
                        If get_expression(getch, slinegrab, chstatusaction) Then
                            If IsNothing(linec) = False Then
                                linec &= slinegrab
                                linecinf.lend += index - 1
                                linecinf.length += slinegrab.Length
                            Else
                                linecinf.lend = index - 1
                                linecinf.length = slinegrab.Length
                                linec = slinegrab
                            End If
                            Dim afline As Integer = linecinf.line
                            linecinf.line = strline
                            If nextchar(index) = conrex.CLN AndAlso nextchar(index + 1) = conrex.CLN AndAlso Regex.IsMatch(linec, conrex.ARRMETHODREGEX) Then
                                Continue For
                            End If
                            check_token(linecinf, linec)
                            linecinf.line = afline
                            slinegrab = conrex.NULL
                        End If
                    Case targetaction.COMPILERATTRIBUTELOADER
                        If get_compiler_attribute(getch, slinegrab, chstatusaction) Then
                            linecinf.lend = index - 1
                            linecinf.length = slinegrab.Length
                            linec = slinegrab
                            Dim afline As Integer = linecinf.line
                            linecinf.line = strline
                            check_token(linecinf, linec)
                            linecinf.line = afline
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


            If check_method(getch, linec, index) Then
                Continue For
            ElseIf tokenhared.check_opt(getch) Then

                If linec = conrex.NULL Then
                    linecinf.lend = index - 1
                    linecinf.length = 1
                    linec = getch
                    If linec = "-" AndAlso IsNumeric(nextchar(index)) Then
                        Continue For
                    End If
                    check_token(linecinf, linec, index)
                    Continue For
                Else
                    linecinf.lend = index - 1
                    linecinf.length = linec.Length
                End If
                If getch = "." AndAlso IsNumeric(linec) Then
                    linec &= getch
                    Continue For
                End If
                check_token(linecinf, linec, index)
                linec = getch
                check_token(linecinf, linec, index)
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
                    check_token(linecinf, linec, index)
                    linecinf.line += 1
                Case Chr(13)
                    Continue For
                Case Else
                    linec &= getch
            End Select

            If fsourcelen = index Then
                check_token(linecinf, linec, index)
            End If
        Next

        tknfmtclass = fmtdata._to_organize()
        tknfmtclass.location = sfile
        tknfmtclass.attribute = attribute.get_attribute()
        tknfmtclass.externlist = fmtdata.externlist
        authfunc.set_name_token_format(tknfmtclass)

        procresult.rs_proc_data(True)
    End Sub

    Private Function check_method(getch As Char, ByRef slinegrab As String, index As Integer) As Boolean
        If getch = ":" Then
            If nextchar(index) = ":" OrElse pervchar(index) = ":" Then
                slinegrab &= getch
                Return True
            Else
                Return False
            End If
        ElseIf getch = "." AndAlso IsNumeric(slinegrab) = False Then
            slinegrab &= getch
            Return True
        Else
            Return False
        End If
    End Function

    Private Function get_co_string(getch As Char, linecinf As targetinf, ByRef slinegrab As String, ByRef chstatus As targetaction, lastchar As Boolean) As Boolean
        If slinegrab.StartsWith(conrex.COSTR) AndAlso getch = conrex.COSTR Then
            If slinegrab(slinegrab.Length - 1) <> conrex.BKSLASH Then
                chstatus = targetaction.NOOPERATION
                slinegrab &= getch
                Return True
            Else
                slinegrab = slinegrab.Remove(slinegrab.Length - 1)
                slinegrab &= getch
                Return False
            End If
        ElseIf lastchar Then
            slinegrab &= getch
            dserr.new_error(conserr.errortype.STRINGCOENDWITH, linecinf.line, sfile, "error in line : " & linecinf.line & " -> " & slinegrab, "print 'Hello World!'")
        End If
        slinegrab &= getch
        Return False
    End Function

    Private Function get_du_string(getch As Char, linecinf As targetinf, ByRef slinegrab As String, ByRef chstatus As targetaction, lastchar As Boolean) As Boolean
        If slinegrab.StartsWith(conrex.DUSTR) AndAlso getch = conrex.DUSTR Then
            If slinegrab(slinegrab.Length - 1) <> conrex.BKSLASH Then
                chstatus = targetaction.NOOPERATION
                slinegrab &= getch
                Return True
            Else
                slinegrab = slinegrab.Remove(slinegrab.Length - 1)
                slinegrab &= getch
                Return False
            End If
        ElseIf lastchar Then
            slinegrab &= getch
            dserr.new_error(conserr.errortype.STRINGDUENDWITH, linecinf.line, sfile, "error in line : " & linecinf.line & " -> " & slinegrab, "print ""Hello World!""")
        End If
        slinegrab &= getch
        Return False
    End Function

    Private Function get_cil_commands(getch As Char, linecinf As targetinf, ByRef slinegrab As String, ByRef chstatus As targetaction, lastchar As Boolean) As Boolean
        Static Dim industrcode As Boolean = False

        If industrcode = False AndAlso getch = conrex.DUSTR Then
            industrcode = True
        ElseIf industrcode = True AndAlso getch = conrex.DUSTR Then
            industrcode = False
        End If
        If getch = conrex.LTLEF AndAlso industrcode = False Then
            chstatus = targetaction.NOOPERATION
            slinegrab &= getch
            Return True
        ElseIf lastchar Then
            slinegrab &= getch
            dserr.new_error(conserr.errortype.CILCOMMANDSENDWITH, linecinf.line, sfile, "error in line : " & linecinf.line & " -> " & slinegrab)
        End If
        slinegrab &= getch
        Return False
    End Function

    Private Function get_compiler_attribute(getch As Char, ByRef slinegrab As String, ByRef chstatus As targetaction) As Boolean
        slinegrab &= getch
        If getch = "]" Then
            chstatus = targetaction.NOOPERATION
            Return True
        End If
        Return False
    End Function

    Private Function get_expression(getch As Char, ByRef slinegrab As String, ByRef chstatus As targetaction) As Boolean
        slinegrab &= getch
        If getch = "]" Then
            chstatus = targetaction.NOOPERATION
            Return True
        End If
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
        If pervchar(index) = "-" AndAlso getch = "#" AndAlso slinegrab <> "#-#" Or lastchar = True Then
            chstatus = targetaction.NOOPERATION
            slinegrab = String.Empty
        End If
    End Sub
    Private Sub check_token(ByRef linecinf As targetinf, ByRef linec As String, Optional index As Integer = -1)
        If IsNothing(linec) OrElse linec.Trim = conrex.NULL Then
            linecinf.lstart = -1
            linec = conrex.NULL
            Return
        End If

        rd_token = tokenhared.token.UNDEFINED

        If qucheck = False AndAlso linec = ":" AndAlso nextchar(index) = ":" Then
            qucheck = True
            linecinf.lstart = -1
            linec = conrex.NULL
            Return
        ElseIf qucheck = True Then
            linec &= ":"
            linecinf.lstart -= 1
            linecinf.length += 1
            qucheck = False
        End If

        If linec.Length = 1 Then
            linecinf.lstart = index
            linecinf.lend = index + 1
            linecinf.length = 1
        End If

        Select Case True

            Case rev_co_string(linec)

            Case rev_du_string(linec)

            Case rev_compiler_attribute(linec)

            Case rev_expression(linec)

            Case rev_sym(linec, linecinf)

            Case rev_cil_code_block(linec)

            Case rev_numeric(linec, linecinf)

            Case rev_keywords(linec, linecinf)

        End Select

        If rd_token = tokenhared.token.UNDEFINED Then
            dserr.args.Add("Token not detected.")
            dserr.new_error(conserr.errortype.SYNTAXERROR, linecinf.line, sfile, authfunc.get_line_error(sfile, linecinf, linec))
            Return
        End If

        'print tokens
        If compdt.DISPLAYTOKENWLEX Then displaytokens(rd_token, linec)

        Select Case rd_token
            Case tokenhared.token.COMPILERATTRIBUTE
                attribute.parse_attribute(linec, linecinf)
            Case Else
                fmtdata.imp_token(linec, rd_token, linecinf)
        End Select

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
        If value.StartsWith(conrex.DLR) Then
            rd_token = tokenhared.token.LABELJMP
            Return True
        ElseIf value.Length <= 4 Then
            rd_token = tokenhared.check_common_type(value)
            If rd_token <> tokenhared.token.UNDEFINED Then
                Return True
            End If
        End If
        rd_token = tokenhared.check_keyword(value.ToLower)
        If rd_token = tokenhared.token.UNDEFINED Then
            If authfunc.check_identifier_vaild(value.ToLower) Then
                rd_token = tokenhared.token.IDENTIFIER
                Return True
            ElseIf authfunc.check_arriden_vaild(value.ToLower) Then
                rd_token = tokenhared.token.ARR
                Return True
            Else
                rd_token = tokenhared.token.UNDEFINED
                dserr.new_error(conserr.errortype.IDENTIFIERUNKNOWN, linecinf.line, sfile, authfunc.get_line_error(sfile, linecinf, value), "name / mycity2 / get_name")
                Return False
            End If
        End If
        Return True
    End Function
    Private Function rev_numeric(ByRef value As String, ByRef linecinf As targetinf) As Boolean
        If IsNumeric(value) Then
            If authfunc.check_integral_overflow(CObj(value)) Then
                rd_token = tokenhared.token.UNDEFINED
                dserr.args.Add(value)
                dserr.new_error(conserr.errortype.INTEGRALOVERFLOW, linecinf.line, sfile, authfunc.get_line_error(sfile, linecinf, value))
            End If
            rd_token = tokenhared.token.TYPE_INT
            If value.Contains(conrex.DOT) Then
                If value(value.Length - 1) <> conrex.DOT AndAlso value.Count(Function(nindex) nindex = conrex.DOT) = 1 Then
                    rd_token = tokenhared.token.TYPE_FLOAT
                    Return True
                Else
                    rd_token = tokenhared.token.UNDEFINED
                    dserr.new_error(conserr.errortype.TYPEERRORNUMERIC, linecinf.line, sfile, authfunc.get_line_error(sfile, linecinf, value), "3.14 / 54.545_152")
                End If
            End If
            Return True
        End If
        Return False
    End Function
    Private Function rev_cil_code_block(ByRef value As String) As Boolean
        If value.StartsWith(conrex.BTRIG) AndAlso value.EndsWith(conrex.LTLEF) Then
            rd_token = tokenhared.token.CIL_BLOCK
            Return True
        End If
        Return False
    End Function

    Private Function rev_compiler_attribute(ByRef value As String) As Boolean
        If value.StartsWith("#[") AndAlso value.EndsWith("]") Then
            rd_token = tokenhared.token.COMPILERATTRIBUTE
            Return True
        End If
        Return False
    End Function
    Private Function rev_expression(ByRef value As String) As Boolean
        If value.StartsWith("[") AndAlso value.EndsWith("]") Then
            If value.Contains(conrex.DBDOT) = False Then
                If rev_typecasting(value) Then
                    rd_token = tokenhared.token.EXPLTYPECAST
                    Return True
                End If
                For index = 0 To compdt.expressionact.Length - 1
                    If value.Contains(compdt.expressionact(index)) Then
                        rd_token = tokenhared.token.EXPRESSION
                        Return True
                    End If
                Next
            Else
                If rev_range(value) Then
                    rd_token = tokenhared.token.RANGE
                    Return True
                End If
            End If
            Return False
        End If
        Return False
    End Function
    Private Function rev_typecasting(value As String) As Boolean
        authfunc.rem_fr_and_en(value)
        If value.ToLower.Trim = conrex.BOX Then
            Return True
        End If
        Return servinterface.is_common_data_type(value, Nothing)
    End Function
    Private Function rev_range(value As String) As Boolean
        If value.Contains(conrex.DBDOT) Then
            Return Regex.IsMatch(value, compdt.RANGEFMT)
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
    Public Function check_target_action(getch As Char, index As Integer, ByRef chstatus As lexer.targetaction, line As Integer) As Boolean
        Select Case getch
            Case "#"
                Select Case nextchar(index)
                    Case ">"
                        chstatus = targetaction.SINGLECOMMENTLOADER
                        Return True
                    Case "-"
                        chstatus = targetaction.MULTILINECOMMENTLOADER
                        Return True
                    Case "["
                        chstatus = targetaction.COMPILERATTRIBUTELOADER
                        Return True
                End Select
            Case "["
                chstatus = targetaction.EXPRESSIONLOADER
                Return True
            Case conrex.COSTR
                chstatus = targetaction.COSTRINGLOADER
                Return True
            Case conrex.DUSTR
                chstatus = targetaction.DUCOSTRINGLOADER
                Return True
            Case conrex.BTRIG
                Dim getline As String = authfunc.get_line_code(sfile, line + 1).Trim
                If getline.StartsWith(conrex.BTRIG) Then
                    chstatus = targetaction.CILCOMMANDSLOADER
                    Return True
                Else
                    Return False
                End If
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

    Friend Shared Function is_expression(value As String) As Boolean
        If value.StartsWith("[") AndAlso value.EndsWith("]") Then
            If value.Contains(conrex.DBDOT) = False Then
                For index = 0 To compdt.expressionact.Length - 1
                    If value.Contains(compdt.expressionact(index)) Then
                        Return True
                    End If
                Next
            End If
        End If
        Return False
    End Function
End Class
