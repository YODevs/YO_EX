Public Class funcste
    Friend Shared attribute As yocaattribute.yoattribute
    Friend Shared Sub invoke_method(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, funcresult As funcvalid._resultfuncvaild)
        If funcresult.callintern Then
            Dim classindex As Integer = funcdtproc.get_index_class(attribute._app._classname)
            If classindex = -1 Then
                'Class Not Found
                Return
            End If
            Dim methodindex As Integer = funcdtproc.get_index_method(funcresult.clmethod, classindex)
            If methodindex = -1 Then
                MsgBox("Method Not Found")
                'Method Not Found
            End If

            cil.call_intern_method(_ilmethod.codes, Nothing, attribute._app._classname, funcresult.clmethod, Nothing)
        End If
    End Sub

End Class
