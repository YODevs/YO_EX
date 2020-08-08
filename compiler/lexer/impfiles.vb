Imports System.IO

Public Class impfiles
    Public Shared Sub import_directory(dir As String)
        If Directory.Exists(dir) Then
            Dim files As New ArrayList
            Dim ilgen As ilgencode
            If get_yo_files(dir, files) Then
                Dim tknfmtclass(files.Count - 1) As tknformat._class
                For index = 0 To files.Count - 1
                    Dim lex As New lexer(files(index).ToString)
                    lex.lexme(tknfmtclass(index))
                Next
                ilgen = New ilgencode(tknfmtclass)
                ilgen.codegenerator()
            Else
                Return
            End If
        Else
            dserr.new_error(conserr.errortype.DIRNOTFOUND, -1, Nothing, dir & " => dir not found.")
        End If
    End Sub

    Friend Shared Function get_yo_files(dir As String, ByRef files As ArrayList) As Boolean

        If Directory.GetFiles(dir).Count = 0 Then
            dserr.new_error(conserr.errortype.YOFILENOTFOUND, -1, Nothing, "path => " & dir)
            Return False
        End If

        Dim file As String = Nothing
        For index = 0 To Directory.GetFiles(dir).Count - 1
            file = Directory.GetFiles(dir)(index)
            If file.ToLower.EndsWith(conrex.YOFORMAT) Then
                files.Add(file)
            End If
        Next

        'TODO : Check files in directory .

        If files.Count = 0 Then
            dserr.new_error(conserr.errortype.YOFILENOTFOUND, -1, Nothing, "path => " & dir)
            Return False
        End If
        Return True
    End Function
End Class
