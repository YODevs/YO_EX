Imports System.Text.RegularExpressions
Public Class YOList
    Public Shared cursor As String = "->"
    Public Shared Function ShowMenu(items As String) As Object
        Dim menuIndex As Short = 0
        Dim key As ConsoleKeyInfo
        Dim caption As String
        Dim yodaformat As New YODA.YODA_Format
        Dim menuItems() As Object = yodaformat.ReadYODA(items).ToArray
        Dim staticCursorTop As Integer = Console.CursorTop
        Do
            Console.CursorTop = staticCursorTop
            caption = String.Empty
            For index = 0 To menuItems.Length - 1
                If menuIndex = index Then
                    caption &= vbCrLf & cursor
                    caption &= menuItems(index)
                Else
                    caption &= vbCrLf & menuItems(index) & Space(cursor.Length)
                End If
            Next
            Console.WriteLine(caption)
            key = Console.ReadKey(True)
            If key.Key.ToString() = "DownArrow" Then
                menuIndex = menuIndex + 1
                If menuIndex > menuItems.Length - 1 Then
                    menuIndex = 0
                End If
            ElseIf key.Key.ToString() = "UpArrow" Then
                menuIndex = menuIndex - 1
                If menuIndex < 0 Then
                    menuIndex = Convert.ToInt16(menuItems.Length - 1)
                End If
            End If
        Loop While key.Key.ToString <> "Enter"

        Return menuItems(menuIndex)
    End Function
End Class
