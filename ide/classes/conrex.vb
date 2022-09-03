Public Class conrex
    Public Shared LOCALAPPDATADIR As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\VSYO\"
    Public Shared PROJECTLISTFILE As String = LOCALAPPDATADIR & "projectlist.yoda"
    Public Shared VER As String = My.Application.Info.Version.ToString
    Public Shared APPDIR As String = My.Application.Info.DirectoryPath
    Public Shared ENVCURDIR As String = Environment.CurrentDirectory
    Public Const PROJECTOPTIONSNAME As String = "labra.yoda"
End Class
