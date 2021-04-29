Public Class interaction
    Public Shared Function inputbox() As String
        Return inputbox(My.Application.Info.Title, Nothing, Nothing)
    End Function

    Public Shared Function inputbox(title As String, description As String) As String
        Return inputbox(title, description, Nothing)
    End Function

    Public Shared Function inputbox(title As String, description As String, defaultresult As String) As String
        Dim result As String = Microsoft.VisualBasic.Interaction.InputBox(description, title, defaultresult)
        Return result
    End Function

    Public Shared Function messagebox(description As String) As String
        Return messagebox(My.Application.Info.Title, description, 0)
    End Function

    Public Shared Function messagebox(title As String, description As String) As String
        Return messagebox(title, description, 0)
    End Function

    Public Shared Function messagebox(title As String, description As String, dialogstyle As Integer) As String
        Return MsgBox(description, dialogstyle, title).ToString()
    End Function
End Class
