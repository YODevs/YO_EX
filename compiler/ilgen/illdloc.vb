Public Class illdloc
    Public _ilmethod As ilformat._ilmethodcollection
    Private Shared ldptr As Boolean = False
    Public Sub New(_ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = _ilmethod
    End Sub

    Friend Shared Function check_integer_type(datatype As String) As String
        For index = 0 To compdt.cilintegertypes.Length - 1
            If compdt.cilintegertypes(index) = datatype Then
                Return datatype
            End If
        Next
        Return Nothing
    End Function

    Friend Shared Function check_yo_integer_type(datatype As String) As String
        For index = 0 To compdt.yointegertypes.Length - 1
            If compdt.yointegertypes(index) = datatype Then
                Return datatype
            End If
        Next
        Return Nothing
    End Function

    Friend Shared Function check_float_type(datatype As String) As String
        Select Case datatype.ToLower
            Case "float32"
                Return "float32"
            Case "float64"
                Return "float64"
            Case Else
                Return Nothing
        End Select
    End Function
    Friend Shared Function check_yo_float_type(datatype As String) As String
        Select Case datatype.ToLower
            Case "f32"
                Return "f32"
            Case "f64"
                Return "f64"
            Case Else
                Return Nothing
        End Select
    End Function
    Public Function load_in_stack(paramtypes As ArrayList, cargcodestruc As xmlunpkd.linecodestruc()) As ilformat._ilmethodcollection
        Dim getdatatype As String = conrex.NULL
        For index = 0 To cargcodestruc.Length - 1
            getdatatype = paramtypes(index).ToString()
            If getdatatype.EndsWith("&") Then
                getdatatype = getdatatype.Remove(getdatatype.Length - 1)
                ldptr = True
            Else
                ldptr = False
            End If
            Select Case getdatatype
                Case "string"
                    ldstr(cargcodestruc(index))
                Case check_integer_type(getdatatype)
                    ldint(cargcodestruc(index), getdatatype)
                Case "float32"
                    ldflt(cargcodestruc(index), getdatatype)
                Case "float64"
                    ldflt(cargcodestruc(index), getdatatype)
                Case "char"
                    ldchr(cargcodestruc(index), getdatatype)
                Case "bool"
                    ldbool(cargcodestruc(index), getdatatype)
                Case Else
                    'Other Types
            End Select
        Next

        ldptr = False
        Return _ilmethod
    End Function

    Public Function load_single_in_stack(datatype As String, cargcodestruc As xmlunpkd.linecodestruc) As ilformat._ilmethodcollection
        Select Case datatype
            Case "string"
                ldstr(cargcodestruc)
            Case check_integer_type(datatype)
                ldint(cargcodestruc, datatype)
            Case "float32"
                ldflt(cargcodestruc, datatype)
            Case "float64"
                ldflt(cargcodestruc, datatype)
            Case "char"
                ldchr(cargcodestruc, datatype)
            Case "bool"
                ldbool(cargcodestruc, datatype)
            Case Else
                'Other Types
        End Select

        Return _ilmethod
    End Function
    Friend Shared Function ld_identifier(nvar As String, ByRef _ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, rlinecodestruc() As xmlunpkd.linecodestruc, datatype As String) As Boolean
        If IsNothing(rlinecodestruc) = False Then
            Dim funcresult As funcvalid._resultfuncvaild = funcvalid.get_func_valid(rlinecodestruc)
            If funcresult.funcvalid Then
                funcste.invoke_method(rlinecodestruc, _ilmethod, funcresult, False)
                Return True
            End If
        End If

        If IsNothing(_ilmethod.locallinit) = False OrElse nvar.Contains(compdt.FLAGPERFIX) Then
            If ld_local(nvar, _ilmethod, cargcodestruc, datatype) Then Return True
        End If
        If IsNothing(_ilmethod.parameter) = False Then
            If ld_argument(nvar, _ilmethod, cargcodestruc, datatype) Then Return True
        End If

        dserr.args.Add(nvar)
        dserr.new_error(conserr.errortype.TYPENOTFOUND, cargcodestruc.line, ilbodybulider.path, "Method : " & _ilmethod.name & " - Unknown identifier : " & nvar & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
        Return False
    End Function

    Friend Shared Function ld_local(nvar As String, ByRef _ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, datatype As String) As Boolean
        Dim nvartolower As String = nvar.ToLower
        Dim pnvar As String = String.Empty
        If nvar.StartsWith(compdt.FLAGPERFIX) Then
            cil.load_local_variable(_ilmethod.codes, nvar)
            Return True
        End If
        For index = 0 To _ilmethod.locallinit.Length - 1
            pnvar = _ilmethod.locallinit(index).name
            If pnvar <> conrex.NULL AndAlso pnvar.ToLower = nvartolower Then
                If _ilmethod.locallinit(index).datatype = datatype Then
                    If ldptr Then
                        cil.load_local_address(_ilmethod.codes, nvar)
                        Return True
                    Else
                        cil.load_local_variable(_ilmethod.codes, nvar)
                        Return True
                    End If
                Else
                    dserr.args.Add(_ilmethod.locallinit(index).datatype)
                    dserr.args.Add(datatype)
                    dserr.new_error(conserr.errortype.EXPLICITCONVERSION, cargcodestruc.line, ilbodybulider.path, "Method : " & _ilmethod.name & " - identifier : " & nvar & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
                    Return False
                End If
            End If
        Next
        Return False
    End Function
    Friend Shared Function ld_argument(nvar As String, ByRef _ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, datatype As String) As Boolean
        Dim nvartolower As String = nvar.ToLower
        Dim pnvar As String = String.Empty
        For index = 0 To _ilmethod.parameter.Length - 1
            pnvar = _ilmethod.parameter(index).name
            If pnvar <> conrex.NULL AndAlso pnvar.ToLower = nvartolower Then
                Dim getcildatatype As String = String.Empty
                If servinterface.is_common_data_type(_ilmethod.parameter(index).datatype, getcildatatype) = False Then
                    getcildatatype = _ilmethod.parameter(index).datatype
                End If

                If datatype = getcildatatype Then
                    If ldptr Then
                        cil.load_local_address(_ilmethod.codes, nvar)
                        Return True
                    ElseIf _ilmethod.parameter(index).ispointer Then
                        cil.load_argument(_ilmethod.codes, nvar)
                        cil.load_pointer(_ilmethod.codes, datatype)
                        Return True
                    Else
                        cil.load_argument(_ilmethod.codes, nvar)
                        Return True
                    End If
                Else
                    dserr.args.Add(_ilmethod.locallinit(index).datatype)
                    dserr.args.Add(datatype)
                    dserr.new_error(conserr.errortype.EXPLICITCONVERSION, cargcodestruc.line, ilbodybulider.path, "Method : " & _ilmethod.name & " - identifier : " & nvar & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
                    Return False
                End If
            End If
        Next
        Return False
    End Function

    Private Sub ldstr(cargcodestruc As xmlunpkd.linecodestruc)
        Select Case cargcodestruc.tokenid
            Case tokenhared.token.TYPE_DU_STR
                cil.load_string(_ilmethod.codes, cargcodestruc.value)
            Case tokenhared.token.TYPE_CO_STR
                cil.load_string(_ilmethod.codes, cargcodestruc.value)
            Case tokenhared.token.IDENTIFIER
                ld_identifier(cargcodestruc.value, _ilmethod, cargcodestruc, Nothing, "string")
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case Else
                'Set Error 
                dserr.args.Add(cargcodestruc.value)
                dserr.args.Add("string")
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, cargcodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
        End Select
    End Sub

    Private Sub ldint(cargcodestruc As xmlunpkd.linecodestruc, datatype As String)
        Dim convtoi8 As Boolean = servinterface.is_i8(datatype)
        servinterface.clinecodestruc = cargcodestruc
        Select Case cargcodestruc.tokenid
            Case tokenhared.token.TYPE_INT
                servinterface.ldc_i_checker(_ilmethod.codes, cargcodestruc.value, convtoi8, datatype)
            Case tokenhared.token.TYPE_FLOAT
                servinterface.ldc_i_checker(_ilmethod.codes, cargcodestruc.value, convtoi8, datatype)
            Case tokenhared.token.IDENTIFIER
                ld_identifier(cargcodestruc.value, _ilmethod, cargcodestruc, Nothing, datatype)
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case tokenhared.token.EXPRESSION
                Dim expr As New expressiondt(_ilmethod, "i32")
                Try
                    _ilmethod = expr.parse_expression_data(cargcodestruc.value, convtoi8)
                Catch ex As Exception
                    dserr.args.Add(ex.Message)
                    dserr.new_error(conserr.errortype.EXPRESSIONERROR, cargcodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
                End Try
            Case Else
                'Set Error 
                dserr.args.Add(cargcodestruc.value)
                dserr.args.Add(datatype)
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, cargcodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
        End Select
    End Sub

    Private Sub ldflt(cargcodestruc As xmlunpkd.linecodestruc, datatype As String)
        Dim convtor8 As Boolean = False
        If datatype = "float64" Then convtor8 = True
        Select Case cargcodestruc.tokenid
            Case tokenhared.token.TYPE_INT
                servinterface.ldc_r_checker(_ilmethod.codes, cargcodestruc.value, convtor8)
            Case tokenhared.token.TYPE_FLOAT
                servinterface.ldc_r_checker(_ilmethod.codes, cargcodestruc.value, convtor8)
            Case tokenhared.token.IDENTIFIER
                ld_identifier(cargcodestruc.value, _ilmethod, cargcodestruc, Nothing, datatype)
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case tokenhared.token.EXPRESSION
                Dim expr As New expressiondt(_ilmethod, "f32")
                Try
                    _ilmethod = expr.parse_expression_data(cargcodestruc.value, convtor8)
                Catch ex As Exception
                    dserr.args.Add(ex.Message)
                    dserr.new_error(conserr.errortype.EXPRESSIONERROR, cargcodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
                End Try
            Case Else
                'Set Error 
                dserr.args.Add(cargcodestruc.value)
                dserr.args.Add(datatype)
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, cargcodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
        End Select
    End Sub

    Private Sub ldchr(cargcodestruc As xmlunpkd.linecodestruc, datatype As String)
        Dim convtoi8 As Boolean = servinterface.is_i8(datatype)
        servinterface.clinecodestruc = cargcodestruc
        Select Case cargcodestruc.tokenid
            Case tokenhared.token.TYPE_DU_STR
                If cargcodestruc.value.Length >= 3 Then
                    cil.push_int32_onto_stack(_ilmethod.codes, AscW(cargcodestruc.value(1)))
                Else
                    'example : value := ""
                    cil.push_null_reference(_ilmethod.codes)
                End If
            Case tokenhared.token.TYPE_CO_STR
                If cargcodestruc.value.Length >= 3 Then
                    cil.push_int32_onto_stack(_ilmethod.codes, AscW(cargcodestruc.value(1)))
                Else
                    'example : value := ''
                    cil.push_null_reference(_ilmethod.codes)
                End If
            Case tokenhared.token.IDENTIFIER
                ld_identifier(cargcodestruc.value, _ilmethod, cargcodestruc, Nothing, datatype)
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case Else
                'Set Error 
                dserr.args.Add(cargcodestruc.value)
                dserr.args.Add(datatype)
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, cargcodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
        End Select
    End Sub

    Private Sub ldbool(cargcodestruc As xmlunpkd.linecodestruc, datatype As String)
        Dim convtoi8 As Boolean = servinterface.is_i8(datatype)
        servinterface.clinecodestruc = cargcodestruc
        Select Case cargcodestruc.tokenid
            Case tokenhared.token.TRUE
                cil.push_int32_onto_stack(_ilmethod.codes, 1)
            Case tokenhared.token.FALSE
                cil.push_int32_onto_stack(_ilmethod.codes, 0)
            Case tokenhared.token.IDENTIFIER
                If assignmentcommondatatype.check_locals_init(_ilmethod.name, cargcodestruc.value, _ilmethod.locallinit, datatype) Then
                    cil.load_local_variable(_ilmethod.codes, cargcodestruc.value)
                End If
            Case tokenhared.token.TYPE_INT
                ld_identifier(cargcodestruc.value, _ilmethod, cargcodestruc, Nothing, datatype)
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case Else
                'Set Error 
                dserr.args.Add(cargcodestruc.value)
                dserr.args.Add(datatype)
                dserr.new_error(conserr.errortype.ASSIGNCONVERT, cargcodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
        End Select
    End Sub
End Class
