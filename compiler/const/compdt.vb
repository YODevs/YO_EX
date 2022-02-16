''' <summary>
''' <en>
''' Constant and arrays which during operation of compiling will be implemented in the preparation units of parameters or code-generates.
''' </en>
''' <fa>
''' ثوابت و ارایه هایی که حین عملیات کامپایل در واحدهای آماده سازی پارامتر ها یا کد جنریت ها استفاده می شوند
''' </fa>
''' </summary>
''' 
Public Class compdt

    Public Enum __projectframework
        DotNetFramework = 1
        DotNetCore = 2
    End Enum
    Friend Shared _PROJECTFRAMEWORK As __projectframework = __projectframework.DotNetFramework
    Friend Shared ILASMPATH As String = My.Application.Info.DirectoryPath & "\ilasm.exe"
    Friend Shared BRIDGECORE As String = conrex.APPDIR & "\.netcorefr\net6.0\BridgeCore.exe"
    Friend Shared BRIDGECORELIB As String = conrex.APPDIR & "\.netcorefr\net6.0\BridgeCore.dll"
    Friend Shared SYSTEMLIBPATH As String = String.Empty
    Friend Shared cilnumerictypes() As String = {"int8", "int16", "int32", "int64", "uint8", "uint16", "uint32", "uint64", "float32", "float64"}
    Friend Shared cilintegertypes() As String = {"int8", "int16", "int32", "int64", "uint8", "uint16", "uint32", "uint64"}
    Friend Shared yointegertypes() As String = {"i8", "i16", "i32", "i64", "u8", "u16", "u32", "u64"}
    Friend Shared i8cmtypes() As String = {"int64", "uint64", "valuetype [mscorlib]System.Decimal"}
    Friend Shared expressionact() As String = {"+", "-", "/", "*", "%"}
    Friend Shared expressionactopt() As String = {"add", "sub", "div", "mul", "rem"}
    Friend Shared errcap() As String = {"Error:", "error code=", ": error :"}
    Friend Const FLOAT32 As String = "float32"
    Friend Const FLOAT64 As String = "float64"
    Friend Shared ptrinddata As mapstoredata
    Friend Shared byrefforbiddentoken() As tokenhared.token = {tokenhared.token.NULL, tokenhared.token.TRUE, tokenhared.token.FALSE, tokenhared.token.TYPE_FLOAT, tokenhared.token.TYPE_INT, tokenhared.token.TYPE_DU_STR, tokenhared.token.TYPE_CO_STR}
    Friend Shared argumentallow() As tokenhared.token = {tokenhared.token.TYPE_CO_STR, tokenhared.token.TYPE_DU_STR, tokenhared.token.TYPE_INT, tokenhared.token.TYPE_FLOAT, tokenhared.token.TYPE_BOOL, tokenhared.token.IDENTIFIER,
        tokenhared.token.EXPRESSION, tokenhared.token.NULL, tokenhared.token.TRUE, tokenhared.token.FALSE, tokenhared.token.ARR}
    Friend Shared blockopallow() As tokenhared.token = {tokenhared.token.ENUM, tokenhared.token.FOR, tokenhared.token.UL, tokenhared.token.ELSEIF, tokenhared.token.ELSE, tokenhared.token.IF, tokenhared.token.WHILE, tokenhared.token.DEFAULT, tokenhared.token.CASE, tokenhared.token.MATCH, tokenhared.token.TO, tokenhared.token.LOOP, tokenhared.token.TRY, tokenhared.token.CATCH}
    Friend Const FLAGPERFIX As String = "YO_Flag_"
    Friend Const YOMAINCLASS As String = "YO_Main"
    Friend Const YOILLABEL As String = "YOIL_"
    Friend Const DOTNET As String = "dotnet"
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
    Friend Shared NOCACHE As Boolean = False
    Friend Shared DEVMOD As Boolean = False
    Friend Shared BENCHMARK As Boolean = False
    Friend Const RUNCMDDELAY As Integer = 500
    Friend Shared WAITILCODE As String = "call string [mscorlib]System.Console::ReadLine()
pop"
    Friend Const YOFORMATTEDSTRBYREGEX As String = "(#{\w+})|(#{\[.*?\]\})|(#{\w+::\w+})|(#{\w+\[.*?\]})"
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
    Friend Const PARAM_NOCACHE As String = "--no_cache"
    Friend Const PARAM_DEV As String = "--dev"
    Friend Const PARAM_BENCHMARK As String = "--benchmark"


    Friend Const ACCESSIBLE_PUBLIC As String = "public"
    Friend Const ACCESSIBLE_PRIVATE As String = "private"
    Friend Const OBJECTMODTYPE_STATIC As String = "static"
    Friend Const OBJECTMODTYPE_INSTANCE As String = "instance"

    Friend Const CONSTRUCTOR_METHOD As String = "ctor"
    Friend Const LOAD_FIRST_ARGUMENT As String = "ldarg.0"
    Friend Const [CLASS] As String = "class"
    Friend Const VALUETYPE As String = "valuetype"

    Friend Shared PROJECTFRAMEWORK, TARGETFRAMEWORK ,  PROJECTASSEMBLYNAME As String
    Friend Shared DOTNETVERSDK, DOTNETNAME As String
    Friend Shared CORELIB As String = "mscorlib"
    Friend Const SYSTEMRUNTIMELIB As String = "System.Runtime"

    Public Enum dotnetcorebridgestate
        success = 0
        dotnetcorenotfound = -1
        dotnetcoreversionnotfound = -2
    End Enum
End Class
