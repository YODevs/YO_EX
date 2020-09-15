Public Class bodyformatter

    Private Structure blockinf
        Dim istart As Integer
        Dim iend As Integer
        Dim name As String
        Dim datafmt As String
        Dim path As String
    End Structure

    Dim blockinfo As blockinf
    Public xmlresult As String = String.Empty
    Public Sub New(blockname As String, sourcelocation As String)
        blockinfo.name = blockname
        blockinfo.istart = 0
        blockinfo.iend = 0
        blockinfo.path = sourcelocation
    End Sub

    Public Function new_token_shared(value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf) As Boolean
        Static iline As Integer = linecinf.line
        If blockinfo.datafmt = conrex.NULL Then
            init_format()
        End If

        If rd_token = tokenhared.token.BLOCKOPEN Then
            If blockinfo.istart = 0 Then
                imp_token("<block path = '" & blockinfo.path & "'>")
            Else
                imp_token("<blockop id = '" & blockinfo.istart & "'>")
            End If
            blockinfo.istart += 1
            Return False
        ElseIf rd_token = tokenhared.token.BLOCKEND Then
            If blockinfo.istart = blockinfo.iend + 1 Then
                imp_token("</block>")
                'Create a log , data file [xml output].
                coutputdata.write_data(blockinfo.datafmt)
                xmlresult = blockinfo.datafmt
                Return True
            Else
                imp_token("</blockop>")
                blockinfo.iend += 1
                Return False
            End If
        End If

        If linecinf.line <> iline Then
            imp_token("<NEWLINE curline = '" & linecinf.line & "'></NEWLINE>")
            iline = linecinf.line
        End If

        If value.Length = 1 AndAlso tokenhared.check_opt(value) Or value = "::" Then
            value = authfunc.bp_xml_injection(value)
            imp_formatting_token("OPT", value, rd_token, linecinf)
            Return False
        End If

        value = authfunc.bp_xml_injection(value)

        Select Case rd_token
            Case tokenhared.token.IDENTIFIER
                imp_formatting_token("IDENTIFIER", value, rd_token, linecinf)
            Case tokenhared.token.TYPE_CO_STR
                imp_formatting_token("COSTR", value, rd_token, linecinf)
            Case tokenhared.token.TYPE_DU_STR
                imp_formatting_token("CUSTR", value, rd_token, linecinf)
            Case tokenhared.token.TYPE_INT
                imp_formatting_token("INTEGER", value, rd_token, linecinf)
            Case tokenhared.token.TYPE_FLOAT
                imp_formatting_token("FLOAT", value, rd_token, linecinf)
            Case tokenhared.token.COMMONDATATYPE
                imp_formatting_token("CDTY", value, rd_token, linecinf)
            Case tokenhared.token.EXPRESSION
                imp_formatting_token("EXPR", value, rd_token, linecinf)
            Case tokenhared.token.CIL_BLOCK
                imp_formatting_token("CIL", value, rd_token, linecinf)
            Case Else
                If tokenhared.check_keyword(value) <> tokenhared.token.UNDEFINED Then
                    imp_formatting_token([Enum].GetName(GetType(tokenhared.token), rd_token), value, rd_token, linecinf)
                    Exit Select
                End If
                dserr.new_error(conserr.errortype.SYNTAXERROR, linecinf.line, blockinfo.path, authfunc.get_line_error(blockinfo.path, linecinf, value))
        End Select

        Return False
    End Function

    Private Sub imp_formatting_token(name As String, value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf)
        Dim linecode As String = "<" & name & " id='" & rd_token & "' line='" & linecinf.line & "' ist='" & linecinf.lstart & "' ien='" & linecinf.lend & "' ile='" & linecinf.length & "'>" & value & "</" & name & ">"
        imp_token(linecode)
    End Sub

    Private Sub imp_token(linecode As String)
        blockinfo.datafmt &= linecode
    End Sub

    Private Sub init_format()
        blockinfo.datafmt = "<?xml version='1.0' encoding='UTF-8' ?>" & vbCr
    End Sub
End Class
