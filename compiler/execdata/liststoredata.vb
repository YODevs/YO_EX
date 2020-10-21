Public Class liststoredata
    Public Structure dataresult
        Dim result As String
        Dim issuccessful As Boolean
    End Structure
    Public items As ArrayList
    Public Sub New()
        items = New ArrayList
    End Sub

    Public Sub import_collection(itemlist As ArrayList)
        items = itemlist
    End Sub

    Public Sub add(value As String)
        items.Add(value)
    End Sub

    Public Function find(value As String, Optional toloweritem As Boolean = False) As Boolean
        If toloweritem Then
            Return find_tolower_item(value)
        End If
        Dim endpoint As Integer = items.Count - 1
        Dim result As New dataresult
        result.issuccessful = False
        For index = 0 To endpoint
            If items(index) = value Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function find_tolower_item(value As String) As Boolean
        Dim endpoint As Integer = items.Count - 1
        Dim result As New dataresult
        result.issuccessful = False
        value = value.ToLower
        For index = 0 To endpoint
            If items(index).ToString.ToLower = value Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Function contains_item(value As String) As dataresult
        Dim endpoint As Integer = items.Count - 1
        Dim result As New dataresult
        result.issuccessful = False
        For index = 0 To endpoint
            If items(index).ToString.Contains(value) Then
                result.result = items(index)
                result.issuccessful = True
                Return result
            End If
        Next
        Return result
    End Function
End Class
