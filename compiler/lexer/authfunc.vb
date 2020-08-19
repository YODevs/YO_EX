Imports System.IO

Public Class authfunc
    Public Shared Function get_line_code(path As String, line As Integer) As String
        If File.Exists(path) Then
            Dim fsource As String = File.ReadAllText(path)
            Dim splsource() As String = fsource.Split(Chr(10)).ToArray
            line -= 2
            If line <= splsource.Length - 1 Then
                Return splsource(line)
            Else
                dserr.new_error(conserr.errortype.RUNTIMEERROR, -1, path, "There is no line credit.")
            End If
        Else
            dserr.new_error(conserr.errortype.YOFILENOTFOUND, -1, path, "path => " & path)
            Return conrex.NULL
        End If
        Return conrex.NULL
    End Function

    Public Shared Function get_line_error(path As String, linecinf As lexer.targetinf, errtoken As String)
        Dim code As String = get_line_code(path, linecinf.line + 1) & vbCrLf
        Dim startindexof As Integer = code.IndexOf(errtoken)
        Dim excreviewer As String = Space(startindexof)
        For index = 0 To errtoken.Length - 1
            excreviewer &= conrex.CURSORERR
        Next
        Return code & vbCr & excreviewer
    End Function

    Public Shared Function check_identifier_vaild(value As String) As Boolean
        If IsNumeric(value(0)) Then Return False
        For index = 0 To value.Length - 1
            Dim getasciicode As Integer = Asc(value(index))
            If getasciicode >= 97 AndAlso getasciicode <= 122 OrElse getasciicode = 95 OrElse getasciicode >= 48 AndAlso getasciicode <= 58 Then
                Continue For
            Else
                Return False
            End If
        Next
        Return True
    End Function

    Public Shared Function check_sym_lex(value As String) As Boolean
        value = value.ToLower
        For index = 0 To value.Length - 1
            Dim getasciicode As Integer = Asc(value(index))
            If getasciicode >= 97 AndAlso getasciicode <= 122 Or getasciicode = 95 Then
                Return False
            Else
                Continue For
            End If
        Next
        Return True
    End Function

    Public Shared Function bp_xml_injection(value As String) As String
        For index = 0 To conrex.specificxmlchar.Length - 1
            Dim getspecificchar As Char = conrex.specificxmlchar(index)
            If value.Contains(getspecificchar) Then
                value = value.Replace(getspecificchar, "#SPCH:" & conrex.specificrandomnumber & "-" & Asc(getspecificchar) & "#")
            End If
        Next
        Return value
    End Function

    Public Shared Function rev_xml_injection(value As String) As String
        For index = 0 To conrex.specificxmlchar.Length - 1
            Dim getspecificchar As Char = conrex.specificxmlchar(index)
            Dim decspecific As String = "#SPCH:" & conrex.specificrandomnumber & "-" & Asc(getspecificchar) & "#"
            If value.Contains("#SPCH:") Then
                value = value.Replace(decspecific, getspecificchar)
            End If
        Next
        Return value
    End Function

    Public Shared Sub set_name_token_format(ByRef tknfmtclass As tknformat._class)
        Dim paradata As String = tknfmtclass.location
        paradata = paradata.Remove(0, paradata.LastIndexOf("\") + 1)
        paradata = paradata.Remove(paradata.LastIndexOf("."))

        paradata = paradata.Replace(conrex.SPACE, "_")
        tknfmtclass.name = paradata
    End Sub

    Public Shared Sub rem_fr_and_en(ByRef value As String)
        value = value.Remove(0, 1)
        value = value.Remove(value.Length - 1)
    End Sub
End Class
