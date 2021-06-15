Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports YOCA

Public Class servinterface
    Friend Shared clinecodestruc As xmlunpkd.linecodestruc
    Friend Shared Sub ldc_i_checker(ByRef codes As ArrayList, value As Object, Optional convtoi8 As Boolean = False, Optional datatype As String = "int32")
        rem_float(value)
        Select Case datatype
            Case "int64"
                If CDec(value) > Int32.MaxValue Or CDec(value) < Int32.MinValue Then
                    cil.push_int64_onto_stack(codes, CDec(value))
                Else
                    cil.push_int32_onto_stack(codes, CDec(value))
                    If convtoi8 Then
                        cil.conv_to_int64(codes)
                    End If
                End If
            Case "int32"
                If CDec(value) > Int32.MaxValue Or CDec(value) < Int32.MinValue Then
                    cil.push_int64_onto_stack(codes, CDec(value))
                Else
                    cil.push_int32_onto_stack(codes, CDec(value))
                    If convtoi8 Then
                        cil.conv_to_int64(codes)
                    End If
                End If
            Case "int16"
                If CDec(value) > Int16.MaxValue Or CDec(value) < Int16.MinValue Then
                    dserr.args.Add(value)
                    dserr.new_error(conserr.errortype.INTEGRALOVERFLOW, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
                Else
                    cil.push_int32_onto_stack(codes, CDec(value))
                End If
            Case "int8"
                If CDec(value) > SByte.MaxValue Or CDec(value) < SByte.MinValue Then
                    dserr.args.Add(value)
                    dserr.new_error(conserr.errortype.INTEGRALOVERFLOW, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
                Else
                    cil.push_int32_onto_stack(codes, CDec(value))
                End If

            Case "uint8"
                If CDec(value) < 0 Then
                    dserr.args.Add(value)
                    dserr.args.Add("u8")
                    dserr.new_error(conserr.errortype.ERRORINCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
                End If
                If CDec(value) > Byte.MaxValue Then
                    dserr.args.Add(value)
                    dserr.args.Add("u8")
                    dserr.new_error(conserr.errortype.ERRORINCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
                Else
                    cil.push_int32_onto_stack(codes, CDec(value))
                    If convtoi8 Then
                        cil.conv_to_int64(codes)
                    End If
                End If
            Case "uint16"
                If CDec(value) < 0 Then
                    dserr.args.Add(value)
                    dserr.args.Add("u16")
                    dserr.new_error(conserr.errortype.ERRORINCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
                End If
                If CDec(value) > UInt16.MaxValue Then
                    dserr.args.Add(value)
                    dserr.args.Add("u16")
                    dserr.new_error(conserr.errortype.ERRORINCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
                Else
                    cil.push_int32_onto_stack(codes, CDec(value))
                    If convtoi8 Then
                        cil.conv_to_int64(codes)
                    End If
                End If
            Case "uint32"
                If CDec(value) < 0 Then
                    dserr.args.Add(value)
                    dserr.args.Add("u32")
                    dserr.new_error(conserr.errortype.ERRORINCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
                End If
                If CDec(value) > UInt32.MaxValue Or CDec(value) < UInt32.MinValue Then
                    cil.push_int64_onto_stack(codes, CDec(value))
                Else
                    cil.push_int32_onto_stack(codes, CDec(value))
                    If convtoi8 Then
                        cil.conv_to_int64(codes)
                    End If
                End If
            Case "uint64"
                If CDec(value) < 0 Then
                    dserr.args.Add(value)
                    dserr.args.Add("u64")
                    dserr.new_error(conserr.errortype.ERRORINCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
                End If
                If CDec(value) > UInt32.MaxValue Or CDec(value) < UInt32.MinValue Then
                    cil.push_int64_onto_stack(codes, CDec(value))
                Else
                    cil.push_int32_onto_stack(codes, CDec(value))
                    If convtoi8 Then
                        cil.conv_to_int64(codes)
                    End If
                End If
            Case "bool"
                If CDec(value) <> 1 AndAlso CDec(value) <> 0 Then
                    dserr.args.Add(value)
                    dserr.args.Add("bool")
                    dserr.new_error(conserr.errortype.ERRORINCONVERT, clinecodestruc.line, ilbodybulider.path, authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(clinecodestruc), clinecodestruc.value))
                Else
                    cil.push_int32_onto_stack(codes, CDec(value))
                End If
        End Select

    End Sub

    Friend Shared Sub ldc_r_checker(ByRef codes As ArrayList, value As Object, Optional convtor8 As Boolean = False)
        If convtor8 OrElse value > Single.MaxValue OrElse value < Single.MinValue Then
            cil.push_float64_onto_stack(codes, CDbl(value))
        Else
            cil.push_float32_onto_stack(codes, CSng(value))
        End If
    End Sub

    Friend Shared Function is_i8(datatype As String) As Boolean
        For index = 0 To compdt.i8cmtypes.Length - 1
            If datatype = compdt.i8cmtypes(index) Then
                Return True
            End If
        Next
        Return False
    End Function

    Friend Shared Function is_common_data_type(datatype As String, ByRef cildatatype As String) As Boolean
        datatype = datatype.ToLower
        For index = 0 To conrex.yocommondatatype.Length - 1
            If datatype = conrex.yocommondatatype(index) Then
                cildatatype = conrex.msilcommondatatype(index)
                Return True
            End If
        Next
        Return False
    End Function

    Friend Shared Function vb_to_cil_common_data_type(datatype As String) As String
        datatype = datatype.ToLower
        For index = 0 To conrex.plvbcommondatatype.Length - 1
            If datatype = conrex.plvbcommondatatype(index).ToLower Then
                Return conrex.msilcommondatatype(index)
            End If
        Next
        Return datatype
    End Function

    Friend Shared Function cil_to_vb_common_data_type(datatype As String) As String
        datatype = datatype.ToLower
        For index = 0 To conrex.plvbcommondatatype.Length - 1
            If datatype = conrex.msilcommondatatype(index).ToLower Then
                Return conrex.plvbcommondatatype(index)
            End If
        Next
        Return datatype
    End Function
    Friend Shared Function get_yo_common_data_type(datatype As String, ByRef yodatatype As String) As Boolean
        datatype = datatype.ToLower
        For index = 0 To conrex.yocommondatatype.Length - 1
            If datatype = conrex.msilcommondatatype(index) Then
                yodatatype = conrex.yocommondatatype(index)
                Return True
            End If
        Next
        Return False
    End Function
    Friend Shared Function get_yo_byte_types(datatype As String) As String
        If datatype.ToLower = "sbyte" Then
            Return "i8"
        ElseIf datatype.ToLower = "byte" Then
            Return "u8"
        End If
        Return datatype
    End Function
    Friend Shared Sub get_cil_byte_types(ByRef datatype As String)
        If datatype.ToLower = "int8" Then
            datatype = "SByte"
        ElseIf datatype.ToLower = "uint8" Then
            datatype = "Byte"
        End If
    End Sub
    Friend Shared Function is_cil_common_data_type(datatype As String) As Boolean
        For index = 0 To conrex.msilcommondatatype.Length - 1
            If datatype = conrex.msilcommondatatype(index) Then
                Return True
            End If
        Next
        Return False
    End Function

    Friend Shared Sub rem_float(ByRef value As Object)
        If value.ToString.Contains(conrex.DOT) Then
            Dim expr As String = value
            value = CObj(expr.Remove(expr.IndexOf(conrex.DOT)))
            Return
        End If
    End Sub

    Friend Shared Function reset_cil_common_data_type(ByRef value As String) As Boolean
        If value.ToString.Contains(conrex.DOT) AndAlso value.StartsWith("[mscorlib]System.") Then
            Dim getcommondtype As String = value.Remove(0, value.LastIndexOf(conrex.DOT) + 1).ToLower
            getcommondtype = servinterface.vb_to_cil_common_data_type(getcommondtype)
            If is_cil_common_data_type(getcommondtype) Then
                value = getcommondtype
                Return True
            ElseIf getcommondtype.ToLower = conrex.VOID Then
                value = conrex.VOID
                Return True
            End If
            Return False
        End If
        Return False
    End Function
    Friend Shared Function get_target_info(clinecodestruc As xmlunpkd.linecodestruc) As lexer.targetinf
        Dim linecinf As New lexer.targetinf
        linecinf.lstart = clinecodestruc.ist
        linecinf.line = clinecodestruc.line
        linecinf.length = clinecodestruc.ile
        linecinf.lend = clinecodestruc.ien
        Return linecinf
    End Function

    Friend Shared Function get_line_code_struct(linecinf As lexer.targetinf, value As String, tokenid As tokenhared.token) As xmlunpkd.linecodestruc
        Dim clinecodestruc As New xmlunpkd.linecodestruc
        clinecodestruc.ist = linecinf.lstart
        clinecodestruc.line = linecinf.line
        clinecodestruc.ile = linecinf.length
        clinecodestruc.ien = linecinf.lend
        clinecodestruc.tokenid = tokenid
        clinecodestruc.value = value
        Return clinecodestruc
    End Function
    Friend Shared Function get_contain_clinecodestruc(clinecodestruc() As xmlunpkd.linecodestruc, ilinc As Integer) As xmlunpkd.linecodestruc()
        Dim rclinecodestruc(clinecodestruc.Length - ilinc - 1) As xmlunpkd.linecodestruc
        For index = ilinc To clinecodestruc.Length - 1
            rclinecodestruc(index - ilinc) = clinecodestruc(index)
        Next
        Return rclinecodestruc
    End Function

    Friend Shared Function check_argument_token(tokenid As tokenhared.token) As Boolean
        For index = 0 To compdt.argumentallow.Length - 1
            If tokenid = compdt.argumentallow(index) Then
                Return True
            End If
        Next
        Return False
    End Function

    Friend Shared Function is_pointer(ilmethod As ilformat._ilmethodcollection, varname As String) As Boolean
        If IsNothing(ilmethod.parameter) = False Then
            varname = varname.ToLower
            For index = 0 To ilmethod.parameter.Length - 1
                If ilmethod.parameter(index).name.ToLower = varname Then
                    If ilmethod.parameter(index).ispointer Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            Next
        End If
        Return False
    End Function

    Friend Shared Function is_variable(ilmethod As ilformat._ilmethodcollection, varname As String, ByRef getdatatype As String) As Boolean
        If varname.Contains(conrex.DBCLN) Then
            Dim clinecodestruc As xmlunpkd.linecodestruc = create_fake_linecodestruc(tokenhared.token.IDENTIFIER, varname)
            Dim propresult As identvalid._resultidentcvaild = identvalid.get_identifier_valid(ilmethod, clinecodestruc)
            If propresult.identvalid Then
                Dim classindex, namespaceindex As Integer
                Dim reclassname As String = String.Empty
                Dim isvirtualmethod As Boolean = False
                If libserv.get_extern_index_class(ilmethod, propresult.exclass, namespaceindex, classindex, isvirtualmethod, reclassname) = -1 Then
                    Return False
                End If
                propresult.asmextern = libserv.get_extern_assembly(namespaceindex)
                Dim retpropertyinfo As PropertyInfo
                If libserv.get_extern_index_property(propresult.clident, namespaceindex, classindex, retpropertyinfo) = -1 Then
                    Return False
                End If
                getdatatype = servinterface.vb_to_cil_common_data_type(retpropertyinfo.PropertyType.Name)
                If servinterface.is_cil_common_data_type(getdatatype) = False Then
                    getdatatype = retpropertyinfo.PropertyType.ToString
                End If
                Return True
            End If
        End If
        varname = varname.ToLower
        If IsNothing(ilmethod.parameter) = False Then
            For index = 0 To ilmethod.parameter.Length - 1
                If ilmethod.parameter(index).name.ToLower = varname Then
                    getdatatype = ilmethod.parameter(index).datatype
                    is_common_data_type(getdatatype, getdatatype)
                    Return True
                End If
            Next
        End If

        If IsNothing(ilmethod.locallinit) = False Then
            For index = 0 To ilmethod.locallinit.Length - 1
                If ilmethod.locallinit(index).name <> conrex.NULL AndAlso ilmethod.locallinit(index).name.ToLower = varname Then
                    getdatatype = ilmethod.locallinit(index).datatype
                    Return True
                End If
            Next
        End If

        If IsNothing(ilasmgen.classdata.fields) = False Then
            For index = 0 To ilasmgen.classdata.fields.Length - 1
                If ilasmgen.classdata.fields(index).name.ToLower = varname Then
                    servinterface.is_common_data_type(ilasmgen.classdata.fields(index).ptype, getdatatype)
                    Return True
                End If
            Next
        End If

        Return False
    End Function

    Friend Shared Function get_field_from_current_class(varname As String) As tknformat._pubfield
        If IsNothing(ilasmgen.classdata.fields) = False Then
            varname = varname.ToLower
            For index = 0 To ilasmgen.classdata.fields.Length - 1
                If ilasmgen.classdata.fields(index).name.ToLower = varname Then
                    Return ilasmgen.classdata.fields(index)
                End If
            Next
        End If
        Return Nothing
    End Function
    Friend Shared Function get_identifier_gb(_ilmethod As ilformat._ilmethodcollection, varname As String, cargcodestruc As xmlunpkd.linecodestruc, ByRef getfield As tknformat._pubfield) As Boolean
        If varname.Contains("::") Then
            Dim hresult As identvalid._resultidentcvaild = identvalid.get_identifier_valid(_ilmethod, cargcodestruc)
            If hresult.identvalid = True Then
                Dim getfieldindex As Integer = -1
                If hresult.callintern = True Then
                    getfieldindex = funcdtproc.get_index_field(hresult.clident, hresult.classindex)
                Else
                    'extern fields
                End If
                If getfieldindex <> -1 Then
                    getfield = funcdtproc.get_field_info(hresult.classindex, getfieldindex)
                    Return True
                End If
            End If
        End If

        Return False
    End Function

    Friend Shared Function rep_data_type(datatype As String, ByRef resultdatatype As String) As Boolean
        datatype = datatype.ToLower
        If datatype.StartsWith("system.") Then
            datatype = datatype.Remove(0, datatype.IndexOf(conrex.DOT) + 1)
        End If

        If servinterface.is_cil_common_data_type(datatype) Then
            resultdatatype = datatype
            Return True
        Else
            Return False
        End If
    End Function
    Friend Shared classlist As New ArrayList
    Friend Shared Sub check_class_vaild(attr As yocaattribute.yoattribute, location As String)
        Dim getclassname As String = attr._app._classname.ToLower
        If attr._app._namespace <> conrex.NULL Then
            getclassname = attr._app._namespace.ToLower & conrex.DOT & getclassname
        End If
        For index = 0 To classlist.Count - 1
            If classlist(index) = getclassname Then
                dserr.args.Add(attr._app._classname)
                dserr.new_error(conserr.errortype.CLASSVAILDERROR, -1, location, "Specify a new name for your class or put it in a new namespace.", "#[app::classname(""yourclass"")]")
            End If
        Next
        classlist.Add(getclassname)
    End Sub

    Friend Shared Sub get_dt_proc(_ilmethod As ilformat._ilmethodcollection, clinecodestruc As xmlunpkd.linecodestruc, ByRef datatype As String)
        Select Case clinecodestruc.tokenid
            Case tokenhared.token.IDENTIFIER
                get_datatype(_ilmethod, clinecodestruc, datatype)
            Case tokenhared.token.TYPE_CO_STR
                datatype = "string"
            Case tokenhared.token.TYPE_DU_STR
                datatype = "string"
            Case tokenhared.token.TYPE_BOOL
                datatype = "bool"
            Case tokenhared.token.TRUE
                datatype = "bool"
            Case tokenhared.token.FALSE
                datatype = "bool"
            Case tokenhared.token.TYPE_INT
                datatype = "int32"
            Case tokenhared.token.TYPE_FLOAT
                datatype = "float32"
            Case Else

        End Select
    End Sub

    Friend Shared Sub get_datatype(_ilmethod As ilformat._ilmethodcollection, clinecodestruc As xmlunpkd.linecodestruc, ByRef getdatatype As String)
        servinterface.is_variable(_ilmethod, clinecodestruc.value, getdatatype)
        servinterface.is_common_data_type(getdatatype, getdatatype)
    End Sub

    Friend Shared Function trim_line_code_struc(clinecodestruc() As xmlunpkd.linecodestruc, index As Integer) As xmlunpkd.linecodestruc()
        If clinecodestruc.Length <index Then Throw New IndexOutOfRangeException
        Dim nretcodestruc() As xmlunpkd.linecodestruc
        Dim indexarray As Int16 = 0
        For stindex = index To clinecodestruc.Length - 1
            Array.Resize(nretcodestruc, indexarray + 1)
            nretcodestruc(indexarray) = clinecodestruc(stindex)
            indexarray += 1
        Next
        Return nretcodestruc
    End Function

    Friend Shared Function get_target_framwork(version As String) As String
        version = version.ToLower
        For index = 0 To Microsoft.Build.Utilities.TargetDotNetFrameworkVersion.VersionLatest
            Dim pathdotnetframework As String = Microsoft.Build.Utilities.ToolLocationHelper.GetPathToDotNetFrameworkFile("ilasm.exe", index)
            If [Enum].GetName(GetType(Microsoft.Build.Utilities.TargetDotNetFrameworkVersion), index).ToLower = version AndAlso pathdotnetframework <> conrex.NULL Then
                Return pathdotnetframework
            End If
        Next
        Return conrex.NULL
    End Function

    Friend Shared Function get_ilasm_path() As String
        Dim cpath As String = String.Empty
        For index = 0 To Microsoft.Build.Utilities.TargetDotNetFrameworkVersion.VersionLatest
            Dim pathdotnetframework As String = Microsoft.Build.Utilities.ToolLocationHelper.GetPathToDotNetFrameworkFile("ilasm.exe", index)
            If pathdotnetframework <> conrex.NULL AndAlso File.Exists(pathdotnetframework) Then
                cpath = pathdotnetframework
                compdt.SYSTEMLIBPATH = Microsoft.Build.Utilities.ToolLocationHelper.GetPathToDotNetFrameworkFile("System.dll", index)
            End If
        Next
        Return cpath
    End Function

    Friend Shared Function create_fake_linecodestruc(token As tokenhared.token, value As String) As xmlunpkd.linecodestruc
        Dim clinecodestruc As New xmlunpkd.linecodestruc
        clinecodestruc.tokenid = token
        clinecodestruc.value = value
        clinecodestruc.name = [Enum].GetName(GetType(tokenhared.token), token)
        Return clinecodestruc
    End Function

    Public Shared Function get_hash(val As String) As String
        Dim hashcreator As MD5 = MD5.Create()
        Dim dbytes As Byte() = hashcreator.ComputeHash(Encoding.UTF8.GetBytes(val))
        Dim sb As New StringBuilder()
        For i = 0 To dbytes.Length - 1
            sb.Append(dbytes(i).ToString("X2"))
        Next
        Return sb.ToString()
    End Function

    Public Shared Function get_array_name(tokenvalue As String) As String
        If tokenvalue.Contains(conrex.BRSTART) AndAlso tokenvalue.EndsWith(conrex.BREND) Then
            tokenvalue = tokenvalue.Remove(tokenvalue.IndexOf(conrex.BRSTART))
        End If
        Return tokenvalue
    End Function
End Class
