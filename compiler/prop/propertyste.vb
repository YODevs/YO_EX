Imports System.Reflection
Imports YOCA

Public Class propertyste
    Friend Shared Sub invoke_property(clinecodestruc() As xmlunpkd.linecodestruc, ilmethod As ilformat._ilmethodcollection, propresult As identvalid._resultidentcvaild, optval As tokenhared.token)
        If propresult.callintern = True Then
            Throw New NotImplementedException
        Else

            inv_external_property(clinecodestruc, ilmethod, propresult, optval)
        End If
    End Sub

    Friend Shared Sub inv_external_property(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, propresult As identvalid._resultidentcvaild, optval As tokenhared.token)
        Dim classindex, namespaceindex As Integer
        Dim reclassname As String = String.Empty
        Dim isvirtualmethod As Boolean = False
        If libserv.get_extern_index_class(_ilmethod, propresult.exclass, namespaceindex, classindex, isvirtualmethod, reclassname) = -1 Then
            dserr.args.Add("Class '" & propresult.exclass & "' not found.")
            dserr.new_error(conserr.errortype.PROPERTYERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            Return
        End If
        propresult.asmextern = libserv.get_extern_assembly(namespaceindex)
        Dim retpropertyinfo As PropertyInfo
        If libserv.get_extern_index_property(propresult.clident, namespaceindex, classindex, retpropertyinfo) = -1 Then
            dserr.args.Add("Property '" & propresult.clident.ToLower & "' not found.")
            dserr.new_error(conserr.errortype.PROPERTYERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), propresult.clident))
            Return
        End If
    End Sub

End Class
