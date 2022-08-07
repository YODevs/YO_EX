Imports System.Reflection
Imports YOCA

Public Class yotypecreator
    Public Shared Function get_type_info(ilmethod As ilformat._ilmethodcollection, clinecodestruc As xmlunpkd.linecodestruc(), indclass As Integer, typestr As String) As ilformat._typeinfo
        Dim tpinf As New ilformat._typeinfo
        If servinterface.is_cil_common_data_type(typestr) OrElse servinterface.is_common_data_type(typestr, typestr) Then
            get_common_dtype(tpinf, typestr)
        Else
            Dim classresult As funcvalid._resultfuncvaild = get_class_valid_rtype(ilmethod, clinecodestruc, indclass)
            If classresult.callintern Then
                get_internal_type(ilmethod, tpinf, clinecodestruc, classresult, indclass)
            Else
                get_external_type(ilmethod, tpinf, clinecodestruc, classresult, indclass)
            End If
        End If
        Return tpinf
    End Function

    Public Shared Function convert_to_type_info(asmtype As Type) As ilformat._typeinfo
        Dim tpinf As New ilformat._typeinfo
        tpinf.externlib = asmtype.Assembly.GetName().Name
        tpinf.fullname = asmtype.ToString
        tpinf.name = asmtype.Name
        tpinf.namespace = asmtype.Namespace
        tpinf.asminfo = asmtype.AssemblyQualifiedName
        tpinf.isprimitive = False
        tpinf.isclass = True
        tpinf.isarray = asmtype.IsArray
        tpinf.isinternalclass = False
        tpinf.isenum = asmtype.IsEnum
        If tpinf.isenum Then
            tpinf.fullname = tpinf.fullname.Replace(conrex.PLUS, conrex.DOT)
            tpinf.valtpinf.structuretype = ilformat._valuetypestructure.ENUM
            tpinf.valtpinf.objectname = tpinf.fullname.Remove(0, tpinf.fullname.LastIndexOf(conrex.DOT) + 1)
            tpinf.valtpinf.classname = tpinf.fullname.Remove(tpinf.fullname.LastIndexOf(conrex.DOT))
        End If
        Return tpinf
    End Function

    Private Shared Sub get_internal_type(ilmethod As ilformat._ilmethodcollection, ByRef tpinf As ilformat._typeinfo, clinecodestruc() As xmlunpkd.linecodestruc, classresult As funcvalid._resultfuncvaild, indclass As Integer)
        Dim classindex As Integer
        Dim isvirtualmethod As Boolean = False
        Dim classname As String = classresult.exclass
        classindex = funcdtproc.get_index_class(ilmethod, classname, isvirtualmethod)
        If classindex = -1 Then
            If valtp.check_value_type(ilmethod, tpinf, classname) Then
                Return
            Else
                dserr.args.Add("Class '" & classname & "' not found.")
                dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(indclass).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(indclass)), clinecodestruc(indclass).value))
                Return
            End If
        End If
        tpinf.fullname = classname
        If classname.Contains(conrex.DOT) Then
            tpinf.name = classname.Remove(0, classname.IndexOf(conrex.DOT) + 1)
            tpinf.namespace = classname.Remove(classname.LastIndexOf(conrex.DOT) + 1)
        Else
            tpinf.name = classname
        End If
        tpinf.isprimitive = False
        tpinf.asminfo = classname
        tpinf.isclass = True
        tpinf.isinternalclass = True
        tpinf.isarray = False
    End Sub

    Friend Shared Sub get_common_dtype(ByRef tpinf As ilformat._typeinfo, typestr As String)
        Dim ctypestr As String = servinterface.cil_to_vb_common_data_type(typestr)
        servinterface.get_cil_byte_types(ctypestr)
        Dim tp As Type = Type.GetType("System." & ctypestr, True, True)
        tpinf.externlib = tp.Assembly.GetName().Name
        tpinf.fullname = tp.ToString
        tpinf.name = tp.Name
        tpinf.namespace = tp.Namespace
        tpinf.asminfo = tp.AssemblyQualifiedName
        tpinf.isprimitive = True
        tpinf.cdttypesymbol = typestr
        tpinf.isclass = False
        tpinf.isinternalclass = False
        tpinf.isarray = False
        servinterface.get_yo_common_data_type(typestr, tpinf.yosymbol)
    End Sub
    Friend Shared Sub get_external_type(ilmethod As ilformat._ilmethodcollection, ByRef tpinf As ilformat._typeinfo, clinecodestruc As xmlunpkd.linecodestruc(), classresult As funcvalid._resultfuncvaild, indclass As Integer)
        Dim classindex, namespaceindex As Integer
        Dim reclassname As String = String.Empty
        Dim isvirtualmethod As Boolean = False
        Dim classname As String = classresult.exclass
        If libserv.get_extern_index_class(ilmethod, classresult.exclass, namespaceindex, classindex, isvirtualmethod, reclassname) = -1 Then
            If valtp.check_value_type(ilmethod, tpinf, classresult.exclass) Then
                Return
            Else
                dserr.args.Add("Class '" & classname & "' not found.")
                dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(indclass).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(indclass)), clinecodestruc(indclass).value))
                Return
            End If
        End If
        classresult.asmextern = libserv.get_extern_assembly(namespaceindex)
        tpinf = get_extern_class_type(namespaceindex, classindex)
    End Sub

    Friend Shared Function get_extern_class_type(namespaceindex As Integer, classindex As Integer) As ilformat._typeinfo
        Dim tpinf As New ilformat._typeinfo
        Dim tp As Type = libserv.get_extern_class_type(namespaceindex, classindex)
        tpinf.externlib = tp.Assembly.GetName().Name
        tpinf.fullname = tp.ToString
        tpinf.name = tp.Name
        tpinf.namespace = tp.Namespace
        tpinf.asminfo = tp.AssemblyQualifiedName
        tpinf.isprimitive = False
        tpinf.isclass = True
        tpinf.isinternalclass = False
        tpinf.isenum = tp.IsEnum
        tpinf.isarray = False
        If tpinf.isenum Then
            tpinf.fullname = tpinf.fullname.Replace(conrex.PLUS, conrex.DOT)
            tpinf.valtpinf.structuretype = ilformat._valuetypestructure.ENUM
            tpinf.valtpinf.objectname = tpinf.fullname.Remove(0, tpinf.fullname.LastIndexOf(conrex.DOT) + 1)
            tpinf.valtpinf.classname = tpinf.fullname.Remove(tpinf.fullname.LastIndexOf(conrex.DOT))
        End If
        Return tpinf
    End Function
    Private Shared Function get_class_valid_rtype(ilmethod As ilformat._ilmethodcollection, clinecodestruc As xmlunpkd.linecodestruc(), indclass As Integer) As funcvalid._resultfuncvaild
        Dim glinecodestruc() As xmlunpkd.linecodestruc = servinterface.trim_line_code_struc(clinecodestruc, indclass)
        glinecodestruc(0).value &= "::.ctor"
        If glinecodestruc.Length = 1 OrElse glinecodestruc.Length > 1 AndAlso glinecodestruc(1).tokenid = tokenhared.token.EQUALS Then
            Array.Resize(glinecodestruc, 3)
            glinecodestruc(1) = New xmlunpkd.linecodestruc
            glinecodestruc(1).tokenid = tokenhared.token.PRSTART
            glinecodestruc(1).value = conrex.PRSTART
            glinecodestruc(2) = New xmlunpkd.linecodestruc
            glinecodestruc(2).tokenid = tokenhared.token.PREND
            glinecodestruc(2).value = conrex.PREND
        End If
        Return funcvalid.get_func_valid(ilmethod, glinecodestruc)
    End Function
End Class
