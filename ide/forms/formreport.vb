Public Class formreport


    Private progresslist As New YOLIB.list
    Public isfail As Boolean = False
    Private Sub reptimer_Tick(sender As Object, e As EventArgs) Handles reptimer.Tick
        For index = 0 To progresslist.count - 1
            update_progressbar_value(progresslist.get(index))
            reporttext.AppendText(progresslist.get(index))
            reporttext.AppendText(vbCrLf)
        Next
        progresslist.clear()
    End Sub

    Private Sub update_progressbar_value(val As String)
        If val.Trim = String.Empty Then Return
        If val = "-end" Then
            If isfail = False Then Return
            progressbar.Text = "Error !"
        End If
        Select Case val.Trim
            Case "-Initialization & Process Preparation"
                progressbar.Value1 = 5
                Return
            Case "-Lexical Analyzer"
                progressbar.Value1 = 20
                Return
            Case "-Intermediate Code Generation"
                progressbar.Value1 = 45
                Return
            Case "-Assembly Code Generation"
                progressbar.Value1 = 70
                Return
            Case "-The overall result"
                progressbar.Value1 = 100
                Return
            Case "***** Operation completed successfully *****"
                Me.Close()
            Case Else
                If (val.StartsWith("Error Code :")) Then
                    isfail = True
                End If
        End Select
    End Sub

    Public Sub get_update(val As String)
        progresslist.add(val)
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Me.Close()
    End Sub
End Class
