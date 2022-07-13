Public Class branching
    Private _ilmethod As ilformat._ilmethodcollection
    Private threadname As String = String.Empty
    Private externlib As String = "mscorlib"
    Private Shared threadlist As ArrayList
    Friend Shared Sub init()
        threadlist = New ArrayList
    End Sub
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        _ilmethod = ilmethod
        If compdt.PROJECTFRAMEWORK = ".netcore" Then
            externlib = "System.Threading.Thread"
        End If
    End Sub

    Public Function set_new_branch(clinecodestruc() As xmlunpkd.linecodestruc, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        If clinecodestruc.Length <= 1 Then
            dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(0).line, ilbodybulider.path, "Method name is not specified for branching.", "br foo()")
        End If

        Select Case clinecodestruc(1).tokenid
            Case tokenhared.token.IDENTIFIER
                branching_with_method(clinecodestruc, illocalinit, localinit)
            Case Else
                dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(1)), clinecodestruc(1).value), "br foo()")
        End Select

        Return _ilmethod
    End Function

    Private Sub branching_with_method(clinecodestruc() As xmlunpkd.linecodestruc, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        clinecodestruc = servinterface.get_contain_clinecodestruc(clinecodestruc, 1)
        Dim funcresult As funcvalid._resultfuncvaild = funcvalid.get_func_valid(_ilmethod, clinecodestruc)
        If funcresult.funcvalid Then
            inv_internal_method(clinecodestruc, _ilmethod, funcresult.exclass, funcresult, True, illocalinit, localinit)
        Else
            dserr.new_error(conserr.errortype.SYNTAXERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value), "br foo()")
        End If
    End Sub


    Private Sub inv_internal_method(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _ilmethod As ilformat._ilmethodcollection, classname As String, funcresult As funcvalid._resultfuncvaild, leftassign As Boolean, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        Dim isvirtualmethod As Boolean = False
        funcste.fscmawait = False
        Dim classindex As Integer = funcdtproc.get_index_class(_ilmethod, classname, isvirtualmethod)
        If classindex = -1 Then
            dserr.args.Add("Class '" & classname & "' not found.")
            dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            Return
        End If
        Dim methodindex As Integer = funcdtproc.get_index_method(_ilmethod, funcste.get_argument_list(clinecodestruc), funcresult.clmethod, classindex, leftassign)
        Select Case methodindex
            Case -1
                dserr.args.Add("Method " & funcresult.clmethod & "(...) not found.")
                dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
            Case -2
                dserr.args.Add("Method " & funcresult.clmethod & "(...) , The parameters of the called function do not match its original function.")
                dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(1).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(2)), clinecodestruc(2).value), "Overloads :" & vbCrLf & funcdtproc.overloadlist)
        End Select

        Dim methodinfo As tknformat._method = funcdtproc.get_method_info(classindex, methodindex)
        Dim isinstance As Boolean = check_instance_method(methodinfo, _ilmethod, funcresult)
        If isinstance = False Then cil.push_null_reference(_ilmethod.codes)

        If isvirtualmethod Then
            Dim ldloc As New illdloc(_ilmethod)
            Dim gidentifier As xmlunpkd.linecodestruc = clinecodestruc(0)
            If gidentifier.value.Contains(conrex.DBCLN) Then
                gidentifier.value = gidentifier.value.Remove(gidentifier.value.IndexOf(conrex.DBCLN))
                gidentifier.ile = gidentifier.value.Length
            End If
            ldloc.load_single_in_stack(classname, gidentifier)
        End If

        If clinecodestruc(0).tokenid = tokenhared.token.ARR Then var.load_element_by_method_ac(_ilmethod, clinecodestruc(0))

        servinterface.remove_br_in_class(classname)
        Dim getdatatype As String = methodinfo.returntype
        cil.push_pointer_to_methodref(_ilmethod.codes, getdatatype, classname, funcresult.clmethod, isinstance)
        init_thread_system(_ilmethod, illocalinit)
        If IsNothing(methodinfo.parameters) = False Then
            dserr.args.Add("Method " & methodinfo.name & "(...) , Branching functions should not have parameters.")
            dserr.new_error(conserr.errortype.BRANCHINGERROR, clinecodestruc(1).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), clinecodestruc(0).value))
        End If
        callvirt_thread_class(_ilmethod)
    End Sub

    Private Sub init_thread_system(ByRef _ilmethod As ilformat._ilmethodcollection, ByRef illocalinit() As ilformat._illocalinit)
        Dim locinit As New ilformat._illocalinit
        locinit.name = lngen.get_varname("br")
        locinit.datatype = "System.Threading.Thread"
        locinit.asmextern = externlib
        locinit.iscommondatatype = False
        locinit.hasdefaultvalue = False
        locinit.isvaluetypes = False
        locinit.typeinf = New ilformat._typeinfo
        locinit.typeinf.externlib = externlib
        locinit.typeinf.isclass = True
        locinit.typeinf.isprimitive = False
        locinit.typeinf.isinternalclass = False
        locinit.typeinf.namespace = "System.Threading"
        locinit.typeinf.name = "Thread"
        locinit.typeinf.fullname = "System.Threading.Thread"
        locinit.typeinf.asminfo = "System.Threading.Thread"
        Array.Resize(locinit.clocalvalue, 1)
        illocalsinit.set_local_init(illocalinit, locinit)
        _ilmethod.locallinit = illocalinit
        threadname = locinit.name
        set_newobj_thread(_ilmethod)
    End Sub

    Private Sub set_newobj_thread(ByRef _ilmethod As ilformat._ilmethodcollection)
        cil.insert_il(_ilmethod.codes, String.Format("newobj instance void [{0}]System.Threading.ThreadStart::.ctor(object, native int)", externlib))
        cil.insert_il(_ilmethod.codes, String.Format("newobj instance void [{0}]System.Threading.Thread::.ctor(class [{0}]System.Threading.ThreadStart)", externlib))
        cil.set_stack_local(_ilmethod.codes, threadname)
    End Sub

    Private Sub callvirt_thread_class(ByRef _ilmethod As ilformat._ilmethodcollection)
        cil.load_local_variable(_ilmethod.codes, threadname)
        cil.insert_il(_ilmethod.codes, String.Format("callvirt instance void [{0}]System.Threading.Thread::Start()", externlib))
        cil.nop(_ilmethod.codes)
    End Sub

    Private Shared Function check_instance_method(methodinfo As tknformat._method, ByRef ilmethod As ilformat._ilmethodcollection, funcresult As funcvalid._resultfuncvaild) As Boolean
        If methodinfo.objcontrol.modifier = tokenhared.token.INSTANCE AndAlso ilasmgen.classdata.attribute._app._classname = funcresult.exclass Then
            cil.ldarg(ilmethod.codes, 0)
            Return True
        End If
        Return False
    End Function
End Class
