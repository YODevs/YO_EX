Public Class tknformat

    Structure _importdll
        Dim name As String
    End Structure
    Structure _class
        Dim name As String
        Dim methods() As _method
    End Structure

    Structure _method
        Dim name As String
        Dim returntype As String
        Dim parameters() As _parameter
    End Structure

    Structure _parameter
        Dim name As String
        Dim ptype As String
        Dim byreference As Boolean
        Dim defvalue As String
    End Structure
    Structure _pubfield

    End Structure

    Structure _inlcode

    End Structure
    Public Sub New()

    End Sub
End Class
