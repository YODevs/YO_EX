Imports System.IO

Public Class coutputdata

    Public Shared Sub write_data(data As String)
        File.WriteAllText(My.Application.Info.DirectoryPath & "\coutput.txt", data)
    End Sub
    Public Shared Sub write_file_data(filename As String, data As String)
        File.WriteAllText(My.Application.Info.DirectoryPath & "\" & filename, data)
    End Sub
    Public Shared Sub print_token(clinecodestruc() As xmlunpkd.linecodestruc)
        Console.WriteLine()
        For index = 0 To clinecodestruc.Length - 1
            Console.WriteLine("{0}-{1} :: {2}", clinecodestruc(index).tokenid, clinecodestruc(index).name, clinecodestruc(index).value)
        Next
    End Sub
End Class
