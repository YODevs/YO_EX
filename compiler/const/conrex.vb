''' <summary>
''' <en>
''' A list of constant and arrays which is applicable in units like lexer or parser.
''' </en>
''' <fa>
''' لیستی از ثوابت و آرایه هایی که در کامپایلر در واحد های مانند لکسر یا پارسر کاربرد دارد
''' </fa>
''' </summary>
Public Class conrex
    Public Shared yocommondatatype() As String = {"bool", "i8", "i16", "i32", "i64", "i128", "u8", "u16", "u32", "u64", "str", "char", "f32", "f64", "obj"}
    Public Shared plvbcommondatatype() As String = {"Boolean", "Int8", "Int16", "Int32", "Int64", "Decimal", "UInt8", "UInt16", "UInt32", "UInt64", "String", "Char", "Single", "Double", "Object"}
    Public Shared msilcommondatatype() As String = {"bool", "int8", "int16", "int32", "int64", "valuetype [mscorlib]System.Decimal", "uint8", "uint16", "uint32", "uint64", "string", "char", "float32", "float64", "object"}
    Public Shared convmethod() As String = {"ToBoolean", "ToSByte", "ToInt16", "ToInt32", "ToInt64", "ToDecimal", "ToByte", "ToUInt16", "ToUInt32", "ToUInt64", "ToString", "ToChar", "ToSingle", "ToDouble", ""}
    Public Shared specificxmlchar() As Char = {">", "<", "'", """", "&"}
    Public Shared spdustrcommand() As String = {"#nl", "#bs", "#tb", "#lf", "#cr", "#qu", "#co"}
    Public Shared spdustrreact() As String = {"\r\n", Chr(8), Chr(9), "\n", "\r", "\""", "\'"}
    Public Shared accesscontrol() As tokenhared.token = {tokenhared.token.PUBLIC, tokenhared.token.PRIVATE}
    Public Shared modifier() As tokenhared.token = {tokenhared.token.INSTANCE, tokenhared.token.STATIC}
    Public Shared ignoretokencontrol() As tokenhared.token = {tokenhared.token.FUNC, tokenhared.token.EXPR, tokenhared.token.EXTERN, tokenhared.token.ENUM, tokenhared.token.CONST, tokenhared.token.INCLUDE, tokenhared.token.LET}
    Private Shared rand As New Random
    Public Shared specificrandomnumber As Integer = rand.Next(10000, 99999)
    Public Const TITLE As String = "[ YO Lang ]"
    Public Const CACHEACTIVITYRANGE As Double = 60.0 'Days
    Public Shared VER As String = My.Application.Info.Version.ToString
    Public Shared APPDIR As String = My.Application.Info.DirectoryPath
    Public Shared ENVCURDIR As String = Environment.CurrentDirectory
    Public Shared CACHEDIR As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\YOLang"
    Public Const YOFORMAT As String = ".yo"
    Public Const DNLIBFORMAT As String = ".dll"
    Public Const LABRAFORMAT As String = ".labra"
    Public Const YODAFORMAT As String = ".yoda"
    Public Const LEXCACHEFORMAT As String = ".yoobj"
    Public Const NULL As String = Nothing
    Public Const SPACE As Char = " "
    Public Const DOT As Char = "."
    Public Const DBDOT As String = ".."
    Public Const CURSORERR As Char = "^"
    Public Const PRSTART As Char = "("
    Public Const PREND As Char = ")"
    Public Const PRSTEN As String = "()"
    Public Const BRSTART As Char = "["
    Public Const BREND As Char = "]"
    Public Const COSTR As Char = "'"
    Public Const DUSTR As Char = """"
    Public Const BKSLASH As Char = "\"
    Public Const BTRIG As Char = "<"
    Public Const LTLEF As Char = ">"
    Public Const CMA As Char = ","
    Public Const DLR As Char = "$"
    Public Const CLN As Char = ":"
    Public Const DBCLN As Char = ":"
    Public Const EQU As Char = "="
    Public Const QES As Char = "?"


    Enum exitcode
        SUCCESS
        [ERROR]
    End Enum
End Class
