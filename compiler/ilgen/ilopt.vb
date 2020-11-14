Public Class ilopt

    Dim _ilmethod As ilformat._ilmethodcollection
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function assiandeq(varname As String, clinecodestruc As xmlunpkd.linecodestruc) As ilformat._ilmethodcollection
        cil.load_local_variable(_ilmethod.codes, varname)
        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_DU_STR
                cil.load_string(_ilmethod.codes, clinecodestruc.value)
            Case tokenhared.token.TYPE_CO_STR
                cil.load_string(_ilmethod.codes, clinecodestruc.value)
            Case tokenhared.token.IDENTIFIER
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, "string")
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add("string")
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
        End Select

        cil.concat_simple(_ilmethod.codes)
        cil.set_stack_local(_ilmethod.codes, varname)

        Return _ilmethod
    End Function


    Public Function assi_str(varname As String, clinecodestruc As xmlunpkd.linecodestruc) As ilformat._ilmethodcollection
        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_DU_STR
                cil.load_string(_ilmethod.codes, clinecodestruc.value)
            Case tokenhared.token.TYPE_CO_STR
                cil.load_string(_ilmethod.codes, clinecodestruc.value)
            Case tokenhared.token.IDENTIFIER
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, "string")
            'let value : str = NULL
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add("string")
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
        End Select

        cil.set_stack_local(_ilmethod.codes, varname)

        Return _ilmethod
    End Function

    Public Function assi_int(varname As String, clinecodestruc As xmlunpkd.linecodestruc, datatype As String) As ilformat._ilmethodcollection
        Dim convtoi8 As Boolean = servinterface.is_i8(datatype)
        servinterface.clinecodestruc = clinecodestruc
        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_INT
                servinterface.ldc_i_checker(_ilmethod.codes, clinecodestruc.value, convtoi8, datatype)
            Case tokenhared.token.TYPE_FLOAT
                servinterface.ldc_i_checker(_ilmethod.codes, clinecodestruc.value, convtoi8, datatype)
            Case tokenhared.token.IDENTIFIER
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, datatype)
            'let value : str = NULL
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case tokenhared.token.EXPRESSION
                Dim expr As New expressiondt(_ilmethod, "i32")
                Try
                    _ilmethod = expr.parse_expression_data(clinecodestruc.value, convtoi8)
                Catch ex As Exception
                    dserr.args.Add(ex.Message)
                    dserr.new_error(conserr.errortype.EXPRESSIONERROR, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
                End Try
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add(datatype)
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))

        End Select

        cil.set_stack_local(_ilmethod.codes, varname)

        Return _ilmethod
    End Function

    Public Function assi_bool(varname As String, clinecodestruc As xmlunpkd.linecodestruc, datatype As String) As ilformat._ilmethodcollection
        Dim convtoi8 As Boolean = servinterface.is_i8(datatype)
        servinterface.clinecodestruc = clinecodestruc
        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TRUE
                cil.push_int32_onto_stack(_ilmethod.codes, 1)
            Case tokenhared.token.FALSE
                cil.push_int32_onto_stack(_ilmethod.codes, 0)
            Case tokenhared.token.IDENTIFIER
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, datatype)
            Case tokenhared.token.TYPE_INT
                servinterface.ldc_i_checker(_ilmethod.codes, clinecodestruc.value, convtoi8, datatype)
            'let value : str = NULL
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add(datatype)
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
        End Select

        cil.set_stack_local(_ilmethod.codes, varname)

        Return _ilmethod
    End Function

    Public Function assi_char(varname As String, clinecodestruc As xmlunpkd.linecodestruc, datatype As String) As ilformat._ilmethodcollection
        Dim convtoi8 As Boolean = servinterface.is_i8(datatype)
        servinterface.clinecodestruc = clinecodestruc
        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_DU_STR
                If clinecodestruc.value.Length >= 3 Then
                    cil.push_int32_onto_stack(_ilmethod.codes, AscW(clinecodestruc.value(1)))
                Else
                    'example : value := ""
                    cil.push_null_reference(_ilmethod.codes)
                End If
            Case tokenhared.token.TYPE_CO_STR
                If clinecodestruc.value.Length >= 3 Then
                    cil.push_int32_onto_stack(_ilmethod.codes, AscW(clinecodestruc.value(1)))
                Else
                    'example : value := ''
                    cil.push_null_reference(_ilmethod.codes)
                End If
            Case tokenhared.token.IDENTIFIER
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, datatype)
                'let value : str = NULL
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add(datatype)
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
        End Select

        cil.set_stack_local(_ilmethod.codes, varname)

        Return _ilmethod
    End Function
    Public Function assi_float(varname As String, clinecodestruc As xmlunpkd.linecodestruc, datatype As String) As ilformat._ilmethodcollection
        Dim convtor8 As Boolean = False
        If datatype = "float64" Then convtor8 = True
        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_INT
                servinterface.ldc_r_checker(_ilmethod.codes, clinecodestruc.value, convtor8)
            Case tokenhared.token.TYPE_FLOAT
                servinterface.ldc_r_checker(_ilmethod.codes, clinecodestruc.value, convtor8)
            Case tokenhared.token.IDENTIFIER
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, datatype)
            'let value : str = NULL
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case tokenhared.token.EXPRESSION
                Dim expr As New expressiondt(_ilmethod, "f32")
                Try
                    _ilmethod = expr.parse_expression_data(clinecodestruc.value, convtor8)
                Catch ex As Exception
                    dserr.args.Add(ex.Message)
                    dserr.new_error(conserr.errortype.EXPRESSIONERROR, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
                End Try
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add(datatype)
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
        End Select

        cil.set_stack_local(_ilmethod.codes, varname)

        Return _ilmethod
    End Function

End Class
