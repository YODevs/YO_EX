Public Class libserv

    Friend Shared Function find_extern_name(name As String) As Boolean
        Return libreg.assemblymap.find(name, True).issuccessful
    End Function

    Friend Shared Function get_extern_index_class(ByRef classname As String, ByRef namespaceptr As Integer, ByRef classptr As Integer) As Integer
        Dim classchename As String = String.Empty
        Dim resultclassindex As mapstoredata.dataresult = libreg.externtypes.find(classname, True, classchename)
        If resultclassindex.issuccessful Then
            classname = classchename
            Dim spdata As String = resultclassindex.result
            namespaceptr = spdata.Remove(spdata.IndexOf(conrex.CMA))
            classptr = spdata.Remove(0, spdata.IndexOf(conrex.CMA) + 1)
            Return 1
        Else
            Return -1
        End If
    End Function

    Friend Shared Function get_extern_index_method(ByRef funcname As String, namespaceindex As Integer, classindex As Integer) As Integer
        For Each method In libreg.types(namespaceindex)(classindex).GetMethods()
            If method.Name.ToLower = funcname.ToLower Then
                funcname = method.Name
                Return 1
            End If
        Next
        Return -1
    End Function

End Class
