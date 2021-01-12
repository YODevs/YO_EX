Public Class syntaxloader

    Enum statements
        TOITER
        LABELJMP
        JMP
        [CONTINUE]
        BREAK
        [LOOP]
        [TRY]
        [CATCH]
        ERR
        RET
        MATCH
        [CASE]
        [DEFAULT]
        [ELSE]
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
        'Set Label , Jump Statement
        st_labeljmp()
        'Set JMP Statement
        st_jmp()
        'Set Continue Statement
        st_continue()
        'Set Break Statement
        st_break()
        'Inifinity Loop
        st_loop()
        'Try Block
        st_try()
        'Catch Block
        st_catch()
        'Err Statement
        st_err()
        'Return Statement
        st_ret()
        'Match Statement
        st_match()
        'Case Statement
        st_case()
        'Default Statement
        st_default()
        'Else Statement
        st_else()
    End Sub

    Private Shared Sub st_else()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.ELSE)
        add_token(exptokenslist, tokenhared.token.BLOCKOP)
        set_syntax_loader(statements.ELSE, "Else Statement", exptokenslist, "let temp : i32 = 20
  if(temp >> 24)
  {
    System.Console::Write('WARM')
  }else{
    System.Console::Write('COOL')
  }")
    End Sub

    Private Shared Sub st_default()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.DEFAULT)
        add_token(exptokenslist, tokenhared.token.BLOCKOP)
        set_syntax_loader(statements.DEFAULT, "Case Statement", exptokenslist, "match(inf)
  {
    case 'start'  {
      System.Console::WriteLine('Starting service...')
    }

    case 'stop'  {
    System.Console::WriteLine('Stopping service...')
    }

default {
    System.Console::WriteLine('Command not found')
}
  }")
    End Sub

    Private Shared Sub st_case()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.CASE)
        add_token(exptokenslist, tokenhared.token.TYPE_CO_STR, tokenhared.token.TYPE_DU_STR, tokenhared.token.TYPE_INT, tokenhared.token.TYPE_FLOAT,
tokenhared.token.TRUE, tokenhared.token.FALSE, tokenhared.token.IDENTIFIER, tokenhared.token.NULL)
        add_token(exptokenslist, tokenhared.token.BLOCKOP)
        set_syntax_loader(statements.CASE, "Case Statement", exptokenslist, "match(inf)
  {
    case 'start'  {
      System.Console::WriteLine('Starting service...')
    }

    case 'stop'  {
    System.Console::WriteLine('Stopping service...')
    }
  }")
    End Sub

    Private Shared Sub st_match()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.MATCH)
        add_token(exptokenslist, tokenhared.token.PRSTART)
        add_token(exptokenslist, tokenhared.token.TYPE_CO_STR, tokenhared.token.TYPE_DU_STR, tokenhared.token.TYPE_INT, tokenhared.token.TYPE_FLOAT,
tokenhared.token.TRUE, tokenhared.token.FALSE, tokenhared.token.IDENTIFIER, tokenhared.token.NULL)
        add_token(exptokenslist, tokenhared.token.PREND)
        add_token(exptokenslist, tokenhared.token.BLOCKOP)
        set_syntax_loader(statements.MATCH, "Match Statement", exptokenslist, "match(inf)
  {
    case 'start'  {
      System.Console::WriteLine('Starting service...')
    }

    case 'stop'  {
    System.Console::WriteLine('Stopping service...')
    }
  }")
    End Sub

    Private Shared Sub st_ret()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.RETURN)
        add_token(exptokenslist, tokenhared.token.TYPE_CO_STR, tokenhared.token.TYPE_DU_STR, tokenhared.token.TYPE_INT, tokenhared.token.TYPE_FLOAT,
tokenhared.token.TRUE, tokenhared.token.FALSE, tokenhared.token.IDENTIFIER, tokenhared.token.NULL)
        set_syntax_loader(statements.RET, "Return Statement", exptokenslist, "return [IDENTIFIER|STRING|INTEGER|...]")
    End Sub

    Private Shared Sub st_err()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.ERR)
        add_token(exptokenslist, tokenhared.token.TYPE_CO_STR, tokenhared.token.TYPE_DU_STR)
        set_syntax_loader(statements.ERR, "Err Statement", exptokenslist, "err 'Error : Attempted to divide by zero.'")
    End Sub

    Private Shared Sub st_try()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.TRY)
        add_token(exptokenslist, tokenhared.token.BLOCKOP)

        set_syntax_loader(statements.TRY, "Try Statement", exptokenslist, "try{
...
}")
    End Sub

    Private Shared Sub st_catch()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.CATCH)
        add_token(exptokenslist, tokenhared.token.BLOCKOP)

        set_syntax_loader(statements.TRY, "Try Statement", exptokenslist, "try{
...
}")
    End Sub
    Private Shared Sub st_continue()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.CONTINUE)
        add_token(exptokenslist, tokenhared.token.TO, tokenhared.token.LOOP, tokenhared.token.WHILE)

        set_syntax_loader(statements.CONTINUE, "Continue Statement", exptokenslist)
    End Sub
    Private Shared Sub st_break()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.BREAK)
        add_token(exptokenslist, tokenhared.token.UL, tokenhared.token.TO, tokenhared.token.LOOP, tokenhared.token.TRY, tokenhared.token.WHILE, tokenhared.token.MATCH)

        set_syntax_loader(statements.BREAK, "Break Statement", exptokenslist)
    End Sub
    Private Shared Sub st_loop()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.LOOP)
        add_token(exptokenslist, tokenhared.token.BLOCKOP)

        set_syntax_loader(statements.LOOP, "Loop Statement", exptokenslist, "loop{
...
}")
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

    Private Shared Sub st_jmp()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.JMP)
        add_token(exptokenslist, tokenhared.token.LABELJMP)
        set_syntax_loader(statements.JMP, "Label Statement", exptokenslist, "$start:

#>code 1 ...
#>code 2 ...
#>code 3 ...


jmp $start
")
    End Sub
    Private Shared Sub st_labeljmp()
        Dim exptokenslist As New ArrayList
        add_token(exptokenslist, tokenhared.token.LABELJMP)
        add_token(exptokenslist, tokenhared.token.ASSINQ)
        set_syntax_loader(statements.LABELJMP, "Label Statement", exptokenslist, "$start:

#>code 1 ...
#>code 2 ...
#>code 3 ...


jmp $start
")
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
