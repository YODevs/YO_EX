Imports System.IO
Imports System.Text

Public Class ilasmconv
    Private ilasmoutputdata As StringBuilder
    Private ilasmparameter As ilasmparam
    Private path As String
    Public Sub New(inputparam As ilasmparam, path As String)
        ilasmparameter = inputparam
        Me.path = path
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
            Dim iloutput As String = get_standard_error(ilasmproc.StandardError)
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

    Private Function get_standard_error(ptrstderr As StreamReader) As String
        Dim errtext As String = String.Empty
        While True
            Dim rte As String = ptrstderr.ReadToEnd()
            If rte = String.Empty Then
                Exit While
            Else
                errtext &= rte & vbLf
            End If
        End While
        remove_il_data(errtext)
        Return errtext.Trim
    End Function

    Private Sub remove_il_data(ByRef errtext As String)
        Dim capt As String = path.Remove(path.LastIndexOf(conrex.DOT) + 1)
        errtext = errtext.Replace(capt, conrex.NULL)
    End Sub
End Class
