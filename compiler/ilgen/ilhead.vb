Public Class ilhead
    Private ilcollection As ilformat.ildata
    Private asmheader(0) As ilformat._ilassemblyextern
    Public Sub New(ilcol As ilformat.ildata, mdname As String)
        ilcollection = ilcol
        asmheader(0) = New ilformat._ilassemblyextern
        init(mdname)
    End Sub

    Private Sub init(mdname As String)
        add_assembly_extern("mscorlib")
        ilcollection.modulename = mdname
    End Sub

    Public Sub add_assembly_extern(name As String, Optional isextern As Boolean = True, Optional asmproperty As String = "{}")
        Dim assemblylen As Integer = asmheader.Length
        Dim iextern As Int16 = assemblylen - 1
        If assemblylen <> 0 Then
            Array.Resize(asmheader, assemblylen + 1)
        End If
        If isextern Then
            asmheader(iextern).name = ".assembly extern " & name
        Else
            asmheader(iextern).name = ".assembly " & name
        End If
        asmheader(iextern).assemblyproperty = assemblylen
    End Sub
End Class
