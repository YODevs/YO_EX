Imports System.IO

Public Class ilgencode

    Friend Shared attribute As yocaattribute.yoattribute
    Dim classdt() As tknformat._class
    Dim ilcollection As ilformat.ildata
    Dim ilasm As ilasmgen
    Dim source As String = vbCrLf & vbCrLf
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
            If IsNothing(classdt(index).fields) = False Then getcfield = classdt(index).fields.Length
            If classdt(index).cacheinf.active AndAlso compdt.CHECKSYNANDSEM = False Then
                procresult.rp_gen(classdt(index).location & " [CA] - " & classdt(index).methods.Length & " func(s) , " & getcfield & " field(s)")
                Dim cachedata As String = File.ReadAllText(classdt(index).cacheinf.path)
                import_il_gen_code(cachedata)
                procresult.rs_set_result(True)
            Else
                procresult.rp_gen(classdt(index).location & " - " & classdt(index).methods.Length & " func(s) , " & getcfield & " field(s)")
                attribute = classdt(index).attribute
                ilasm = New ilasmgen(ilcollection)
                funcste.attribute = classdt(index).attribute
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
        If compdt.CHECKSYNANDSEM = False Then write_il()
    End Sub

    Private Sub write_il()
        procresult.set_state("asm")
        procresult.rp_asm("Preparation of prerequisites and parameters")
        Dim ilasmparameter As New ilasmparam
        check_debug_state(ilasmparameter)
        coutputdata.write_file_data("msil_source.il", source)
        Dim path As String = cilcomp.get_il_loca()
        File.WriteAllText(path, source)
        ilasmparameter.add_file(path)
        ilasmparameter.add_param("/OUTPUT", conrex.DUSTR & cilcomp.get_output_loca() & conrex.DUSTR)
        Dim ilconv As New ilasmconv(ilasmparameter, path)
        procresult.rs_set_result(True)
        procresult.rp_asm("Assembly process & Linker")
        ilconv.compile()
        cilcomp.set_options()
    End Sub
    Private Sub import_il_gen_code(codes As String)
        source &= codes & vbCrLf & vbCrLf
    End Sub

    Private Sub check_debug_state(ByRef ilasmparameter As ilasmparam)
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
    End Sub
End Class
