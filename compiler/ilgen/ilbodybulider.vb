Imports YOCA

Public Class ilbodybulider

    Public ildt As ilformat.ildata
    Friend Shared dotnetcorebasicextern As New ArrayList
    Friend Shared path As String
    Friend Shared attribute As yocaattribute.yoattribute
    Private cachesystem As Boolean = False
    Private ctorset As Boolean = False
    Private sbc As Text.StringBuilder
    Public ReadOnly Property source() As String
        Get
            Return sbc.ToString
        End Get
    End Property

    Friend Shared Sub set_basic_assembly()
        Dim externcount As Integer = ilbodybulider.dotnetcorebasicextern.Count - 1
        Dim sb As New Text.StringBuilder
        For i2 = 0 To externcount
            sb.AppendLine(String.Format(".assembly extern {0}{1}", ilbodybulider.dotnetcorebasicextern(i2), "{}"))
        Next
        ilgencode.source = sb.ToString & vbCrLf & ilgencode.source
    End Sub

    Public Sub New(ilclassdata As ilformat.ildata, attr As yocaattribute.yoattribute)
        ildt = ilclassdata
        attribute = attr
        sbc = New Text.StringBuilder
    End Sub

    Public Sub conv_to_msil()
        ctorset = False
        cachesystem = False
        check_allow_to_cache()
        For index = 0 To ildt.assemblyextern.Length - 1
            add_assembly(ildt.assemblyextern(index))
        Next

        If attribute._app._classname <> Nothing Then
            imp_module(cilkeywordchecker.get_key(attribute._app._classname))
        Else
            imp_module(compdt.YOMAINCLASS)
        End If
        newline()

        imp_enum(ildt.enumeration)
        newline()

        If IsNothing(ildt.ilmethod) = False Then
            For index = 0 To ildt.ilmethod.Length - 1
                newline()
                imp_func(ildt.ilmethod(index))
            Next
        End If

        newline()


        imp_ctor()

        newline()

        add_en_block()

        If cachesystem Then cachemkr.create_cache_file(path, sbc.ToString)
    End Sub

    Private Sub imp_enum(enumeration() As tknformat._enum)
        If IsNothing(enumeration) Then Return
        For index = 0 To enumeration.Length - 1
            add_il_code(String.Format(".class nested public auto ansi sealed {0}
        extends [" & compdt.CORELIB & "]System.Enum", cilkeywordchecker.get_key(enumeration(index).name)))
            add_st_block()
            add_il_code(".field public specialname rtspecialname int32 value__")
            For itemindex = 0 To enumeration(index).constkeys.Count - 1
                add_il_code(String.Format(".field public static literal valuetype {0}/{1} {2} = int32({3})", cilkeywordchecker.get_key(attribute._app._classname), cilkeywordchecker.get_key(enumeration(index).name), enumeration(index).constkeys(itemindex).ToString, enumeration(index).constvalues(itemindex).ToString))
            Next
            add_en_block()
        Next
        newline()
    End Sub

    Public Sub imp_ctor()
        If ctorset = False Then
            If IsNothing(ildt.instancector) = False AndAlso ildt.instancector.Count > 0 OrElse IsNothing(ildt.staticctor) = False AndAlso ildt.staticctor.Count > 0 Then
                add_il_code(".method public specialname rtspecialname instance void .ctor() cil managed ")
                add_il_code("{")
                add_il_code("ldarg.0
call instance void [" & compdt.CORELIB & "]System.Object::.ctor()")
                For index = 0 To ildt.instancector.Count - 1
                    add_il_code(ildt.instancector(index))
                Next
                add_il_code("ret")
                add_il_code("}")
            End If
        End If

        If IsNothing(ildt.staticctor) = False AndAlso ildt.staticctor.Count > 0 Then
            add_il_code(".method public specialname rtspecialname static void .cctor() cil managed ")
            add_il_code("{")
            For index = 0 To ildt.staticctor.Count - 1
                add_il_code(ildt.staticctor(index))
            Next
            add_il_code("ret")
            add_il_code("}")
        End If
    End Sub
    Public Sub imp_field()
        If IsNothing(ildt.field) Then Return
        newline()
        Dim lcode As String = String.Empty
        For index = 0 To ildt.field.Length - 1
            If ildt.field(index).isliteral Then
                'NEED TO REVIEW
                lcode = ".field " & ildt.field(index).accesscontrol & conrex.SPACE & "static literal" &
                    conrex.SPACE & ildt.field(index).ptype & conrex.SPACE & cilkeywordchecker.get_key(ildt.field(index).name) & conrex.SPACE
                lcode &= " = " & ildt.field(index).ptype & "(" & ildt.field(index).value & ")"
            Else
                Dim arraychars As String = Nothing
                If ildt.field(index).isarray Then arraychars = "[]"
                If ildt.field(index).typeinf.isprimitive Then
                    lcode = String.Format(".field {0} {1} {2}{4} {3}", ildt.field(index).accesscontrol, ildt.field(index).modifier,
                                       ildt.field(index).typeinf.cdttypesymbol, cilkeywordchecker.get_key(ildt.field(index).name), arraychars)
                Else
                    If ildt.field(index).typeinf.isinternalclass Then
                        lcode = String.Format(".field {0} {1} class {2}{4} {3}", ildt.field(index).accesscontrol, ildt.field(index).modifier,
                                       cilkeywordchecker.get_key(ildt.field(index).typeinf.fullname), cilkeywordchecker.get_key(ildt.field(index).name), arraychars)
                    Else
                        lcode = String.Format(".field {0} {1} class [{2}]{3}{5} {4}", ildt.field(index).accesscontrol, ildt.field(index).modifier,
                                      cilkeywordchecker.get_key(netcorerectifier.fullname_checking(ildt.field(index).typeinf.fullname, ildt.field(index).typeinf.externlib)), cilkeywordchecker.get_key(ildt.field(index).typeinf.fullname), cilkeywordchecker.get_key(ildt.field(index).name), arraychars)
                    End If
                End If
            End If
            add_il_code(lcode)
        Next
        newline()
    End Sub

    Public Function get_cil_access_control(accessibletoken As ilformat._accessiblemethod) As String
        Select Case accessibletoken
            Case ilformat._accessiblemethod.PUBLIC
                Return compdt.ACCESSIBLE_PUBLIC
            Case ilformat._accessiblemethod.PRIVATE
                Return compdt.ACCESSIBLE_PRIVATE
        End Select
        Return compdt.ACCESSIBLE_PUBLIC
    End Function
    Public Function get_cil_modifier_type(modifiertoken As ilformat._accessiblemethod) As String
        Select Case modifiertoken
            Case ilformat._modifiertype.INSTANCE
                Return compdt.OBJECTMODTYPE_INSTANCE
            Case ilformat._modifiertype.STATIC
                Return compdt.OBJECTMODTYPE_STATIC
        End Select
        Return compdt.OBJECTMODTYPE_STATIC
    End Function

    Public Sub set_constructor(funcdt As ilformat._ilmethodcollection)
        ctorset = True
        add_inline_code(".method public specialname rtspecialname instance void .ctor")
        If IsNothing(funcdt.parameter) Then
            add_inline_code(conrex.PRSTEN)
        Else
            imp_parameter(funcdt)
        End If
        add_inline_code(" cil managed")
        add_st_block()
        If funcdt.locallinit.Length > 0 Then
            imp_locals_init(funcdt)
        End If

        add_il_code("ldarg.0
call instance void [" & compdt.CORELIB & "]System.Object::.ctor()")

        If IsNothing(ildt.instancector) = False AndAlso ildt.instancector.Count > 0 OrElse IsNothing(ildt.staticctor) = False AndAlso ildt.staticctor.Count > 0 Then
            For index = 0 To ildt.instancector.Count - 1
                add_il_code(ildt.instancector(index))
            Next
        End If
        imp_body(funcdt, Nothing)
        add_il_code("ret")
        add_en_block()
    End Sub

    Private Sub set_destructor(funcdt As ilformat._ilmethodcollection)
        add_inline_code(".method family hidebysig strict virtual instance void Finalize()  cil managed")
        If IsNothing(funcdt.parameter) = False Then
            dserr.args.Add(String.Format("The destructor method in {0} class does not support parameters.", attribute._app._classname))
            dserr.new_error(conserr.errortype.DESTRUCTERROR, -1, Nothing, Nothing, Nothing)
        End If
        add_st_block()
        If funcdt.locallinit.Length > 0 Then
            imp_locals_init(funcdt)
        End If
        imp_body(funcdt, Nothing)
        add_il_code("ret")
        add_en_block()
    End Sub

    Public Sub imp_func(funcdt As ilformat._ilmethodcollection)
        If funcdt.name.ToLower = "ctor" AndAlso funcdt.methodmodtype = ilformat._modifiertype.INSTANCE AndAlso funcdt.accessible = ilformat._accessiblemethod.PUBLIC Then
            set_constructor(funcdt)
            Return
        ElseIf funcdt.name.ToLower = "destruct" Then
            set_destructor(funcdt)
            Return
        End If
        Dim headfuncdt As String = String.Format(".method {1} {0} ", get_cil_modifier_type(funcdt.methodmodtype), get_cil_access_control(funcdt.accessible))

        If funcdt.returntype = "void" Or funcdt.returntype = Nothing Then
            headfuncdt &= "void"
        Else
            If funcdt.isretarray Then
                funcdt.returntype = funcdt.returntype.Remove(funcdt.returntype.IndexOf(conrex.BRSTART))
            End If
            If servinterface.is_cil_common_data_type(funcdt.returntype) Then
                headfuncdt &= funcdt.returntype
            Else
                'other types
                headfuncdt &= String.Format("class [{0}]{1}", funcdt.returninfo.asmextern, funcdt.returninfo.classname)
            End If
            If funcdt.isretarray Then headfuncdt &= conrex.BRSTEN
        End If

        headfuncdt &= conrex.SPACE & cilkeywordchecker.get_key(funcdt.name)
        If IsNothing(funcdt.parameter) Then
            headfuncdt &= "()"
            add_il_code(headfuncdt)
        Else
            add_il_code(headfuncdt)
            imp_parameter(funcdt)
        End If
        add_inline_code(" cil managed")
        add_st_block()

        If funcdt.entrypoint Then
            add_il_code(".entrypoint")
        End If

        'Test import_locals_init()
        'imp_cil_code.import_test_local_init(funcdt)
        If funcdt.locallinit.Length > 0 Then
            imp_locals_init(funcdt)
        End If

        'Test Subroutine
        imp_cil_code.import_test_code(funcdt)
        Dim impretopt As Boolean = True
        imp_body(funcdt, impretopt)

        If funcdt.entrypoint AndAlso attribute._app._wait Then
            set_wait_attribute()
        End If

        If impretopt Then
            If funcdt.returntype <> conrex.NULL AndAlso funcdt.returntype.ToLower <> conrex.VOID Then
                add_il_code("ldnull")
            End If
            add_il_code(conrex.ret)
        End If
        add_en_block()
    End Sub

    Private Sub imp_parameter(funcdt As ilformat._ilmethodcollection)
        add_inline_code("(")
        newline()
        For index = 0 To funcdt.parameter.Length - 1
            Dim cildatatype As String = String.Empty
            If servinterface.is_common_data_type(funcdt.parameter(index).datatype, cildatatype) Then
                If funcdt.parameter(index).ispointer Then cildatatype &= conrex.AMP
                add_inline_code(cildatatype)
            Else
                'Other Types ...
                Dim gcodeparam As String = conrex.NULL
                Dim classref, dllref As String
                If funcdt.parameter(index).typeinf.valtpinf.classname = conrex.NULL Then
                    classref = compdt.CLASS
                Else
                    classref = compdt.VALUETYPE
                End If
                If funcdt.parameter(index).typeinf.externlib <> conrex.NULL Then dllref = String.Format("[{0}]", netcorerectifier.fullname_checking(funcdt.parameter(index).typeinf.fullname, funcdt.parameter(index).typeinf.externlib))

                If classref = compdt.CLASS Then
                    gcodeparam = String.Format("{0} {1}{2}", classref, dllref, funcdt.parameter(index).typeinf.fullname)
                Else
                    gcodeparam = String.Format("{0} {1}{2}/{3}", classref, dllref, funcdt.parameter(index).typeinf.valtpinf.classname, funcdt.parameter(index).typeinf.valtpinf.objectname)
                End If
                If funcdt.parameter(index).ispointer Then gcodeparam &= conrex.AMP
                add_inline_code(gcodeparam)
            End If

            If funcdt.parameter(index).typeinf.isarray = True Then
                add_inline_code(conrex.BRSTEN)
            End If

            add_inline_code(conrex.SPACE)
            add_inline_code(cilkeywordchecker.get_key(funcdt.parameter(index).name))

            If funcdt.parameter.Length - 1 <> index Then
                add_inline_code(conrex.CMA)
                newline()
            End If
        Next
        add_il_code(")")
    End Sub
    Private Sub imp_locals_init(ByRef funcdt As ilformat._ilmethodcollection)
        add_il_code(".locals init(")
        Dim islot As Integer = 0
        For index = 0 To funcdt.locallinit.Length - 1
            If funcdt.locallinit(index).datatype = conrex.NULL Then Continue For
            Dim classref As String = String.Empty
            Dim dllref As String = String.Empty
            If funcdt.locallinit(index).typeinf.asminfo <> conrex.NULL Then
                If funcdt.locallinit(index).typeinf.isprimitive = False Then
                    If funcdt.locallinit(index).isvaluetypes Then
                        classref = compdt.VALUETYPE
                    Else
                        classref = compdt.CLASS
                    End If
                    If funcdt.locallinit(index).typeinf.externlib <> conrex.NULL Then dllref = String.Format("[{0}]", netcorerectifier.fullname_checking(funcdt.locallinit(index).typeinf.fullname, funcdt.locallinit(index).typeinf.externlib))
                End If
                Dim arrlgo As String = String.Empty
                Dim fullname As String = String.Empty
                funcdt.locallinit(index).name = cilkeywordchecker.get_key(funcdt.locallinit(index).name)
                If funcdt.locallinit(index).typeinf.isprimitive Then
                    fullname = cilkeywordchecker.get_key(funcdt.locallinit(index).typeinf.cdttypesymbol)
                Else
                    fullname = cilkeywordchecker.get_key(funcdt.locallinit(index).typeinf.fullname)
                End If
                If funcdt.locallinit(index).isarrayobj Then arrlgo = conrex.BRSTEN
                Dim locinitcode As String
                If funcdt.locallinit(index).isvaluetypes = False Then
                    locinitcode = String.Format("[{0}] {1} {2}{3}{4} {5}", islot, classref, dllref, fullname, arrlgo, funcdt.locallinit(index).name)
                Else
                    locinitcode = String.Format("[{0}] {1} {2}{3}/{4}{5} {6}", islot, classref, dllref, funcdt.locallinit(index).typeinf.valtpinf.classname, funcdt.locallinit(index).typeinf.valtpinf.objectname, arrlgo, funcdt.locallinit(index).name)
                End If
                add_il_code(locinitcode)
                If funcdt.locallinit.Length <> index + 1 Then
                    add_inline_code(conrex.CMA)
                End If

            Else
                imp_locals_init_lgcy(funcdt, index, islot)
            End If
            islot += 1
        Next
        add_il_code(")")
    End Sub

    Private Sub imp_locals_init_lgcy(ByRef funcdt As ilformat._ilmethodcollection, index As Integer, islot As Integer)
        Dim classref As String = String.Empty
        Dim dllref As String = String.Empty
        If funcdt.locallinit(index).iscommondatatype = False Then
            classref = "class "
            If funcdt.locallinit(index).asmextern <> conrex.NULL Then
                dllref = String.Format("[{0}]", funcdt.locallinit(index).asmextern)
            End If
        End If
        Dim arrlgo As String = String.Empty
        funcdt.locallinit(index).name = cilkeywordchecker.get_key(funcdt.locallinit(index).name)
        funcdt.locallinit(index).datatype = cilkeywordchecker.get_key(funcdt.locallinit(index).datatype)
        If funcdt.locallinit(index).isarrayobj Then arrlgo = conrex.BRSTEN
        If funcdt.locallinit.Length = index + 1 Then
            add_il_code("[" & islot & "] " & classref & dllref & funcdt.locallinit(index).datatype & arrlgo & " " & funcdt.locallinit(index).name)
        Else
            add_il_code("[" & islot & "] " & classref & dllref & funcdt.locallinit(index).datatype & arrlgo & " " & funcdt.locallinit(index).name & " , ")
        End If
    End Sub
    Private Sub imp_body(funcdt As ilformat._ilmethodcollection, ByRef impretopt As Boolean)
        If funcdt.entrypoint Then
            If attribute._app._title <> String.Empty Then
                Dim externlib As String = String.Empty
                Select Case compdt._PROJECTFRAMEWORK
                    Case compdt.__projectframework.DotNetCore
                        externlib = "System.Console"
                    Case compdt.__projectframework.DotNetFramework
                        externlib = conrex.MSCORLIB
                End Select

                add_il_code(String.Format("ldstr ""{0}""
call void [{1}]System.Console::set_Title(string)", attribute._app._title, externlib))
            End If
        End If
        Dim linecode As String = String.Empty
        For index = 0 To funcdt.codes.Count - 1
            linecode = funcdt.codes(index).ToString.Trim
            If linecode = conrex.NULL Then Continue For
            impretopt = (linecode <> conrex.ret)
            If compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetCore Then netcorerectifier.assembly_checking(linecode)
            add_il_code(linecode)
        Next
    End Sub
    Private Sub imp_module(name As String)
        'check name
        name = cilkeywordchecker.get_key(name)
        Dim checkfieldinit As String = conrex.SPACE
        If IsNothing(ildt.instancector) = False AndAlso ildt.instancector.Count > 0 OrElse IsNothing(ildt.staticctor) = False AndAlso ildt.staticctor.Count > 0 Then
            checkfieldinit = " beforefieldinit "
        End If

        Dim heri As String = conrex.NULL
        If attribute._app._issealed Then
            heri = " sealed "
        End If
        If compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetFramework Then
            If attribute._app._namespace <> String.Empty Then
                add_il_code(".class public auto ansi" & heri & checkfieldinit & attribute._app._namespace & conrex.DOT & name)
            Else
                add_il_code(".class public auto ansi" & heri & checkfieldinit & name)
            End If
        Else
            If attribute._app._namespace <> String.Empty Then
                add_il_code(".class public auto ansi sealed beforefieldinit " & attribute._app._namespace & conrex.DOT & name)
            Else
                add_il_code(".class public  auto ansi sealed beforefieldinit " & name)
            End If
        End If
        add_il_code(String.Format("extends [{0}]System.Object", compdt.CORELIB))
        add_st_block()
        imp_field()
    End Sub

    Public Sub add_st_block()
        add_il_code(conrex.STBLOCK)
    End Sub
    Public Sub add_en_block()
        add_il_code(conrex.ENBLOCK)
    End Sub

    Public Sub newline()
        sbc.AppendLine()
    End Sub
    Public Sub add_assembly(assemblydt As ilformat._ilassemblyextern)
        'check uniq assembly
        'check names
        assemblydt.name = cilkeywordchecker.get_key(assemblydt.name)
        If assemblydt.isextern Then
            add_il_code(".assembly extern " & assemblydt.name & assemblydt.assemblyproperty)
        Else
            add_il_code(".assembly " & assemblydt.name & assemblydt.assemblyproperty)
        End If
    End Sub
    Public Sub add_il_code(code As String)
        sbc.Append(vbCrLf & code)
    End Sub
    Public Sub add_inline_code(code As String)
        sbc.Append(code)
    End Sub
    Public Sub set_wait_attribute()
        add_il_code(compdt.WAITILCODE)
        If compdt._PROJECTFRAMEWORK = compdt.__projectframework.DotNetCore Then
            Dim externcount As Integer = ilbodybulider.dotnetcorebasicextern.Count - 1
            For i2 = 0 To externcount
                If (ilbodybulider.dotnetcorebasicextern(i2) = "System.Console") Then
                    Return
                End If
            Next
            ilbodybulider.dotnetcorebasicextern.Add("System.Console")
        End If
    End Sub
    Public Sub check_allow_to_cache()
        If compdt.NOCACHE = False Then
            If attribute._cfg._no_cache = False Then
                cachesystem = True
            End If
        End If
        If compdt.DEVMOD = True Then cachesystem = False
    End Sub
End Class
