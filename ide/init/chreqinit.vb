Imports System.IO

Public Class chreqinit
    Public Shared Function requires_initialization() As Boolean
        If Directory.Exists(conrex.LOCALAPPDATADIR) = False Then Return True
        If File.Exists(conrex.PROJECTLISTFILE) = False Then Return True
        If File.Exists(conrex.FILEOPENLIST) = False Then Return True
        Return False
    End Function
End Class
