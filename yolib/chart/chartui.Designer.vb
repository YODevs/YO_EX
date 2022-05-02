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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(chartui))
        Me.chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveChartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditViewPointsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeChartTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PalleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.palletecombo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DChartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.savefile = New System.Windows.Forms.SaveFileDialog()
        Me.PrintChartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PageSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.chart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
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
        Me.chart.Location = New System.Drawing.Point(0, 24)
        Me.chart.Name = "chart"
        Me.chart.Size = New System.Drawing.Size(644, 397)
        Me.chart.TabIndex = 0
        Me.chart.Text = "My Chart"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(644, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveChartToolStripMenuItem, Me.PrintChartToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'SaveChartToolStripMenuItem
        '
        Me.SaveChartToolStripMenuItem.Name = "SaveChartToolStripMenuItem"
        Me.SaveChartToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveChartToolStripMenuItem.Text = "Save chart"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditViewPointsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'EditViewPointsToolStripMenuItem
        '
        Me.EditViewPointsToolStripMenuItem.Name = "EditViewPointsToolStripMenuItem"
        Me.EditViewPointsToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.EditViewPointsToolStripMenuItem.Text = "Edit/View points"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeChartTypeToolStripMenuItem, Me.PalleteToolStripMenuItem, Me.ToolStripSeparator2, Me.DChartToolStripMenuItem, Me.DOptionsToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'ChangeChartTypeToolStripMenuItem
        '
        Me.ChangeChartTypeToolStripMenuItem.Name = "ChangeChartTypeToolStripMenuItem"
        Me.ChangeChartTypeToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ChangeChartTypeToolStripMenuItem.Text = "Change Chart Type"
        '
        'PalleteToolStripMenuItem
        '
        Me.PalleteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.palletecombo})
        Me.PalleteToolStripMenuItem.Name = "PalleteToolStripMenuItem"
        Me.PalleteToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PalleteToolStripMenuItem.Text = "Pallete"
        '
        'palletecombo
        '
        Me.palletecombo.Name = "palletecombo"
        Me.palletecombo.Size = New System.Drawing.Size(121, 23)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(177, 6)
        '
        'DChartToolStripMenuItem
        '
        Me.DChartToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnableToolStripMenuItem, Me.DisableToolStripMenuItem})
        Me.DChartToolStripMenuItem.Name = "DChartToolStripMenuItem"
        Me.DChartToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DChartToolStripMenuItem.Text = "3D Chart"
        '
        'EnableToolStripMenuItem
        '
        Me.EnableToolStripMenuItem.Name = "EnableToolStripMenuItem"
        Me.EnableToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.EnableToolStripMenuItem.Text = "Enable"
        '
        'DisableToolStripMenuItem
        '
        Me.DisableToolStripMenuItem.Name = "DisableToolStripMenuItem"
        Me.DisableToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.DisableToolStripMenuItem.Text = "Disable"
        '
        'DOptionsToolStripMenuItem
        '
        Me.DOptionsToolStripMenuItem.Name = "DOptionsToolStripMenuItem"
        Me.DOptionsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DOptionsToolStripMenuItem.Text = "3D Options"
        '
        'savefile
        '
        Me.savefile.CheckFileExists = True
        Me.savefile.DefaultExt = "png"
        Me.savefile.Title = "Save Chart"
        '
        'PrintChartToolStripMenuItem
        '
        Me.PrintChartToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PageSetupToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.PrintChartToolStripMenuItem.Name = "PrintChartToolStripMenuItem"
        Me.PrintChartToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PrintChartToolStripMenuItem.Text = "Print Chart"
        '
        'PageSetupToolStripMenuItem
        '
        Me.PageSetupToolStripMenuItem.Name = "PageSetupToolStripMenuItem"
        Me.PageSetupToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PageSetupToolStripMenuItem.Text = "Page Setup"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'chartui
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(644, 421)
        Me.Controls.Add(Me.chart)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "chartui"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "chartui"
        CType(Me.chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveChartToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditViewPointsToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Public WithEvents chart As Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ViewToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DChartToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnableToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisableToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DOptionsToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents savefile As Windows.Forms.SaveFileDialog
    Friend WithEvents ChangeChartTypeToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents PalleteToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents palletecombo As Windows.Forms.ToolStripComboBox
    Friend WithEvents PrintChartToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents PageSetupToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As Windows.Forms.ToolStripMenuItem
End Class
