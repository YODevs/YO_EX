Public Class stjmper
    Private Shared path As String
    Private Shared jmpslist() As stjmperlist
    Private Shared indexarray As Int16 = 0

    Private Structure stjmperlist
        Dim tokenid As tokenhared.token
        Dim endblockln As String
        Dim startblockln As String
        Dim headblockln As String
    End Structure
    Friend Shared Sub reset_method(filepath As String)
        path = filepath
    End Sub

    Friend Shared Sub init()
        jmpslist = Nothing
        indexarray = 0
    End Sub
    Public Shared Sub set_new_jmper(tokenid As tokenhared.token, endblockln As String, startblockln As String, Optional headblockln As String = conrex.NULL)
        Array.Resize(jmpslist, indexarray + 1)
        jmpslist(indexarray) = New stjmperlist
        jmpslist(indexarray).tokenid = tokenid
        jmpslist(indexarray).endblockln = endblockln
        jmpslist(indexarray).startblockln = startblockln
        jmpslist(indexarray).headblockln = headblockln
        indexarray += 1
        Return
    End Sub
    Public Shared Sub repeat_jmper(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.REPEAT)
        Dim getindex As Integer = find_statement(clinecodestruc(1).tokenid)
        If getindex = -1 Then
            dserr.new_error(conserr.errortype.CONTINUEERROR, clinecodestruc(0).line, path, "Repeat statement not within a loop." & vbCrLf & authfunc.get_line_error(path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End If
        cil.branch_to_target(_ilmethod.codes, jmpslist(getindex).headblockln)
    End Sub

    Public Shared Sub continue_jmper(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.CONTINUE)
        Dim getindex As Integer = find_statement(clinecodestruc(1).tokenid)
        If getindex = -1 Then
            dserr.new_error(conserr.errortype.CONTINUEERROR, clinecodestruc(0).line, path, "Continue statement not within a loop." & vbCrLf & authfunc.get_line_error(path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End If
        cil.branch_to_target(_ilmethod.codes, jmpslist(getindex).startblockln)
    End Sub

    Public Shared Sub break_jmper(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection)
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.BREAK)
        Dim getindex As Integer = find_statement(clinecodestruc(1).tokenid)
        If getindex = -1 Then
            dserr.new_error(conserr.errortype.BREAKERROR, clinecodestruc(0).line, path, "Break statement not within a loop." & vbCrLf & authfunc.get_line_error(path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End If
        If clinecodestruc(1).tokenid = tokenhared.token.TRY Then
            cil.leave(_ilmethod.codes, jmpslist(getindex).endblockln)
        Else
            cil.branch_to_target(_ilmethod.codes, jmpslist(getindex).endblockln)
        End If
    End Sub

    Public Shared Sub reset_jmper(tokenid As tokenhared.token)
        Dim getindex As Integer = find_statement(tokenid)
        If getindex = -1 Then Return
        jmpslist(getindex) = Nothing
    End Sub
    Private Shared Function find_statement(tokenid As tokenhared.token) As Integer
        If IsNothing(jmpslist) OrElse jmpslist.Length = 0 Then Return -1
        For index = jmpslist.Length - 1 To 0 Step -1
            If jmpslist(index).tokenid = tokenid Then
                Return index
            End If
        Next
        Return -1
    End Function
End Class
