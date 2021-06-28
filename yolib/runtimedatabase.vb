Public Class rds
    Private columns, dt() As ArrayList
    Public Sub New()
        columns = New ArrayList
    End Sub

    Public ReadOnly Property columncount() As Integer
        Get
            Return columns.Count
        End Get
    End Property
    Public ReadOnly Property rowcount() As Integer
        Get
            If IsNothing(dt) Then
                Return 0
            End If
            Return dt.Count
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

    Public Function insert(items As String) As Integer
        Dim rowlist As ArrayList
        Dim yoda As New yoda
        rowlist = yoda.ReadYODA(items)
        If rowlist.Count <> columns.Count Then
            Throw New Exception("Items are not equal to the number of columns[" & columns.Count & "].")
            Return -1
        End If
        Dim getlastitemindex As Integer = rowcount
        Array.Resize(dt, getlastitemindex + 1)
        dt(getlastitemindex) = rowlist
        Return getlastitemindex + 1
    End Function

    Public Sub delete(index As Integer)
        If IsNothing(dt) Then
            Throw New Exception("Datastore is empty.")
        End If
        If index >= 0 AndAlso index < dt.Length Then
            dt = dt.Skip(index).ToArray
        Else
            Throw New Exception("Index is not allowed, review it.")
        End If
    End Sub

    Public Function get_row_map(index As Integer) As map
        Dim yodastr As String = get_row(index)
        Dim mp As New map
        Dim yoda As New yoda
        Dim rowlist As ArrayList = yoda.ReadYODA(yodastr)
        For index = 0 To rowlist.Count - 1
            mp.add(columns(index).ToString, rowlist(index).ToString)
        Next
        Return mp
    End Function
    Public Function get_row_list(index As Integer) As list
        Dim yodastr As String = get_row(index)
        Dim ls As New list
        ls.import(yodastr)
        Return ls
    End Function
    Public Function get_row(index As Integer) As String
        If IsNothing(dt) Then
            Throw New Exception("Datastore is empty.")
            Return Nothing
        End If
        If index >= 0 AndAlso index < dt.Length Then
            Dim yoda As New yoda
            Return yoda.WriteYODA(dt(index))
        Else
            Throw New Exception("Index is not allowed, review it.")
            Return Nothing
        End If
    End Function

    Private Sub index_validation(index As Integer)
        If IsNothing(dt) Then
            Throw New Exception("Datastore is empty.")
        End If
        If index >= 0 AndAlso index < dt.Length Then
            Return
        Else
            Throw New Exception("Index is not allowed, review it.")
        End If
    End Sub

    Private Sub column_validation(ByRef columnname As String)
        For index = 0 To columns.Count - 1
            If columns(index).ToString.ToLower = columnname.ToLower Then
                columnname = columns(index).ToString
            End If
        Next
        Throw New Exception("Column named '" & columnname & "' not found.")
    End Sub
End Class
