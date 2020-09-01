Public Class cil

    ''' <summary>
    ''' ldstr [str]
    ''' </summary>
    Public Shared Sub load_string(ByRef codes As ArrayList, value As String)
        If value.StartsWith(conrex.COSTR) OrElse value.StartsWith(conrex.DUSTR) Then
            specificdustrcommand.reset_line_feed(value)
            If value.StartsWith(conrex.DUSTR) Then
                specificdustrcommand.get_specific_dustr_command(value)
            Else
                specificdustrcommand.rem_specific_cil_char(value)
            End If
            authfunc.rem_fr_and_en(value)
        End If
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

    ''' <summary>
    ''' ldloc [str]
    ''' </summary>
    ''' <param name="codes"></param>
    ''' <param name="name"></param>
    Public Shared Sub load_local_variable(ByRef codes As ArrayList, name As String)
        codes.Add("ldloc " & name)
    End Sub

    ''' <summary>
    ''' ldc.i4.s[int32] Push int32 onto stack 
    ''' </summary>
    ''' <param name="codes"></param>
    ''' <param name="value"></param>
    Public Shared Sub push_int32_onto_stack(ByRef codes As ArrayList, value As Decimal)
        If value >= 0 AndAlso value < 9 Then
            codes.Add("ldc.i4." & value)
        Else
            codes.Add("ldc.i4 " & value)
        End If
    End Sub

    ''' <summary>
    ''' ldc.i8 [int64] Push int64 onto stack 
    ''' </summary>
    ''' <param name="codes"></param>
    Public Shared Sub push_int64_onto_stack(ByRef codes As ArrayList, value As Object)
        codes.Add("ldc.i8 " & value)
    End Sub

    ''' <summary>
    '''     Convert to int64, pushing int64 on stack. 
    ''' </summary>
    ''' <param name="codes"></param>
    Public Shared Sub conv_to_int64(ByRef codes As ArrayList)
        codes.Add("conv.i8")
    End Sub

    ''' <summary>
    ''' insert il code .
    ''' </summary>
    ''' <param name="codes"></param>
    Public Shared Sub insert_il(ByRef codes As ArrayList, value As Object)
        codes.Add(value)
    End Sub
End Class
