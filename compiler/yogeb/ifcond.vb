Imports YOCA

Public Class ifcond
    Private Shared conddata() As conddatacollection
    Friend Shared incond As Boolean = False
    Friend Shared leavebrachlabel As New ArrayList
    Private _ilmethod As ilformat._ilmethodcollection
    Private enblbranch As String
    Public Sub New(ilmethod As ilformat._ilmethodcollection)
        Me._ilmethod = ilmethod
        enblbranch = lngen.get_line_prop("enifcond")
    End Sub

    Private Structure conddatacollection
        Dim statement As tokenhared.token
        Dim clinecodestruc() As xmlunpkd.linecodestruc
        Dim brself As String
    End Structure
    Friend Shared Sub imp_cond_statement(clinecodestruc() As xmlunpkd.linecodestruc)
        Dim index As Integer = 0
        If IsNothing(conddata) Then
            Array.Resize(conddata, 1)
        Else
            index = conddata.Length
            Array.Resize(conddata, index + 1)
        End If
        conddata(index).clinecodestruc = clinecodestruc
        conddata(index).statement = clinecodestruc(0).tokenid
        conddata(index).brself = lngen.get_line_prop("ifcond")
        incond = True
    End Sub
    Friend Shared Function check_cond_statement(clinecodestruc As xmlunpkd.linecodestruc) As Boolean
        Select Case clinecodestruc.tokenid
            Case tokenhared.token.IF
            Case tokenhared.token.ELSEIF
            Case tokenhared.token.ELSE
            Case Else
                Return False
        End Select
        Return True
    End Function

    Public Function set_condition_statement(ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        Dim prconddatacollection() As conddatacollection = conddata
        conddata = Nothing
        incond = False
        For index = 0 To prconddatacollection.Length - 1
            stjmper.set_new_jmper(tokenhared.token.IF, enblbranch, prconddatacollection(index).brself, Nothing)
            Select Case prconddatacollection(index).statement
                Case tokenhared.token.IF
                    set_if_statement(prconddatacollection(index).clinecodestruc, _illocalinit, localinit)
                Case tokenhared.token.ELSEIF
                    set_elseif_statement(prconddatacollection(index).clinecodestruc, _illocalinit, localinit)
                Case tokenhared.token.ELSE
                    set_else_statement(prconddatacollection(index).clinecodestruc, _illocalinit, localinit)
            End Select
            stjmper.reset_jmper(tokenhared.token.IF)
        Next

        lngen.set_direct_label(enblbranch, _ilmethod.codes)
        Return _ilmethod
    End Function
    Public Function set_if_statement(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        Dim condlinecodestruc() As xmlunpkd.linecodestruc = condproc.get_condition(clinecodestruc, 1)
        Dim ifenblock As xmlunpkd.linecodestruc = condproc.get_block_body(clinecodestruc)
        Dim nbranch As New condproc.branchtargetinfo
        nbranch.truebranch = lngen.get_line_prop("st_if")
        nbranch.falsebranch = lngen.get_line_prop("en_if")
        Dim cdproc As New condproc(nbranch)
        cdproc.set_condition(_ilmethod, condlinecodestruc, False)
        set_if_body(ifenblock, nbranch, _illocalinit, localinit)
        Return _ilmethod
    End Function

    Public Function set_elseif_statement(clinecodestruc() As xmlunpkd.linecodestruc, ByRef _illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata) As ilformat._ilmethodcollection
        Dim condlinecodestruc() As xmlunpkd.linecodestruc = condproc.get_condition(clinecodestruc, 1)
        Dim ifenblock As xmlunpkd.linecodestruc = condproc.get_block_body(clinecodestruc)
        Dim nbranch As New condproc.branchtargetinfo
        nbranch.truebranch = lngen.get_line_prop("st_if")
        nbranch.falsebranch = lngen.get_line_prop("en_if")
        Dim cdproc As New condproc(nbranch)
        cdproc.set_condition(_ilmethod, condlinecodestruc, False)
        set_if_body(ifenblock, nbranch, _illocalinit, localinit)
        Return _ilmethod
    End Function

    Private Sub set_if_body(ifenblock As xmlunpkd.linecodestruc, nbranch As condproc.branchtargetinfo, ByRef illocalinit() As ilformat._illocalinit, ByRef localinit As localinitdata)
        '  stjmper.set_new_jmper(tokenhared.token.if, nbranch.falsebranch, Nothing )
        lngen.set_direct_label(nbranch.truebranch, _ilmethod.codes)
        Dim iltrans As New iltranscore(ilbodybulider.path, ifenblock.value, illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        illocalinit = _ilmethod.locallinit
        cil.branch_to_target(_ilmethod.codes, enblbranch)
        '   stjmper.reset_jmper(tokenhared.token.IF )
        lngen.set_direct_label(nbranch.falsebranch, _ilmethod.codes)
    End Sub

    Public Function set_else_statement(clinecodestruc() As xmlunpkd.linecodestruc, ByRef illocalinit() As ilformat._illocalinit, localinit As localinitdata) As ilformat._ilmethodcollection
        syntaxchecker.check_statement(clinecodestruc, syntaxloader.statements.ELSE)
        Dim iltrans As New iltranscore(ilbodybulider.path, clinecodestruc(1).value, illocalinit, localinit)
        iltrans.gen_transpile_code(_ilmethod, False)
        illocalinit = _ilmethod.locallinit
        Return _ilmethod
    End Function

End Class
