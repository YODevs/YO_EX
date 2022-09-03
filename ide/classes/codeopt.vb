Imports System.IO
Imports System.Reflection
Imports FastColoredTextBoxNS

Public Class codeopt
    Friend Shared Function is_file_open(path As String, ByRef rdpage As Telerik.WinControls.UI.RadPageViewPage) As Boolean
        For index = 0 To Main.tabs.Pages.Count - 1
            If Main.tabs.Pages(index).Tag = path Then
                rdpage = Main.tabs.Pages(index)
                Return True
            End If
        Next
        Return False
    End Function

    Friend Shared Sub fscode_customization(ByRef fscode As FastColoredTextBox, path As String)
        fscode = Formcodeenv.x

        load_source(fscode, path)
    End Sub

    Friend Shared Sub load_source(ByRef fscode As FastColoredTextBox, path As String)
        If File.Exists(path) = False Then
            MsgBox("File '" & path & "' not found.", MsgBoxStyle.Critical)
            Return
        End If
        fscode.Text = File.ReadAllText(path)
    End Sub
End Class
