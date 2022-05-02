
Imports System.Windows.Forms

Public Class dddoptions
    Dim formid As Integer = -1
    Dim chart As Windows.Forms.DataVisualization.Charting.Chart
    Private Sub dddoptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        rotation.Value = chart.ChartAreas(0).Area3DStyle.Rotation
        gapdepth.Value = chart.ChartAreas(0).Area3DStyle.PointGapDepth
        depth.Value = chart.ChartAreas(0).Area3DStyle.PointDepth
        perspective.Value = chart.ChartAreas(0).Area3DStyle.Perspective
        inclination.value = chart.ChartAreas(0).Area3DStyle.Inclination
        wallwidth.value = chart.ChartAreas(0).Area3DStyle.WallWidth
    End Sub

    Private Sub rotation_ValueChanged(sender As Object, e As EventArgs) Handles rotation.ValueChanged
        chart.ChartAreas(0).Area3DStyle.Rotation = rotation.Value
    End Sub

    Private Sub gapdepth_ValueChanged(sender As Object, e As EventArgs) Handles gapdepth.ValueChanged
        chart.ChartAreas(0).Area3DStyle.PointGapDepth = gapdepth.Value
    End Sub

    Private Sub depth_ValueChanged(sender As Object, e As EventArgs) Handles depth.ValueChanged
        chart.ChartAreas(0).Area3DStyle.PointDepth = depth.Value
    End Sub

    Private Sub perspective_ValueChanged(sender As Object, e As EventArgs) Handles perspective.ValueChanged
        chart.ChartAreas(0).Area3DStyle.Perspective = perspective.Value
    End Sub

    Private Sub wallwidth_ValueChanged(sender As Object, e As EventArgs) Handles wallwidth.ValueChanged
        chart.ChartAreas(0).Area3DStyle.WallWidth = wallwidth.Value
    End Sub

    Private Sub inclination_ValueChanged(sender As Object, e As EventArgs) Handles inclination.ValueChanged
        chart.ChartAreas(0).Area3DStyle.Inclination = inclination.Value
    End Sub
End Class