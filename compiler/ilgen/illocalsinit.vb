Public Class illocalsinit

    Friend Shared Sub set_local_init(ByRef localinit() As ilformat._illocalinit, locinit As ilformat._illocalinit)
        'Check local init name
        Dim localinitlen As Integer = localinit.Length
        Array.Resize(localinit, localinitlen + 1)
        localinit(localinitlen - 1) = locinit
    End Sub
End Class
