Public Class parampt

    Friend Shared Function check_param_types(_ilmethod As ilformat._ilmethodcollection, paramtypes As ArrayList, params As tknformat._parameter(), cargcodestruc As xmlunpkd.linecodestruc(), Optional paramfullname As ArrayList = Nothing) As Boolean
        Dim getdatatype As String = conrex.NULL
        For index = 0 To cargcodestruc.Length - 1
            getdatatype = paramtypes(index).ToString()
            If getdatatype.EndsWith("&") Then
                getdatatype = getdatatype.Remove(getdatatype.Length - 1)
            End If

            Select Case getdatatype
                Case conrex.STRING
                    If chstr(_ilmethod, cargcodestruc(index)) = False Then Return False
                Case illdloc.check_integer_type(getdatatype)
                    If chint(_ilmethod, cargcodestruc(index), getdatatype) = False Then Return False
                Case "float32"
                    If chflt(_ilmethod, cargcodestruc(index), getdatatype) = False Then Return False
                Case "float64"
                    If chflt(_ilmethod, cargcodestruc(index), getdatatype) = False Then Return False
                Case "char"
                    If chchr(_ilmethod, cargcodestruc(index), getdatatype) = False Then Return False
                Case "bool"
                    If chbool(_ilmethod, cargcodestruc(index), getdatatype) = False Then Return False
                Case "object"
                    If chobj(_ilmethod, cargcodestruc(index)) = False Then Return False
                Case Else
                    'Other Types
                    Dim crdatatype As String = String.Empty
                    If servinterface.is_variable(_ilmethod, cargcodestruc(index).value, crdatatype) Then
                        Dim tpinf As ilformat._typeinfo = servinterface.get_variable_type(_ilmethod, cargcodestruc(index).value)
                        If tpinf.asminfo = params(index).typeinf.asminfo Then
                            Continue For
                        ElseIf tpinf.isarray AndAlso tpinf.fullname & conrex.BRSTEN = getdatatype Then
                            Continue For
                        End If
                    ElseIf cargcodestruc(index).tokenid = tokenhared.token.ARR Then
                        Dim cargtype As String = cargcodestruc(index).value.Remove(cargcodestruc(index).value.IndexOf(conrex.BRSTART))
                        If servinterface.is_variable(_ilmethod, cargtype, crdatatype) Then
                            Dim tpinf As ilformat._typeinfo = servinterface.get_variable_type(_ilmethod, cargtype)
                            If tpinf.asminfo = params(index).typeinf.asminfo Then
                                Continue For
                            End If
                        End If
                    ElseIf servinterface.is_variable(_ilmethod, cargcodestruc(index).value, crdatatype) AndAlso getdatatype.ToLower = crdatatype.ToLower Then
                        Continue For
                    ElseIf IsNothing(paramfullname) = False AndAlso paramfullname(index).ToString.ToLower = crdatatype.ToLower Then
                        Continue For
                    End If
                    Dim idenresult As identvalid._resultidentcvaild = identvalid.get_identifier_valid(_ilmethod, cargcodestruc(index))
                    If idenresult.identvalid Then Continue For
                    Return False
            End Select
        Next

        Return True
    End Function

    Friend Shared Function check_param_types(_ilmethod As ilformat._ilmethodcollection, gparameters() As Reflection.ParameterInfo, cargcodestruc As xmlunpkd.linecodestruc()) As Boolean
        Dim getdatatype As String = conrex.NULL
        For index = 0 To cargcodestruc.Length - 1
            getdatatype = servinterface.vb_to_cil_common_data_type(gparameters(index).ParameterType.Name)
            If getdatatype.EndsWith("&") Then
                getdatatype = getdatatype.Remove(getdatatype.Length - 1)
            End If

            Select Case getdatatype
                Case conrex.STRING
                    If chstr(_ilmethod, cargcodestruc(index)) = False Then Return False
                Case illdloc.check_integer_type(getdatatype)
                    If chint(_ilmethod, cargcodestruc(index), getdatatype) = False Then Return False
                Case "float32"
                    If chflt(_ilmethod, cargcodestruc(index), getdatatype) = False Then Return False
                Case "single"
                    getdatatype = "float32"
                    If chflt(_ilmethod, cargcodestruc(index), getdatatype) = False Then Return False
                Case "float64"
                    If chflt(_ilmethod, cargcodestruc(index), getdatatype) = False Then Return False
                Case "char"
                    If chchr(_ilmethod, cargcodestruc(index), getdatatype) = False Then Return False
                Case "bool"
                    If chbool(_ilmethod, cargcodestruc(index), getdatatype) = False Then Return False
                Case "object"
                    If chobj(_ilmethod, cargcodestruc(index)) = False Then Return False
                Case Else
                    'Other Types
                    If cargcodestruc(index).tokenid = tokenhared.token.IDENTIFIER Then
                        Dim crdatatype As String = String.Empty
                        If servinterface.is_variable(_ilmethod, cargcodestruc(index).value, crdatatype) Then
                            Dim tpinf As ilformat._typeinfo = servinterface.get_variable_type(_ilmethod, cargcodestruc(index).value)
                            If tpinf.asminfo = gparameters(index).ParameterType.AssemblyQualifiedName Then
                                Continue For
                            ElseIf tpinf.isarray AndAlso tpinf.fullname & conrex.BRSTEN = gparameters(index).ParameterType.FullName Then
                                Continue For
                            End If
                        Else
                            Dim idenresult As identvalid._resultidentcvaild = identvalid.get_identifier_valid(_ilmethod, cargcodestruc(index))
                            If idenresult.identvalid Then Continue For
                        End If
                    ElseIf cargcodestruc(index).tokenid = tokenhared.token.ARR Then
                        Dim crdatatype As String = String.Empty
                        Dim cargtype As String = cargcodestruc(index).value.Remove(cargcodestruc(index).value.IndexOf(conrex.BRSTART))
                        If servinterface.is_variable(_ilmethod, cargtype, crdatatype) Then
                            Dim tpinf As ilformat._typeinfo = servinterface.get_variable_type(_ilmethod, cargtype)
                            If tpinf.asminfo = gparameters(index).ParameterType.AssemblyQualifiedName Then
                                Continue For
                            End If
                        End If
                    End If

                    Return False
            End Select
        Next

        Return True
    End Function
    Friend Shared Function chstr(_ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc) As Boolean
        Select Case cargcodestruc.tokenid
            Case tokenhared.token.TYPE_DU_STR
                Return True
            Case tokenhared.token.TYPE_CO_STR
                Return True
            Case tokenhared.token.IDENTIFIER
                Dim getdatatype As String = String.Empty
                If servinterface.is_variable(_ilmethod, cargcodestruc.value, getdatatype) AndAlso getdatatype = conrex.STRING Then
                    Return True
                End If
                Return False
            Case tokenhared.token.ARR
                Dim getdatatype As String = String.Empty
                Dim cargtype As String = cargcodestruc.value.Remove(cargcodestruc.value.IndexOf(conrex.BRSTART))
                servinterface.is_variable(_ilmethod, cargtype, getdatatype)
                If getdatatype.EndsWith(conrex.BRSTEN) Then
                    getdatatype = getdatatype.Remove(getdatatype.Length - 2)
                End If
                If getdatatype = "string" Then
                    Return True
                End If
                Return False
            Case tokenhared.token.NULL
                Return True
            Case Else
                Return False
        End Select
    End Function

    Friend Shared Function chobj(_ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc) As Boolean
        Select Case cargcodestruc.tokenid
            Case tokenhared.token.IDENTIFIER
                Dim getdatatype As String = String.Empty
                If servinterface.is_variable(_ilmethod, cargcodestruc.value, getdatatype) AndAlso getdatatype = conrex.OBJECT Then
                    Return True
                End If
                Return False
            Case tokenhared.token.ARR
                Dim getdatatype As String = String.Empty
                Dim cargtype As String = cargcodestruc.value.Remove(cargcodestruc.value.IndexOf(conrex.BRSTART))
                servinterface.is_variable(_ilmethod, cargtype, getdatatype)
                If getdatatype.EndsWith(conrex.BRSTEN) Then
                    getdatatype = getdatatype.Remove(getdatatype.Length - 2)
                End If
                If getdatatype = conrex.OBJECT Then
                    Return True
                End If
                Return False
            Case tokenhared.token.NULL
                Return True
            Case Else
                Return False
        End Select
    End Function
    Friend Shared Function chint(_ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, datatype As String) As Boolean
        Dim convtoi8 As Boolean = servinterface.is_i8(datatype)
        servinterface.clinecodestruc = cargcodestruc
        Select Case cargcodestruc.tokenid
            Case tokenhared.token.TYPE_INT
                Return True
            Case tokenhared.token.IDENTIFIER
                Dim getdatatype As String = String.Empty
                If servinterface.is_variable(_ilmethod, cargcodestruc.value, getdatatype) AndAlso getdatatype = datatype Then
                    Return True
                End If
                Return False
            Case tokenhared.token.ARR
                Dim getdatatype As String = String.Empty
                Dim cargtype As String = cargcodestruc.value.Remove(cargcodestruc.value.IndexOf(conrex.BRSTART))
                servinterface.is_variable(_ilmethod, cargtype, getdatatype)
                If getdatatype.EndsWith(conrex.BRSTEN) Then
                    getdatatype = getdatatype.Remove(getdatatype.Length - 2)
                End If
                If getdatatype = datatype Then
                    Return True
                End If
                Return False
            Case tokenhared.token.NULL
                Return True
            Case tokenhared.token.EXPRESSION
                Return True
            Case Else
                Return False
        End Select
    End Function

    Friend Shared Function chflt(_ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, datatype As String) As Boolean
        Dim convtor8 As Boolean = False
        If datatype = "float64" Then convtor8 = True
        Select Case cargcodestruc.tokenid
            Case tokenhared.token.TYPE_FLOAT
                Return True
            Case tokenhared.token.IDENTIFIER
                Dim getdatatype As String = String.Empty
                If servinterface.is_variable(_ilmethod, cargcodestruc.value, getdatatype) AndAlso getdatatype = datatype Then
                    Return True
                End If
                Return False
            Case tokenhared.token.ARR
                Dim getdatatype As String = String.Empty
                Dim cargtype As String = cargcodestruc.value.Remove(cargcodestruc.value.IndexOf(conrex.BRSTART))
                servinterface.is_variable(_ilmethod, cargtype, getdatatype)
                If getdatatype.EndsWith(conrex.BRSTEN) Then
                    getdatatype = getdatatype.Remove(getdatatype.Length - 2)
                End If
                If getdatatype = datatype Then
                    Return True
                End If
                Return False
            Case tokenhared.token.NULL
                Return True
            Case tokenhared.token.EXPRESSION
                Return True
            Case Else
                Return False
        End Select
    End Function

    Friend Shared Function chchr(_ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, datatype As String) As Boolean
        Dim convtoi8 As Boolean = servinterface.is_i8(datatype)
        servinterface.clinecodestruc = cargcodestruc
        Select Case cargcodestruc.tokenid
            Case tokenhared.token.TYPE_DU_STR
                If cargcodestruc.value.Length = 3 Then
                    Return True
                Else
                    Return False
                End If
            Case tokenhared.token.TYPE_CO_STR
                If cargcodestruc.value.Length = 3 Then
                    Return True
                Else
                    Return False
                End If
            Case tokenhared.token.IDENTIFIER
                Dim getdatatype As String = String.Empty
                If servinterface.is_variable(_ilmethod, cargcodestruc.value, getdatatype) AndAlso getdatatype = datatype Then
                    Return True
                End If
                Return False
            Case tokenhared.token.ARR
                Dim getdatatype As String = String.Empty
                Dim cargtype As String = cargcodestruc.value.Remove(cargcodestruc.value.IndexOf(conrex.BRSTART))
                servinterface.is_variable(_ilmethod, cargtype, getdatatype)
                If getdatatype.EndsWith(conrex.BRSTEN) Then
                    getdatatype = getdatatype.Remove(getdatatype.Length - 2)
                End If
                If getdatatype = datatype Then
                    Return True
                End If
                Return False
            Case tokenhared.token.NULL
                Return True
            Case Else
                Return False
        End Select
    End Function

    Friend Shared Function chbool(_ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, datatype As String) As Boolean
        Dim convtoi8 As Boolean = servinterface.is_i8(datatype)
        servinterface.clinecodestruc = cargcodestruc
        Select Case cargcodestruc.tokenid
            Case tokenhared.token.TRUE
                Return True
            Case tokenhared.token.FALSE
                Return True
            Case tokenhared.token.IDENTIFIER
                Dim getdatatype As String = String.Empty
                If servinterface.is_variable(_ilmethod, cargcodestruc.value, getdatatype) AndAlso getdatatype = datatype Then
                    Return True
                End If
                Return False
            Case tokenhared.token.ARR
                Dim getdatatype As String = String.Empty
                Dim cargtype As String = cargcodestruc.value.Remove(cargcodestruc.value.IndexOf(conrex.BRSTART))
                servinterface.is_variable(_ilmethod, cargtype, getdatatype)
                If getdatatype.EndsWith(conrex.BRSTEN) Then
                    getdatatype = getdatatype.Remove(getdatatype.Length - 2)
                End If
                If getdatatype = datatype Then
                    Return True
                End If
                Return False
            Case tokenhared.token.NULL
                Return True
            Case Else
                Return False
        End Select

    End Function
End Class
