Public Class jmp
    Private Shared path As String
    Public Shared lbllist As liststoredata
    Public Shared Sub init(xpath As String)
        lbllist = New liststoredata
        path = xpath
    End Sub

    Public Shared Sub set_label(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.LABELJMP)
        Dim lblcode As String = clinecodestruc(0).value.Remove(0, 1)
        set_label_customization(lblcode)
        If lbllist.find(lblcode) Then
            dserr.new_error(conserr.errortype.JMPERROR, clinecodestruc(0).line, path, clinecodestruc(0).value & " - This label is already defined in this scope." & vbCrLf & authfunc.get_line_error(path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End If
        lbllist.add(lblcode)
        lngen.set_direct_label(lblcode, _ilmethod.codes)
    End Sub

    Public Shared Sub jmp_statement(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.JMP)
        Dim lblcode As String = clinecodestruc(1).value.Remove(0, 1)
        set_label_customization(lblcode)
        cil.branch_to_target(_ilmethod.codes, lblcode)
    End Sub

    Private Shared Sub set_label_customization(ByRef lblcode As String)
        lblcode = conrex.COSTR & lblcode & conrex.COSTR
    End Sub
End Class
