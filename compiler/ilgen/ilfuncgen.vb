Public Class ilfuncgen

    Public setinitialization As Boolean = False
    Private grabentrypoint As Boolean = False
    Private ilcollection As ilformat.ildata
    Private yoclassdt As tknformat._class
    Private _ilmethods(0) As ilformat._ilmethodcollection

    Public Sub New(ilcol As ilformat.ildata, yoclass As tknformat._class)
        ilcollection = ilcol
        yoclassdt = yoclass
        _ilmethods(0) = New ilformat._ilmethodcollection
    End Sub

    Public Function gen() As ilformat._ilmethodcollection()
        For index = 0 To yoclassdt.methods.Length - 1
            check_func_name(yoclassdt.methods, index)
            Dim _ilmethodslen As Integer = _ilmethods.Length
            Dim imethod As Int16 = _ilmethodslen - 1
            If _ilmethodslen <> 0 Then
                Array.Resize(_ilmethods, _ilmethodslen + 1)
            End If
            lngen.init_lines()
            func_ilforamtter(yoclassdt.methods(index), imethod)
        Next
        Array.Resize(_ilmethods, _ilmethods.Length - 1)
        Return _ilmethods
    End Function


    Public Sub func_ilforamtter(yomethod As tknformat._method, ilmethodsindex As Integer)
        'Check name rules ...
        'Check uniq names
        _ilmethods(ilmethodsindex).name = yomethod.name
        If yomethod.name = "init" Then
            setinitialization = True
        End If
        If yomethod.name.ToLower = "main" AndAlso check_entry_point_by_file(yoclassdt.location) AndAlso cprojdt.get_val("outputtype").ToLower <> "library" Then
            If grabentrypoint = False Then
                _ilmethods(ilmethodsindex).entrypoint = True
                grabentrypoint = True
            End If
        End If

        _ilmethods(ilmethodsindex).accessible = ilformat._accessiblemethod.PUBLIC
        _ilmethods(ilmethodsindex).returntype = yomethod.returntype
        _ilmethods(ilmethodsindex).isexpr = yomethod.isexpr


        set_parameter(yomethod, ilmethodsindex)
        Dim iltrans As New iltranscore(yomethod)
        iltrans.gen_transpile_code(_ilmethods(ilmethodsindex))
    End Sub

    Private Sub set_parameter(yomethod As tknformat._method, ilmethodsindex As Integer)
        If IsNothing(yomethod.parameters) Then Return
        For index = 0 To yomethod.parameters.Length - 1
            Array.Resize(_ilmethods(ilmethodsindex).parameter, index + 1)
            _ilmethods(ilmethodsindex).parameter(index).name = yomethod.parameters(index).name
            _ilmethods(ilmethodsindex).parameter(index).datatype = yomethod.parameters(index).ptype
            _ilmethods(ilmethodsindex).parameter(index).ispointer = yomethod.parameters(index).byreference
        Next
    End Sub
    Private Function check_entry_point_by_file(location As String) As Boolean
        location = location.Remove(0, location.LastIndexOf("\") + 1)
        If location.ToLower = "main.yo" Then
            Return True
        End If
        Return False
    End Function

    Private Sub check_func_name(methods As tknformat._method(), index As Integer)
        Dim seterr As Boolean = False
        Dim crmethod As tknformat._method = methods(index)
        For ime = 0 To methods.Length - 1
            If ime <> index AndAlso crmethod.name = methods(ime).name Then
                If IsNothing(crmethod.parameters) = False AndAlso IsNothing(methods(ime).parameters) = False Then
                    If crmethod.parameters.Length = methods(ime).parameters.Length Then
                        If check_rep_params(crmethod, methods(ime)) = False Then
                            seterr = True
                            Exit For
                        End If
                    End If
                ElseIf IsNothing(crmethod.parameters) AndAlso IsNothing(methods(ime).parameters) Then
                    seterr = True
                    Exit For
                End If
            End If
        Next

        If seterr Then
            dserr.args.Add(crmethod.name)
            dserr.new_error(conserr.errortype.OVERLOADERROR, -1, ilbodybulider.path, "Define different signatures for the function.")
        End If
    End Sub
    Private Function check_rep_params(fmethod As tknformat._method, nmethod As tknformat._method) As Boolean
        For index = 0 To fmethod.parameters.Length - 1
            If fmethod.parameters(index).ptype <> nmethod.parameters(index).ptype Then
                Return True
            End If
        Next
        Return False
    End Function

End Class
