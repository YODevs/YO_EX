Imports System.IO

Public Class initessentialfiles

    Public Shared essfiles As New ArrayList
    Public Shared Sub add_path(path As String)
        essfiles.Add(path)
        If File.Exists(path) Then
            Return
        Else
            dserr.new_error(conserr.errortype.MISSINGESSENTIALFILES, -1, Nothing, "Path : " & path)
        End If
    End Sub
End Class
