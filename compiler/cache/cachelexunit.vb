Imports System.IO
Imports YOCA

Public Class cachelexunit
    Enum cachecheckstate
        INCLUDEFILE
        PROJECTFILE
    End Enum
    Friend Shared Function check_lexer_cache(ByRef tknfmtclass As tknformat._class, path As String) As Boolean
        If compdt.DEVMOD = True Then Return False
        If compdt.NOCACHE = True Then Return False
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
            check_exist_source(incfile.incspath, cachecheckstate.INCLUDEFILE)
        End If
    End Sub
    Friend Shared Sub load_includes(tknfmtclass As tknformat._class())
        Dim cacheprojectdir As String = conrex.CACHEDIR & "\fastbuild\" & servinterface.get_hash(conrex.ENVCURDIR) & "\"
        If Directory.Exists(cacheprojectdir) Then
            For index = 0 To tknfmtclass.Length - 1
                check_exist_source(tknfmtclass(index).includelist, cachecheckstate.INCLUDEFILE)
                For i2 = 0 To tknfmtclass(index).includelist.Count - 1
                    incfile.add_new_path(tknfmtclass(index).includelist(i2).ToString)
                Next
            Next
        End If
    End Sub

    Friend Shared Sub check_exist_source(files As ArrayList, checkstate As cachecheckstate)
        If checkstate = cachecheckstate.INCLUDEFILE Then
            If files.Count = 0 Then Return
            For index = 0 To files.Count - 1
                If File.Exists(files(index).ToString) = False Then
                    Dim cacheprojectdir As String = conrex.CACHEDIR & "\fastbuild\" & servinterface.get_hash(conrex.ENVCURDIR) & "\"
                    File.WriteAllText(cacheprojectdir & ".delete", conrex.NULL)
                    dserr.args.Add(files(index).ToString)
                    dserr.new_error(conserr.errortype.ACCESSINGFILEERROR, -1, Nothing, "This error occurs when the compiler cannot access the project files.", "Use the compile command again: yoca build Or yoca run")
                End If
            Next
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
                save_single_include_file(frclass(index))
            End If
        Next
    End Sub

    Private Sub save_single_include_file(frclass As tknformat._class)
        Dim path As String = cachemkr.cacheprojectdir & servinterface.get_hash(frclass.location) & "inc" & conrex.YODAFORMAT
        If IsNothing(frclass.includelist) OrElse frclass.includelist.Count = 0 Then
            File.WriteAllText(path, conrex.YODAEMPTYDATA)
        Else
            Dim includes As New YODA.YODA_Format
            Dim getincludeyodafmt As String = includes.WriteYODA(frclass.includelist)
            File.WriteAllText(path, getincludeyodafmt)
        End If
    End Sub
    Friend Shared Sub save_include_file()
        Dim includes As New YODA.YODA_Format
        Dim getincludeyodafmt As String = includes.WriteYODA(incfile.incspath)
        File.WriteAllText(cachemkr.cacheprojectdir & "includes.yoda", getincludeyodafmt)
    End Sub
End Class
