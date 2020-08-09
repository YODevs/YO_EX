Public Class ilasmgen

    Private _ilhead As ilhead
    Private _ilfunc As ilfuncgen
    Private ilcollection As ilformat.ildata
    Public Sub New(ilcol As ilformat.ildata)
        ilcollection = ilcol
    End Sub

    Public Function gen(yoclassdt As tknformat._class) As ilformat.resultildata
        _ilhead = New ilhead(ilcollection, yoclassdt.name)
        'Public fields ...
        _ilfunc = New ilfuncgen(ilcollection, yoclassdt)
        _ilfunc.gen()
    End Function
End Class
