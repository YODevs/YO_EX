Public Class expressionopt

    Structure exprstaticdt
        Dim frilcode As String
        Dim frnumber As Object
        Dim nxilcode As String
        Dim nxnumber As Object
        Dim computeexpr As Boolean
        Dim action As String
        Dim ilcode As String
    End Structure

    Private Shared exprdt As New exprstaticdt
    Private Shared gencode As String = String.Empty
    Friend Shared Function optimize_expression(genilcode As String) As String
        For Each linec In genilcode.Split(vbLf)
            linec = linec.Trim
            If linec = Nothing Then Continue For
            gencode &= vbCrLf & linec
            If linec.StartsWith(">") Then
                exprdt.frilcode = String.Empty
                Continue For
            End If

            If is_action(linec) Then
                If exprdt.computeexpr Then
                    exprdt.action = linec
                    compute()
                End If
                reset_expr_static()
            Else
                check_expression(linec)
            End If
        Next

        Return gencode
    End Function

    Private Shared Sub compute()
        Dim result As Object
        Dim dt As New DataTable
        Dim code As String = String.Empty
        Dim expression As String = exprdt.frnumber & get_sym_action() & exprdt.nxnumber
        result = dt.Compute(expression, Nothing)
        gen_il_expression(result)

        code = exprdt.frilcode & conrex.SPACE & exprdt.frnumber
        code &= vbCrLf & exprdt.nxilcode & conrex.SPACE & exprdt.nxnumber
        code &= vbCrLf & exprdt.action

        gencode = gencode.Replace(code, exprdt.ilcode.Trim)
    End Sub

    Private Shared Sub gen_il_expression(value As Object)
        If exprdt.frilcode.StartsWith("ldc.i") Then
            If value.ToString.Length > 10 AndAlso CDec(value) > Int32.MaxValue Or CDec(value) < Int32.MinValue Then
                add_il_code(exprdt.frilcode & conrex.SPACE & CDec(value))
                add_il_code("conv.i8")
            Else
                add_il_code(exprdt.frilcode & conrex.SPACE & CDec(value))
            End If
        ElseIf exprdt.frilcode.StartsWith("ldc.r") Then
            If value > Single.MaxValue Or value < Single.MinValue Then
                add_il_code(exprdt.frilcode & conrex.SPACE & CDbl(value))
            Else
                add_il_code(exprdt.frilcode & conrex.SPACE & CSng(value))
            End If
        End If
    End Sub

    Private Shared Sub add_il_code(code As String)
        exprdt.ilcode &= vbCrLf & code
    End Sub
    Private Shared Function get_sym_action() As String
        Select Case exprdt.action
            Case "add"
                Return "+"
            Case "sub"
                Return "-"
            Case "div"
                Return "/"
            Case "mul"
                Return "*"
        End Select
        Return "+"
    End Function
    Friend Shared Function is_action(linec As String) As Boolean
        For index = 0 To compdt.expressionactopt.Length - 1
            If linec = compdt.expressionactopt(index) Then Return True
        Next
        Return False
    End Function

    Private Shared Sub check_expression(linec As String)
        If linec.StartsWith("ldc.") Then
            If linec.StartsWith("ldc.i") Then
                'ldc.i4 / ldc.i8
                If exprdt.frilcode = String.Empty Then
                    exprdt.frnumber = linec.Remove(0, linec.IndexOf(conrex.SPACE) + 1)
                    exprdt.frilcode = linec.Remove(linec.IndexOf(conrex.SPACE))
                Else
                    exprdt.nxnumber = linec.Remove(0, linec.IndexOf(conrex.SPACE) + 1)
                    exprdt.nxilcode = linec.Remove(linec.IndexOf(conrex.SPACE))
                    If exprdt.nxilcode = exprdt.frilcode Then exprdt.computeexpr = True
                End If
                Return
            Else
                'ldc.r4 / ldc.r8
                If exprdt.frilcode = String.Empty Then
                    exprdt.frnumber = linec.Remove(0, linec.IndexOf(conrex.SPACE) + 1)
                    exprdt.frilcode = linec.Remove(linec.IndexOf(conrex.SPACE))
                Else
                    exprdt.nxnumber = linec.Remove(0, linec.IndexOf(conrex.SPACE) + 1)
                    exprdt.nxilcode = linec.Remove(linec.IndexOf(conrex.SPACE))
                    If exprdt.nxilcode = exprdt.frilcode Then exprdt.computeexpr = True
                End If
                Return
            End If
        End If

        'Reset struct
        reset_expr_static()
    End Sub

    Private Shared Sub reset_expr_static()
        exprdt = Nothing
    End Sub
End Class
