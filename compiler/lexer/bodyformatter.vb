Public Class bodyformatter

    Private Structure blockinf
        Dim istart As Integer
        Dim iend As Integer
        Dim name As String
        Dim datafmt As String
    End Structure

    Dim blockinfo As blockinf
    Public Sub New(blockname As String)
        blockinfo.name = blockname
        blockinfo.istart = 0
        blockinfo.iend = 0
    End Sub

    Public Function new_token_shared(value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf) As Boolean
        If blockinfo.datafmt = conrex.NULL Then
            init_format()
        End If

        If rd_token = tokenhared.token.BLOCKOPEN AndAlso blockinfo.istart = 0 Then
            imp_token("<block>")
            blockinfo.istart += 1
            Return False
        ElseIf rd_token = tokenhared.token.BLOCKEND AndAlso blockinfo.istart = blockinfo.iend + 1 Then
            imp_token("</block>")
            'Create a log , data file [xml output].
            coutputdata.write_data(blockinfo.datafmt)
            Return True
        End If

        Select Case rd_token
            Case tokenhared.token.IDENTIFIER
                imp_formatting_token("IDENTIFIER", value, rd_token, linecinf)
            Case tokenhared.token.TYPE_CO_STR
                'TODO : FIX : XML INJECTION ...
                imp_formatting_token("COSTR", value, rd_token, linecinf)
            Case tokenhared.token.TYPE_DU_STR
                'TODO : FIX : XML INJECTION ...
                imp_formatting_token("CUSTR", value, rd_token, linecinf)
            Case tokenhared.token.TYPE_INT
                imp_formatting_token("INTEGER", value, rd_token, linecinf)
            Case tokenhared.token.TYPE_FLOAT
                imp_formatting_token("FLOAT", value, rd_token, linecinf)
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
