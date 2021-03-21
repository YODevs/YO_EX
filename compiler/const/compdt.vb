''' <summary>
''' <en>
''' Constant and arrays which during operation of compiling will be implemented in the preparation units of parameters or code-generates.
''' </en>
''' <fa>
''' ثوابت و ارایه هایی که حین عملیات کامپایل در واحدهای آماده سازی پارامتر ها یا کد جنریت ها استفاده می شوند
''' </fa>
''' </summary>
Public Class compdt
    Friend Shared ILASMPATH As String = My.Application.Info.DirectoryPath & "\ilasm.exe"
    Friend Shared cilintegertypes() As String = {"int8", "int16", "int32", "int64", "uint8", "uint16", "uint32", "uint64"}
    Friend Shared yointegertypes() As String = {"i8", "i16", "i32", "i64", "u8", "u16", "u32", "u64"}
    Friend Shared i8cmtypes() As String = {"int64", "uint64", "valuetype [mscorlib]System.Decimal"}
    Friend Shared expressionact() As String = {"+", "-", "/", "*", "%"}
    Friend Shared expressionactopt() As String = {"add", "sub", "div", "mul", "rem"}
    Friend Shared errcap() As String = {"Error:", "error code="}
    Friend Shared ptrinddata As mapstoredata
    Friend Shared argumentallow() As tokenhared.token = {tokenhared.token.TYPE_CO_STR, tokenhared.token.TYPE_DU_STR, tokenhared.token.TYPE_INT, tokenhared.token.TYPE_FLOAT, tokenhared.token.TYPE_BOOL, tokenhared.token.IDENTIFIER,
        tokenhared.token.EXPRESSION, tokenhared.token.NULL, tokenhared.token.TRUE, tokenhared.token.FALSE}
    Friend Shared blockopallow() As tokenhared.token = {tokenhared.token.ENUM, tokenhared.token.FOR, tokenhared.token.UL, tokenhared.token.ELSEIF, tokenhared.token.ELSE, tokenhared.token.IF, tokenhared.token.WHILE, tokenhared.token.DEFAULT, tokenhared.token.CASE, tokenhared.token.MATCH, tokenhared.token.TO, tokenhared.token.LOOP, tokenhared.token.TRY, tokenhared.token.CATCH}
    Friend Const FLAGPERFIX As String = "YO_Flag_"
    Friend Const YOMAINCLASS As String = "YO_Main"
    Friend Const YOILLABEL As String = "YOIL_"
    Friend Const RANGEFMT As String = "\[\s*\w+\s*\.\.\=?\s*\w+\s*(\s*\;\s*\-?\w+)?\s*\]"
    Friend Const ATTRIBUTEFMT As String = "\#\[\w+::\w+\(.+\)\]"
    Friend Const DISPLAYILASMOUTPUT As Boolean = False
    Friend Shared DISPLAYTOKENWLEX As Boolean = False
    Friend Shared DISPLAYSTACKTRACE As Boolean = False
    Friend Shared CHECKSYNANDSEM As Boolean = False
    Friend Shared MUTEPROCESS As Boolean = False
    Friend Shared DISABLEWARNINGS As Boolean = False
    Friend Shared EXECTIME As Boolean = False
    Friend Shared COMPILETIME As Boolean = False
    Friend Const RUNCMDDELAY As Integer = 500
    Friend Const WAITILCODE As String = "call string [mscorlib]System.Console::ReadLine()
pop"
    Friend Const YOFORMATTEDSTRBYREGEX As String = "#{\w+}"
    Friend Const PARAM_IMPASSETS As String = "--import_assets"
    Friend Const PARAM_DEBUG As String = "--debug"
    Friend Const PARAM_DEBUG_IMPL As String = "--debug_impl"
    Friend Const PARAM_DEBUG_OPT As String = "--debug_opt"
    Friend Const PARAM_DISPLAYTOKENLEX As String = "--display_token"
    Friend Const PARAM_DISPLAYSTACKTRACE As String = "--stack_trace"
    Friend Const PARAM_MUTE_PROCESS As String = "--mute_process"
    Friend Const PARAM_DISABLE_WARNINGS As String = "--disable_warnings"
    Friend Const PARAM_DISPLAY_EXEC_TIME As String = "--execution_time"
    Friend Const PARAM_DISPLAY_COMPILE_TIME As String = "--compile_time"

    Friend Const ACCESSIBLE_PUBLIC As String = "public"
    Friend Const ACCESSIBLE_PRIVATE As String = "private"
    Friend Const OBJECTMODTYPE_STATIC As String = "static"
    Friend Const OBJECTMODTYPE_INSTANCE As String = "instance"

    Friend Const CONSTRUCTOR_METHOD As String = "ctor"
End Class
