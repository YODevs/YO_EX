Imports System.IO

Public Class encoding

    Public Shared Function utf8_get_bytes(value As String) As Byte()
        Return System.Text.Encoding.UTF8.GetBytes(value)
    End Function
    Public Shared Function utf8_get_string(value As Byte()) As String
        Return System.Text.Encoding.UTF8.GetString(value)
    End Function
    Public Shared Function utf32_get_bytes(value As String) As Byte()
        Return System.Text.Encoding.UTF32.GetBytes(value)
    End Function
    Public Shared Function utf32_get_string(value As Byte()) As String
        Return System.Text.Encoding.UTF32.GetString(value)
    End Function
    Public Shared Function ascii_get_bytes(value As String) As Byte()
        Return System.Text.Encoding.ASCII.GetBytes(value)
    End Function
    Public Shared Function ascii_get_string(value As Byte()) As String
        Return System.Text.Encoding.ASCII.GetString(value)
    End Function

    Public Shared Function unicode_get_bytes(value As String) As Byte()
        Return System.Text.Encoding.Unicode.GetBytes(value)
    End Function
    Public Shared Function unicode_get_string(value As Byte()) As String
        Return System.Text.Encoding.Unicode.GetString(value)
    End Function
End Class
