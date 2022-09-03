Imports System.IO
Imports Telerik.WinControls.UI

Public Class main
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabs.SelectedPage.Visible = False
        check_init()
        import_projects()
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
            tabs.Pages.Add(rdpage)
            Dim fscode As New FastColoredTextBoxNS.FastColoredTextBox
            codeopt.fscode_customization(fscode, path)
            rdpage.Controls.Add(fscode)
        End If
        tabs.SelectedPage = rdpage
        Me.waitbar.StopWaiting()
        waitbar.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
        waitbar.Text = String.Empty
    End Sub

    Private Sub RadMenuItem6_Click(sender As Object, e As EventArgs) Handles RadMenuItem6.Click
        Dim options As New fromoptions
        options.ShowDialog()
    End Sub
End Class
