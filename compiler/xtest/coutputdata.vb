Imports System.IO

Public Class coutputdata

    Public Shared Sub write_data(data As String)
        File.WriteAllText(My.Application.Info.DirectoryPath & "\coutput.txt", data)
    End Sub
End Class
