Imports System.IO

Public Class cprojclean
    Private Shared ifile, idir As Integer
    Friend Shared Sub clean_project()
        Try
            ifile = 0
            idir = 0
            clean_dirs()
            clean_files()
            Console.Write(vbCrLf & "Result: {0} folders and {1} files were deleted .", idir, ifile)
        Catch ex As Exception
            dserr.new_error(conserr.errortype.RUNTIMEERROR, -1, Nothing, ex.Message)
        End Try
    End Sub

    Private Shared Sub clean_dirs()
        Dim dirlen As Integer = Directory.GetDirectories(cilcomp.get_output_loca_without_extension).Length - 1
        Dim dirs() As String = Directory.GetDirectories(cilcomp.get_output_loca_without_extension)
        For index = 0 To dirlen
            Dim routedir As String = dirs(index)
            Dim dirname As String = routedir.Remove(0, routedir.LastIndexOf("\"))
            My.Computer.FileSystem.DeleteDirectory(routedir, FileIO.DeleteDirectoryOption.DeleteAllContents)
            Console.WriteLine("'{0}' folder was deleted ", dirname)
            idir += 1
        Next
    End Sub

    Private Shared Sub clean_files()
        Dim filelen As Integer = Directory.GetFiles(cilcomp.get_output_loca_without_extension).Length - 1
        Dim files() As String = Directory.GetFiles(cilcomp.get_output_loca_without_extension)
        For index = 0 To filelen
            Dim routefile As String = files(index)
            Dim filename As String = routefile.Remove(0, routefile.LastIndexOf("\"))
            My.Computer.FileSystem.DeleteFile(routefile)
            Console.WriteLine("'{0}' file was deleted ", filename)
            ifile += 1
        Next
    End Sub
End Class
