Public Class initcommondatatype

    Friend Shared cdtype As New mapstoredata
    Friend Shared Sub init_common_data_type()
        For index = 0 To conrex.yocommondatatype.Length - 1
            cdtype.add(conrex.yocommondatatype(index), conrex.msilcommondatatype(index))
        Next
    End Sub
End Class
