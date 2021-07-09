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
                Else
                    cache_scheduling_operation()
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

    Friend Shared Function cache_cleaner() As Boolean
        If Directory.Exists(conrex.CACHEDIR) Then
            Directory.Delete(conrex.CACHEDIR, True)
            Return True
        End If
        Return False
    End Function

    Friend Shared Sub cache_scheduling_operation()
        Dim fastbuilddirs() As String = Directory.GetDirectories(conrex.CACHEDIR & "\fastbuild")
        If fastbuilddirs.Length = 0 Then Return
        For index = 0 To fastbuilddirs.Length - 1
            Dim dir As String = fastbuilddirs(index).ToString
            Dim dircurdate As Date = Directory.GetLastWriteTime(dir)
            Dim tsp As TimeSpan = Date.Now.Subtract(dircurdate)
            If tsp.TotalDays > conrex.CACHEACTIVITYRANGE OrElse File.Exists(dir & "\.delete") Then
                Directory.Delete(dir, True)
            End If
        Next
    End Sub
End Class
