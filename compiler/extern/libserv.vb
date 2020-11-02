Public Class libserv

    Friend Shared Function find_extern_name(name As String) As Boolean
        Return libreg.assemblymap.find(name, True).issuccessful
    End Function
End Class
