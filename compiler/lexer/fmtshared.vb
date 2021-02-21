Public Class fmtshared
    Public tknfmt As tknformat
    Private sourceloc As String
    Dim bdyformatter As bodyformatter
    Dim state As statecursor
    Public xclass(0) As tknformat._class
    Public xmethods(0) As tknformat._method
    Public xfield(0) As tknformat._pubfield
    Public xenum(0) As tknformat._enum
    Dim funcstate As funcstatecursor
    Dim parastate As funcparastate
    Dim paraitemstate As funcparaitemstate
    Dim fieldtypest As fieldtypestate
    Dim fieldstate As pbfieldstate
    Dim incstate As includestate
    Dim enumstate As enumerationcursor
    Public externlist As ArrayList
    Public includelist As ArrayList
    Public Sub New(file As String)
        tknfmt = New tknformat
        sourceloc = file
        state = statecursor.OUT
        fieldstate = pbfieldstate.OUT
        funcstate = funcstatecursor.OUT
        enumstate = enumerationcursor.OUT
        parastate = funcparastate.WAITFORSTARTBRACKET
        xmethods(0) = New tknformat._method
        xclass(0) = New tknformat._class
        xfield(0) = New tknformat._pubfield
        xenum(0) = New tknformat._enum
        externlist = New ArrayList
        includelist = New ArrayList
    End Sub

    Enum enumerationcursor
        OUT
        ENUMNAME
        ENUMPROP
        ENUMCONST
        ENUMEQU
        ENUMVAL
        ENUMCMA
        ENUMNEXT
    End Enum
    Enum fieldtypestate
        [LET]
        [CONST]
    End Enum
    Enum statecursor
        INFUNC
        INIMPORTS
        FIELDS
        INCLUDES
        ENUMS
        OUT
    End Enum

    Enum includestate
        OUT
        INCLUDEINTRO
        INCLUDEFILE
        INCLUDESPLITTER
    End Enum
    Enum funcstatecursor
        OUT
        ACCESSRESTR
        FUNCINTRO
        FUNCNAME
        FUNCPARA
        FUNCRETURNTYPE
        FUNCEXPRASSIGNMENT
        FUNCEXPREQUEXPRESSION
        FUNCSTBLOCK
        FUNCBODY
        FUNCENBLOCK
    End Enum

    Enum funcparastate
        WAITFORSTARTBRACKET
        WAITFORNEWPARAMETER
    End Enum

    Enum funcparaitemstate
        WAITFORIDENTIFIER
        WAITFORASSIGNMENTOPERATOR
        WAITFORPARAMETERTYPE
        WAITFORSPLITTER
    End Enum

    Enum pbfieldstate
        OUT
        ACCESSCONTORL
        MODIFIER
        FIELDNAME
        FIELDDTTPOPT
        FIELDTYPE
        EQOPT
        FIELDVALUE
    End Enum
    Public Sub imp_token(value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf)
        Select Case state
            Case statecursor.OUT
                Select Case rd_token
                    Case tokenhared.token.FUNC
                        _rev_func(value, rd_token, linecinf)
                    Case tokenhared.token.EXPR
                        _rev_func(value, rd_token, linecinf, True)
                    Case tokenhared.token.EXTERN
                        state = statecursor.INIMPORTS
                    Case tokenhared.token.LET
                        state = statecursor.FIELDS
                        fieldstate = pbfieldstate.ACCESSCONTORL
                        fieldtypest = fieldtypestate.LET
                    Case tokenhared.token.ENUM
                        state = statecursor.ENUMS
                        enumstate = enumerationcursor.ENUMNAME
                    Case tokenhared.token.CONST
                        state = statecursor.FIELDS
                        fieldstate = pbfieldstate.ACCESSCONTORL
                        fieldtypest = fieldtypestate.CONST
                    Case tokenhared.token.INCLUDE
                        state = statecursor.INCLUDES
                        incstate = includestate.INCLUDEFILE
                    Case Else
                        dserr.new_error(conserr.errortype.SYNTAXERROR, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value))
                End Select
                Return
            Case statecursor.INFUNC
                _rev_func(value, rd_token, linecinf)
            Case statecursor.FIELDS
                _rev_field(value, rd_token, linecinf)
            Case statecursor.INIMPORTS
                _rev_extern(value, rd_token, linecinf)
            Case statecursor.INCLUDES
                _rev_include(value, rd_token, linecinf)
            Case statecursor.ENUMS
                _rev_enumeration(value, rd_token, linecinf)
            Case Else
                dserr.new_error(conserr.errortype.SYNTAXERROR, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value))
        End Select
    End Sub

    Private Sub _rev_include(value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf)
        Select Case incstate
            Case includestate.INCLUDEFILE
                incfile.set_new_include_source(includelist, value, rd_token, linecinf)
                incstate = includestate.OUT
                state = statecursor.OUT
        End Select
    End Sub
    Private Sub _rev_enumeration(value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf)
        Static Dim i As Integer = 0
        Static Dim consval As Integer = 0
        Select Case enumstate
            Case enumerationcursor.ENUMNAME
                consval = 0
                If i <> 0 Then
                    Array.Resize(xenum, i + 1)
                End If
                Select Case rd_token
                    Case tokenhared.token.IDENTIFIER
                        xenum(i).name = value
                        enumstate = enumerationcursor.ENUMPROP
                    Case Else
                        dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "enum state{red,green,yellow}")
                End Select
                Return
            Case enumerationcursor.ENUMPROP
                If rd_token = tokenhared.token.BLOCKOPEN Then
                    xenum(i).constkeys = New ArrayList
                    xenum(i).constvalues = New ArrayList
                    enumstate = enumerationcursor.ENUMCONST
                Else
                    dserr.new_error(conserr.errortype.BLOCKOPENEXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "")
                End If
                Return
            Case enumerationcursor.ENUMCONST
                If rd_token = tokenhared.token.IDENTIFIER Then
                    xenum(i).constkeys.Add(value)
                    enumstate = enumerationcursor.ENUMEQU
                Else
                    dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value))
                End If
            Case enumerationcursor.ENUMEQU
                Select Case rd_token
                    Case tokenhared.token.EQUALS
                        enumstate = enumerationcursor.ENUMVAL
                    Case tokenhared.token.CMA
                        xenum(i).constvalues.Add(consval)
                        consval += 1
                        enumstate = enumerationcursor.ENUMCONST
                    Case tokenhared.token.BLOCKEND
                        xenum(i).constvalues.Add(consval)
                        enumstate = enumerationcursor.OUT
                        state = statecursor.OUT
                    Case Else
                        dserr.args.Add(value)
                        dserr.new_error(conserr.errortype.OPERATORUNKNOWN, linecinf.line, sourceloc, "Use the ',' separator." & vbCrLf & authfunc.get_line_error(sourceloc, linecinf, value), )
                End Select
                Return
            Case enumerationcursor.ENUMVAL
                Select Case rd_token
                    Case tokenhared.token.TYPE_INT
                        consval = value
                        enumstate = enumerationcursor.ENUMEQU
                    Case Else
                        dserr.new_error(conserr.errortype.CONSTANTVALERROR, linecinf.line, sourceloc, value & " - The constant value must be numeric." & vbCrLf & authfunc.get_line_error(sourceloc, linecinf, value), )
                End Select
        End Select
    End Sub

    Private Sub _rev_field(value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf)
        Static Dim i As Integer = 0
        Select Case fieldstate
            Case pbfieldstate.ACCESSCONTORL
                If i <> 0 Then
                    Array.Resize(xfield, i + 1)
                End If
                Select Case rd_token
                    Case tokenhared.token.PUBLIC
                        xfield(i).accesscontrol = "public"
                    Case tokenhared.token.PRIVATE
                        xfield(i).accesscontrol = "private"
                    Case Else
                        dserr.args.Add(value)
                        dserr.new_error(conserr.errortype.BADACCESSCONTROL, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "public / private / ...")
                End Select
                fieldstate = pbfieldstate.MODIFIER
                If fieldtypest = fieldtypestate.CONST Then
                    xfield(i).isconstant = True
                Else
                    xfield(i).isconstant = False
                End If
                Return
            Case pbfieldstate.MODIFIER
                Select Case rd_token
                    Case tokenhared.token.STATIC
                        xfield(i).modifier = "static"
                    Case Else
                        fieldstate = pbfieldstate.FIELDNAME
                        _rev_field(value, rd_token, linecinf)
                End Select
                Return
            Case pbfieldstate.FIELDNAME
                If rd_token = tokenhared.token.IDENTIFIER Then
                    xfield(i).name = value
                    fieldstate = pbfieldstate.FIELDDTTPOPT
                Else
                    dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "let public static age : i32 = 51")
                End If
            Case pbfieldstate.FIELDDTTPOPT
                If rd_token = tokenhared.token.ASSINQ Then
                    fieldstate = pbfieldstate.FIELDTYPE
                Else
                    dserr.args.Add(value)
                    dserr.new_error(conserr.errortype.OPERATORUNKNOWN, linecinf.line, sourceloc, "Use the ':' operator." & vbCrLf & authfunc.get_line_error(sourceloc, linecinf, value), "let public static age : i32 = 51")
                End If
            Case pbfieldstate.FIELDTYPE
                xfield(i).ptype = value
                fieldstate = pbfieldstate.EQOPT
            Case pbfieldstate.EQOPT
                If rd_token = tokenhared.token.EQUALS Then
                    fieldstate = pbfieldstate.FIELDVALUE
                Else
                    xfield(i).value = String.Empty
                    xfield(i).valuecinf = Nothing
                    fieldstate = pbfieldstate.OUT
                    state = statecursor.OUT
                    i += 1
                    imp_token(value, rd_token, linecinf)
                End If
            Case pbfieldstate.FIELDVALUE
                xfield(i).value = value
                xfield(i).valuecinf = linecinf
                xfield(i).valuetoken = rd_token
                fieldstate = pbfieldstate.OUT
                state = statecursor.OUT
                i += 1
        End Select
        Return
    End Sub
    Private Sub _rev_extern(value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf)
        If rd_token = tokenhared.token.IDENTIFIER Then
            externlist.Add(value)
        Else
            dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "extern mylib")
        End If
        state = statecursor.OUT
    End Sub
    Private Sub _rev_func(value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf, Optional isexpr As Boolean = False)
        Static Dim i As Integer = 0
        Select Case funcstate
            Case funcstatecursor.OUT
                If rd_token = tokenhared.token.FUNC OrElse isexpr Then
                    If i <> 0 Then
                        Array.Resize(xmethods, i + 1)
                    End If
                    xmethods(i).isexpr = isexpr
                    funcstate = funcstatecursor.FUNCNAME
                    paraitemstate = funcparaitemstate.WAITFORIDENTIFIER
                    state = statecursor.INFUNC
                    Return
                End If
            Case funcstatecursor.FUNCNAME
                If rd_token = tokenhared.token.IDENTIFIER OrElse rd_token = tokenhared.token.INIT Then
                    xmethods(i).name = value
                    funcstate = funcstatecursor.FUNCPARA
                Else
                    dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "func main()
{...}")
                End If
            Case funcstatecursor.FUNCPARA
                Select Case parastate
                    Case funcparastate.WAITFORSTARTBRACKET
                        If rd_token = tokenhared.token.PRSTART Then
                            xmethods(i).nopara = True
                            parastate = funcparastate.WAITFORNEWPARAMETER
                            Return
                        Else
                            dserr.new_error(conserr.errortype.FUNCOPBRACKETEXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "func main()
{...}")
                        End If
                    Case funcparastate.WAITFORNEWPARAMETER
                        If rd_token = tokenhared.token.PREND Then
                            funcstate = funcstatecursor.FUNCSTBLOCK
                            Return
                        Else
                            get_parameters(value, rd_token, linecinf, i)
                            Return
                        End If
                End Select

            Case funcstatecursor.FUNCRETURNTYPE
                Dim cildatatype As String = String.Empty
                If rd_token <> tokenhared.token.IDENTIFIER AndAlso rd_token <> tokenhared.token.COMMONDATATYPE Then
                    If xmethods(i).isexpr Then
                        dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "expr kelvin(ct : i32) : i32 = [ct + 373]")
                    Else
                        dserr.new_error(conserr.errortype.IDENTIFIEREXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "func get_data(id : i16) :: i32
{...}")
                    End If
                End If

                If servinterface.is_common_data_type(value, cildatatype) Then
                    'Common Data Type
                    xmethods(i).returntype = cildatatype
                Else
                    'Else Types ...
                    xmethods(i).returntype = value
                End If
                If xmethods(i).isexpr Then
                    funcstate = funcstatecursor.FUNCEXPRASSIGNMENT
                Else
                    funcstate = funcstatecursor.FUNCSTBLOCK
                End If

                Return

            Case funcstatecursor.FUNCEXPRASSIGNMENT
                If rd_token = tokenhared.token.EQUALS Then
                    funcstate = funcstatecursor.FUNCEXPREQUEXPRESSION
                Else
                    dserr.new_error(conserr.errortype.SYNTAXERROR, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "expr kelvin(ct : i32) : i32 = [ct + 373]")
                End If
                Return
            Case funcstatecursor.FUNCEXPREQUEXPRESSION
                If rd_token = tokenhared.token.EXPRESSION Then
                    bdyformatter = New bodyformatter("Func", sourceloc)
                    bdyformatter.new_token_shared("{", tokenhared.token.BLOCKOPEN, linecinf)
                    bdyformatter.new_token_shared(value, rd_token, linecinf)
                    bdyformatter.new_token_shared("}", tokenhared.token.BLOCKEND, linecinf)
                    xmethods(i).bodyxmlfmt = bdyformatter.xmlresult
                    i += 1
                    _settingup()
                Else
                    dserr.new_error(conserr.errortype.SYNTAXERROR, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "expr kelvin(ct : i32) : i32 = [ct + 373]")
                End If
                Return
            Case funcstatecursor.FUNCSTBLOCK
                If rd_token = tokenhared.token.BLOCKOPEN AndAlso xmethods(i).isexpr = False Then
                    funcstate = funcstatecursor.FUNCBODY
                    bdyformatter = New bodyformatter("Func", sourceloc)
                    bdyformatter.new_token_shared(value, rd_token, linecinf)
                ElseIf rd_token = tokenhared.token.ASSINQ AndAlso xmethods(i).returntype = String.Empty Then
                    funcstate = funcstatecursor.FUNCRETURNTYPE
                Else
                    If xmethods(i).isexpr Then
                        dserr.new_error(conserr.errortype.BLOCKOPENEXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "expr kelvin(ct : i32) : i32 = [ct + 373]")
                    Else
                        dserr.new_error(conserr.errortype.BLOCKOPENEXPECTED, linecinf.line, sourceloc, authfunc.get_line_error(sourceloc, linecinf, value), "func get_data(id : i16)
{...}")
                    End If
                End If

            Case funcstatecursor.FUNCBODY
                If bdyformatter.new_token_shared(value, rd_token, linecinf) = True Then
                    xmethods(i).bodyxmlfmt = bdyformatter.xmlresult
                    i += 1
                    _settingup()
                End If
        End Select

    End Sub

    Private Sub get_parameters(value As String, rd_token As tokenhared.token, linecinf As lexer.targetinf, i As Integer)
        Static Dim arindex As Integer = 0
        Select Case paraitemstate
            Case funcparaitemstate.WAITFORIDENTIFIER
                paraitemstate = funcparaitemstate.WAITFORASSIGNMENTOPERATOR
                If IsNothing(xmethods(i).parameters) Then
                    arindex = 0
                    Array.Resize(xmethods(i).parameters, 1)
                Else
                    arindex = xmethods(i).parameters.Length
                    Array.Resize(xmethods(i).parameters, xmethods(i).parameters.Length + 1)
                End If
                xmethods(i).parameters(arindex).name = value
            Case funcparaitemstate.WAITFORASSIGNMENTOPERATOR
                If rd_token = tokenhared.token.ASSINQ Then
                    paraitemstate = funcparaitemstate.WAITFORPARAMETERTYPE
                Else
                    dserr.args.Add(value)
                    dserr.new_error(conserr.errortype.OPERATORUNKNOWN, linecinf.line, sourceloc, "Use the ':' operator." & vbCrLf & authfunc.get_line_error(sourceloc, linecinf, value), "func get_data(id : i16)
{...}")
                End If
            Case funcparaitemstate.WAITFORPARAMETERTYPE
                paraitemstate = funcparaitemstate.WAITFORSPLITTER
                xmethods(i).parameters(arindex).ptype = value
            Case funcparaitemstate.WAITFORSPLITTER
                If rd_token = tokenhared.token.CMA Then
                    paraitemstate = funcparaitemstate.WAITFORIDENTIFIER

                    'Check is pointer
                ElseIf rd_token = tokenhared.token.AND Then
                    xmethods(i).parameters(arindex).byreference = True
                Else
                    dserr.args.Add(value)
                    dserr.new_error(conserr.errortype.OPERATORUNKNOWN, linecinf.line, sourceloc, "Use ','" & vbCrLf & authfunc.get_line_error(sourceloc, linecinf, value), "func get_data(id : i16 , msg : str)
{...}")
                End If
        End Select
    End Sub
    Public Function _to_organize() As tknformat._class
        xclass(0).methods = xmethods
        xclass(0).name = conrex.NULL
        xclass(0).includelist = includelist
        xclass(0).enums = xenum
        If IsNothing(xfield) = False AndAlso xfield.Length = 1 AndAlso xfield(0).name = conrex.NULL Then
            xclass(0).fields = Nothing
        Else
            xclass(0).fields = xfield
        End If
        Return xclass(0)
    End Function
    Public Sub _settingup()
        state = statecursor.OUT
        fieldstate = pbfieldstate.OUT
        funcstate = funcstatecursor.OUT
        enumstate = enumerationcursor.OUT
        parastate = funcparastate.WAITFORSTARTBRACKET
        paraitemstate = funcparaitemstate.WAITFORIDENTIFIER
        incstate = includestate.OUT
    End Sub

End Class
