''' <summary>
''' <en>
''' Preparing commands of command line
''' </en>
''' <fa>
''' آماده سازی دستورات خط فرمان
''' </fa>
''' </summary>
Public Class cmdlnproc
    Enum cmdtype
        TEST
        [EXIT]
        VERSION
        BUILD
        RUN
        IMPORT
        CLEAN
        HELP
        CHECK
        INIT
        CACLEANER
        DEV
        YOAT
    End Enum
    Structure cmdstruct
        Dim commandtype As cmdtype
        Dim command As String
        Dim withargs As Boolean
        Dim maxargs As Int16
    End Structure

    Public Shared cmd() As cmdstruct

    ''' <summary>
    ''' <en>
    ''' Submitting commands and attributes of each command in the command line/
    ''' </en>
    ''' <fa>
    ''' ثبت دستورات و ویژگی های هر دستور در خط فرمان
    ''' </fa>
    ''' </summary>
    Public Shared Sub set_new_command(commandtype As cmdtype, command As String, Optional withargs As Boolean = False, Optional maxargs As Int16 = 0)
        Static Dim indexarray As Int16 = 0
        Array.Resize(cmd, indexarray + 1)
        cmd(indexarray) = New cmdstruct
        cmd(indexarray).commandtype = commandtype
        cmd(indexarray).command = command.ToLower
        cmd(indexarray).withargs = withargs
        cmd(indexarray).maxargs = maxargs
        indexarray += 1
        Return
    End Sub

    Public Shared Function check_master_key(command As String) As Int16
        command = command.ToLower
        For index = 0 To cmd.Length - 1
            If cmd(index).command = command Then
                Return index
            End If
        Next
        Return -1
    End Function

    ''' <summary>
    ''' <en>
    ''' This function has to prepare and add commands of command line.
    ''' </en>
    ''' <fa>
    ''' این تابع وظیفه آماده سازی و افزودن دستورات خط فرمان را دارد
    ''' </fa>
    ''' </summary>
    Public Shared Sub init_command_struct()
        set_new_command(cmdtype.BUILD, "build", True, 9)
        set_new_command(cmdtype.RUN, "run", True, 10)
        set_new_command(cmdtype.CHECK, "check", True, 7)
        set_new_command(cmdtype.INIT, "init")
        set_new_command(cmdtype.IMPORT, "import")
        set_new_command(cmdtype.CLEAN, "clean")
        set_new_command(cmdtype.CACLEANER, "cacleaner")
        set_new_command(cmdtype.DEV, "dev")
        set_new_command(cmdtype.VERSION, "version")
        set_new_command(cmdtype.TEST, "test")
        set_new_command(cmdtype.YOAT, "yoat")
        set_new_command(cmdtype.EXIT, "exit")
        set_new_command(cmdtype.HELP, "help")
    End Sub
End Class
