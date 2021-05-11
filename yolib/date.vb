Public Class [date]
    ''' <summary>
    ''' Return date and time in arbitrary format.
    ''' </summary>
    ''' <param name="format">Primary date format</param>
    ''' <returns>String</returns>
    Public Shared Function get_now(format As String) As String
        If format = Nothing Then Return DateTime.Now 'Return with default format
        Dim activechargrabber As Boolean = False
        Dim getsingleformat As String = String.Empty
        Dim formatteddate As String = format
        For Each getch As Char In format
            Select Case getch
                Case "{"
                    getsingleformat = getch
                    activechargrabber = True
                Case "}"
                    activechargrabber = False
                    getsingleformat &= getch
                    'Validation and replacement in elementary history format
                    formatteddate = formatteddate.Replace(getsingleformat, check_single_format(getsingleformat))
                    getsingleformat = String.Empty
                Case Else
                    If activechargrabber Then
                        getsingleformat &= getch
                        Continue For
                    End If
            End Select
        Next
        Return formatteddate
    End Function

    Private Shared Function check_single_format(singleformat As String) As String
        Dim setdate As String = singleformat
        singleformat = singleformat.Remove(0, 1)
        singleformat = singleformat.Remove(singleformat.Length - 1)
        singleformat = singleformat.Trim

        'Identify constant expressions in string
        Select Case singleformat
            Case "Y"
                setdate = DateTime.Now.Year
            Case "M"
                setdate = DateTime.Now.Month
            Case "D"
                setdate = DateTime.Now.Day
            Case "DW"
                setdate = DateTime.Now.DayOfWeek
            Case "DY"
                setdate = DateTime.Now.DayOfYear
            Case "h"
                setdate = DateTime.Now.Hour
            Case "m"
                setdate = DateTime.Now.Minute
            Case "s"
                setdate = DateTime.Now.Second
            Case "t"
                setdate = DateTime.Now.Millisecond
            Case Else
                Return Nothing
        End Select
        Return setdate
    End Function
End Class
