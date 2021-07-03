Public Class parampt

    Friend Shared Function check_param_types(_ilmethod As ilformat._ilmethodcollection, paramtypes As ArrayList, cargcodestruc As xmlunpkd.linecodestruc(), Optional paramfullname As ArrayList = Nothing) As Boolean
        Dim getdatatype As String = conrex.NULL
        For index = 0 To cargcodestruc.Length - 1
            getdatatype = paramtypes(index).ToString()
            If getdatatype.EndsWith("&") Then
                getdatatype = getdatatype.Remove(getdatatype.Length - 1)
            End If

            Select Case getdatatype
                Case "string"
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
                Case Else
                    'Other Types
                    Dim crdatatype As String = String.Empty
                    If servinterface.is_variable(_ilmethod, cargcodestruc(0).value, crdatatype) AndAlso getdatatype.ToLower = crdatatype.ToLower Then
                        Return True
                    ElseIf IsNothing(paramfullname) = False AndAlso paramfullname(index).ToString.ToLower = crdatatype.ToLower Then
                        Return True
                    End If
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
                Case "string"
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
                Case Else
                    'Other Types
                    Dim crdatatype As String = String.Empty
                    If servinterface.is_variable(_ilmethod, cargcodestruc(index).value, crdatatype) Then
                        Dim tpinf As ilformat._typeinfo = servinterface.get_variable_type(_ilmethod, cargcodestruc(index).value)
                        If tpinf.asminfo = gparameters(index).ParameterType.AssemblyQualifiedName Then
                            Continue For
                        End If
                    Else
                        Dim idenresult As identvalid._resultidentcvaild = identvalid.get_identifier_valid(_ilmethod, cargcodestruc(index))
                        If idenresult.identvalid Then Continue For
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
                If servinterface.is_variable(_ilmethod, cargcodestruc.value, getdatatype) AndAlso getdatatype = "string" Then
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
            Case tokenhared.token.NULL
                Return True
            Case Else
                Return False
        End Select

    End Function
End Class
