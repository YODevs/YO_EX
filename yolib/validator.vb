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
        If str.Length = 0 Then Return False
        For i = 0 To str.Length - 1
            If str(i) = " " Then Continue For Else Return False
        Next
        Return True
    End Function
    Public Shared Function is_numeric(str As String) As Boolean
        If str.Length = 0 Then Return False
        For i = 0 To str.Length - 1
            If Char.IsNumber(str(i)) = False Then Return False
        Next
        Return True
    End Function
    Public Shared Function is_uppercase(str As String) As Boolean
        If str.Length = 0 Then Return False
        Dim loweredstr As String = str.ToLower
        For i = 0 To str.Length - 1
            If str(i) = loweredstr(i) And str(i) <> " " Then Return False Else Continue For
        Next
        Return True
    End Function
    Public Shared Function is_lowercase(str As String) As Boolean
        If str.Length = 0 Then Return False
        Dim upperedstr As String = str.ToUpper
        For i = 0 To str.Length - 1
            If str(i) = upperedstr(i) And str(i) <> " " Then Return False Else Continue For
        Next
        Return True
    End Function
    Public Shared Function is_hexadecimal(str As String) As Boolean
        If str.Length = 0 Then Return False
        Return System.Text.RegularExpressions.Regex.IsMatch(str, "\A\b[0-9a-fA-F]+\b\Z")
    End Function
    Public Shared Function is_email(str As String) As Boolean
        If str.Length = 0 Then Return False
        Try
            Dim address As New System.Net.Mail.MailAddress(str)
            Return address.Address = str
        Catch
            Return False
        End Try
    End Function
    Public Shared Function is_date(str As String) As Boolean
        If str.Length = 0 Then Return False
        If Char.IsNumber(str(0)) = False Or Char.IsNumber(str(str.Length - 1)) = False Then Return False
        Dim result As DateTime
        Return DateTime.TryParse(str, result)
    End Function
    Public Shared Function is_integer32(str As String) As Boolean
        If str.Length = 0 Then Return False
        If str.Contains(" ") = True Then Return False
        Dim i As Integer
        Return System.Int32.TryParse(str, i)
    End Function
    Public Shared Function is_integer64(str As String) As Boolean
        If str.Length = 0 Then Return False
        If str.Contains(" ") = True Then Return False
        Dim i As Int64
        Return System.Int64.TryParse(str, i)
    End Function
    Public Shared Function is_float32(str As String) As Boolean
        If str.Length = 0 Then Return False
        If str.Contains(" ") = True Then Return False
        Dim s As Single
        Return System.Single.TryParse(str, s)
    End Function
    Public Shared Function is_bool(str As String) As Boolean
        If str.Length = 0 Then Return False
        If str.Contains(" ") = True Then Return False
        If str.ToLower() = "true" Or str.ToLower() = "false" Then Return True Else Return False
    End Function
    Public Shared Function is_strong_password(str As String) As Boolean
        Dim minlength As Integer = 8
        Dim hasnum, hassymbol, hasletter As Boolean
        If str.Length < minlength Then Return False
        If str.Length >= minlength Then
            Dim symbols As list = New list()
            symbols.add_with_split("!,@,#,$,%,^,&,*,(,),~,\,|,<,>,/,?,+,=,-", ",")
            For i = 0 To str.Length - 1
                For listindex = 0 To symbols.count - 1
                    If str(i) = symbols.get(listindex) Then hassymbol = True Else Continue For
                    If hassymbol = True Then Exit For Else Continue For
                Next
            Next
            For i = 0 To str.Length - 1
                If Char.IsNumber(str(i)) = True Then hasnum = True Else Continue For
                If hasnum = True Then Exit For Else Continue For
            Next
            For i = 0 To str.Length - 1
                If Char.IsLetter(str(i)) = True Then hasletter = True Else Continue For
                If hasletter = True Then Exit For Else Continue For
            Next
            If hasnum And hasletter And hassymbol = True Then Return True Else Return False
        End If
    End Function
End Class
