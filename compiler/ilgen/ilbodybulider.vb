Public Class ilbodybulider

    Public ildt As ilformat.ildata

    Private msilsource As String
    Public ReadOnly Property source() As String
        Get
            Return msilsource
        End Get
    End Property
    Public Sub New(ilclassdata As ilformat.ildata)
        ildt = ilclassdata
    End Sub

    Public Function conv_to_msil() As String
        For index = 0 To ildt.assemblyextern.Length - 1
            add_assembly(ildt.assemblyextern(index))
        Next

        Return source
    End Function

    Public Sub add_assembly(assemblydt As ilformat._ilassemblyextern)
        'check uniq assembly
        'check names
        If assemblydt.isextern Then
            add_il_code(".assembly extern " & assemblydt.name & assemblydt.assemblyproperty)
        Else
            add_il_code(".assembly " & assemblydt.name & assemblydt.assemblyproperty)
        End If
    End Sub
    Public Sub add_il_code(code As String)
        msilsource &= vbCrLf & code
    End Sub
End Class
