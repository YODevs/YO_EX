Public Class mapstoredata

    Public Structure dataresult
        Dim result As String
        Dim issuccessful As Boolean
    End Structure
    Private keys, values As ArrayList
    Public Sub New()
        keys = New ArrayList
        values = New ArrayList
    End Sub

    Public Sub import_collection(keylist As ArrayList, valuelist As ArrayList)
        keys = keylist
        values = valuelist
    End Sub

    Public Sub add(key As String, value As String)
        keys.Add(key)
        values.Add(value)
    End Sub

    Public Function find(key As String) As dataresult
        Dim endpoint As Integer = keys.Count - 1
        Dim result As New dataresult
        result.issuccessful = False
        For index = 0 To endpoint
            If keys.Item(index) = key Then
                result.result = values(index)
                result.issuccessful = True
                Return result
            End If
        Next
        Return result
    End Function

    Public Function findkey(value As String) As dataresult
        Dim endpoint As Integer = keys.Count - 1
        Dim result As New dataresult
        result.issuccessful = False
        For index = 0 To endpoint
            If values.Item(index) = value Then
                result.result = keys(index)
                result.issuccessful = True
                Return result
            End If
        Next
        Return result
    End Function
End Class
