Public Class rds
    Private columns, dt As ArrayList
    Public Sub New()
        columns = New ArrayList
        dt = New ArrayList
    End Sub

    Public Sub set_columns(items As String)
        Dim yoda As New yoda
        columns = yoda.ReadYODA(items)
        If IsNothing(columns) Then
            Throw New Exception("The columns are still empty.")
        End If
    End Sub
End Class
