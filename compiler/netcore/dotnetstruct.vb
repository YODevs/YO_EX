Imports System.IO

Public Class dotnetstruct
    Public Shared Sub init(path As String)
        create_global_file(path)
        create_il_project(path)
    End Sub

    Private Shared Sub create_il_project(path As String)
        Dim code As String = File.ReadAllText(conrex.APPDIR & "\iniopt\dotnetconfig\global.json")
        code = code.Replace("{0}", compdt.DOTNETVERSDK)
        File.WriteAllText(path & "\global.json", code)
    End Sub

    Private Shared Sub create_global_file(path As String)
        Dim code As String = File.ReadAllText(conrex.APPDIR & "\iniopt\dotnetconfig\main.ilproj")
        If cprojdt.get_val("outputtype").ToLower = "library" Then
            code = code.Replace("{0}", ".dll")
        Else
            code = code.Replace("{0}", "exe")
        End If
        code = code.Replace("{1}", compdt.DOTNETNAME)
        File.WriteAllText(path & conrex.BKSLASH & compdt.PROJECTASSEMBLYNAME & ".ilproj", code)
    End Sub
End Class
