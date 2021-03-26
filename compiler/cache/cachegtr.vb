Imports System.IO
Imports YOCA

Public Class cachegtr
    Private Shared cacheprojectdir As String = String.Empty
    Friend Shared Sub check_cache_repo(ByRef tknfmtclass As tknformat._class())
        If compdt.NOCACHE Then Return
        If cacheprojectdir = conrex.NULL Then cacheprojectdir = conrex.CACHEDIR & "\fastbuild\" & servinterface.get_hash(conrex.ENVCURDIR) & "\"
        For index = 0 To tknfmtclass.Length - 1
            If tknfmtclass(index).attribute._cfg._no_cache = True Then
                tknfmtclass(index).cacheinf.active = False
                Continue For
            End If
            Dim sourcepath As String = cacheprojectdir & servinterface.get_hash(tknfmtclass(index).location)
            Dim sourceinfopath As String = sourcepath & conrex.YODAFORMAT
            If File.Exists(sourcepath) = False OrElse File.Exists(sourceinfopath) = False Then
                tknfmtclass(index).cacheinf.active = False
            Else
                check_file_information(tknfmtclass(index), sourcepath, sourceinfopath)
            End If
        Next
    End Sub

    Private Shared Sub check_file_information(ByRef tknfmtclass As tknformat._class, sourcepath As String, sourceinfopath As String)
        Dim getinfofile As String = File.ReadAllText(sourceinfopath)
        Dim fileinfo As New YODA.YODA_Format
        Dim fileinforesult As YODA.YODA_Format.YODAMapFormat = fileinfo.ReadYODA_Map(getinfofile)
        If fileinforesult.keys.Count <> 3 Then
            tknfmtclass.cacheinf.active = False
            Return
        End If
        compare_data_inforamtion(tknfmtclass, fileinforesult, sourcepath)
    End Sub

    Private Shared Sub compare_data_inforamtion(ByRef tknfmtclass As tknformat._class, fileinforesult As YODA.YODA_Format.YODAMapFormat, sourcepath As String)
        Dim mfilelocation As String = tknfmtclass.location
        Dim filemapdata As New mapstoredata
        filemapdata.import_collection(fileinforesult.keys, fileinforesult.values)

        If mfilelocation <> filemapdata.find("path").result Then
            tknfmtclass.cacheinf.active = False
            Return
        End If

        If File.GetCreationTime(mfilelocation).ToFileTimeUtc.ToString <> filemapdata.find("dt_cr").result.ToString Then
            tknfmtclass.cacheinf.active = False
            Return
        End If

        If File.GetLastWriteTime(mfilelocation).ToFileTimeUtc.ToString <> filemapdata.find("dt_mod").result.ToString Then
            tknfmtclass.cacheinf.active = False
            Return
        End If

        tknfmtclass.cacheinf.active = True
        tknfmtclass.cacheinf.path = sourcepath
        tknfmtclass.cacheinf.datecreated = filemapdata.find("dt_cr").result
        tknfmtclass.cacheinf.datemodified = filemapdata.find("dt_mod").result
    End Sub
End Class
