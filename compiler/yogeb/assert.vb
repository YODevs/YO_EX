Public Class assert
    Private _ilmethod As ilformat._ilmethodcollection
    Private enblbranch As String
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
        enblbranch = lngen.get_line_prop("enifcond")
    End Sub

    Public Function set_assertion_st(clinecodestruc() As xmlunpkd.linecodestruc) As ilformat._ilmethodcollection
        Dim condlinecodestruc() As xmlunpkd.linecodestruc = condproc.get_condition(clinecodestruc, 1)
        Dim nbranch As New condproc.branchtargetinfo
        nbranch.truebranch = lngen.get_line_prop("en_assert")
        nbranch.falsebranch = lngen.get_line_prop("st_assert")
        Dim cdproc As New condproc(nbranch)
        cdproc.set_condition(_ilmethod, condlinecodestruc)
        set_assertion_error(clinecodestruc, nbranch)
        Return _ilmethod
    End Function

    Private Sub set_assertion_error(clinecodestruc() As xmlunpkd.linecodestruc, nbranch As condproc.branchtargetinfo)
        lngen.set_direct_label(nbranch.falsebranch, _ilmethod.codes)
        Dim errortext As String = String.Empty
        Dim path As String = ilbodybulider.path.Remove(0, Environment.CurrentDirectory.Length + 1)
        Dim assertcode As String = authfunc.get_line_code(ilbodybulider.path, clinecodestruc(0).line + 1)
        errortext = String.Format("\nAssertion Error {0} Path: {1} - Line [{2}]{0} Code:{3}\n\n", "\n", path, clinecodestruc(0).line, assertcode)
        errortext = errortext.Replace("\", "\\").Replace("\\n", "\n")
        cil.load_string(_ilmethod.codes, errortext)
        cil.insert_il(_ilmethod.codes, "call void [" & compdt.CORELIB & "]System.Console::Write(string)")
        lngen.set_direct_label(nbranch.truebranch, _ilmethod.codes)
    End Sub
End Class
