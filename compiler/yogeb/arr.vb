Imports YOCA

Public Class arr

    Friend Shared Function check_array_struct(ByRef varname As String, ByRef arrayinf As ilformat._arrayinfo, ByRef isarrayobj As Boolean) As Boolean
        Dim bkvarname As String = varname
        varname = servinterface.get_array_name(varname)
        If varname <> bkvarname Then
            isarrayobj = True
            arrayinf.isarrayref = True
            arrayinf.isunspecifiedelements = is_unspecified_elements(bkvarname, arrayinf.elementsp)
            Return True
        End If
        isarrayobj = False
        arrayinf.isarrayref = False
        Return False
    End Function

    Friend Shared Function is_unspecified_elements(varname As String, ByRef getelementsp As Object) As Boolean
        If varname.Length = 0 Then Return False
        Dim getelements As String = varname.Remove(0, varname.IndexOf(conrex.BRSTART))
        getelementsp = getelements
        If getelements = conrex.BRSTEN Then
            Return True
        End If
        Return False
    End Function

    Friend Shared Sub init_all_items(ByRef ilmethod As ilformat._ilmethodcollection, index As Integer, valindex As Integer)
        Dim arrobj As ilformat._illocalinit = ilmethod.locallinit(index)
        If arrobj.clocalvalue(valindex).tokenid = tokenhared.token.BLOCKOP Then
            Dim xmldata As New xmlunpkd(arrobj.clocalvalue(valindex).value, False)
            Dim items() As xmlunpkd.linecodestruc
            While xmldata.xmlreader.EOF = False
                items = xmldata.get_line_tokens()
                If items.Length = 0 Then Continue While
                Exit While
            End While
            Dim reclitem() As xmlunpkd.linecodestruc = funcste.get_arr_items(items)
            If IsNothing(reclitem) Then
                dserr.new_error(conserr.errortype.SYNTAXERROR, arrobj.clocalvalue(valindex).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(arrobj.clocalvalue(valindex)), arrobj.clocalvalue(valindex).value), "let i[] : i32 = {10,20,30,40,50}")
            End If
            arrobj.typeinf.isarray = True
            arrobj.arrayinf.isunspecifiedelements = False
            arrobj.arrayinf.elementsp = String.Format("[{0}]", reclitem.Length)
            set_new_arr(ilmethod, arrobj, assignmentcommondatatype.varnamecodestruc)
            arr.set_loc(ilmethod, arrobj, assignmentcommondatatype.varnamecodestruc)
            assign_all_items(ilmethod, arrobj, reclitem)
        Else
            dserr.new_error(conserr.errortype.SYNTAXERROR, arrobj.clocalvalue(valindex).line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(arrobj.clocalvalue(valindex)), arrobj.clocalvalue(valindex).value), "let i[] : i32 = {10,20,30,40,50}")
        End If
    End Sub

    Private Shared Sub assign_all_items(ByRef ilmethod As ilformat._ilmethodcollection, arrobj As ilformat._illocalinit, reclitem() As xmlunpkd.linecodestruc)
        Dim elemenetsp As Integer = reclitem.Length - 1
        Dim cildatatype As String = servinterface.vb_to_cil_common_data_type(arrobj.typeinf.name)
        For index = 0 To elemenetsp
            cil.load_local_variable(ilmethod.codes, arrobj.name)
            cil.push_int32_onto_stack(ilmethod.codes, index)
            pv_iden_assidb(arrobj, reclitem, index, ilmethod)
            ilmethod.codes.RemoveAt(ilmethod.codes.Count - 1)
            cil.set_element(ilmethod.codes, cildatatype)
        Next
    End Sub

    Private Shared Sub pv_iden_assidb(arrobj As ilformat._illocalinit, clinecodestruc() As xmlunpkd.linecodestruc, ByRef ilinc As Integer, ByRef _ilmethod As ilformat._ilmethodcollection)
        Dim optgen As New ilopt(_ilmethod, servinterface.get_contain_clinecodestruc(clinecodestruc, ilinc))
        Dim varname As String = arrobj.name
        Dim commondatatype As String
        If arrobj.typeinf.cdttypesymbol <> conrex.NULL AndAlso servinterface.get_yo_common_data_type(arrobj.typeinf.cdttypesymbol, commondatatype) Then
            Select Case commondatatype
                Case "str"
                    _ilmethod = optgen.assi_str(varname, clinecodestruc(ilinc))
                Case "obj"
                    _ilmethod = optgen.assi_obj(varname, clinecodestruc(ilinc))
                Case "i128"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "valuetype [mscorlib]System.Decimal")
                Case "i64"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "int64")
                Case "i32"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "int32")
                Case "i16"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "int16")
                Case "i8"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "int8")
                Case "u64"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "uint64")
                Case "u32"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "uint32")
                Case "u16"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "uint16")
                Case "u8"
                    _ilmethod = optgen.assi_int(varname, clinecodestruc(ilinc), "uint8")
                Case "f32"
                    _ilmethod = optgen.assi_float(varname, clinecodestruc(ilinc), "float32")
                Case "f64"
                    _ilmethod = optgen.assi_float(varname, clinecodestruc(ilinc), "float64")
                Case "bool"
                    _ilmethod = optgen.assi_bool(varname, clinecodestruc(ilinc), "bool")
                Case "char"
                    _ilmethod = optgen.assi_char(varname, clinecodestruc(ilinc), "char")
            End Select
        Else
            _ilmethod = optgen.assi_identifier(varname, clinecodestruc(ilinc), arrobj.typeinf.fullname)
        End If
        illdloc.frvarstruc = Nothing
    End Sub
    Friend Shared Sub set_new_arr(ByRef ilmethod As ilformat._ilmethodcollection, illocalinit As ilformat._illocalinit, clinecodestruc As xmlunpkd.linecodestruc)
        If illocalinit.isarrayobj = False OrElse illocalinit.arrayinf.isunspecifiedelements Then Return
        Dim elementsp As String = illocalinit.arrayinf.elementsp
        authfunc.rem_fr_and_en(elementsp)
        If IsNumeric(elementsp) Then
            servinterface.ldc_i_checker(ilmethod.codes, elementsp, False, "int32")
        Else
            illdloc.ld_identifier(elementsp, ilmethod, clinecodestruc, Nothing, "int32")
        End If
        cil.new_arr(ilmethod.codes, illocalinit.typeinf)
        setloc = True
    End Sub

    Friend Shared setloc As Boolean = False
    Friend Shared Sub set_loc(ByRef ilmethod As ilformat._ilmethodcollection, illocalinit As ilformat._illocalinit, clinecodestruc As xmlunpkd.linecodestruc)
        If setloc = False Then Return
        Dim ptype As String = illocalinit.typeinf.fullname
        If illocalinit.typeinf.isarray = True AndAlso illocalinit.typeinf.isprimitive Then
            ptype = illocalinit.typeinf.cdttypesymbol
        End If
        ilstvar.st_identifier(illocalinit.name, ilmethod, clinecodestruc, ptype)
        setloc = False
    End Sub

    Friend Shared Sub set_allocation_of_space(ByRef ilcollection As ilformat.ildata, index As Integer, classname As String)
        Dim arrlen As Integer = ilcollection.field(index).arrlen
        If arrlen = 0 Then Return
        arrlen += 1
        If ilcollection.field(index).modifier = compdt.OBJECTMODTYPE_STATIC Then
            cil.push_int32_onto_stack(ilcollection.staticctor, arrlen)
            cil.new_arr(ilcollection.staticctor, ilcollection.field(index).typeinf)
            cil.set_static_field(ilcollection.staticctor, ilcollection.field(index).typeinf, ilcollection.field(index).name, classname)
        Else
            cil.ldarg(ilcollection.instancector, 0)
            cil.push_int32_onto_stack(ilcollection.instancector, arrlen)
            cil.new_arr(ilcollection.instancector, ilcollection.field(index).typeinf)
            cil.set_field(ilcollection.instancector, ilcollection.field(index).typeinf, ilcollection.field(index).name, classname)
        End If
    End Sub
End Class
