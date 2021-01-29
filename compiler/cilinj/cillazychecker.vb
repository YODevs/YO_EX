Public Class cillazychecker

    Structure resultlazycheck
        Dim result As Boolean
        Dim errtext As String
    End Structure
    ''' <summary>
    ''' <en>
    ''' 
    ''' </en>
    ''' <fa>
    ''' بررسی توکن ها و ساختار کد های CIL به صورت Lazy mode
    ''' </fa>
    ''' </summary>
    Friend Shared Function lazy_check(cline As String) As resultlazycheck
        Dim retresult As New resultlazycheck
        retresult.result = True
        check_line(retresult, cline)
        If retresult.result = False Then Return retresult
        If cline.Trim = Nothing Then Return retresult

        If cline.Contains("//") Then
            cline = cline.Remove(cline.IndexOf("//")).Trim
        End If

        check_keyword(retresult, cline)
        If retresult.result = False Then Return retresult

        '...

        Return retresult
    End Function

    ''' <summary>
    ''' <en>
    ''' 
    ''' </en>
    ''' <fa>
    ''' بررسی توکن ها و دستورات زبان میانی مایکروسافت
    ''' </fa>
    ''' </summary>
    ''' <returns></returns>
    Friend Shared Function check_keyword(ByRef retresult As resultlazycheck, cline As String) As Boolean
        If cline.Trim = Nothing Then
            retresult.result = True
            Return True
        End If
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

    ''' <summary>
    ''' <en>
    ''' 
    ''' </en>
    ''' <fa>
    ''' بررسی لیبل های کد میانی مایکروسافت
    ''' لیبل ها CIL باید با YOIL_ شروع شوند
    ''' </fa>
    ''' </summary>
    Friend Shared Sub check_line(ByRef retresult As resultlazycheck, ByRef cline As String)
        If cline.StartsWith(compdt.YOILLABEL) Then
            If cline.Contains(conrex.CLN) Then
                cline = cline.Remove(0, cline.IndexOf(conrex.CLN) + 1).Trim
            Else
                retresult.result = False
                retresult.errtext = cline & " - The line tag is incorrect."
            End If
        End If
    End Sub
End Class
