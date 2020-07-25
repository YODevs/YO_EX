Imports System.IO

Public Class authfunc
    Public Shared Function get_line_code(path As String, line As Integer) As String
        If File.Exists(path) Then
            Dim fsource As String = File.ReadAllText(path)
            Dim splsource() As String = fsource.Split(Chr(10)).ToArray
            If line <= splsource.Length - 1 Then
                Return splsource(line)
            Else
                'Error...
            End If
        Else
            dserr.new_error(conserr.errortype.YOFILENOTFOUND, "path => " & path)
            Return conrex.NULL
        End If
        Return conrex.NULL
    End Function
End Class
