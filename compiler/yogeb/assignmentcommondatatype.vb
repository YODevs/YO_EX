Public Class assignmentcommondatatype

    Friend Shared Sub set_value(ByRef funcdt As ilformat._ilmethodcollection, index As Integer)
        Dim datatype As String = funcdt.locallinit(index).datatype
        Select Case initcommondatatype.cdtype.findkey(datatype).result
            Case "str"
                set_str_data(funcdt, index)
        End Select
    End Sub

    Friend Shared Sub set_str_data(ByRef funcdt As ilformat._ilmethodcollection, index As Integer)
        If funcdt.locallinit(index).clocalvalue.Length = 1 Then
            Select Case funcdt.locallinit(index).clocalvalue(0).tokenid

                Case tokenhared.token.IDENTIFIER
                    Dim getclocalname As String = funcdt.locallinit(index).clocalvalue(0).value
                    If check_locals_init(funcdt.name, getclocalname, funcdt.locallinit) Then
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

    Friend Shared Function check_locals_init(methodname As String, nvar As String, varlocallist() As ilformat._illocalinit) As Boolean
        'TODO : Check Global Identifiers.
        'TODO : Check Equal Types.

        For index = 0 To varlocallist.Length - 1
            If varlocallist(index).name = nvar Then
                Return True
            End If
        Next

        dserr.args.Add(nvar)
        dserr.new_error(conserr.errortype.TYPENOTFOUND, -1, ilbodybulider.path, "Method : " & methodname & " - Unknown identifier : " & nvar)
        Return False
    End Function
End Class
