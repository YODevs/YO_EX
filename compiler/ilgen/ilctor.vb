Public Class ilctor
    Private _ilmethod As ilformat._ilmethodcollection
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_new_ctor(index As Integer, clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        Dim classindex, namespaceindex As Integer
        Dim classname As String = _illocalinit(index).datatype
        If libserv.get_extern_index_class(classname, namespaceindex, classindex) = -1 Then
            dserr.args.Add("Class " & classname & " not found.")
            dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), classname))
        End If
        Return _ilmethod
    End Function
End Class
