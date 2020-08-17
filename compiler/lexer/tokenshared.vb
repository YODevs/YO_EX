Public Class tokenhared
    Public Shared tokenopt() As Object = {" ", "=", "&", "+", "-", "*", "/", "%", "|", ">", "<", ",", "(", ")", "{", "}", ".", ":"}
    Public Shared conditionToken() As Object = {"==", "<>", ">>", "<<", ">=", "<="}
    Private Shared _token As Dictionary(Of token, String)
    Private Shared _tokensym As New Dictionary(Of token, String)

    Friend Shared Sub init()
        _token = New Dictionary(Of token, String)()
        _token.Add(token.TO, "to")
        _token.Add(token.IF, "if")
        _token.Add(token.ELSEIF, "elseif")
        _token.Add(token.ELSE, "else")
        _token.Add(token.FUNC, "func")
        _token.Add(token.CONST, "const")
        _token.Add(token.[NEW], "new")
        _token.Add(token.NULL, "null")
        _token.Add(token.BREAK, "break")
        _token.Add(token.CONTINUE, "continue")
        _token.Add(token.WHILE, "while")
        _token.Add(token.LOOP, "loop")
        _token.Add(token.MATCH, "match")
        _token.Add(token.CASE, "case")
        _token.Add(token.RETURN, "return")
        _token.Add(token.LET, "let")

        _tokensym.Add(token.ASSIDB, ":=")
        _tokensym.Add(token.R2KO, "<<")
        _tokensym.Add(token.L2KO, ">>")
        _tokensym.Add(token.CONDEQ, "==")
        _tokensym.Add(token.LKOEQ, ">=")
        _tokensym.Add(token.RKOEQ, "<=")
        _tokensym.Add(token.ANDLOGIC, "&&")
        _tokensym.Add(token.ORLOGIC, "||")
        _tokensym.Add(token.LRNA, "<>")
        _tokensym.Add(token.PLUSMA, "++")
        _tokensym.Add(token.MINUSMA, "--")
        _tokensym.Add(token.PLUSEQ, "+=")
        _tokensym.Add(token.MINUSEQ, "-=")
        _tokensym.Add(token.SLASHEQ, "/=")
        _tokensym.Add(token.REMINDEQ, "%=")
        _tokensym.Add(token.ASTERISKEQ, "*=")
        _tokensym.Add(token.ANDEQ, "&=")
        _tokensym.Add(token.DUTNQ, "::")
        _tokensym.Add(token.ASSINQ, ":")
        _tokensym.Add(token.ASTERISK, "*")
        _tokensym.Add(token.SLASH, "/")
        _tokensym.Add(token.PLUS, "+")
        _tokensym.Add(token.MINUS, "-")
        _tokensym.Add(token.[AND], "&")
        _tokensym.Add(token.LKO, ">")
        _tokensym.Add(token.RKO, "<")
        _tokensym.Add(token.EQUALS, "=")
        _tokensym.Add(token.CMA, ",")
        _tokensym.Add(token.BLOCKOPEN, "{")
        _tokensym.Add(token.BLOCKEND, "}")
        _tokensym.Add(token.PRSTART, "(")
        _tokensym.Add(token.PREND, ")")
        _tokensym.Add(token.DOT, ".")
    End Sub


    Public Shared Function check_opt(getch As Char) As Boolean
        For index = 0 To tokenopt.Length - 1
            If tokenopt(index) = getch Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Shared Function check_sym(target As String) As Integer
        For Each pair As KeyValuePair(Of token, String) In _tokensym
            If pair.Value = target Then
                Return pair.Key
            End If
        Next
        Return token.UNDEFINED
    End Function
    Public Shared Function check_keyword(target As String) As Integer
        target = target.ToLower
        For Each pair As KeyValuePair(Of token, String) In _token
            If pair.Value = target Then
                Return pair.Key
            End If
        Next
        Return token.UNDEFINED
    End Function

    Public Shared Function check_common_type(ByRef target As String) As Integer
        Dim datatyperesult As mapstoredata.dataresult = initcommondatatype.cdtype.find(target.ToLower)
        If datatyperesult.issuccessful Then
            target = target.ToLower
            Return token.COMMONDATATYPE
        Else
            Return token.UNDEFINED
        End If
    End Function
    Public Enum token
        UNDEFINED = 0
        COMMENT = 1
        NEWLINE_EMP = 2
        [TO] = 3
        [IF] = 4
        [ELSEIF] = 5
        [ELSE] = 6
        FUNC = 7
        [CONST] = 8
        [NEW] = 9
        NULL = 10
        BREAK = 11
        [CONTINUE] = 12
        [WHILE] = 13
        [LOOP] = 14
        MATCH = 15
        [CASE] = 16
        [RETURN] = 17
        ASSIDB = 18
        R2KO = 19
        L2KO = 20
        CONDEQ = 21
        LKOEQ = 22
        RKOEQ = 23
        ANDLOGIC = 24
        ORLOGIC = 25
        LRNA = 26
        PLUSMA = 27
        MINUSMA = 28
        PLUSEQ = 29
        MINUSEQ = 30
        SLASHEQ = 31
        REMINDEQ = 32
        ASTERISKEQ = 33
        ANDEQ = 34
        ASTERISK = 35
        SLASH = 36
        PLUS = 37
        MINUS = 38
        [AND] = 39
        LKO = 40
        RKO = 41
        CMA = 42
        BLOCKOPEN = 43
        BLOCKEND = 44
        EQUALS = 45
        TYPE_BOOL = 46
        TYPE_INT = 47
        TYPE_FLOAT = 48
        IDENTIFIER = 49
        FUNCTIONIDENTIFIER = 50
        PRSTART = 51
        PREND = 52
        TYPE_CO_STR = 53
        TYPE_DU_STR = 54
        DOT = 55
        DUTNQ = 56
        [LET] = 57
        COMMONDATATYPE = 58
        ASSINQ = 59
    End Enum
End Class
