Public Class ilformat

    Public Structure resultildata
        Dim result As Boolean
        Dim ilfmtdata As ildata
    End Structure
    Public Structure ildata
        Dim ilmethod() As _ilmethodcollection
        Dim assemblyextern() As _ilassemblyextern
        Dim modulename As String
        'Assembly
        'Global Fields
    End Structure

    Public Structure _ilmethodcollection
        Dim name As String
        Dim accessible As _accessiblemethod
        Dim locallinit() As _illocalinit
        Dim returntype As String
        'Parameters
        Dim entrypoint As Boolean
        Dim maxstack As Int16
        Dim codes As ArrayList
        Dim line As ArrayList
    End Structure

    Public Structure _illocalinit
        Dim name As String
        Dim datatype As String
        Dim defvalue As String
    End Structure
    Public Structure _ilassemblyextern
        Dim name As String
        Dim isextern As Boolean
        Dim assemblyproperty As String
    End Structure

    Public Enum _accessiblemethod
        [PUBLIC]
        [PRIVATE]
    End Enum
    Public Sub New()

    End Sub
End Class
