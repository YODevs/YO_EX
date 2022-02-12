﻿Imports System.Text.RegularExpressions
Imports Expr2CIL
Public Class expressiondt
    Dim _ilmethod As ilformat._ilmethodcollection
    Dim _datatype As String
    Dim _yocaexpr As Expr2CIL.Expr2CIL
    Dim _expression As String
    Dim arrstore As mapstoredata
    Public Sub New(ilmethod As ilformat._ilmethodcollection, datatype As String)
        Me._ilmethod = ilmethod
        Me._datatype = datatype
        Me._yocaexpr = New Expr2CIL.Expr2CIL
    End Sub

    Public Function parse_expression_data(expression As String, convtoi8 As Boolean) As ilformat._ilmethodcollection
        _expression = expression
        authfunc.rem_fr_and_en(expression)

        'example : 5 * ( 6 - 4 )
        If check_simple_expression(expression) AndAlso ilasmgen.classdata.attribute._cfg._optimize_expression = True Then
            Dim result As Object
            Dim dt As New DataTable
            If _datatype = "i32" Then
                result = dt.Compute(expression, Nothing)
                servinterface.ldc_i_checker(_ilmethod.codes, result, convtoi8, initcommondatatype.cdtype.find(Me._datatype).result)
            Else
                result = dt.Compute(expression, Nothing)
                servinterface.ldc_r_checker(_ilmethod.codes, result, convtoi8)
            End If

        Else
            remove_array_tokens(expression)
            Dim genilcode As String = _yocaexpr.CompileMsil(expression, _datatype)
            If ilasmgen.classdata.attribute._cfg._optimize_expression = True Then
                genilcode = expressionopt.optimize_expression(genilcode)
            End If

            For Each linec In genilcode.Split(vbLf)
                If linec.StartsWith(">") Then
                    Dim varname As String = linec.Remove(0, 1).Trim
                    Dim getdatatype As String = String.Empty
                    Dim getcildatatype As String = String.Empty
                    If varname.StartsWith(conrex.EXPRARRNAME) Then
                        Dim storeresult As mapstoredata.dataresult = arrstore.find(varname)
                        If storeresult.issuccessful Then
                            varname = storeresult.result
                            Dim clinecodestruc As New xmlunpkd.linecodestruc
                            clinecodestruc.tokenid = tokenhared.token.ARR
                            clinecodestruc.name = "ARR"
                            clinecodestruc.value = varname
                            varname = varname.Remove(varname.IndexOf(conrex.BRSTART))
                            'Load Array
                            If servinterface.is_variable(_ilmethod, varname, getdatatype) Then
                                servinterface.is_common_data_type(getdatatype, getcildatatype)
                                If getcildatatype = String.Empty Then getcildatatype = getdatatype
                                check_valid_dttype(getcildatatype, varname)
                                var.load_arr_identifier(_ilmethod, clinecodestruc, Nothing, getcildatatype)
                                Continue For
                            Else
                                'Set Error , Variable not founded.
                                dserr.args.Add(varname)
                                dserr.new_error(conserr.errortype.TYPENOTFOUND, -1, ilbodybulider.path, "Method : " & _ilmethod.name & " - Unknown identifier : " & varname)
                            End If
                        End If
                    End If
                    If servinterface.is_variable(_ilmethod, varname, getdatatype) Then
                        servinterface.is_common_data_type(getdatatype, getcildatatype)
                        If getcildatatype = String.Empty Then getcildatatype = getdatatype
                        check_valid_dttype(getcildatatype, varname)
                        illdloc.ld_identifier(varname, _ilmethod, Nothing, Nothing, getcildatatype)
                        conv_local_variable(getcildatatype)
                        Continue For
                    Else
                        'Set Error , Variable not founded.
                        dserr.args.Add(varname)
                        dserr.new_error(conserr.errortype.TYPENOTFOUND, -1, ilbodybulider.path, "Method : " & _ilmethod.name & " - Unknown identifier : " & varname)
                    End If
                End If
                cil.insert_il(_ilmethod.codes, linec)
            Next
        End If
        Return _ilmethod
    End Function

    Private Sub remove_array_tokens(ByRef experssion As String)
        If experssion.Contains(conrex.BRSTART) = False OrElse experssion.Contains(conrex.BREND) = False Then Return
        Dim matchdata As Match = Regex.Match(experssion, conrex.ARRMETHODREGEXEXPR)
        Dim rand As New Random
        arrstore = New mapstoredata
        While matchdata.Success = True
            Dim newvarname As String = conrex.EXPRARRNAME & rand.Next(1000, 9999) & rand.Next(100, 999)
            experssion = experssion.Replace(matchdata.Value, newvarname)
            arrstore.add(newvarname, matchdata.Value)
            matchdata = Regex.Match(experssion, conrex.ARRMETHODREGEXEXPR)
        End While
    End Sub
    Private Sub check_valid_dttype(getcildatatype As String, varname As String)
        For index = 0 To compdt.cilnumerictypes.Length - 1
            If compdt.cilnumerictypes(index) = getcildatatype Then
                Return
            End If
        Next
        servinterface.is_common_data_type(_datatype, _datatype)
        dserr.args.Add(getcildatatype)
        dserr.args.Add(_datatype)
        dserr.new_error(conserr.errortype.EXPLICITCONVERSION, -1, ilbodybulider.path, "Method : " & _ilmethod.name & " - Unknown identifier : " & varname & " , in " & _expression)
    End Sub

    Private Sub conv_local_variable(getdatatype As String)
        Select Case _datatype
            Case "i32"
                conv_local_to_i32(getdatatype)
            Case "f32"
                conv_local_to_f32(getdatatype)
        End Select
    End Sub

    Private Sub conv_local_to_f32(getdatatype As String)
        Select Case getdatatype
            Case "int32"
                cil.conv_to_float32(_ilmethod.codes)
            Case "int64"
                cil.conv_to_float64(_ilmethod.codes)
        End Select
    End Sub
    Private Sub conv_local_to_i32(getdatatype As String)
        Select Case getdatatype
            Case "float32"
                cil.conv_to_int32(_ilmethod.codes)
            Case "float64"
                cil.conv_to_int64(_ilmethod.codes)
        End Select
    End Sub
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
