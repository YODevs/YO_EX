Public Class chartui
    Private Sub EditViewPointsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditViewPointsToolStripMenuItem.Click
        Dim formpoint As New editpoint
        formpoint.ShowDialog()
    End Sub
End Class