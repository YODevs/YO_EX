Public Class ilfuncgen

    Private grabentrypoint As Boolean = False
    Private ilcollection As ilformat.ildata
    Private yoclassdt As tknformat._class
    Private _ilmethods(0) As ilformat._ilmethodcollection

    Public Sub New(ilcol As ilformat.ildata, yoclass As tknformat._class)
        ilcollection = ilcol
        yoclassdt = yoclass
        _ilmethods(0) = New ilformat._ilmethodcollection
    End Sub

    Public Function gen() As ilformat._ilmethodcollection()
        For index = 0 To yoclassdt.methods.Length - 1
            Dim _ilmethodslen As Integer = _ilmethods.Length
            Dim imethod As Int16 = _ilmethodslen - 1
            If _ilmethodslen <> 0 Then
                Array.Resize(_ilmethods, _ilmethodslen + 1)
            End If
            func_ilforamtter(yoclassdt.methods(index), _ilmethodslen)
        Next
        Return _ilmethods
    End Function


    Public Sub func_ilforamtter(yomethod As tknformat._method, _ilmethodslen As Integer)
        'Check name rules ...
        'Check uniq names
        _ilmethods(_ilmethodslen).name = yomethod.name
        If yomethod.name.ToLower = "main" Then
            If grabentrypoint = False Then
                _ilmethods(_ilmethodslen).entrypoint = True
                grabentrypoint = True
            Else
                'When two entry points 
                'set error
            End If
        End If

        _ilmethods(_ilmethodslen).codes.Add("ldstr ""Hello From YOLang""")
        _ilmethods(_ilmethodslen).codes.Add("Call Void [mscorlib]System.Console:WriteLine(String)")
        _ilmethods(_ilmethodslen).codes.Add("ret")

    End Sub
End Class
