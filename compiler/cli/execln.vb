Imports System.IO
Imports System.Text.RegularExpressions
''' <summary>
''' <en>
''' This class has to run compiler's commands in the command line
''' </en>
''' <fa>
'''این کلاس وظیفه اجرای دستورات خط فرمان کامپایلر را داردو
''' </fa>
''' </summary>
Public Class execln
    Friend Shared argstorelist As liststoredata
    Friend Shared Sub nv_check_command(result As parseargs._parseresult)
        If result.command = Nothing Or result.command = conrex.SPACE Then
            Return
        End If
        Dim getindex As Int16 = cmdlnproc.check_master_key(result.command)
        If getindex = -1 Then
            'Set Error , command not found .
            dserr.new_error(conserr.errortype.PARAMCLIERROR, -1, Nothing, "'" & result.command & "' - Command not found." & vbLf & "This command may be used in updated versions of YO Compiler API(YOCA).")
            Return
        End If

        If cmdlnproc.cmd(getindex).withargs = False AndAlso result.args.Count > 0 Then
            dserr.new_error(conserr.errortype.PARAMCLIERROR, -1, Nothing, "'" & result.command & "' - This command does not support any parameters, enter this command without entering a parameter.")
            Return
        ElseIf cmdlnproc.cmd(getindex).maxargs < result.args.Count Then
            dserr.new_error(conserr.errortype.PARAMCLIERROR, -1, Nothing, "'" & result.command & "' - The number of parameters of this command is too much.")
            Return
        End If

        argstorelist = New liststoredata
        Dim cmdexeclninstance As New execln
        If cmdlnproc.cmd(getindex).withargs = False Then
            CallByName(cmdexeclninstance, "rp_" & result.command, CallType.Method, Nothing)
        Else
            check_parameters(result)
            CallByName(cmdexeclninstance, "rp_" & result.command, CallType.Method, result.args)
        End If
    End Sub
    Public Sub New()
    End Sub
    ''' <summary>
    ''' <en>
    '''
    ''' </en>
    ''' <fa>
    ''' بررسی اعتبار آرگومان های ارسال شده برای دستورات خط فرمان
    ''' </fa>
    ''' </summary>
    Friend Shared Sub check_parameters(result As parseargs._parseresult)
        Dim yodaf As New YODA.YODA_Format()
        Dim yodamap As YODA.YODA_Format.YODAMapFormat = yodaf.ReadYODA_Map(FileIO.FileSystem.ReadAllText(conrex.APPDIR & "\iniopt\param.yoda"))
        Dim cmapstore As New mapstoredata()
        cmapstore.import_collection(yodamap.keys, yodamap.values)
        Dim cresult As mapstoredata.dataresult = cmapstore.find(result.command, True)
        If cresult.issuccessful Then
            Dim params() As String
            params = Regex.Split(cresult.result, conrex.CMA)
            For argindex = 0 To result.args.Count - 1
                Dim vaildparam As Boolean = False
                Dim inputparam As String = result.args(argindex)
                inputparam = inputparam.Remove(0, 2).ToLower
                For index = 0 To params.Length - 1
                    If inputparam = params(index) Then
                        vaildparam = True
                        Exit For
                    End If
                Next
                If vaildparam Then
                    Continue For
                Else
                    dserr.new_error(conserr.errortype.UNDEFINEDPARAM, -1, Nothing,
                                    String.Format("The '{0}' parameter is not defined for the '{1}' command.", result.args(argindex), result.command), "Supported parameters for this command include: " & cresult.result)
                End If
            Next
        End If
    End Sub
    Public Sub rp_test()
        Dim peconsolecolor As Int16 = Console.ForegroundColor
        Console.ForegroundColor = System.ConsoleColor.DarkGreen
        Console.Write("Bravo !!!!! YO Compiler API (YOCA) is ready to execute your commands.
You can type 'Help' to view commands.")
        Console.ForegroundColor = peconsolecolor
    End Sub

    Public Sub rp_exit()
        Environment.Exit(1)
    End Sub

    Public Sub rp_version()
        Console.Write(conrex.VER)
    End Sub
    Public Sub rp_import()
        Dim projflow As New cprojflow()
        projflow.load_cproj_data()
        cilcomp.get_il_loca()
        impassets.copy_assets()
    End Sub
    Public Sub rp_clean()
        Dim projflow As New cprojflow()
        projflow.load_cproj_data()
        cilcomp.get_il_loca()
        cprojclean.clean_project()
    End Sub

    Public Sub rp_help()
        introcmd.show_intro()
    End Sub
    Public Sub rp_init()
        initact.set_initial_process()
    End Sub
    Public Sub rp_cacleaner()
        Console.Write(vbCrLf & "Are you sure you want to delete all compiler caches?[y/N]")
        If Console.ReadKey.KeyChar.ToString.ToLower = "y" Then
            If cacheste.cache_cleaner() = True Then
                Dim peconsolecolor As Int16 = Console.ForegroundColor
                Console.ForegroundColor = System.ConsoleColor.DarkGreen
                Console.WriteLine(vbCrLf & "The caches were cleared successfully.")
                Console.ForegroundColor = peconsolecolor
            Else
                Console.WriteLine(vbCrLf & "The cache cleaning operation was stopped.(No cache found)")
            End If
        Else
            Console.WriteLine(vbCrLf & "The cache cleaning operation was stopped.")
        End If
    End Sub
    Public Sub rp_check(args As ArrayList)
        compdt.CHECKSYNANDSEM = True
        rp_build(args, True)
    End Sub
    Public Sub rp_build(args As ArrayList, Optional ismuteprocess As Boolean = False)
        argstorelist.import_collection(args)
        If ismuteprocess = True Then
            compdt.MUTEPROCESS = True
        Else
            compdt.MUTEPROCESS = argstorelist.find(compdt.PARAM_MUTE_PROCESS, True)
        End If
        procresult.set_state("init")
        compdt.DEVMOD = argstorelist.find(compdt.PARAM_DEV, True)
        compdt.NOCACHE = argstorelist.find(compdt.PARAM_NOCACHE, True)
        compdt.DISPLAYTOKENWLEX = argstorelist.find(compdt.PARAM_DISPLAYTOKENLEX, True)
        compdt.DISPLAYSTACKTRACE = argstorelist.find(compdt.PARAM_DISPLAYSTACKTRACE, True)
        compdt.DISABLEWARNINGS = argstorelist.find(compdt.PARAM_DISABLE_WARNINGS, True)
        compdt.COMPILETIME = argstorelist.find(compdt.PARAM_DISPLAY_COMPILE_TIME, True)
        If compdt.COMPILETIME Then compile_time(True)
        Dim projflow As New cprojflow()
        projflow.start_project_flow()
        If compdt.COMPILETIME Then compile_time(False)
        If argstorelist.find(compdt.PARAM_IMPASSETS, True) Then impassets.copy_assets()
        impassets.import_std()
    End Sub
    Public Sub rp_run(args As ArrayList)
        rp_build(args)
        If ilasmconv.result Then
            compdt.EXECTIME = argstorelist.find(compdt.PARAM_DISPLAY_EXEC_TIME, True)
            If compdt.EXECTIME = False AndAlso compdt.MUTEPROCESS = False Then Console.WriteLine("Launching and running compiled output [" & compdt.RUNCMDDELAY & "ms] ...")
            Threading.Thread.Sleep(compdt.RUNCMDDELAY)
            Dim appproc As New Process
            With appproc
                .StartInfo = New ProcessStartInfo(cilcomp.get_output_loca())
                .Start()
                .WaitForExit()
            End With
            If compdt.EXECTIME Then exec_time(appproc)
        End If
    End Sub
    Public Sub rp_dev()
        Console.Write(constcli.DEVQES)
        Select Case Console.ReadKey.KeyChar.ToString.ToLower
            Case "y"
                If File.Exists(conrex.APPDIR & "\iniopt\dev") = False Then
                    File.WriteAllText(conrex.APPDIR & "\iniopt\dev", conrex.NULL)
                End If
            Case "n"
                If File.Exists(conrex.APPDIR & "\iniopt\dev") Then
                    File.Delete(conrex.APPDIR & "\iniopt\dev")
                End If
            Case Else
                Console.WriteLine(vbCrLf & constcli.DEVCHARERROR)
                Return
        End Select
        Console.WriteLine(vbCrLf & constcli.DEVONCHANGED)
    End Sub
    Private Sub compile_time(firststage As Boolean)
        Static frcompiletime As Date = Date.Now
        If firststage = False Then
            Console.WriteLine("Compile time : {0} ", Date.Now.Subtract(frcompiletime).ToString)
        End If
    End Sub
    Private Sub exec_time(appproc As Process)
        Dim tsp As TimeSpan = appproc.ExitTime.Subtract(appproc.StartTime)
        Console.WriteLine("Time measured ( + process call delay ) : {0} ", tsp.ToString)
    End Sub
End Class
