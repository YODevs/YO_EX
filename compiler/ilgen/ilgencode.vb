Public Class ilgencode

    Dim classdt() As tknformat._class
    Public Sub New(tknfmtclass() As tknformat._class)
        classdt = tknfmtclass
    End Sub

    Public Sub codegenerator()
        For index = 0 To classdt.Length - 1

        Next
    End Sub
End Class
