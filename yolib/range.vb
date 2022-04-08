Public Class range


    Public Shared Function get_range(startpoint As Integer, endpoint As Integer) As list
        Return get_range(startpoint, endpoint, 1, True)
    End Function

    Public Shared Function get_range(startpoint As Integer, endpoint As Integer, [step] As Integer) As list
        Return get_range(startpoint, endpoint, [step], True)
    End Function

    Public Shared Function get_range(startpoint As Integer, endpoint As Integer, [step] As Integer, ignorelastpoint As Boolean) As list
        If startpoint < endpoint Then
            If [step] <= 0 Then Throw New Exception("The value of the step parameter is not allowed for this range; Intervals greater than 0 should be used.")
            If ignorelastpoint Then
                endpoint -= 1
            End If
        ElseIf startpoint > endpoint Then
            If [step] >= 0 Then Throw New Exception("The value of the step parameter is not allowed for this range; A range of less than 0 should be used.")
            If ignorelastpoint Then
                endpoint += 1
            End If
        End If
        Dim items As New YOLIB.list
        For index = startpoint To endpoint Step [step]
            items.add(index)
        Next
        Return items
    End Function
End Class
