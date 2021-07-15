Imports YOCA

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

    Friend Shared Sub set_new_arr(ByRef ilmethod As ilformat._ilmethodcollection, illocalinit As ilformat._illocalinit, clinecodestruc As xmlunpkd.linecodestruc)
        If illocalinit.isarrayobj = False OrElse illocalinit.arrayinf.isunspecifiedelements Then Return
        Dim elementsp As String = illocalinit.arrayinf.elementsp
        authfunc.rem_fr_and_en(elementsp)
        If IsNumeric(elementsp) Then
            servinterface.ldc_i_checker(ilmethod.codes, elementsp, False, "int32")
        Else
            illdloc.ld_identifier(elementsp, ilmethod, clinecodestruc, Nothing, "int32")
        End If
        cil.new_arr(ilmethod.codes, illocalinit.typeinf)
        setloc = True
    End Sub

    Friend Shared setloc As Boolean = False
    Friend Shared Sub set_loc(ByRef ilmethod As ilformat._ilmethodcollection, illocalinit As ilformat._illocalinit, clinecodestruc As xmlunpkd.linecodestruc)
        If setloc = False Then Return
        ilstvar.st_identifier(illocalinit.name, ilmethod, clinecodestruc, illocalinit.typeinf.fullname)
        setloc = False
    End Sub
End Class
