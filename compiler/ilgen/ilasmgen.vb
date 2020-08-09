Public Class ilasmgen

    Private _ilhead As ilhead
    Private ilcollection As ilformat.ildata
    Public Sub New(ilcol As ilformat.ildata)
        ilcollection = ilcol
    End Sub

    Public Function gen(yoclassdt As tknformat._class) As ilformat.resultildata
        _ilhead = New ilhead(ilcollection, yoclassdt.name)
    End Function
End Class
