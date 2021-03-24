Imports System.IO

Public Class cacheste
    Friend Shared Sub init_cache_system()
        If Directory.Exists(conrex.CACHEDIR) = False Then
            create_cache_structure()
        End If
    End Sub

    Friend Shared Sub create_cache_structure()
        Directory.CreateDirectory(conrex.CACHEDIR)
        File.WriteAllText(conrex.CACHEDIR & "\.ver", conrex.VER)
        Directory.CreateDirectory(conrex.CACHEDIR & "\fastbuild")
    End Sub
End Class
