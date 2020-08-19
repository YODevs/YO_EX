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
            End Select

        End If
    End Sub
End Class
