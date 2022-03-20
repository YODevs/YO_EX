Public Class dataframeform
    Public typeofstruct As String
    Private Sub infotimer_Tick(sender As Object, e As EventArgs) Handles infotimer.Tick
        dtginfotext.Text = String.Format("{0} Cols , {1} Rows ", dtg.Columns.Count, dtg.Rows.Count)
        dtgstructtext.Text = String.Format("Type of structure : {0}", typeofstruct)
    End Sub

    Private Sub dataframeform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        infotimer_Tick(Nothing, Nothing)
    End Sub

    Private Sub fontlabel_Click(sender As Object, e As EventArgs) Handles fontlabel.Click
        Dim dialogresult = fontselector.ShowDialog()
        If dialogresult = Windows.Forms.DialogResult.OK OrElse dialogresult = Windows.Forms.DialogResult.Yes Then
            dtg.DefaultCellStyle.Font = fontselector.Font
        End If
    End Sub
End Class