Public Class cillazychecker

    Structure resultlazycheck
        Dim result As Boolean
        Dim errtext As String
    End Structure
    Friend Shared Function lazy_check(cline As String) As resultlazycheck
        Dim retresult As New resultlazycheck
        retresult.result = True
        check_line(retresult, cline)
        If retresult.result = False Then Return retresult

        check_keyword(retresult, cline)
        If retresult.result = False Then Return retresult

        '...

        Return retresult
    End Function

    Friend Shared Function check_keyword(ByRef retresult As resultlazycheck, cline As String) As Boolean
        Dim exckey() As String = cline.Split(Space(1))
        For index = 0 To ciltoken.cilinstruct.Length - 1
            If ciltoken.cilinstruct(index).keyword.ToLower = exckey(0).ToLower Then
                If ciltoken.cilinstruct(index).keyword = exckey(0) Then
                    retresult.result = True
                    Return True
                Else
                    retresult.result = False
                    retresult.errtext = exckey(0) & " - The intermediate language is to the form of sensitive commands. , Did you mean '" & ciltoken.cilinstruct(index).keyword & "'?"
                    Return False
                End If
            End If
        Next


        retresult.result = False
        retresult.errtext = exckey(0) & " - This command could not be found."
        Return False

    End Function

    Friend Shared Sub check_line(ByRef retresult As resultlazycheck, ByRef cline As String)
        If cline.StartsWith("YOIL_") Then
            If cline.Contains(":") Then
                cline = cline.Remove(0, cline.IndexOf(":")).Trim
            Else
                retresult.result = False
                retresult.errtext = cline & " - The line tag is incorrect."
            End If
        End If
    End Sub
End Class
