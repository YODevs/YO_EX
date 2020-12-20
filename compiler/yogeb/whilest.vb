Imports YOCA

Public Class whilest
    Private _ilmethod As ilformat._ilmethodcollection
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_while_st(clinecodestruc() As xmlunpkd.linecodestruc, illocalinit() As ilformat._illocalinit, localinit As localinitdata) As ilformat._ilmethodcollection
        coutputdata.print_token(clinecodestruc)
        Dim condlinecodestruc() As xmlunpkd.linecodestruc = condproc.get_condition(clinecodestruc, 1)
        Dim whilenblock As xmlunpkd.linecodestruc = condproc.get_block_body(clinecodestruc)
        Return _ilmethod
    End Function
End Class
