Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

Public Class charttypeoptions
    Dim formid As Integer = -1
    Dim chart As Windows.Forms.DataVisualization.Charting.Chart
    Dim charttypes As New map
    Private Sub charttypeoptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        set_chart_type()
    End Sub

    Private Sub set_chart_type()
        Dim ccharttype As SeriesChartType
        Dim values As Array = [Enum].GetValues(ccharttype.GetType)
        Dim keys As String() = [Enum].GetNames(ccharttype.GetType)
        For index = 0 To values.Length - 1
            charttypes.add(keys(index), values(index))
            chartcombo.Items.Add(keys(index))
        Next
    End Sub

    Private Sub seriescombo_TextChanged(sender As Object, e As EventArgs) Handles seriescombo.TextChanged
        Try
            chartcombo.SelectedIndex = charttypes.get(chart.Series(seriescombo.Text).ChartType.ToString())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            chart.Series(seriescombo.Text).ChartType = charttypes.get(chartcombo.SelectedItem)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class