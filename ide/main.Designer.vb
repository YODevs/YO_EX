<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.VisualStudio2022LightTheme1 = New Telerik.WinControls.Themes.VisualStudio2022LightTheme()
        Me.Office2019DarkTheme1 = New Telerik.WinControls.Themes.Office2019DarkTheme()
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        Me.waitbar = New Telerik.WinControls.UI.RadWaitingBarElement()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.RadMenuItem1 = New Telerik.WinControls.UI.RadMenuItem()
        Me.RadMenuItem2 = New Telerik.WinControls.UI.RadMenuItem()
        Me.RadMenuItem3 = New Telerik.WinControls.UI.RadMenuItem()
        Me.RadMenuItem4 = New Telerik.WinControls.UI.RadMenuItem()
        Me.RadMenuItem5 = New Telerik.WinControls.UI.RadMenuItem()
        Me.RadMenuItem6 = New Telerik.WinControls.UI.RadMenuItem()
        Me.RadMenuItem7 = New Telerik.WinControls.UI.RadMenuItem()
        Me.RadCommandBar1 = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.CommandBarTextBox1 = New Telerik.WinControls.UI.CommandBarTextBox()
        Me.CommandBarStripElement2 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.CommandBarLabel1 = New Telerik.WinControls.UI.CommandBarLabel()
        Me.RadSplitContainer1 = New Telerik.WinControls.UI.RadSplitContainer()
        Me.projectpanel = New Telerik.WinControls.UI.SplitPanel()
        Me.projecttab = New Telerik.WinControls.UI.Docking.RadDock()
        Me.projecttabch = New Telerik.WinControls.UI.Docking.DocumentWindow()
        Me.treeproject = New Telerik.WinControls.UI.RadTreeView()
        Me.imagelist = New System.Windows.Forms.ImageList(Me.components)
        Me.projectlistcontextmenu = New Telerik.WinControls.UI.RadContextMenu(Me.components)
        Me.contextaddproject = New Telerik.WinControls.UI.RadMenuItem()
        Me.contextresetproject = New Telerik.WinControls.UI.RadMenuItem()
        Me.DocumentContainer1 = New Telerik.WinControls.UI.Docking.DocumentContainer()
        Me.DocumentTabStrip1 = New Telerik.WinControls.UI.Docking.DocumentTabStrip()
        Me.SplitPanel2 = New Telerik.WinControls.UI.SplitPanel()
        Me.tabs = New Telerik.WinControls.UI.RadPageView()
        Me.startuptabpage = New Telerik.WinControls.UI.RadPageViewPage()
        Me.viewpanel = New Telerik.WinControls.UI.SplitPanel()
        Me.x = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.DotsSpinnerWaitingBarIndicatorElement1 = New Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement()
        Me.fdaddproject = New System.Windows.Forms.OpenFileDialog()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadSplitContainer1.SuspendLayout()
        CType(Me.projectpanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.projectpanel.SuspendLayout()
        CType(Me.projecttab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.projecttab.SuspendLayout()
        Me.projecttabch.SuspendLayout()
        CType(Me.treeproject, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocumentContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DocumentContainer1.SuspendLayout()
        CType(Me.DocumentTabStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DocumentTabStrip1.SuspendLayout()
        CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel2.SuspendLayout()
        CType(Me.tabs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabs.SuspendLayout()
        CType(Me.viewpanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.x, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.waitbar})
        Me.RadStatusStrip1.Location = New System.Drawing.Point(0, 722)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        Me.RadStatusStrip1.Size = New System.Drawing.Size(1318, 25)
        Me.RadStatusStrip1.TabIndex = 0
        Me.RadStatusStrip1.ThemeName = "Office2019Dark"
        '
        'waitbar
        '
        Me.waitbar.Name = "waitbar"
        '
        '
        '
        Me.waitbar.SeparatorElement.Dash = False
        Me.waitbar.SeparatorElement.ProgressOrientation = Telerik.WinControls.ProgressOrientation.Right
        Me.waitbar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        Me.RadStatusStrip1.SetSpring(Me.waitbar, False)
        Me.waitbar.Text = "Processing ..."
        Me.waitbar.WaitingBarOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.waitbar.WaitingDirection = Telerik.WinControls.ProgressOrientation.Right
        Me.waitbar.WaitingSpeed = 100
        Me.waitbar.WaitingStep = 1
        Me.waitbar.ZIndex = 2
        CType(Me.waitbar.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).ProgressOrientation = Telerik.WinControls.ProgressOrientation.Right
        CType(Me.waitbar.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).Dash = False
        '
        'RadMenu1
        '
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadMenuItem1, Me.RadMenuItem2, Me.RadMenuItem3, Me.RadMenuItem4, Me.RadMenuItem5, Me.RadMenuItem6, Me.RadMenuItem7})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 0)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Size = New System.Drawing.Size(1318, 25)
        Me.RadMenu1.TabIndex = 1
        Me.RadMenu1.ThemeName = "Office2019Dark"
        '
        'RadMenuItem1
        '
        Me.RadMenuItem1.Name = "RadMenuItem1"
        Me.RadMenuItem1.Text = "&File"
        '
        'RadMenuItem2
        '
        Me.RadMenuItem2.Name = "RadMenuItem2"
        Me.RadMenuItem2.Tag = ""
        Me.RadMenuItem2.Text = "&Edit"
        '
        'RadMenuItem3
        '
        Me.RadMenuItem3.Name = "RadMenuItem3"
        Me.RadMenuItem3.Text = ""
        '
        'RadMenuItem4
        '
        Me.RadMenuItem4.Name = "RadMenuItem4"
        Me.RadMenuItem4.Text = "&Project"
        '
        'RadMenuItem5
        '
        Me.RadMenuItem5.Name = "RadMenuItem5"
        Me.RadMenuItem5.Text = "&Build"
        '
        'RadMenuItem6
        '
        Me.RadMenuItem6.Name = "RadMenuItem6"
        Me.RadMenuItem6.Text = "&Options"
        '
        'RadMenuItem7
        '
        Me.RadMenuItem7.Name = "RadMenuItem7"
        Me.RadMenuItem7.Text = "&Help"
        '
        'RadCommandBar1
        '
        Me.RadCommandBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadCommandBar1.Location = New System.Drawing.Point(0, 25)
        Me.RadCommandBar1.Name = "RadCommandBar1"
        Me.RadCommandBar1.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement1})
        Me.RadCommandBar1.Size = New System.Drawing.Size(1318, 30)
        Me.RadCommandBar1.TabIndex = 2
        Me.RadCommandBar1.ThemeName = "Office2019Dark"
        '
        'CommandBarRowElement1
        '
        Me.CommandBarRowElement1.MinSize = New System.Drawing.Size(25, 25)
        Me.CommandBarRowElement1.Name = "CommandBarRowElement1"
        Me.CommandBarRowElement1.Strips.AddRange(New Telerik.WinControls.UI.CommandBarStripElement() {Me.CommandBarStripElement1, Me.CommandBarStripElement2})
        '
        'CommandBarStripElement1
        '
        Me.CommandBarStripElement1.DisplayName = "CommandBarStripElement1"
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.CommandBarTextBox1})
        Me.CommandBarStripElement1.Name = "CommandBarStripElement1"
        '
        'CommandBarTextBox1
        '
        Me.CommandBarTextBox1.DisplayName = "CommandBarTextBox1"
        Me.CommandBarTextBox1.Name = "CommandBarTextBox1"
        Me.CommandBarTextBox1.Text = "CommandBarTextBox1"
        '
        'CommandBarStripElement2
        '
        Me.CommandBarStripElement2.DisplayName = "CommandBarStripElement2"
        Me.CommandBarStripElement2.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.CommandBarLabel1})
        Me.CommandBarStripElement2.Name = "CommandBarStripElement2"
        '
        'CommandBarLabel1
        '
        Me.CommandBarLabel1.DisplayName = "CommandBarLabel1"
        Me.CommandBarLabel1.Name = "CommandBarLabel1"
        Me.CommandBarLabel1.Text = "CommandBarLabel1"
        '
        'RadSplitContainer1
        '
        Me.RadSplitContainer1.Controls.Add(Me.projectpanel)
        Me.RadSplitContainer1.Controls.Add(Me.SplitPanel2)
        Me.RadSplitContainer1.Controls.Add(Me.viewpanel)
        Me.RadSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadSplitContainer1.Location = New System.Drawing.Point(0, 55)
        Me.RadSplitContainer1.Name = "RadSplitContainer1"
        '
        '
        '
        Me.RadSplitContainer1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.RadSplitContainer1.Size = New System.Drawing.Size(1318, 667)
        Me.RadSplitContainer1.SplitterWidth = 8
        Me.RadSplitContainer1.TabIndex = 3
        Me.RadSplitContainer1.TabStop = False
        Me.RadSplitContainer1.ThemeName = "Office2019Dark"
        '
        'projectpanel
        '
        Me.projectpanel.Controls.Add(Me.projecttab)
        Me.projectpanel.Location = New System.Drawing.Point(0, 0)
        Me.projectpanel.Name = "projectpanel"
        '
        '
        '
        Me.projectpanel.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.projectpanel.Size = New System.Drawing.Size(183, 667)
        Me.projectpanel.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(-0.1927803!, 0!)
        Me.projectpanel.SizeInfo.SplitterCorrection = New System.Drawing.Size(-252, 0)
        Me.projectpanel.TabIndex = 0
        Me.projectpanel.TabStop = False
        Me.projectpanel.Text = "projectpanel"
        Me.projectpanel.ThemeName = "Office2019Dark"
        '
        'projecttab
        '
        Me.projecttab.ActiveWindow = Me.projecttabch
        Me.projecttab.Controls.Add(Me.DocumentContainer1)
        Me.projecttab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.projecttab.IsCleanUpTarget = True
        Me.projecttab.Location = New System.Drawing.Point(0, 0)
        Me.projecttab.MainDocumentContainer = Me.DocumentContainer1
        Me.projecttab.Name = "projecttab"
        Me.projecttab.Padding = New System.Windows.Forms.Padding(0)
        '
        '
        '
        Me.projecttab.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.projecttab.Size = New System.Drawing.Size(183, 667)
        Me.projecttab.SplitterWidth = 8
        Me.projecttab.TabIndex = 3
        Me.projecttab.TabStop = False
        Me.projecttab.ThemeName = "Office2019Dark"
        '
        'projecttabch
        '
        Me.projecttabch.Controls.Add(Me.treeproject)
        Me.projecttabch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.projecttabch.Location = New System.Drawing.Point(4, 30)
        Me.projecttabch.Name = "projecttabch"
        Me.projecttabch.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument
        Me.projecttabch.Size = New System.Drawing.Size(175, 633)
        Me.projecttabch.Text = "Project"
        '
        'treeproject
        '
        Me.treeproject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeproject.ImageKey = "(none)"
        Me.treeproject.ImageList = Me.imagelist
        Me.treeproject.ItemHeight = 24
        Me.treeproject.LineColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.treeproject.LineStyle = Telerik.WinControls.UI.TreeLineStyle.Solid
        Me.treeproject.Location = New System.Drawing.Point(0, 0)
        Me.treeproject.Name = "treeproject"
        Me.treeproject.RadContextMenu = Me.projectlistcontextmenu
        Me.treeproject.Size = New System.Drawing.Size(175, 633)
        Me.treeproject.TabIndex = 0
        Me.treeproject.ThemeName = "Office2019Dark"
        '
        'imagelist
        '
        Me.imagelist.ImageStream = CType(resources.GetObject("imagelist.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imagelist.TransparentColor = System.Drawing.Color.Transparent
        Me.imagelist.Images.SetKeyName(0, "folder.png")
        Me.imagelist.Images.SetKeyName(1, "yo.png")
        Me.imagelist.Images.SetKeyName(2, "exe.png")
        '
        'projectlistcontextmenu
        '
        Me.projectlistcontextmenu.Items.AddRange(New Telerik.WinControls.RadItem() {Me.contextaddproject, Me.contextresetproject})
        '
        'contextaddproject
        '
        Me.contextaddproject.Name = "contextaddproject"
        Me.contextaddproject.Text = "Add Project"
        '
        'contextresetproject
        '
        Me.contextresetproject.Name = "contextresetproject"
        Me.contextresetproject.Text = "Reset Projects"
        '
        'DocumentContainer1
        '
        Me.DocumentContainer1.Controls.Add(Me.DocumentTabStrip1)
        Me.DocumentContainer1.Name = "DocumentContainer1"
        '
        '
        '
        Me.DocumentContainer1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.DocumentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill
        Me.DocumentContainer1.SplitterWidth = 8
        Me.DocumentContainer1.ThemeName = "Office2019Dark"
        '
        'DocumentTabStrip1
        '
        Me.DocumentTabStrip1.CanUpdateChildIndex = True
        Me.DocumentTabStrip1.Controls.Add(Me.projecttabch)
        Me.DocumentTabStrip1.Location = New System.Drawing.Point(0, 0)
        Me.DocumentTabStrip1.Name = "DocumentTabStrip1"
        '
        '
        '
        Me.DocumentTabStrip1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.DocumentTabStrip1.SelectedIndex = 0
        Me.DocumentTabStrip1.Size = New System.Drawing.Size(183, 667)
        Me.DocumentTabStrip1.TabIndex = 0
        Me.DocumentTabStrip1.TabStop = False
        Me.DocumentTabStrip1.ThemeName = "Office2019Dark"
        '
        'SplitPanel2
        '
        Me.SplitPanel2.Controls.Add(Me.tabs)
        Me.SplitPanel2.Location = New System.Drawing.Point(191, 0)
        Me.SplitPanel2.Name = "SplitPanel2"
        '
        '
        '
        Me.SplitPanel2.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitPanel2.Size = New System.Drawing.Size(864, 667)
        Me.SplitPanel2.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.3302611!, 0!)
        Me.SplitPanel2.SizeInfo.SplitterCorrection = New System.Drawing.Size(432, 0)
        Me.SplitPanel2.TabIndex = 1
        Me.SplitPanel2.TabStop = False
        Me.SplitPanel2.Text = "SplitPanel2"
        Me.SplitPanel2.ThemeName = "Office2019Dark"
        '
        'tabs
        '
        Me.tabs.Controls.Add(Me.startuptabpage)
        Me.tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs.Location = New System.Drawing.Point(0, 0)
        Me.tabs.Name = "tabs"
        Me.tabs.SelectedPage = Me.startuptabpage
        Me.tabs.Size = New System.Drawing.Size(864, 667)
        Me.tabs.TabIndex = 0
        Me.tabs.ThemeName = "Office2019Dark"
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ShowItemPinButton = True
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Top
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ShowItemCloseButton = True
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ItemDragMode = Telerik.WinControls.UI.PageViewItemDragMode.Preview
        CType(Me.tabs.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal
        '
        'startuptabpage
        '
        Me.startuptabpage.ItemSize = New System.Drawing.SizeF(143.0!, 25.0!)
        Me.startuptabpage.Location = New System.Drawing.Point(6, 32)
        Me.startuptabpage.Name = "startuptabpage"
        Me.startuptabpage.Size = New System.Drawing.Size(852, 629)
        Me.startuptabpage.Text = "Welcome To VSYO"
        '
        'viewpanel
        '
        Me.viewpanel.Location = New System.Drawing.Point(1063, 0)
        Me.viewpanel.Name = "viewpanel"
        '
        '
        '
        Me.viewpanel.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.viewpanel.Size = New System.Drawing.Size(255, 667)
        Me.viewpanel.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(-0.1374808!, 0!)
        Me.viewpanel.SizeInfo.SplitterCorrection = New System.Drawing.Size(-180, 0)
        Me.viewpanel.TabIndex = 2
        Me.viewpanel.TabStop = False
        Me.viewpanel.ThemeName = "Office2019Dark"
        '
        'x
        '
        Me.x.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.x.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;=]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*(case|default)\s*[^:" &
    "]*(?<range>:)\s*(?<range>[^;]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.x.AutoScrollMinSize = New System.Drawing.Size(868, 6289)
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
        Me.x.Dock = System.Windows.Forms.DockStyle.Fill
        Me.x.Font = New System.Drawing.Font("Consolas", 10.3!)
        Me.x.IndentBackColor = System.Drawing.Color.Transparent
        Me.x.IsReplaceMode = False
        Me.x.Language = FastColoredTextBoxNS.Language.CSharp
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
        Me.x.Size = New System.Drawing.Size(852, 629)
        Me.x.TabIndex = 2
        Me.x.Text = resources.GetString("x.Text")
        Me.x.VirtualSpace = True
        Me.x.Zoom = 100
        '
        'DotsSpinnerWaitingBarIndicatorElement1
        '
        Me.DotsSpinnerWaitingBarIndicatorElement1.Name = "DotsSpinnerWaitingBarIndicatorElement1"
        '
        'fdaddproject
        '
        Me.fdaddproject.DefaultExt = "yoda"
        Me.fdaddproject.FileName = "labra.yoda"
        Me.fdaddproject.Title = "Add a Project to Visual YO"
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1318, 747)
        Me.Controls.Add(Me.RadSplitContainer1)
        Me.Controls.Add(Me.RadCommandBar1)
        Me.Controls.Add(Me.RadMenu1)
        Me.Controls.Add(Me.RadStatusStrip1)
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Name = "main"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visual YO"
        Me.ThemeName = "Office2019Dark"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadSplitContainer1.ResumeLayout(False)
        CType(Me.projectpanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.projectpanel.ResumeLayout(False)
        CType(Me.projecttab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.projecttab.ResumeLayout(False)
        Me.projecttabch.ResumeLayout(False)
        CType(Me.treeproject, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocumentContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DocumentContainer1.ResumeLayout(False)
        CType(Me.DocumentTabStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DocumentTabStrip1.ResumeLayout(False)
        CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel2.ResumeLayout(False)
        CType(Me.tabs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabs.ResumeLayout(False)
        CType(Me.viewpanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.x, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents VisualStudio2022LightTheme1 As Telerik.WinControls.Themes.VisualStudio2022LightTheme
    Friend WithEvents Office2019DarkTheme1 As Telerik.WinControls.Themes.Office2019DarkTheme
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents RadCommandBar1 As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents CommandBarTextBox1 As Telerik.WinControls.UI.CommandBarTextBox
    Friend WithEvents CommandBarStripElement2 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents CommandBarLabel1 As Telerik.WinControls.UI.CommandBarLabel
    Friend WithEvents RadSplitContainer1 As Telerik.WinControls.UI.RadSplitContainer
    Friend WithEvents projectpanel As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents SplitPanel2 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents viewpanel As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents CardViewGroupItem1 As Telerik.WinControls.UI.CardViewGroupItem
    Friend WithEvents tabs As Telerik.WinControls.UI.RadPageView
    Friend WithEvents x As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents startuptabpage As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents projecttab As Telerik.WinControls.UI.Docking.RadDock
    Friend WithEvents projecttabch As Telerik.WinControls.UI.Docking.DocumentWindow
    Friend WithEvents treeproject As Telerik.WinControls.UI.RadTreeView
    Friend WithEvents DocumentContainer1 As Telerik.WinControls.UI.Docking.DocumentContainer
    Friend WithEvents DocumentTabStrip1 As Telerik.WinControls.UI.Docking.DocumentTabStrip
    Friend WithEvents RadMenuItem1 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents RadMenuItem2 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents RadMenuItem3 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents RadMenuItem4 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents RadMenuItem5 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents RadMenuItem6 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents RadMenuItem7 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents waitbar As Telerik.WinControls.UI.RadWaitingBarElement
    Friend WithEvents DotsSpinnerWaitingBarIndicatorElement1 As Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement
    Friend WithEvents projectlistcontextmenu As Telerik.WinControls.UI.RadContextMenu
    Friend WithEvents contextaddproject As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents contextresetproject As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents fdaddproject As OpenFileDialog
    Friend WithEvents imagelist As ImageList
End Class

