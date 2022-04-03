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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.dtginfotext = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dtgstructtext = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dtg = New System.Windows.Forms.DataGridView()
        Me.infotimer = New System.Windows.Forms.Timer(Me.components)
        Me.fontselector = New System.Windows.Forms.FontDialog()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.SheetDirectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RTLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LTRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dtg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.exportdatalabel, Me.ToolStripSeparator1, Me.ToolStripDropDownButton2})
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
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SheetDirectionToolStripMenuItem, Me.FontToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripDropDownButton2.Text = "&Options"
        '
        'SheetDirectionToolStripMenuItem
        '
        Me.SheetDirectionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RTLToolStripMenuItem, Me.LTRToolStripMenuItem})
        Me.SheetDirectionToolStripMenuItem.Name = "SheetDirectionToolStripMenuItem"
        Me.SheetDirectionToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SheetDirectionToolStripMenuItem.Text = "Sheet Direction"
        '
        'RTLToolStripMenuItem
        '
        Me.RTLToolStripMenuItem.Name = "RTLToolStripMenuItem"
        Me.RTLToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RTLToolStripMenuItem.Text = "RTL"
        '
        'LTRToolStripMenuItem
        '
        Me.LTRToolStripMenuItem.Name = "LTRToolStripMenuItem"
        Me.LTRToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LTRToolStripMenuItem.Text = "LTR"
        '
        'FontToolStripMenuItem
        '
        Me.FontToolStripMenuItem.Name = "FontToolStripMenuItem"
        Me.FontToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.FontToolStripMenuItem.Text = "Font"
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
    Friend WithEvents fontselector As Windows.Forms.FontDialog
    Friend WithEvents ToolStripDropDownButton2 As Windows.Forms.ToolStripDropDownButton
    Friend WithEvents SheetDirectionToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents RTLToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents LTRToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton1 As Windows.Forms.ToolStripDropDownButton
    Friend WithEvents FontToolStripMenuItem As Windows.Forms.ToolStripMenuItem
End Class
