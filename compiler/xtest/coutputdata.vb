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

    Public Shared Sub print_collection(arr As ArrayList)
        Console.WriteLine()
        If IsNothing(arr) OrElse arr.Count = 0 Then
            Console.WriteLine("Collection is Empty !")
            Return
        End If
        For index = 0 To arr.Count - 1
            Console.WriteLine("{0}-> {1}", index, arr(index))
        Next
    End Sub
    Public Shared Sub message_box(text As String)
        MsgBox(text)
    End Sub
End Class
