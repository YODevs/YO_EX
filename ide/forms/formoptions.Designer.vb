<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formoptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formoptions))
        Dim ListViewDataItem1 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--benchmark | [Run] View benchmark and process execution status")
        Dim ListViewDataItem2 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--compile_time | Display project compilation time")
        Dim ListViewDataItem3 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--import_assets | Copy dependencies and assets from the assets folder to the outp" &
        "ut")
        Dim ListViewDataItem4 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--execution_time | [Run]  Measuring the execution time of the called process")
        Dim ListViewDataItem5 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--dev | Enable compiler development mode, which disables the cache unit and gener" &
        "ates IL codes and more")
        Dim ListViewDataItem6 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--no_cache | Disable the use of project caches in the compiler(YOCA)")
        Dim ListViewDataItem7 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--stack_trace | View and track details of compiler problems at runtime")
        Dim ListViewDataItem8 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--disable_warnings | Hide all compiler warnings and notifications")
        Dim ListViewDataItem9 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--disable_assertion | Disabling all assertions during compilation")
        Dim ListViewDataItem10 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--display_token | Display and print tokens while analyzing source code (lexical a" &
        "nalysis)")
        Dim ListViewDataItem11 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--debug | Disable JIT optimization, create PDB file, use sequence points from PDB" &
        "")
        Dim ListViewDataItem12 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--debug_impl | Disable JIT optimization, create PDB file, use implicit sequence p" &
        "oints")
        Dim ListViewDataItem13 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--debug_opt | Enable JIT optimization, create PDB file, use implicit sequence poi" &
        "nts")
        Dim ListViewDataItem14 As Telerik.WinControls.UI.ListViewDataItem = New Telerik.WinControls.UI.ListViewDataItem("--mute_process | Hide all logs and do not show the process when compiling")
        Me.Office2019DarkTheme1 = New Telerik.WinControls.Themes.Office2019DarkTheme()
        Me.tabs = New Telerik.WinControls.UI.RadPageView()
        Me.textension = New Telerik.WinControls.UI.RadPageViewPage()
        Me.tab2 = New Telerik.WinControls.UI.RadPageView()
        Me.tmodifiers = New Telerik.WinControls.UI.RadPageViewPage()
        Me.rlistofmodifiers = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton5 = New Telerik.WinControls.UI.RadButton()
        Me.tkeywords = New Telerik.WinControls.UI.RadPageViewPage()
        Me.rlistofkeywords = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.tdatatype = New Telerik.WinControls.UI.RadPageViewPage()
        Me.rlistofdatatypes = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        Me.toperators = New Telerik.WinControls.UI.RadPageViewPage()
        Me.rlistofoperators = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton3 = New Telerik.WinControls.UI.RadButton()
        Me.tconstant = New Telerik.WinControls.UI.RadPageViewPage()
        Me.rlistofconstant = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton4 = New Telerik.WinControls.UI.RadButton()
        Me.tparameters = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadButton6 = New Telerik.WinControls.UI.RadButton()
        Me.buildparamtext = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.chlistparameters = New Telerik.WinControls.UI.RadCheckedListBox()
        Me.runparamtext = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        CType(Me.tabs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabs.SuspendLayout()
        Me.textension.SuspendLayout()
        CType(Me.tab2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab2.SuspendLayout()
        Me.tmodifiers.SuspendLayout()
        CType(Me.rlistofmodifiers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tkeywords.SuspendLayout()
        CType(Me.rlistofkeywords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tdatatype.SuspendLayout()
        CType(Me.rlistofdatatypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toperators.SuspendLayout()
        CType(Me.rlistofoperators, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tconstant.SuspendLayout()
        CType(Me.rlistofconstant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tparameters.SuspendLayout()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.RadButton6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.buildparamtext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chlistparameters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.runparamtext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabs
        '
        Me.tabs.Controls.Add(Me.textension)
        Me.tabs.Controls.Add(Me.tparameters)
        Me.tabs.DefaultPage = Me.textension
        Me.tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs.Location = New System.Drawing.Point(0, 0)
        Me.tabs.Margin = New System.Windows.Forms.Padding(0)
        Me.tabs.Name = "tabs"
        Me.tabs.SelectedPage = Me.tparameters
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
        Me.textension.ItemSize = New System.Drawing.SizeF(78.0!, 29.0!)
        Me.textension.Location = New System.Drawing.Point(133, 37)
        Me.textension.Name = "textension"
        Me.textension.Size = New System.Drawing.Size(692, 488)
        Me.textension.Text = "Extension"
        Me.textension.Title = "Extension"
        '
        'tab2
        '
        Me.tab2.Controls.Add(Me.tmodifiers)
        Me.tab2.Controls.Add(Me.tkeywords)
        Me.tab2.Controls.Add(Me.tdatatype)
        Me.tab2.Controls.Add(Me.toperators)
        Me.tab2.Controls.Add(Me.tconstant)
        Me.tab2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab2.Location = New System.Drawing.Point(0, 0)
        Me.tab2.Name = "tab2"
        Me.tab2.SelectedPage = Me.tmodifiers
        Me.tab2.Size = New System.Drawing.Size(692, 488)
        Me.tab2.TabIndex = 0
        Me.tab2.ThemeName = "Office2019Dark"
        CType(Me.tab2.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ShowItemPinButton = False
        CType(Me.tab2.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ShowItemCloseButton = False
        '
        'tmodifiers
        '
        Me.tmodifiers.Controls.Add(Me.rlistofmodifiers)
        Me.tmodifiers.Controls.Add(Me.RadLabel5)
        Me.tmodifiers.Controls.Add(Me.RadButton5)
        Me.tmodifiers.ItemSize = New System.Drawing.SizeF(60.0!, 25.0!)
        Me.tmodifiers.Location = New System.Drawing.Point(6, 32)
        Me.tmodifiers.Name = "tmodifiers"
        Me.tmodifiers.Size = New System.Drawing.Size(680, 450)
        Me.tmodifiers.Text = "Modifiers"
        '
        'rlistofmodifiers
        '
        Me.rlistofmodifiers.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.rlistofmodifiers.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;]+);" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rlistofmodifiers.AutoScrollMinSize = New System.Drawing.Size(37, 19)
        Me.rlistofmodifiers.BackBrush = Nothing
        Me.rlistofmodifiers.BackColor = System.Drawing.Color.Transparent
        Me.rlistofmodifiers.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.rlistofmodifiers.CharHeight = 19
        Me.rlistofmodifiers.CharWidth = 8
        Me.rlistofmodifiers.CurrentLineColor = System.Drawing.Color.Gainsboro
        Me.rlistofmodifiers.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.rlistofmodifiers.DefaultMarkerSize = 8
        Me.rlistofmodifiers.DelayedEventsInterval = 20
        Me.rlistofmodifiers.DelayedTextChangedInterval = 20
        Me.rlistofmodifiers.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rlistofmodifiers.Font = New System.Drawing.Font("Consolas", 10.3!)
        Me.rlistofmodifiers.IndentBackColor = System.Drawing.Color.Transparent
        Me.rlistofmodifiers.IsReplaceMode = False
        Me.rlistofmodifiers.Language = FastColoredTextBoxNS.Language.JSON
        Me.rlistofmodifiers.LeftBracket = Global.Microsoft.VisualBasic.ChrW(91)
        Me.rlistofmodifiers.LeftBracket2 = Global.Microsoft.VisualBasic.ChrW(123)
        Me.rlistofmodifiers.LeftPadding = 10
        Me.rlistofmodifiers.LineInterval = 3
        Me.rlistofmodifiers.Location = New System.Drawing.Point(12, 13)
        Me.rlistofmodifiers.Name = "rlistofmodifiers"
        Me.rlistofmodifiers.Paddings = New System.Windows.Forms.Padding(0)
        Me.rlistofmodifiers.RightBracket = Global.Microsoft.VisualBasic.ChrW(93)
        Me.rlistofmodifiers.RightBracket2 = Global.Microsoft.VisualBasic.ChrW(125)
        Me.rlistofmodifiers.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rlistofmodifiers.ServiceColors = CType(resources.GetObject("rlistofmodifiers.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.rlistofmodifiers.ServiceLinesColor = System.Drawing.Color.Transparent
        Me.rlistofmodifiers.ShowCaretWhenInactive = True
        Me.rlistofmodifiers.ShowFoldingLines = True
        Me.rlistofmodifiers.Size = New System.Drawing.Size(657, 365)
        Me.rlistofmodifiers.TabIndex = 11
        Me.rlistofmodifiers.VirtualSpace = True
        Me.rlistofmodifiers.Zoom = 100
        '
        'RadLabel5
        '
        Me.RadLabel5.AutoSize = False
        Me.RadLabel5.Location = New System.Drawing.Point(21, 408)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(373, 28)
        Me.RadLabel5.TabIndex = 10
        Me.RadLabel5.Text = "<html>To display the changes, restart <strong>VisualYO</strong> after saving the " &
    "data.</html>"
        Me.RadLabel5.ThemeName = "Office2019Dark"
        '
        'RadButton5
        '
        Me.RadButton5.Location = New System.Drawing.Point(579, 413)
        Me.RadButton5.Name = "RadButton5"
        Me.RadButton5.Size = New System.Drawing.Size(88, 24)
        Me.RadButton5.TabIndex = 9
        Me.RadButton5.Text = "Save Data"
        Me.RadButton5.ThemeName = "Office2019Dark"
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
        'rlistofkeywords
        '
        Me.rlistofkeywords.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.rlistofkeywords.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;]+);" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rlistofkeywords.AutoScrollMinSize = New System.Drawing.Size(12, 19)
        Me.rlistofkeywords.BackBrush = Nothing
        Me.rlistofkeywords.BackColor = System.Drawing.Color.Transparent
        Me.rlistofkeywords.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.rlistofkeywords.CharHeight = 19
        Me.rlistofkeywords.CharWidth = 8
        Me.rlistofkeywords.CurrentLineColor = System.Drawing.Color.Gainsboro
        Me.rlistofkeywords.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.rlistofkeywords.DefaultMarkerSize = 8
        Me.rlistofkeywords.DelayedEventsInterval = 20
        Me.rlistofkeywords.DelayedTextChangedInterval = 20
        Me.rlistofkeywords.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rlistofkeywords.Font = New System.Drawing.Font("Consolas", 10.3!)
        Me.rlistofkeywords.IndentBackColor = System.Drawing.Color.Transparent
        Me.rlistofkeywords.IsReplaceMode = False
        Me.rlistofkeywords.Language = FastColoredTextBoxNS.Language.JSON
        Me.rlistofkeywords.LeftBracket = Global.Microsoft.VisualBasic.ChrW(91)
        Me.rlistofkeywords.LeftBracket2 = Global.Microsoft.VisualBasic.ChrW(123)
        Me.rlistofkeywords.LeftPadding = 10
        Me.rlistofkeywords.LineInterval = 3
        Me.rlistofkeywords.Location = New System.Drawing.Point(12, 13)
        Me.rlistofkeywords.Name = "rlistofkeywords"
        Me.rlistofkeywords.Paddings = New System.Windows.Forms.Padding(0)
        Me.rlistofkeywords.RightBracket = Global.Microsoft.VisualBasic.ChrW(93)
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
        'rlistofdatatypes
        '
        Me.rlistofdatatypes.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.rlistofdatatypes.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;]+);" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rlistofdatatypes.AutoScrollMinSize = New System.Drawing.Size(12, 19)
        Me.rlistofdatatypes.BackBrush = Nothing
        Me.rlistofdatatypes.BackColor = System.Drawing.Color.Transparent
        Me.rlistofdatatypes.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.rlistofdatatypes.CharHeight = 19
        Me.rlistofdatatypes.CharWidth = 8
        Me.rlistofdatatypes.CurrentLineColor = System.Drawing.Color.Gainsboro
        Me.rlistofdatatypes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.rlistofdatatypes.DefaultMarkerSize = 8
        Me.rlistofdatatypes.DelayedEventsInterval = 20
        Me.rlistofdatatypes.DelayedTextChangedInterval = 20
        Me.rlistofdatatypes.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rlistofdatatypes.Font = New System.Drawing.Font("Consolas", 10.3!)
        Me.rlistofdatatypes.IndentBackColor = System.Drawing.Color.Transparent
        Me.rlistofdatatypes.IsReplaceMode = False
        Me.rlistofdatatypes.Language = FastColoredTextBoxNS.Language.JSON
        Me.rlistofdatatypes.LeftBracket = Global.Microsoft.VisualBasic.ChrW(91)
        Me.rlistofdatatypes.LeftBracket2 = Global.Microsoft.VisualBasic.ChrW(123)
        Me.rlistofdatatypes.LeftPadding = 10
        Me.rlistofdatatypes.LineInterval = 3
        Me.rlistofdatatypes.Location = New System.Drawing.Point(12, 13)
        Me.rlistofdatatypes.Name = "rlistofdatatypes"
        Me.rlistofdatatypes.Paddings = New System.Windows.Forms.Padding(0)
        Me.rlistofdatatypes.RightBracket = Global.Microsoft.VisualBasic.ChrW(93)
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
        'rlistofoperators
        '
        Me.rlistofoperators.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.rlistofoperators.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;=]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*(case|default)\s*[^:" &
    "]*(?<range>:)\s*(?<range>[^;]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rlistofoperators.AutoScrollMinSize = New System.Drawing.Size(12, 19)
        Me.rlistofoperators.BackBrush = Nothing
        Me.rlistofoperators.BackColor = System.Drawing.Color.Transparent
        Me.rlistofoperators.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.rlistofoperators.CharHeight = 19
        Me.rlistofoperators.CharWidth = 8
        Me.rlistofoperators.CurrentLineColor = System.Drawing.Color.Gainsboro
        Me.rlistofoperators.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.rlistofoperators.DefaultMarkerSize = 8
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
        'tconstant
        '
        Me.tconstant.Controls.Add(Me.rlistofconstant)
        Me.tconstant.Controls.Add(Me.RadLabel4)
        Me.tconstant.Controls.Add(Me.RadButton4)
        Me.tconstant.ItemSize = New System.Drawing.SizeF(63.0!, 25.0!)
        Me.tconstant.Location = New System.Drawing.Point(6, 32)
        Me.tconstant.Name = "tconstant"
        Me.tconstant.Size = New System.Drawing.Size(680, 450)
        Me.tconstant.Text = "Constants"
        '
        'rlistofconstant
        '
        Me.rlistofconstant.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.rlistofconstant.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;=]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*(case|default)\s*[^:" &
    "]*(?<range>:)\s*(?<range>[^;]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rlistofconstant.AutoScrollMinSize = New System.Drawing.Size(12, 19)
        Me.rlistofconstant.BackBrush = Nothing
        Me.rlistofconstant.BackColor = System.Drawing.Color.Transparent
        Me.rlistofconstant.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.rlistofconstant.CharHeight = 19
        Me.rlistofconstant.CharWidth = 8
        Me.rlistofconstant.CurrentLineColor = System.Drawing.Color.Gainsboro
        Me.rlistofconstant.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.rlistofconstant.DefaultMarkerSize = 8
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
        'tparameters
        '
        Me.tparameters.Controls.Add(Me.RadGroupBox1)
        Me.tparameters.Controls.Add(Me.chlistparameters)
        Me.tparameters.ItemSize = New System.Drawing.SizeF(78.0!, 29.0!)
        Me.tparameters.Location = New System.Drawing.Point(133, 37)
        Me.tparameters.Name = "tparameters"
        Me.tparameters.Size = New System.Drawing.Size(692, 488)
        Me.tparameters.Text = "Parameters"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.runparamtext)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel7)
        Me.RadGroupBox1.Controls.Add(Me.RadButton6)
        Me.RadGroupBox1.Controls.Add(Me.buildparamtext)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel6)
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(1)
        Me.RadGroupBox1.HeaderText = "Outputs"
        Me.RadGroupBox1.Location = New System.Drawing.Point(7, 20)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(679, 100)
        Me.RadGroupBox1.TabIndex = 3
        Me.RadGroupBox1.Text = "Outputs"
        Me.RadGroupBox1.ThemeName = "Office2019Dark"
        '
        'RadButton6
        '
        Me.RadButton6.Location = New System.Drawing.Point(572, 42)
        Me.RadButton6.Name = "RadButton6"
        Me.RadButton6.Size = New System.Drawing.Size(88, 24)
        Me.RadButton6.TabIndex = 10
        Me.RadButton6.Text = "Save Data"
        Me.RadButton6.ThemeName = "Office2019Dark"
        '
        'buildparamtext
        '
        Me.buildparamtext.Location = New System.Drawing.Point(98, 30)
        Me.buildparamtext.Name = "buildparamtext"
        Me.buildparamtext.NullText = "Ex: --no_cache"
        Me.buildparamtext.Size = New System.Drawing.Size(452, 22)
        Me.buildparamtext.TabIndex = 2
        Me.buildparamtext.ThemeName = "Office2019Dark"
        '
        'RadLabel6
        '
        Me.RadLabel6.Location = New System.Drawing.Point(28, 31)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(63, 19)
        Me.RadLabel6.TabIndex = 1
        Me.RadLabel6.Text = "yoca build"
        Me.RadLabel6.ThemeName = "Office2019Dark"
        '
        'chlistparameters
        '
        Me.chlistparameters.GroupItemSize = New System.Drawing.Size(200, 24)
        ListViewDataItem1.Text = "--benchmark | [Run] View benchmark and process execution status"
        ListViewDataItem2.Text = "--compile_time | Display project compilation time"
        ListViewDataItem3.Text = "--import_assets | Copy dependencies and assets from the assets folder to the outp" &
    "ut"
        ListViewDataItem4.Text = "--execution_time | [Run]  Measuring the execution time of the called process"
        ListViewDataItem5.Text = "--dev | Enable compiler development mode, which disables the cache unit and gener" &
    "ates IL codes and more"
        ListViewDataItem6.Text = "--no_cache | Disable the use of project caches in the compiler(YOCA)"
        ListViewDataItem7.Text = "--stack_trace | View and track details of compiler problems at runtime"
        ListViewDataItem8.Text = "--disable_warnings | Hide all compiler warnings and notifications"
        ListViewDataItem9.Text = "--disable_assertion | Disabling all assertions during compilation"
        ListViewDataItem10.Text = "--display_token | Display and print tokens while analyzing source code (lexical a" &
    "nalysis)"
        ListViewDataItem11.Text = "--debug | Disable JIT optimization, create PDB file, use sequence points from PDB" &
    ""
        ListViewDataItem12.Text = "--debug_impl | Disable JIT optimization, create PDB file, use implicit sequence p" &
    "oints"
        ListViewDataItem13.Text = "--debug_opt | Enable JIT optimization, create PDB file, use implicit sequence poi" &
    "nts"
        ListViewDataItem14.Text = "--mute_process | Hide all logs and do not show the process when compiling"
        Me.chlistparameters.Items.AddRange(New Telerik.WinControls.UI.ListViewDataItem() {ListViewDataItem1, ListViewDataItem2, ListViewDataItem3, ListViewDataItem4, ListViewDataItem5, ListViewDataItem6, ListViewDataItem7, ListViewDataItem8, ListViewDataItem9, ListViewDataItem10, ListViewDataItem11, ListViewDataItem12, ListViewDataItem13, ListViewDataItem14})
        Me.chlistparameters.ItemSize = New System.Drawing.Size(200, 24)
        Me.chlistparameters.Location = New System.Drawing.Point(7, 138)
        Me.chlistparameters.Name = "chlistparameters"
        Me.chlistparameters.Size = New System.Drawing.Size(679, 340)
        Me.chlistparameters.TabIndex = 0
        Me.chlistparameters.ThemeName = "Office2019Dark"
        '
        'runparamtext
        '
        Me.runparamtext.Location = New System.Drawing.Point(98, 58)
        Me.runparamtext.Name = "runparamtext"
        Me.runparamtext.NullText = "Ex: --no_cache"
        Me.runparamtext.Size = New System.Drawing.Size(452, 22)
        Me.runparamtext.TabIndex = 4
        Me.runparamtext.ThemeName = "Office2019Dark"
        '
        'RadLabel7
        '
        Me.RadLabel7.Location = New System.Drawing.Point(28, 59)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(53, 19)
        Me.RadLabel7.TabIndex = 3
        Me.RadLabel7.Text = "yoca run"
        Me.RadLabel7.ThemeName = "Office2019Dark"
        '
        'formoptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 527)
        Me.Controls.Add(Me.tabs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "formoptions"
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
        Me.tmodifiers.ResumeLayout(False)
        CType(Me.rlistofmodifiers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tkeywords.ResumeLayout(False)
        CType(Me.rlistofkeywords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tdatatype.ResumeLayout(False)
        CType(Me.rlistofdatatypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toperators.ResumeLayout(False)
        CType(Me.rlistofoperators, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tconstant.ResumeLayout(False)
        CType(Me.rlistofconstant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tparameters.ResumeLayout(False)
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.RadButton6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.buildparamtext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chlistparameters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.runparamtext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Office2019DarkTheme1 As Telerik.WinControls.Themes.Office2019DarkTheme
    Friend WithEvents tabs As Telerik.WinControls.UI.RadPageView
    Friend WithEvents textension As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents tparameters As Telerik.WinControls.UI.RadPageViewPage
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
    Friend WithEvents tmodifiers As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents rlistofmodifiers As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadButton5 As Telerik.WinControls.UI.RadButton
    Friend WithEvents chlistparameters As Telerik.WinControls.UI.RadCheckedListBox
    Friend WithEvents buildparamtext As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadButton6 As Telerik.WinControls.UI.RadButton
    Friend WithEvents runparamtext As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
End Class

