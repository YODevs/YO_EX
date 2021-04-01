Imports System.IO

Public Class cachemkr
    Friend Shared cacheprojectdir As String = String.Empty
    Friend Shared Sub create_cache_file(path As String, source As String)
        If cacheprojectdir = conrex.NULL Then create_cache_route()
        Dim filepath As String = cacheprojectdir & servinterface.get_hash(path)
        File.WriteAllText(filepath, source)
        create_cache_info(path, filepath)
    End Sub

    Private Shared Sub create_cache_info(mainpath As String, hashfilepath As String)
        Dim key, val As ArrayList
        key = New ArrayList
        val = New ArrayList
        key.Add("path")
        val.Add(mainpath)

        key.Add("dt_cr")
        val.Add(File.GetCreationTime(mainpath).ToFileTimeUtc)

        key.Add("dt_mod")
        val.Add(File.GetLastWriteTime(mainpath).ToFileTimeUtc)

        Dim yoda As New YODA.YODA_Format
        Dim labrainfo As String = yoda.WriteYODA_Map(key, val, True)
        File.WriteAllText(hashfilepath & conrex.YODAFORMAT, labrainfo)
    End Sub
    Friend Shared Sub create_cache_route()
        cacheprojectdir = conrex.CACHEDIR & "\fastbuild\" & servinterface.get_hash(conrex.ENVCURDIR) & "\"
        If Directory.Exists(cacheprojectdir) = False Then
            Directory.CreateDirectory(cacheprojectdir)
        End If
    End Sub

End Class
