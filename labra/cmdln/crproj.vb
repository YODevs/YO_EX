Public Class crproj
    Dim yoda As YODA.YODA_Format
    Public Sub New()
        yoda = New YODA.YODA_Format
    End Sub

    Public Sub init_project()
        Dim asmname As String = get_assembly_name()
    End Sub

    Private Function get_assembly_name() As String
        Dim checkit As Boolean = True
        Dim asmname As String = String.Empty
        While checkit
            If asmname = String.Empty Then
                Console.Write("Assembly name [ex:myapp]: ")
            Else
                Console.Write(vbLf & "Assembly name [ex:myapp]: ")
            End If
            asmname = Console.ReadLine.Trim
            check_assembly_name(checkit, asmname)
        End While
        Return asmname
    End Function
    Private Sub check_assembly_name(ByRef continueloop As Boolean, asmname As String)
        Dim errtext As String = String.Empty
        If asmname = Nothing Then
            errtext = "Assembly name can not be empty, write a custom name like 'myfirstapp'."
        ElseIf Asc(asmname(0).ToString.ToUpper) < 65 OrElse Asc(asmname(0).ToString.ToUpper) > 90 Then
            errtext = "Assembly name must start with letters , [a-z,A-Z]."
        Else
            For index = 0 To asmname.Length - 1
                If Asc(asmname(index).ToString.ToUpper) < 65 OrElse Asc(asmname(index).ToString.ToUpper) > 90 Then
                    If IsNumeric(asmname(index)) OrElse asmname(index) = "_" Then
                        Continue For
                    End If
                    errtext = "[ " & asmname(index) & " ]- The assembly name can be a combination of letters, numbers and the character '_'."
                    Exit For
                End If
            Next
        End If

        If errtext <> conrex.NULL Then
            dserr.set_error("Assembly name", errtext)
        Else
            continueloop = False
        End If
    End Sub
End Class
