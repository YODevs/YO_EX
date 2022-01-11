<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class editpoint
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
        Me.dt = New System.Windows.Forms.DataGridView()
        Me.index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.axislabel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.seriescombo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dt
        '
        Me.dt.AllowUserToAddRows = False
        Me.dt.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dt.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.index, Me.axislabel, Me.xvalue, Me.yvalue})
        Me.dt.Location = New System.Drawing.Point(8, 76)
        Me.dt.Name = "dt"
        Me.dt.Size = New System.Drawing.Size(446, 367)
        Me.dt.TabIndex = 0
        '
        'index
        '
        Me.index.FillWeight = 50.0!
        Me.index.HeaderText = "Index"
        Me.index.Name = "index"
        Me.index.ReadOnly = True
        Me.index.Width = 50
        '
        'axislabel
        '
        Me.axislabel.FillWeight = 150.0!
        Me.axislabel.HeaderText = "Axis Label"
        Me.axislabel.Name = "axislabel"
        Me.axislabel.Width = 150
        '
        'xvalue
        '
        Me.xvalue.HeaderText = "X-Value"
        Me.xvalue.Name = "xvalue"
        '
        'yvalue
        '
        Me.yvalue.HeaderText = "Y-Value"
        Me.yvalue.Name = "yvalue"
        '
        'seriescombo
        '
        Me.seriescombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.seriescombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.seriescombo.FormattingEnabled = True
        Me.seriescombo.Location = New System.Drawing.Point(129, 28)
        Me.seriescombo.Name = "seriescombo"
        Me.seriescombo.Size = New System.Drawing.Size(175, 21)
        Me.seriescombo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(84, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Series : "
        '
        'editpoint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 451)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.seriescombo)
        Me.Controls.Add(Me.dt)
        Me.MaximizeBox = False
        Me.Name = "editpoint"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Points"
        Me.TopMost = True
        CType(Me.dt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dt As Windows.Forms.DataGridView
    Friend WithEvents index As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents axislabel As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xvalue As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yvalue As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents seriescombo As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
End Class
