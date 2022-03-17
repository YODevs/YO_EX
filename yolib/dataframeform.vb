Public Class dataframeform
    Public typeofstruct As String
    Private Sub infotimer_Tick(sender As Object, e As EventArgs) Handles infotimer.Tick
        dtginfotext.Text = String.Format("{0} Cols , {1} Rows ", dtg.Columns.Count, dtg.Rows.Count)
        dtgstructtext.Text = String.Format("Type of structure : {0}", typeofstruct)
    End Sub

    Private Sub dataframeform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        infotimer_Tick(Nothing, Nothing)
    End Sub
End Class