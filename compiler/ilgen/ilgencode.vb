Imports System.IO

Public Class ilgencode

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
            procresult.rp_gen(classdt(index).location & " - " & classdt(index).methods.Length & " func ")
            ilasm = New ilasmgen(ilcollection)
            funcste.attribute = classdt(index).attribute
            Dim resultdata As ilformat.resultildata = ilasm.gen(classdt(index))
            If resultdata.result Then
                Dim bodybuilder As New ilbodybulider(resultdata.ilfmtdata, classdt(index).attribute)
                ilbodybulider.path = classdt(index).location
                bodybuilder.conv_to_msil()
                procresult.rs_set_result(True)
                import_il_gen_code(bodybuilder.source)
            Else
                'Somethings error ...
            End If
        Next

        write_il()
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
        ilasmparameter.add_param("/OUTPUT", cilcomp.get_output_loca())
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
