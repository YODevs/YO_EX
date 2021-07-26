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
    Public Sub clear_matrix()
        For index = 0 To gcolumnsize - 1
            dt(index).Clear()
        Next
    End Sub
    Public Sub set_zero_matrix()
        For index = 0 To gcolumnsize - 1
            For i2 = 0 To growsize - 1
                dt(index).Add(0)
            Next
        Next
    End Sub
End Class
