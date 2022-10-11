Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports FastColoredTextBoxNS

Public Class codeopt
    Friend Shared Function is_file_open(path As String, ByRef rdpage As Telerik.WinControls.UI.RadPageViewPage) As Boolean
        For index = 0 To main.tabs.Pages.Count - 1
            If main.tabs.Pages(index).Tag = path Then
                rdpage = main.tabs.Pages(index)
                Return True
            End If
        Next
        Return False
    End Function

    Friend Shared Sub fscode_customization(ByRef fscode As FastColoredTextBox, path As String)
        fscode.Font = New Font("Cascadia Mono", 10.3)
        fscode.AutoScrollMinSize = formcodeenv.x.AutoScrollMinSize
        fscode.AutoCompleteBrackets = formcodeenv.x.AutoCompleteBrackets
        fscode.AutoIndent = formcodeenv.x.AutoIndent
        fscode.AutoIndentChars = formcodeenv.x.AutoIndentChars
        fscode.AutoIndentCharsPatterns = formcodeenv.x.AutoIndentCharsPatterns
        fscode.AutoIndentExistingLines = formcodeenv.x.AutoIndentExistingLines
        fscode.BackColor = formcodeenv.x.BackColor
        fscode.BookmarkColor = formcodeenv.x.BookmarkColor
        fscode.BorderStyle = formcodeenv.x.BorderStyle
        fscode.BracketsHighlightStrategy = formcodeenv.x.BracketsHighlightStrategy
        fscode.BracketsStyle = formcodeenv.x.BracketsStyle
        fscode.BracketsStyle2 = formcodeenv.x.BracketsStyle2
        fscode.CaretBlinking = formcodeenv.x.CaretBlinking
        fscode.CaretColor = formcodeenv.x.CaretColor
        fscode.CaretVisible = formcodeenv.x.CaretVisible
        fscode.ChangedLineColor = formcodeenv.x.ChangedLineColor
        fscode.CharHeight = formcodeenv.x.CharHeight
        fscode.CharWidth = formcodeenv.x.CharWidth
        fscode.CommentPrefix = formcodeenv.x.CommentPrefix
        fscode.Dock = formcodeenv.x.Dock
        fscode.DefaultMarkerSize = formcodeenv.x.DefaultMarkerSize
        fscode.FoldedBlockStyle = formcodeenv.x.FoldedBlockStyle
        fscode.ForeColor = formcodeenv.x.ForeColor
        fscode.HighlightFoldingIndicator = formcodeenv.x.HighlightFoldingIndicator
        fscode.Hotkeys = formcodeenv.x.Hotkeys
        fscode.HotkeysMapping = formcodeenv.x.HotkeysMapping
        fscode.ImeMode = formcodeenv.x.ImeMode
        fscode.IndentBackColor = formcodeenv.x.IndentBackColor
        fscode.Language = formcodeenv.x.Language
        fscode.LeftBracket = formcodeenv.x.LeftBracket
        fscode.LeftBracket2 = formcodeenv.x.LeftBracket2
        fscode.LeftPadding = formcodeenv.x.LeftPadding
        fscode.LineInterval = formcodeenv.x.LineInterval
        fscode.LineNumberColor = formcodeenv.x.LineNumberColor
        fscode.LineNumberFormatting = formcodeenv.x.LineNumberFormatting
        fscode.LineNumberStartValue = formcodeenv.x.LineNumberStartValue
        fscode.PaddingBackColor = formcodeenv.x.PaddingBackColor
        fscode.Paddings = formcodeenv.x.Paddings
        fscode.PreferredLineWidth = formcodeenv.x.PreferredLineWidth
        fscode.ReservedCountOfLineNumberChars = formcodeenv.x.ReservedCountOfLineNumberChars
        fscode.RightBracket = formcodeenv.x.RightBracket
        fscode.RightBracket2 = formcodeenv.x.RightBracket2
        fscode.SelectionColor = formcodeenv.x.SelectionColor
        fscode.ServiceColors = formcodeenv.x.ServiceColors
        fscode.ShowCaretWhenInactive = formcodeenv.x.ShowCaretWhenInactive
        fscode.ServiceLinesColor = formcodeenv.x.ServiceLinesColor
        fscode.ShowFoldingLines = formcodeenv.x.ShowFoldingLines
        fscode.ShowLineNumbers = formcodeenv.x.ShowLineNumbers
        fscode.ShowScrollBars = formcodeenv.x.ShowScrollBars
        fscode.TextAreaBorder = formcodeenv.x.TextAreaBorder
        fscode.TextAreaBorderColor = formcodeenv.x.TextAreaBorderColor
        fscode.ToolTip = formcodeenv.x.ToolTip
        fscode.ToolTipDelay = formcodeenv.x.ToolTipDelay
        fscode.Zoom = formcodeenv.x.Zoom
        fscode.WordWrap = formcodeenv.x.WordWrap
        fscode.WordWrapAutoIndent = formcodeenv.x.WordWrapAutoIndent
        fscode.WordWrapIndent = formcodeenv.x.WordWrapIndent
        fscode.WordWrapMode = formcodeenv.x.WordWrapMode
        fscode.WideCaret = formcodeenv.x.WideCaret
        fscode.VirtualSpace = formcodeenv.x.VirtualSpace

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
