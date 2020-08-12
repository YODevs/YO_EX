Imports System.IO

Public Class coutputdata

    Public Shared Sub write_data(data As String)
        File.WriteAllText(My.Application.Info.DirectoryPath & "\coutput.txt", data)
    End Sub
    Public Shared Sub write_file_data(filename As String, data As String)
        File.WriteAllText(My.Application.Info.DirectoryPath & "\" & filename, data)
    End Sub
End Class
