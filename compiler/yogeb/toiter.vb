Public Class toiter
    Private _ilmethod As ilformat._ilmethodcollection
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_to_iter(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit) As ilformat._ilmethodcollection
        'Create a flag variable for [TO] iter
        set_flag_loop(_illocalinit, clinecodestruc)
        'Create & Set label for [TO] body
        lngen.set_label("tobody", _ilmethod.codes)
        Return _ilmethod
    End Function

    Private Sub set_flag_loop(ByRef _illocalinit() As ilformat._illocalinit, clinecodestruc() As xmlunpkd.linecodestruc)
        Dim locinit As New ilformat._illocalinit
        locinit.name = lngen.get_flag
        locinit.datatype = "int32"
        locinit.hasdefaultvalue = True
        locinit.iscommondatatype = True
        Array.Resize(locinit.clocalvalue, 1)
        locinit.clocalvalue(0).value = 0
        illocalsinit.set_local_init(_illocalinit, locinit)
        'Set initial value for [TO] flag
        set_initial_value(locinit.name, clinecodestruc(2))
    End Sub

    Private Sub set_initial_value(varname As String, clinecodestruc As xmlunpkd.linecodestruc)
        Dim optgen As New ilopt(_ilmethod)
        _ilmethod = optgen.assi_int(varname, clinecodestruc, "int32")
    End Sub
End Class
