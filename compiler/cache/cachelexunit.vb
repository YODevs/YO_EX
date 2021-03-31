Imports YOCA

Public Class cachelexunit
    Friend Shared Function check_lexer_cache(ByRef tknfmtclass As tknformat._class, path As String) As Boolean
        tknfmtclass.location = path
        cachegtr.check_cache_repo(tknfmtclass)
        If tknfmtclass.cacheinf.active Then
            Return True
        Else
            Return False
        End If
    End Function


    Private frclass() As tknformat._class
    Public Sub New(tknfmtclass() As tknformat._class)
        Me.frclass = tknfmtclass
    End Sub
    Public Sub lex_to_serialization()
        If cachemkr.cacheprojectdir = conrex.NULL Then cachemkr.create_cache_route()
        For index = 0 To frclass.Length - 1
            If IsNothing(frclass(index).methods) = False Then
                For ielem = 0 To frclass(index).methods.Length - 1
                    frclass(index).methods(ielem).bodyxmlfmt = conrex.NULL
                Next
            End If
            Dim filepath As String = cachemkr.cacheprojectdir & servinterface.get_hash(frclass(index).location) & conrex.LEXCACHEFORMAT
            Dim nxmlserializer As New Xml.Serialization.XmlSerializer(frclass(index).GetType)
            Dim nstreamwriter As New IO.StreamWriter(filepath)
            nxmlserializer.Serialize(nstreamwriter, frclass(index))
        Next
    End Sub
End Class
