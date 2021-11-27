Public Class conrex
    Friend Shared TARGETFRAMEWORK As String
    Friend Shared TARGETCACHEDIR As String
    Friend Shared TARGETMAJORVER As String
    Friend Const SPACE As String = " "
    Public Const DNLIBFORMAT As String = ".dll"
    Public Const DOT As Char = "."
    Public Const NULL As String = Nothing
    Public Const CMA As Char = ","
    Friend Shared DOTNETCOREROOT As String = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\dotnet\shared\Microsoft.NETCore.App\"
End Class
