Public Class iterator
    Private clist As list
    Private count, privindex As Integer

    Public Property index() As Integer
        Get
            Return privindex
        End Get
        Set(ByVal value As Integer)
            If value >= 0 AndAlso count > privindex Then
                privindex = value
            Else
                Throw New Exception(value & " - The index is invalid.")
            End If
        End Set
    End Property

    Public Sub New(clonelist As list)
        count = clonelist.count
        privindex = 0
        If IsNothing(clonelist) OrElse count = 0 Then Throw New Exception("The list is empty.")
        clist = clonelist
    End Sub

    Public Function has_next() As Boolean
        Return (count > privindex)
    End Function

    Public Function [next]() As String
        If has_next() Then
            Dim result As String = clist.get(privindex)
            privindex += 1
            Return result
        End If
        Throw New Exception("There is no item, with 'has_next()' function you can check the iterator values.")
    End Function

End Class
