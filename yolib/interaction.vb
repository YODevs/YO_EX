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
End Class
