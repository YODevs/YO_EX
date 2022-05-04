Imports System.Net
Imports System.Net.Sockets
Imports System.Windows.Forms

Public Class chartui
    Friend remoteactive As Boolean
    Dim palletes As map
    Private receiveudpclient As UdpClient
    Private threadrecive As System.Threading.Thread
    Private remoteipendpoint As New System.Net.IPEndPoint(System.Net.IPAddress.Any, 0)
    Private byteReceive As Byte() = New Byte() {}
    Private Sub EditViewPointsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditViewPointsToolStripMenuItem.Click
        Dim formpoint As New editpoint
        formpoint.ShowDialog()
    End Sub

    Private Sub EnableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnableToolStripMenuItem.Click
        chart.ChartAreas(0).Area3DStyle.Enable3D = True
    End Sub

    Private Sub DisableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableToolStripMenuItem.Click
        chart.ChartAreas(0).Area3DStyle.Enable3D = False
    End Sub

    Private Sub DOptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DOptionsToolStripMenuItem.Click
        Dim thdoption As New dddoptions
        thdoption.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SaveChartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveChartToolStripMenuItem.Click
        chart.SaveImage(My.Application.Info.DirectoryPath & "\chart-" & New Random().Next(1000, 9999) & ".png", Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png)
    End Sub

    Private Sub ChangeChartTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeChartTypeToolStripMenuItem.Click
        Dim charttype As New charttypeoptions
        charttype.ShowDialog()
    End Sub
    Private Sub chartui_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        get_all_pallete()
        palletecombo.SelectedIndex = palletes.get(chart.Palette.ToString)
        If remoteactive Then
            EnableToolStripMenuItem1_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub get_all_pallete()
        palletes = New map
        Dim cpallete As Windows.Forms.DataVisualization.Charting.ChartColorPalette
        Dim values As Array = [Enum].GetValues(cpallete.GetType)
        Dim keys As String() = [Enum].GetNames(cpallete.GetType)
        For index = 0 To values.Length - 1
            palletes.add(keys(index), values(index))
            palletecombo.Items.Add(keys(index))
        Next
    End Sub

    Private Sub palletecombo_TextChanged(sender As Object, e As EventArgs) Handles palletecombo.TextChanged
        chart.Palette = palletes.get(palletecombo.SelectedItem)
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PageSetupToolStripMenuItem.Click
        chart.Printing.PageSetup()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        chart.Printing.PrintDocument.DocumentName = Me.Text
        chart.Printing.PrintDocument.Print()
    End Sub

    Private Sub EnableToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EnableToolStripMenuItem1.Click
        EnableToolStripMenuItem1.Checked = True
        DisableToolStripMenuItem1.Checked = False
        Try
            remoteactive = True
            receiveudpclient = New System.Net.Sockets.UdpClient(CInt(porttextbox.Text))
            threadrecive = New System.Threading.Thread(AddressOf receive_point)
            threadrecive.Start()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        End Try
    End Sub

    Private Sub receive_point()
        Try
            Do
                If DisableToolStripMenuItem1.Checked Then
                    receiveudpclient.Close()
                    receiveudpclient.Dispose()
                    Return
                End If
                Dim receiveBytes As [Byte]() = receiveudpclient.Receive(remoteipendpoint)
                Dim txtIP As String = remoteipendpoint.Address.ToString
                Dim BitDet As BitArray
                BitDet = New BitArray(receiveBytes)
                set_item(System.Text.Encoding.ASCII.GetChars(receiveBytes))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        End Try
    End Sub

    Private Sub set_item(yodaformat As String)
        Dim yoda As New yoda
        Dim point As ArrayList = yoda.ReadYODA(yodaformat)
        If point.Count <> 3 Then
            MsgBox("The number of entries is not allowed.
Correct data format:
!['seriesname','xvalue','yvalue']", MsgBoxStyle.Critical, "Error !")
            Return
        End If
        chart.Invoke(New Action(Function() chart.Series(point(0)).Points.AddXY(CDbl(point(1)), CDbl(point(2)))))
        chart.Invoke(New Action(Sub() If (maxpointstext.Text <> "" AndAlso chart.Series(point(0)).Points.Count >= CInt(maxpointstext.Text) AndAlso CInt(maxpointstext.Text) > 0) Then chart.Series(point(0)).Points.RemoveAt(0)))
        chart.AntiAliasing = DataVisualization.Charting.AntiAliasingStyles.All
    End Sub

    Private Sub DisableToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DisableToolStripMenuItem1.Click
        EnableToolStripMenuItem1.Checked = False
        DisableToolStripMenuItem1.Checked = True
        remoteactive = False
    End Sub

    Private Sub chartui_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If DisableToolStripMenuItem1.Checked = False Then
            receiveudpclient.Close()
            receiveudpclient.Dispose()
            Return
        End If
    End Sub
End Class