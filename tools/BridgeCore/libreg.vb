Imports System.IO
Imports System.Reflection

Public Class libreg
    Public Shared files As New ArrayList
    Friend Shared assemblymap As mapstoredata
    Friend Shared externtypes As mapstoredata
    Friend Shared types()() As Type
    Public Shared Sub init_libraries(path As String)
        assemblymap = New mapstoredata
        externtypes = New mapstoredata
        get_dll_list(path, files, True)
        get_dll_info()
    End Sub

    Friend Shared Sub get_dll_info()
        Dim asm As [Assembly]
        For index = 0 To files.Count - 1
            Try
                asm = [Assembly].LoadFrom(files(index).ToString)
                extract_dt_info_to_map(asm)
            Catch ex As Exception

            End Try
        Next
        Environment.Exit(0)
    End Sub

    Private Shared Sub extract_dt_info_to_map(asm As Assembly)
        assemblymap.add(asm.GetName.Name, asm.Location)
        Static Dim indexarray As Int16 = 0
        Array.Resize(types, indexarray + 1)
        Dim index As Integer = 0
        For Each asmtype In asm.GetTypes()
            Array.Resize(types(indexarray), index + 1)
            Dim nsname As String = String.Empty
            If asmtype.Namespace <> conrex.NULL Then
                nsname = asmtype.Namespace & conrex.DOT
            End If
            nsname &= asmtype.Name
            externtypes.add(nsname, indexarray & conrex.CMA & index)
            types(indexarray)(index) = asmtype
            index += 1
        Next
        indexarray += 1
    End Sub

    Friend Shared Function get_dll_list(dir As String, ByRef files As ArrayList, Optional head As Boolean = False) As Boolean
        Dim file As String = Nothing
        For index = 0 To Directory.GetFiles(dir).Count - 1
            file = Directory.GetFiles(dir)(index)
            If file.ToLower.EndsWith(conrex.DNLIBFORMAT) AndAlso file.ToLower.StartsWith("api.") = False Then
                files.Add(file)
            End If
        Next

        Dim route As String = Nothing
        For index = 0 To Directory.GetDirectories(dir).Count - 1
            route = Directory.GetDirectories(dir)(index)
            get_dll_list(route, files)
        Next

        If head Then
            Return True
        End If
        Return True
    End Function

End Class
