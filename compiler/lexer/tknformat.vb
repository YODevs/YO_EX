Public Class tknformat

    Structure _importdll
        Dim name As String
    End Structure
    Structure _class
        Dim name As String
        Dim location As String
        Dim enums() As _enum
        Dim methods() As _method
        Dim fields() As _pubfield
        Dim attribute As yocaattribute.yoattribute
        Dim externlist As ArrayList
        Dim includelist As ArrayList
        Dim cacheinf As _cacheinfo
    End Structure

    Structure _cacheinfo
        Dim active As Boolean
        Dim path As String
        Dim datecreated As Long
        Dim datemodified As Long
    End Structure
    Structure _enum
        Dim name As String
        Dim constkeys As ArrayList
        Dim constvalues As ArrayList
    End Structure
    Structure _method
        Dim name As String
        Dim returntype As String
        Dim nopara As Boolean
        Dim parameters() As _parameter
        Dim bodyxmlfmt As String
        Dim isexpr As Boolean
        Dim objcontrol As fmtshared.objectcontrol
    End Structure

    Structure _parameter
        Dim name As String
        Dim ptype As String
        Dim byreference As Boolean
        Dim defvalue As String
    End Structure
    Structure _pubfield
        Dim isconstant As Boolean
        Dim accesscontrol As String
        Dim modifier As String
        Dim name As String
        Dim ptype As String
        Dim value As String
        Dim valuecinf As lexer.targetinf
        Dim valuetoken As tokenhared.token
    End Structure

    Structure _inlcode

    End Structure
    Public Sub New()

    End Sub
End Class
