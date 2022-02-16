Imports System.IO

Public Class netcoreinitproc
    Friend Shared Sub init()
        If Directory.Exists(conrex.DOTNETCACHEDIR) = False Then
            Directory.CreateDirectory(conrex.DOTNETCACHEDIR)
        End If
        If Directory.Exists(conrex.DOTNETCACHEDIR & "\" & compdt.TARGETFRAMEWORK) = False Then
            Directory.CreateDirectory(conrex.DOTNETCACHEDIR & "\" & compdt.TARGETFRAMEWORK)
        End If
        start_process()
    End Sub

    Private Shared Sub start_process()
        Dim targetdir As String = conrex.DOTNETCACHEDIR & "\" & compdt.TARGETFRAMEWORK
        If (File.Exists(targetdir & "\types.yoda") = False) Then
            Dim bridgecoreproc As New System.Diagnostics.Process()
            Try
                With bridgecoreproc.StartInfo
                    .FileName = compdt.BRIDGECORE
                    .Arguments = compdt.TARGETFRAMEWORK & conrex.SPACE & targetdir.Replace(conrex.SPACE, "@#SP#")
                    .UseShellExecute = True
                    .WindowStyle = ProcessWindowStyle.Hidden
                    .CreateNoWindow = True
                End With
                bridgecoreproc.Start()
                bridgecoreproc.WaitForExit()
                check_bridge_state(bridgecoreproc.ExitCode)
            Catch ex As Exception
                dserr.args.Add(ex.Message)
                dserr.new_error(conserr.errortype.DOTNETERROR, -1, Nothing, Nothing)
            End Try
        End If

        set_sdk()
        asmlist.init(targetdir & "\types.yoda")
    End Sub

    Public Shared Sub set_sdk()
        If compdt.TARGETFRAMEWORK.StartsWith("6.") Then
            compdt.DOTNETVERSDK = "6.0.0"
            compdt.DOTNETNAME = "net6.0"
        ElseIf compdt.TARGETFRAMEWORK.StartsWith("5.") Then
            compdt.DOTNETVERSDK = "5.0.0"
            compdt.DOTNETNAME = "net5.0"
        ElseIf compdt.TARGETFRAMEWORK.StartsWith("3.") Then
            compdt.DOTNETVERSDK = "3.0.0"
            compdt.DOTNETNAME = "netcoreapp3.0"
        ElseIf compdt.TARGETFRAMEWORK.StartsWith("7.") Then
            compdt.DOTNETVERSDK = "7.0.0"
            compdt.DOTNETNAME = "net7.0"
        Else
            dserr.args.Add("Version " & compdt.TARGETFRAMEWORK & " of .NET Core is not installed.")
            dserr.new_error(conserr.errortype.DOTNETERROR, -1, Nothing, Nothing)
        End If
    End Sub
    Private Shared Sub check_bridge_state(exitcode As Integer)
        Dim errortext As String = "Return code interpretation not found."
        Select Case exitcode
            Case compdt.dotnetcorebridgestate.success
                Return
            Case compdt.dotnetcorebridgestate.dotnetcorenotfound
                errortext = ".Net Core not found."
            Case compdt.dotnetcorebridgestate.dotnetcoreversionnotfound
                errortext = "Version " & compdt.TARGETFRAMEWORK & " of .NET Core is not installed."
            Case Else
                Return
        End Select
        dserr.args.Add(errortext)
        dserr.new_error(conserr.errortype.BRIDGECOREERROR, -1, Nothing, Nothing)
    End Sub

    Friend Shared Sub load_framework_data()
        procresult.rp_init("Check .NET Core Prerequisites")
        compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetCore
        compdt.CORELIB = "System.Private.CoreLib"
        compdt.WAITILCODE = "call string [System.Console]System.Console::ReadLine()
pop"
    End Sub
End Class
