Imports System.IO
Imports Telerik.WinControls.UI

Public Class proj
    Friend Shared projectlist, fileopenlist As ArrayList
    Friend Shared yodaprojectlist As YOLIB.yoda
    Public Shared Sub import_a_project(location As String) '...\labra.yoda
        If File.Exists(location) = False Then
            Return
        End If
        projectlist.Add(location)
        File.WriteAllText(conrex.PROJECTLISTFILE, yodaprojectlist.WriteYODA(projectlist, True))
        load_treeview_of_project(location)
    End Sub

    Friend Shared Sub remove_a_project(path As String)
        Dim projectname As String = String.Empty
        For index = 0 To main.treeproject.Nodes.Count - 1
            If main.treeproject.Nodes(index).Tag = path Then
                projectname = main.treeproject.Nodes(index).Text
                main.treeproject.Nodes(index).Remove()
                Exit For
            End If
        Next

        If projectname = String.Empty Then Return
        remove_project_at_projectlist(projectname)
        close_tabs_of_project(path)
        check_open_tabs()
        remove_a_project_inlist(path)
    End Sub

    Friend Shared Sub remove_project_at_projectlist(projectname As String)
        For index = 0 To main.cmddropprojectlist.Items.Count - 1
            If main.cmddropprojectlist.Items(index).Text = projectname Then
                main.cmddropprojectlist.Items.RemoveAt(index)
                Exit For
            End If
        Next
    End Sub

    Friend Shared Sub close_tabs_of_project(path As String)
        Dim lspage As New YOLIB.list
        For index = 0 To main.tabs.Pages.Count - 1
            Dim pagetag As String = main.tabs.Pages(index).Tag
            If pagetag = String.Empty Then Continue For
            If pagetag.StartsWith(path) Then
                lspage.add(index)
            End If
        Next

        For index = 0 To lspage.count - 1
            main.tabs.Pages.RemoveAt(lspage.get(index))
        Next
    End Sub

    Friend Shared Sub remove_a_project_inlist(path As String)
        For index = 0 To projectlist.Count - 1
            If projectlist(index) = path & "\labra.yoda" Then
                projectlist.RemoveAt(index)
                Exit For
            End If
        Next
        File.WriteAllText(conrex.PROJECTLISTFILE, yodaprojectlist.WriteYODA(projectlist, True))
    End Sub

    Friend Shared Sub load_project()
        yodaprojectlist = New YOLIB.yoda
        fileopenlist = yodaprojectlist.ReadYODA(File.ReadAllText(conrex.FILEOPENLIST))
        projectlist = yodaprojectlist.ReadYODA(File.ReadAllText(conrex.PROJECTLISTFILE))
        For index = 0 To projectlist.Count - 1
            load_treeview_of_project(projectlist(index))
        Next
    End Sub

    Friend Shared Sub load_treeview_of_project(ylocation As String)
        Dim projlocation As String = ylocation.Remove(ylocation.LastIndexOf("\"))
        Dim dirname As String = projlocation.Remove(0, projlocation.LastIndexOf("\") + 1)
        main.cmddropprojectlist.Items.Add(New RadListDataItem(dirname, projlocation))
        main.cmddropprojectlist.SelectedIndex = main.cmddropprojectlist.Items.Count - 1
        get_directories(projlocation)
    End Sub

    Private Shared Sub get_directories(dir As String)
        Dim root As String = dir.Remove(0, dir.LastIndexOf("\") + 1)
        Dim rootid As Integer = Main.treeproject.Nodes.Count
        Dim rdroot As New Telerik.WinControls.UI.RadTreeNode
        rdroot.Text = root
        rdroot.Tag = dir
        Main.treeproject.Nodes.Add(rdroot)

        Dim result() As String = Directory.GetDirectories(dir)
        For index = 0 To result.Length - 1
            Dim lroot As String = result(index)
            Dim dirname As String = lroot.Remove(0, lroot.LastIndexOf("\") + 1)
            Dim rditem As New Telerik.WinControls.UI.RadTreeNode
            rditem.Text = dirname
            rditem.Tag = lroot
            rditem.ImageKey = "folder.png"
            load_sub_directories(lroot, rditem)
            Main.treeproject.Nodes(root).Nodes.Add(rditem)
        Next
        load_sub_files(dir, rdroot)
    End Sub

    Private Shared Sub load_sub_directories(dir As String, ByRef rditem As RadTreeNode)
        Dim result() As String = Directory.GetDirectories(dir)
        For index = 0 To result.Length - 1
            Dim lroot As String = result(index)
            Dim dirname As String = lroot.Remove(0, lroot.LastIndexOf("\") + 1)
            Dim rditemsc As New Telerik.WinControls.UI.RadTreeNode
            rditemsc.Text = dirname
            rditemsc.Tag = lroot
            rditemsc.ImageKey = "folder.png"
            load_sub_directories(lroot, rditemsc)
            rditem.Nodes.Add(rditemsc)
        Next
        load_sub_files(dir, rditem)
    End Sub

    Private Shared Sub load_sub_files(dir As String, ByRef rditem As RadTreeNode)
        Dim result() As String = Directory.GetFiles(dir)
        For index = 0 To result.Length - 1
            Dim lroot As String = result(index)
            Dim filename As String = lroot.Remove(0, lroot.LastIndexOf("\") + 1)
            Dim rditemsc As New Telerik.WinControls.UI.RadTreeNode
            rditemsc.Text = filename
            rditemsc.Tag = lroot
            rditemsc.ImageKey = get_def_icon(filename.Remove(0, filename.LastIndexOf(".") + 1))
            rditem.Nodes.Add(rditemsc)
        Next
    End Sub

    Friend Shared Sub check_open_tabs()
        Dim yodaf As New YOLIB.yoda
        For index = 0 To main.tabs.Pages.Count - 1
            Dim path As String = main.tabs.Pages(index).Tag
            If path <> String.Empty AndAlso File.Exists(path) Then
                yodaf.add(path)
            End If
        Next
        File.WriteAllText(conrex.FILEOPENLIST, yodaf.get_list)
    End Sub

    Friend Shared Function get_def_icon(ext As String) As String
        Select Case ext
            Case "yo"
                Return "yo.png"
            Case "exe"
                Return "exe.png"
            Case Else
                Return String.Empty
        End Select
    End Function
End Class
