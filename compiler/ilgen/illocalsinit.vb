Public Class illocalsinit

    Friend Shared Sub set_local_init(ByRef localinit() As ilformat._illocalinit, locinit As ilformat._illocalinit)
        'Check local init name
        Dim localinitlen As Integer = localinit.Length
        Array.Resize(localinit, localinitlen + 1)
        If localinit(localinitlen - 1).name = String.Empty Then
            localinit(localinitlen - 1) = locinit
        Else
            localinit(localinitlen) = locinit
        End If
    End Sub
End Class
