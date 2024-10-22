﻿Public Class [date]
    Private Const YEAR As String = "Y"
    Private Const MONTH As String = "M"
    Private Const DAY As String = "D"
    Private Const DAYOFWEEK As String = "DW"
    Private Const DAYOFYEAR As String = "DY"
    Private Const HOUR As String = "h"
    Private Const MINUTE As String = "m"
    Private Const SECOND As String = "s"
    Private Const MILLISECOND As String = "t"
    Private Const TICKS As String = "ti"
    Private Const STARG As String = "{"
    Private Const ENARG As String = "}"
    Private xdate As DateTime

    ''' <summary>
    ''' Return date and time in arbitrary format.
    ''' </summary>
    ''' <param name="format">Primary date format</param>
    ''' <returns>String</returns>
    Public Shared Function get_now(format As String) As String
        If format = Nothing Then Return DateTime.Now 'Return with default format
        Return lex_format(format, "getnow")
    End Function

    Public Shared Function utc_now(format As String) As String
        If format = Nothing Then Return DateTime.UtcNow 'Return with default format
        Return lex_format(format, "utcnow")
    End Function

    Private Shared Function lex_format(format As String, typeofdate As String, Optional customdate As DateTime = Nothing)
        Dim activechargrabber As Boolean = False
        Dim getsingleformat As String = String.Empty
        Dim formatteddate As String = format
        Dim fdate As Date = DateTime.Now
        If typeofdate = "utcnow" Then fdate = DateTime.UtcNow
        If IsNothing(customdate) = False AndAlso typeofdate = String.Empty Then fdate = customdate
        For Each getch As Char In format
            Select Case getch
                Case STARG
                    getsingleformat = getch
                    activechargrabber = True
                Case ENARG
                    activechargrabber = False
                    getsingleformat &= getch
                    'Validation and replacement in elementary history format
                    formatteddate = formatteddate.Replace(getsingleformat, check_single_format(getsingleformat, fdate))
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

    Private Shared Function check_single_format(singleformat As String, fdate As Date) As String
        Dim setdate As String = singleformat
        singleformat = singleformat.Remove(0, 1)
        singleformat = singleformat.Remove(singleformat.Length - 1)
        singleformat = singleformat.Trim

        'Identify constant expressions in string
        Select Case singleformat
            Case YEAR
                setdate = fdate.Year
            Case MONTH
                setdate = fdate.Month
            Case DAY
                setdate = fdate.Day
            Case DAYOFWEEK
                setdate = fdate.DayOfWeek
            Case DAYOFYEAR
                setdate = fdate.DayOfYear
            Case HOUR
                setdate = fdate.Hour
            Case MINUTE
                setdate = fdate.Minute
            Case SECOND
                setdate = fdate.Second
            Case MILLISECOND
                setdate = fdate.Millisecond
            Case TICKS
                setdate = fdate.Ticks
        End Select
        Return setdate
    End Function

    Public Sub New(utcdate As Boolean)
        xdate = New DateTime
        If utcdate Then
            xdate = DateTime.UtcNow
        Else
            xdate = DateTime.Now
        End If
    End Sub
    Public Sub add_years(val As Integer)
        xdate = xdate.AddYears(val)
    End Sub
    Public Sub add_months(val As Integer)
        xdate = xdate.AddMonths(val)
    End Sub
    Public Sub add_days(val As Integer)
        xdate = xdate.AddDays(val)
    End Sub
    Public Sub add_hours(val As Integer)
        xdate = xdate.AddHours(val)
    End Sub
    Public Sub add_minutes(val As Integer)
        xdate = xdate.AddMinutes(val)
    End Sub
    Public Sub add_seconds(val As Integer)
        xdate = xdate.AddSeconds(val)
    End Sub
    Public Sub add_milliseconds(val As Integer)
        xdate = xdate.AddMilliseconds(val)
    End Sub
    Public Sub add_ticks(val As Integer)
        xdate = xdate.AddTicks(val)
    End Sub
    Public Function [get](format As String) As String
        Return lex_format(format, String.Empty, xdate)
    End Function
End Class
