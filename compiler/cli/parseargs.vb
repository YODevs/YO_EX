''' <summary>
''' <en>
'''
''' </en>
''' <fa>
''' این کلاس وظیفه تجزیه و تحلیل آرگومان های ورودی کامپایلر را دارد
''' </fa>
''' </summary>
Public Class parseargs

    Structure _parseresult
        Dim command As String
        Dim args As ArrayList
    End Structure
    Friend Shared Sub parse_data(args() As String)
        Dim parseresult As New _parseresult
        parseresult.args = New ArrayList
        Dim instr As Boolean = False
        Dim argval As String = String.Empty
        Dim optval As String = String.Empty
        For index = 0 To args.Length - 1
            argval = args(index)
            If index = 0 Then
                parseresult.command = argval
                Continue For
            Else
                If instr = True AndAlso argval.EndsWith(conrex.DUSTR) Then
                    instr = False
                    optval &= conrex.SPACE & argval
                    parseresult.args.Add(optval)
                ElseIf instr = True Then
                    optval &= conrex.SPACE & argval
                ElseIf instr = False AndAlso argval.StartsWith(conrex.DUSTR) Then
                    instr = True
                    optval = argval
                Else
                    parseresult.args.Add(argval)
                End If
            End If
        Next

        execln.nv_check_command(parseresult)
    End Sub
End Class
