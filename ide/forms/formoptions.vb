Imports System.IO

Public Class formoptions


    ''' <summary>
    ''' keywords button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        File.WriteAllText(conrex.EXTENSIONDIR & "keywords.yoda", rlistofkeywords.Text)
        restart_ide()
    End Sub

    ''' <summary>
    ''' datatypes button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RadButton2_Click(sender As Object, e As EventArgs) Handles RadButton2.Click
        File.WriteAllText(conrex.EXTENSIONDIR & "datatypes.yoda", rlistofdatatypes.Text)
        restart_ide()
    End Sub

    ''' <summary>
    ''' operators button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RadButton3_Click(sender As Object, e As EventArgs) Handles RadButton3.Click
        File.WriteAllText(conrex.EXTENSIONDIR & "operators.yoda", rlistofoperators.Text)
        restart_ide()
    End Sub

    ''' <summary>
    ''' constant button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RadButton4_Click(sender As Object, e As EventArgs) Handles RadButton4.Click
        File.WriteAllText(conrex.EXTENSIONDIR & "constants.yoda", rlistofconstant.Text)
        restart_ide()
    End Sub


    Private Sub RadButton5_Click(sender As Object, e As EventArgs) Handles RadButton5.Click
        File.WriteAllText(conrex.EXTENSIONDIR & "modifiers.yoda", rlistofmodifiers.Text)
        restart_ide()
    End Sub

    Private Sub restart_ide()
        If MsgBox("Do you want to restart Visual YO to see the syntax changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Application.Restart()
        End If
    End Sub

    Private Sub load_extension()
        Try
            rlistofkeywords.Text = File.ReadAllText(conrex.EXTENSIONDIR & "keywords.yoda")
            rlistofdatatypes.Text = File.ReadAllText(conrex.EXTENSIONDIR & "datatypes.yoda")
            rlistofoperators.Text = File.ReadAllText(conrex.EXTENSIONDIR & "operators.yoda")
            rlistofconstant.Text = File.ReadAllText(conrex.EXTENSIONDIR & "constants.yoda")
            rlistofmodifiers.Text = File.ReadAllText(conrex.EXTENSIONDIR & "modifiers.yoda")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub fromoptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_extension()
    End Sub

    Private Sub chlistparameters_ItemCheckedChanged(sender As Object, e As Telerik.WinControls.UI.ListViewItemEventArgs) Handles chlistparameters.ItemCheckedChanged
        buildparamtext.Text = String.Empty
        runparamtext.Text = String.Empty
        For index = 0 To chlistparameters.Items.Count - 1
            If chlistparameters.Items(index).CheckState = Telerik.WinControls.Enumerations.ToggleState.On Then
                Dim val As String = chlistparameters.Items(index).Value
                If val.Contains("| [Run] ") Then
                    val = val.Remove(val.IndexOf("|")).Trim
                    runparamtext.Text &= val & " "
                ElseIf val.Contains("| [Build] ") Then
                    val = val.Remove(val.IndexOf("|")).Trim
                    buildparamtext.Text &= val & " "
                Else
                    val = val.Remove(val.IndexOf("|")).Trim
                    buildparamtext.Text &= val & " "
                    runparamtext.Text &= val & " "
                End If
            End If
        Next
    End Sub

    Private Sub RadButton6_Click(sender As Object, e As EventArgs) Handles RadButton6.Click
        File.WriteAllText(conrex.EXTENSIONDIR & "runparams", runparamtext.Text)
        File.WriteAllText(conrex.EXTENSIONDIR & "buildparams", buildparamtext.Text)
        MsgBox("Data has been saved successfully.", MsgBoxStyle.Information)
    End Sub
End Class
