Imports YOCA

Public Class valtp
    Friend Shared Function check_value_type(ilmethod As ilformat._ilmethodcollection, ByRef illocalinit As ilformat._illocalinit, classname As String) As Boolean
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
                illocalinit.isvaluetypes = True
                illocalinit.typeinf.valtpinf.structuretype = ilformat._valuetypestructure.ENUM
                illocalinit.typeinf.valtpinf.objectname = enumname
                illocalinit.typeinf.valtpinf.classname = classname
                illocalinit.typeinf.isenum = True
                illocalinit.typeinf.isclass = True
                illocalinit.typeinf.isinternalclass = True
                illocalinit.typeinf.isprimitive = False
                illocalinit.typeinf.fullname = classname & conrex.DOT & enumname
                illocalinit.typeinf.asminfo = classname & conrex.DOT & enumname
                If classname.Contains(conrex.DOT) Then
                    illocalinit.typeinf.name = classname.Remove(0, classname.IndexOf(conrex.DOT) + 1)
                    illocalinit.typeinf.namespace = classname.Remove(classname.LastIndexOf(conrex.DOT) + 1)
                Else
                    illocalinit.typeinf.name = classname
                End If
                illocalinit.datatype = illocalinit.typeinf.asminfo
                Return True
            End If
        Else
            Dim enumindex As Integer = libserv.get_index_enum(enumname, namespaceindex, classindex)
            If enumindex = -1 Then
                Return False
            Else
                Dim getnestedtype As Type = libserv.get_nested_type(enumindex, namespaceindex, classindex)
                illocalinit.isvaluetypes = True
                illocalinit.typeinf.valtpinf.structuretype = ilformat._valuetypestructure.ENUM
                illocalinit.typeinf.valtpinf.objectname = enumname
                illocalinit.typeinf.valtpinf.classname = classname
                illocalinit.typeinf.isenum = True
                illocalinit.typeinf.isclass = True
                illocalinit.typeinf.isinternalclass = False
                illocalinit.typeinf.isprimitive = False
                illocalinit.typeinf.fullname = getnestedtype.FullName.Replace("+", ".")
                illocalinit.typeinf.asminfo = getnestedtype.AssemblyQualifiedName
                illocalinit.typeinf.externlib = getnestedtype.Assembly.GetName().Name
                If getnestedtype.Namespace <> conrex.NULL Then
                    illocalinit.typeinf.namespace = getnestedtype.Namespace
                Else
                    illocalinit.typeinf.name = getnestedtype.Name
                End If
                illocalinit.datatype = illocalinit.typeinf.fullname
                Return True
            End If
        End If
        Return True
    End Function
End Class
