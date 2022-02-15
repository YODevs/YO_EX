Imports System.IO

Public Class asmlist
    Friend Shared assemblylist()(), typelist()() As ArrayList
    Public Shared Sub init(path As String)
        Array.Resize(assemblylist, 26)
        Array.Resize(typelist, 26)
        For index = 0 To 25
            Array.Resize(assemblylist(index), 26)
            Array.Resize(typelist(index), 26)
            assemblylist(index)(0) = New ArrayList()
            typelist(index)(0) = New ArrayList()
            For index2 = 0 To 25
                assemblylist(index)(index2) = New ArrayList
                typelist(index)(index2) = New ArrayList
            Next
        Next
        load_assembly_types(path)
    End Sub

    Private Shared Sub load_assembly_types(path As String)
        Dim yoda As New YODA.YODA_Format
        Dim yodaresult As YODA.YODA_Format.YODAMapFormat = yoda.ReadYODA_Map(File.ReadAllText(path))
        Dim countofresult As Integer = yodaresult.keys.Count - 1
        Dim key, value As String
        Dim d1, d2 As Integer
        For index = 0 To countofresult
            key = yodaresult.keys(index).ToString
            value = yodaresult.values(index).ToString
            If key.StartsWith("System.") Then
                d1 = Asc(key(7).ToString.ToUpper) - 65
                d2 = Asc(key(8).ToString.ToUpper) - 65
            Else
                d1 = Asc(key(1).ToString.ToUpper) - 65
                d2 = Asc(key(2).ToString.ToUpper) - 65
            End If
            If d1 < 0 OrElse d2 < 0 OrElse d1 > 25 OrElse d2 > 25 Then
                d1 = 0
                d2 = 0
            End If
            assemblylist(d1)(d2).Add(value)
            typelist(d1)(d2).Add(key)
        Next
        GC.Collect()
    End Sub
End Class
