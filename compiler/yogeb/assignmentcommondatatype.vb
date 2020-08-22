Public Class assignmentcommondatatype

    Friend Shared Sub set_value(ByRef funcdt As ilformat._ilmethodcollection, index As Integer)
        Dim datatype As String = funcdt.locallinit(index).datatype
        Select Case initcommondatatype.cdtype.findkey(datatype).result
            Case "str"
                set_str_data(funcdt, index)
            Case "bool"
                set_bool_data(funcdt, index)
            Case "char"
                set_char_data(funcdt, index)
        End Select
    End Sub

    Friend Shared Sub set_str_data(ByRef funcdt As ilformat._ilmethodcollection, index As Integer)
        If funcdt.locallinit(index).clocalvalue.Length = 1 Then
            Select Case funcdt.locallinit(index).clocalvalue(0).tokenid

                Case tokenhared.token.IDENTIFIER
                    Dim getclocalname As String = funcdt.locallinit(index).clocalvalue(0).value
                    If check_locals_init(funcdt.name, getclocalname, funcdt.locallinit, funcdt.locallinit(index).datatype) Then
                        cil.load_local_variable(funcdt.codes, getclocalname)
                        cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)
                    End If

                    'let name : str = 'Amin'
                Case tokenhared.token.TYPE_CO_STR
                    cil.load_string(funcdt.codes, funcdt.locallinit(index).clocalvalue(0).value)
                    cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)

                    'let message :str = "Hello.#nlWelcome to my app."
                Case tokenhared.token.TYPE_DU_STR
                    cil.load_string(funcdt.codes, funcdt.locallinit(index).clocalvalue(0).value)
                    cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)

                    'let value : str = NULL
                Case tokenhared.token.NULL
                    cil.push_null_reference(funcdt.codes)
                    cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)

                    'let val : str = 36000
                Case tokenhared.token.TYPE_INT
                    cil.load_string(funcdt.codes, funcdt.locallinit(index).clocalvalue(0).value)
                    cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)

                    'let pi : str = 3.14
                Case tokenhared.token.TYPE_FLOAT
                    cil.load_string(funcdt.codes, funcdt.locallinit(index).clocalvalue(0).value)
                    cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)

                Case tokenhared.token.TRUE
                    cil.load_string(funcdt.codes, "True")
                    cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)

                Case tokenhared.token.FALSE
                    cil.load_string(funcdt.codes, "False")
                    cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)
                Case Else
                    'Set dserr
            End Select

        End If
    End Sub

    Friend Shared Sub set_bool_data(ByRef funcdt As ilformat._ilmethodcollection, index As Integer)
        If funcdt.locallinit(index).clocalvalue.Length = 1 Then
            Select Case funcdt.locallinit(index).clocalvalue(0).tokenid


                Case tokenhared.token.TRUE
                    cil.push_int32_onto_stack(funcdt.codes, 1)
                    cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)

                Case tokenhared.token.FALSE
                    cil.push_int32_onto_stack(funcdt.codes, 0)
                    cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)

                Case tokenhared.token.IDENTIFIER
                    Dim getclocalname As String = funcdt.locallinit(index).clocalvalue(0).value
                    If check_locals_init(funcdt.name, getclocalname, funcdt.locallinit, funcdt.locallinit(index).datatype) Then
                        cil.load_local_variable(funcdt.codes, getclocalname)
                        cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)
                    End If

                    'let value : bool = NULL
                Case tokenhared.token.NULL
                    cil.push_null_reference(funcdt.codes)
                    cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)

                    'let val : bool = 1
                Case tokenhared.token.TYPE_INT
                    Dim boolboxinteger As Integer = funcdt.locallinit(index).clocalvalue(0).value
                    If boolboxinteger = 1 Or boolboxinteger = 0 Then
                        cil.push_int32_onto_stack(funcdt.codes, boolboxinteger)
                        cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)
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

    Friend Shared Sub set_char_data(ByRef funcdt As ilformat._ilmethodcollection, index As Integer)
        If funcdt.locallinit(index).clocalvalue.Length = 1 Then
            Select Case funcdt.locallinit(index).clocalvalue(0).tokenid

                Case tokenhared.token.TYPE_DU_STR
                    If funcdt.locallinit(index).clocalvalue(0).value.Length >= 3 Then
                        cil.push_int32_onto_stack(funcdt.codes, Asc(funcdt.locallinit(index).clocalvalue(0).value(1)))
                        cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)
                    Else
                        cil.push_null_reference(funcdt.codes)
                        cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)
                    End If
                Case tokenhared.token.TYPE_CO_STR
                    If funcdt.locallinit(index).clocalvalue(0).value.Length >= 3 Then
                        cil.push_int32_onto_stack(funcdt.codes, Asc(funcdt.locallinit(index).clocalvalue(0).value(1)))
                        cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)
                    Else
                        cil.push_null_reference(funcdt.codes)
                        cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)
                    End If
                Case tokenhared.token.IDENTIFIER
                    Dim getclocalname As String = funcdt.locallinit(index).clocalvalue(0).value
                    If check_locals_init(funcdt.name, getclocalname, funcdt.locallinit, funcdt.locallinit(index).datatype) Then
                        cil.load_local_variable(funcdt.codes, getclocalname)
                        cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)
                    End If

                    'let value : char = NULL
                Case tokenhared.token.NULL
                    cil.push_null_reference(funcdt.codes)
                    cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)

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
End Class
