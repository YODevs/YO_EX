Public Class rangeserv

    Structure ranginf
        Dim startpoint As Object
        Dim endpoint As Object
        Dim stepsc As Object
        Dim ignorelastpoint As Boolean
    End Structure
    Public Shared Function get_range_info(rangestring As xmlunpkd.linecodestruc) As ranginf
        If rangestring.tokenid <> tokenhared.token.RANGE Then Return Nothing
        Dim rvalue As String = rangestring.value
        authfunc.rem_fr_and_en(rvalue)
        Dim rninf As New ranginf
        rninf.stepsc = 1
        rninf.startpoint = rvalue.Remove(rvalue.IndexOf(conrex.DBDOT))
        rninf.endpoint = rvalue.Remove(0, rvalue.IndexOf(conrex.DBDOT) + 2)
        If rninf.endpoint.ToString.StartsWith(conrex.EQU) Then
            rninf.endpoint = rninf.endpoint.ToString.Remove(0, 1)
            rninf.ignorelastpoint = False ' [0..=5]
        Else
            rninf.ignorelastpoint = True ' [0..5]
        End If
        If rninf.endpoint.ToString.Contains(";") Then
            rninf.stepsc = rninf.endpoint.ToString.Remove(0, rninf.endpoint.ToString.IndexOf(";") + 1)
            rninf.endpoint = rninf.endpoint.ToString.Remove(rninf.endpoint.ToString.IndexOf(";"))
        End If
        Return rninf
    End Function
End Class
