Public Class lngen
    Private Shared lines As ArrayList
    Public Shared Function get_line_prop(perfix As String) As String
        Dim rand As New Random
        While True
            Dim linename As String = "YOIL_" & perfix & "_" & rand.Next(10000, 100000) & ":"
            For index = 0 To lines.Count - 1
                If lines(index) = lines Then
                    Continue While
                End If
            Next
            lines.Add(linename)
            Return linename
        End While
        Return 0
    End Function

    Public Shared Sub set_label(perfix As String, ByRef codes As ArrayList)
        Dim labelname As String = get_line_prop(perfix)
        cil.insert_il(codes, labelname)
    End Sub
    Public Shared Sub init_lines()
        lines = New ArrayList
    End Sub
End Class
