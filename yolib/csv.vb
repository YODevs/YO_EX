Imports System.IO
Imports System.Text

Public Class csv

    Public delimiter As Char = ","
    Dim dt As rds
    Private isdblcot As Boolean = False
    Public ReadOnly Property columncount() As Integer
        Get
            Return dt.columncount
        End Get
    End Property
    Public ReadOnly Property rowcount() As Integer
        Get
            If IsNothing(dt) Then
                Return 0
            End If
            Return dt.rowcount
        End Get
    End Property
    Public Sub New()
        dt = New rds
    End Sub
    Public Sub load_file(path As String)
        If File.Exists(path) = False Then Throw New Exception(String.Format("{0}- Datasheet file not found", path))
        Using streamdataloader As StreamReader = File.OpenText(path)
            While streamdataloader.EndOfStream = False
                set_rows(streamdataloader.ReadLine)
            End While
        End Using
    End Sub

    Private Sub set_rows(row As String)
        Dim items As New ArrayList
        lex_row(row, items)
        If items.Count = 0 Then Return
        If dt.columncount = 0 Then
            dt.set_columns(items)
        Else
            dt.insert(items)
        End If
    End Sub

    Private Sub lex_row(row As String, ByRef items As ArrayList)
        If row = String.Empty Then Return
        Dim rowlen As Integer = row.Length - 1
        Dim singleitem As String = String.Empty
        For index = 0 To rowlen
            If row(index) = delimiter AndAlso isdblcot = False Then
                items.Add(singleitem)
                isdblcot = False
                singleitem = String.Empty
            Else
                singleitem &= row(index)
                If row(index) = """" Then
                    If isdblcot = False Then
                        isdblcot = True
                    ElseIf isdblcot = True AndAlso row(index - 1) = """" Then
                        singleitem = singleitem.Remove(singleitem.Length - 1)
                    ElseIf rowlen > index + 1 AndAlso row(index + 1) = delimiter Then
                        isdblcot = False
                        If singleitem.StartsWith("""") AndAlso singleitem.EndsWith("""") Then
                            singleitem = singleitem.Remove(singleitem.Length - 1)
                            singleitem = singleitem.Remove(0, 1)
                        End If
                    End If

                End If
            End If
        Next
        If singleitem.StartsWith("""") AndAlso singleitem.EndsWith("""") Then
            singleitem = singleitem.Remove(singleitem.Length - 1)
            singleitem = singleitem.Remove(0, 1)
        End If
        items.Add(singleitem)
        isdblcot = False
    End Sub

    Public Function [get](rowindex As Integer) As String()
        Return dt.get(rowindex)
    End Function

    Public Function [get](rowindex As Integer, colindex As Integer) As String
        Return dt.get(rowindex, colindex)
    End Function

    Public Function get_rds() As rds
        Return dt
    End Function

    Public Shared Function to_csv(data As rds) As String
        If IsNothing(data) Then Return Nothing
        Dim sb As New StringBuilder
        sb.AppendLine(String.Join(",", data.getcolumns))
        Dim count As Integer = data.rowcount - 1
        For index = 0 To count
            Dim row() As String = data.get(index)
            For i2 = 0 To row.Length - 1
                Dim item As String = row(i2)
                If item.Contains(",") Then
                    item = String.Format("""{0}""", item)
                    row(i2) = item
                End If
            Next
            sb.AppendLine(String.Join(",", row))
        Next
        Return sb.ToString
    End Function

End Class
