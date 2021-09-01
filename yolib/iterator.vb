Public Class iterator
    Private clist As list
    Private count, index As Integer
    Public Sub New(clonelist As list)
        count = clonelist.count
        index = 0
        If IsNothing(clonelist) OrElse count = 0 Then Throw New Exception("The list is empty.")
        clist = clonelist
    End Sub
End Class
