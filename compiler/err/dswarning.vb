Public Class dswar

    Structure warstruct
        Dim title As String
        Dim description As String
        Dim file As String
        Dim line As Integer
    End Structure

    Private Shared war() As warstruct
    Friend Shared Sub set_warning(title As String, description As String, Optional file As String = conrex.NULL, Optional line As String = conrex.NULL)
        Static Dim indexarray As Int16 = 0
        Array.Resize(war, indexarray + 1)
        war(indexarray) = New warstruct
        war(indexarray).title = title
        war(indexarray).description = description
        war(indexarray).line = line
        war(indexarray).file = file
        indexarray += 1
        Return
    End Sub

    Friend Shared Sub show_warning()
        If war.Length = 0 Then Return
        Console.Write("-Warnings")
        For index = 0 To war.Length - 1
            Console.ForegroundColor = ConsoleColor.DarkYellow
            Console.Write(vbCrLf & index + 1 & ")" & war(index).title)
            Console.ResetColor()
            Console.Write(" : " & war(index).description)
            If war(index).file <> conrex.NULL Then
                Console.Write(vbLf & "FILE : " & war(index).file)
                If war(index).line <> conrex.NULL Then
                    Console.Write(" - LINE(" & war(index).line & ")")
                End If
            End If
        Next
        Console.WriteLine()
    End Sub

End Class
