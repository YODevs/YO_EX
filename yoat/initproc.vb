Imports System.IO

Public Class initproc

    Friend Shared Sub init()
        cli.init_cli(False)
        If check_path() Then

        End If
    End Sub

    Private Shared Function check_path()
        If File.Exists(conrex.APPDIR & "/YOCA.exe") = False Then
            Console.Write("YO compiler(YOCA.exe) not found.")
            Return False
        End If
        Return True
    End Function
End Class
