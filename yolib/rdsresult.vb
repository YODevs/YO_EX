Public Class rdsresult
    Private cols, dt() As ArrayList
    Private iter As Integer = -1
    Public Sub New(data() As ArrayList, columns As ArrayList)
        dt = data
        cols = columns
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

    Public Function [get](index As Integer) As String
        Return CStr(dt(iter)(index))
    End Function

    Public Function get_i64(index As Integer) As Int64
        Return CLng(dt(iter)(index))
    End Function

    Public Function get_i32(index As Integer) As Int32
        Return CInt(dt(iter)(index))
    End Function

    Public Function get_f64(index As Integer) As Double
        Return CDbl(dt(iter)(index))
    End Function

    Public Function get_f32(index As Integer) As Single
        Return CSng(dt(iter)(index))
    End Function

    Public Function get_bool(index As Integer) As Boolean
        Return CBool(dt(iter)(index))
    End Function

    Public Function get_obj(index As Integer) As Object
        Return dt(iter)(index)
    End Function




End Class
