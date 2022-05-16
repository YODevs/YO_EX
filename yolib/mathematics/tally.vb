Public Class tally
    Dim items, countlist As ArrayList
    Public Sub New()
        items = New ArrayList
        countlist = New ArrayList
    End Sub

    Private privgrouprange As Integer = 5
    Public Property grouprange() As Integer
        Get
            Return privgrouprange
        End Get
        Set(ByVal value As Integer)
            If value <= 0 Then value = 5
            privgrouprange = value
        End Set
    End Property
    Public Sub add(item As String)
        Dim indexref As Integer = 0
        If check_item_repetition(item, indexref) Then
            countlist(indexref) = CInt(countlist(indexref)) + 1
        Else
            items.Add(item)
            countlist.Add(1)
        End If
    End Sub

    Public Function [get](item As String) As Integer
        Dim indexref As Integer = 0
        If check_item_repetition(item, indexref) Then
            Return CInt(countlist(indexref))
        End If
        Return 0
    End Function

    Public Function get_group(item As String) As Single
        Dim indexref As Integer = 0
        If check_item_repetition(item, indexref) Then
            Return CSng(CInt(countlist(indexref)) / privgrouprange)
        End If
        Return 0.0
    End Function

    Private Function check_item_repetition(item As String, ByRef indexref As Integer) As Boolean
        Dim count As Integer = items.Count - 1
        If count = -1 Then Return False
        For index = 0 To count
            If items(index).ToString = item Then
                indexref = index
                Return True
            End If
        Next
        Return False
    End Function
End Class
