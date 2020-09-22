Public Class compdt
    Friend Shared i8cmtypes() As String = {"int64", "uint64", "valuetype [mscorlib]System.Decimal"}
    Friend Shared expressionact() As String = {"+", "-", "/", "*"}
    Friend Shared expressionactopt() As String = {"add", "sub", "div", "mul"}
    Friend Shared blockopallow() As tokenhared.token = {tokenhared.token.TO}
    Friend Const flagperfix As String = "YO_Flag_"
    Friend Const yomainclass As String = "YO_Main"
End Class
