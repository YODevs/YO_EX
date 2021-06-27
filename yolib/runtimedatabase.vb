Public Class rds
    Private columns, dt()() As ArrayList
    Public Sub New()
        columns = New ArrayList
    End Sub

    Public ReadOnly Property columncount() As Integer
        Get
            Return columns.Count
        End Get
    End Property
    Public Sub set_columns(items As String)
        If columns.Count > 0 Then
            Throw New Exception("Columns have already been added to the data store.")
            Return
        End If
        Dim yoda As New yoda
        columns = yoda.ReadYODA(items)
        If IsNothing(columns) OrElse columns.Count = 0 Then
            Throw New Exception("The columns are still empty.")
        End If
    End Sub
End Class
