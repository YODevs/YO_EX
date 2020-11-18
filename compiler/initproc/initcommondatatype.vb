Public Class initcommondatatype

    Friend Shared cdtype As New mapstoredata
    Friend Shared Sub init_common_data_type()
        For index = 0 To conrex.yocommondatatype.Length - 1
            cdtype.add(conrex.yocommondatatype(index), conrex.msilcommondatatype(index))
        Next
    End Sub

    Friend Shared Sub init_ptr_bind()
        compdt.ptrinddata = New mapstoredata
        compdt.ptrinddata.add("int8", "i1")
        compdt.ptrinddata.add("int16", "i2")
        compdt.ptrinddata.add("int32", "i4")
        compdt.ptrinddata.add("int64", "i8")
        compdt.ptrinddata.add("float32", "r4")
        compdt.ptrinddata.add("float64", "r8")
        compdt.ptrinddata.add("uint8", "u1")
        compdt.ptrinddata.add("uint16", "u2")
        compdt.ptrinddata.add("uint32", "u4")
        compdt.ptrinddata.add("uint64", "u8")
    End Sub

End Class
