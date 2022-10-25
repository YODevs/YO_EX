Imports System.IO

Public Class gen
    Friend Shared report As formreport
    Friend Shared outputs As YOLIB.list
    Friend Shared m As String
    Friend Shared Sub execute(path As String, Optional justbuild As Boolean = False)
        If check_project(path) = False Then Return
        show_report_form()
        Dim command As String = "run"
        If justbuild Then command = "build"
        load_def_params(command)
        Dim yocaproc As New System.Diagnostics.Process()
        With yocaproc.StartInfo
            .FileName = "yoca.exe"
            .WorkingDirectory = path
            .Arguments = command
            .RedirectStandardOutput = True
            .RedirectStandardError = True
            .RedirectStandardInput = True
            .UseShellExecute = False
            .CreateNoWindow = True
            .WindowStyle = ProcessWindowStyle.Minimized
        End With

        AddHandler yocaproc.OutputDataReceived, AddressOf yoca_output_handler
        yocaproc.StartInfo.CreateNoWindow = True
        yocaproc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        yocaproc.Start()
        yocaproc.BeginOutputReadLine()
        yocaproc.WaitForExit()
        report.get_update("-end")
    End Sub

    Private Shared Sub load_def_params(ByRef command As String)
        If command = "run" Then
            command &= load_params("runparams")
        ElseIf command = "build" Then
            command &= load_params("buildparams")
        Else
            Return
        End If
    End Sub

    Private Shared Function load_params(filename As String) As String
        Dim fileloc As String = conrex.EXTENSIONDIR & filename
        If File.Exists(fileloc) Then
            Return " " & File.ReadAllText(fileloc)
        End If
        Return String.Empty
    End Function

    Public Shared Sub show_report_form()
        Dim repthread As New System.Threading.Thread(AddressOf thread_start_report)
        repthread.SetApartmentState(Threading.ApartmentState.STA)
        repthread.Start()
    End Sub

    Private Shared Sub thread_start_report()
        report = New formreport
        report.ShowDialog()
        '   Application.Run(report)
    End Sub

    Private Shared Sub yoca_output_handler(sender As Object, e As DataReceivedEventArgs)
        If e.Data = String.Empty Then Return
        report.get_update(e.Data)
    End Sub

    Private Shared Function check_project(path As String) As Boolean
        If Directory.Exists(path) = False Then
            MsgBox("Path " & path & " was not found!", MsgBoxStyle.Critical, "Compile Error")
            Return False
        End If
        If File.Exists(path & "\labra.yoda") = False Then
            MsgBox("The project settings file (labra.yoda) was not found!", MsgBoxStyle.Critical, "Compile Error")
            Return False
        End If
        Return True
    End Function
End Class
