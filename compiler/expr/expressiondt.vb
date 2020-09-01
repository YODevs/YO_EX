Imports Expr2CIL
Public Class expressiondt
    Dim _ilmethod As ilformat._ilmethodcollection
    Dim _datatype As String
    Dim _yocaexpr As Expr2CIL.Expr2CIL
    Public Sub New(ilmethod As ilformat._ilmethodcollection, datatype As String)
        Me._ilmethod = ilmethod
        Me._datatype = datatype
        Me._yocaexpr = New Expr2CIL.Expr2CIL
    End Sub

    Public Function parse_expression_data(expression As String, convtoi8 As Boolean) As ilformat._ilmethodcollection
        authfunc.rem_fr_and_en(expression)

        'example : 5 * ( 6 - 4 )
        If check_simple_expression(expression) AndAlso ilasmgen.classdata.attribute._cfg._optimize_expression = True Then
            Dim result As Object
            Dim dt As New DataTable
            If _datatype = "i32" Then
                result = dt.Compute(expression, Nothing)
                servinterface.ldc_i_checker(_ilmethod.codes, result, convtoi8)
            Else
                'f32 , f64 ...
            End If

        Else
            Dim genilcode As String = _yocaexpr.CompileMsil(expression, _datatype)
            For Each linec In genilcode.Split(vbCrLf)
                cil.insert_il(_ilmethod.codes, linec)
            Next
        End If
        Return _ilmethod
    End Function

    Private Function check_simple_expression(expression As String) As Boolean
        For index = 0 To expression.Length - 1
            If expression(index) = conrex.SPACE Then
                Continue For
            ElseIf check_action(expression(index)) Then
                Continue For
            ElseIf IsNumeric(expression(index)) Then
                Continue For
            ElseIf expression(index) = "(" OrElse expression(index) = ")" OrElse expression(index) = "." Then
                Continue For
            Else
                Return False
            End If
        Next
        Return True
    End Function

    Private Function check_action(exprchar As Char) As Boolean
        For index = 0 To compdt.expressionact.Length - 1
            If exprchar = compdt.expressionact(index) Then
                Return True
            End If
        Next
        Return False
    End Function
End Class
