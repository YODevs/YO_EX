Public Class iterator
    Private clist As list
    Private count, index As Integer
    Public Sub New(clonelist As list)
        count = clonelist.count
        index = 0
        If IsNothing(clonelist) OrElse count = 0 Then Throw New Exception("The list is empty.")
        clist = clonelist
    End Sub

    Public Function has_next() As Boolean
        Return (count > index + 1)
    End Function

    Public Function [next]() As String
        If has_next() Then
            index += 1
            Return clist.get(index)
        End If
        Throw New Exception("There is no item, with 'has_next()' function you can check the iterator values.")
    End Function

End Class
