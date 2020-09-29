Imports YODA

Public Class cprojdt

    Public Shared labradt As YODA_Format.YODAMapFormat
    Public Shared projmapdt As mapstoredata
    Public Sub New(labrasetting As YODA_Format.YODAMapFormat)
        labradt = labrasetting
        projmapdt = New mapstoredata
    End Sub

    Public Sub conv_to_mapstore()
        projmapdt.import_collection(labradt.keys, labradt.values)
    End Sub

    Public Function get_val(key As String) As String
        Dim resultmapstore As mapstoredata.dataresult = projmapdt.find(key)
        If resultmapstore.issuccessful Then
            Return resultmapstore.result
        Else
            'set error
        End If
        Return Nothing
    End Function
End Class
