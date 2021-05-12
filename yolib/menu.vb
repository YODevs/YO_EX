Public Class menu
    Private Shared prcursor As String = "->"
    Public Shared Property cursor() As String
        Get
            Return prcursor
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                prcursor = " "
            Else
                prcursor = value
            End If
        End Set
    End Property
    Public Shared Function show_menu(items As String) As String
        Dim menuindex As Short = 0
        Dim key As ConsoleKeyInfo
        Dim textfpr As String
        Dim yoda As New yoda
        Dim menuitems() As Object = yoda.ReadYODA(items).ToArray
        Dim staticcursortop As Integer = Console.CursorTop
        Do
            Console.CursorTop = staticcursortop
            textfpr = String.Empty
            For index = 0 To menuitems.Length - 1
                If menuindex = index Then
                    textfpr &= vbCrLf & prcursor
                    textfpr &= menuitems(index)
                Else
                    textfpr &= vbCrLf & menuitems(index) & Space(prcursor.Length)
                End If
            Next
            Console.WriteLine(textfpr)
            key = Console.ReadKey(True)
            If key.Key.ToString() = "DownArrow" Then
                menuindex = menuindex + 1
                If menuindex > menuitems.Length - 1 Then
                    menuindex = 0
                End If
            ElseIf key.Key.ToString() = "UpArrow" Then
                menuindex = menuindex - 1
                If menuindex < 0 Then
                    menuindex = Convert.ToInt16(menuitems.Length - 1)
                End If
            End If
        Loop While key.Key.ToString <> "Enter"
        Return menuitems(menuindex)
    End Function
End Class
