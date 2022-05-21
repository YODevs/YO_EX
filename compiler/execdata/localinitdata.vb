Imports YOCA

Public Class localinitdata
    Friend datatypelocal As mapstoredata
    Friend datatypeparameter As mapstoredata
    Friend Shared fieldst As mapstoredata
    Public Sub New()
        datatypelocal = New mapstoredata
        datatypeparameter = New mapstoredata
    End Sub

    Public Function check_local_init(name As String, linecodestruc As xmlunpkd.linecodestruc) As Boolean
        check_type_name(name, linecodestruc)
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
                check_type_name(method.parameters(index).name, method.parameters(index).dtypetargetinfo)
                add_parameter(method.parameters(index).name, method.parameters(index).ptype)
            Next
        End If
    End Sub

    Friend Shared Sub import_fields(fields() As tknformat._pubfield)
        fieldst = New mapstoredata
        If IsNothing(fields) Then Return
        For index = 0 To fields.Length - 1
            check_type_name(fields(index).name, fields(index).typetargetinfo)
            fieldst.add(fields(index).name, fields(index).ptype)
        Next
    End Sub
    Friend Shared Sub import_fields(varname As String, datatype As String)
        fieldst.add(varname, datatype)
    End Sub

    Friend Shared Sub check_type_name(name As String, linecodestruc As xmlunpkd.linecodestruc)
        name = name.ToLower
        Dim arrlen As Integer = conrex.forbiddenvariablenames.Length - 1
        For index = 0 To arrlen
            If conrex.forbiddenvariablenames(index) = name Then
                dserr.new_error(conserr.errortype.DECLARINGERROR, linecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(linecodestruc), linecodestruc.value) & vbCrLf & "The name of this object is in the forbidden list, choose another name.")
            End If
        Next
    End Sub
    Friend Shared Sub check_type_name(name As String, typetargetinfo As lexer.targetinf)
        name = name.ToLower
        Dim arrlen As Integer = conrex.forbiddenvariablenames.Length - 1
        For index = 0 To arrlen
            If conrex.forbiddenvariablenames(index) = name Then
                Dim linecodestruc As xmlunpkd.linecodestruc = servinterface.get_line_code_struct(typetargetinfo, name, tokenhared.token.IDENTIFIER)
                dserr.new_error(conserr.errortype.DECLARINGERROR, linecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(linecodestruc), linecodestruc.value) & vbCrLf & "The name of this object is in the forbidden list, choose another name.")
            End If
        Next
    End Sub
End Class
