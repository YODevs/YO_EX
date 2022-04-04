Public Class font
    Dim cfont As System.Drawing.Font
    Public Sub New(fontname As String, fontsize As Integer)
        init(fontname, fontsize)
    End Sub
    Public Sub New(fontname As String, fontsize As Single)
        init(fontname, fontsize)
    End Sub
    Public Sub New(fontname As String, fontsize As Single, fontstyle As String)
        init(fontname, fontsize, fontstyle)
    End Sub
    Public Sub New(fontname As String, fontsize As Integer, fontstyle As String)
        init(fontname, fontsize, fontstyle)
    End Sub

    Private Sub init(fontname As String, fontsize As Single, Optional fontstyle As String = Nothing)
        Dim enumfontstyle As Drawing.FontStyle = get_font_style(fontstyle)
        cfont = New Drawing.Font(fontname, fontsize, enumfontstyle)
    End Sub

    Private Function get_font_style(fontstyle As String) As Drawing.FontStyle
        Select Case fontstyle.ToLower
            Case "bold"
                Return Drawing.FontStyle.Bold
            Case "italic"
                Return Drawing.FontStyle.Italic
            Case "underline"
                Return Drawing.FontStyle.Underline
            Case "strikeout"
                Return Drawing.FontStyle.Strikeout
            Case Else
                Return Drawing.FontStyle.Regular
        End Select
    End Function

    Public Property [font]() As System.Drawing.Font
        Get
            Return cfont
        End Get
        Set(ByVal value As System.Drawing.Font)
            cfont = value
        End Set
    End Property
End Class
