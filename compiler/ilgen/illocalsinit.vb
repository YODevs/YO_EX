Public Class illocalsinit

    Friend Shared Sub set_local_init(ByRef funcdt As ilformat._ilmethodcollection, locinit As ilformat._illocalinit)
        'Check local init name
        Dim funcdtlen As Integer = funcdt.locallinit.Length
        Array.Resize(funcdt.locallinit, funcdtlen + 1)
        funcdt.locallinit(funcdtlen) = locinit
    End Sub
End Class
