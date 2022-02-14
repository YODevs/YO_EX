﻿'Clone from https://github.com/YODevs/YO/tree/master/yoda
Public Class yoda

#Region "const"
    Private Const YODA_EMP As String = "![]"
    Private Const DBCOT As String = """"
    Private Const SGCOT As String = "'"
    Private Const SPACE As String = " "
    Private Const CMA As String = ","
    Private Const ST_YODA As String = "!["
    Private Const EN_YODA As String = "]"
#End Region

    Private snkey, snvalue, snitem As ArrayList

    Private compressformat As Boolean = False
    Public Property compress() As Boolean
        Get
            Return compressformat
        End Get
        Set(ByVal value As Boolean)
            compressformat = value
        End Set
    End Property
    Public Sub New()
        snitem = New ArrayList
        snvalue = New ArrayList
        snkey = New ArrayList
    End Sub
    Public Structure YODAMapFormat
        Dim keys As ArrayList
        Dim values As ArrayList
    End Structure

    Public Sub add(value As String)
        snitem.Add(value)
    End Sub
    Public Sub add(key As String, value As String)
        snkey.Add(key)
        snvalue.Add(value)
    End Sub
    Public Function get_list() As String
        Dim yodaf As String = WriteYODA(snitem, compress)
        snitem.Clear()
        Return yodaf
    End Function
    Public Function get_map() As String
        Dim yodaf As String = WriteYODA_Map(snkey, snvalue, compress)
        snkey.Clear()
        snvalue.Clear()
        Return yodaf
    End Function
    Public Function WriteYODA(items As ArrayList, Optional compress As Boolean = True) As String
        Dim countOfItems As Integer = items.Count - 1
        If countOfItems = -1 Then Return YODA_EMP
        Dim YODA_Format As String = ST_YODA
        Dim item As String = String.Empty
        If compress = False Then
            YODA_Format &= vbCrLf
        End If
        For index = 0 To countOfItems
            item = items(index)
            Replace_Unique_Char(item)
            If index <> countOfItems Then
                If compress Then
                    YODA_Format &= DBCOT & item & DBCOT & CMA
                Else
                    YODA_Format &= DBCOT & item & """   ," & vbCrLf
                End If
            Else
                If compress Then
                    YODA_Format &= DBCOT & item & DBCOT & EN_YODA
                Else
                    YODA_Format &= DBCOT & item & DBCOT & vbCrLf & EN_YODA
                End If

            End If
        Next
        Return YODA_Format
    End Function

    Public Function WriteYODA_Map(keys As ArrayList, values As ArrayList, Optional compress As Boolean = True) As String
        Dim countOfItems As Integer = keys.Count - 1
        If countOfItems = -1 Then Return YODA_EMP
        If keys.Count <> values.Count Then Throw New Exception("The keys and values are not equal.")
        Dim YODA_Format As String = "!!["
        Dim key As String = String.Empty
        Dim value As String = String.Empty

        If compress = False Then
            YODA_Format &= vbCrLf
        End If

        For index = 0 To countOfItems
            key = keys(index)
            value = values(index)
            Replace_Unique_Char(key)
            Replace_Unique_Char(value)
            If index <> countOfItems Then
                If compress Then
                    YODA_Format &= DBCOT & key & """=""" & value & DBCOT & CMA
                Else
                    YODA_Format &= DBCOT & key & """   =   """ & value & """   ," & vbCrLf
                End If
            Else
                If compress Then
                    YODA_Format &= DBCOT & key & """=""" & value & DBCOT & EN_YODA
                Else
                    YODA_Format &= DBCOT & key & """   =   """ & value & """   " & vbCrLf & EN_YODA
                End If
            End If
        Next
        Return YODA_Format
    End Function


    Public Function WriteYODA_Map(items As ArrayList) As String
        Dim countOfItems As Integer = items.Count - 1
        If countOfItems = -1 Then Return YODA_EMP
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
                YODA_Format &= DBCOT & key & """=""" & value & DBCOT & CMA
            Else
                YODA_Format &= DBCOT & key & """=""" & value & DBCOT & EN_YODA
            End If
        Next
        Return YODA_Format

    End Function

    Private Sub Replace_Unique_Char(ByRef obj As String)
        obj = obj.Replace(SGCOT, "&apos;")
        obj = obj.Replace(DBCOT, "&quot;")
    End Sub
    Private Sub Return_Unique_Char(ByRef obj As String)
        obj = obj.Replace("&apos;", SGCOT)
        obj = obj.Replace("&quot;", DBCOT)
    End Sub

    Public Function ReadYODA(YODA_F As String) As ArrayList
        YODA_F = YODA_F.Trim
        Dim item As String = String.Empty
        Dim items As New ArrayList
        If YODA_F = String.Empty Or YODA_F = YODA_EMP Then
            Return items
        ElseIf YODA_F.StartsWith(ST_YODA) = False Or YODA_F.EndsWith(EN_YODA) = False Then
            Throw New Exception("The format of data markup is unclear.")
        End If
        YODA_F = YODA_F.Remove(0, 2)
        YODA_F = YODA_F.Remove(YODA_F.Length - 1).Trim
        Dim cotStarter As Char = YODA_F(0)

        If cotStarter <> SGCOT And cotStarter <> DBCOT Then
            Throw New Exception(cotStarter & " - Starter is incomprehensible, start with a string quotation.")
        End If

        Dim lenOfYODA As Integer = YODA_F.Length - 1
        Dim nextItem As Boolean = False
        For index = 0 To lenOfYODA
            If nextItem Then
                If YODA_F(index) = SPACE OrElse YODA_F(index) = vbCrLf OrElse YODA_F(index) = vbCr OrElse YODA_F(index) = vbLf Then
                    Continue For
                ElseIf YODA_F(index) = CMA Then
                    nextItem = False
                    Continue For
                Else
                    Throw New Exception(YODA_F(index) & " - Unauthorized character found outside of string.")
                End If
            End If
            item &= YODA_F(index)
            If item.StartsWith(cotStarter) = False Then
                item = item.Trim
            End If
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
        ElseIf YODA_F.StartsWith("!![") = False Or YODA_F.EndsWith(EN_YODA) = False Then
            Throw New Exception("The format of data markup is unclear.")
        End If
        YODA_F = YODA_F.Remove(0, 3)
        YODA_F = YODA_F.Remove(YODA_F.Length - 1).Trim
        Dim cotStarter As Char = YODA_F(0)

        If cotStarter <> SGCOT And cotStarter <> DBCOT Then
            Throw New Exception(cotStarter & " - Starter is incomprehensible, start with a string quotation.")
        End If

        Dim lenOfYODA As Integer = YODA_F.Length - 1
        Dim nextItem As Boolean = False
        Dim setKeys As Boolean = True
        For index = 0 To lenOfYODA
            If nextItem Then
                If YODA_F(index) = SPACE OrElse YODA_F(index) = vbCrLf OrElse YODA_F(index) = vbCr OrElse YODA_F(index) = vbLf Then
                    Continue For
                ElseIf YODA_F(index) = CMA Or YODA_F(index) = "=" Then
                    nextItem = False
                    Continue For
                Else
                    Throw New Exception(YODA_F(index) & " - Unauthorized character found outside of string.")
                End If
            End If
            item &= YODA_F(index)
            If item.StartsWith(cotStarter) = False Then
                item = item.Trim
            End If
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
