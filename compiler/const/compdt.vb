Public Class compdt
    Friend Shared i8cmtypes() As String = {"int64", "uint64", "valuetype [mscorlib]System.Decimal"}
    Friend Shared expressionact() As String = {"+", "-", "/", "*"}
    Friend Shared expressionactopt() As String = {"add", "sub", "div", "mul"}
    Friend Shared blockopallow() As tokenhared.token = {tokenhared.token.TO}
    Friend Const FLAGPERFIX As String = "YO_Flag_"
    Friend Const YOMAINCLASS As String = "YO_Main"
    Friend Const DISPLAYILASMOUTPUT As Boolean = False
    Friend Const DISPLAYTOKENWLEX As Boolean = False
End Class
