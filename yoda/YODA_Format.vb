Public Class YODA_Format

    Public Sub New()
    End Sub
    Public Structure YODAMapFormat
        Dim keys As ArrayList
        Dim values As ArrayList
    End Structure
    Public Function WriteYODA(items As ArrayList) As String
        Dim countOfItems As Integer = items.Count - 1
        If countOfItems = -1 Then Return "![]"
        Dim YODA_Format As String = "!["
        Dim item As String = String.Empty
        For index = 0 To countOfItems
            item = items(index)
            Replace_Unique_Char(item)
            If index <> countOfItems Then
                YODA_Format &= """" & item & ""","
            Else
                YODA_Format &= """" & item & """]"
            End If
        Next
        Return YODA_Format
    End Function

    Public Function WriteYODA_Map(keys As ArrayList, values As ArrayList) As String
        Dim countOfItems As Integer = keys.Count - 1
        If countOfItems = -1 Then Return "![]"
        If keys.Count <> values.Count Then Throw New Exception("The keys and values are not equal.")
        Dim YODA_Format As String = "!!["
        Dim key As String = String.Empty
        Dim value As String = String.Empty

        For index = 0 To countOfItems
            key = keys(index)
            value = values(index)
            Replace_Unique_Char(key)
            Replace_Unique_Char(value)
            If index <> countOfItems Then
                YODA_Format &= """" & key & """=""" & value & ""","
            Else
                YODA_Format &= """" & key & """=""" & value & """]"
            End If
        Next
        Return YODA_Format
    End Function


    Public Function WriteYODA_Map(items As ArrayList) As String
        Dim countOfItems As Integer = items.Count - 1
        If countOfItems = -1 Then Return "![]"
        If items.Count Mod 2 <> 0 Then Throw New Exception("The keys and values are not equal.")
        Dim YODA_Format As String = "!!["
        Dim key As String = String.Empty
        Dim value As String = String.Empty

        For index = 0 To countOfItems Step 2
            key = items(index)
            value = items(index + 1)
            Replace_Unique_Char(key)
            Replace_Unique_Char(value)
            If index + 1 <> countOfItems Then
                YODA_Format &= """" & key & """=""" & value & ""","
            Else
                YODA_Format &= """" & key & """=""" & value & """]"
            End If
        Next
        Return YODA_Format

    End Function

    Private Sub Replace_Unique_Char(ByRef obj As String)
        obj = obj.Replace("'", "&apos;")
        obj = obj.Replace("""", "&quot;")
    End Sub
    Private Sub Return_Unique_Char(ByRef obj As String)
        obj = obj.Replace("&apos;", "'")
        obj = obj.Replace("&quot;", """")
    End Sub

    Public Function ReadYODA(YODA_F As String) As ArrayList
        YODA_F = YODA_F.Trim
        Dim item As String = String.Empty
        Dim items As New ArrayList
        If YODA_F = String.Empty Or YODA_F = "![]" Then
            Return items
        ElseIf YODA_F.StartsWith("![") = False Or YODA_F.EndsWith("]") = False Then
            Throw New Exception("The format of data markup is unclear.")
        End If
        YODA_F = YODA_F.Remove(0, 2)
        YODA_F = YODA_F.Remove(YODA_F.Length - 1).Trim
        Dim cotStarter As Char = YODA_F(0)

        If cotStarter <> "'" And cotStarter <> """" Then
            Throw New Exception(cotStarter & " - Starter is incomprehensible, start with a string quotation.")
        End If

        Dim lenOfYODA As Integer = YODA_F.Length - 1
        Dim nextItem As Boolean = False
        For index = 0 To lenOfYODA
            If nextItem Then
                If YODA_F(index) = " " Then
                    Continue For
                ElseIf YODA_F(index) = "," Then
                    nextItem = False
                    Continue For
                Else
                    Throw New Exception(YODA_F(index) & " - Unauthorized character found outside of string.")
                End If
            End If
            item &= YODA_F(index)
            If item.Length > 1 AndAlso item.StartsWith(cotStarter) AndAlso item.EndsWith(cotStarter) Then
                item = item.Remove(0, 1)
                item = item.Remove(item.Length - 1)
                Return_Unique_Char(item)
                items.Add(item)
                item = ""
                nextItem = True
            End If
        Next

        Return items
    End Function

    Public Function ReadYODA_Map(YODA_F As String) As YODAMapFormat
        YODA_F = YODA_F.Trim
        Dim item As String = String.Empty
        Dim items As New YODAMapFormat
        items.keys = New ArrayList
        items.values = New ArrayList
        If YODA_F = String.Empty Or YODA_F = "!![]" Then
            Return items
        ElseIf YODA_F.StartsWith("!![") = False Or YODA_F.EndsWith("]") = False Then
            Throw New Exception("The format of data markup is unclear.")
        End If
        YODA_F = YODA_F.Remove(0, 3)
        YODA_F = YODA_F.Remove(YODA_F.Length - 1).Trim
        Dim cotStarter As Char = YODA_F(0)

        If cotStarter <> "'" And cotStarter <> """" Then
            Throw New Exception(cotStarter & " - Starter is incomprehensible, start with a string quotation.")
        End If

        Dim lenOfYODA As Integer = YODA_F.Length - 1
        Dim nextItem As Boolean = False
        Dim setKeys As Boolean = True
        For index = 0 To lenOfYODA
            If nextItem Then
                If YODA_F(index) = " " Then
                    Continue For
                ElseIf YODA_F(index) = "," Or YODA_F(index) = "=" Then
                    nextItem = False
                    Continue For
                Else
                    Throw New Exception(YODA_F(index) & " - Unauthorized character found outside of string.")
                End If
            End If
            item &= YODA_F(index)
            If item.Length > 1 AndAlso item.StartsWith(cotStarter) AndAlso item.EndsWith(cotStarter) Then
                item = item.Remove(0, 1)
                item = item.Remove(item.Length - 1)
                Return_Unique_Char(item)

                If setKeys Then
                    items.keys.Add(item)
                    setKeys = False
                Else
                    items.values.Add(item)
                    setKeys = True
                End If
                item = Nothing
                nextItem = True
            End If
        Next

        If items.keys.Count <> items.values.Count Then Throw New Exception("The keys and values are not equal.")
        Return items
    End Function

End Class
