Imports System.Xml

Public Class xmlunpkd

    Public bodyxmlfmt As String
    Public path As String = Nothing
    Public xmlreader As XmlReader

    Public Structure linecodestruc
        Dim name As String
        Dim value As String
        Dim tokenid As Integer
        Dim line As Integer
        Dim ist, ien, ile As Integer
    End Structure

    Public Sub New(xmlfmt As String, Optional ismainproc As Boolean = True)
        If ismainproc = False Then
            set_header(xmlfmt, ilbodybulider.path)
        End If
        bodyxmlfmt = xmlfmt
        Dim xmlrdoptions As New XmlReaderSettings
        xmlrdoptions.IgnoreComments = True
        xmlrdoptions.IgnoreWhitespace = True
        xmlrdoptions.IgnoreProcessingInstructions = True

        xmlreader = XmlReader.Create(New IO.StringReader(bodyxmlfmt), xmlrdoptions)
        xmlreader.Read()
        xmlreader.Read()
        path = xmlreader.GetAttribute("path")
    End Sub

    Public Sub set_header(ByRef xmlfmt As String, path As String)
        xmlfmt = "<?xml version='1.0' encoding='UTF-8' ?><block path = '" & path & "'>
" & xmlfmt & "</block>"
    End Sub
    Public Function get_line_tokens() As linecodestruc()
        Dim clinecodestruct(0) As linecodestruc
        Dim isnewline As Boolean = False
        Dim index As Integer = 0
        Do
            clinecodestruct(index) = next_token(isnewline)
            If isnewline = True Or xmlreader.EOF Then
                If clinecodestruct(index).tokenid = tokenhared.token.BLOCKOP Then
                    If initblockop.check_blockop_allow(clinecodestruct(0).tokenid) AndAlso clinecodestruct(0).tokenid <> tokenhared.token.BLOCKOP Then
                        Return clinecodestruct
                    Else
                        dserr.new_error(conserr.errortype.INVALIDCODEBLOCK, clinecodestruct(0).line, path, authfunc.get_line_error(path, servinterface.get_target_info(clinecodestruct(0)), clinecodestruct(0).value))
                    End If
                ElseIf index = 0 AndAlso xmlreader.EOF = False Then
                    Continue Do
                End If
                Array.Resize(clinecodestruct, clinecodestruct.Length - 1)
                Return clinecodestruct
            End If
            Array.Resize(clinecodestruct, clinecodestruct.Length + 1)
            index += 1
        Loop
    End Function

    Public Function next_token(ByRef isnewline As Boolean) As linecodestruc
        Dim tokenstruct As New linecodestruc
        While xmlreader.Read()
            Select Case xmlreader.NodeType
                Case XmlNodeType.Element
                    If xmlreader.Name = "blockop" Then
                        get_blockop(xmlreader, tokenstruct)
                        isnewline = True
                        Return tokenstruct
                    ElseIf xmlreader.Name <> "NEWLINE" Then
                        tokenstruct.name = xmlreader.Name
                        tokenstruct.line = xmlreader.GetAttribute("line")
                        tokenstruct.tokenid = xmlreader.GetAttribute("id")
                        tokenstruct.ien = xmlreader.GetAttribute("ien")
                        tokenstruct.ist = xmlreader.GetAttribute("ist")
                        tokenstruct.ile = xmlreader.GetAttribute("ile")
                        isnewline = False
                    Else
                        isnewline = True
                        Return tokenstruct
                    End If
                Case XmlNodeType.Text
                    tokenstruct.value = authfunc.rev_xml_injection(xmlreader.Value)
                    Exit While
            End Select
        End While

        isnewline = False
        Return tokenstruct
    End Function

    Private Sub get_blockop(xmlr As XmlReader, ByRef tokenstruct As linecodestruc)
        tokenstruct.name = xmlr.Name
        tokenstruct.value = xmlr.ReadInnerXml()
        tokenstruct.tokenid = tokenhared.token.BLOCKOP
        tokenstruct.ien = 0
        tokenstruct.ist = 0
        tokenstruct.ile = 0
    End Sub

    Public Sub close()
        xmlreader.Close()
    End Sub
End Class
