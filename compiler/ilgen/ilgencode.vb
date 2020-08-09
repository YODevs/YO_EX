Public Class ilgencode

    Dim classdt() As tknformat._class
    Dim ilcollection As ilformat.ildata
    Dim ilasm As ilasmgen
    Public Sub New(tknfmtclass() As tknformat._class)
        classdt = tknfmtclass
        ilcollection = New ilformat.ildata
    End Sub

    Public Sub codegenerator()
        For index = 0 To classdt.Length - 1
            'Class Generate ...
            ilasm = New ilasmgen(ilcollection)

        Next
    End Sub
End Class
