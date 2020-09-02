Public Class ilopt

    Dim _ilmethod As ilformat._ilmethodcollection
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function assi_str(varname As String, clinecodestruc As xmlunpkd.linecodestruc) As ilformat._ilmethodcollection
        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_DU_STR
                cil.load_string(_ilmethod.codes, clinecodestruc.value)
            Case tokenhared.token.TYPE_CO_STR
                cil.load_string(_ilmethod.codes, clinecodestruc.value)
            Case tokenhared.token.IDENTIFIER
                If assignmentcommondatatype.check_locals_init(_ilmethod.name, clinecodestruc.value, _ilmethod.locallinit, "string") Then
                    cil.load_local_variable(_ilmethod.codes, clinecodestruc.value)
                End If

            'let value : str = NULL
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)

            Case Else
                'Set Error 
        End Select

        cil.set_stack_local(_ilmethod.codes, varname)

        Return _ilmethod
    End Function

    Public Function assi_int(varname As String, clinecodestruc As xmlunpkd.linecodestruc, datatype As String) As ilformat._ilmethodcollection
        Dim convtoi8 As Boolean = servinterface.is_i8(datatype)

        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_INT
                servinterface.ldc_i_checker(_ilmethod.codes, clinecodestruc.value, convtoi8)
            Case tokenhared.token.TYPE_FLOAT
                servinterface.ldc_i_checker(_ilmethod.codes, clinecodestruc.value, convtoi8)
            Case tokenhared.token.IDENTIFIER
                If assignmentcommondatatype.check_locals_init(_ilmethod.name, clinecodestruc.value, _ilmethod.locallinit, datatype) Then
                    cil.load_local_variable(_ilmethod.codes, clinecodestruc.value)
                End If
            'let value : str = NULL
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case tokenhared.token.EXPRESSION
                Dim expr As New expressiondt(_ilmethod, "i32")
                _ilmethod = expr.parse_expression_data(clinecodestruc.value, convtoi8)
            Case Else
                'Set Error 
        End Select

        cil.set_stack_local(_ilmethod.codes, varname)

        Return _ilmethod
    End Function

    Public Function assi_float(varname As String, clinecodestruc As xmlunpkd.linecodestruc, datatype As String) As ilformat._ilmethodcollection
        Dim convtor8 As Boolean = False
        If datatype = "f64" Then convtor8 = True

        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_INT
                servinterface.ldc_r_checker(_ilmethod.codes, clinecodestruc.value, convtor8)
            Case tokenhared.token.TYPE_FLOAT
                servinterface.ldc_r_checker(_ilmethod.codes, clinecodestruc.value, convtor8)
            Case tokenhared.token.IDENTIFIER
                If assignmentcommondatatype.check_locals_init(_ilmethod.name, clinecodestruc.value, _ilmethod.locallinit, datatype) Then
                    cil.load_local_variable(_ilmethod.codes, clinecodestruc.value)
                End If
            'let value : str = NULL
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case tokenhared.token.EXPRESSION
                Dim expr As New expressiondt(_ilmethod, "f32")
                _ilmethod = expr.parse_expression_data(clinecodestruc.value, convtor8)
            Case Else
                'Set Error 
        End Select

        cil.set_stack_local(_ilmethod.codes, varname)

        Return _ilmethod
    End Function

End Class
