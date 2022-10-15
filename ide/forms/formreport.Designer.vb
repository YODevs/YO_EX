<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formreport
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
        Me.reporttext = New Telerik.WinControls.UI.RadTextBoxControl()
        Me.reptimer = New System.Windows.Forms.Timer(Me.components)
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.progressbar = New Telerik.WinControls.UI.RadProgressBar()
        CType(Me.reporttext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.progressbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'reporttext
        '
        Me.reporttext.Font = New System.Drawing.Font("Consolas", 10.1!)
        Me.reporttext.IsReadOnly = True
        Me.reporttext.Location = New System.Drawing.Point(12, 48)
        Me.reporttext.Multiline = True
        Me.reporttext.Name = "reporttext"
        Me.reporttext.ShowClearButton = True
        Me.reporttext.Size = New System.Drawing.Size(707, 322)
        Me.reporttext.TabIndex = 0
        Me.reporttext.ThemeName = "Office2019Dark"
        '
        'reptimer
        '
        Me.reptimer.Enabled = True
        Me.reptimer.Interval = 10
        '
        'RadButton1
        '
        Me.RadButton1.Location = New System.Drawing.Point(609, 376)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(110, 24)
        Me.RadButton1.TabIndex = 1
        Me.RadButton1.Text = "Close"
        Me.RadButton1.ThemeName = "Office2019Dark"
        '
        'progressbar
        '
        Me.progressbar.Location = New System.Drawing.Point(12, 13)
        Me.progressbar.Name = "progressbar"
        Me.progressbar.Size = New System.Drawing.Size(707, 24)
        Me.progressbar.TabIndex = 2
        Me.progressbar.Text = "Progress Report"
        Me.progressbar.ThemeName = "Office2019Dark"
        CType(Me.progressbar.GetChildAt(0), Telerik.WinControls.UI.RadProgressBarElement).Text = "Progress Report"
        CType(Me.progressbar.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.ProgressIndicatorElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(29, Byte), Integer))
        CType(Me.progressbar.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.ProgressIndicatorElement).Visibility = Telerik.WinControls.ElementVisibility.Collapsed
        CType(Me.progressbar.GetChildAt(0).GetChildAt(1), Telerik.WinControls.UI.UpperProgressIndicatorElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(13, Byte), Integer))
        CType(Me.progressbar.GetChildAt(0).GetChildAt(1), Telerik.WinControls.UI.UpperProgressIndicatorElement).Visibility = Telerik.WinControls.ElementVisibility.Collapsed
        '
        'formreport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 400)
        Me.Controls.Add(Me.progressbar)
        Me.Controls.Add(Me.RadButton1)
        Me.Controls.Add(Me.reporttext)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "formreport"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Progress Report"
        Me.ThemeName = "Office2019Dark"
        CType(Me.reporttext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.progressbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Office2019DarkTheme1 As Telerik.WinControls.Themes.Office2019DarkTheme
    Friend WithEvents reporttext As Telerik.WinControls.UI.RadTextBoxControl
    Friend WithEvents reptimer As Timer
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents progressbar As Telerik.WinControls.UI.RadProgressBar
End Class

