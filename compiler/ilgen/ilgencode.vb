Imports System.IO

Public Class ilgencode

    Friend Shared attribute As yocaattribute.yoattribute
    Dim classdt() As tknformat._class
    Dim ilcollection As ilformat.ildata
    Dim ilasm As ilasmgen
    Friend Shared source As String = vbCrLf & vbCrLf
    Public Sub New(tknfmtclass() As tknformat._class)
        classdt = tknfmtclass
        ilcollection = New ilformat.ildata
    End Sub


    'TODO : compile multi code generator.
    Public Sub codegenerator()
        For index = 0 To classdt.Length - 1
            'Class Generate ...
            'Single File ;
            Dim getcfield As Integer = 0
            Dim getcmethod As Integer = 0
            If IsNothing(classdt(index).fields) = False Then getcfield = classdt(index).fields.Length
            If IsNothing(classdt(index).methods) = False Then getcmethod = classdt(index).methods.Length
            If classdt(index).cacheinf.active AndAlso compdt.CHECKSYNANDSEM = False AndAlso compdt.DEVMOD = False Then
                procresult.rp_gen(classdt(index).location & " [CA] - " & getcmethod & " func(s) , " & getcfield & " field(s)")
                Dim cachedata As String = File.ReadAllText(classdt(index).cacheinf.path)
                import_il_gen_code(cachedata)
                procresult.rs_set_result(True)
            Else
                procresult.rp_gen(classdt(index).location & " - " & getcmethod & " func(s) , " & getcfield & " field(s)")
                attribute = classdt(index).attribute
                ilasm = New ilasmgen(ilcollection)
                funcste.attribute = classdt(index).attribute
                check_classname(classdt(index).location)
                Dim resultdata As ilformat.resultildata = ilasm.gen(classdt(index))
                If resultdata.result AndAlso compdt.CHECKSYNANDSEM = False Then
                    Dim bodybuilder As New ilbodybulider(resultdata.ilfmtdata, classdt(index).attribute)
                    ilbodybulider.path = classdt(index).location
                    bodybuilder.conv_to_msil()
                    procresult.rs_set_result(True)
                    import_il_gen_code(bodybuilder.source)
                End If
            End If

        Next
        If compdt.CHECKSYNANDSEM = False Then
            If compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetFramework Then
                write_il()
            ElseIf compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetCore Then
                ilbodybulider.set_basic_assembly()
                write_il_dotnetcore()
            End If
        End If
    End Sub

    Private Sub check_classname(location As String)
        Dim classname As String = funcste.attribute._app._classname
        If classname <> String.Empty Then
            If tokenhared.check_keyword(classname) <> 0 OrElse tokenhared.check_common_type(classname) <> 0 Then
                dserr.new_error(conserr.errortype.ATTRIBUTEVALUEERROR, -1, location, "Classname can not be '" & funcste.attribute._app._classname & "'.")
            End If
        End If
    End Sub

    Private Sub write_il_dotnetcore()
        procresult.set_state("asm")
        procresult.rp_asm("Preparation of prerequisites and parameters")
        Dim ilasmparameter As New ilasmparam
        ilasmparameter.add_param("build")
        check_debug_state(ilasmparameter)
        If compdt.DEVMOD Then coutputdata.write_file_data("msil_source.il", source)
        Dim path As String = cilcomp.get_dotnetcore_dir
        File.WriteAllText(path & "\main.il", source, System.Text.Encoding.Unicode)
        Dim location As String = "..\..\"
        If cilcomp.debug Then
            location &= "debug\"
        Else
            location &= "release\"
        End If
        location &= compdt.DOTNETNAME
        ilasmparameter.add_param("-o", location)
        set_metadata_version(ilasmparameter)
        Dim dotnetconv As New dotnetbuild(ilasmparameter, path)
        procresult.rs_set_result(True)
        procresult.rp_asm("Assembly process & Linker")
        dotnetstruct.init(path)
        dotnetconv.compile()
        cilcomp.set_options()
    End Sub
    Private Sub write_il()
        procresult.set_state("asm")
        procresult.rp_asm("Preparation of prerequisites and parameters")
        Dim ilasmparameter As New ilasmparam
        check_debug_state(ilasmparameter)
        If compdt.DEVMOD Then coutputdata.write_file_data("msil_source.il", source)
        Dim path As String = cilcomp.get_il_loca()
        File.WriteAllText(path, source, System.Text.Encoding.Unicode)
        ilasmparameter.add_file(path)
        ilasmparameter.add_param("/OUTPUT", conrex.DUSTR & cilcomp.get_output_loca() & conrex.DUSTR)
        set_metadata_version(ilasmparameter)
        Dim ilconv As New ilasmconv(ilasmparameter, path)
        procresult.rs_set_result(True)
        procresult.rp_asm("Assembly process & Linker")
        ilconv.compile()
        cilcomp.set_options()
    End Sub
    Private Sub import_il_gen_code(codes As String)
        source &= codes & vbCrLf & vbCrLf
    End Sub

    Private Sub set_metadata_version(ByRef ilasmparameter As ilasmparam)
        If compdt.METADATAVERSION <> String.Empty Then ilasmparameter.add_param("/mdv", compdt.METADATAVERSION)
        If compdt.METASTREAMVERSION <> String.Empty Then ilasmparameter.add_param("/msv", compdt.METASTREAMVERSION)
    End Sub
    Private Sub check_debug_state(ByRef ilasmparameter As ilasmparam)
        If compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetFramework Then
            If execln.argstorelist.find(compdt.PARAM_DEBUG, True) Then
                cilcomp.debug = True
                ilasmparameter.add_param("/DEBUG")
            ElseIf execln.argstorelist.find(compdt.PARAM_DEBUG_IMPL, True) Then
                cilcomp.debug = True
                ilasmparameter.add_param("/DEBUG", "IMPL")
            ElseIf execln.argstorelist.find(compdt.PARAM_DEBUG_OPT, True) Then
                cilcomp.debug = True
                ilasmparameter.add_param("/DEBUG", "OPT")
            End If
        ElseIf compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetCore Then
            If execln.argstorelist.find(compdt.PARAM_DEBUG, True) Then
                cilcomp.debug = True
                ilasmparameter.add_param("-c", "debug")
            Else
                cilcomp.debug = False
                ilasmparameter.add_param("-c", "release")
            End If
        End If
    End Sub
End Class
