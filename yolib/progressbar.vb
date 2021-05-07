Public Class progressbar
    Private currentcursortop As Integer
    Private progressbarval, progresschars() As String
    Private progressenabled As Boolean = False
    Private getrandom As New Random(0)
    Public progress As Integer = 0
    Public progresschar As Char = "="
    Public isenabled As Boolean = True
    Public spaceprogresschar As Char = "-"
    Public Sub New()
    End Sub

    Public Sub show_progress()
        currentcursortop = Console.CursorTop
        progressbarval = "[" & Space(50) & "]"
        Console.WriteLine(progressbarval)
        progressenabled = True
        progresschars = {"\", "|", "/", "-", "\", "|", "/", "-", "*"}
    End Sub
    Public Sub increase()
        If progress = 100 OrElse progressenabled = False Then
            Return
        End If
        Console.CursorTop = currentcursortop
        progress += 1
        Dim gtcurrhalf As Integer = progress / 2
        Dim dtr As New String(progresschar, gtcurrhalf)
        Dim drr As New String(spaceprogresschar, 50 - gtcurrhalf)
        If isenabled Then
            progressbarval = "[" & dtr & drr & "]" & progresschars(getrandom.Next(0, 9)) & Space(1) & progress & "%  "
        Else
            progressbarval = "[" & dtr & drr & "]"
        End If
        Console.WriteLine(progressbarval)
    End Sub
    Public Sub decrease()
        If progress = 0 Or progressenabled = False Then
            Return
        End If
        Console.CursorTop = currentcursortop
        progress -= 1
        Dim getcurrhalf As Integer = progress / 2
        Dim dtr As New String(progresschar, getcurrhalf)
        Dim drr As New String(spaceprogresschar, 50 - getcurrhalf)
        If isenabled Then
            progressbarval = "[" & dtr & drr & "]" & progresschars(getrandom.Next(0, 9)) & Space(1) & progress & "%"
        Else
            progressbarval = "[" & dtr & drr & "]"
        End If
        Console.WriteLine(progressbarval & Space(5))
    End Sub

    Public Sub hide_progress()
        If progressenabled = False Then
            Return
        End If
        Console.CursorTop = currentcursortop
        Console.WriteLine(Space(progressbarval.Length + 2))
    End Sub

    Public Sub reset_progress()
        progress = 0
    End Sub
End Class
