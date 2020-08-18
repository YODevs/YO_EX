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
            'let name : str = 'Amin'
            If funcdt.locallinit(index).clocalvalue(0).tokenid = tokenhared.token.TYPE_CO_STR Then
                cil.load_string(funcdt.codes, funcdt.locallinit(index).clocalvalue(0).value)
                cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)
                'let message :str = "Hello.#nlWelcome to my app."
            ElseIf funcdt.locallinit(index).clocalvalue(0).tokenid = tokenhared.token.TYPE_DU_STR Then
                cil.load_string(funcdt.codes, funcdt.locallinit(index).clocalvalue(0).value)
                cil.set_stack_local(funcdt.codes, funcdt.locallinit(index).name)
            End If
        End If
    End Sub
End Class
