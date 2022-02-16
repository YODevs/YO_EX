Imports System.IO
Imports System.Text
Public Class dotnetbuild
    Private ilasmoutputdata As StringBuilder
    Private ilasmparameter As ilasmparam
        Private path As String
    Public Sub New(inputparam As ilasmparam, path As String)
        ilasmparameter = inputparam
        Me.path = path
    End Sub

    Public Sub compile()
        ilasmoutputdata = New StringBuilder()
        Dim ilasmproc As New System.Diagnostics.Process()
        With ilasmproc.StartInfo
            .WorkingDirectory = path
            .FileName = compdt.DOTNET
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
        If compdt.DEVMOD Then coutputdata.write_file_data("conv_info.txt", ilasmoutputdata.ToString())
        If ilasmoutputdata.ToString.Contains("Build succeeded.") Then
            ilasmconv.result = True
            If compdt.MUTEPROCESS Then Return
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
            Dim iloutput As String = get_error_info(ilasmoutputdata.ToString())
            Console.WriteLine(iloutput)
            ilasmconv.result = False
        End If
            dswar.show_warning()
        End Sub

        ''' <summary>
        ''' <en>
        ''' Cleaning and sorting orders and warnings while compiling in MSIL
        ''' </en>
        ''' <fa>
        ''' پاکسازی و مرتب کردن خطاها و هشدارهای حین کامپایل در MSIL
        ''' </fa>
        ''' </summary>
        ''' <param name="output"></param>
        ''' <returns></returns>
        Private Function get_error_info(output As String) As String
            Dim errgrab As String = String.Empty
            For Each tline In output.Split(vbLf)
            If tline.Trim = Nothing Then Continue For
            If RegularExpressions.Regex.IsMatch(tline, "main\.il\(\d+\)\:\serror\s:") Then
                tline = tline.Remove(0, tline.IndexOf("error :"))
                If tline.Trim.EndsWith(".ilproj]") Then
                    tline = tline.Remove(tline.LastIndexOf("["))
                End If
                errgrab = vbCrLf & tline
                End If
        Next
            Return errgrab.Trim
        End Function
    Private Sub ilasmoutputhandler(sender As Object, e As DataReceivedEventArgs)
        ilasmoutputdata.AppendLine(e.Data)
    End Sub

End Class
