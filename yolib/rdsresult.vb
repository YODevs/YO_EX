Public Class rdsresult
    Public columnslist As list
    Private cols, dt() As ArrayList
    Private iter As Integer = -1
    Public Sub New(data() As ArrayList, columns As ArrayList)
        dt = data
        cols = columns
        columnslist = New list
        For index = 0 To columns.Count - 1
            columnslist.add(columns(index))
        Next
    End Sub

    Public ReadOnly Property count() As Integer
        Get
            If IsNothing(dt) = True Then Return 0
            Return dt.Length
        End Get
    End Property

    Public ReadOnly Property read() As Boolean
        Get
            If iter + 1 >= dt.Length Then
                Return False
            Else
                iter += 1
                Return True
            End If
        End Get
    End Property

    Public Sub [next]()
        iter += 1
    End Sub

    Private Function find_index(name As String) As Integer
        Dim colcount As Integer = cols.Count - 1
        For index = 0 To colcount
            If name = cols(index).ToString Then
                Return index
            End If
        Next
        Throw New Exception(String.Format("'{0}' , This column was not found.", name))
    End Function
    Public Function [get](name As String) As String
        Return [get](find_index(name))
    End Function

    Public Function [get](index As Integer) As String
        Return CStr(dt(iter)(index))
    End Function

    Public Function get_i64(name As String) As Int64
        Return get_i64(find_index(name))
    End Function
    Public Function get_i64(index As Integer) As Int64
        Return CLng(dt(iter)(index))
    End Function

    Public Function get_i32(name As String) As Int32
        Return get_i32(find_index(name))
    End Function
    Public Function get_i32(index As Integer) As Int32
        Return CInt(dt(iter)(index))
    End Function

    Public Function get_f64(name As String) As Double
        Return get_f64(find_index(name))
    End Function
    Public Function get_f64(index As Integer) As Double
        Return CDbl(dt(iter)(index))
    End Function

    Public Function get_f32(name As String) As Single
        Return get_f32(find_index(name))
    End Function
    Public Function get_f32(index As Integer) As Single
        Return CSng(dt(iter)(index))
    End Function

    Public Function get_bool(name As String) As Boolean
        Return get_bool(find_index(name))
    End Function
    Public Function get_bool(index As Integer) As Boolean
        Return CBool(dt(iter)(index))
    End Function

    Public Function get_obj(name As String) As Object
        Return get_obj(find_index(name))
    End Function
    Public Function get_obj(index As Integer) As Object
        Return dt(iter)(index)
    End Function




End Class
