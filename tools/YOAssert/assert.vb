Public Class assert
    Private Shared bfishandlecreated As Boolean = False
    Private Shared formreportunittest As New reportunittest
    Private th As New System.Threading.Thread(AddressOf formreportunittest.ShowDialog)

    Public Sub New()
    End Sub
    Private Sub show_report_form()
        If formreportunittest.IsHandleCreated = False AndAlso bfishandlecreated = False Then
            th.SetApartmentState(Threading.ApartmentState.MTA)
            th.Start()
            bfishandlecreated = True
        Else
            Threading.Thread.Sleep(15)
            formreportunittest.dtreport.AutoResizeColumns()
        End If
    End Sub
    Private Sub recheck_output_color()
        Dim ipass, ifail As Int16
        ipass = 0
        ifail = 0
        For index = 0 To formreportunittest.dtreport.Rows.Count - 2
            If formreportunittest.dtreport.Rows.Item(index).Cells(4).Value = "Passed" Then
                ipass += 1
                formreportunittest.dtreport.Rows.Item(index).Cells(4).ToolTipText = "Pass Test"
            Else
                ifail += 1
                formreportunittest.dtreport.Rows.Item(index).Cells(4).ErrorText = "Failed Test"
            End If
        Next
        formreportunittest.passlabelstatus.Text = ipass & " Passed"
        formreportunittest.failedlabelstatus.Text = ifail & " Failed"
    End Sub

    Public Sub is_true(id As String, realresult As String, idealresult As String)
        show_report_form()
        Dim result As String = "Failed"
        If idealresult = realresult Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "Equal", result)
        recheck_output_color()
    End Sub


    Public Sub is_false(id As String, realresult As String, idealresult As String)
        show_report_form()
        Dim result As String = "Failed"
        If idealresult <> realresult Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "UnEqual", result)
        recheck_output_color()
    End Sub


    Public Sub contains(id As String, realresult As String, idealresult As String)
        show_report_form()
        Dim result As String = "Failed"
        If realresult.Contains(idealresult) Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "Contains", result)
        recheck_output_color()
    End Sub

    Public Sub starts_with(id As String, realresult As String, idealresult As String)
        show_report_form()
        Dim result As String = "Failed"
        If realresult.StartsWith(idealresult) Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "StartsWith", result)
        recheck_output_color()
    End Sub

    Public Sub ends_with(id As String, realresult As String, idealresult As String)
        show_report_form()
        Dim result As String = "Failed"
        If realresult.EndsWith(idealresult) Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "EndsWith", result)
        recheck_output_color()
    End Sub

    Public Sub regex(id As String, input As String, pattern As String)
        show_report_form()
        Dim result As String = "Failed"
        If System.Text.RegularExpressions.Regex.IsMatch(input, pattern) Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, input, "Regex:'" & pattern & "'", "Regex", result)
        recheck_output_color()
    End Sub

    Public Sub is_equal(id As String, realresult As Integer, idealresult As Integer)
        show_report_form()
        Dim result As String = "Failed"
        If realresult = idealresult Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "Equal - Numeric", result)
        recheck_output_color()
    End Sub
    Public Sub is_greater(id As String, realresult As Integer, idealresult As Integer)
        show_report_form()
        Dim result As String = "Failed"
        If realresult > idealresult Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "Greater", result)
        recheck_output_color()
    End Sub

    Public Sub is_greater_Equal(id As String, realresult As Integer, idealresult As Integer)
        show_report_form()
        Dim result As String = "Failed"
        If realresult >= idealresult Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "Greater / Equal", result)
        recheck_output_color()
    End Sub

    Public Sub is_less(id As String, realresult As Integer, idealresult As Integer)
        show_report_form()
        Dim result As String = "Failed"
        If realresult < idealresult Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "Less", result)
        recheck_output_color()
    End Sub

    Public Sub is_less_equal(id As String, realresult As Integer, idealresult As Integer)
        show_report_form()
        Dim result As String = "Failed"
        If realresult <= idealresult Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "Less / Equal", result)
        recheck_output_color()
    End Sub

#Region "Float32"
    Public Sub is_equal(id As String, realresult As Single, idealresult As Single)
        show_report_form()
        Dim result As String = "Failed"
        If realresult = idealresult Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "Equal - Numeric", result)
        recheck_output_color()
    End Sub
    Public Sub is_greater(id As String, realresult As Single, idealresult As Single)
        show_report_form()
        Dim result As String = "Failed"
        If realresult > idealresult Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "Greater", result)
        recheck_output_color()
    End Sub

    Public Sub is_greater_equal(id As String, realresult As Single, idealresult As Single)
        show_report_form()
        Dim result As String = "Failed"
        If realresult >= idealresult Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "Greater / Equal", result)
        recheck_output_color()
    End Sub

    Public Sub is_less(id As String, realresult As Single, idealresult As Single)
        show_report_form()
        Dim result As String = "Failed"
        If realresult < idealresult Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "Less", result)
        recheck_output_color()
    End Sub

    Public Sub is_less_equal(id As String, realresult As Single, idealresult As Single)
        show_report_form()
        Dim result As String = "Failed"
        If realresult <= idealresult Then
            result = "Passed"
        End If
        formreportunittest.dtreport.Rows.Add(id, realresult, idealresult, "Less / Equal", result)
        recheck_output_color()
    End Sub
#End Region

End Class
