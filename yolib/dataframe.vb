Public Class dataframe

    Dim title As String = "Dataframe Form"
    Dim dtgrtl As Boolean = False
    Dim form As dataframeform
    Dim cfont As font
    Public Sub New()
        form = New dataframeform
    End Sub

    Public Property formtitle() As String
        Get
            Return title
        End Get
        Set(ByVal value As String)
            title = value
        End Set
    End Property

    Public Property rtl() As Boolean
        Get
            Return dtgrtl
        End Get
        Set(ByVal value As Boolean)
            dtgrtl = value
        End Set
    End Property

    Public Property [font]() As font
        Get
            Return cfont
        End Get
        Set(ByVal obj As font)
            cfont = obj
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

    Public Sub show(dt As rdsresult)
        check_object(dt)
        Dim columns() As String = dt.columnslist.to_str
        If IsNothing(columns) Then
            Throw New Exception("No column found.")
        End If

        Dim columncount As Integer = columns.Length - 1
        For index = 0 To columncount
            form.dtg.Columns.Add(String.Format("col_{0}", index), columns(index))
        Next

        While dt.read
            Dim values(columncount) As Object
            For index = 0 To columncount
                values(index) = dt.get(index)
            Next
            form.dtg.Rows.Add(values)
        End While

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

    Public Sub show(dt As list)
        check_object(dt)
        form.dtg.Columns.Add("col_Items", "Items")
        Dim listcount As Integer = dt.count - 1
        For index = 0 To listcount
            form.dtg.Rows.Add(New Object() {dt.get(index)})
        Next
        form.typeofstruct = "list"
        form.ShowDialog()
    End Sub
    Public Sub show(dt As matrix)
        check_object(dt)
        Dim columncount As Integer = dt.columnsize - 1
        For index = 0 To columncount
            form.dtg.Columns.Add(String.Format("col_{0}", index), String.Empty)
        Next
        Dim rowcount As Integer = dt.rowsize - 1
        For index = 0 To rowcount
            Dim values(columncount) As Object
            For index2 = 0 To columncount
                values(index2) = dt.get_item_f64(index2, index)
            Next
            form.dtg.Rows.Add(values)
        Next
        form.typeofstruct = "matrix"
        form.ShowDialog()
    End Sub
    Private Sub check_object(dt As Object)
        If IsNothing(dt) Then
            Throw New Exception("Object Reference Not Set to an instance of an object.")
        End If
        form = New dataframeform
        form.Text = title
        If rtl = True Then
            form.dtg.RightToLeft = Windows.Forms.RightToLeft.Yes
        Else
            form.dtg.RightToLeft = Windows.Forms.RightToLeft.No
        End If
        If IsNothing(cfont) = False Then
            form.dtg.DefaultCellStyle.Font = cfont.font
        End If
    End Sub
End Class
