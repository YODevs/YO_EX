Imports YOCA

Public Class ilopt

    Dim _ilmethod As ilformat._ilmethodcollection
    Dim rlinecodestruc As xmlunpkd.linecodestruc()
    Public Sub New(ilmethod As ilformat._ilmethodcollection, linecodestruc As xmlunpkd.linecodestruc())
        Me._ilmethod = ilmethod
        Me.rlinecodestruc = linecodestruc
    End Sub

    Friend Function assidiv(varname As String, clinecodestruc As xmlunpkd.linecodestruc, datatype As String, Optional isfloat As Boolean = False) As ilformat._ilmethodcollection
        Dim convi8 As Boolean = False
        Dim convr8 As Boolean = False
        If datatype.ToLower = "i64" Then convi8 = True
        If datatype.ToLower = "f64" Then convr8 = True

        If servinterface.is_pointer(_ilmethod, varname) Then
            cil.load_argument(_ilmethod.codes, varname)
        End If

        servinterface.is_common_data_type(datatype, datatype)
        illdloc.ld_identifier(varname, _ilmethod, clinecodestruc, Nothing, datatype)

        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_FLOAT
                If isfloat Then
                    servinterface.ldc_r_checker(_ilmethod.codes, clinecodestruc.value, convr8)
                Else
                    servinterface.ldc_i_checker(_ilmethod.codes, clinecodestruc.value, convi8, datatype)
                End If
            Case tokenhared.token.TYPE_INT
                If isfloat Then
                    servinterface.ldc_r_checker(_ilmethod.codes, clinecodestruc.value, convr8)
                Else
                    servinterface.ldc_i_checker(_ilmethod.codes, clinecodestruc.value, convi8, datatype)
                End If
            Case tokenhared.token.IDENTIFIER
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, rlinecodestruc, datatype)
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add("i64/i32/i16/i8/...")
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
        End Select

        cil.div(_ilmethod.codes)
        ilstvar.st_identifier(varname, _ilmethod, clinecodestruc, datatype)

        Return _ilmethod
    End Function

    Friend Function assimul(varname As String, clinecodestruc As xmlunpkd.linecodestruc, datatype As String, Optional isfloat As Boolean = False) As ilformat._ilmethodcollection
        Dim convi8 As Boolean = False
        Dim convr8 As Boolean = False
        If datatype.ToLower = "i64" Then convi8 = True
        If datatype.ToLower = "f64" Then convr8 = True

        If servinterface.is_pointer(_ilmethod, varname) Then
            cil.load_argument(_ilmethod.codes, varname)
        End If

        servinterface.is_common_data_type(datatype, datatype)
        illdloc.ld_identifier(varname, _ilmethod, clinecodestruc, Nothing, datatype)

        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_FLOAT
                If isfloat Then
                    servinterface.ldc_r_checker(_ilmethod.codes, clinecodestruc.value, convr8)
                Else
                    servinterface.ldc_i_checker(_ilmethod.codes, clinecodestruc.value, convi8, datatype)
                End If
            Case tokenhared.token.TYPE_INT
                If isfloat Then
                    servinterface.ldc_r_checker(_ilmethod.codes, clinecodestruc.value, convr8)
                Else
                    servinterface.ldc_i_checker(_ilmethod.codes, clinecodestruc.value, convi8, datatype)
                End If
            Case tokenhared.token.IDENTIFIER
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, rlinecodestruc, datatype)
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add("i64/i32/i16/i8/...")
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
        End Select

        cil.mul(_ilmethod.codes, True)
        ilstvar.st_identifier(varname, _ilmethod, clinecodestruc, datatype)

        Return _ilmethod
    End Function

    Friend Function assisub(varname As String, clinecodestruc As xmlunpkd.linecodestruc, datatype As String, Optional isfloat As Boolean = False) As ilformat._ilmethodcollection
        Dim convi8 As Boolean = False
        Dim convr8 As Boolean = False
        If datatype.ToLower = "i64" Then convi8 = True
        If datatype.ToLower = "f64" Then convr8 = True

        If servinterface.is_pointer(_ilmethod, varname) Then
            cil.load_argument(_ilmethod.codes, varname)
        End If

        servinterface.is_common_data_type(datatype, datatype)
        illdloc.ld_identifier(varname, _ilmethod, clinecodestruc, Nothing, datatype)

        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_FLOAT
                If isfloat Then
                    servinterface.ldc_r_checker(_ilmethod.codes, clinecodestruc.value, convr8)
                Else
                    servinterface.ldc_i_checker(_ilmethod.codes, clinecodestruc.value, convi8, datatype)
                End If
            Case tokenhared.token.TYPE_INT
                If isfloat Then
                    servinterface.ldc_r_checker(_ilmethod.codes, clinecodestruc.value, convr8)
                Else
                    servinterface.ldc_i_checker(_ilmethod.codes, clinecodestruc.value, convi8, datatype)
                End If
            Case tokenhared.token.IDENTIFIER
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, rlinecodestruc, datatype)
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add("i64/i32/i16/i8/...")
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
        End Select

        cil.sub(_ilmethod.codes, True)
        ilstvar.st_identifier(varname, _ilmethod, clinecodestruc, datatype)

        Return _ilmethod
    End Function

    Friend Function assiadd(varname As String, clinecodestruc As xmlunpkd.linecodestruc, datatype As String, Optional isfloat As Boolean = False) As ilformat._ilmethodcollection
        Dim convi8 As Boolean = False
        Dim convr8 As Boolean = False
        If datatype.ToLower = "i64" Then convi8 = True
        If datatype.ToLower = "f64" Then convr8 = True

        If servinterface.is_pointer(_ilmethod, varname) Then
            cil.load_argument(_ilmethod.codes, varname)
        End If

        servinterface.is_common_data_type(datatype, datatype)
        illdloc.ld_identifier(varname, _ilmethod, clinecodestruc, Nothing, datatype)

        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_FLOAT
                If isfloat Then
                    servinterface.ldc_r_checker(_ilmethod.codes, clinecodestruc.value, convr8)
                Else
                    servinterface.ldc_i_checker(_ilmethod.codes, clinecodestruc.value, convi8, datatype)
                End If
            Case tokenhared.token.TYPE_INT
                If isfloat Then
                    servinterface.ldc_r_checker(_ilmethod.codes, clinecodestruc.value, convr8)
                Else
                    servinterface.ldc_i_checker(_ilmethod.codes, clinecodestruc.value, convi8, datatype)
                End If
            Case tokenhared.token.IDENTIFIER
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, rlinecodestruc, datatype)
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add("i64/i32/i16/i8/...")
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
        End Select

        cil.add(_ilmethod.codes)
        ilstvar.st_identifier(varname, _ilmethod, clinecodestruc, datatype)

        Return _ilmethod
    End Function
    Public Function assiandeq(varname As String, clinecodestruc As xmlunpkd.linecodestruc) As ilformat._ilmethodcollection
        If servinterface.is_pointer(_ilmethod, varname) Then
            cil.load_argument(_ilmethod.codes, varname)
        End If
        illdloc.ld_identifier(varname, _ilmethod, clinecodestruc, Nothing, "string")
        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_DU_STR
                cil.load_string(_ilmethod, clinecodestruc.value, clinecodestruc)
            Case tokenhared.token.TYPE_CO_STR
                cil.load_string(_ilmethod, clinecodestruc.value, clinecodestruc)
            Case tokenhared.token.IDENTIFIER
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, rlinecodestruc, "string")
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add("string")
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
        End Select

        cil.concat_simple(_ilmethod.codes)
        ilstvar.st_identifier(varname, _ilmethod, clinecodestruc, "string")

        Return _ilmethod
    End Function

    Public Function assi_identifier(varname As String, clinecodestruc As xmlunpkd.linecodestruc, type As String) As ilformat._ilmethodcollection
        Select Case clinecodestruc.tokenid
            Case tokenhared.token.IDENTIFIER
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, rlinecodestruc, type)
            'let value : str = NULL
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add(type)
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
        End Select

        ilstvar.st_identifier(varname, _ilmethod, clinecodestruc, type)

        Return _ilmethod
    End Function
    Public Function assi_str(varname As String, clinecodestruc As xmlunpkd.linecodestruc) As ilformat._ilmethodcollection
        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_DU_STR
                cil.load_string(_ilmethod, clinecodestruc.value, clinecodestruc)
            Case tokenhared.token.TYPE_CO_STR
                cil.load_string(_ilmethod, clinecodestruc.value, clinecodestruc)
            Case tokenhared.token.IDENTIFIER
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, rlinecodestruc, "string")
            'let value : str = NULL
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add("string")
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
        End Select

        ilstvar.st_identifier(varname, _ilmethod, clinecodestruc, "string")

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
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, rlinecodestruc, datatype)
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

        ilstvar.st_identifier(varname, _ilmethod, clinecodestruc, datatype)

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
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, rlinecodestruc, datatype)
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

        ilstvar.st_identifier(varname, _ilmethod, clinecodestruc, datatype)

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
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, rlinecodestruc, datatype)
                'let value : str = NULL
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case Else
                'Set Error 
                dserr.args.Add(clinecodestruc.value)
                dserr.args.Add(datatype)
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
        End Select

        ilstvar.st_identifier(varname, _ilmethod, clinecodestruc, datatype)

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
                illdloc.ld_identifier(clinecodestruc.value, _ilmethod, clinecodestruc, rlinecodestruc, datatype)
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

        ilstvar.st_identifier(varname, _ilmethod, clinecodestruc, datatype)

        Return _ilmethod
    End Function


End Class
