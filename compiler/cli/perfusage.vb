Public Class perfusage
    Dim runtimeprocess As Process
    Public chtimer As New System.Timers.Timer
    Public cram As ArrayList
    Public Sub New(runtimeprocess As Process)
        Me.runtimeprocess = runtimeprocess
        chtimer.AutoReset = True
        chtimer.Interval = 500
        AddHandler chtimer.Elapsed, AddressOf check_process
        cram = New ArrayList
    End Sub

    Public Sub start()
        check_process(Nothing, Nothing)
        chtimer.Start()
    End Sub
    Private Sub check_process(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        Try
            If runtimeprocess.HasExited = True Then
                chtimer.Stop()
                Return
            End If
            Dim memoryspace As Long = New PerformanceCounter("Process", "Working Set - Private", runtimeprocess.ProcessName).RawValue
            cram.Add((memoryspace * 0.9765625 * 0.000001).ToString)
            Exit Sub
        Catch ex As Exception
            dserr.new_error(conserr.errortype.RUNTIMEERROR, -1, conrex.NULL, ex.Message, "This process is closed too soon; The compiler is unable to receive information.")
        End Try
    End Sub
    Public Sub get_response()
        If cram.Count = 0 Then Return
        Dim cramresult As Double = 0.0
        For index = 0 To cram.Count - 1
            cramresult += Double.Parse(cram(index))
        Next
        Dim totalmemory As Int32 = (My.Computer.Info.TotalPhysicalMemory * 0.000001)
        Dim avgram As Double = Math.Round(Double.Parse(cramresult / cram.Count), 3)
        Dim percentageram As Single = ((avgram / totalmemory) * 100)
        If percentageram < 0.0001 Then
            percentageram = 0.0
        Else
            percentageram = Math.Round(percentageram, 2)
        End If
        Console.WriteLine(String.Format("Current workingset     : {0} MB [{1}%]", avgram, percentageram))
        Dim tsp As TimeSpan = runtimeprocess.ExitTime.Subtract(runtimeprocess.StartTime)
        Console.WriteLine("Time measured          : {0} ", tsp.ToString)
    End Sub
End Class
