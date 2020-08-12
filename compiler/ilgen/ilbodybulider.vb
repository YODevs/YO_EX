Public Class ilbodybulider

    Public ildt As ilformat.ildata

    Private ReadOnly msilsource As String
    Public ReadOnly Property source() As String
        Get
            Return msilsource
        End Get
    End Property
    Public Sub New(ilclassdata As ilformat.ildata)
        ildt = ilclassdata
    End Sub

    Public Function conv_to_msil() As String

    End Function
End Class
