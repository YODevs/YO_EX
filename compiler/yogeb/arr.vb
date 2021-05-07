Public Class arr

    Friend Shared Function check_array_struct(ByRef varname As String, ByRef arrayinf As ilformat._arrayinfo, ByRef isarrayobj As Boolean) As Boolean
        Dim bkvarname As String = varname
        varname = servinterface.get_array_name(varname)
        If varname <> bkvarname Then
            isarrayobj = True
            arrayinf.isarrayref = True
            arrayinf.isunspecifiedelements = is_unspecified_elements(bkvarname, arrayinf.elementsp)
            Return True
        End If
        isarrayobj = False
        arrayinf.isarrayref = False
        Return False
    End Function

    Friend Shared Function is_unspecified_elements(varname As String, ByRef getelementsp As Object) As Boolean
        If varname.Length = 0 Then Return False
        Dim getelements As String = varname.Remove(0, varname.IndexOf(conrex.BRSTART))
        getelementsp = getelements
        If getelements = conrex.BRSTEN Then
            Return True
        End If
        Return False
    End Function
End Class
