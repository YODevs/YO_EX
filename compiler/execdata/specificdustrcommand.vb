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

    Friend Shared Sub rem_specific_cil_char(ByRef value As String)
        If value.Contains("\") Then
            value = value.Replace("\", "\\")
        End If
    End Sub

End Class
