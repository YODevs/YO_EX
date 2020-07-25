Public Class tokenhared
    Public Shared operatorToken() As Object = {"=", "&", "+", "-", "*", ":", "/", "%", "|", ">", "<", ","}
    Public Shared conditionToken() As Object = {"==", "<>", ">>", "<<", ">=", "<="}
    Private Shared _token As Dictionary(Of token, String)
    Private Shared _tokenSym As New Dictionary(Of token, String)

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

        _tokenSym.Add(token.ASSIDB, ":=")
        _tokenSym.Add(token.R2KO, "<<")
        _tokenSym.Add(token.L2KO, ">>")
        _tokenSym.Add(token.CONDEQ, "==")
        _tokenSym.Add(token.LKOEQ, ">=")
        _tokenSym.Add(token.RKOEQ, "<=")
        _tokenSym.Add(token.ANDLOGIC, "&&")
        _tokenSym.Add(token.ORLOGIC, "||")
        _tokenSym.Add(token.LRNA, "<>")
        _tokenSym.Add(token.PLUSMA, "++")
        _tokenSym.Add(token.MINUSMA, "--")
        _tokenSym.Add(token.PLUSEQ, "+=")
        _tokenSym.Add(token.MINUSEQ, "-=")
        _tokenSym.Add(token.SLASHEQ, "/=")
        _tokenSym.Add(token.REMINDEQ, "%=")
        _tokenSym.Add(token.ASTERISKEQ, "*=")
        _tokenSym.Add(token.ANDEQ, "&=")
        _tokenSym.Add(token.ASTERISK, "*")
        _tokenSym.Add(token.SLASH, "/")
        _tokenSym.Add(token.PLUS, "+")
        _tokenSym.Add(token.MINUS, "-")
        _tokenSym.Add(token.[AND], "&")
        _tokenSym.Add(token.LKO, ">")
        _tokenSym.Add(token.RKO, "<")
        _tokenSym.Add(token.EQUALS, "=")
        _tokenSym.Add(token.CMA, ",")
        _tokenSym.Add(token.BLOCKOPEN, "{")
        _tokenSym.Add(token.BLOCKEND, "}")

    End Sub


    Public Function checkOPR(target As String) As Boolean
        For Each pair As KeyValuePair(Of token, String) In _tokenSym
            If target = [Enum].GetName(GetType(tokenhared.token), pair.Key) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function checksym(target As String) As Integer
        target = target.ToLower
        For Each pair As KeyValuePair(Of token, String) In _tokenSym
            If pair.Value = target Then
                Return pair.Key
            End If
        Next
        Return token.UNDEFINED
    End Function
    Public Function check_keyword(target As String) As Integer
        target = target.ToLower
        For Each pair As KeyValuePair(Of token, String) In _token
            If pair.Value = target Then
                Return pair.Key
            End If
        Next
        Return token.UNDEFINED
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
    End Enum
End Class
