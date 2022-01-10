Public Class chart
    Dim chartform As chartui
    Public Sub New()
        chartform = New chartui
    End Sub
    Public Property formtitle() As String
        Get
            Return chartform.Text
        End Get
        Set(ByVal value As String)
            chartform.Text = value
        End Set
    End Property

    Public Sub new_series(name As String)
        chartform.chart.Series.Add(name)
    End Sub

    Public Sub add_point(name As String, xvalue As Integer, yvalue As Integer)
        chartform.chart.Series(name).Points.AddXY(xvalue, yvalue)
    End Sub

    Public Sub show()
        chartform.ShowDialog()
    End Sub
End Class
