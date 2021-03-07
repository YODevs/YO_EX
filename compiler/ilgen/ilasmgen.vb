Public Class ilasmgen

    Private _ilhead As ilhead
    Private _ilfunc As ilfuncgen
    Private ilcollection As ilformat.ildata
    Friend Shared classdata As tknformat._class
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
        localinitdata.import_fields(yoclassdt.fields)
        ilcollection.ilmethod = _ilfunc.gen()
        _ilresultcollection.ilfmtdata = ilcollection
        _ilresultcollection.ilfmtdata.setinitialization = _ilfunc.setinitialization
        _ilresultcollection.result = True
        Return _ilresultcollection
    End Function
    Private Sub set_fields(yoclassdt As tknformat._class, ByRef _ilcollection As ilformat.ildata)
        If IsNothing(yoclassdt.fields) Then Return
        _ilcollection.staticctor = New ArrayList
        _ilcollection.instancector = New ArrayList
        For index = 0 To yoclassdt.fields.Length - 1
            Array.Resize(_ilcollection.field, index + 1)
            Dim getdatatype As String = yoclassdt.fields(index).ptype
            servinterface.is_common_data_type(getdatatype, getdatatype)
            _ilcollection.field(index).name = yoclassdt.fields(index).name
            _ilcollection.field(index).accesscontrol = yoclassdt.fields(index).accesscontrol
            _ilcollection.field(index).modifier = yoclassdt.fields(index).modifier
            _ilcollection.field(index).ptype = getdatatype
            _ilcollection.field(index).isliteral = yoclassdt.fields(index).isconstant
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
                If yoclassdt.fields(index).modifier = "static" Then
                    For ictrcode = 0 To ctrfunc.codes.Count - 1
                        _ilcollection.staticctor.Add(ctrfunc.codes(ictrcode))
                    Next
                    ilstvar.st_field(yoclassdt.fields(index).name, Nothing, getlinecodestruct, getdatatype, _ilcollection.staticctor)
                Else
                    For ictrcode = 0 To ctrfunc.codes.Count - 1
                        _ilcollection.instancector.Add(ctrfunc.codes(ictrcode))
                    Next
                    ilstvar.st_field(yoclassdt.fields(index).name, Nothing, getlinecodestruct, getdatatype, _ilcollection.instancector)
                End If
            ElseIf _ilcollection.field(index).isliteral Then
                dserr.new_error(conserr.errortype.CONSTANTVALERROR, -1, yoclassdt.location, "[Identifier] -> " & yoclassdt.fields(index).name)
            End If
            'Check Type ...
        Next
    End Sub
End Class
