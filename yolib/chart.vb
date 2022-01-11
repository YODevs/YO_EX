Imports System.Windows.Forms.DataVisualization.Charting

Public Class chart
    Dim chartform As chartui
    Dim charttypes As map
    Public Sub New()
        chartform = New chartui
        charttypes = New map
        Dim ccharttype As SeriesChartType
        Dim values As Array = [Enum].GetValues(ccharttype.GetType)
        Dim keys As String() = [Enum].GetNames(ccharttype.GetType)
        For index = 0 To values.Length - 1
            charttypes.add(keys(index).ToLower, values(index))
        Next
    End Sub
    Public Property formtitle() As String
        Get
            Return chartform.Text
        End Get
        Set(ByVal value As String)
            chartform.Text = value
        End Set
    End Property

    Public Property asixytitle As String
        Get
            Return chartform.chart.ChartAreas(0).AxisY.Title
        End Get
        Set(ByVal value As String)
            chartform.chart.ChartAreas(0).AxisY.Title = value
        End Set
    End Property

    Public Property asixxtitle As String
        Get
            Return chartform.chart.ChartAreas(0).AxisX.Title
        End Get
        Set(ByVal value As String)
            chartform.chart.ChartAreas(0).AxisX.Title = value
        End Set
    End Property

    Public Sub new_series(name As String)
        new_series(name, "Area")
    End Sub
    Public Sub new_series(name As String, charttypename As String)
        chartform.chart.Series.Add(name)
        Dim localcharttype As String = charttypes.get(charttypename.ToLower)
        If localcharttype <> String.Empty Then
            chartform.chart.Series(name).ChartType = Convert.ToInt32(localcharttype)
        Else
            Throw New Exception(charttypename & " - The selected chart type could not be found! You can use charts like [Pie,Line,Bar,Area,Bubble,Point,Radar,...].")
        End If
    End Sub

    Public Sub add_point(name As String, xvalue As Integer, yvalue As Integer)
        chartform.chart.Series(name).Points.AddXY(xvalue, yvalue)
    End Sub
    Public Sub add_point(name As String, xvalue As Double, yvalue As Double)
        chartform.chart.Series(name).Points.AddXY(xvalue, yvalue)
    End Sub
    Public Sub add_point(name As String, xvalue As Single, yvalue As Single)
        chartform.chart.Series(name).Points.AddXY(xvalue, yvalue)
    End Sub

    Public Sub show()
        chartform.ShowDialog()
    End Sub
End Class
