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
        ilcollection.ilmethod = _ilfunc.gen()
        _ilresultcollection.ilfmtdata = ilcollection
        set_fields(yoclassdt, _ilresultcollection)
        _ilresultcollection.result = True

        Return _ilresultcollection
    End Function
    Private Sub set_fields(yoclassdt As tknformat._class, ByRef _ilresultcollection As ilformat.resultildata)
        If IsNothing(yoclassdt.fields) Then Return
        For index = 0 To yoclassdt.fields.Length - 1
            Array.Resize(_ilresultcollection.ilfmtdata.field, index + 1)
            _ilresultcollection.ilfmtdata.field(index).name = yoclassdt.fields(index).name
            _ilresultcollection.ilfmtdata.field(index).accesscontrol = yoclassdt.fields(index).accesscontrol
            _ilresultcollection.ilfmtdata.field(index).modifier = yoclassdt.fields(index).modifier
            _ilresultcollection.ilfmtdata.field(index).ptype = yoclassdt.fields(index).ptype
            'Check Type ...
        Next
    End Sub
End Class
