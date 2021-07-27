Public Class matrix

    Private dt() As ArrayList
    Private gcolumnsize, growsize As Integer
    Private gisempty As Boolean = True
    Public columnseparator As String = Space(2)
    Public ReadOnly Property isempty() As Boolean
        Get
            Return gisempty
        End Get
    End Property
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
        gisempty = True
    End Sub
    Public Sub set_zero_matrix()
        clear_matrix()
        For index = 0 To gcolumnsize - 1
            For i2 = 0 To growsize - 1
                dt(index).Add(0)
            Next
        Next
        gisempty = False
    End Sub
    Public Sub set_unit_matrix()
        If gcolumnsize <> growsize Then Throw New Exception("Unit matrix should be a square matrix (for example, 3 * 3 or 2 * 2).")
        clear_matrix()
        Dim rowunit As Integer = 0
        For index = 0 To gcolumnsize - 1
            For i2 = 0 To growsize - 1
                If rowunit = i2 Then
                    dt(i2).Add(1)
                Else
                    dt(i2).Add(0)
                End If
            Next
            rowunit += 1
        Next
        gisempty = False
    End Sub
    Private Sub priv_set_scalar_matrix(val As Object)
        If gcolumnsize <> growsize Then Throw New Exception("Unit matrix should be a square matrix (for example, 3 * 3 or 2 * 2).")
        clear_matrix()
        Dim rowunit As Integer = 0
        For index = 0 To gcolumnsize - 1
            For i2 = 0 To growsize - 1
                If rowunit = i2 Then
                    dt(i2).Add(val)
                Else
                    dt(i2).Add(0)
                End If
            Next
            rowunit += 1
        Next
        gisempty = False
    End Sub
    Public Sub set_scalar_matrix(val As Integer)
        priv_set_scalar_matrix(val)
    End Sub
    Public Sub set_scalar_matrix(val As Double)
        priv_set_scalar_matrix(val)
    End Sub
    Public Function get_matrix() As String
        If gisempty Then Throw New Exception("The matrix is empty, you must first fill in the matrix values.")
        Dim result As String
        For index = 0 To growsize - 1
            For i2 = 0 To gcolumnsize - 1
                result &= dt(i2)(index).ToString & columnseparator
            Next
            If growsize - 1 <> index Then result &= vbCrLf
        Next
        Return result
    End Function
End Class
