Imports System.IO

Public Class cilcomp
    Friend Shared debug As Boolean = False
    Friend Shared ext As String = ".exe"
    Private Shared prnum As Int16 = 562
    Private Shared optilfile As String = String.Empty
    Private Shared temppath As String = String.Empty

    Friend Shared Function get_assets_loca() As String
        Dim loca As String = conrex.ENVCURDIR & cprojdt.get_val("assetspath") & "\"
        Return loca
    End Function
    Friend Shared Function get_il_loca() As String
        Dim getrandom As New Random
        check_route()
        Dim loca As String = conrex.ENVCURDIR & "\target\"
        If debug = False Then
            prnum = getrandom.Next(0, 30000)
            loca &= "release\" & prnum & cprojdt.get_val("assemblyname") & ".il"
        Else
            loca &= "debug\" & prnum & cprojdt.get_val("assemblyname") & ".il"
        End If
        optilfile = loca
        Return loca
    End Function
    Friend Shared Function get_dotnetcore_dir() As String
        Dim getrandom As New Random
        check_route()
        Dim loca As String = conrex.ENVCURDIR & "\target\"
        If debug = False Then
            loca &= "release\"
        Else
            loca &= "debug\"
        End If
        loca &= "obj" & getrandom.Next(0, 30000)
        Directory.CreateDirectory(loca)
        temppath = loca
        Return loca
    End Function

    Friend Shared Function get_dotnetcore_output() As String
        If cprojdt.get_val("outputpath") <> conrex.NULL Then
            dswar.set_warning("Lack of feature support", "The ability to output to a custom address for .NET Core is disabled.")
        End If
        Dim getrandom As New Random
        check_route()
        Dim loca As String = conrex.ENVCURDIR & "\target\"
        If debug = False Then
            loca &= "release\"
        Else
            loca &= "debug\"
        End If
        loca &= compdt.DOTNETNAME & conrex.BKSLASH & compdt.PROJECTASSEMBLYNAME & ext
        Return loca
    End Function

    Friend Shared Function get_output_loca() As String
        set_extension_loca()
        Dim loca As String = optilfile
        If cprojdt.get_val("outputpath") <> conrex.NULL Then
            loca = cprojdt.get_val("outputpath")
            If loca.EndsWith("\") = False Then loca &= "\"
        Else
                loca = loca.Remove(loca.LastIndexOf("\") + 1)
        End If
        loca &= cprojdt.get_val("assemblyname") & ext
        Return loca
    End Function

    Friend Shared Function get_output_loca_without_extension() As String
        Dim loca As String = optilfile
        loca = loca.Remove(loca.LastIndexOf("\"))
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
        If compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetFramework Then
            File.Delete(optilfile)
        ElseIf compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetCore Then
            Directory.Delete(temppath, True)
        End If
    End Sub

    Private Shared Sub set_extension_loca()
        If cprojdt.get_val("outputtype").ToLower = "library" Then
            ext = ".dll"
        End If
    End Sub
End Class
