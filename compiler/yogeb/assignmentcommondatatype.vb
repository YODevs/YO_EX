Public Class assignmentcommondatatype

    Friend Shared Sub set_value(ByRef funcdt As ilformat._ilmethodcollection, index As Integer, Optional loadatfirst As Boolean = True)
        Static indinsert As Integer = 0
        Dim indenditem As Integer = 0
        Dim prcodes As New ArrayList
        Dim datatype As String = funcdt.locallinit(index).datatype
        Dim optgen As New ilopt(funcdt)

        Select Case initcommondatatype.cdtype.findkey(datatype).result
            Case "str"
                set_str_data(funcdt, index, prcodes)
            Case "bool"
                set_bool_data(funcdt, index, prcodes)
            Case "char"
                set_char_data(funcdt, index, prcodes)
            Case "i32"
                set_i32_data(funcdt, index, prcodes)
            Case "i16"
                indenditem = funcdt.codes.Count - 1
                funcdt = optgen.assi_int(funcdt.locallinit(index).name, funcdt.locallinit(index).clocalvalue(0), "int16")
            Case "i8"
                indenditem = funcdt.codes.Count - 1
                funcdt = optgen.assi_int(funcdt.locallinit(index).name, funcdt.locallinit(index).clocalvalue(0), "int8")
            Case "f32"
                indenditem = funcdt.codes.Count - 1
                funcdt = optgen.assi_float(funcdt.locallinit(index).name, funcdt.locallinit(index).clocalvalue(0), "float32")
            Case "f64"
                indenditem = funcdt.codes.Count - 1
                funcdt = optgen.assi_float(funcdt.locallinit(index).name, funcdt.locallinit(index).clocalvalue(0), "float64")
            Case "u32"
                indenditem = funcdt.codes.Count - 1
                funcdt = optgen.assi_int(funcdt.locallinit(index).name, funcdt.locallinit(index).clocalvalue(0), "uint32")
            Case "u16"
                indenditem = funcdt.codes.Count - 1
                funcdt = optgen.assi_int(funcdt.locallinit(index).name, funcdt.locallinit(index).clocalvalue(0), "uint16")
            Case "u8"
                indenditem = funcdt.codes.Count - 1
                funcdt = optgen.assi_int(funcdt.locallinit(index).name, funcdt.locallinit(index).clocalvalue(0), "uint8")
        End Select

        If loadatfirst Then

            If index = 0 Then
                indinsert = 0
            End If
            If prcodes.Count > 0 Then
                For indloop = 0 To prcodes.Count - 1
                    funcdt.codes.Insert(indinsert, prcodes(indloop))
                    indinsert += 1
                Next
            ElseIf indenditem <> 0 Then
                Dim indprcodesinsert As Integer = 0
                For indloop = indenditem + 1 To funcdt.codes.Count - 1
                    prcodes.Insert(indprcodesinsert, funcdt.codes(indloop))
                    indprcodesinsert += 1
                Next

                Dim indremat As Integer = indenditem + 1
                For indloop = indremat To funcdt.codes.Count - 1
                    funcdt.codes.RemoveAt(indremat)
                Next

                For indloop = 0 To prcodes.Count - 1
                    funcdt.codes.Insert(indinsert, prcodes(indloop))
                    indinsert += 1
                Next
            End If
        Else
            For indloop = 0 To prcodes.Count - 1
                funcdt.codes.Add(prcodes(indloop))
            Next
        End If

    End Sub


    Friend Shared Sub set_i32_data(ByRef funcdt As ilformat._ilmethodcollection, index As Integer, ByRef prcodes As ArrayList)
        If funcdt.locallinit(index).clocalvalue.Length = 1 Then
            Select Case funcdt.locallinit(index).clocalvalue(0).tokenid

                Case tokenhared.token.IDENTIFIER
                    Dim getclocalname As String = funcdt.locallinit(index).clocalvalue(0).value
                    If check_locals_init(funcdt.name, getclocalname, funcdt.locallinit, funcdt.locallinit(index).datatype) Then
                        cil.load_local_variable(prcodes, getclocalname)
                        cil.set_stack_local(prcodes, funcdt.locallinit(index).name)
                    End If

                    'let value : i32 = NULL
                Case tokenhared.token.NULL
                    cil.push_null_reference(prcodes)
                    cil.set_stack_local(prcodes, funcdt.locallinit(index).name)

                    'let val : i32 = 36000
                Case tokenhared.token.TYPE_INT
                    If Int32.MaxValue >= funcdt.locallinit(index).clocalvalue(0).value AndAlso Int32.MinValue <= funcdt.locallinit(index).clocalvalue(0).value Then
                        cil.push_int32_onto_stack(prcodes, funcdt.locallinit(index).clocalvalue(0).value)
                        cil.set_stack_local(prcodes, funcdt.locallinit(index).name)
                    Else
                        dserr.args.Add(funcdt.locallinit(index).clocalvalue(0).value)
                        dserr.args.Add(Int32.MaxValue)
                        dserr.args.Add(Int32.MinValue)
                        dserr.new_error(conserr.errortype.CONSTANTNUMOUTOFRANGE, -1, ilbodybulider.path)
                    End If

                    'let pi : i32 = 3.14
                Case tokenhared.token.TYPE_FLOAT
                    If Int32.MaxValue >= funcdt.locallinit(index).clocalvalue(0).value AndAlso Int32.MinValue <= funcdt.locallinit(index).clocalvalue(0).value Then
                        cil.push_int32_onto_stack(prcodes, CInt(funcdt.locallinit(index).clocalvalue(0).value))
                        cil.set_stack_local(prcodes, funcdt.locallinit(index).name)
                    Else
                        dserr.args.Add(funcdt.locallinit(index).clocalvalue(0).value)
                        dserr.args.Add(Int32.MaxValue)
                        dserr.args.Add(Int32.MinValue)
                        dserr.new_error(conserr.errortype.CONSTANTNUMOUTOFRANGE, -1, ilbodybulider.path)
                    End If
                Case Else
                    'Set dserr
            End Select

        End If
    End Sub


    Friend Shared Sub set_str_data(ByRef funcdt As ilformat._ilmethodcollection, index As Integer, ByRef prcodes As ArrayList)
        If funcdt.locallinit(index).clocalvalue.Length = 1 Then
            Select Case funcdt.locallinit(index).clocalvalue(0).tokenid

                Case tokenhared.token.IDENTIFIER
                    Dim getclocalname As String = funcdt.locallinit(index).clocalvalue(0).value
                    If check_locals_init(funcdt.name, getclocalname, funcdt.locallinit, funcdt.locallinit(index).datatype) Then
                        cil.load_local_variable(prcodes, getclocalname)
                        cil.set_stack_local(prcodes, funcdt.locallinit(index).name)
                    End If

                    'let name : str = 'Amin'
                Case tokenhared.token.TYPE_CO_STR
                    cil.load_string(prcodes, funcdt.locallinit(index).clocalvalue(0).value)
                    cil.set_stack_local(prcodes, funcdt.locallinit(index).name)

                    'let message :str = "Hello.#nlWelcome to my app."
                Case tokenhared.token.TYPE_DU_STR
                    cil.load_string(prcodes, funcdt.locallinit(index).clocalvalue(0).value)
                    cil.set_stack_local(prcodes, funcdt.locallinit(index).name)

                    'let value : str = NULL
                Case tokenhared.token.NULL
                    cil.push_null_reference(prcodes)
                    cil.set_stack_local(prcodes, funcdt.locallinit(index).name)

                    'let val : str = 36000
                Case tokenhared.token.TYPE_INT
                    cil.load_string(prcodes, funcdt.locallinit(index).clocalvalue(0).value)
                    cil.set_stack_local(prcodes, funcdt.locallinit(index).name)

                    'let pi : str = 3.14
                Case tokenhared.token.TYPE_FLOAT
                    cil.load_string(prcodes, funcdt.locallinit(index).clocalvalue(0).value)
                    cil.set_stack_local(prcodes, funcdt.locallinit(index).name)

                Case tokenhared.token.TRUE
                    cil.load_string(prcodes, "True")
                    cil.set_stack_local(prcodes, funcdt.locallinit(index).name)

                Case tokenhared.token.FALSE
                    cil.load_string(prcodes, "False")
                    cil.set_stack_local(prcodes, funcdt.locallinit(index).name)
                Case Else
                    'Set dserr
            End Select

        End If
    End Sub

    Friend Shared Sub set_bool_data(ByRef funcdt As ilformat._ilmethodcollection, index As Integer, ByRef prcodes As ArrayList)
        If funcdt.locallinit(index).clocalvalue.Length = 1 Then
            Select Case funcdt.locallinit(index).clocalvalue(0).tokenid


                Case tokenhared.token.TRUE
                    cil.push_int32_onto_stack(prcodes, 1)
                    cil.set_stack_local(prcodes, funcdt.locallinit(index).name)

                Case tokenhared.token.FALSE
                    cil.push_int32_onto_stack(prcodes, 0)
                    cil.set_stack_local(prcodes, funcdt.locallinit(index).name)

                Case tokenhared.token.IDENTIFIER
                    Dim getclocalname As String = funcdt.locallinit(index).clocalvalue(0).value
                    If check_locals_init(funcdt.name, getclocalname, funcdt.locallinit, funcdt.locallinit(index).datatype) Then
                        cil.load_local_variable(prcodes, getclocalname)
                        cil.set_stack_local(prcodes, funcdt.locallinit(index).name)
                    End If

                    'let value : bool = NULL
                Case tokenhared.token.NULL
                    cil.push_null_reference(prcodes)
                    cil.set_stack_local(prcodes, funcdt.locallinit(index).name)

                    'let val : bool = 1
                Case tokenhared.token.TYPE_INT
                    Dim boolboxinteger As Integer = funcdt.locallinit(index).clocalvalue(0).value
                    If boolboxinteger = 1 Or boolboxinteger = 0 Then
                        cil.push_int32_onto_stack(prcodes, boolboxinteger)
                        cil.set_stack_local(prcodes, funcdt.locallinit(index).name)
                    Else
                        dserr.args.Add(funcdt.locallinit(index).clocalvalue(0).value)
                        dserr.args.Add("bool")
                        dserr.new_error(conserr.errortype.ERRORINCONVERT, -1, ilbodybulider.path, "Method : " & funcdt.name & "  - bool var : " & funcdt.locallinit(index).name & " , Must use 0 [False] and 1 [True] in Boolean variables.", "let " & funcdt.locallinit(index).name & " : bool = 1")
                    End If
                Case Else
                    'Set dserr
            End Select

        End If
    End Sub

    Friend Shared Sub set_char_data(ByRef funcdt As ilformat._ilmethodcollection, index As Integer, ByRef prcodes As ArrayList)
        If funcdt.locallinit(index).clocalvalue.Length = 1 Then
            Select Case funcdt.locallinit(index).clocalvalue(0).tokenid

                Case tokenhared.token.TYPE_DU_STR
                    If funcdt.locallinit(index).clocalvalue(0).value.Length >= 3 Then
                        cil.push_int32_onto_stack(prcodes, AscW(funcdt.locallinit(index).clocalvalue(0).value(1)))
                        cil.set_stack_local(prcodes, funcdt.locallinit(index).name)
                    Else
                        cil.push_null_reference(prcodes)
                        cil.set_stack_local(prcodes, funcdt.locallinit(index).name)
                    End If
                Case tokenhared.token.TYPE_CO_STR
                    If funcdt.locallinit(index).clocalvalue(0).value.Length >= 3 Then
                        cil.push_int32_onto_stack(prcodes, AscW(funcdt.locallinit(index).clocalvalue(0).value(1)))
                        cil.set_stack_local(prcodes, funcdt.locallinit(index).name)
                    Else
                        cil.push_null_reference(prcodes)
                        cil.set_stack_local(prcodes, funcdt.locallinit(index).name)
                    End If
                Case tokenhared.token.IDENTIFIER
                    Dim getclocalname As String = funcdt.locallinit(index).clocalvalue(0).value
                    If check_locals_init(funcdt.name, getclocalname, funcdt.locallinit, funcdt.locallinit(index).datatype) Then
                        cil.load_local_variable(prcodes, getclocalname)
                        cil.set_stack_local(prcodes, funcdt.locallinit(index).name)
                    End If

                    'let value : char = NULL
                Case tokenhared.token.NULL
                    cil.push_null_reference(prcodes)
                    cil.set_stack_local(prcodes, funcdt.locallinit(index).name)

                Case Else
                    'Set dserr
            End Select

        End If
    End Sub

    Friend Shared Function check_locals_init(methodname As String, nvar As String, varlocallist() As ilformat._illocalinit, datatype As String) As Boolean
        'TODO : Check Global Identifiers.
        'TODO : Check Equal Types.

        For index = 0 To varlocallist.Length - 1
            If varlocallist(index).name = nvar Then
                If varlocallist(index).datatype = datatype Then
                    Return True
                Else
                    dserr.args.Add(varlocallist(index).datatype)
                    dserr.args.Add(datatype)
                    dserr.new_error(conserr.errortype.EXPLICITCONVERSION, -1, ilbodybulider.path, "Method : " & methodname & " - identifier : " & nvar)
                End If
            End If
        Next

        dserr.args.Add(nvar)
        dserr.new_error(conserr.errortype.TYPENOTFOUND, -1, ilbodybulider.path, "Method : " & methodname & " - Unknown identifier : " & nvar)
        Return False
    End Function

    Friend Shared Function check_locals_create(nvar As String, varlocallist() As ilformat._illocalinit, Optional ByRef getdatatype As String = Nothing) As Boolean
        For index = 0 To varlocallist.Length - 1
            If varlocallist(index).name = nvar Then
                getdatatype = varlocallist(index).datatype
                Return True
            End If
        Next
        Return False
    End Function

End Class
