<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formcodeenv
    Inherits Telerik.WinControls.UI.RadForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formcodeenv))
        Me.Office2019DarkTheme1 = New Telerik.WinControls.Themes.Office2019DarkTheme()
        Me.x = New FastColoredTextBoxNS.FastColoredTextBox()
        CType(Me.x, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'x
        '
        Me.x.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.x.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;=]+);" & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*(case|default)\s*[^:]*" &
    "(?<range>:)\s*(?<range>[^;]+);" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.x.AutoScrollMinSize = New System.Drawing.Size(909, 6289)
        Me.x.BackBrush = Nothing
        Me.x.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.x.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.x.CharHeight = 19
        Me.x.CharWidth = 8
        Me.x.CurrentLineColor = System.Drawing.Color.Gainsboro
        Me.x.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.x.DefaultMarkerSize = 8
        Me.x.DelayedEventsInterval = 20
        Me.x.DelayedTextChangedInterval = 20
        Me.x.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.x.Dock = System.Windows.Forms.DockStyle.Fill
        Me.x.Font = New System.Drawing.Font("Consolas", 10.3!)
        Me.x.IndentBackColor = System.Drawing.Color.Transparent
        Me.x.IsReplaceMode = False
        Me.x.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.x.LeftBracket2 = Global.Microsoft.VisualBasic.ChrW(123)
        Me.x.LeftPadding = 10
        Me.x.LineInterval = 3
        Me.x.Location = New System.Drawing.Point(0, 0)
        Me.x.Name = "x"
        Me.x.Paddings = New System.Windows.Forms.Padding(0)
        Me.x.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.x.RightBracket2 = Global.Microsoft.VisualBasic.ChrW(125)
        Me.x.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.x.ServiceColors = CType(resources.GetObject("x.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.x.ServiceLinesColor = System.Drawing.Color.Transparent
        Me.x.ShowCaretWhenInactive = True
        Me.x.ShowFoldingLines = True
        Me.x.Size = New System.Drawing.Size(971, 683)
        Me.x.TabIndex = 3
        Me.x.Text = resources.GetString("x.Text")
        Me.x.VirtualSpace = True
        Me.x.Zoom = 100
        '
        'formcodeenv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 683)
        Me.Controls.Add(Me.x)
        Me.Name = "formcodeenv"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Code Env"
        Me.ThemeName = "Office2019Dark"
        CType(Me.x, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Office2019DarkTheme1 As Telerik.WinControls.Themes.Office2019DarkTheme
    Friend WithEvents x As FastColoredTextBoxNS.FastColoredTextBox
End Class

