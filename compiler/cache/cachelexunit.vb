Imports System.IO
Imports YOCA

Public Class cachelexunit
    Friend Shared Function check_lexer_cache(ByRef tknfmtclass As tknformat._class, path As String) As Boolean
        If compdt.DEVMOD = True Then Return False
        tknfmtclass.location = path
        cachegtr.check_cache_repo(tknfmtclass)
        If tknfmtclass.cacheinf.active Then
            procresult.rp_lex_file(path & " [CA]")
            deserialize_lex(tknfmtclass)
            procresult.rs_proc_data(True)
            Return True
        Else
            Return False
        End If
    End Function
    Friend Shared Sub deserialize_lex(ByRef tknfmtclass As tknformat._class)
        If tknfmtclass.cacheinf.active = False Then Return
        If cachemkr.cacheprojectdir = conrex.NULL Then cachemkr.create_cache_route()
        Dim filepath As String = cachemkr.cacheprojectdir & servinterface.get_hash(tknfmtclass.location) & conrex.LEXCACHEFORMAT
        Dim nxmlserializer As New Xml.Serialization.XmlSerializer(tknfmtclass.GetType)
        Dim streamreader As New IO.StreamReader(filepath)
        tknfmtclass = nxmlserializer.Deserialize(streamreader)
    End Sub

    Friend Shared Sub load_includes()
        Dim cacheprojectdir As String = conrex.CACHEDIR & "\fastbuild\" & servinterface.get_hash(conrex.ENVCURDIR) & "\"
        If Directory.Exists(cacheprojectdir) AndAlso File.Exists(cacheprojectdir & "includes.yoda") Then
            Dim yoda As New YODA.YODA_Format
            incfile.incspath = yoda.ReadYODA(File.ReadAllText(cacheprojectdir & "includes.yoda"))
        End If
    End Sub

    Private frclass() As tknformat._class
    Public Sub New(tknfmtclass() As tknformat._class)
        Me.frclass = tknfmtclass
    End Sub
    Public Sub lex_to_serialization()
        If cachemkr.cacheprojectdir = conrex.NULL Then cachemkr.create_cache_route()
        For index = 0 To frclass.Length - 1
            If frclass(index).cacheinf.active = False Then
                If IsNothing(frclass(index).methods) = False Then
                    For ielem = 0 To frclass(index).methods.Length - 1
                        frclass(index).methods(ielem).bodyxmlfmt = conrex.NULL
                    Next
                End If
                Dim filepath As String = cachemkr.cacheprojectdir & servinterface.get_hash(frclass(index).location) & conrex.LEXCACHEFORMAT
                Dim nxmlserializer As New Xml.Serialization.XmlSerializer(frclass(index).GetType)
                Dim nstreamwriter As New IO.StreamWriter(filepath)
                nxmlserializer.Serialize(nstreamwriter, frclass(index))
            End If
        Next
        save_include_file()
    End Sub

    Private Sub save_include_file()
        Dim includes As New YODA.YODA_Format
        Dim getincludeyodafmt As String = includes.WriteYODA(incfile.incspath)
        File.WriteAllText(cachemkr.cacheprojectdir & "includes.yoda", getincludeyodafmt)
    End Sub
End Class
