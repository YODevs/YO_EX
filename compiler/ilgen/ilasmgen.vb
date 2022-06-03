Imports YOCA

Public Class ilasmgen

    Private _ilhead As ilhead
    Private _ilfunc As ilfuncgen
    Private ilcollection As ilformat.ildata
    Friend Shared classdata As tknformat._class
    Friend Shared fields() As ilformat._pubfield
    Public Sub New(ilcol As ilformat.ildata)
        ilcollection = ilcol
    End Sub

    Public Function gen(yoclassdt As tknformat._class) As ilformat.resultildata
        Dim _ilresultcollection As New ilformat.resultildata
        classdata = yoclassdt
        _ilhead = New ilhead(ilcollection, yoclassdt)
        For index = 0 To classdata.externlist.Count - 1
            If libserv.find_extern_name(yoclassdt.externlist(index)) Then
                _ilhead.add_assembly_extern(yoclassdt.externlist(index))
            Else
                dserr.new_error(conserr.errortype.ASMERROR, -1, Nothing, "'" & yoclassdt.externlist(index) & "' Assembly not found.")
            End If
        Next
        ilcollection.assemblyextern = _ilhead.asmheader
        Array.Resize(ilcollection.assemblyextern, ilcollection.assemblyextern.Length - 1)

        'Public fields ...
        _ilfunc = New ilfuncgen(ilcollection, yoclassdt)
        ilbodybulider.path = yoclassdt.location
        ilcollection.enumeration = yoclassdt.enums
        set_fields(yoclassdt, ilcollection)
        set_this_field(yoclassdt, ilcollection)
        fields = ilcollection.field
        localinitdata.import_fields(yoclassdt.fields)
        ilcollection.ilmethod = _ilfunc.gen()
        _ilresultcollection.ilfmtdata = ilcollection
        _ilresultcollection.ilfmtdata.setinitialization = _ilfunc.setinitialization
        _ilresultcollection.result = True
        Return _ilresultcollection
    End Function

    Private Sub set_this_field(ByRef yoclassdt As tknformat._class, ByRef _ilcollection As ilformat.ildata)
        If IsNothing(_ilcollection.instancector) Then
            _ilcollection.instancector = New ArrayList
        End If
        If IsNothing(_ilcollection.staticctor) Then
            _ilcollection.staticctor = New ArrayList
        End If
        Dim fieldlen As Integer = 0
        If IsNothing(_ilcollection.field) = False Then
            fieldlen = _ilcollection.field.Length
        End If
        Array.Resize(yoclassdt.fields, fieldlen + 1)
        Array.Resize(_ilcollection.field, fieldlen + 1)
        Dim index As Integer = _ilcollection.field.Length - 1
        Dim objctrl As New fmtshared.objectcontrol
        objctrl.accesscontrol = tokenhared.token.PRIVATE
        objctrl.accesscontrolval = compdt.ACCESSIBLE_PRIVATE
        objctrl.modifier = tokenhared.token.UNDEFINED
        objctrl.modifierval = compdt.OBJECTMODTYPE_INSTANCE
        yoclassdt.fields(index) = New tknformat._pubfield
        yoclassdt.fields(index).ptype = "obj"
        yoclassdt.fields(index).objcontrol = objctrl
        yoclassdt.fields(index).name = conrex.THIS
        _ilcollection.field(index) = New ilformat._pubfield
        _ilcollection.field(index).name = conrex.THIS
        _ilcollection.field(index).accesscontrol = compdt.ACCESSIBLE_PRIVATE
        _ilcollection.field(index).ptype = conrex.OBJECT
        _ilcollection.field(index).typeinf = New ilformat._typeinfo
        _ilcollection.field(index).typeinf.externlib = compdt.CORELIB
        _ilcollection.field(index).typeinf.name = conrex.OBJECT
        _ilcollection.field(index).typeinf.yosymbol = "obj"
        _ilcollection.field(index).typeinf.cdttypesymbol = conrex.OBJECT
        _ilcollection.field(index).typeinf.isprimitive = True
        _ilcollection.field(index).initproc = True
        cil.insert_il(_ilcollection.instancector, compdt.LOAD_FIRST_ARGUMENT)
        cil.insert_il(_ilcollection.instancector, compdt.LOAD_FIRST_ARGUMENT)
        cil.insert_il(_ilcollection.instancector, String.Format("stfld object {0}::this", funcste.attribute._app._classname))
        classdata.fields = yoclassdt.fields
    End Sub

    Private Sub set_fields(yoclassdt As tknformat._class, ByRef _ilcollection As ilformat.ildata)
        If IsNothing(yoclassdt.fields) Then Return
        Dim fakeobjectcontrol As New fmtshared.objectcontrol
        fakeobjectcontrol.modifier = tokenhared.token.INSTANCE
        fakeobjectcontrol.modifierval = compdt.OBJECTMODTYPE_INSTANCE
        iltranscore.set_object_control(fakeobjectcontrol)
        _ilcollection.staticctor = New ArrayList
        _ilcollection.instancector = New ArrayList
        For index = 0 To yoclassdt.fields.Length - 1
            Array.Resize(_ilcollection.field, index + 1)
            Dim getdatatype As String = yoclassdt.fields(index).ptype
            set_type_info(_ilcollection.field(index), yoclassdt.fields(index))
            servinterface.is_common_data_type(getdatatype, getdatatype)
            _ilcollection.field(index).name = yoclassdt.fields(index).name
            _ilcollection.field(index).accesscontrol = yoclassdt.fields(index).objcontrol.accesscontrolval
            _ilcollection.field(index).modifier = yoclassdt.fields(index).objcontrol.modifierval
            _ilcollection.field(index).ptype = getdatatype
            _ilcollection.field(index).isliteral = yoclassdt.fields(index).isconstant
            _ilcollection.field(index).initproc = yoclassdt.fields(index).initproc
            _ilcollection.field(index).ctorparameter = yoclassdt.fields(index).ctorparameters
            _ilcollection.field(index).value = yoclassdt.fields(index).value
            If yoclassdt.fields(index).isarray Then
                _ilcollection.field(index).isarray = True
                _ilcollection.field(index).arrlen = servinterface.get_array_length(_ilcollection.field(index), yoclassdt.fields(index))
                If _ilcollection.field(index).arrlen = -1 Then
                    dserr.args.Add("[Identifier] -> " & yoclassdt.fields(index).name & " - The array index must be a number.")
                    dserr.new_error(conserr.errortype.FIELDERROR, -1, yoclassdt.location, Nothing, "public static let i[5] : i32 ")
                End If
                arr.set_allocation_of_space(_ilcollection, index, yoclassdt.attribute._app._classname)
            End If

            Array.Resize(fields, index + 1)
            fields(index) = _ilcollection.field(index)
            Dim getlinecodestruct As xmlunpkd.linecodestruc = servinterface.get_line_code_struct(yoclassdt.fields(index).valuecinf, yoclassdt.fields(index).value, yoclassdt.fields(index).valuetoken)
            If yoclassdt.fields(index).value <> String.Empty Then
                If _ilcollection.field(index).isliteral Then
                    _ilcollection.field(index).value = yoclassdt.fields(index).value
                    _ilcollection.field(index).valuecinf = yoclassdt.fields(index).valuecinf
                    _ilcollection.field(index).valuetoken = yoclassdt.fields(index).valuetoken
                    Continue For
                End If
                Dim ctrfunc As New ilformat._ilmethodcollection
                ctrfunc.entrypoint = False
                ctrfunc.isexpr = False
                ctrfunc.name = ".ctor_imp"
                ctrfunc.codes = New ArrayList
                Dim ldfield As New illdloc(ctrfunc)
                ldfield.load_single_in_stack(getdatatype, getlinecodestruct)
                If yoclassdt.fields(index).objcontrol.modifier = tokenhared.token.STATIC Then
                    For ictrcode = 0 To ctrfunc.codes.Count - 1
                        _ilcollection.staticctor.Add(ctrfunc.codes(ictrcode))
                    Next
                    ilstvar.st_field(yoclassdt.fields(index).name, Nothing, getlinecodestruct, getdatatype, _ilcollection.staticctor)
                Else
                    cil.insert_il(_ilcollection.instancector, compdt.LOAD_FIRST_ARGUMENT)
                    For ictrcode = 0 To ctrfunc.codes.Count - 1
                        _ilcollection.instancector.Add(ctrfunc.codes(ictrcode))
                    Next
                    ilstvar.st_field(yoclassdt.fields(index).name, Nothing, getlinecodestruct, getdatatype, _ilcollection.instancector)
                End If
            ElseIf _ilcollection.field(index).isliteral Then
                dserr.new_error(conserr.errortype.CONSTANTVALERROR, -1, yoclassdt.location, "[Identifier] -> " & yoclassdt.fields(index).name)
            End If

            If _ilcollection.field(index).initproc Then
                set_ctor(_ilcollection, _ilcollection.field(index), yoclassdt.fields(index), getdatatype)
            End If
            check_null_safe_mode(_ilcollection.field(index))

        Next
        iltranscore.set_object_control(Nothing)
    End Sub

    Private Sub check_null_safe_mode(_pubfield As ilformat._pubfield)
        If ilgencode.attribute._cfg._null_safety = False Then Return
        If _pubfield.typeinf.isprimitive Then
            If _pubfield.value = conrex.NULL Then
                dserr.args.Add(_pubfield.name)
                dserr.new_error(conserr.errortype.NULLSAFETYMODEINIT, -1, ilbodybulider.path, String.Format("The '{0}' field requires initialization.", _pubfield.name), "public static let pi : f32 = 3.14" & vbCrLf & "Null Safety mode is to prevent NullReferenceException error, you can disable it from the labra.yoda file.")
            End If
        Else
            If _pubfield.initproc = False Then
                dserr.args.Add(_pubfield.name)
                dserr.new_error(conserr.errortype.NULLSAFETYMODEINIT, -1, ilbodybulider.path, String.Format("The '{0}' field requires initialization.", _pubfield.name), "public static let rnd : init system.random()" & vbCrLf & "Null Safety mode is to prevent NullReferenceException error, you can disable it from the labra.yoda file.")
            End If
        End If
    End Sub

    Private Sub set_ctor(ByRef _ilcollection As ilformat.ildata, pubfield As ilformat._pubfield, lexfield As tknformat._pubfield, getdatatype As String)
        Dim ctorclinecodestruc(pubfield.ctorparameter.Length) As xmlunpkd.linecodestruc
        ctorclinecodestruc(0) = servinterface.get_line_code_struct(lexfield.typetargetinfo, lexfield.ptype, tokenhared.token.IDENTIFIER)
        For index = 0 To pubfield.ctorparameter.Length - 1
            ctorclinecodestruc(index + 1) = pubfield.ctorparameter(index)
        Next
        Dim fakector As ilformat._ilmethodcollection = servinterface.create_fake_method_collection(".ctor_test")
        Dim ctor As New ilctor(fakector)
        ctor.set_new_ctor(ctorclinecodestruc)
        Dim getlinecodestruct As xmlunpkd.linecodestruc = servinterface.get_line_code_struct(lexfield.valuecinf, lexfield.name, lexfield.valuetoken)
        Dim ldfield As New illdloc(fakector)
        If lexfield.objcontrol.modifier = tokenhared.token.STATIC Then
            For ictrcode = 0 To fakector.codes.Count - 1
                _ilcollection.staticctor.Add(fakector.codes(ictrcode))
            Next
            ilstvar.st_field(lexfield.name, Nothing, getlinecodestruct, getdatatype, _ilcollection.staticctor)
        Else
            cil.insert_il(_ilcollection.instancector, compdt.LOAD_FIRST_ARGUMENT)
            For ictrcode = 0 To fakector.codes.Count - 1
                _ilcollection.instancector.Add(fakector.codes(ictrcode))
            Next
            ilstvar.st_field(lexfield.name, Nothing, getlinecodestruct, getdatatype, _ilcollection.instancector)
        End If
    End Sub

    Private Sub set_type_info(ByRef pubgenfield As ilformat._pubfield, publexfield As tknformat._pubfield)
        Dim clinetypeinfostruct(2) As xmlunpkd.linecodestruc
        clinetypeinfostruct(0) = servinterface.get_line_code_struct(publexfield.typetargetinfo, publexfield.ptype, tokenhared.token.IDENTIFIER)
        clinetypeinfostruct(1) = New xmlunpkd.linecodestruc
        clinetypeinfostruct(1).tokenid = tokenhared.token.PRSTART
        clinetypeinfostruct(1).value = conrex.PRSTART
        clinetypeinfostruct(2) = New xmlunpkd.linecodestruc
        clinetypeinfostruct(2).tokenid = tokenhared.token.PREND
        clinetypeinfostruct(2).value = conrex.PREND
        pubgenfield.typeinf = yotypecreator.get_type_info(Nothing, clinetypeinfostruct, 0, publexfield.ptype)
        pubgenfield.typeinf.isarray = publexfield.isarray
    End Sub
End Class
