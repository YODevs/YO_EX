Public Class chartui
    Dim palletes As map
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
End Class