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
    Public Sub New(xmlfmt As String)
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

    Public Function get_line_tokens() As linecodestruc()
        Dim clinecodestruct(0) As linecodestruc
        Dim isnewline As Boolean = False
        Dim index As Integer = 0
        Do
            clinecodestruct(index) = next_token(isnewline)
            If isnewline = True Or xmlreader.EOF Then
                If index = 0 AndAlso xmlreader.EOF = False Then
                    Continue Do
                End If
                Array.Resize(clinecodestruct, clinecodestruct.Length)
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
                    If xmlreader.Name <> "NEWLINE" Then
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

    Public Sub close()
        xmlreader.Close()
    End Sub
End Class
