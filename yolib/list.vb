Imports System.IO
Imports System.Text.RegularExpressions

Public Class [list]
    Dim items As ArrayList
    Public Sub New()
        items = New ArrayList
    End Sub
    Public Sub New(value As String, pattern As String)
        Me.New()
        Dim splititems() As String
        splititems = System.Text.RegularExpressions.Regex.Split(value, pattern)
        Dim listsplitlength As Integer = splititems.Length - 1
        For index = 0 To listsplitlength
            items.Add(splititems(index))
        Next
    End Sub
    Public Sub New(values() As String)
        Me.New()
        Dim len As Integer = values.Length - 1
        For index = 0 To len
            items.Add(items(index))
        Next
    End Sub
    Public Function append(value As String) As Integer
        If items.Count = 0 Then
            Return items.Add(value)
        End If
        items.Insert(0, value)
        Return items.Count
    End Function
    Public Function add(value As String) As Integer
        Return items.Add(value)
    End Function

    Public Function add_with_split(values As String, pattern As String) As Integer
        Dim splititems() As String
        splititems = System.Text.RegularExpressions.Regex.Split(values, pattern)
        Dim listSplitLength As Integer = splititems.Length - 1
        For index = 0 To listSplitLength
            items.Add(splititems(index))
        Next
        Return items.Count
    End Function

    Public Function insert(index As Integer, value As String) As Integer
        If items.Count = 0 Then
            Return items.Add(value)
        End If
        items.Insert(index, value)
        Return items.Count
    End Function
    Public Function import(yodastring As String) As Integer
        Dim yodaformat As New yoda
        Dim itemlist As ArrayList = yodaformat.ReadYODA(yodastring)
        Dim itemcount As Integer = itemlist.Count - 1
        For index = 0 To itemcount
            items.Add(itemlist(index))
        Next
        Return items.Count
    End Function

    Public Sub save(path As String)
        Dim yodaformat As New yoda
        File.WriteAllText(path, yodaformat.WriteYODA(items))
    End Sub

    Public Sub load(path As String)
        If File.Exists(path) = False Then
            Throw New Exception(path & " - Yoda file not found.")
            Return
        End If
        Dim yodaformat As New yoda
        Dim yodaplaintext As String = File.ReadAllText(path)
        items = yodaformat.ReadYODA(yodaplaintext)
    End Sub

    Public Function [set](yodastring As String) As Integer
        Dim yodaformat As New yoda
        Dim itemlist As ArrayList = yodaformat.ReadYODA(yodastring)
        items = itemlist
        Return items.Count
    End Function

    Public Function clone() As String
        Dim yodaformat As New yoda
        Return yodaformat.WriteYODA(items)
    End Function

    Public Function iter(item As String) As Integer
        Dim numofiter As Integer = 0
        For index = 0 To items.Count - 1
            If item = items(index) Then
                numofiter += 1
            End If
        Next
        Return numofiter
    End Function

    Public Function count() As Integer
        Return items.Count
    End Function

    Public Sub clear()
        items.Clear()
    End Sub

    Public Function remove(value As String) As Boolean
        Dim itemscount As Integer = items.Count - 1
        For index = 0 To itemscount
            If items(index) = value Then
                items.RemoveAt(index)
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub remove_at(index As Integer)
        items.RemoveAt(index)
    End Sub

    Public Sub sort()
        items.Sort()
    End Sub
    Public Sub reverse()
        Dim departList As New ArrayList
        Dim itemscount As Integer = items.Count - 1
        For index = itemscount To 0 Step -1
            departList.Add(items(index))
        Next
        items = departList
    End Sub

    Public Function contains(value As String) As Boolean
        Dim itemscount As Integer = items.Count - 1
        For index = 0 To itemscount
            If items(index).ToString.Contains(value) Then Return True
        Next
        Return False
    End Function

    Public Function starts_with(value As String) As Boolean
        Dim itemscount As Integer = items.Count - 1
        For index = 0 To itemscount
            If items(index).ToString.StartsWith(value) Then Return True
        Next
        Return False
    End Function

    Public Function ends_with(value As String) As Boolean
        Dim itemscount As Integer = items.Count - 1
        For index = 0 To itemscount
            If items(index).ToString.EndsWith(value) Then Return True
        Next
        Return False
    End Function

    Public Function pattern(regexCode As String) As Boolean
        Dim itemscount As Integer = items.Count - 1
        For index = 0 To itemscount
            If System.Text.RegularExpressions.Regex.IsMatch(items(index).ToString, regexCode) Then Return True
        Next
        Return False
    End Function
    Public Function [get](index As Integer) As String
        If index <> -1 Then
            Return items(index)
        Else
            Return items(items.Count - 1)
        End If
    End Function

    Public Function get_index(value As String) As Integer
        Dim itemscount As Integer = items.Count - 1
        For index = 0 To itemscount
            If value = items(index) Then Return index
        Next
        Return -1
    End Function

    Public Function pop() As String
        If items.Count = 0 Then Throw New Exception("pop from empty list.")
        Dim item As String = items(items.Count - 1)
        If items.Count <> 1 Then
            items.RemoveAt(items.Count - 1)
        Else
            items.Clear()
        End If
        Return item
    End Function

    Public Function pop_left() As String
        If items.Count = 0 Then Throw New Exception("pop from empty list.")
        Dim item As String = items(0)
        If items.Count <> 1 Then
            items.RemoveAt(0)
        Else
            items.Clear()
        End If
        Return item
    End Function

    Public Function to_str() As String()
        Dim itemscount As Integer = items.Count - 1
        Dim retstr(itemscount) As String
        For index = 0 To itemscount
            retstr(index) = items(index).ToString
        Next
        Return retstr
    End Function
End Class
