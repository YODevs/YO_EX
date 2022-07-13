Public Class lngen
    Private Shared lines As ArrayList
    Private Shared flags As ArrayList
    Private Shared privlocalinit As ArrayList
    Private Shared rand As New Random

    Public Shared Function get_line_prop(perfix As String) As String
        While True
            Dim linename As String = "YOIL_" & perfix & "_" & rand.Next(10000, 100000)
            For index = 0 To lines.Count - 1
                If lines(index) = linename Then
                    Continue While
                End If
            Next
            lines.Add(linename)
            Return linename
        End While
        Return 0
    End Function

    Public Shared Function set_label(perfix As String, ByRef codes As ArrayList) As String
        Dim labelname As String = get_line_prop(perfix)
        cil.insert_il(codes, labelname & ":")
        Return labelname
    End Function

    Public Shared Sub set_direct_label(label As String, ByRef codes As ArrayList)
        label &= ":"
        cil.insert_il(codes, label)
    End Sub
    Public Shared Function get_flag() As String
        Dim flag As String = compdt.FLAGPERFIX & flags.Count
        flags.Add(flag)
        Return flag
    End Function
    Public Shared Function get_varname(varname As String) As String
        Dim name As String = compdt.VARPERFIX & varname & rand.Next(100000, 9999999) & "_" & privlocalinit.Count
        privlocalinit.Add(name)
        Return name
    End Function
    Public Shared Sub init_lines()
        lines = New ArrayList
        flags = New ArrayList
        privlocalinit = New ArrayList
    End Sub
End Class
