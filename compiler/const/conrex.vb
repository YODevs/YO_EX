Public Class conrex
    Public Const TITLE As String = "[ YO Lang ]"
    Public Shared VER As String = My.Application.Info.Version.ToString
    Public Shared APPDIR As String = My.Application.Info.DirectoryPath
    Public Const YOFORMAT As String = ".yo"
    Public Const NULL As String = Nothing
    Public Const SPACE As Char = " "
    Public Const DOT As Char = "."
    Public Const CURSORERR As Char = "^"
    Public Const PRSTART As Char = "("
    Public Const PREND As Char = ")"
    Enum exitcode
        SUCCESS
        [ERROR]
    End Enum
End Class
