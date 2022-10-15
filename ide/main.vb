Imports System.IO
Imports FastColoredTextBoxNS
Imports Telerik.WinControls.UI

Public Class main
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabs.SelectedPage.Visible = False
        check_init()
        range.init()
        import_projects()
        import_files()
    End Sub

    Private Sub import_files()
        Me.waitbar.StartWaiting()
        Me.waitbar.Text = "Launch the avaiable files"
        For index = 0 To proj.fileopenlist.Count - 1
            Dim path As String = proj.fileopenlist(index)
            Dim filename As String = path.Remove(0, path.LastIndexOf("\") + 1)
            If File.GetAttributes(path).HasFlag(FileAttributes.Directory) Then Return
            Dim rdpage As New RadPageViewPage
            rdpage.Title = filename
            rdpage.Text = filename
            rdpage.Tag = path
            If codeopt.is_file_open(path, rdpage) = False Then
                Dim iconkey As String = proj.get_def_icon(filename.Remove(0, filename.LastIndexOf(".") + 1))
                If iconkey <> String.Empty Then
                    rdpage.Image = imagelist.Images(imagelist.Images.IndexOfKey(iconkey))
                End If
                tabs.Pages.Add(rdpage)
                Dim fscode As New FastColoredTextBoxNS.FastColoredTextBox
                codeopt.fscode_customization(fscode, path)
                range.set_extension(fscode)
                fscode.Selection.Start = Place.Empty
                fscode.DoCaretVisible()
                fscode.IsChanged = False
                fscode.ClearUndo()
                rdpage.Controls.Add(fscode)
                AddHandler fscode.TextChanged, AddressOf fscode_textchanged
            End If
            tabs.SelectedPage = rdpage

        Next
        Me.waitbar.StopWaiting()
        waitbar.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
        waitbar.Text = String.Empty
    End Sub

    Private Sub import_projects()
        waitbar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsLine
        waitbar.StartWaiting()
        waitbar.Text = "Loading projects"
        proj.load_project()
        waitbar.StopWaiting()
        waitbar.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
        waitbar.Text = String.Empty
    End Sub

    Private Sub check_init()
        waitbar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsLine
        waitbar.StartWaiting()
        waitbar.Text = "Initialization"
        If chreqinit.requires_initialization() Then
            Dim initstruct As New forminitstruct
            initstruct.ShowDialog()
        End If
        waitbar.StopWaiting()
        waitbar.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
        waitbar.Text = String.Empty
    End Sub

    Private Sub contextaddproject_Click(sender As Object, e As EventArgs) Handles contextaddproject.Click
        If fdaddproject.ShowDialog() = DialogResult.OK Then
            Dim result As String = fdaddproject.FileName
            If result.EndsWith(conrex.PROJECTOPTIONSNAME) = False Then
                MsgBox("The project file must be labra.yoda", MsgBoxStyle.Critical)
                Return
            End If
            proj.import_a_project(result)
        End If
    End Sub

    Private Sub treeproject_NodeMouseDoubleClick(sender As Object, e As Telerik.WinControls.UI.RadTreeViewEventArgs) Handles treeproject.NodeMouseDoubleClick
        If File.GetAttributes(e.Node.Tag).HasFlag(FileAttributes.Directory) Then Return
        Me.waitbar.StartWaiting()
        Me.waitbar.Text = "Preparing the coding environment"
        Dim path As String = e.Node.Tag
        Dim rdpage As New RadPageViewPage
        rdpage.Title = e.Node.Text
        rdpage.Text = e.Node.Text
        rdpage.Tag = path
        If codeopt.is_file_open(path, rdpage) = False Then
            Dim iconkey As String = proj.get_def_icon(e.Node.Text.Remove(0, e.Node.Text.LastIndexOf(".") + 1))
            If iconkey <> String.Empty Then
                rdpage.Image = imagelist.Images(imagelist.Images.IndexOfKey(iconkey))
            End If
            tabs.Pages.Add(rdpage)
            Dim fscode As New FastColoredTextBoxNS.FastColoredTextBox
            codeopt.fscode_customization(fscode, path)
            range.set_extension(fscode)
            fscode.Selection.Start = Place.Empty
            fscode.DoCaretVisible()
            fscode.IsChanged = False
            fscode.ClearUndo()
            rdpage.Controls.Add(fscode)
            AddHandler fscode.TextChanged, AddressOf fscode_textchanged
            proj.check_open_tabs()
        End If
        tabs.SelectedPage = rdpage
        Me.waitbar.StopWaiting()
        waitbar.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
        waitbar.Text = String.Empty
    End Sub
    Private Sub fscode_textchanged(sender As Object, ByVal e As TextChangedEventArgs)
        range.set_extension(e.ChangedRange)
    End Sub

    Private Sub RadMenuItem6_Click(sender As Object, e As EventArgs) Handles RadMenuItem6.Click
        Dim options As New formoptions
        options.ShowDialog()
    End Sub

    Private Sub tabs_ItemDropped(sender As Object, e As RadPageViewItemDroppedEventArgs) Handles tabs.ItemDropped
        proj.check_open_tabs()
    End Sub

    Private Sub tabs_PageRemoved(sender As Object, e As RadPageViewEventArgs) Handles tabs.PageRemoved
        proj.check_open_tabs()
    End Sub

    Private Sub cmdbtnaction_Click(sender As Object, e As EventArgs) Handles cmdbtnaction.Click
        If IsNothing(cmddropprojectlist.SelectedItem) Then
            MsgBox("First, select a project to compile.", MsgBoxStyle.Critical, "Compile Error")
            Return
        End If
        gen.execute(cmddropprojectlist.SelectedItem.Value)
    End Sub

    Private Sub cmdbtnbuild_Click(sender As Object, e As EventArgs) Handles cmdbtnbuild.Click
        If IsNothing(cmddropprojectlist.SelectedItem) Then
            MsgBox("First, select a project to compile.", MsgBoxStyle.Critical, "Compile Error")
            Return
        End If
        gen.execute(cmddropprojectlist.SelectedItem.Value, True)
    End Sub
End Class
