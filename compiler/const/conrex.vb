Public Class conrex
    Public Shared yocommondatatype() As String = {"bool", "i8", "i16", "i32", "i64", "i128", "ui8", "ui16", "ui32", "u64", "str", "char", "f32", "f64", "obj"}
    Public Shared msilcommondatatype() As String = {"bool", "int8", "int16", "int32", "int64", "valuetype [mscorlib]System.Decimal", "uint8", "uint16", "uint32", "uint64", "string", "char", "single", "double", "object"}
    Public Shared specificxmlchar() As Char = {">", "<", "'", """", "&"}
    Public Shared spdustrcommand() As String = {"#nl", "#bs", "#tb", "#lf", "#cr", "#qu", "#co"}
    Public Shared spdustrreact() As String = {"\r\n", Chr(8), Chr(9), "\n", "\r", "\""", "\'"}


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
