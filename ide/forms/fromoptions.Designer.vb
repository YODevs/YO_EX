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
        Me.Office2019DarkTheme1 = New Telerik.WinControls.Themes.Office2019DarkTheme()
        Me.tabs = New Telerik.WinControls.UI.RadPageView()
        Me.keywords = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadPageViewPage1 = New Telerik.WinControls.UI.RadPageViewPage()
        CType(Me.tabs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabs.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabs
        '
        Me.tabs.Controls.Add(Me.keywords)
        Me.tabs.Controls.Add(Me.RadPageViewPage1)
        Me.tabs.DefaultPage = Me.keywords
        Me.tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs.Location = New System.Drawing.Point(0, 0)
        Me.tabs.Margin = New System.Windows.Forms.Padding(0)
        Me.tabs.Name = "tabs"
        Me.tabs.SelectedPage = Me.keywords
        Me.tabs.Size = New System.Drawing.Size(833, 555)
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
        'keywords
        '
        Me.keywords.Description = Nothing
        Me.keywords.ItemSize = New System.Drawing.SizeF(124.0!, 29.0!)
        Me.keywords.Location = New System.Drawing.Point(133, 37)
        Me.keywords.Name = "keywords"
        Me.keywords.Size = New System.Drawing.Size(698, 516)
        Me.keywords.Text = "Keywords"
        Me.keywords.Title = "Keywords"
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
        Me.ClientSize = New System.Drawing.Size(833, 555)
        Me.Controls.Add(Me.tabs)
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
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Office2019DarkTheme1 As Telerik.WinControls.Themes.Office2019DarkTheme
    Friend WithEvents tabs As Telerik.WinControls.UI.RadPageView
    Friend WithEvents keywords As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageViewPage1 As Telerik.WinControls.UI.RadPageViewPage
End Class

