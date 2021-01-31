Public Class ilctor
    Private _ilmethod As ilformat._ilmethodcollection
    Structure ctorinfo
        Dim classindex, namespaceindex As Integer
        Dim classname As String
    End Structure
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
    End Sub

    Public Function set_new_ctor(index As Integer, clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        Dim ctorinf As New ctorinfo
        ctorinf.classname = _illocalinit(index).datatype
        If libserv.get_extern_index_class(ctorinf.classname, ctorinf.namespaceindex, ctorinf.classindex) = -1 Then
            dserr.args.Add("Class " & ctorinf.classname & " not found.")
            dserr.new_error(conserr.errortype.METHODERROR, clinecodestruc(0).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc(0)), ctorinf.classname))
        End If
        allocate_an_uninitialized_obj(ctorinf, index, clinecodestruc, _illocalinit, localinit)
        Return _ilmethod
    End Function

    Public Sub allocate_an_uninitialized_obj(ctorinf As ctorinfo, index As Integer, clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        Dim indclass As Integer = 3
        If _illocalinit(index).ctor Then
            indclass = 4
        End If
        Dim glinecodestruc() As xmlunpkd.linecodestruc = servinterface.trim_line_code_struc(clinecodestruc, indclass)
        glinecodestruc(0).value &= "::.ctor"
        coutputdata.print_token(glinecodestruc)
        Dim resultfunc As funcvalid._resultfuncvaild = funcvalid.get_func_valid(glinecodestruc)
        invoke_constructor(glinecodestruc, resultfunc, ctorinf)
    End Sub

    Private Sub invoke_constructor(glinecodestruc As xmlunpkd.linecodestruc(), resultfunc As funcvalid._resultfuncvaild, ctorinf As ctorinfo)
        resultfunc.asmextern = libserv.get_extern_assembly(ctorinf.namespaceindex)
        MsgBox(resultfunc.asmextern)
    End Sub
End Class
