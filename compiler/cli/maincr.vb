''' <summary>
''' <en>
''' Compiler's process starts from the Main() function exists in this class
''' </en>
''' <fa>
''' شروع فرایند کامپایلر از تابع Main() در این کلاس است .
''' </fa>
''' </summary>
Module maincr
    Const BYPASSFLOW As Boolean = False
    Sub main(ByVal argsval() As String)
        Try
            init_class_data()
            If BYPASSFLOW Then
                cli.init_cli(False)
                cflowtester.lex_dir(conrex.APPDIR & "\myapp\")
                Console.ReadLine()
                Return
            End If

            If argsval.Length = 0 Then
                cli.init_cli(True)
                cli.goto_cmdln(argsval)
                Console.ReadLine()
                Return
            Else
                cli.init_cli(False)
                parseargs.parse_data(argsval)
            End If
        Catch ex As Exception
            If compdt.DISPLAYSTACKTRACE Then
                dserr.new_error(conserr.errortype.RUNTIMEERROR, -1, Nothing, ex.Message & vbCrLf & ex.StackTrace)
            Else
                dserr.new_error(conserr.errortype.RUNTIMEERROR, -1, Nothing, ex.Message)
            End If
        End Try
    End Sub

    ''' <summary>
    ''' <en>
    ''' Preparing and running prerequisites of starting compile process
    ''' </en>
    ''' <fa>
    ''' عملیات آماده سازی و اجرای پیشنیاز های شروع فرایند کامپایل
    ''' </fa>
    ''' </summary>
    Sub init_class_data()
        cmdlnproc.init_command_struct()
        conserr.init_error_struct()
        tokenhared.init()
        init_essential_files()
        cacheste.init_cache_system()
        initcommondatatype.init_common_data_type()
        initcommondatatype.init_ptr_bind()
        specificdustrcommand.init()
        ciltoken.init_cil_instruction()
        initblockop.init_blockop_allow_list()
        syntaxloader.init_syntax_loader()
        incfile.init()
        cilkeywordchecker.init_keyword()
    End Sub

    ''' <summary>
    ''' <en>
    ''' Initializing essential files which are next to the compiler and affect compiler's activity.
    ''' </en>
    ''' <fa>
    ''' بررسی فایل های ضروری کنار کامپایلر ، که فعالیت آن را تحت تاثیر قرار میدهد.
    ''' </fa>
    ''' </summary>
    Sub init_essential_files()
        initessentialfiles.add_path(conrex.APPDIR & "\iniopt\intro.yoda")
        initessentialfiles.add_path(conrex.APPDIR & "\iniopt\win32exceptions.yoda")
        initessentialfiles.add_path(conrex.APPDIR & "\iniopt\param.yoda")
        initessentialfiles.add_path(conrex.APPDIR & "\iniopt\dotnetconfig\global.json")
        initessentialfiles.add_path(conrex.APPDIR & "\iniopt\dotnetconfig\main.ilproj")
        initessentialfiles.add_path(conrex.APPDIR & "\iniopt\sym\symbols.yoda")
        initessentialfiles.add_path(compdt.BRIDGECORE)
        initessentialfiles.add_path(compdt.BRIDGECORELIB)
    End Sub
End Module
