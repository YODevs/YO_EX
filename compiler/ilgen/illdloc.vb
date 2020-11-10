Public Class illdloc
    Public _ilmethod As ilformat._ilmethodcollection
    Public Sub New(_ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = _ilmethod
    End Sub

    Public Function load_in_stack(paramtypes As ArrayList, cargcodestruc As xmlunpkd.linecodestruc()) As ilformat._ilmethodcollection
        Console.WriteLine()
        For index = 0 To cargcodestruc.Length - 1

            Console.WriteLine("{0} ({1}) -> {2}", cargcodestruc(index).value, cargcodestruc(index).name, paramtypes(index))
        Next

        Return _ilmethod
    End Function

    Private Shared Sub ldstr()

    End Sub

    Private Sub ldinteger(snparamtype As String, cargcodestruc As xmlunpkd.linecodestruc)

    End Sub
End Class
