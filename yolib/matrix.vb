Public Class matrix

    Private dt() As ArrayList
    Private gcolumnsize, growsize As Integer
    Public ReadOnly Property columnsize() As Integer
        Get
            Return gcolumnsize
        End Get
    End Property
    Public ReadOnly Property rowsize() As Integer
        Get
            Return rowsize
        End Get
    End Property
    Public Sub New(ncol As Integer, nrow As Integer)
        If ncol < 1 OrElse nrow < 1 Then
            Throw New Exception("Number of columns or rows must be more than zero.")
        End If
        gcolumnsize = ncol
        growsize = nrow
        init_columns()
    End Sub
    Private Sub init_columns()
        Array.Resize(dt, gcolumnsize)
        For index = 0 To gcolumnsize - 1
            dt(index) = New ArrayList
        Next
    End Sub
End Class
