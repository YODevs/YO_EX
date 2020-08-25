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
        Select Case clinecodestruc.tokenid
            Case tokenhared.token.TYPE_INT
                cil.push_int32_onto_stack(_ilmethod.codes, clinecodestruc.value)
            Case tokenhared.token.TYPE_FLOAT
                cil.push_int32_onto_stack(_ilmethod.codes, CInt(clinecodestruc.value))
            Case tokenhared.token.IDENTIFIER
                If assignmentcommondatatype.check_locals_init(_ilmethod.name, clinecodestruc.value, _ilmethod.locallinit, datatype) Then
                    cil.load_local_variable(_ilmethod.codes, clinecodestruc.value)
                End If
            'let value : str = NULL
            Case tokenhared.token.NULL
                cil.push_null_reference(_ilmethod.codes)

            Case Else
                'Set Error 
        End Select

        If datatype = "int64" OrElse datatype = "valuetype [mscorlib]System.Decimal" Then
            cil.conv_to_int64(_ilmethod.codes)
        End If
        cil.set_stack_local(_ilmethod.codes, varname)

        Return _ilmethod
    End Function
End Class
