Imports System.Text

Public Class dataframeform
    Public typeofstruct As String
    Private Sub infotimer_Tick(sender As Object, e As EventArgs) Handles infotimer.Tick
        dtginfotext.Text = String.Format("{0} Cols , {1} Rows ", dtg.Columns.Count, dtg.Rows.Count)
        dtgstructtext.Text = String.Format("Type of structure : {0}", typeofstruct)
    End Sub

    Private Sub dataframeform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        infotimer_Tick(Nothing, Nothing)
    End Sub


    Private Sub exportdatalabel_Click(sender As Object, e As EventArgs) Handles exportdatalabel.Click
        Dim sb As New StringBuilder
        Dim columnscount As Integer = dtg.Columns.Count - 1
        Dim rowscount As Integer = dtg.Rows.Count - 1

        For index = 0 To dtg.Columns.Count - 1
            sb.Append(dtg.Columns(index).HeaderText)
            If index < dtg.Columns.Count - 1 Then
                sb.Append(",")
            End If
        Next
        sb.AppendLine()
        For index = 0 To rowscount
            For i2 = 0 To columnscount
                Dim getitem As String = dtg.Item(i2, index).Value
                If getitem.Contains(",") Then
                    getitem = String.Format("""{0}""", getitem)
                End If
                sb.Append(getitem)
                If i2 <> columnscount Then
                    sb.Append(",")
                End If
            Next
            sb.AppendLine()
        Next

        IO.File.WriteAllText(environment.appdir & "\output.csv", sb.ToString)
        MsgBox("Csv output generated successfully.
Storage location:" & environment.appdir & "\output.csv", MsgBoxStyle.Information)
    End Sub

    Private Sub RTLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RTLToolStripMenuItem.Click
        dtg.RightToLeft = Windows.Forms.RightToLeft.Yes
    End Sub

    Private Sub LTRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LTRToolStripMenuItem.Click
        dtg.RightToLeft = Windows.Forms.RightToLeft.No
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        Dim dialogresult = fontselector.ShowDialog()
        If dialogresult = Windows.Forms.DialogResult.OK OrElse dialogresult = Windows.Forms.DialogResult.Yes Then
            dtg.DefaultCellStyle.Font = fontselector.Font
        End If
    End Sub
End Class