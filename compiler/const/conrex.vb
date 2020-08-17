Public Class conrex
    Public Shared yocommondatatype() As String = {"bool", "i8", "i16", "i32", "i64", "i128", "ui8", "ui16", "ui32", "u64", "str", "chr", "f32", "f64"}
    Public Shared msilcommondatatype() As String = {"Boolean", "SByte", "Int16", "Int32", "Int64", "Int128", "Byte", "UInt16", "UInt32", "UInt64", "String", "Char", "Single", "Double"}
    Public Shared specificxmlchar() As Char = {">", "<", "'", """", "&"}
    Private Shared rand As New Random
    Public Shared specificrandomnumber As Integer = rand.Next(10000, 99999)
    Public Const TITLE As String = "[ YO Lang ]"
    Public Shared VER As String = My.Application.Info.Version.ToString
    Public Shared APPDIR As String = My.Application.Info.DirectoryPath
    Public Const YOFORMAT As String = ".yo"
    Public Const NULL As String = Nothing
    Public Const SPACE As Char = " "
    Public Const DOT As Char = "."
    Public Const CURSORERR As Char = "^"
    Public Const PRSTART As Char = "("
    Public Const PREND As Char = ")"
    Public Const COSTR As Char = "'"
    Public Const DUSTR As Char = """"
    Public Const BKSLASH As Char = "\"
    Enum exitcode
        SUCCESS
        [ERROR]
    End Enum
End Class
