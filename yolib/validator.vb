Public Class validator

    Public Shared Function is_equals(str As String, comparison As String) As Boolean
        If str = comparison Then Return True Else Return False
    End Function
    Public Shared Function is_alpha(str As String) As Boolean
        If str.Length = 0 Then Return False
        For i = 0 To str.Length - 1
            If Char.IsLetter(str(i)) = False Then Return False
        Next
        Return True
    End Function
    Public Shared Function is_alpha_numeric(str As String) As Boolean
        Dim hasnum As Boolean
        Dim hasletter As Boolean
        For i = 0 To str.Length - 1
            If Char.IsLetter(str(i)) = False And Char.IsNumber(str(i)) = False Then Return False Else Continue For
        Next
        For i = 0 To str.Length - 1
            If Char.IsNumber(str(i)) = True Then hasnum = True Else Continue For
            If hasnum = True Then Exit For Else Continue For
        Next
        For i = 0 To str.Length - 1
            If Char.IsLetter(str(i)) = True Then hasletter = True Else Continue For
            If hasletter = True Then Exit For Else Continue For
        Next
        If hasletter = True And hasnum = True Then Return True Else Return False
    End Function
    Public Shared Function is_empty(str As String) As Boolean
        If str.Length = 0 Then Return True Else Return False
    End Function
    Public Shared Function is_whitespace(str As String) As Boolean
        For i = 0 To str.Length - 1
            If str(i) = " " Then Continue For Else Return False
        Next
        Return True
    End Function

End Class
