Imports System.IO
Imports System.Reflection
Imports System.Text

Public Class libreg
    Public Shared files As New ArrayList
    Friend Shared assemblymap As mapstoredata
    Friend Shared externtypes As mapstoredata
    Friend Shared asmtypemapstore As mapstoredata
    Public Shared s As Type
    Public Shared types()() As MethodInfo
    Public Shared _externinf() As _extern_info
    Public Structure _extern_info
        Dim name As String
        Dim asmname As String
        Dim fullname As String
        Dim msnamespace As String
        Dim location As String
        Dim asmmethod() As _method
    End Structure
    Public Structure _method
        Dim methodname As String
        Dim methodparameter As String
    End Structure
    Public Shared Sub init_lib(path As String)
        assemblymap = New mapstoredata
        externtypes = New mapstoredata
        asmtypemapstore = New mapstoredata
        get_dll_list(path, files, True)
        If files.Count = 0 Then
            Environment.Exit(-2)
        End If
        get_dll_info()
    End Sub

    Friend Shared Sub get_dll_info()
        extract_dt_info_to_map(Assembly.Load("System.Private.CoreLib"))
        For index = 0 To files.Count - 1
            Try
                Console.WriteLine(files(index).ToString)
                extract_dt_info_to_map(Assembly.LoadFrom(files(index).ToString))
            Catch ex As Exception
            End Try
        Next
        Dim yoda As New yoda
        File.WriteAllText(conrex.TARGETCACHEDIR & "\types.yoda", yoda.WriteYODA_Map(asmtypemapstore.keys, asmtypemapstore.values, True))
    End Sub

    Public Shared Sub extract_dt_info_to_map(asm As Assembly)
        For Each asmtype In asm.GetTypes
            asmtypemapstore.add(asmtype.FullName, asmtype.Assembly.GetName.Name)
        Next
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
