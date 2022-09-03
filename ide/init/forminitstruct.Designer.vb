<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class forminitstruct
    Inherits Telerik.WinControls.UI.RadForm

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
        Me.Office2019DarkTheme1 = New Telerik.WinControls.Themes.Office2019DarkTheme()
        Me.progressbar = New Telerik.WinControls.UI.RadProgressBar()
        Me.labelprogressinfo = New Telerik.WinControls.UI.RadLabel()
        Me.timer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.progressbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.labelprogressinfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'progressbar
        '
        Me.progressbar.Location = New System.Drawing.Point(24, 26)
        Me.progressbar.Name = "progressbar"
        Me.progressbar.SeparatorColor1 = System.Drawing.Color.Black
        Me.progressbar.SeparatorColor3 = System.Drawing.Color.DarkRed
        Me.progressbar.Size = New System.Drawing.Size(389, 24)
        Me.progressbar.TabIndex = 0
        Me.progressbar.Text = "Initialization . . ."
        Me.progressbar.ThemeName = "Office2019Dark"
        '
        'labelprogressinfo
        '
        Me.labelprogressinfo.AutoSize = False
        Me.labelprogressinfo.Location = New System.Drawing.Point(24, 61)
        Me.labelprogressinfo.Name = "labelprogressinfo"
        Me.labelprogressinfo.Size = New System.Drawing.Size(389, 19)
        Me.labelprogressinfo.TabIndex = 1
        Me.labelprogressinfo.Text = "Initialization"
        Me.labelprogressinfo.ThemeName = "Office2019Dark"
        '
        'timer
        '
        Me.timer.Enabled = True
        Me.timer.Interval = 20
        '
        'forminitstruct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 119)
        Me.Controls.Add(Me.labelprogressinfo)
        Me.Controls.Add(Me.progressbar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "forminitstruct"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Initialization"
        Me.ThemeName = "Office2019Dark"
        Me.TopMost = True
        CType(Me.progressbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.labelprogressinfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Office2019DarkTheme1 As Telerik.WinControls.Themes.Office2019DarkTheme
    Friend WithEvents progressbar As Telerik.WinControls.UI.RadProgressBar
    Friend WithEvents labelprogressinfo As Telerik.WinControls.UI.RadLabel
    Friend WithEvents timer As Timer
End Class

