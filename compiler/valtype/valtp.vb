Imports YOCA

Public Class valtp
    Friend Shared Function check_value_type(ilmethod As ilformat._ilmethodcollection, ByRef typeinf As ilformat._typeinfo, classname As String) As Boolean
        Dim enumname As String = String.Empty
        Dim classindex As Integer = -1
        Dim namespaceindex As Integer = -1
        Dim internalclass As Boolean = False
        If classname.Contains(conrex.DOT) Then
            enumname = classname.Remove(0, classname.LastIndexOf(conrex.DOT) + 1)
            classname = classname.Remove(classname.LastIndexOf(conrex.DOT))
        Else
            enumname = classname
            classname = ilasmgen.classdata.name
        End If
        If libserv.get_extern_index_class(ilmethod, classname, namespaceindex, classindex, Nothing, Nothing) = -1 Then
            classindex = funcdtproc.get_index_class(ilmethod, classname)
            If classindex = -1 Then
                Return False
            End If
            internalclass = True
        End If

        If internalclass Then
            Dim enumindex As Integer = funcdtproc.get_index_enum(enumname, classindex)
            If enumindex = -1 Then
                Return False
            Else
                typeinf.valtpinf.structuretype = ilformat._valuetypestructure.ENUM
                typeinf.valtpinf.objectname = enumname
                typeinf.valtpinf.classname = classname
                typeinf.isenum = True
                typeinf.isclass = True
                typeinf.isinternalclass = True
                typeinf.isprimitive = False
                typeinf.fullname = classname & conrex.DOT & enumname
                typeinf.asminfo = classname & conrex.DOT & enumname
                If classname.Contains(conrex.DOT) Then
                    typeinf.name = classname.Remove(0, classname.IndexOf(conrex.DOT) + 1)
                    typeinf.namespace = classname.Remove(classname.LastIndexOf(conrex.DOT) + 1)
                Else
                    typeinf.name = classname
                End If
                Return True
            End If
        Else
            Dim enumindex As Integer = libserv.get_index_enum(enumname, namespaceindex, classindex)
            If enumindex = -1 Then
                Return False
            Else
                Dim getnestedtype As Type = libserv.get_nested_type(enumindex, namespaceindex, classindex)
                typeinf.valtpinf.structuretype = ilformat._valuetypestructure.ENUM
                typeinf.valtpinf.objectname = enumname
                typeinf.valtpinf.classname = classname
                typeinf.isenum = True
                typeinf.isclass = True
                typeinf.isinternalclass = False
                typeinf.isprimitive = False
                typeinf.fullname = getnestedtype.FullName.Replace("+", ".")
                typeinf.asminfo = getnestedtype.AssemblyQualifiedName
                typeinf.externlib = getnestedtype.Assembly.GetName().Name
                If getnestedtype.Namespace <> conrex.NULL Then
                    typeinf.namespace = getnestedtype.Namespace
                Else
                    typeinf.name = getnestedtype.Name
                End If
                Return True
            End If
        End If
        Return True
    End Function
End Class
