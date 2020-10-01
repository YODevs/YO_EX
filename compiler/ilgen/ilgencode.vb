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
            ilasm = New ilasmgen(ilcollection)
            Dim resultdata As ilformat.resultildata = ilasm.gen(classdt(index))
            If resultdata.result Then
                Dim bodybuilder As New ilbodybulider(resultdata.ilfmtdata, classdt(index).attribute)
                ilbodybulider.path = classdt(index).location
                bodybuilder.conv_to_msil()
                import_il_gen_code(bodybuilder.source)
            Else
                'Somethings error ...
            End If
        Next

        write_il()
    End Sub

    Private Sub write_il()
        Dim ilasmparameter As New ilasmparam
        coutputdata.write_file_data("msil_source.il", source)
        Dim path As String = conrex.ENVCURDIR & "\" & cprojdt.get_val("assemblyname") & ".il"
        File.WriteAllText(path, source)
        ilasmparameter.add_file(path)
        Dim ilconv As New ilasmconv(ilasmparameter)
        ilconv.compile()
    End Sub
    Private Sub import_il_gen_code(codes As String)
        source &= codes & vbCrLf & vbCrLf
    End Sub
End Class
