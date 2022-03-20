Public Class dataframe

    Dim form As dataframeform
    Public Sub New()
        form = New dataframeform
    End Sub

    Public Property formtitle() As String
        Get
            Return form.Text
        End Get
        Set(ByVal value As String)
            form.Text = value
        End Set
    End Property

    Public Sub show(dt As csv)
        check_object(dt)
        show(dt.get_rds)
    End Sub

    Public Sub show(dt As rds)
        check_object(dt)
        Dim columns() As String = dt.getcolumns
        If IsNothing(columns) Then
            Throw New Exception("No column found.")
        End If

        Dim columncount As Integer = columns.Length - 1
        For index = 0 To columncount
            form.dtg.Columns.Add(String.Format("col_{0}", index), columns(index))
        Next

        Dim rowcount As Integer = dt.rowcount - 1
        For index = 0 To rowcount
            Dim row As list = dt.get_row_list(index)
            Dim values(columncount) As Object
            For index2 = 0 To columncount
                values(index2) = row.get(index2)
            Next
            form.dtg.Rows.Add(values)
        Next
        form.typeofstruct = "rds"
        form.ShowDialog()
    End Sub

    Public Sub show(dt As map)
        check_object(dt)
        form.dtg.Columns.Add("col_keys", "Keys")
        form.dtg.Columns.Add("col_values", "Values")
        Dim mapsize As Integer = dt.size - 1
        For index = 0 To mapsize
            Dim key, value As String
            dt.get_map(index, key, value)
            form.dtg.Rows.Add(New Object() {key, value})
        Next
        form.typeofstruct = "map"
        form.ShowDialog()
    End Sub

    Private Sub check_object(dt As Object)
        If IsNothing(dt) Then
            Throw New Exception("Object Reference Not Set to an instance of an object.")
        End If
        form = New dataframeform
    End Sub
End Class
