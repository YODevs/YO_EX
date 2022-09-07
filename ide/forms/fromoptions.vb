Imports System.IO

Public Class fromoptions


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
        File.WriteAllText(conrex.EXTENSIONDIR & "constant.yoda", rlistofconstant.Text)
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
            rlistofconstant.Text = File.ReadAllText(conrex.EXTENSIONDIR & "constant.yoda")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub fromoptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_extension()
    End Sub
End Class
