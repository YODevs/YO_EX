Imports System.IO
Imports System.Text

Public Class ilasmconv
    Private ilasmoutputdata As StringBuilder
    Private ilasmparameter As ilasmparam
    Public Sub New(inputparam As ilasmparam)
        ilasmparameter = inputparam
        init()
    End Sub

    Public Sub compile()
        ilasmoutputdata = New StringBuilder()
        Dim ilasmproc As New System.Diagnostics.Process()
        With ilasmproc.StartInfo
            .FileName = My.Application.Info.DirectoryPath & "\ilasm.exe"
            .Arguments = ilasmparameter.get_param_list
            .RedirectStandardOutput = True
            .RedirectStandardError = True
            .RedirectStandardInput = True
            .UseShellExecute = False
            .WindowStyle = ProcessWindowStyle.Normal
            .CreateNoWindow = False
        End With

        AddHandler ilasmproc.OutputDataReceived, AddressOf ilasmoutputhandler
        ilasmproc.Start()
        ilasmproc.BeginOutputReadLine()
        ilasmproc.WaitForExit()
        If compdt.DISPLAYILASMOUTPUT Then Console.WriteLine(ilasmoutputdata.ToString())
        coutputdata.write_file_data("conv_info.txt", ilasmoutputdata.ToString())


        If ilasmoutputdata.ToString.Contains("Operation completed successfully") Then
            procresult.rs_set_result(True)
            Console.WriteLine("-The overall result")
            Dim ciden As Int16 = Console.ForegroundColor
            Console.ForegroundColor = ConsoleColor.DarkGreen
            Console.WriteLine(vbTab & "***** Operation completed successfully *****")
            Console.ForegroundColor = ciden
        ElseIf ilasmoutputdata.ToString.Contains("***** FAILURE *****") Then
            procresult.rs_set_result(False)
            Console.WriteLine("-The overall result")
            Dim ciden As Int16 = Console.ForegroundColor
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine(vbTab & "***** FAILURE *****")
            Console.ForegroundColor = ciden
            Dim iloutput As String = ilasmoutputdata.ToString().Trim
            iloutput = iloutput.Remove(0, iloutput.IndexOf(vbLf)).Trim
            iloutput = iloutput.Remove(iloutput.IndexOf("***** FAILURE *****")).Trim
            Console.WriteLine(iloutput)
        End If
    End Sub

    Private Sub ilasmoutputhandler(sender As Object, e As DataReceivedEventArgs)
        ilasmoutputdata.AppendLine(e.Data)
    End Sub

    Private Sub init()
        ilasmparameter.add_param("/NOLOGO")
        ilasmparameter.add_param("/OPTIMIZE")
    End Sub
End Class
