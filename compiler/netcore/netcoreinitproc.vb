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
                .Arguments = compdt.TARGETFRAMEWORK & Space(1) & targetdir.Replace(conrex.SPACE, "@#SP#")
                .RedirectStandardOutput = True
                .RedirectStandardError = True
                .RedirectStandardInput = True
                .UseShellExecute = False
                .WindowStyle = ProcessWindowStyle.Normal
                .CreateNoWindow = False
            End With

            bridgecoreproc.Start()
            bridgecoreproc.WaitForExit()
            Dim resultbrigecore As String = conrex.NULL
            For Each stdoutput In bridgecoreproc.StandardOutput.ReadToEnd().Split(vbCrLf)
                resultbrigecore &= stdoutput
            Next
            '...Action
        Catch ex As Exception
            dserr.args.Add(ex.Message)
            dserr.new_error(conserr.errortype.DOTNETERROR, -1, Nothing, Nothing)
        End Try
    End Sub
End Class
