Imports System.IO

Public Class impfiles
    Public Shared Sub import_directory(dir As String)
        If Directory.Exists(dir) Then

        Else
            dserr.new_error(conserr.errortype.DIRNOTFOUND, dir & " => dir not found.")
        End If
    End Sub
End Class
