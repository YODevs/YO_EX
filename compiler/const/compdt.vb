Public Class compdt
    Friend Shared i8cmtypes() As String = {"int64", "uint64", "valuetype [mscorlib]System.Decimal"}
    Friend Shared expressionact() As String = {"+", "-", "/", "*"}
    Friend Shared expressionactopt() As String = {"add", "sub", "div", "mul"}
    Friend Shared errcap() As String = {"Error:", "error code="}
    Friend Shared blockopallow() As tokenhared.token = {tokenhared.token.TO, tokenhared.token.LOOP}
    Friend Const FLAGPERFIX As String = "YO_Flag_"
    Friend Const YOMAINCLASS As String = "YO_Main"
    Friend Const DISPLAYILASMOUTPUT As Boolean = False
    Friend Const DISPLAYTOKENWLEX As Boolean = False
    Friend Const DISPLAYSTACKTRACE As Boolean = False
    Friend Const RUNCMDDELAY As Integer = 500
    Friend Const WAITILCODE As String = "call string [mscorlib]System.Console::ReadLine()
pop"
    Friend Const PARAM_IMPASSETS As String = "--import_assets"
End Class
