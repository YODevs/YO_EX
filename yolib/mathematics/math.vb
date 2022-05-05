Public Class math

#Region "constants"
    Public Shared ReadOnly Property PI() As Double
        Get
            Return 3.14159265358979
        End Get
    End Property
    Public Shared ReadOnly Property TUA() As Double
        Get
            Return 6.28318530717958
        End Get
    End Property
    Public Shared ReadOnly Property E() As Double
        Get
            Return 2.71828182845904
        End Get
    End Property
#End Region


#Region "factorial"
    Public Shared Function factorial(ByVal number As Integer) As Long
        If number < 0 Then
            Throw New Exception(String.Format("The number ({0}) must be greater than or equal to zero.", number))
        End If
        Dim result As Long = 1
        For i = 1 To number
            result *= i
        Next
        Return result
    End Function
    Public Shared Function factorial_i32(ByVal number As Integer) As Integer
        If number < 0 Then
            Throw New Exception(String.Format("The number ({0}) must be greater than or equal to zero.", number))
        End If
        Dim result As Long = 1
        For i = 1 To number
            result *= i
        Next
        Return result
    End Function
#End Region

#Region "abs"
    Public Shared Function abs(ByVal value As Decimal) As Decimal
        If (value >= 0) Then
            Return value
        End If
        Dim tostr As String = value.ToString
        tostr = tostr.Remove(0, 1)
        Return CDec(tostr)
    End Function

    Public Shared Function abs(ByVal value As Integer) As Integer
        If (value >= 0) Then
            Return value
        End If
        Dim tostr As String = value.ToString
        tostr = tostr.Remove(0, 1)
        Return CDec(tostr)
    End Function

    Public Shared Function abs(ByVal value As Single) As Single
        If (value >= 0) Then
            Return value
        End If
        Dim tostr As String = value.ToString
        tostr = tostr.Remove(0, 1)
        Return CDec(tostr)
    End Function

    Public Shared Function abs(ByVal value As Double) As Double
        If (value >= 0) Then
            Return value
        End If
        Dim tostr As String = value.ToString
        tostr = tostr.Remove(0, 1)
        Return CDec(tostr)
    End Function
#End Region

#Region "logarithm"
    Public Shared Function log(ByVal number As Integer) As Integer
        Return CInt(System.Math.Log(CDbl(number), 10.0))
    End Function
    Public Shared Function log(ByVal number As Integer, ByVal base As Integer) As Integer
        Return CInt(System.Math.Log(CDbl(number), base))
    End Function
    Public Shared Function log(ByVal number As Single) As Single
        Return CSng(System.Math.Log(CDbl(number), 10.0))
    End Function
    Public Shared Function log(ByVal number As Single, ByVal base As Single) As Single
        Return CSng(System.Math.Log(CDbl(number), base))
    End Function
    Public Shared Function log(ByVal number As Double) As Double
        Return System.Math.Log(number, 10.0)
    End Function
    Public Shared Function log(ByVal number As Double, ByVal base As Double) As Double
        Return System.Math.Log(number, base)
    End Function
#End Region

End Class
