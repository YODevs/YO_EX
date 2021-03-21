Imports System.Reflection

Public Class ilctor
    Private _ilmethod As ilformat._ilmethodcollection
    Structure ctorinfo
        Dim classindex, namespaceindex As Integer
        Dim classname As String
        Dim objname As String
    End Structure
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_new_ctor(index As Integer, clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        Dim ctorinf As New ctorinfo
        ctorinf.classname = _illocalinit(index).datatype
        ctorinf.objname = _illocalinit(index).name
        Dim indclass As Integer = 3
        If _illocalinit(index).ctor Then
            indclass = 4
        End If
        Dim glinecodestruc() As xmlunpkd.linecodestruc = servinterface.trim_line_code_struc(clinecodestruc, indclass)
        glinecodestruc(0).value &= "::.ctor"
        Dim resultfunc As funcvalid._resultfuncvaild = funcvalid.get_func_valid(glinecodestruc)
        If resultfunc.callintern Then
            Dim classindex As Integer = funcdtproc.get_index_class(ctorinf.classname)
            If classindex = -1 Then
                dserr.args.Add("Class '" & ctorinf.classname & "' not found.")
                dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            End If
        Else
            If libserv.get_extern_index_class(_ilmethod, ctorinf.classname, ctorinf.namespaceindex, ctorinf.classindex) = -1 Then
                dserr.args.Add("Class '" & ctorinf.classname & "' not found.")
                dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), ctorinf.classname))
            End If
        End If
        allocate_an_uninitialized_obj(glinecodestruc, resultfunc, ctorinf, index, clinecodestruc, _illocalinit, localinit)
        Return _ilmethod
    End Function

    Public Sub allocate_an_uninitialized_obj(glinecodestruc() As xmlunpkd.linecodestruc, resultfunc As funcvalid._resultfuncvaild, ctorinf As ctorinfo, index As Integer, clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        If _illocalinit(index).ctor = False Then
            If resultfunc.callintern = False Then _illocalinit(index).asmextern = libserv.get_extern_assembly(ctorinf.namespaceindex)
            Return
        End If
        If resultfunc.callintern Then
            inv_internal_constructor(glinecodestruc, resultfunc, ctorinf)
        Else
            inv_external_constructor(_illocalinit(index), glinecodestruc, resultfunc, ctorinf)
        End If
    End Sub
    Private Sub inv_internal_constructor(glinecodestruc As xmlunpkd.linecodestruc(), resultfunc As funcvalid._resultfuncvaild, ctorinf As ctorinfo)
        Dim methodinfo As New tknformat._method
        rep_constructor_param(glinecodestruc)
        Dim stateprop As Integer = funcdtproc.get_index_constructor(_ilmethod, funcste.get_argument_list(glinecodestruc), compdt.CONSTRUCTOR_METHOD, ctorinf.classindex)
        If stateprop = -1 Then
            dserr.args.Add("Constructor method not found.")
            dserr.new_error(conserr.errortype.METHODERROR, glinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(glinecodestruc(0)), glinecodestruc(0).value))
        End If
        Dim paramtype As ArrayList
        Dim cargcodestruc() As xmlunpkd.linecodestruc = libserv.cargldr
        libserv.cargldr = Nothing

        If IsNothing(methodinfo.parameters) = False AndAlso methodinfo.parameters.Length > 0 Then
            funcste.load_param_in_stack(cargcodestruc, _ilmethod, methodinfo, Nothing, paramtype, cargcodestruc)
        End If
        cil.new_obj(_ilmethod.codes, "void", Nothing, resultfunc.exclass, resultfunc.clmethod, paramtype)
        cil.set_stack_local(_ilmethod.codes, ctorinf.objname)
    End Sub

    Private Sub inv_external_constructor(ByRef _illocalinit As ilformat._illocalinit, glinecodestruc As xmlunpkd.linecodestruc(), resultfunc As funcvalid._resultfuncvaild, ctorinf As ctorinfo)
        resultfunc.asmextern = libserv.get_extern_assembly(ctorinf.namespaceindex)
        _illocalinit.asmextern = resultfunc.asmextern
        Dim ctormethodinfo As ConstructorInfo
        Dim methodinfo As New tknformat._method
        rep_constructor_param(glinecodestruc)
        Dim stateprop As Integer = libserv.get_extern_index_constructor(_ilmethod, funcste.get_argument_list(glinecodestruc), ctorinf.namespaceindex, ctorinf.classindex, ctormethodinfo, methodinfo)
        If stateprop = -1 Then
            dserr.args.Add("Constructor method not found.")
            dserr.new_error(conserr.errortype.METHODERROR, glinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(glinecodestruc(0)), glinecodestruc(0).value))
        End If
        Dim paramtype As ArrayList
        Dim cargcodestruc() As xmlunpkd.linecodestruc = libserv.cargldr
        libserv.cargldr = Nothing

        If IsNothing(methodinfo.parameters) = False AndAlso methodinfo.parameters.Length > 0 Then
            funcste.load_param_in_stack(cargcodestruc, _ilmethod, methodinfo, Nothing, paramtype, cargcodestruc)
        End If
        Dim getrettype As String = "void"
        cil.new_obj(_ilmethod.codes, getrettype, resultfunc.asmextern, resultfunc.exclass, resultfunc.clmethod, paramtype)
        cil.set_stack_local(_ilmethod.codes, ctorinf.objname)
    End Sub
    Private Sub rep_constructor_param(ByRef glinecodestruc As xmlunpkd.linecodestruc())
        If glinecodestruc.Length - 1 = 0 Then
            dserr.new_error(conserr.errortype.CONSTRUCTORERROR, glinecodestruc(0).line, ilbodybulider.path, "No parameters are defined for the initial value.", "If the initialization has no parameters, proceed as let x : init System.Text.StringBuilder()")
        End If
    End Sub
End Class
