Imports YOCA

Public Class localinitdata
    Friend datatypelocal As mapstoredata
    Friend datatypeparameter As mapstoredata
    Friend Shared fieldst As mapstoredata
    Public Sub New()
        datatypelocal = New mapstoredata
        datatypeparameter = New mapstoredata
    End Sub

    Public Function check_local_init(name As String) As Boolean
        If fieldst.find(name.ToLower, True).issuccessful Then Return True
        Return datatypelocal.find(name.ToLower, True).issuccessful
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

    Friend Shared Sub import_fields(fields() As tknformat._pubfield)
        fieldst = New mapstoredata
        If IsNothing(fields) Then Return
        For index = 0 To fields.Length - 1
            fieldst.add(fields(index).name, fields(index).ptype)
        Next
    End Sub
    Friend Shared Sub import_fields(varname As String, datatype As String)
        fieldst.add(varname, datatype)
    End Sub
End Class
