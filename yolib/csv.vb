Imports System.IO

Public Class csv

    Public delimiter As Char = ","
    Dim dt As rds
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
    End Sub

    Private Sub lex_row(row As String, ByRef items As ArrayList)
        If row = String.Empty Then Return
        Dim rowlen As Integer = row.Length - 1
        Dim singleitem As String = String.Empty
        For index = 0 To rowlen
            If row(index) = delimiter Then
                items.Add(singleitem)
                singleitem = String.Empty
            Else
                singleitem &= row(index)
            End If
        Next
    End Sub
End Class
