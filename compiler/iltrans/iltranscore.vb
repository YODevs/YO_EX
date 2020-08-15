Public Class iltranscore

    Private methoddata As tknformat._method
    Public Sub New(method As tknformat._method)
        methoddata = method
    End Sub

    Public Sub gen_transpile_code(ByRef _ilmethod As ilformat._ilmethodcollection)
        _ilmethod.codes = New ArrayList
        _ilmethod.line = New ArrayList
    End Sub
End Class
