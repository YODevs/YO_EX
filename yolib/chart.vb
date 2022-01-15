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

    Public Property enable3d() As Boolean
        Get
            Return chartform.chart.ChartAreas(0).Area3DStyle.Enable3D
        End Get
        Set(ByVal value As Boolean)
            chartform.chart.ChartAreas(0).Area3DStyle.Enable3D = value
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
        set_default_setting_series(name)
    End Sub
    Public Sub new_series(name As String, charttypename As String)
        chartform.chart.Series.Add(name)
        Dim localcharttype As String = charttypes.get(charttypename.ToLower)
        If localcharttype <> String.Empty Then
            chartform.chart.Series(name).ChartType = Convert.ToInt32(localcharttype)
            set_default_setting_series(name)
        Else
            Throw New Exception(charttypename & " - The selected chart type could not be found! You can use charts like [Pie,Line,Bar,Area,Bubble,Point,Radar,...].")
        End If
    End Sub

    Public Sub add_point(seriesname As String, xvalue As Integer, yvalue As Integer)
        Dim pointid As Integer = chartform.chart.Series(seriesname).Points.AddXY(xvalue, yvalue)
        set_default_setting_point(seriesname, pointid, xvalue, yvalue)
    End Sub
    Public Sub add_point(seriesname As String, xvalue As Double, yvalue As Double)
        Dim pointid As Integer = chartform.chart.Series(seriesname).Points.AddXY(xvalue, yvalue)
        set_default_setting_point(seriesname, pointid, xvalue, yvalue)
    End Sub
    Public Sub add_point(seriesname As String, xvalue As Single, yvalue As Single)
        Dim pointid As Integer = chartform.chart.Series(seriesname).Points.AddXY(xvalue, yvalue)
        set_default_setting_point(seriesname, pointid, xvalue, yvalue)
    End Sub

    Private Sub set_default_setting_point(seriesname As String, pointid As Integer, xvalue As Object, yvalue As Object)
        chartform.chart.Series(seriesname).Points(pointid).MarkerStyle = MarkerStyle.Circle
        chartform.chart.Series(seriesname).Points(pointid).ToolTip = String.Format("{3}{1}X:{0}{1}Y:{2}", xvalue, vbCrLf, yvalue, seriesname)
    End Sub

    Private Sub set_default_setting_series(seriesname As String)
        chartform.chart.Series(seriesname).BorderWidth = 2
    End Sub

    Public Sub set_asix_label(seriesname As String, index As Integer, value As String)
        chartform.chart.Series(seriesname).Points(index).AxisLabel = value
    End Sub
    Public Sub set_asix_label(index As Integer, value As String)
        chartform.chart.Series(0).Points(index).AxisLabel = value
    End Sub
    Public Sub show()
        chartform.ShowDialog()
    End Sub
End Class
