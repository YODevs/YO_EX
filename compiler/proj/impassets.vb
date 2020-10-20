Imports System.IO

Public Class impassets
    Friend Shared Sub copy_assets()
        Console.WriteLine("Checking and copying the required compiled output file ...")
        Try
            copy_dir()
            copy_file()
        Catch ex As Exception
            dserr.new_error(conserr.errortype.RUNTIMEERROR, -1, Nothing, ex.Message)
        End Try
    End Sub

    Private Shared Sub copy_dir()
        Dim dirlen As Integer = Directory.GetDirectories(cilcomp.get_assets_loca).Length - 1
        For index = 0 To dirlen
            Dim routedir As String = Directory.GetDirectories(cilcomp.get_assets_loca)(index)
            Dim dirname As String = routedir.Remove(0, routedir.LastIndexOf("\"))
            My.Computer.FileSystem.CopyDirectory(routedir, cilcomp.get_output_loca_without_extension & dirname, True)
        Next
    End Sub

    Private Shared Sub copy_file()
        Dim filelen As Integer = Directory.GetFiles(cilcomp.get_assets_loca).Length - 1
        For index = 0 To filelen
            Dim routefile As String = Directory.GetFiles(cilcomp.get_assets_loca)(index)
            Dim filename As String = routefile.Remove(0, routefile.LastIndexOf("\"))
            My.Computer.FileSystem.CopyFile(routefile, cilcomp.get_output_loca_without_extension & filename, True)
        Next
    End Sub
End Class
