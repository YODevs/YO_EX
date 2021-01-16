Public Class rangeserv

    Structure ranginf
        Dim startpoint As Object
        Dim endpoint As Object
        Dim stepsc As Integer
    End Structure
    Public Shared Function get_range_info(rangestring As xmlunpkd.linecodestruc) As ranginf
        If rangestring.tokenid <> tokenhared.token.RANGE Then Return Nothing
        Dim rvalue As String = rangestring.value
        authfunc.rem_fr_and_en(rvalue)
        Dim rninf As New ranginf
        rninf.stepsc = 1
        rninf.startpoint = rvalue.Remove(rvalue.IndexOf(conrex.DBDOT))
        rninf.endpoint = rvalue.Remove(0, rvalue.IndexOf(conrex.DBDOT) + 2)
        Return rninf
    End Function
End Class
