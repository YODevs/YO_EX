Imports System
Imports System.IO
Imports ExtendedXmlSerializer

Module mainproc
    Sub Main(args As String())
        If args.Length < 2 Then Return
        conrex.TARGETFRAMEWORK = args(0)
        conrex.TARGETCACHEDIR = args(1).Replace("@#SP#", conrex.SPACE)
        conrex.TARGETMAJORVER = conrex.TARGETFRAMEWORK.Remove(conrex.TARGETFRAMEWORK.IndexOf("."))
        libreg.init_lib(get_targetdir())
        Console.ReadLine()
        Environment.Exit(0)
    End Sub
    Function get_targetdir() As String
        If Directory.Exists(conrex.DOTNETCOREROOT) = False Then
            Console.Write(".Net Core not found.")
            Environment.Exit(-1)
        End If
        For Each sdir In Directory.GetDirectories(conrex.DOTNETCOREROOT)
            If sdir.StartsWith(conrex.DOTNETCOREROOT & conrex.TARGETMAJORVER & conrex.DOT) Then
                Return sdir
            End If
        Next
        Console.Write("Version " & conrex.TARGETMAJORVER & " of .NET Core is not installed")
        Environment.Exit(-2)
    End Function

    Public Sub WriteXML()
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(libreg))
        Dim file As New System.IO.StreamWriter(
          "C:\Users\AminCoder\AppData\Local\YOLang\.NetCoreCache\6.0.100\types.xml")
        ' writer.Serialize(file, CObj(libreg))
        file.Close()
    End Sub
End Module
