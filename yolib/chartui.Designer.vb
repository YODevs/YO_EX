<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class chartui
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.chart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chart
        '
        Me.chart.BorderSkin.BackColor = System.Drawing.SystemColors.InactiveBorder
        ChartArea1.Name = "ChartArea1"
        Me.chart.ChartAreas.Add(ChartArea1)
        Me.chart.Cursor = System.Windows.Forms.Cursors.Default
        Me.chart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.chart.Legends.Add(Legend1)
        Me.chart.Location = New System.Drawing.Point(0, 0)
        Me.chart.Name = "chart"
        Me.chart.Size = New System.Drawing.Size(644, 421)
        Me.chart.TabIndex = 0
        Me.chart.Text = "My Chart"
        '
        'chartui
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(644, 421)
        Me.Controls.Add(Me.chart)
        Me.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "chartui"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "chartui"
        CType(Me.chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents chart As Windows.Forms.DataVisualization.Charting.Chart
End Class
