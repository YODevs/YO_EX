Imports System.IO

Public Class initproc

    Friend Shared Sub init()
        cli.init_cli(False)
        If check_path() Then
            Dim dirlist() As String = Directory.GetDirectories(conrex.APPDIR & "\ctest")
            Dim yocapr As New yocaproc(dirlist)
            yocapr.check()
        End If
    End Sub

    Private Shared Function check_path()
        If File.Exists(conrex.APPDIR & "\YOCA.exe") = False Then
            Console.Write("YO compiler(YOCA.exe) not found.")
            Return False
        End If

        If Directory.Exists(conrex.APPDIR & "\ctest") = False Then
            Console.Write(conrex.APPDIR & "\ctest" & " not found.")
            Return False
        End If
        Return True
    End Function
End Class
