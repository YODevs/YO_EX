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
            If ignorelastpoint = True Then
                endpoint -= 1
            End If
        ElseIf startpoint > endpoint Then
            If [step] >= 0 Then Throw New Exception("The value of the step parameter is not allowed for this range; A range of less than 0 should be used.")
            If ignorelastpoint = True Then
                endpoint += 1
            End If
        End If
        Dim items As New YOLIB.list
        For index = startpoint To endpoint Step [step]
            items.add(index)
        Next
        Return items
    End Function

    Public Shared Function get_range(startpoint As Double, endpoint As Double) As list
        Return get_range(startpoint, endpoint, 1.0, True)
    End Function

    Public Shared Function get_range(startpoint As Double, endpoint As Double, [step] As Double) As list
        Return get_range(startpoint, endpoint, [step], True)
    End Function

    Public Shared Function get_range(startpoint As Double, endpoint As Double, [step] As Double, ignorelastpoint As Boolean) As list
        Dim items As New YOLIB.list
        Dim critem As Double = startpoint
        If endpoint > startpoint Then
            If [step] <= 0 Then Throw New Exception("The value of the step parameter is not allowed for this range; Intervals greater than than 0 should be used.")
            While critem <= endpoint
                items.add(critem)
                critem += [step]
            End While
        ElseIf endpoint < startpoint Then
            If [step] >= 0 Then Throw New Exception("The value of the step parameter is not allowed for this range; A range of less than 0 should be used.")
            While critem >= endpoint
                items.add(critem)
                critem += [step]
            End While
        End If
        If startpoint = endpoint Then
            items.add(startpoint)
        Else
            If ignorelastpoint = True AndAlso items.count > 1 Then
                items.remove_at(items.count - 1)
            End If
        End If
        Return items
    End Function
End Class
