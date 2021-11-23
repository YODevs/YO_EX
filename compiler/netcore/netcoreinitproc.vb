Imports System.IO

Public Class netcoreinitproc
    Friend Shared Sub init()
        If Directory.Exists(conrex.DOTNETCACHEDIR) = False Then
            Directory.CreateDirectory(conrex.DOTNETCACHEDIR)
        End If
        If Directory.Exists(conrex.DOTNETCACHEDIR & "\" & compdt.TARGETFRAMEWORK) = False Then
            Directory.CreateDirectory(conrex.DOTNETCACHEDIR & "\" & compdt.TARGETFRAMEWORK)
            'Action ...
        End If
    End Sub
End Class
