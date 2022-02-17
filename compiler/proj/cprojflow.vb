Imports System.IO
Imports YODA

Public Class cprojflow

    Private yodagen As YODA_Format
    Private cproj As cprojdt
    Public Sub New()
        yodagen = New YODA_Format
    End Sub

    Public Sub start_project_flow()
        check_prerequisites()
    End Sub

    Private Sub check_prerequisites()
        procresult.rp_init("Preparation & analysis of 'labra.yoda'")
        If File.Exists(conrex.ENVCURDIR & "\labra.yoda") = False Then
            'set error
        End If
        load_cproj_data()
        procresult.rs_set_result(True)
        procresult.rp_init("Check the path of project files")
        If Directory.Exists(conrex.ENVCURDIR & cprojdt.get_val("sourcepath")) = False Then
            dserr.args.Add("\src")
            dserr.new_error(conserr.errortype.PROJECTSTRUCTERROR, -1, Nothing)
        End If

        If Directory.Exists(conrex.ENVCURDIR & cprojdt.get_val("assetspath")) = False Then
            Directory.CreateDirectory(conrex.ENVCURDIR & cprojdt.get_val("assetspath"))
            Console.Write("[Reconstructed assets folder]")
        End If

        Dim gpath As String = servinterface.get_ilasm_path()
        If gpath <> conrex.NULL Then
            compdt.ILASMPATH = gpath
        Else
            dserr.args.Add("V3.5|4|...")
            dserr.new_error(conserr.errortype.TARGETFRAMEWORKERROR, -1, Nothing, "To solve this problem, you can go to https://dotnet.microsoft.com/download/dotnet-framework and download and install the desired version.")
        End If
        procresult.rs_set_result(True)

        load_type_of_project()
        libreg.init_libraries(conrex.ENVCURDIR & cprojdt.get_val("assetspath"))
        impfiles.import_directory(conrex.ENVCURDIR & cprojdt.get_val("sourcepath"))
    End Sub
    Public Sub load_type_of_project()
        compdt.PROJECTASSEMBLYNAME = cprojdt.get_val("assemblyname")
        compdt.PROJECTFRAMEWORK = cprojdt.get_val("projectframework")
        If compdt.PROJECTFRAMEWORK = ".netcore" Then
            netcoreinitproc.load_framework_data()
        End If
        If compdt.PROJECTFRAMEWORK = conrex.NULL Then compdt.PROJECTFRAMEWORK = ".netframework"
        compdt.TARGETFRAMEWORK = cprojdt.get_val("targetframework")

        If compdt.PROJECTFRAMEWORK = ".netcore" Then
            Dim dotnetproc As New System.Diagnostics.Process()
            Try
                With dotnetproc.StartInfo
                    .FileName = "dotnet"
                    .Arguments = "--list-runtimes"
                    .RedirectStandardOutput = True
                    .RedirectStandardError = True
                    .RedirectStandardInput = True
                    .UseShellExecute = False
                    .WindowStyle = ProcessWindowStyle.Normal
                    .CreateNoWindow = False
                End With

                dotnetproc.Start()
                dotnetproc.WaitForExit()
            Catch ex As Exception
                dserr.args.Add(".NET Core is not installed on your system.
Download the latest SDK version from this link (https://dotnet.microsoft.com/download).")
                dserr.new_error(conserr.errortype.DOTNETERROR, -1, Nothing, Nothing)
            End Try
            Dim result As Boolean = False
            For Each singlesdk In dotnetproc.StandardOutput.ReadToEnd().Split(vbCrLf)
                singlesdk = singlesdk.Trim
                If singlesdk <> conrex.NULL AndAlso singlesdk.StartsWith("Microsoft.NETCore.App") Then
                    singlesdk = singlesdk.Remove(0, singlesdk.IndexOf(conrex.SPACE) + 1)
                    singlesdk = singlesdk.Remove(singlesdk.IndexOf(conrex.SPACE))
                    If singlesdk = compdt.TARGETFRAMEWORK Then
                        result = True
                        Exit For
                    End If
                End If
            Next
            If result = False Then
                dserr.args.Add(".NET Core version '" & compdt.TARGETFRAMEWORK & "' is not installed on your system, download the SDK via this link.(https://dotnet.microsoft.com/download).")
                dserr.new_error(conserr.errortype.DOTNETERROR, -1, Nothing, Nothing)
            Else
                netcoreinitproc.init()
                procresult.rs_set_result(True)
            End If
        End If
    End Sub
    Public Sub load_cproj_data()
        If compdt.DEVMOD = False Then
            If File.Exists(conrex.APPDIR & "\iniopt\dev") Then compdt.DEVMOD = True
        End If
        Dim getlabrasetting As String = File.ReadAllText(conrex.ENVCURDIR & "\labra.yoda")
        Dim labradt As YODA_Format.YODAMapFormat = yodagen.ReadYODA_Map(getlabrasetting)
        cproj = New cprojdt(labradt)
        cproj.conv_to_mapstore()
    End Sub
End Class
