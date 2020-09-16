Public Class initblockop
    Friend Shared blockopallowlist As New mapstoredata
    Friend Shared Sub init_blockop_allow_list()
        For index = 0 To compdt.blockopallow.Length - 1
            blockopallowlist.add([Enum].GetName(GetType(tokenhared.token), compdt.blockopallow(index)), compdt.blockopallow(index))
        Next
    End Sub

    Friend Shared Function check_blockop_allow(tokenid As Integer) As Boolean
        Return blockopallowlist.findkey(tokenid).issuccessful
    End Function
End Class
