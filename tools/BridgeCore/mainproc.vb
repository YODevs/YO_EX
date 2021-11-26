Imports System

Module mainproc
    Sub Main(args As String())
        If args.Length < 2 Then Return
        conrex.TARGETFRAMEWORK = args(0)
        conrex.TARGETCACHEDIR = args(1).Replace("@#SP#", conrex.SPACE)
        Console.WriteLine(conrex.TARGETCACHEDIR)
    End Sub
End Module
