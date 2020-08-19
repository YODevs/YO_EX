Public Class cil

    ''' <summary>
    ''' ldstr [str]
    ''' </summary>
    Public Shared Sub load_string(ByRef codes As ArrayList, value As String)
        'TODO : Check DU Or Co String .
        authfunc.rem_fr_and_en(value)
        codes.Add("ldstr " & conrex.DUSTR & value & conrex.DUSTR)
    End Sub

    ''' <summary>
    ''' stloc [str]
    ''' </summary>
    Public Shared Sub set_stack_local(ByRef codes As ArrayList, name As String)
        codes.Add("stloc " & name)
    End Sub

    ''' <summary>
    ''' ldnull
    ''' </summary>
    ''' <param name="codes"></param>
    Public Shared Sub push_null_reference(ByRef codes As ArrayList)
        codes.Add("ldnull")
    End Sub
End Class
