Public Class servinterface
    Friend Shared Sub ldc_i_checker(ByRef codes As ArrayList, value As Object, Optional convtoi8 As Boolean = False)
        rem_float(value)
        If value.ToString.Length > 10 AndAlso CDec(value) > Int32.MaxValue Or CDec(value) < Int32.MinValue Then
            cil.push_int64_onto_stack(codes, CDec(value))
        Else
            cil.push_int32_onto_stack(codes, CDec(value))
            If convtoi8 Then
                cil.conv_to_int64(codes)
            End If
        End If
    End Sub

    Friend Shared Function is_i8(datatype As String) As Boolean
        For index = 0 To compdt.i8cmtypes.Length - 1
            If datatype = compdt.i8cmtypes(index) Then
                Return True
            End If
        Next
        Return False
    End Function

    Friend Shared Sub rem_float(ByRef value As Object)
        If value.ToString.Contains(conrex.DOT) Then
            Dim expr As String = value
            value = CObj(expr.Remove(expr.IndexOf(conrex.DOT)))
            Return
        End If
    End Sub
End Class
