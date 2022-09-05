<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fromoptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fromoptions))
        Me.Office2019DarkTheme1 = New Telerik.WinControls.Themes.Office2019DarkTheme()
        Me.tabs = New Telerik.WinControls.UI.RadPageView()
        Me.textension = New Telerik.WinControls.UI.RadPageViewPage()
        Me.tab2 = New Telerik.WinControls.UI.RadPageView()
        Me.tkeywords = New Telerik.WinControls.UI.RadPageViewPage()
        Me.x = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.tdatatype = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        Me.rdatatypes = New Telerik.WinControls.UI.RadRichTextEditor()
        Me.toperators = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton3 = New Telerik.WinControls.UI.RadButton()
        Me.roperators = New Telerik.WinControls.UI.RadRichTextEditor()
        Me.tconstant = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton4 = New Telerik.WinControls.UI.RadButton()
        Me.rconstant = New Telerik.WinControls.UI.RadRichTextEditor()
        Me.RadPageViewPage1 = New Telerik.WinControls.UI.RadPageViewPage()
        CType(Me.tabs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabs.SuspendLayout()
        Me.textension.SuspendLayout()
        CType(Me.tab2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab2.SuspendLayout()
        Me.tkeywords.SuspendLayout()
        CType(Me.x, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tdatatype.SuspendLayout()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdatatypes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toperators.SuspendLayout()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.roperators, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tconstant.SuspendLayout()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rconstant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabs
        '
        Me.tabs.Controls.Add(Me.textension)
        Me.tabs.Controls.Add(Me.RadPageViewPage1)
        Me.tabs.DefaultPage = Me.textension
        Me.tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs.Location = New System.Drawing.Point(0, 0)
        Me.tabs.Margin = New System.Windows.Forms.Padding(0)
        Me.tabs.Name = "tabs"
        Me.tabs.SelectedPage = Me.textension
        Me.tabs.Size = New System.Drawing.Size(827, 527)
        Me.tabs.TabIndex = 0
        Me.tabs.ThemeName = "Office2019Dark"
        Me.tabs.ViewMode = Telerik.WinControls.UI.PageViewMode.NavigationView
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewNavigationViewElement).HeaderHeight = 35
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewNavigationViewElement).ExpandedPaneWidth = 131
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewNavigationViewElement).ExpandedModeThresholdWidth = 1000
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewNavigationViewElement).HierarchyIndent = 0
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewNavigationViewElement).ItemExpandCollapseMode = Telerik.WinControls.UI.NavigationViewItemExpandCollapseMode.OnItemClick
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewNavigationViewElement).ItemDragMode = Telerik.WinControls.UI.PageViewItemDragMode.Preview
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewNavigationViewElement).ItemSpacing = 0
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewNavigationViewElement).ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewNavigationViewElement).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal
        '
        'textension
        '
        Me.textension.Controls.Add(Me.tab2)
        Me.textension.Description = Nothing
        Me.textension.ItemSize = New System.Drawing.SizeF(124.0!, 29.0!)
        Me.textension.Location = New System.Drawing.Point(133, 37)
        Me.textension.Name = "textension"
        Me.textension.Size = New System.Drawing.Size(692, 488)
        Me.textension.Text = "Extension"
        Me.textension.Title = "Extension"
        '
        'tab2
        '
        Me.tab2.Controls.Add(Me.tkeywords)
        Me.tab2.Controls.Add(Me.tdatatype)
        Me.tab2.Controls.Add(Me.toperators)
        Me.tab2.Controls.Add(Me.tconstant)
        Me.tab2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab2.Location = New System.Drawing.Point(0, 0)
        Me.tab2.Name = "tab2"
        Me.tab2.SelectedPage = Me.tkeywords
        Me.tab2.Size = New System.Drawing.Size(692, 488)
        Me.tab2.TabIndex = 0
        Me.tab2.ThemeName = "Office2019Dark"
        CType(Me.tab2.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ShowItemPinButton = False
        '
        'tkeywords
        '
        Me.tkeywords.Controls.Add(Me.x)
        Me.tkeywords.Controls.Add(Me.RadLabel1)
        Me.tkeywords.Controls.Add(Me.RadButton1)
        Me.tkeywords.ItemSize = New System.Drawing.SizeF(61.0!, 25.0!)
        Me.tkeywords.Location = New System.Drawing.Point(6, 32)
        Me.tkeywords.Name = "tkeywords"
        Me.tkeywords.Size = New System.Drawing.Size(680, 450)
        Me.tkeywords.Text = "Keywords"
        '
        'x
        '
        Me.x.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.x.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;=]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*(case|default)\s*[^:" &
    "]*(?<range>:)\s*(?<range>[^;]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.x.AutoScrollMinSize = New System.Drawing.Size(37, 19)
        Me.x.BackBrush = Nothing
        Me.x.BackColor = System.Drawing.Color.Transparent
        Me.x.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.x.CharHeight = 19
        Me.x.CharWidth = 8
        Me.x.CurrentLineColor = System.Drawing.Color.Gainsboro
        Me.x.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.x.DelayedEventsInterval = 20
        Me.x.DelayedTextChangedInterval = 20
        Me.x.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.x.Font = New System.Drawing.Font("Consolas", 10.3!)
        Me.x.IndentBackColor = System.Drawing.Color.Transparent
        Me.x.IsReplaceMode = False
        Me.x.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.x.LeftBracket2 = Global.Microsoft.VisualBasic.ChrW(123)
        Me.x.LeftPadding = 10
        Me.x.LineInterval = 3
        Me.x.Location = New System.Drawing.Point(10, 16)
        Me.x.Name = "x"
        Me.x.Paddings = New System.Windows.Forms.Padding(0)
        Me.x.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.x.RightBracket2 = Global.Microsoft.VisualBasic.ChrW(125)
        Me.x.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.x.ServiceColors = CType(resources.GetObject("x.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.x.ServiceLinesColor = System.Drawing.Color.Transparent
        Me.x.ShowCaretWhenInactive = True
        Me.x.ShowFoldingLines = True
        Me.x.Size = New System.Drawing.Size(657, 365)
        Me.x.TabIndex = 5
        Me.x.VirtualSpace = True
        Me.x.Zoom = 100
        '
        'RadLabel1
        '
        Me.RadLabel1.AutoSize = False
        Me.RadLabel1.Location = New System.Drawing.Point(19, 411)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(373, 28)
        Me.RadLabel1.TabIndex = 4
        Me.RadLabel1.Text = "<html>To display the changes, restart <strong>VisualYO</strong> after saving the " &
    "data.</html>"
        Me.RadLabel1.ThemeName = "Office2019Dark"
        '
        'RadButton1
        '
        Me.RadButton1.Location = New System.Drawing.Point(577, 416)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(88, 24)
        Me.RadButton1.TabIndex = 2
        Me.RadButton1.Text = "Save Data"
        Me.RadButton1.ThemeName = "Office2019Dark"
        '
        'tdatatype
        '
        Me.tdatatype.Controls.Add(Me.RadLabel2)
        Me.tdatatype.Controls.Add(Me.RadButton2)
        Me.tdatatype.Controls.Add(Me.rdatatypes)
        Me.tdatatype.ItemSize = New System.Drawing.SizeF(65.0!, 25.0!)
        Me.tdatatype.Location = New System.Drawing.Point(6, 32)
        Me.tdatatype.Name = "tdatatype"
        Me.tdatatype.Size = New System.Drawing.Size(680, 450)
        Me.tdatatype.Text = "DataTypes"
        '
        'RadLabel2
        '
        Me.RadLabel2.AutoSize = False
        Me.RadLabel2.Location = New System.Drawing.Point(15, 414)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(373, 28)
        Me.RadLabel2.TabIndex = 7
        Me.RadLabel2.Text = "<html>To display the changes, restart <strong>VisualYO</strong> after saving the " &
    "data.</html>"
        Me.RadLabel2.ThemeName = "Office2019Dark"
        '
        'RadButton2
        '
        Me.RadButton2.Location = New System.Drawing.Point(578, 417)
        Me.RadButton2.Name = "RadButton2"
        Me.RadButton2.Size = New System.Drawing.Size(88, 24)
        Me.RadButton2.TabIndex = 6
        Me.RadButton2.Text = "Save Data"
        Me.RadButton2.ThemeName = "Office2019Dark"
        '
        'rdatatypes
        '
        Me.rdatatypes.BorderColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.rdatatypes.ForeColor = System.Drawing.Color.White
        Me.rdatatypes.Location = New System.Drawing.Point(15, 9)
        Me.rdatatypes.Name = "rdatatypes"
        Me.rdatatypes.SelectionFill = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.rdatatypes.SelectionStroke = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.rdatatypes.Size = New System.Drawing.Size(651, 389)
        Me.rdatatypes.TabIndex = 5
        Me.rdatatypes.ThemeName = "Office2019Dark"
        '
        'toperators
        '
        Me.toperators.Controls.Add(Me.RadLabel3)
        Me.toperators.Controls.Add(Me.RadButton3)
        Me.toperators.Controls.Add(Me.roperators)
        Me.toperators.ItemSize = New System.Drawing.SizeF(63.0!, 25.0!)
        Me.toperators.Location = New System.Drawing.Point(6, 32)
        Me.toperators.Name = "toperators"
        Me.toperators.Size = New System.Drawing.Size(680, 450)
        Me.toperators.Text = "Operators"
        '
        'RadLabel3
        '
        Me.RadLabel3.AutoSize = False
        Me.RadLabel3.Location = New System.Drawing.Point(15, 414)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(373, 28)
        Me.RadLabel3.TabIndex = 10
        Me.RadLabel3.Text = "<html>To display the changes, restart <strong>VisualYO</strong> after saving the " &
    "data.</html>"
        Me.RadLabel3.ThemeName = "Office2019Dark"
        '
        'RadButton3
        '
        Me.RadButton3.Location = New System.Drawing.Point(578, 417)
        Me.RadButton3.Name = "RadButton3"
        Me.RadButton3.Size = New System.Drawing.Size(88, 24)
        Me.RadButton3.TabIndex = 9
        Me.RadButton3.Text = "Save Data"
        Me.RadButton3.ThemeName = "Office2019Dark"
        '
        'roperators
        '
        Me.roperators.BorderColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.roperators.Location = New System.Drawing.Point(15, 9)
        Me.roperators.Name = "roperators"
        Me.roperators.SelectionFill = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.roperators.SelectionStroke = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.roperators.Size = New System.Drawing.Size(651, 389)
        Me.roperators.TabIndex = 8
        Me.roperators.ThemeName = "Office2019Dark"
        '
        'tconstant
        '
        Me.tconstant.Controls.Add(Me.RadLabel4)
        Me.tconstant.Controls.Add(Me.RadButton4)
        Me.tconstant.Controls.Add(Me.rconstant)
        Me.tconstant.ItemSize = New System.Drawing.SizeF(57.0!, 25.0!)
        Me.tconstant.Location = New System.Drawing.Point(6, 32)
        Me.tconstant.Name = "tconstant"
        Me.tconstant.Size = New System.Drawing.Size(680, 450)
        Me.tconstant.Text = "Constant"
        '
        'RadLabel4
        '
        Me.RadLabel4.AutoSize = False
        Me.RadLabel4.Location = New System.Drawing.Point(15, 414)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(373, 28)
        Me.RadLabel4.TabIndex = 10
        Me.RadLabel4.Text = "<html>To display the changes, restart <strong>VisualYO</strong> after saving the " &
    "data.</html>"
        Me.RadLabel4.ThemeName = "Office2019Dark"
        '
        'RadButton4
        '
        Me.RadButton4.Location = New System.Drawing.Point(578, 417)
        Me.RadButton4.Name = "RadButton4"
        Me.RadButton4.Size = New System.Drawing.Size(88, 24)
        Me.RadButton4.TabIndex = 9
        Me.RadButton4.Text = "Save Data"
        Me.RadButton4.ThemeName = "Office2019Dark"
        '
        'rconstant
        '
        Me.rconstant.BorderColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.rconstant.Location = New System.Drawing.Point(15, 9)
        Me.rconstant.Name = "rconstant"
        Me.rconstant.SelectionFill = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.rconstant.SelectionStroke = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.rconstant.Size = New System.Drawing.Size(651, 389)
        Me.rconstant.TabIndex = 8
        Me.rconstant.ThemeName = "Office2019Dark"
        '
        'RadPageViewPage1
        '
        Me.RadPageViewPage1.ItemSize = New System.Drawing.SizeF(124.0!, 29.0!)
        Me.RadPageViewPage1.Location = New System.Drawing.Point(133, 37)
        Me.RadPageViewPage1.Name = "RadPageViewPage1"
        Me.RadPageViewPage1.Size = New System.Drawing.Size(698, 516)
        Me.RadPageViewPage1.Text = "RadPageViewPage1"
        '
        'fromoptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 527)
        Me.Controls.Add(Me.tabs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "fromoptions"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Options"
        Me.ThemeName = "Office2019Dark"
        CType(Me.tabs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabs.ResumeLayout(False)
        Me.textension.ResumeLayout(False)
        CType(Me.tab2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab2.ResumeLayout(False)
        Me.tkeywords.ResumeLayout(False)
        CType(Me.x, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tdatatype.ResumeLayout(False)
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdatatypes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toperators.ResumeLayout(False)
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.roperators, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tconstant.ResumeLayout(False)
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rconstant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Office2019DarkTheme1 As Telerik.WinControls.Themes.Office2019DarkTheme
    Friend WithEvents tabs As Telerik.WinControls.UI.RadPageView
    Friend WithEvents textension As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageViewPage1 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents tab2 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents tkeywords As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents tdatatype As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadButton2 As Telerik.WinControls.UI.RadButton
    Friend WithEvents rdatatypes As Telerik.WinControls.UI.RadRichTextEditor
    Friend WithEvents toperators As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadButton3 As Telerik.WinControls.UI.RadButton
    Friend WithEvents roperators As Telerik.WinControls.UI.RadRichTextEditor
    Friend WithEvents tconstant As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadButton4 As Telerik.WinControls.UI.RadButton
    Friend WithEvents rconstant As Telerik.WinControls.UI.RadRichTextEditor
    Friend WithEvents x As FastColoredTextBoxNS.FastColoredTextBox
End Class

