Public Class localinitdata
    Friend datatypelocal As mapstoredata
    Public Sub New()
        datatypelocal = New mapstoredata
    End Sub

    Public Function check_local_init(name As String) As Boolean
        name = name.ToLower
        Return datatypelocal.find(name).issuccessful
    End Function

    Public Sub add_local_init(name As String, datatype As String)
        name = name
        datatype = datatype
        datatypelocal.add(name, datatype)
    End Sub
End Class
