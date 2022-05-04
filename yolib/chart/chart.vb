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

    Public Property axisytitle As String
        Get
            Return chartform.chart.ChartAreas(0).AxisY.Title
        End Get
        Set(ByVal value As String)
            chartform.chart.ChartAreas(0).AxisY.Title = value
        End Set
    End Property

    Public Property axisxtitle As String
        Get
            Return chartform.chart.ChartAreas(0).AxisX.Title
        End Get
        Set(ByVal value As String)
            chartform.chart.ChartAreas(0).AxisX.Title = value
        End Set
    End Property

    Public Property remoteaccess As Boolean
        Get
            Return chartform.remoteactive
        End Get
        Set(value As Boolean)
            chartform.remoteactive = value
        End Set
    End Property

    Public Sub set_remote(port As Integer, maxpoints As Integer)
        chartform.porttextbox.Text = port
        chartform.maxpointstext.Text = maxpoints
    End Sub
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
    Public Sub add_title(titlename As String, value As String)
        add_title(titlename, value, Nothing, Nothing)
    End Sub
    Public Sub add_title(titlename As String, value As String, font As font, colorname As String)
        Dim title As Windows.Forms.DataVisualization.Charting.Title = chartform.chart.Titles.Add(titlename)
        title.Text = value
        title.Alignment = Drawing.ContentAlignment.MiddleCenter
        If IsNothing(font) = False Then
            title.Font = font.font
        End If
        If colorname <> String.Empty Then
            title.ForeColor = Drawing.Color.FromName(colorname)
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
    Public Sub add_point(seriesname As String, xvalues As list, yvalues As list)
        If xvalues.count <> yvalues.count Then
            Throw New Exception("The number of points in the xvalues list is not equal to yvalues.")
        End If
        For index = 0 To xvalues.count - 1
            Dim xvalue, yvalue As Double
            xvalue = CDbl(xvalues.get(index))
            yvalue = CDbl(yvalues.get(index))
            Dim pointid As Integer = chartform.chart.Series(seriesname).Points.AddXY(xvalue, yvalue)
            set_default_setting_point(seriesname, pointid, xvalue, yvalue)
        Next
    End Sub
    Private Sub set_default_setting_point(seriesname As String, pointid As Integer, xvalue As Object, yvalue As Object)
        chartform.chart.Series(seriesname).Points(pointid).MarkerStyle = MarkerStyle.Circle
        chartform.chart.Series(seriesname).Points(pointid).ToolTip = String.Format("{3}{1}X:{0}{1}Y:{2}", xvalue, vbCrLf, yvalue, seriesname)
    End Sub

    Private Sub set_default_setting_series(seriesname As String)
        chartform.chart.Series(seriesname).BorderWidth = 2
    End Sub

    Public Sub set_axis_label(seriesname As String, index As Integer, value As String)
        chartform.chart.Series(seriesname).Points(index).AxisLabel = value
    End Sub
    Public Sub set_axis_label(seriesname As String, values As list)
        Dim gcount As Integer = chartform.chart.Series(seriesname).Points.Count - 1
        If gcount < values.count - 1 Then
            Throw New Exception("The number of points is more than prescribed.")
        End If
        For index = 0 To values.count - 1
            chartform.chart.Series(seriesname).Points(index).AxisLabel = values.get(index)
        Next
    End Sub
    Public Sub set_axis_label(index As Integer, value As String)
        chartform.chart.Series(0).Points(index).AxisLabel = value
    End Sub
    Public Sub show()
        chartform.ShowDialog()
    End Sub
    Public Sub save(path As String)
        chartform.chart.SaveImage(path, ChartImageFormat.Png)
    End Sub
End Class
