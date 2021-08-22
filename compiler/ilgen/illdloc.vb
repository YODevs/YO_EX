Public Class illdloc
    Public _ilmethod As ilformat._ilmethodcollection
    Private Shared ldptr As Boolean = False
    Friend Shared ldindx As Boolean = False
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
            Case "single"
                Return "float32"
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
                Case conrex.STRING
                    ldstr(cargcodestruc(index))
                Case check_integer_type(getdatatype)
                    ldint(cargcodestruc(index), getdatatype)
                Case "single"
                    getdatatype = "float32"
                    ldflt(cargcodestruc(index), getdatatype)
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
                    ld_identifier(cargcodestruc(index).value, _ilmethod, cargcodestruc(index), Nothing, getdatatype)
            End Select
        Next

        ldptr = False
        ldindx = False
        Return _ilmethod
    End Function

    Public Function load_single_in_stack(datatype As String, cargcodestruc As xmlunpkd.linecodestruc) As ilformat._ilmethodcollection
        Select Case datatype
            Case conrex.STRING
                ldstr(cargcodestruc)
            Case check_integer_type(datatype)
                ldint(cargcodestruc, datatype)
            Case "single"
                datatype = "float32"
                ldflt(cargcodestruc, datatype)
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
                ld_identifier(cargcodestruc.value, _ilmethod, cargcodestruc, Nothing, datatype)
        End Select

        ldptr = False
        ldindx = False

        Return _ilmethod
    End Function
    Friend Shared Function ld_identifier(nvar As String, ByRef _ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, rlinecodestruc() As xmlunpkd.linecodestruc, datatype As String) As Boolean
        Dim clineprop As xmlunpkd.linecodestruc = cargcodestruc
        If IsNothing(rlinecodestruc) = False Then
            Dim funcresult As funcvalid._resultfuncvaild = funcvalid.get_func_valid(_ilmethod, rlinecodestruc)
            If funcresult.funcvalid Then
                funcste.assignmentype = datatype
                funcste.invoke_method(rlinecodestruc, _ilmethod, funcresult, False)
                Return True
            End If
            clineprop = rlinecodestruc(0)
        End If

        Dim idenresult As identvalid._resultidentcvaild = identvalid.get_identifier_valid(_ilmethod, clineprop)
        If idenresult.identvalid Then
            If enumeration.is_enum(_ilmethod, idenresult, cargcodestruc) Then
                Return True
            Else
                propertyste.assignmentype = datatype
                propertyste.get_inv_property(New xmlunpkd.linecodestruc() {clineprop}, _ilmethod, idenresult, 0)
                Return True
            End If
        End If

        If IsNothing(_ilmethod.locallinit) = False OrElse nvar.Contains(compdt.FLAGPERFIX) Then
            If ld_local(nvar, _ilmethod, cargcodestruc, datatype) Then Return True
        End If
        If IsNothing(_ilmethod.parameter) = False Then
            If ld_argument(nvar, _ilmethod, cargcodestruc, datatype) Then Return True
        End If
        If IsNothing(ilasmgen.fields) = False AndAlso nvar.Contains("::") = False Then
            If ld_field(nvar, _ilmethod, cargcodestruc, datatype) Then Return True
        End If

        If nvar.Contains("::") Then
            Dim hresult As identvalid._resultidentcvaild = identvalid.get_identifier_valid(_ilmethod, cargcodestruc)
            If hresult.identvalid = True Then
                If hresult.callintern = True Then
                    If ld_field_global(hresult, _ilmethod, cargcodestruc, datatype) Then Return True
                Else
                    'extern fields
                End If
            End If
        End If

        dserr.args.Add(nvar)
        dserr.new_error(conserr.errortype.TYPENOTFOUND, cargcodestruc.line, ilbodybulider.path, "Method : " & _ilmethod.name & " - Unknown identifier : " & nvar & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
        Return False
    End Function

    Friend Shared Function ld_field_global(hresult As identvalid._resultidentcvaild, ByRef _ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, datatype As String, Optional ByRef nactorcode As ArrayList = Nothing) As Boolean
        Dim nvar As String = hresult.clident
        Dim fieldindex As Integer = funcdtproc.get_index_field(nvar, hresult.classindex)
        If fieldindex = -1 Then
            dserr.args.Add("Identifier '" & hresult.clident & "' was not found in class " & hresult.exclass)
            dserr.new_error(conserr.errortype.FIELDERROR, cargcodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
        End If
        Dim hfield As tknformat._pubfield = funcdtproc.get_field_info(hresult.classindex, fieldindex)
        Dim nvartolower As String = nvar.ToLower
        Dim pnvar As String = String.Empty
        Dim pdatatype As String = String.Empty

        pnvar = hfield.name
        If pnvar <> conrex.NULL AndAlso pnvar.ToLower = nvartolower Then
            pdatatype = hfield.ptype
            servinterface.is_common_data_type(pdatatype, pdatatype)
            If eq_data_types(pdatatype, datatype) Then
                convtc.reset_convtc()
                Dim classname As String = hresult.exclass
                If IsNothing(nactorcode) = False Then
                    If hfield.objcontrol.modifier = tokenhared.token.STATIC Then
                        cil.load_static_field(nactorcode, pnvar, pdatatype, classname)
                    Else
                        cil.load_field(nactorcode, pnvar, pdatatype, classname)
                    End If
                Else
                    If hfield.objcontrol.modifier = tokenhared.token.STATIC Then
                        cil.load_static_field(_ilmethod.codes, pnvar, pdatatype, classname)
                    Else
                        cil.load_field(_ilmethod.codes, pnvar, pdatatype, classname)
                    End If
                End If
                Return True
            Else
                dserr.args.Add(hfield.ptype)
                dserr.args.Add(datatype)
                dserr.new_error(conserr.errortype.EXPLICITCONVERSION, cargcodestruc.line, ilbodybulider.path, "Method : " & _ilmethod.name & " - identifier [ Field ] : " & nvar & vbCrLf)
                Return False
            End If
            Return True
        End If
        Return False
    End Function

    Friend Shared Sub check_identifier_modifiers(cargcodestruc As xmlunpkd.linecodestruc, nvar As String, objcontrol As fmtshared.objectcontrol, _ilmethod As ilformat._ilmethodcollection, ptype As String)
        If iltranscore.methodobjectcontrol.modifier = tokenhared.token.STATIC AndAlso objcontrol.modifier = tokenhared.token.UNDEFINED Then
            dserr.new_error(conserr.errortype.MODIFIERERROR, cargcodestruc.line, ilbodybulider.path, "Method : " & _ilmethod.name & " - identifier : " & nvar & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value), String.Format("public static {0} : {1} ", nvar, ptype))
        End If
    End Sub

    Friend Shared Function ld_field(nvar As String, ByRef _ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, datatype As String, Optional ByRef nactorcode As ArrayList = Nothing) As Boolean
        If IsNothing(ilasmgen.fields) Then Return False
        Dim nvartolower As String = nvar.ToLower
        Dim pnvar As String = String.Empty
        Dim pdatatype As String = String.Empty
        For index = 0 To ilasmgen.fields.Length - 1
            pnvar = ilasmgen.fields(index).name
            If pnvar <> conrex.NULL AndAlso pnvar.ToLower = nvartolower Then
                pdatatype = ilasmgen.fields(index).ptype
                servinterface.is_common_data_type(pdatatype, pdatatype)
                check_identifier_modifiers(cargcodestruc, nvar, ilasmgen.classdata.fields(index).objcontrol, _ilmethod, ilasmgen.fields(index).ptype)
                If eq_data_types(pdatatype, datatype) Then
                    convtc.reset_convtc()
                    Dim classname As String = ilasmgen.classdata.attribute._app._classname
                    If ilasmgen.classdata.fields(index).objcontrol.modifier = tokenhared.token.UNDEFINED Then 'INSTANCE
                        cil.insert_il(_ilmethod.codes, compdt.LOAD_FIRST_ARGUMENT)
                    End If
                    If IsNothing(nactorcode) = False Then
                        If ilasmgen.classdata.fields(index).objcontrol.modifier = tokenhared.token.STATIC Then
                            If ldindx Then
                                cil.ldsflda(_ilmethod.codes, pnvar)
                            Else
                                cil.load_static_field(nactorcode, ilasmgen.fields(index), pnvar, pdatatype, classname)
                            End If
                        Else
                            If ldindx Then
                                cil.ldflda(_ilmethod.codes, pnvar)
                            Else
                                cil.load_field(nactorcode, ilasmgen.fields(index), pnvar, pdatatype, classname)
                            End If
                        End If
                    Else
                        If ilasmgen.classdata.fields(index).objcontrol.modifier = tokenhared.token.STATIC Then
                            If ldindx Then
                                cil.ldsflda(_ilmethod.codes, pnvar)
                            Else
                                cil.load_static_field(_ilmethod.codes, ilasmgen.fields(index), pnvar, pdatatype, classname)
                            End If
                        Else
                            If ldindx Then
                                cil.ldflda(_ilmethod.codes, pnvar)
                            Else
                                cil.load_field(_ilmethod.codes, ilasmgen.fields(index), pnvar, pdatatype, classname)
                            End If
                        End If
                    End If
                    Return True
                ElseIf convtc.setconvmethod Then
                    Dim classname As String = ilasmgen.classdata.attribute._app._classname
                    If IsNothing(nactorcode) = False Then
                        If ilasmgen.classdata.fields(index).objcontrol.modifier = tokenhared.token.STATIC Then
                            If ldindx Then
                                cil.ldsflda(_ilmethod.codes, pnvar)
                            Else
                                cil.load_static_field(nactorcode, ilasmgen.fields(index), pnvar, pdatatype, classname)
                            End If
                        Else
                            If ldindx Then
                                cil.ldflda(_ilmethod.codes, pnvar)
                            Else
                                cil.load_field(nactorcode, ilasmgen.fields(index), pnvar, pdatatype, classname)
                            End If
                        End If
                    Else
                        If ilasmgen.classdata.fields(index).objcontrol.modifier = tokenhared.token.STATIC Then
                            If ldindx Then
                                cil.ldsflda(_ilmethod.codes, pnvar)
                            Else
                                cil.load_static_field(_ilmethod.codes, ilasmgen.fields(index), pnvar, pdatatype, classname)
                            End If
                        Else
                            If ldindx Then
                                cil.ldflda(_ilmethod.codes, pnvar)
                            Else
                                cil.load_field(_ilmethod.codes, ilasmgen.fields(index), pnvar, pdatatype, classname)
                            End If
                        End If
                    End If
                    convtc.set_type_cast(_ilmethod, ilasmgen.fields(index).ptype, datatype, nvar, cargcodestruc)
                    Return True
                Else
                    dserr.args.Add(ilasmgen.fields(index).ptype)
                    dserr.args.Add(datatype)
                    dserr.new_error(conserr.errortype.EXPLICITCONVERSION, cargcodestruc.line, ilbodybulider.path, "Method : " & _ilmethod.name & " - identifier [ Field ] : " & nvar & vbCrLf)
                    Return False
                End If
            End If
        Next
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
                If eq_data_types(_ilmethod.locallinit(index).datatype, datatype, _ilmethod.locallinit(index).typeinf) Then
                    convtc.reset_convtc()
                    If ldptr Then
                        cil.load_local_address(_ilmethod.codes, pnvar)
                        Return True
                    ElseIf ldindx Then
                        cil.ldloca(_ilmethod.codes, pnvar)
                        Return True
                    Else
                        cil.load_local_variable(_ilmethod.codes, pnvar)
                        Return True
                    End If
                ElseIf convtc.setconvmethod Then
                    If ldptr Then
                        cil.load_local_address(_ilmethod.codes, pnvar)
                    ElseIf ldindx Then
                        cil.ldloca(_ilmethod.codes, pnvar)
                    Else
                        cil.load_local_variable(_ilmethod.codes, pnvar)
                    End If
                    convtc.set_type_cast(_ilmethod, _ilmethod.locallinit(index).datatype, datatype, pnvar, cargcodestruc)
                    Return True
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
                If eq_data_types(datatype, getcildatatype, _ilmethod.parameter(index).typeinf) Then
                    convtc.reset_convtc()
                    If ldindx Then
                        cil.ldarga(_ilmethod.codes, nvar)
                        Return True
                    ElseIf ldptr Then
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
                ElseIf convtc.setconvmethod Then
                    If ldindx Then
                        cil.ldarga(_ilmethod.codes, nvar)
                    ElseIf ldptr Then
                        cil.load_local_address(_ilmethod.codes, nvar)
                    ElseIf _ilmethod.parameter(index).ispointer Then
                        cil.load_argument(_ilmethod.codes, nvar)
                        cil.load_pointer(_ilmethod.codes, datatype)
                    Else
                        cil.load_argument(_ilmethod.codes, nvar)
                    End If
                    convtc.set_type_cast(_ilmethod, _ilmethod.parameter(index).datatype, datatype, nvar, cargcodestruc)
                    Return True
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

    Friend Shared Function eq_data_types(maintype As String, resulttype As String, Optional typeinf As ilformat._typeinfo = Nothing) As Boolean
        If IsNothing(typeinf) = False AndAlso typeinf.isarray AndAlso resulttype.EndsWith(conrex.BRSTEN) AndAlso maintype.EndsWith(conrex.BRSTEN) = False Then
            maintype &= conrex.BRSTEN
        End If
        If maintype = conrex.NULL OrElse resulttype = conrex.NULL Then
            If maintype = resulttype Then
                Return True
            End If
            If maintype = conrex.NULL AndAlso resulttype.ToLower = conrex.VOID Then
                Return True
            ElseIf resulttype = conrex.NULL AndAlso maintype.ToLower = conrex.VOID Then

            End If
        Else
            maintype = maintype.ToLower
            resulttype = resulttype.ToLower
        End If
        If maintype = resulttype Then
            Return True
        End If

        If resulttype.StartsWith("system.") Then
            Dim mptype As String = resulttype.Remove(0, resulttype.IndexOf(conrex.DOT) + 1)
            If maintype = mptype Then Return True
        ElseIf maintype.StartsWith("system.") Then
            Dim mptype As String = maintype.Remove(0, maintype.IndexOf(conrex.DOT) + 1)
            If resulttype = mptype Then Return True
        ElseIf (maintype = conrex.OBJECT OrElse maintype = conrex.STRING) AndAlso (resulttype = conrex.OBJECT OrElse resulttype = conrex.STRING) Then
            Return True
        ElseIf typeinf.isenum = True AndAlso (maintype = "int32" OrElse resulttype = "int32") Then
            Return True
        End If

        'Ignore check collection types.
        If resulttype.EndsWith(conrex.BRSTEN) OrElse maintype.EndsWith(conrex.BRSTEN) Then
            If resulttype.EndsWith(conrex.BRSTEN) Then resulttype = resulttype.Remove(resulttype.IndexOf(conrex.BRSTART))
            If maintype.EndsWith(conrex.BRSTEN) Then maintype = maintype.Remove(maintype.IndexOf(conrex.BRSTART))
            If maintype.ToLower = resulttype.ToLower Then Return True
        End If
        Return False
    End Function

    Private Sub ldstr(cargcodestruc As xmlunpkd.linecodestruc)
        Select Case cargcodestruc.tokenid
            Case tokenhared.token.TYPE_DU_STR
                cil.load_string(_ilmethod, cargcodestruc.value, cargcodestruc)
            Case tokenhared.token.TYPE_CO_STR
                cil.load_string(_ilmethod, cargcodestruc.value, cargcodestruc)
            Case tokenhared.token.IDENTIFIER
                ld_identifier(cargcodestruc.value, _ilmethod, cargcodestruc, Nothing, conrex.STRING)
            Case tokenhared.token.ARR
                var.load_arr_identifier(_ilmethod, cargcodestruc, Nothing, conrex.STRING)
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)
            Case Else
                'Set Error 
                dserr.args.Add(cargcodestruc.value)
                dserr.args.Add(conrex.STRING)
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
            Case tokenhared.token.ARR
                var.load_arr_identifier(_ilmethod, cargcodestruc, Nothing, datatype)
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
            Case tokenhared.token.ARR
                var.load_arr_identifier(_ilmethod, cargcodestruc, Nothing, datatype)
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
            Case tokenhared.token.ARR
                var.load_arr_identifier(_ilmethod, cargcodestruc, Nothing, datatype)
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
                ld_identifier(cargcodestruc.value, _ilmethod, cargcodestruc, Nothing, datatype)
            Case tokenhared.token.ARR
                var.load_arr_identifier(_ilmethod, cargcodestruc, Nothing, datatype)
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
