Public Class netcorerectifier
    Friend Shared cilcheckassembly As New ArrayList
    Friend Shared keychecklistcount As Integer
    Public Shared Sub assembly_checking(ByRef clinecode As String)
        Dim ibar As Integer = 0
        For index = 0 To keychecklistcount
            If clinecode.StartsWith(cilcheckassembly(index).ToString) Then
                While clinecode.Contains(conrex.BRSTART & conrex.MSCORLIB & conrex.BREND)
                    Dim fullname As String = clinecode.Remove(0, clinecode.IndexOf(conrex.BREND) + 1)
                    Dim cdbcln, cspace As Integer
                    cdbcln = 1000
                    cspace = 1000
                    If fullname.Contains(conrex.DBCLN) Then
                        cdbcln = fullname.IndexOf(conrex.DBCLN)
                    End If
                    If fullname.Contains(conrex.SPACE) Then
                        cspace = fullname.IndexOf(conrex.SPACE)
                    End If

                    If cspace > 0 AndAlso cspace < cdbcln Then
                        fullname = fullname.Remove(fullname.IndexOf(conrex.SPACE))
                    ElseIf cdbcln > 0 AndAlso cspace > cdbcln Then
                        fullname = fullname.Remove(fullname.IndexOf(conrex.DBCLN))
                    End If
                    Dim assemblyname As String = fullname_checking(fullname, conrex.MSCORLIB)
                    clinecode = clinecode.Replace("[mscorlib]" & fullname, String.Format("[{0}]{1}", assemblyname, fullname))
                    If ibar > 10 Then Return
                    ibar += 1
                End While
                Return
            End If
        Next
    End Sub

    Public Shared Function fullname_checking(fullname As String, assemblyname As String) As String
        If compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetFramework OrElse assemblyname <> conrex.MSCORLIB Then Return assemblyname
        Dim d1, d2 As Integer
        If fullname.StartsWith("System.") Then
            d1 = Asc(fullname(7).ToString.ToUpper) - 65
            d2 = Asc(fullname(8).ToString.ToUpper) - 65
        Else
            d1 = Asc(fullname(1).ToString.ToUpper) - 65
            d2 = Asc(fullname(2).ToString.ToUpper) - 65
        End If
        If d1 < 0 OrElse d2 < 0 OrElse d1 > 25 OrElse d2 > 25 Then
            d1 = 0
            d2 = 0
        End If
        Dim asmsinglelist As ArrayList = asmlist.typelist(d1)(d2)
        Dim asmlistcount As Integer = asmsinglelist.Count - 1
        For index = 0 To asmlistcount
            If asmsinglelist(index).ToString = fullname Then
                Return asmlist.assemblylist(d1)(d2)(index).ToString
            End If
        Next
        Return assemblyname
    End Function

End Class
