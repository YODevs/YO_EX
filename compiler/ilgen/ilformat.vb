Public Class ilformat

    Public Structure resultildata
        Dim result As Boolean
        Dim ilfmtdata As ildata
    End Structure
    Public Structure ildata
        Dim enumeration() As tknformat._enum
        Dim ilmethod() As _ilmethodcollection
        Dim assemblyextern() As _ilassemblyextern
        Dim modulename As String
        Dim field() As _pubfield
        Dim staticctor As ArrayList
        Dim instancector As ArrayList
        Dim setinitialization As Boolean
        'Assembly
    End Structure

    Public Structure _ilmethodcollection
        Dim name As String
        Dim objcontrol As fmtshared.objectcontrol
        Dim accessible As _accessiblemethod
        Dim methodmodtype As _modifiertype
        Dim locallinit() As _illocalinit
        Dim returntype As String
        Dim typeinf As _typeinfo
        Dim returninfo As _returninfo
        Dim parameter() As _ilparameter
        Dim entrypoint As Boolean
        Dim maxstack As Int16
        Dim codes As ArrayList
        Dim line As ArrayList
        Dim isexpr As Boolean
        Dim isretarray As Boolean
    End Structure
    Public Structure _returninfo
        Dim asmextern As String
        Dim classname As String
    End Structure
    Public Structure _ilparameter
        Dim name As String
        Dim typeinf As _typeinfo
        Dim datatype As String
        Dim hasdefaultvalue As Boolean
        Dim ispointer As Boolean
        Dim clocalvalue() As xmlunpkd.linecodestruc
    End Structure
    Public Structure _illocalinit
        Dim name As String
        Dim datatype As String
        Dim typeinf As _typeinfo
        Dim iscommondatatype As Boolean
        Dim hasdefaultvalue As Boolean
        Dim clocalvalue() As xmlunpkd.linecodestruc
        Dim isconstant As Boolean
        Dim frinit As Boolean
        Dim ctor As Boolean
        Dim isvaluetypes As Boolean
        Dim isarrayobj As Boolean
        Dim arrayinf As _arrayinfo
        Dim asmextern As String
    End Structure
    Public Structure _typeinfo
        Dim name As String
        Dim [namespace] As String
        Dim fullname As String
        Dim externlib As String
        Dim isprimitive As Boolean
        Dim isclass As Boolean
        Dim isenum As Boolean
        Dim isarray As Boolean
        Dim isinternalclass As Boolean
        Dim yosymbol As String
        Dim cdttypesymbol As String
        Dim asminfo As String
        Dim valtpinf As _valtypeinfo
    End Structure
    Public Structure _ilassemblyextern
        Dim name As String
        Dim isextern As Boolean
        Dim assemblyproperty As String
    End Structure
    Public Structure _pubfield
        Dim isliteral As Boolean
        Dim accesscontrol As String
        Dim modifier As String
        Dim name As String
        Dim typeinf As _typeinfo
        Dim ptype As String
        Dim value As String
        Dim valuecinf As lexer.targetinf
        Dim valuetoken As tokenhared.token
        Dim ctorparameter() As xmlunpkd.linecodestruc
        Dim initproc As Boolean
    End Structure

    Public Structure _arrayinfo
        Dim isarrayref As Boolean
        Dim isunspecifiedelements As Boolean
        Dim elementsp As Object
    End Structure
    Public Enum _accessiblemethod
        [PUBLIC]
        [PRIVATE]
    End Enum

    Public Enum _modifiertype
        [STATIC]
        [INSTANCE]
    End Enum
    Public Enum _valuetypestructure
        [NOTHING]
        [ENUM]
        [STRUCT]
    End Enum
    Public Structure _valtypeinfo
        Dim structuretype As _valuetypestructure
        Dim classname As String
        Dim objectname As String
    End Structure
    Public Sub New()

    End Sub
End Class
