Public Class timer
    Private Shared headlabel As String = String.Empty
    Friend Shared Sub set_new_timer(ByRef ilmethod As ilformat._ilmethodcollection)
        Dim interval As Integer = methodattr.get_attribute_by_i32(ilmethod, compdt.INTERVAL, compdt.DEFVALINTERVAL)
        gen_header_code(ilmethod)
        gen_footer_code(ilmethod, interval)
    End Sub

    Private Shared Sub gen_footer_code(ByRef ilmethod As ilformat._ilmethodcollection, interval As Integer)
        Dim param As New ArrayList
        param.Add("int32")
        cil.push_int32_onto_stack(ilmethod.codes, interval)
        cil.call_extern_method(ilmethod.codes, conrex.VOID, compdt.CORELIB, "System.Threading.Thread", "Sleep", param)
        cil.branch_to_target(ilmethod.codes, headlabel)
    End Sub

    Private Shared Sub gen_header_code(ByRef ilmethod As ilformat._ilmethodcollection)
        headlabel = lngen.get_line_prop("timer")
        If ilmethod.codes.Count > 0 Then
            ilmethod.codes.Insert(0, String.Format("{0}:", headlabel))
        Else
            lngen.set_direct_label(headlabel, ilmethod.codes)
        End If
    End Sub
End Class
