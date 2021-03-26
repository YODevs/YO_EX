Imports System.IO

Public Class cacheste
    Friend Shared Sub init_cache_system()
        If Directory.Exists(conrex.CACHEDIR) = False Then
            create_cache_structure()
        Else
            If File.Exists(conrex.CACHEDIR & "\.ver") Then
                If File.ReadAllText(conrex.CACHEDIR & "\.ver").ToString <> conrex.VER Then
                    Directory.Delete(conrex.CACHEDIR, True)
                    create_cache_structure()
                End If
            Else
                Directory.Delete(conrex.CACHEDIR, True)
                create_cache_structure()
            End If
        End If
    End Sub

    Friend Shared Sub create_cache_structure()
        Directory.CreateDirectory(conrex.CACHEDIR)
        File.WriteAllText(conrex.CACHEDIR & "\.ver", conrex.VER)
        Directory.CreateDirectory(conrex.CACHEDIR & "\fastbuild")
    End Sub
End Class
