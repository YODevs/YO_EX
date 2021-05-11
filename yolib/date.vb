Public Class [date]
    Private Const YEAR As String = "Y"
    Private Const MONTH As String = "M"
    Private Const DAY As String = "D"
    Private Const DAYOFWEEK As String = "DW"
    Private Const DAYOFYEAR As String = "DY"
    Private Const HOUR As String = "h"
    Private Const MINUTE As String = "m"
    Private Const SECOND As String = "s"
    Private Const MILLISECOND As String = "t"
    Private Const STARG As String = "{"
    Private Const ENARG As String = "}"

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
                Case STARG
                    getsingleformat = getch
                    activechargrabber = True
                Case ENARG
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
            Case YEAR
                setdate = DateTime.Now.Year
            Case MONTH
                setdate = DateTime.Now.Month
            Case DAY
                setdate = DateTime.Now.Day
            Case DAYOFWEEK
                setdate = DateTime.Now.DayOfWeek
            Case DAYOFYEAR
                setdate = DateTime.Now.DayOfYear
            Case HOUR
                setdate = DateTime.Now.Hour
            Case MINUTE
                setdate = DateTime.Now.Minute
            Case SECOND
                setdate = DateTime.Now.Second
            Case MILLISECOND
                setdate = DateTime.Now.Millisecond
        End Select
        Return setdate
    End Function
End Class
