Public Class ilhead
    Private ilcollection As ilformat.ildata
    Public asmheader(0) As ilformat._ilassemblyextern
    Public Sub New(ilcol As ilformat.ildata, yoclassdt As tknformat._class)
        ilcollection = ilcol
        asmheader(0) = New ilformat._ilassemblyextern
        init(yoclassdt.name)
    End Sub

    Private Sub init(mdname As String)
        If compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetCore Then
            ilbodybulider.dotnetcorebasicextern.Add(compdt.SYSTEMRUNTIMELIB)
            ilbodybulider.dotnetcorebasicextern.Add(compdt.CORELIB)
        ElseIf compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetFramework Then
            add_assembly_extern(conrex.MSCORLIB)
        End If
        If mdname = "main" Then
            add_assembly_extern(cprojdt.get_val("assemblyname"), False, "{.ver 1:0:0:0}")
            set_module(mdname)
        End If
    End Sub

    Public Sub add_assembly_extern(name As String, Optional isextern As Boolean = True, Optional asmproperty As String = "{}")
        Dim assemblylen As Integer = asmheader.Length
        Dim iextern As Int16 = assemblylen - 1
        If assemblylen <> 0 Then
            Array.Resize(asmheader, assemblylen + 1)
        End If

        asmheader(iextern).name = name
        asmheader(iextern).isextern = isextern
        asmheader(iextern).assemblyproperty = asmproperty
    End Sub

    Public Sub set_module(mdname As String)
        ilcollection.modulename = mdname
    End Sub
End Class
