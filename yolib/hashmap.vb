Imports System.IO

Public Class map
    Private keys, values As New ArrayList

    Public Sub New()

    End Sub

    Public Function import(yodamap As String) As Integer
        Dim yodaformat As New yoda
        Dim mapresult As yoda.YODAMapFormat = yodaformat.ReadYODA_Map(yodamap)
        Dim itemcount As Integer = mapresult.keys.Count - 1
        For index = 0 To itemcount
            keys.Add(mapresult.keys(index))
            values.Add(mapresult.values(index))
        Next
        Return itemcount + 1
    End Function

    Public Function clone() As String
        Dim yodaformat As New yoda
        Return yodaformat.WriteYODA_Map(keys, values)
    End Function

    Public Function [set](yodamap As String) As Integer
        Dim yodaformat As New yoda
        Dim mapresult As yoda.YODAMapFormat = yodaformat.ReadYODA_Map(yodamap)
        keys = mapresult.keys
        values = mapresult.values
        Return keys.Count
    End Function

    Public Function add(key As String, value As String) As Boolean
        If key = Nothing Then
            Throw New Exception("Key is empty.")
        End If
        keys.Add(key)
        values.Add(value)
        Return True
    End Function

    Public Function add_unique(key As String, value As String) As Boolean
        If key = Nothing Then
            Throw New Exception("Key is empty.")
        End If
        Dim getkey As String
        For index = 0 To keys.Count - 1
            getkey = keys(index).ToString
            If getkey = key Then
                Throw New Exception("This key is already registered, you can use 'update' method.")
                Return False
            End If
        Next
        keys.Add(key)
        values.Add(value)
        Return True
    End Function
    Public Function contains_Key(key As String) As Object
        If key = Nothing Then
            Throw New Exception("Key is empty.")
        End If
        Dim getkey As String
        For index = 0 To keys.Count - 1
            getkey = keys(index).ToString
            If getkey.Contains(key) Then
                Return getkey
            End If
        Next
        Return False
    End Function

    Public Function contains_value(value As String) As Object
        If value = Nothing Then
            Throw New Exception("Value is empty.")
        End If
        Dim getval As String
        For index = 0 To keys.Count - 1
            getval = values(index).ToString
            If getval.Contains(value) Then
                Return getval
            End If
        Next
        Return False
    End Function


    Public Function [get](key As String) As Object
        If key = Nothing Then
            Throw New Exception("Key is empty.")
        End If
        Dim getkey As String
        For index = 0 To keys.Count - 1
            getkey = keys(index).ToString
            If getkey = key Then
                Return values(index)
            End If
        Next
        Throw New Exception(key & " - Key is not defined.")
        Return Nothing
    End Function

    Public Sub get_map(index As Integer, ByRef key As String, ByRef value As String)
        If index >= 0 AndAlso keys.Count > index Then
            key = keys(index)
            value = values(index)
        Else
            Throw New Exception("The index '" & index & "' entered in the validation was rejected.")
        End If
    End Sub
    Public Function get_with_index(index As Integer) As Object
        If index >= 0 AndAlso keys.Count > index Then
            Return values(index)
        Else
            Throw New Exception("The index '" & index & "' entered in the validation was rejected.")
        End If
        Return Nothing
    End Function
    Public Function [remove](key As String) As Boolean
        If key = Nothing Then
            Throw New Exception("Key is empty.")
        End If
        Dim getkey As String
        For index = 0 To keys.Count - 1
            getkey = keys(index).ToString
            If getkey = key Then
                keys.RemoveAt(index)
                values.RemoveAt(index)
                Return True
            End If
        Next
        Throw New Exception(key & " - Key is not defined.")
        Return False
    End Function

    Public Function [clear]() As Boolean
        If keys.Count = 0 Then Return False
        keys.Clear()
        values.Clear()
        Return True
    End Function

    Public Function [size]() As Integer
        Return keys.Count
    End Function

    Public Function is_empty() As Boolean
        If keys.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function [update](key As String, value As String) As Boolean
        If key = Nothing Then
            Throw New Exception("Key is empty.")
        End If
        Dim getkey As String
        For index = 0 To keys.Count - 1
            getkey = keys(index).ToString
            If getkey = key Then
                values.Insert(index + 1, value)
                values.RemoveAt(index)
                Return True
            End If
        Next
        Throw New Exception(key & " - Key is not defined.")
        Return False
    End Function

    Public Sub save(path As String)
        Dim yodaformat As New yoda
        File.WriteAllText(path, yodaformat.WriteYODA_Map(keys, values))
    End Sub

    Public Function load(path As String) As Integer
        If File.Exists(path) = False Then
            Throw New Exception(path & " - Yoda file not found.")
            Return 0
        End If
        Dim yodaformat As New yoda
        Dim yodaplaintext As String = File.ReadAllText(path)
        Dim mapresult As yoda.YODAMapFormat = yodaformat.ReadYODA_Map(yodaplaintext)
        keys = mapresult.keys
        values = mapresult.values
        Return keys.Count
    End Function
End Class
