<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dataframeform
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dataframeform))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.exportdatalabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.fontlabel = New System.Windows.Forms.ToolStripLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.dtginfotext = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dtgstructtext = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dtg = New System.Windows.Forms.DataGridView()
        Me.infotimer = New System.Windows.Forms.Timer(Me.components)
        Me.fontselector = New System.Windows.Forms.FontDialog()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dtg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.exportdatalabel, Me.ToolStripSeparator1, Me.fontlabel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(507, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'exportdatalabel
        '
        Me.exportdatalabel.Name = "exportdatalabel"
        Me.exportdatalabel.Size = New System.Drawing.Size(67, 22)
        Me.exportdatalabel.Text = "&Export data"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'fontlabel
        '
        Me.fontlabel.Name = "fontlabel"
        Me.fontlabel.Size = New System.Drawing.Size(31, 22)
        Me.fontlabel.Text = "&Font"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.dtginfotext, Me.dtgstructtext})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 479)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(507, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'dtginfotext
        '
        Me.dtginfotext.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.dtginfotext.Name = "dtginfotext"
        Me.dtginfotext.Size = New System.Drawing.Size(60, 17)
        Me.dtginfotext.Text = "Waiting ..."
        '
        'dtgstructtext
        '
        Me.dtgstructtext.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgstructtext.Name = "dtgstructtext"
        Me.dtgstructtext.Size = New System.Drawing.Size(60, 17)
        Me.dtgstructtext.Text = "Waiting ..."
        '
        'dtg
        '
        Me.dtg.AllowUserToAddRows = False
        Me.dtg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtg.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dtg.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtg.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtg.Location = New System.Drawing.Point(0, 25)
        Me.dtg.Name = "dtg"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg.Size = New System.Drawing.Size(507, 454)
        Me.dtg.TabIndex = 2
        '
        'infotimer
        '
        Me.infotimer.Interval = 5000
        '
        'fontselector
        '
        Me.fontselector.Font = New System.Drawing.Font("Consolas", 8.0!)
        '
        'dataframeform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(507, 501)
        Me.Controls.Add(Me.dtg)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "dataframeform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dataframe Form"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dtg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
    Friend WithEvents dtg As Windows.Forms.DataGridView
    Friend WithEvents dtgstructtext As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents infotimer As Windows.Forms.Timer
    Friend WithEvents dtginfotext As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents exportdatalabel As Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents fontlabel As Windows.Forms.ToolStripLabel
    Friend WithEvents fontselector As Windows.Forms.FontDialog
End Class
