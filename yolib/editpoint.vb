Imports System.Windows.Forms

Public Class editpoint
    Dim formid As Integer = -1
    Dim chart As Windows.Forms.DataVisualization.Charting.Chart
    Private Sub editpoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For fsindex = 0 To Application.OpenForms.Count - 1
            If Application.OpenForms(fsindex).Name = "chartui" Then
                formid = fsindex
                Exit For
            End If
        Next
        If formid = -1 Then Me.Close()
        chart = Application.OpenForms(formid).Controls(0)
        If chart.Series.Count = -1 Then
            MsgBox("No series specified for the chart! Define it first.", MsgBoxStyle.Critical, "Series Error")
            Me.Close()
        End If
        For fseriesindex = 0 To chart.Series.Count - 1
            seriescombo.Items.Add(chart.Series(fseriesindex).Name)
        Next

    End Sub

    Private Sub seriescombo_SelectedValueChanged(sender As Object, e As EventArgs) Handles seriescombo.SelectedValueChanged
        dt.Rows.Clear()
        For fsindex = 0 To chart.Series(seriescombo.Text).Points.Count - 1
            dt.Rows.Add(New Object() {fsindex, chart.Series(seriescombo.Text).Points(fsindex).AxisLabel, chart.Series(seriescombo.Text).Points(fsindex).XValue, chart.Series(seriescombo.Text).Points(fsindex).YValues(0)})
        Next
    End Sub

    Private Sub dt_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dt.CellValueChanged
        If e.RowIndex = -1 OrElse seriescombo.Text = String.Empty Then
            Return
        End If
        Dim pointid As Integer = dt.Item(0, e.RowIndex).Value
        Select Case e.ColumnIndex
            Case 1
                chart.Series(seriescombo.Text).Points(pointid).AxisLabel = dt.Item(e.ColumnIndex, e.RowIndex).Value
            Case 2
                chart.Series(seriescombo.Text).Points(pointid).XValue = dt.Item(e.ColumnIndex, e.RowIndex).Value
            Case 3
                chart.Series(seriescombo.Text).Points(pointid).YValues = New Double() {Convert.ToDouble(dt.Item(e.ColumnIndex, e.RowIndex).Value)}
        End Select
    End Sub
End Class