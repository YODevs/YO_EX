Imports System.IO

Public Class forminitstruct

    Dim progress As Integer = 0
    Dim progressbarlabel As String = String.Empty
    Private Sub forminitstruct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        create_localappdata()
        progress = 20
        create_projectlistfile()
        progress = 100
        Me.Close()
    End Sub

    Private Sub create_projectlistfile()
        progressbarlabel = "Creating projectlist file"
        labelprogressinfo.Text = conrex.PROJECTLISTFILE
        If File.Exists(conrex.PROJECTLISTFILE) = False Then
            File.WriteAllText(conrex.PROJECTLISTFILE, "![]")
        End If
        set_sleep()
    End Sub

    Private Sub create_localappdata()
        progressbarlabel = "Creating parent directory"
        labelprogressinfo.Text = conrex.LOCALAPPDATADIR
        If Directory.Exists(conrex.LOCALAPPDATADIR) = False Then
            Directory.CreateDirectory(conrex.LOCALAPPDATADIR)
        End If
        set_sleep()
    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        progressbar.Value1 = progress
        progressbar.Text = progressbarlabel
    End Sub

    Public Sub set_sleep()
        Threading.Thread.Sleep(50)
    End Sub
End Class
