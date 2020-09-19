Public Class syntaxloader

    Enum statements
        TOITER
    End Enum

    Structure syntaxtypesloader
        Dim statetype As statements
        Dim statename As String
        Dim exptokenslist As ArrayList
        Dim example As String
    End Structure

    Friend Shared syntploader() As syntaxtypesloader

    Private Shared Sub set_syntax_loader(statetype As statements, statename As String, exptokenslist As ArrayList, Optional example As String = Nothing)
        Static Dim indexarray As Int16 = 0
        Array.Resize(syntploader, indexarray + 1)
        syntploader(indexarray) = New syntaxtypesloader
        syntploader(indexarray).statetype = statetype
        syntploader(indexarray).statename = statename
        syntploader(indexarray).exptokenslist = exptokenslist
        syntploader(indexarray).example = example
        indexarray += 1
        Return
    End Sub

    Public Shared Sub init_syntax_loader()
        'TO Iter
        st_to()
    End Sub

    Private Shared Sub st_to()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.TO)
        add_token(exptokenslist, tokenhared.token.PRSTART)
        add_token(exptokenslist, tokenhared.token.TYPE_INT, tokenhared.token.IDENTIFIER, tokenhared.token.EXPRESSION)
        add_token(exptokenslist, tokenhared.token.PREND)
        add_token(exptokenslist, tokenhared.token.BLOCKOP)

        set_syntax_loader(statements.TOITER, "TO Statement", exptokenslist, "to(5){
...
}")
    End Sub

    Private Shared Sub add_token(ByRef exptokenslist As ArrayList, ParamArray ByVal tkn() As tokenhared.token)
        If tkn.Length = 1 Then
            exptokenslist.Add(tkn(0))
        Else
            Dim tkns As String = String.Empty
            For index = 0 To tkn.Length - 1
                If tkns = String.Empty Then
                    tkns = tkn(index)
                Else
                    tkns &= conrex.CMA & tkn(index)
                End If
            Next
            exptokenslist.Add(tkns)
        End If
    End Sub

End Class
