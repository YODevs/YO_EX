''' <summary>
''' <en>
''' 
''' </en>
''' <fa>
''' تولید آرگومان های MSIL
''' </fa>
''' </summary>
Public Class ilasmparam

    Private paramlist As String
    Public Sub New()

    End Sub

    Public Sub add_param(argument As String)
        paramlist &= argument & conrex.SPACE
    End Sub
    Public Sub add_param(argument As String, value As String)
        If compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetCore Then
            paramlist &= argument & conrex.SPACE & value & conrex.SPACE
        Else
            paramlist &= argument & conrex.EQU & value & conrex.SPACE
        End If
    End Sub

    Public Sub add_file(path As String)
        path = conrex.DUSTR & path & conrex.DUSTR
        paramlist = path & Space(1) & paramlist
    End Sub
    Public Function get_param_list() As String
        Return paramlist
    End Function
End Class
