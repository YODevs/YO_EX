Public Class mapstoredata
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
        values.Add(key)
    End Sub
End Class
