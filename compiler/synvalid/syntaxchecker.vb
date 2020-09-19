Imports System.Text.RegularExpressions

Public Class syntaxchecker

    Public Shared Sub check_statement(clinecodestruc() As xmlunpkd.linecodestruc, statement As syntaxloader.statements)
        If clinecodestruc.Count <> syntaxloader.syntploader(statement).exptokenslist.Count Then
            dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(0).line, ilbodybulider.path, syntaxloader.syntploader(statement).statename & " - The structural form of the command is invalid.", syntaxloader.syntploader(statement).example)
        End If

        For index = 0 To clinecodestruc.Length - 1
            If syntaxloader.syntploader(statement).exptokenslist(index).ToString.Contains(conrex.CMA) Then
                Dim resultproc As Boolean = False
                Dim tokens() As String
                tokens = Regex.Split(syntaxloader.syntploader(statement).exptokenslist(index), conrex.CMA)
                For prindex = 0 To tokens.Length - 1
                    If clinecodestruc(index).tokenid = tokens(prindex) Then
                        resultproc = True
                        Exit For
                    End If
                Next
                If resultproc = False Then
                    dserr.args.Add(syntaxloader.syntploader(statement).statename)
                    Dim gettokenvalue As String = get_tokens_name(tokens)
                    dserr.args.Add(gettokenvalue)
                    dserr.new_error(conserr.errortype.EXPECTSYNTAX, clinecodestruc(index).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(index)), clinecodestruc(index).value), syntaxloader.syntploader(statement).example)
                End If
            Else
                If clinecodestruc(index).tokenid <> syntaxloader.syntploader(statement).exptokenslist(index) Then
                    dserr.args.Add(syntaxloader.syntploader(statement).statename)
                    Dim gettokenvalue As String = tokenhared.tokenid_to_value(syntaxloader.syntploader(statement).exptokenslist(index))
                    If gettokenvalue = "NP" Then
                        gettokenvalue = [Enum].GetName(GetType(tokenhared.token), syntaxloader.syntploader(statement).exptokenslist(index))
                    End If
                    dserr.args.Add(gettokenvalue)
                    dserr.new_error(conserr.errortype.EXPECTSYNTAX, clinecodestruc(index).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(index)), clinecodestruc(index).value), syntaxloader.syntploader(statement).example)
                End If
            End If
        Next
    End Sub

    Private Shared Function get_tokens_name(tokens() As String) As String
        Dim rettokennames As String = String.Empty
        For index = 0 To tokens.Length - 1
            Dim gettokenvalue As String = tokenhared.tokenid_to_value(CInt(tokens(index)))
            If gettokenvalue = "NP" Then
                tokens(index) = [Enum].GetName(GetType(tokenhared.token), CInt(tokens(index)))
            End If
            If rettokennames = String.Empty Then
                rettokennames = tokens(index)
            Else
                rettokennames &= " | " & tokens(index)
            End If
        Next
        Return rettokennames
    End Function
End Class
