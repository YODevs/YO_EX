Public Class ilhead
    Private ilcollection As ilformat.ildata
    Public asmheader(0) As ilformat._ilassemblyextern
    Public Sub New(ilcol As ilformat.ildata, mdname As String)
        ilcollection = ilcol
        asmheader(0) = New ilformat._ilassemblyextern
        init(mdname)
    End Sub

    Private Sub init(mdname As String)
        add_assembly_extern("mscorlib")
        add_assembly_extern(mdname, False, "{.ver:1:0:0:0}")
        set_module(mdname)
    End Sub

    Public Sub add_assembly_extern(name As String, Optional isextern As Boolean = True, Optional asmproperty As String = "{}")
        Dim assemblylen As Integer = asmheader.Length
        Dim iextern As Int16 = assemblylen - 1
        If assemblylen <> 0 Then
            Array.Resize(asmheader, assemblylen + 1)
        End If

        asmheader(iextern).name = name
        asmheader(iextern).isextern = isextern
        asmheader(iextern).assemblyproperty = assemblylen
    End Sub

    Public Sub set_module(mdname As String)
        ilcollection.modulename = mdname
    End Sub
End Class
