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
        Me.tdatatype = New Telerik.WinControls.UI.RadPageViewPage()
        Me.toperators = New Telerik.WinControls.UI.RadPageViewPage()
        Me.tconstant = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadPageViewPage1 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.rlistofkeywords = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.rlistofdatatypes = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        Me.rlistofoperators = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton3 = New Telerik.WinControls.UI.RadButton()
        Me.rlistofconstant = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton4 = New Telerik.WinControls.UI.RadButton()
        CType(Me.tabs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabs.SuspendLayout()
        Me.textension.SuspendLayout()
        CType(Me.tab2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab2.SuspendLayout()
        Me.tkeywords.SuspendLayout()
        Me.tdatatype.SuspendLayout()
        Me.toperators.SuspendLayout()
        Me.tconstant.SuspendLayout()
        CType(Me.rlistofkeywords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rlistofdatatypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rlistofoperators, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rlistofconstant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton4, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.tab2.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ShowItemCloseButton = False
        '
        'tkeywords
        '
        Me.tkeywords.Controls.Add(Me.rlistofkeywords)
        Me.tkeywords.Controls.Add(Me.RadLabel1)
        Me.tkeywords.Controls.Add(Me.RadButton1)
        Me.tkeywords.ItemSize = New System.Drawing.SizeF(61.0!, 25.0!)
        Me.tkeywords.Location = New System.Drawing.Point(6, 32)
        Me.tkeywords.Name = "tkeywords"
        Me.tkeywords.Size = New System.Drawing.Size(680, 450)
        Me.tkeywords.Text = "Keywords"
        '
        'tdatatype
        '
        Me.tdatatype.Controls.Add(Me.rlistofdatatypes)
        Me.tdatatype.Controls.Add(Me.RadLabel2)
        Me.tdatatype.Controls.Add(Me.RadButton2)
        Me.tdatatype.ItemSize = New System.Drawing.SizeF(65.0!, 25.0!)
        Me.tdatatype.Location = New System.Drawing.Point(6, 32)
        Me.tdatatype.Name = "tdatatype"
        Me.tdatatype.Size = New System.Drawing.Size(680, 450)
        Me.tdatatype.Text = "DataTypes"
        '
        'toperators
        '
        Me.toperators.Controls.Add(Me.rlistofoperators)
        Me.toperators.Controls.Add(Me.RadLabel3)
        Me.toperators.Controls.Add(Me.RadButton3)
        Me.toperators.ItemSize = New System.Drawing.SizeF(63.0!, 25.0!)
        Me.toperators.Location = New System.Drawing.Point(6, 32)
        Me.toperators.Name = "toperators"
        Me.toperators.Size = New System.Drawing.Size(680, 450)
        Me.toperators.Text = "Operators"
        '
        'tconstant
        '
        Me.tconstant.Controls.Add(Me.rlistofconstant)
        Me.tconstant.Controls.Add(Me.RadLabel4)
        Me.tconstant.Controls.Add(Me.RadButton4)
        Me.tconstant.ItemSize = New System.Drawing.SizeF(57.0!, 25.0!)
        Me.tconstant.Location = New System.Drawing.Point(6, 32)
        Me.tconstant.Name = "tconstant"
        Me.tconstant.Size = New System.Drawing.Size(680, 450)
        Me.tconstant.Text = "Constant"
        '
        'RadPageViewPage1
        '
        Me.RadPageViewPage1.ItemSize = New System.Drawing.SizeF(69.0!, 29.0!)
        Me.RadPageViewPage1.Location = New System.Drawing.Point(133, 37)
        Me.RadPageViewPage1.Name = "RadPageViewPage1"
        Me.RadPageViewPage1.Size = New System.Drawing.Size(698, 516)
        Me.RadPageViewPage1.Text = "More ..."
        '
        'rlistofkeywords
        '
        Me.rlistofkeywords.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.rlistofkeywords.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;=]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*(case|default)\s*[^:" &
    "]*(?<range>:)\s*(?<range>[^;]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rlistofkeywords.AutoScrollMinSize = New System.Drawing.Size(37, 19)
        Me.rlistofkeywords.BackBrush = Nothing
        Me.rlistofkeywords.BackColor = System.Drawing.Color.Transparent
        Me.rlistofkeywords.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.rlistofkeywords.CharHeight = 19
        Me.rlistofkeywords.CharWidth = 8
        Me.rlistofkeywords.CurrentLineColor = System.Drawing.Color.Gainsboro
        Me.rlistofkeywords.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.rlistofkeywords.DelayedEventsInterval = 20
        Me.rlistofkeywords.DelayedTextChangedInterval = 20
        Me.rlistofkeywords.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rlistofkeywords.Font = New System.Drawing.Font("Consolas", 10.3!)
        Me.rlistofkeywords.IndentBackColor = System.Drawing.Color.Transparent
        Me.rlistofkeywords.IsReplaceMode = False
        Me.rlistofkeywords.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.rlistofkeywords.LeftBracket2 = Global.Microsoft.VisualBasic.ChrW(123)
        Me.rlistofkeywords.LeftPadding = 10
        Me.rlistofkeywords.LineInterval = 3
        Me.rlistofkeywords.Location = New System.Drawing.Point(12, 13)
        Me.rlistofkeywords.Name = "rlistofkeywords"
        Me.rlistofkeywords.Paddings = New System.Windows.Forms.Padding(0)
        Me.rlistofkeywords.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.rlistofkeywords.RightBracket2 = Global.Microsoft.VisualBasic.ChrW(125)
        Me.rlistofkeywords.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rlistofkeywords.ServiceColors = CType(resources.GetObject("rlistofkeywords.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.rlistofkeywords.ServiceLinesColor = System.Drawing.Color.Transparent
        Me.rlistofkeywords.ShowCaretWhenInactive = True
        Me.rlistofkeywords.ShowFoldingLines = True
        Me.rlistofkeywords.Size = New System.Drawing.Size(657, 365)
        Me.rlistofkeywords.TabIndex = 8
        Me.rlistofkeywords.VirtualSpace = True
        Me.rlistofkeywords.Zoom = 100
        '
        'RadLabel1
        '
        Me.RadLabel1.AutoSize = False
        Me.RadLabel1.Location = New System.Drawing.Point(21, 408)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(373, 28)
        Me.RadLabel1.TabIndex = 7
        Me.RadLabel1.Text = "<html>To display the changes, restart <strong>VisualYO</strong> after saving the " &
    "data.</html>"
        Me.RadLabel1.ThemeName = "Office2019Dark"
        '
        'RadButton1
        '
        Me.RadButton1.Location = New System.Drawing.Point(579, 413)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(88, 24)
        Me.RadButton1.TabIndex = 6
        Me.RadButton1.Text = "Save Data"
        Me.RadButton1.ThemeName = "Office2019Dark"
        '
        'rlistofdatatypes
        '
        Me.rlistofdatatypes.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.rlistofdatatypes.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;=]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*(case|default)\s*[^:" &
    "]*(?<range>:)\s*(?<range>[^;]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rlistofdatatypes.AutoScrollMinSize = New System.Drawing.Size(37, 19)
        Me.rlistofdatatypes.BackBrush = Nothing
        Me.rlistofdatatypes.BackColor = System.Drawing.Color.Transparent
        Me.rlistofdatatypes.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.rlistofdatatypes.CharHeight = 19
        Me.rlistofdatatypes.CharWidth = 8
        Me.rlistofdatatypes.CurrentLineColor = System.Drawing.Color.Gainsboro
        Me.rlistofdatatypes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.rlistofdatatypes.DelayedEventsInterval = 20
        Me.rlistofdatatypes.DelayedTextChangedInterval = 20
        Me.rlistofdatatypes.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rlistofdatatypes.Font = New System.Drawing.Font("Consolas", 10.3!)
        Me.rlistofdatatypes.IndentBackColor = System.Drawing.Color.Transparent
        Me.rlistofdatatypes.IsReplaceMode = False
        Me.rlistofdatatypes.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.rlistofdatatypes.LeftBracket2 = Global.Microsoft.VisualBasic.ChrW(123)
        Me.rlistofdatatypes.LeftPadding = 10
        Me.rlistofdatatypes.LineInterval = 3
        Me.rlistofdatatypes.Location = New System.Drawing.Point(12, 13)
        Me.rlistofdatatypes.Name = "rlistofdatatypes"
        Me.rlistofdatatypes.Paddings = New System.Windows.Forms.Padding(0)
        Me.rlistofdatatypes.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.rlistofdatatypes.RightBracket2 = Global.Microsoft.VisualBasic.ChrW(125)
        Me.rlistofdatatypes.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rlistofdatatypes.ServiceColors = CType(resources.GetObject("rlistofdatatypes.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.rlistofdatatypes.ServiceLinesColor = System.Drawing.Color.Transparent
        Me.rlistofdatatypes.ShowCaretWhenInactive = True
        Me.rlistofdatatypes.ShowFoldingLines = True
        Me.rlistofdatatypes.Size = New System.Drawing.Size(657, 365)
        Me.rlistofdatatypes.TabIndex = 8
        Me.rlistofdatatypes.VirtualSpace = True
        Me.rlistofdatatypes.Zoom = 100
        '
        'RadLabel2
        '
        Me.RadLabel2.AutoSize = False
        Me.RadLabel2.Location = New System.Drawing.Point(21, 408)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(373, 28)
        Me.RadLabel2.TabIndex = 7
        Me.RadLabel2.Text = "<html>To display the changes, restart <strong>VisualYO</strong> after saving the " &
    "data.</html>"
        Me.RadLabel2.ThemeName = "Office2019Dark"
        '
        'RadButton2
        '
        Me.RadButton2.Location = New System.Drawing.Point(581, 414)
        Me.RadButton2.Name = "RadButton2"
        Me.RadButton2.Size = New System.Drawing.Size(88, 24)
        Me.RadButton2.TabIndex = 6
        Me.RadButton2.Text = "Save Data"
        Me.RadButton2.ThemeName = "Office2019Dark"
        '
        'rlistofoperators
        '
        Me.rlistofoperators.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.rlistofoperators.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;=]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*(case|default)\s*[^:" &
    "]*(?<range>:)\s*(?<range>[^;]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rlistofoperators.AutoScrollMinSize = New System.Drawing.Size(37, 19)
        Me.rlistofoperators.BackBrush = Nothing
        Me.rlistofoperators.BackColor = System.Drawing.Color.Transparent
        Me.rlistofoperators.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.rlistofoperators.CharHeight = 19
        Me.rlistofoperators.CharWidth = 8
        Me.rlistofoperators.CurrentLineColor = System.Drawing.Color.Gainsboro
        Me.rlistofoperators.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.rlistofoperators.DelayedEventsInterval = 20
        Me.rlistofoperators.DelayedTextChangedInterval = 20
        Me.rlistofoperators.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rlistofoperators.Font = New System.Drawing.Font("Consolas", 10.3!)
        Me.rlistofoperators.IndentBackColor = System.Drawing.Color.Transparent
        Me.rlistofoperators.IsReplaceMode = False
        Me.rlistofoperators.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.rlistofoperators.LeftBracket2 = Global.Microsoft.VisualBasic.ChrW(123)
        Me.rlistofoperators.LeftPadding = 10
        Me.rlistofoperators.LineInterval = 3
        Me.rlistofoperators.Location = New System.Drawing.Point(12, 13)
        Me.rlistofoperators.Name = "rlistofoperators"
        Me.rlistofoperators.Paddings = New System.Windows.Forms.Padding(0)
        Me.rlistofoperators.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.rlistofoperators.RightBracket2 = Global.Microsoft.VisualBasic.ChrW(125)
        Me.rlistofoperators.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rlistofoperators.ServiceColors = CType(resources.GetObject("rlistofoperators.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.rlistofoperators.ServiceLinesColor = System.Drawing.Color.Transparent
        Me.rlistofoperators.ShowCaretWhenInactive = True
        Me.rlistofoperators.ShowFoldingLines = True
        Me.rlistofoperators.Size = New System.Drawing.Size(657, 365)
        Me.rlistofoperators.TabIndex = 8
        Me.rlistofoperators.VirtualSpace = True
        Me.rlistofoperators.Zoom = 100
        '
        'RadLabel3
        '
        Me.RadLabel3.AutoSize = False
        Me.RadLabel3.Location = New System.Drawing.Point(21, 408)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(373, 28)
        Me.RadLabel3.TabIndex = 7
        Me.RadLabel3.Text = "<html>To display the changes, restart <strong>VisualYO</strong> after saving the " &
    "data.</html>"
        Me.RadLabel3.ThemeName = "Office2019Dark"
        '
        'RadButton3
        '
        Me.RadButton3.Location = New System.Drawing.Point(579, 413)
        Me.RadButton3.Name = "RadButton3"
        Me.RadButton3.Size = New System.Drawing.Size(88, 24)
        Me.RadButton3.TabIndex = 6
        Me.RadButton3.Text = "Save Data"
        Me.RadButton3.ThemeName = "Office2019Dark"
        '
        'rlistofconstant
        '
        Me.rlistofconstant.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.rlistofconstant.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;=]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*(case|default)\s*[^:" &
    "]*(?<range>:)\s*(?<range>[^;]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rlistofconstant.AutoScrollMinSize = New System.Drawing.Size(37, 19)
        Me.rlistofconstant.BackBrush = Nothing
        Me.rlistofconstant.BackColor = System.Drawing.Color.Transparent
        Me.rlistofconstant.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.rlistofconstant.CharHeight = 19
        Me.rlistofconstant.CharWidth = 8
        Me.rlistofconstant.CurrentLineColor = System.Drawing.Color.Gainsboro
        Me.rlistofconstant.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.rlistofconstant.DelayedEventsInterval = 20
        Me.rlistofconstant.DelayedTextChangedInterval = 20
        Me.rlistofconstant.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rlistofconstant.Font = New System.Drawing.Font("Consolas", 10.3!)
        Me.rlistofconstant.IndentBackColor = System.Drawing.Color.Transparent
        Me.rlistofconstant.IsReplaceMode = False
        Me.rlistofconstant.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.rlistofconstant.LeftBracket2 = Global.Microsoft.VisualBasic.ChrW(123)
        Me.rlistofconstant.LeftPadding = 10
        Me.rlistofconstant.LineInterval = 3
        Me.rlistofconstant.Location = New System.Drawing.Point(12, 13)
        Me.rlistofconstant.Name = "rlistofconstant"
        Me.rlistofconstant.Paddings = New System.Windows.Forms.Padding(0)
        Me.rlistofconstant.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.rlistofconstant.RightBracket2 = Global.Microsoft.VisualBasic.ChrW(125)
        Me.rlistofconstant.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rlistofconstant.ServiceColors = CType(resources.GetObject("rlistofconstant.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.rlistofconstant.ServiceLinesColor = System.Drawing.Color.Transparent
        Me.rlistofconstant.ShowCaretWhenInactive = True
        Me.rlistofconstant.ShowFoldingLines = True
        Me.rlistofconstant.Size = New System.Drawing.Size(657, 365)
        Me.rlistofconstant.TabIndex = 8
        Me.rlistofconstant.VirtualSpace = True
        Me.rlistofconstant.Zoom = 100
        '
        'RadLabel4
        '
        Me.RadLabel4.AutoSize = False
        Me.RadLabel4.Location = New System.Drawing.Point(21, 408)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(373, 28)
        Me.RadLabel4.TabIndex = 7
        Me.RadLabel4.Text = "<html>To display the changes, restart <strong>VisualYO</strong> after saving the " &
    "data.</html>"
        Me.RadLabel4.ThemeName = "Office2019Dark"
        '
        'RadButton4
        '
        Me.RadButton4.Location = New System.Drawing.Point(579, 413)
        Me.RadButton4.Name = "RadButton4"
        Me.RadButton4.Size = New System.Drawing.Size(88, 24)
        Me.RadButton4.TabIndex = 6
        Me.RadButton4.Text = "Save Data"
        Me.RadButton4.ThemeName = "Office2019Dark"
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
        Me.tdatatype.ResumeLayout(False)
        Me.toperators.ResumeLayout(False)
        Me.tconstant.ResumeLayout(False)
        CType(Me.rlistofkeywords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rlistofdatatypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rlistofoperators, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rlistofconstant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Office2019DarkTheme1 As Telerik.WinControls.Themes.Office2019DarkTheme
    Friend WithEvents tabs As Telerik.WinControls.UI.RadPageView
    Friend WithEvents textension As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageViewPage1 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents tab2 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents tkeywords As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents tdatatype As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents toperators As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents tconstant As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents rlistofkeywords As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents rlistofdatatypes As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadButton2 As Telerik.WinControls.UI.RadButton
    Friend WithEvents rlistofoperators As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadButton3 As Telerik.WinControls.UI.RadButton
    Friend WithEvents rlistofconstant As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadButton4 As Telerik.WinControls.UI.RadButton
End Class

