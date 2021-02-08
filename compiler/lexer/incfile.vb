Imports System.IO
Imports YOCA

Public Class incfile
    Friend Shared incspath, incsname As ArrayList
    Private Shared linecodeinf As lexer.targetinf
    Structure incstruct
        Dim name As String
        Dim path As String
        Dim isexist As Boolean
        Dim replist As Boolean
    End Structure
    Public Shared Sub set_new_include_source(ByRef includelist As ArrayList, value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf)
        linecodeinf = linecinf
        If rd_token = tokenhared.token.TYPE_CO_STR OrElse rd_token = tokenhared.token.TYPE_DU_STR Then
            authfunc.rem_fr_and_en(value)
            Dim inc As New incstruct
            set_include_struct_data(inc, value)
        Else
            dserr.args.Add("Unexpected Tokens Use the string to analyze the Include statement.")
            dserr.new_error(conserr.errortype.INCLUDEERROR, linecinf.line, lexer.wfile, Nothing, "include 'ystdio'")
        End If
    End Sub

    Private Shared Sub set_include_struct_data(ByRef inc As incstruct, value As String)
        If value.ToLower.Contains(conrex.YOFORMAT) = False Then value &= conrex.YOFORMAT
        If value.Contains(conrex.BKSLASH) Then
            inc.path = value
            inc.name = value.Remove(0, value.LastIndexOf(conrex.BKSLASH) + 1)
            check_exist_include_file(inc.path)
        Else
            inc.name = value
        End If
    End Sub

    Private Shared Sub check_exist_include_file(path As String)
        If File.Exists(path) = False Then
            dserr.args.Add(String.Format("'{0}' path not found.[include statement]", path))
            dserr.new_error(conserr.errortype.INCLUDEERROR, linecodeinf.line, lexer.wfile, Nothing)
        End If
    End Sub

    Friend Shared Sub init()
        incsname = New ArrayList
        incspath = New ArrayList
    End Sub
End Class
