Imports System.Text.RegularExpressions

Public Class fmtstrlit
    'Formatted String Literal
    Private Shared paramcount As Integer = 0
    Friend Shared Function action(ByRef ilmethod As ilformat._ilmethodcollection, value As String, cargcodestruc As xmlunpkd.linecodestruc) As Boolean
        If value.Contains("#") AndAlso Regex.Match(value, compdt.YOFORMATTEDSTRBYREGEX).Success Then
            paramcount = 0
            authfunc.rem_fr_and_en(value)
            Dim regexresult As MatchCollection = Regex.Matches(value, compdt.YOFORMATTEDSTRBYREGEX)
            For index = 0 To regexresult.Count - 1
                Dim result As String = regexresult(index).Value
                Dim ldstrvalue As String = value.Remove(value.IndexOf(result))
                value = value.Remove(0, value.IndexOf(result) + result.Length)
                load_string(ilmethod, ldstrvalue, cargcodestruc)
                result = result.Remove(0, 2)
                result = result.Remove(result.Length - 1)
                load_identifier(ilmethod, result, cargcodestruc)
            Next
            If value <> conrex.NULL Then
                load_string(ilmethod, value, cargcodestruc, True)
                paramcount += 1
                set_concat(ilmethod)
            ElseIf paramcount <> 0 Then
                set_concat(ilmethod)
            End If
            Return True
        End If
        Return False
    End Function

    Private Shared Sub set_concat(ByRef ilmethod As ilformat._ilmethodcollection)
        cil.concat(ilmethod.codes, "string", paramcount - 1)
        paramcount = 0
    End Sub
    Private Shared Sub load_identifier(ByRef ilmethod As ilformat._ilmethodcollection, varname As String, cargcodestruc As xmlunpkd.linecodestruc)
        Dim getdatatype As String = String.Empty
        If servinterface.is_variable(ilmethod, varname, getdatatype) Then
            illdloc.ld_identifier(varname, ilmethod, cargcodestruc, Nothing, getdatatype)
            If servinterface.is_cil_common_data_type(getdatatype) Then
                conv_to_string(ilmethod, getdatatype)
                paramcount += 1
                If paramcount = 4 Then
                    set_concat(ilmethod)
                End If
            Else
                dserr.args.Add(getdatatype)
                dserr.args.Add("CIL COMMON DATA-TYPE")
                dserr.new_error(conserr.errortype.EXPLICITCONVERSION, cargcodestruc.line, ilbodybulider.path, "Method : " & ilmethod.name & " - identifier : " & varname & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
            End If
        Else
            'Set warning
            load_string(ilmethod, "#[" & varname & "]", cargcodestruc)
        End If
    End Sub

    Friend Shared Sub conv_to_string(ByRef ilmethod As ilformat._ilmethodcollection, datatype As String)
        If datatype.ToLower = "string" Then Return
        cil.convert_to_string(ilmethod.codes, datatype)
    End Sub
    Private Shared Sub load_string(ByRef ilmethod As ilformat._ilmethodcollection, value As String, cargcodestruc As xmlunpkd.linecodestruc, Optional lastproc As Boolean = False)
        cil.load_string(ilmethod, value, cargcodestruc)
        paramcount += 1
        If lastproc = False AndAlso paramcount = 4 Then
            set_concat(ilmethod)
        End If
    End Sub
End Class
