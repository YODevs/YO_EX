Imports System.Text.RegularExpressions

Public Class specificdustrcommand
    Public Shared spdustr As mapstoredata
    Friend Shared Sub init()
        spdustr = New mapstoredata
        For index = 0 To conrex.spdustrcommand.Length - 1
            spdustr.add(conrex.spdustrcommand(index), conrex.spdustrreact(index))
        Next
    End Sub

    Friend Shared Sub get_specific_dustr_command(ByRef value As String)
        rem_specific_cil_char(value)
        set_asc_dustr_command(value)
        If value.Contains("#") Then
            For index = 0 To conrex.spdustrcommand.Length - 1
                Dim resultspdustr As mapstoredata.dataresult = spdustr.find(conrex.spdustrcommand(index))
                If value.Contains(conrex.spdustrcommand(index)) Then
                    If resultspdustr.issuccessful Then
                        value = value.Replace(conrex.spdustrcommand(index), resultspdustr.result)
                    End If
                End If

                If value.Contains("#") = False Then Return
            Next
        Else
            Return
        End If
    End Sub

    Private Shared Sub set_asc_dustr_command(ByRef value As String)
        Dim regexresult As MatchCollection = Regex.Matches(value, "\#\[\d+\]")
        For index = 0 To regexresult.Count - 1
            Dim result As String = regexresult(index).Value
            result = result.Remove(0, 2)
            result = result.Remove(result.Length - 1)
            value = value.Replace(regexresult(index).Value, ChrW(result))
        Next
    End Sub
    Friend Shared Sub rem_specific_cil_char(ByRef value As String)
        If value.Contains("\") Then
            value = value.Replace("\", "\\")
        End If
    End Sub

    Friend Shared Sub reset_line_feed(ByRef value As String)
        value = value.Replace(vbCrLf, "#ln")
        value = value.Replace(vbCr, "#cr")
        value = value.Replace(vbLf, "#lf")
    End Sub

End Class
