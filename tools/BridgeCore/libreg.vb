Imports System.IO
Imports System.Reflection

Public Class libreg
    Public Shared files As New ArrayList
    Friend Shared assemblymap As mapstoredata
    Friend Shared externtypes As mapstoredata
    Public Shared s As Type
    Public Shared types()() As MethodInfo

    Public Shared _externinf() As _extern_info
    Public Structure _extern_info
        Dim name As String
        Dim asmname As String
        Dim fullname As String
        Dim msnamespace As String
        Dim location As String
        '  Dim asmmethods() As MethodInfo
        Dim asmmethod() As _method
    End Structure
    Public Structure _method
        Dim methodname As String
        Dim methodparameter As String
    End Structure
    Public Shared Sub init_lib(path As String)
        assemblymap = New mapstoredata
        externtypes = New mapstoredata
        get_dll_list(path, files, True)
        If files.Count = 0 Then
            Environment.Exit(-2)
        End If
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
        Console.WriteLine("Start")
        type_serializer()
        Console.WriteLine("End")
        Environment.Exit(0)
    End Sub

    Public Shared Sub type_serializer()
        Dim filepath As String = conrex.TARGETCACHEDIR
        Dim nxmlserializer As New Xml.Serialization.XmlSerializer(GetType(_extern_info()))
        Dim nstreamwriter As New IO.StreamWriter(filepath & "\types.xml")
        nxmlserializer.Serialize(nstreamwriter, _externinf)
    End Sub

    Public Shared Sub extract_dt_info_to_map(asm As Assembly)
        'assemblymap.add(asm.GetName.Name, asm.Location)
        Static Dim indexarray As Int16 = 0
        For Each asmtype In asm.GetTypes()
            Array.Resize(_externinf, indexarray + 1)
            _externinf(indexarray) = New _extern_info
            If asmtype.Namespace <> conrex.NULL Then
                _externinf(indexarray).name = asmtype.Namespace & conrex.DOT
            End If
            _externinf(indexarray).name &= asmtype.Name
            _externinf(indexarray).asmname = asm.GetName.Name
            _externinf(indexarray).fullname = asmtype.FullName
            _externinf(indexarray).msnamespace = asmtype.Namespace
            _externinf(indexarray).location = asm.Location
            Dim i As Integer = 0
            For Each c In asmtype.GetMethods
                Array.Resize(_externinf(indexarray).asmmethod, i + 1)
                _externinf(indexarray).asmmethod(i) = New _method
                _externinf(indexarray).asmmethod(i).methodname = c.Name
                _externinf(indexarray).asmmethod(i).methodparameter = c.ReturnType.Name
                i += 1
            Next
            '_externinf(indexarray).asmmethods = asmtype.GetMethods
            indexarray += 1
        Next
    End Sub
    Private Sub extract_dt_info_to_map2(asm As Assembly)
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
            '   types(indexarray)(index) = asmtype.GetMethods
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
