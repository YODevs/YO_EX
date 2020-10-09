Public Class jmp
    Private path As String
    Private lbllist As liststoredata
    Public Sub New(path As String)
        lbllist = New liststoredata
        Me.path = path
    End Sub

    Public Sub set_label(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.LABELJMP)
        Dim lblcode As String = clinecodestruc(0).value.Remove(0, 1)
        If lbllist.find(lblcode) Then
            dserr.new_error(conserr.errortype.JMPERROR, clinecodestruc(0).line, path, clinecodestruc(0).value & " - This label is already defined in this scope." & vbCrLf & authfunc.get_line_error(path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End If
        lbllist.add(lblcode)
        lngen.set_direct_label(lblcode, _ilmethod.codes)
    End Sub

    Public Sub jmp_statement(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.JMP)
        Dim lblcode As String = clinecodestruc(1).value.Remove(0, 1)
        If lbllist.find(lblcode) = False Then
            dserr.new_error(conserr.errortype.JMPERROR, clinecodestruc(0).line, path, "label '" & clinecodestruc(1).value & "' used but not defined." & vbCrLf & authfunc.get_line_error(path, servinterface.get_target_info(clinecodestruc(1)), clinecodestruc(1).value))
        End If
        cil.branch_to_target(_ilmethod.codes, lblcode)
    End Sub

End Class
