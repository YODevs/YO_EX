Imports System.IO

Public Class cilcomp
    Friend Shared debug As Boolean = False
    Friend Shared ext As String = ".exe"
    Private Shared prnum As Int16 = 562
    Private Shared optilfile As String = String.Empty
    Friend Shared Function get_il_loca() As String
        Dim getrandom As New Random
        check_route()
        Dim loca As String = conrex.ENVCURDIR & "\target\"
        If debug = False Then
            prnum = getrandom.Next(0, 30000)
            loca &= "release\" & prnum & cprojdt.get_val("assemblyname") & ".il"
        Else
            '...
        End If
        optilfile = loca
        Return loca
    End Function

    Friend Shared Function get_output_loca() As String
        Dim loca As String = optilfile
        loca = loca.Remove(loca.LastIndexOf("\") + 1)
        loca &= cprojdt.get_val("assemblyname") & ext
        Return loca
    End Function

    Friend Shared Sub check_route()
        If Directory.Exists(conrex.ENVCURDIR & "\target\debug") = False Then
            Directory.CreateDirectory(conrex.ENVCURDIR & "\target\debug")
        End If

        If Directory.Exists(conrex.ENVCURDIR & "\target\release") = False Then
            Directory.CreateDirectory(conrex.ENVCURDIR & "\target\release")
        End If
    End Sub

    Friend Shared Sub set_options()
        File.Delete(optilfile)
    End Sub

End Class
