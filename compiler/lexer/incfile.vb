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

    Friend Shared Sub add_new_path(path As String)
        Dim addpath As Boolean = True
        For index = 0 To incspath.Count - 1
            If incspath(index).ToString = path Then
                addpath = False
                Exit For
            End If
        Next
        If addpath Then incspath.Add(path)
    End Sub
    Public Shared Sub set_new_include_source(ByRef includelist As ArrayList, value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf)
        linecodeinf = linecinf
        If rd_token = tokenhared.token.TYPE_CO_STR OrElse rd_token = tokenhared.token.TYPE_DU_STR OrElse rd_token = tokenhared.token.IDENTIFIER Then
            If rd_token <> tokenhared.token.IDENTIFIER Then authfunc.rem_fr_and_en(value)
            Dim inc As New incstruct
            set_include_struct_data(inc, value)
            check_route_repetition(inc)
            If inc.replist = False Then
                incspath.Add(inc.path)
                incsname.Add(inc.name)
            End If
            includelist.Add(inc.path)
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
            get_path_include_file(inc)
        End If
    End Sub

    Private Shared Sub check_route_repetition(ByRef inc As incstruct)
        For index = 0 To incspath.Count - 1
            If incspath(index).ToString.ToLower = inc.path.ToLower Then
                inc.replist = True
                Return
            End If
        Next
        inc.replist = False
        Return
    End Sub
    Private Shared Sub get_path_include_file(ByRef inc As incstruct)
        If File.Exists(conrex.APPDIR & "\std\" & inc.name) Then
            inc.path = conrex.APPDIR & "\std\" & inc.name
            inc.isexist = True
        ElseIf File.Exists(conrex.ENVCURDIR & cprojdt.get_val("assetspath") & conrex.BKSLASH & inc.name) Then
            inc.path = conrex.ENVCURDIR & cprojdt.get_val("assetspath") & conrex.BKSLASH & inc.name
            inc.isexist = True
        Else
            dserr.args.Add(String.Format("'{0}' This file does not exist in the specified paths.", inc.name))
            dserr.new_error(conserr.errortype.INCLUDEERROR, linecodeinf.line, lexer.wfile, Nothing)
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
