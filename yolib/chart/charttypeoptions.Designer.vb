<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class charttypeoptions
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
        Me.seriescombo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chartcombo = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Series : "
        '
        'seriescombo
        '
        Me.seriescombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.seriescombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.seriescombo.FormattingEnabled = True
        Me.seriescombo.Location = New System.Drawing.Point(83, 12)
        Me.seriescombo.Name = "seriescombo"
        Me.seriescombo.Size = New System.Drawing.Size(175, 21)
        Me.seriescombo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Chart :"
        '
        'chartcombo
        '
        Me.chartcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.chartcombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chartcombo.FormattingEnabled = True
        Me.chartcombo.Location = New System.Drawing.Point(83, 48)
        Me.chartcombo.Name = "chartcombo"
        Me.chartcombo.Size = New System.Drawing.Size(175, 21)
        Me.chartcombo.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(109, 92)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Change"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'charttypeoptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(296, 146)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chartcombo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.seriescombo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "charttypeoptions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Chart Type"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents seriescombo As Windows.Forms.ComboBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents chartcombo As Windows.Forms.ComboBox
    Friend WithEvents Button1 As Windows.Forms.Button
End Class
