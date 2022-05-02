<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dddoptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rotation = New System.Windows.Forms.NumericUpDown()
        Me.depth = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gapdepth = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.perspective = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.wallwidth = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.inclination = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        CType(Me.rotation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.depth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gapdepth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.perspective, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wallwidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.inclination, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Rotation"
        '
        'rotation
        '
        Me.rotation.Location = New System.Drawing.Point(103, 14)
        Me.rotation.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.rotation.Minimum = New Decimal(New Integer() {180, 0, 0, -2147483648})
        Me.rotation.Name = "rotation"
        Me.rotation.Size = New System.Drawing.Size(65, 20)
        Me.rotation.TabIndex = 1
        '
        'depth
        '
        Me.depth.Location = New System.Drawing.Point(103, 40)
        Me.depth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.depth.Name = "depth"
        Me.depth.Size = New System.Drawing.Size(65, 20)
        Me.depth.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Point Depth"
        '
        'gapdepth
        '
        Me.gapdepth.Location = New System.Drawing.Point(103, 66)
        Me.gapdepth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.gapdepth.Name = "gapdepth"
        Me.gapdepth.Size = New System.Drawing.Size(65, 20)
        Me.gapdepth.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Point Gap Depth"
        '
        'perspective
        '
        Me.perspective.Location = New System.Drawing.Point(103, 92)
        Me.perspective.Name = "perspective"
        Me.perspective.Size = New System.Drawing.Size(65, 20)
        Me.perspective.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Perspective "
        '
        'wallwidth
        '
        Me.wallwidth.Location = New System.Drawing.Point(103, 118)
        Me.wallwidth.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.wallwidth.Name = "wallwidth"
        Me.wallwidth.Size = New System.Drawing.Size(65, 20)
        Me.wallwidth.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Wall Width"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Inclination."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label7.Location = New System.Drawing.Point(176, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "-180 , 180"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label8.Location = New System.Drawing.Point(176, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "0 , 1000"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label9.Location = New System.Drawing.Point(176, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "0 , 1000"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label10.Location = New System.Drawing.Point(176, 99)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "0 , 100"
        '
        'inclination
        '
        Me.inclination.Location = New System.Drawing.Point(103, 144)
        Me.inclination.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.inclination.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.inclination.Name = "inclination"
        Me.inclination.Size = New System.Drawing.Size(65, 20)
        Me.inclination.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label11.Location = New System.Drawing.Point(176, 125)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "0 , 30"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label12.Location = New System.Drawing.Point(176, 151)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "-90 , 90"
        '
        'dddoptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(243, 181)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.inclination)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.wallwidth)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.perspective)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gapdepth)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.depth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rotation)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dddoptions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "3D Options"
        Me.TopMost = True
        CType(Me.rotation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.depth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gapdepth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.perspective, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wallwidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.inclination, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents rotation As Windows.Forms.NumericUpDown
    Friend WithEvents depth As Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents gapdepth As Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents perspective As Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents wallwidth As Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents inclination As Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
End Class
