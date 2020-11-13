Public Class localinitdata
    Friend datatypelocal As mapstoredata
    Friend datatypeparameter As mapstoredata
    Public Sub New()
        datatypelocal = New mapstoredata
        datatypeparameter = New mapstoredata
    End Sub

    Public Function check_local_init(name As String) As Boolean
        Return datatypelocal.find(name).issuccessful
    End Function

    Public Sub add_local_init(name As String, datatype As String)
        datatypelocal.add(name, datatype)
    End Sub

    Public Sub add_parameter(name As String, datatype As String)
        datatypeparameter.add(name, datatype)
    End Sub

    Public Sub import_parameter(method As tknformat._method)
        If IsNothing(method.parameters) = False Then
            For index = 0 To method.parameters.Length - 1
                add_parameter(method.parameters(index).name, method.parameters(index).ptype)
            Next
        End If
    End Sub
End Class
