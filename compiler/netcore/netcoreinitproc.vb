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
        Dim bridgecoreproc As New System.Diagnostics.Process()
        Try
            With bridgecoreproc.StartInfo
                .FileName = compdt.BRIDGECORE
                .Arguments = compdt.TARGETFRAMEWORK & conrex.SPACE & targetdir.Replace(conrex.SPACE, "@#SP#")
                .UseShellExecute = True
                .WindowStyle = ProcessWindowStyle.Normal
                .CreateNoWindow = True
            End With

            bridgecoreproc.Start()
            bridgecoreproc.WaitForExit()
            check_bridge_state(bridgecoreproc.ExitCode)
        Catch ex As Exception
            dserr.args.Add(ex.Message)
            dserr.new_error(conserr.errortype.DOTNETERROR, -1, Nothing, Nothing)
        End Try
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
End Class
