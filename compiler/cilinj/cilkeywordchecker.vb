Public Class cilkeywordchecker
    Private Shared cilkey2w As New ArrayList
    Private Shared cilkey3w As New ArrayList
    Private Shared cilkey4w As New ArrayList
    Private Shared cilkey5w As New ArrayList
    Private Shared cilkey6w As New ArrayList
    Private Shared cilkey7w As New ArrayList
    Private Shared cilkeypl As New ArrayList
    Private Shared keywordmaxlen As Short = 0
    Friend Shared Sub init_keyword()
        import_cil_keyword("add")
        import_cil_keyword("and")
        import_cil_keyword("arglist")
        import_cil_keyword("beq")
        import_cil_keyword("bge")
        import_cil_keyword("bgt")
        import_cil_keyword("ble")
        import_cil_keyword("blt")
        import_cil_keyword("box", True)
        import_cil_keyword("br")
        import_cil_keyword("break")
        import_cil_keyword("brfalse")
        import_cil_keyword("brinst")
        import_cil_keyword("brnull")
        import_cil_keyword("brtrue")
        import_cil_keyword("brzero")
        import_cil_keyword("call", True)
        import_cil_keyword("callvirt", True)
        import_cil_keyword("calli", True)
        import_cil_keyword("castclass", True)
        import_cil_keyword("ceq")
        import_cil_keyword("cgt")
        import_cil_keyword("ckfinite")
        import_cil_keyword("clt")
        import_cil_keyword("constrained.")
        import_cil_keyword("cpblk")
        import_cil_keyword("cpobj")
        import_cil_keyword("div")
        import_cil_keyword("div.u")
        import_cil_keyword("dup")
        import_cil_keyword("endfault")
        import_cil_keyword("endfilter")
        import_cil_keyword("endfinally")
        import_cil_keyword("initblk")
        import_cil_keyword("initobj")
        import_cil_keyword("isinst")
        import_cil_keyword("jmp")
        import_cil_keyword("ldelem")
        import_cil_keyword("ldelema")
        import_cil_keyword("ldfld", True)
        import_cil_keyword("ldflda", True)
        import_cil_keyword("ldftn", True)
        import_cil_keyword("ldlen")
        import_cil_keyword("ldloc")
        import_cil_keyword("ldnull")
        import_cil_keyword("ldobj", True)
        import_cil_keyword("ldsfld", True)
        import_cil_keyword("ldsflda", True)
        import_cil_keyword("ldstr")
        import_cil_keyword("ldtoken", True)
        import_cil_keyword("ldvirtftn", True)
        import_cil_keyword("leave")
        import_cil_keyword("localloc")
        import_cil_keyword("mkrefany")
        import_cil_keyword("mul")
        import_cil_keyword("neg")
        import_cil_keyword("newarr", True)
        import_cil_keyword("newobj", True)
        import_cil_keyword("no.")
        import_cil_keyword("nop")
        import_cil_keyword("not")
        import_cil_keyword("or")
        import_cil_keyword("pop")
        import_cil_keyword("readonly.")
        import_cil_keyword("refanytype")
        import_cil_keyword("refanyval")
        import_cil_keyword("rem")
        import_cil_keyword("ret")
        import_cil_keyword("rethrow")
        import_cil_keyword("shl")
        import_cil_keyword("shr")
        import_cil_keyword("sizeof")
        import_cil_keyword("starg")
        import_cil_keyword("stelem")
        import_cil_keyword("stfld")
        import_cil_keyword("stloc")
        import_cil_keyword("stobj")
        import_cil_keyword("stsfld")
        import_cil_keyword("sub")
        import_cil_keyword("switch")
        import_cil_keyword("tail.")
        import_cil_keyword("throw")
        import_cil_keyword("unaligned.")
        import_cil_keyword("unbox", True)
        import_cil_keyword("volatile")
        import_cil_keyword("xor")
        import_cil_keyword("import")
        import_cil_keyword("value")
        import_cil_keyword("type")
        import_cil_keyword("instance")
        import_cil_keyword("static")
        import_cil_keyword("family")
        import_cil_keyword("array")
        netcorerectifier.keychecklistcount = netcorerectifier.cilcheckassembly.Count - 1
    End Sub

    Private Shared Sub import_cil_keyword(keyword As String, Optional checkassembly As Boolean = False)
        Select Case keyword.Length
            Case 2
                cilkey2w.Add(keyword)
            Case 3
                cilkey3w.Add(keyword)
            Case 4
                cilkey4w.Add(keyword)
            Case 5
                cilkey5w.Add(keyword)
            Case 6
                cilkey6w.Add(keyword)
            Case 7
                cilkey7w.Add(keyword)
            Case Else
                cilkeypl.Add(keyword)
        End Select
        If checkassembly Then
            netcorerectifier.cilcheckassembly.Add(keyword)
        End If
        If keyword.Length > keywordmaxlen Then
            keywordmaxlen = keyword.Length
        End If
    End Sub

    Friend Shared Function get_key(keyword As String) As String
        If keyword = conrex.NULL Then Return conrex.NULL
        If keyword.Length > keywordmaxlen Then Return keyword
        Select Case keyword.Length
            Case 1
                Return keyword
            Case 2
                check_keyword_with_tokens(cilkey2w, keyword)
            Case 3
                check_keyword_with_tokens(cilkey3w, keyword)
            Case 4
                check_keyword_with_tokens(cilkey4w, keyword)
            Case 5
                check_keyword_with_tokens(cilkey5w, keyword)
            Case 6
                check_keyword_with_tokens(cilkey6w, keyword)
            Case 7
                check_keyword_with_tokens(cilkey7w, keyword)
            Case Else
                check_keyword_with_tokens(cilkeypl, keyword)
        End Select
        Return keyword
    End Function

    Private Shared Sub check_keyword_with_tokens(arr As ArrayList, ByRef keyword As String)
        Dim cycle As Int32 = arr.Count - 1
        For index = 0 To cycle
            If arr(index).ToString = keyword Then
                reset_keyword(keyword)
            End If
        Next
    End Sub

    Private Shared Sub reset_keyword(ByRef keyword As String)
        keyword = conrex.COSTR & keyword & conrex.COSTR
    End Sub
End Class
