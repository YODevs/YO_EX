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
    ''' ldarg [str]
    ''' </summary>
    ''' <param name="codes"></param>
    ''' <param name="name"></param>
    Public Shared Sub load_argument(ByRef codes As ArrayList, name As String)
        codes.Add("ldarg " & name)
    End Sub

    ''' <summary>
    ''' ldc.i4.s[int32] Push int32 onto stack 
    ''' </summary>
    ''' <param name="codes"></param>
    ''' <param name="value"></param>
    Public Shared Sub push_int32_onto_stack(ByRef codes As ArrayList, value As Decimal)
        If value >= 0 AndAlso value < 9 Then
            codes.Add("ldc.i4." & value)
        ElseIf value >= -128 AndAlso value <= 127 Then
            push_int32_sbyte_onto_stack(codes, value)
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

    Public Shared Sub push_int32_sbyte_onto_stack(ByRef codes As ArrayList, value As Decimal)
        If value >= -128 AndAlso value <= 127 Then
            codes.Add("ldc.i4.s " & value)
        Else
            push_int32_onto_stack(codes, value)
        End If
    End Sub
    ''' <summary>
    ''' ldc.r4 [float32]
    ''' </summary>
    ''' <param name="codes"></param>
    ''' <param name="value"></param>
    Public Shared Sub push_float32_onto_stack(ByRef codes As ArrayList, value As Object)
        codes.Add("ldc.r4 " & value)
    End Sub

    ''' <summary>
    ''' ldc.r8 [float64]
    ''' </summary>
    ''' <param name="codes"></param>
    ''' <param name="value"></param>
    Public Shared Sub push_float64_onto_stack(ByRef codes As ArrayList, value As Object)
        codes.Add("ldc.r8 " & value)
    End Sub
    ''' <summary>
    '''Convert to int64, pushing int64 on stack. 
    ''' </summary>
    ''' <param name="codes"></param>
    Public Shared Sub conv_to_int64(ByRef codes As ArrayList)
        codes.Add("conv.i8")
    End Sub

    ''' <summary>
    '''Convert to int32, pushing int32 on stack. 
    ''' </summary>
    ''' <param name="codes"></param>
    Public Shared Sub conv_to_int32(ByRef codes As ArrayList)
        codes.Add("conv.i4")
    End Sub

    ''' <summary>
    ''' conv.r8
    ''' </summary>
    ''' <param name="codes"></param>
    Public Shared Sub conv_to_float64(ByRef codes As ArrayList)
        codes.Add("conv.r8")
    End Sub


    ''' <summary>
    ''' conv.r4
    ''' </summary>
    ''' <param name="codes"></param>
    Public Shared Sub conv_to_float32(ByRef codes As ArrayList)
        codes.Add("conv.r4")
    End Sub

    ''' <summary>
    ''' insert il code .
    ''' </summary>
    ''' <param name="codes"></param>
    Public Shared Sub insert_il(ByRef codes As ArrayList, value As Object)
        If value.ToString.Trim = Nothing Then Return
        codes.Add(value)
    End Sub

    Public Shared Sub ceq(ByRef codes As ArrayList)
        codes.Add("ceq")
    End Sub

    Public Shared Sub add(ByRef codes As ArrayList)
        codes.Add("add")
    End Sub
    Public Shared Sub pop(ByRef codes As ArrayList)
        codes.Add("pop")
    End Sub
    Public Shared Sub branch_if_false(ByRef codes As ArrayList, label As Object)
        codes.Add("brfalse " & label)
    End Sub
    Public Shared Sub branch_if_true(ByRef codes As ArrayList, label As Object)
        codes.Add("brtrue " & label)
    End Sub

    Public Shared Sub branch_to_target(ByRef codes As ArrayList, label As Object)
        codes.Add("br " & label)
    End Sub

    Public Shared Sub concat_simple(ByRef codes As ArrayList)
        codes.Add("call string [mscorlib]System.String::Concat(string, string)")
    End Sub

    ''' <summary>
    ''' Exit a protected region of code. 
    ''' </summary>
    Public Shared Sub leave(ByRef codes As ArrayList, label As Object)
        codes.Add("leave " & label)
    End Sub
    ''' <summary>
    ''' Throw Simple ex : err statement
    ''' </summary>
    ''' <param name="codes"></param>
    ''' <param name="exceptiontext"></param>
    Public Shared Sub throw_simple(ByRef codes As ArrayList, exceptiontext As Object)
        load_string(codes, exceptiontext)
        codes.Add("newobj instance void [mscorlib]System.Exception::.ctor(string)")
        codes.Add("throw")
    End Sub

    Public Shared Sub call_method(ByRef codes As ArrayList, returntype As String, asmextern As String, classprop As String, methodname As String, paramtypes As ArrayList)
        Dim code As String = "call "
        If returntype = Nothing Then
            code &= "void"
        Else
            code &= returntype
        End If
        code &= conrex.SPACE
        code &= String.Format("[{0}]{1}::{2}", asmextern, classprop, methodname)
        If IsNothing(paramtypes) OrElse paramtypes.Count > 0 Then
            code &= "()"
        Else
            code &= conrex.PRSTART
            For index = 0 To paramtypes.Count - 1
                If index = paramtypes.Count - 1 Then
                    code &= paramtypes(index) & conrex.PREND
                Else
                    code &= paramtypes(index) & conrex.CMA
                End If
            Next
        End If
        codes.Add(code)
    End Sub

    Public Shared Sub call_intern_method(ByRef codes As ArrayList, returntype As String, classprop As String, methodname As String, paramtypes As ArrayList)
        Dim code As String = "call "
        If returntype = Nothing Then
            code &= "void"
        Else
            code &= returntype
        End If
        code &= conrex.SPACE
        code &= String.Format("{0}::{1}", classprop, methodname)
        If IsNothing(paramtypes) OrElse paramtypes.Count = 0 Then
            code &= "()"
        Else
            code &= conrex.PRSTART
            For index = 0 To paramtypes.Count - 1
                If index = paramtypes.Count - 1 Then
                    code &= paramtypes(index) & conrex.PREND
                Else
                    code &= paramtypes(index) & conrex.CMA
                End If
            Next
        End If
        codes.Add(code)
    End Sub

End Class
