Public Class matrix

    Private dt() As ArrayList
    Private gcolumnsize, growsize As Integer
    Private gisempty As Boolean = True
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
            Return growsize
        End Get
    End Property
    Public Shared Function unit_matrix(nsize As Integer) As matrix
        Dim nmatrix As New matrix(nsize, nsize)
        nmatrix.set_unit_matrix()
        Return nmatrix
    End Function
    Public Sub New(ncol As Integer, nrow As Integer)
        If ncol < 1 OrElse nrow < 1 Then
            Throw New Exception("Number of columns or rows must be more than zero.")
        End If
        gcolumnsize = ncol
        growsize = nrow
        init_columns()
        set_zero_matrix()
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
    Public Sub set_range_matrix(items As list)
        clear_matrix()
        If items.count < columnsize * rowsize Then
            Throw New Exception("The number of list items must be greater than or equal to the number of matrix items.")
        End If
        For index = 0 To gcolumnsize - 1
            For i2 = 0 To growsize - 1
                Dim item As String = items.pop_left
                If IsNumeric(item) Then
                    dt(index).Add(item)
                Else
                    Throw New Exception("List values must be numeric to be added to the matrix.")
                End If
            Next
        Next
        gisempty = False
    End Sub
    Public Sub set_unit_matrix()
        priv_set_scalar_matrix(1)
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
        Dim maxlengthindex As Integer = get_max_length()

        For index = 0 To growsize - 1
            For i2 = 0 To gcolumnsize - 1
                Dim value As String = dt(i2)(index).ToString
                result &= value & Space(maxlengthindex - dt(i2)(index).ToString.Length + 2)
            Next
            If growsize - 1 <> index Then result &= vbCrLf
        Next

        Return result
    End Function

    Private Function get_max_length() As Integer
        Dim maxlengthindex As Integer = 0
        For index = 0 To growsize - 1
            For i2 = 0 To gcolumnsize - 1
                Dim value As String = dt(i2)(index).ToString
                If value.Length > maxlengthindex Then maxlengthindex = value.Length
            Next
        Next
        Return maxlengthindex
    End Function

    Private Sub priv_set_item(columnindex As Integer, rowindex As Integer, value As Object)
        If gisempty Then Throw New Exception("The matrix is empty, you must first fill in the matrix values.")
        If columnindex >= gcolumnsize Then Throw New Exception("There is no column with this ID, reduce the index.")
        If rowindex >= growsize Then Throw New Exception("There is no row with this ID, reduce the index.")
        dt(columnindex).Insert(rowindex + 1, value)
        dt(columnindex).RemoveAt(rowindex)
    End Sub

    Public Sub set_item(columnindex As Integer, rowindex As Integer, value As Integer)
        priv_set_item(columnindex, rowindex, value)
    End Sub

    Public Sub set_item(columnindex As Integer, rowindex As Integer, value As Double)
        priv_set_item(columnindex, rowindex, value)
    End Sub

    Private Function priv_get_item(columnindex As Integer, rowindex As Integer) As Object
        If gisempty Then Throw New Exception("The matrix is empty, you must first fill in the matrix values.")
        If columnindex >= gcolumnsize Then Throw New Exception("There is no column with this ID, reduce the index.")
        If rowindex >= growsize Then Throw New Exception("There is no row with this ID, reduce the index.")
        Return dt(columnindex)(rowindex)
    End Function

    Private Function is_double(val As Object) As Boolean
        Return val.ToString.Contains(".")
    End Function

    Public Function get_item(columnindex As Integer, rowindex As Integer) As Integer
        Dim result As Integer = Convert.ToInt32(priv_get_item(columnindex, rowindex))
        Return result
    End Function

    Public Function get_item_f64(columnindex As Integer, rowindex As Integer) As Double
        Dim result As Double = Convert.ToDouble(priv_get_item(columnindex, rowindex))
        Return result
    End Function

    Public Function neg() As matrix
        If gisempty Then Throw New Exception("The matrix is empty, you must first fill in the matrix values.")
        Dim nmatrix As New matrix(gcolumnsize, growsize)
        nmatrix.set_zero_matrix()
        For index = 0 To gcolumnsize - 1
            For rindex = 0 To growsize - 1
                Dim item As Object = dt(index)(rindex)
                If is_double(item) Then
                    Dim valf32 As Double = Convert.ToDouble(item)
                    valf32 *= -1
                    nmatrix.set_item(index, rindex, valf32)
                Else
                    Dim vali32 As Integer = Convert.ToInt32(item)
                    vali32 *= -1
                    nmatrix.set_item(index, rindex, vali32)
                End If
            Next
        Next
        Return nmatrix
    End Function

    Public Function transpose() As matrix
        If gisempty Then Throw New Exception("The matrix is empty, you must first fill in the matrix values.")
        Dim nmatrix As New matrix(growsize, gcolumnsize)
        nmatrix.set_zero_matrix()
        For index = 0 To gcolumnsize - 1
            For rindex = 0 To growsize - 1
                Dim item As Object = dt(index)(rindex)
                nmatrix.set_item(rindex, index, item)
            Next
        Next
        Return nmatrix
    End Function
    Public Function [sub](matrix2 As matrix) As matrix
        If gisempty OrElse IsNothing(matrix2) Then Throw New Exception("The matrix is empty, you must first fill in the matrix values.")
        If columnsize <> matrix2.columnsize OrElse rowsize <> matrix2.rowsize Then
            Throw New Exception("A's(Matrix1) and B's(Matrix2) must be the same size")
        End If
        Dim nmatrix As New matrix(gcolumnsize, growsize)
        nmatrix.set_zero_matrix()
        For index = 0 To gcolumnsize - 1
            For rindex = 0 To growsize - 1
                Dim item As Double = CDbl(dt(index)(rindex)) - CDbl(matrix2.get_item_f64(index, rindex))
                nmatrix.set_item(index, rindex, item)
            Next
        Next
        Return nmatrix
    End Function
    Public Function add(matrix2 As matrix) As matrix
        If gisempty OrElse IsNothing(matrix2) Then Throw New Exception("The matrix is empty, you must first fill in the matrix values.")
        If columnsize <> matrix2.columnsize OrElse rowsize <> matrix2.rowsize Then
            Throw New Exception("A's(Matrix1) and B's(Matrix2) must be the same size")
        End If
        Dim nmatrix As New matrix(gcolumnsize, growsize)
        nmatrix.set_zero_matrix()
        For index = 0 To gcolumnsize - 1
            For rindex = 0 To growsize - 1
                Dim item As Double = CDbl(dt(index)(rindex)) + CDbl(matrix2.get_item_f64(index, rindex))
                nmatrix.set_item(index, rindex, item)
            Next
        Next
        Return nmatrix
    End Function
    Public Function multiply(val As Integer) As matrix
        Return priv_multiply(val, True)
    End Function

    Public Function multiply(val As Double) As matrix
        Return priv_multiply(val, False)
    End Function

    Public Function multiply(matrix2 As matrix) As matrix
        If gisempty OrElse IsNothing(matrix2) Then Throw New Exception("The matrix is empty, you must first fill in the matrix values.")
        If columnsize <> matrix2.rowsize Then
            Throw New Exception("A's(Matrix1) columns must equal B's(Matrix2) rows")
        End If
        Dim nmatrix As New matrix(matrix2.columnsize, growsize)
        nmatrix.set_zero_matrix()
        Dim result As New ArrayList
        For rindex = 0 To growsize - 1
            For pindex = 0 To matrix2.gcolumnsize - 1
                Dim singleresult As Double = 0
                For cindex = 0 To gcolumnsize - 1
                    singleresult += Convert.ToDouble(dt(cindex)(rindex) * matrix2.get_item(pindex, cindex))
                Next
                result.Add(singleresult)
            Next
        Next
        Dim counter As Integer = 0
        For nrindex = 0 To nmatrix.growsize - 1
            For ncindex = 0 To nmatrix.columnsize - 1
                nmatrix.set_item(ncindex, nrindex, result(counter))
                counter += 1
            Next
        Next
        Return nmatrix
    End Function

    Private Function priv_multiply(val As Object, isinteger As Boolean) As matrix
        If gisempty Then Throw New Exception("The matrix is empty, you must first fill in the matrix values.")
        Dim nmatrix As New matrix(gcolumnsize, growsize)
        nmatrix.set_zero_matrix()
        For index = 0 To gcolumnsize - 1
            For rindex = 0 To growsize - 1
                Dim item As Object = dt(index)(rindex)
                If is_double(item) Then
                    Dim valf32 As Double = Convert.ToDouble(item)
                    Dim scalarval As Double = Convert.ToDouble(val)
                    valf32 *= scalarval
                    nmatrix.set_item(index, rindex, valf32)
                Else
                    Dim vali32 As Integer = Convert.ToInt32(item)
                    Dim scalarval As Integer = Convert.ToInt32(val)
                    vali32 *= scalarval
                    nmatrix.set_item(index, rindex, vali32)
                End If
            Next
        Next
        Return nmatrix
    End Function
    Public Function get_list() As YOLIB.list
        Dim list As New YOLIB.list
        For rindex = 0 To growsize - 1
            For cindex = 0 To gcolumnsize - 1
                list.add(dt(cindex)(rindex))
            Next
        Next
        Return list
    End Function

    Private Function dt_to_matrix() As matrix
        Dim nmatrix As New matrix(gcolumnsize, growsize)
        nmatrix.set_zero_matrix()
        For index = 0 To gcolumnsize - 1
            For rindex = 0 To growsize - 1
                Dim item As Double = CDbl(dt(index)(rindex))
                nmatrix.set_item(index, rindex, item)
            Next
        Next
        Return nmatrix
    End Function
    Public Function avg() As Double
        Dim nmatrix As YOLIB.matrix = dt_to_matrix()
        Dim list As YOLIB.list = nmatrix.get_list()
        Dim result As Double = list.avg()
        Return result
    End Function

End Class
