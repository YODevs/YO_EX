Public Class conrex
    Public Const TITLE As String = "[ Labra ]"
    Public Shared VER As String = My.Application.Info.Version.ToString
    Public Shared APPDIR As String = My.Application.Info.DirectoryPath
    Public Shared ENVCURDIR As String = Environment.CurrentDirectory
    Public Shared COMMANDLINE As String = Environment.CommandLine
    Public Shared PROGRAMFILEDIR As String = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
    Public Const YOFORMAT As String = ".yo"
    Public Const NULL As String = Nothing
    Public Const SPACE As Char = " "
    Public Const DOT As Char = "."
    Public Const DUSTR As Char = """"
    Public Const BATCHFILESTR As String = "yoca run
pause"
    Public Const MAINDEFCODE As String = "#[app::classname(""myapp"")]
#[app::wait(true)]

func main()
{
  
}
"
    Public Const MAINLIBDEFCODE As String = "#[app::classname(""mylib"")]
public instance func ctor()
{

}
"
End Class
