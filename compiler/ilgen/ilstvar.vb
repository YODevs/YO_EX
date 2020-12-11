Public Class ilstvar
    Friend Shared Function st_identifier(nvar As String, ByRef _ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, datatype As String) As Boolean
        If IsNothing(_ilmethod.locallinit) = False OrElse nvar.StartsWith(compdt.FLAGPERFIX) Then
            If st_local(nvar, _ilmethod, cargcodestruc, datatype) Then Return True
        End If
        If IsNothing(_ilmethod.parameter) = False Then
            If st_argument(nvar, _ilmethod, cargcodestruc, datatype) Then Return True
        End If
        If IsNothing(ilasmgen.classdata.fields) = False Then
            If st_field(nvar, _ilmethod, cargcodestruc, datatype) Then Return True
        End If
        dserr.args.Add(nvar)
        dserr.new_error(conserr.errortype.TYPENOTFOUND, cargcodestruc.line, ilbodybulider.path, "Method : " & _ilmethod.name & " - Unknown identifier : " & nvar & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))

        Return False
    End Function

    Friend Shared Function st_local(nvar As String, ByRef _ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, datatype As String) As Boolean
        Dim nvartolower As String = nvar.ToLower
        Dim pnvar As String = String.Empty
        If nvar.StartsWith(compdt.FLAGPERFIX) Then
            cil.set_stack_local(_ilmethod.codes, nvar)
            Return True
        End If
        For index = 0 To _ilmethod.locallinit.Length - 1
            pnvar = _ilmethod.locallinit(index).name
            If pnvar <> conrex.NULL AndAlso pnvar.ToLower = nvartolower Then
                If _ilmethod.locallinit(index).datatype = datatype Then
                    cil.set_stack_local(_ilmethod.codes, nvar)
                    Return True
                Else
                    dserr.args.Add(_ilmethod.locallinit(index).datatype)
                    dserr.args.Add(datatype)
                    dserr.new_error(conserr.errortype.EXPLICITCONVERSION, cargcodestruc.line, ilbodybulider.path, "Method : " & _ilmethod.name & " - identifier : " & nvar & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
                    Return False
                End If
            End If
        Next
        Return False
    End Function
    Friend Shared Function st_argument(nvar As String, ByRef _ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, datatype As String) As Boolean
        Dim nvartolower As String = nvar.ToLower
        Dim pnvar As String = String.Empty
        For index = 0 To _ilmethod.parameter.Length - 1
            pnvar = _ilmethod.parameter(index).name
            If pnvar <> conrex.NULL AndAlso pnvar.ToLower = nvartolower Then
                Dim getcildatatype As String = String.Empty
                If servinterface.is_common_data_type(_ilmethod.parameter(index).datatype, getcildatatype) = False Then
                    getcildatatype = _ilmethod.parameter(index).datatype
                End If

                If datatype = getcildatatype Then
                    If _ilmethod.parameter(index).ispointer Then
                        cil.set_stack_pointer(_ilmethod.codes, datatype)
                        Return True
                    Else
                        cil.set_stack_argument(_ilmethod.codes, nvar)
                        Return True
                    End If
                Else
                    dserr.args.Add(_ilmethod.locallinit(index).datatype)
                    dserr.args.Add(datatype)
                    dserr.new_error(conserr.errortype.EXPLICITCONVERSION, cargcodestruc.line, ilbodybulider.path, "Method : " & _ilmethod.name & " - identifier : " & nvar & vbCrLf & authfunc.get_line_error(ilbodybulider.path, servinterface.get_target_info(cargcodestruc), cargcodestruc.value))
                    Return False
                End If
            End If
        Next
        Return False
    End Function

    Friend Shared Function st_field(nvar As String, ByRef _ilmethod As ilformat._ilmethodcollection, cargcodestruc As xmlunpkd.linecodestruc, datatype As String, Optional ByRef nactorcode As ArrayList = Nothing) As Boolean
        If IsNothing(ilasmgen.classdata.fields) Then Return False
        Dim nvartolower As String = nvar.ToLower
        Dim pnvar As String = String.Empty
        Dim pdatatype As String = String.Empty
        For index = 0 To ilasmgen.classdata.fields.Length - 1
            pnvar = ilasmgen.classdata.fields(index).name
            If pnvar <> conrex.NULL AndAlso pnvar.ToLower = nvartolower Then
                pdatatype = ilasmgen.classdata.fields(index).ptype
                servinterface.is_common_data_type(pdatatype, pdatatype)
                If pdatatype = datatype Then
                    Dim classname As String = ilasmgen.classdata.attribute._app._classname
                    If ilasmgen.classdata.attribute._app._namespace <> conrex.NULL Then
                        classname = ilasmgen.classdata.attribute._app._namespace & conrex.DOT & classname
                    End If
                    If IsNothing(nactorcode) = False Then
                        If ilasmgen.classdata.fields(index).modifier = "static" Then
                            cil.set_static_field(nactorcode, pnvar, pdatatype, classname)
                        Else
                            cil.set_field(nactorcode, pnvar, pdatatype, classname)
                        End If
                    Else
                        If ilasmgen.classdata.fields(index).modifier = "static" Then
                            cil.set_static_field(_ilmethod.codes, pnvar, pdatatype, classname)
                        Else
                            cil.set_field(_ilmethod.codes, pnvar, pdatatype, classname)
                        End If
                    End If
                    Return True
                Else
                    dserr.args.Add(ilasmgen.classdata.fields(index).ptype)
                    dserr.args.Add(datatype)
                    dserr.new_error(conserr.errortype.EXPLICITCONVERSION, cargcodestruc.line, ilbodybulider.path, "Method : " & _ilmethod.name & " - identifier [ Field ] : " & nvar & vbCrLf)
                    Return False
                End If
            End If
        Next
        Return False
    End Function
End Class
