Imports System.IO
Imports FastColoredTextBoxNS
Public Class range

    Public Shared fsrange As FastColoredTextBoxNS.Range
    Public Shared constantsstyle, stringstyle, keywordsstyle, datatypesstyle, methodsstyle, commentsstyle, modifiersstyle, operatorsstyle As TextStyle
    Private Shared constants, keywords, operators, datatypes, modifiers As String

    Public Shared BlueStyle As TextStyle = New TextStyle(Brushes.Blue, Nothing, FontStyle.Regular)
    Public Shared BoldStyle As TextStyle = New TextStyle(Nothing, Nothing, FontStyle.Bold Or FontStyle.Underline)
    Public Shared GrayStyle As TextStyle = New TextStyle(Brushes.Gray, Nothing, FontStyle.Regular)
    Public Shared MagentaStyle As TextStyle = New TextStyle(Brushes.Magenta, Nothing, FontStyle.Regular)
    Public Shared GreenStyle As TextStyle = New TextStyle(Brushes.Green, Nothing, FontStyle.Italic)
    Public Shared BrownStyle As TextStyle = New TextStyle(Brushes.Brown, Nothing, FontStyle.Italic)
    Public Shared MaroonStyle As TextStyle = New TextStyle(Brushes.Maroon, Nothing, FontStyle.Regular)
    Public Shared SameWordsStyle As MarkerStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(40, Color.Gray)))

    Public Shared bgreen As New SolidBrush(Color.FromArgb(181, 189, 104))
    Public Shared bcyan As New SolidBrush(Color.FromArgb(138, 190, 183))
    Public Shared bblue As New SolidBrush(Color.FromArgb(129, 162, 190))
    Public Shared bpurple As New SolidBrush(Color.FromArgb(163, 86, 187))
    Public Shared bred As New SolidBrush(Color.FromArgb(204, 102, 102))
    Public Shared borange As New SolidBrush(Color.FromArgb(222, 147, 95))
    Public Shared blightorange As New SolidBrush(Color.FromArgb(240, 198, 116))
    Public Shared blightgray As New SolidBrush(Color.FromArgb(150, 152, 150))

    Friend Shared Sub init()
        load_extension("keywords.yoda", keywords)
        load_extension("modifiers.yoda", modifiers)
        load_extension("constants.yoda", constants)
        load_extension("operators.yoda", operators)
        load_extension("datatypes.yoda", datatypes)
        constantsstyle = New TextStyle(borange, Nothing, FontStyle.Regular)
        datatypesstyle = New TextStyle(New SolidBrush(Color.FromArgb(86, 156, 214)), Nothing, FontStyle.Regular)
        stringstyle = New TextStyle(New SolidBrush(Color.FromArgb(214, 157, 133)), Nothing, FontStyle.Regular)
        modifiersstyle = New TextStyle(New SolidBrush(Color.FromArgb(86, 156, 214)), Nothing, FontStyle.Regular)
        methodsstyle = New TextStyle(New SolidBrush(Color.FromArgb(220, 220, 170)), Nothing, FontStyle.Regular)
        operatorsstyle = New TextStyle(New SolidBrush(Color.FromArgb(180, 180, 180)), Nothing, FontStyle.Regular)
        keywordsstyle = New TextStyle(New SolidBrush(Color.FromArgb(224, 108, 117)), Nothing, FontStyle.Regular)
    End Sub

    Private Shared Sub load_extension(filename As String, ByRef output As String)
        Try
            Dim path As String = conrex.EXTENSIONDIR & filename
        If File.Exists(path) = False Then Return
        Dim values As String = File.ReadAllText(path)
            Dim tokens As New YOLIB.list
            Dim count As Integer = tokens.import(values) - 1
        If count < 1 Then Return
            For index = 0 To count
                If filename <> "operators.yoda" Then
                    output &= tokens.get(index) & "|"
                Else
                    Dim val As String = tokens.get(index)
                    For Each ch In val
                        output &= "\" & ch
                    Next
                    output &= "|"
                End If
            Next
            output = output.Remove(output.Length - 1)
            If filename <> "operators.yoda" Then output = "\b(" & output & ")\b"
        Catch ex As Exception
            Return
        End Try
    End Sub

    Friend Shared Sub set_extension(ByRef fscode As FastColoredTextBox)
        fscode.Range.ClearStyle()
        fscode.Range.SetStyle(keywordsstyle, keywords)
        fscode.Range.SetStyle(datatypesstyle, datatypes)
        fscode.Range.SetStyle(constantsstyle, constants)
        fscode.Range.SetStyle(modifiersstyle, modifiers)
        fscode.Range.SetStyle(operatorsstyle, operators)
        fscode.Range.SetStyle(methodsstyle, "(?<range>\w+?)(\(.*\))")
        fscode.Range.SetStyle(methodsstyle, "\b(func)\s+(?<range>\w+?)\b")
        fscode.Range.SetStyle(stringstyle, """.*?""|'.+?'")
        fscode.Range.SetStyle(constantsstyle, "\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b")
        fscode.Range.SetStyle(commentsstyle, "//.+")
        fscode.Range.SetStyle(commentsstyle, "\#\-.*\-\#", System.Text.RegularExpressions.RegexOptions.Multiline)

        fscode.Range.ClearFoldingMarkers()
    End Sub

    Friend Shared Sub set_extension(ByRef fsrange As FastColoredTextBoxNS.Range)
        fsrange.ClearStyle()
        fsrange.SetStyle(keywordsstyle, keywords)
        fsrange.SetStyle(datatypesstyle, datatypes)
        fsrange.SetStyle(constantsstyle, constants)
        fsrange.SetStyle(modifiersstyle, modifiers)
        fsrange.SetStyle(operatorsstyle, operators)
        fsrange.SetStyle(methodsstyle, "(?<range>\w+?)(\(.*\))")
        fsrange.SetStyle(methodsstyle, "\b(func)\s+(?<range>\w+?)\b")
        fsrange.SetStyle(stringstyle, """.*?""|'.+?'")
        fsrange.SetStyle(constantsstyle, "\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b")
        fsrange.SetStyle(commentsstyle, "//.+")
        fsrange.SetStyle(commentsstyle, "\#\-.+\-\#", System.Text.RegularExpressions.RegexOptions.Multiline)

        fsrange.ClearFoldingMarkers()
    End Sub
End Class
