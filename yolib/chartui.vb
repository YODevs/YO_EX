Public Class chartui
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
End Class