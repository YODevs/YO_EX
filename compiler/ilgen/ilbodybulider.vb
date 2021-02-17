Public Class ilbodybulider

    Public ildt As ilformat.ildata
    Friend Shared path As String
    Friend Shared attribute As yocaattribute.yoattribute
    Private msilsource As String
    Public ReadOnly Property source() As String
        Get
            Return msilsource
        End Get
    End Property
    Public Sub New(ilclassdata As ilformat.ildata, attr As yocaattribute.yoattribute)
        ildt = ilclassdata
        attribute = attr
    End Sub

    Public Function conv_to_msil() As String
        For index = 0 To ildt.assemblyextern.Length - 1
            add_assembly(ildt.assemblyextern(index))
        Next

        If attribute._app._classname <> Nothing Then
            imp_module(attribute._app._classname)
        Else
            imp_module(compdt.YOMAINCLASS)
        End If
        newline()

        imp_ctor()

        newline()

        For index = 0 To ildt.ilmethod.Length - 1
            newline()
            imp_func(ildt.ilmethod(index))
        Next

        newline()
        add_en_block()

        Return source
    End Function

    Public Sub imp_ctor()

        If IsNothing(ildt.instancector) = False AndAlso ildt.instancector.Count > 0 OrElse IsNothing(ildt.staticctor) = False AndAlso ildt.staticctor.Count > 0 Then
            add_il_code(".method public specialname rtspecialname instance void .ctor() cil managed ")
            add_il_code("{")
            add_il_code("ldarg.0
call instance void [mscorlib]System.Object::.ctor()")
            For index = 0 To ildt.instancector.Count - 1
                add_il_code(ildt.instancector(index))
            Next
            add_il_code("ret")
            add_il_code("}")
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
                lcode = ".field " & ildt.field(index).accesscontrol & conrex.SPACE & "static literal" &
                    conrex.SPACE & ildt.field(index).ptype & conrex.SPACE & ildt.field(index).name & conrex.SPACE
                lcode &= " = " & ildt.field(index).ptype & "(" & ildt.field(index).value & ")"
            Else
                servinterface.is_common_data_type(ildt.field(index).ptype, ildt.field(index).ptype)
                lcode = ".field " & ildt.field(index).accesscontrol & conrex.SPACE & ildt.field(index).modifier &
                    conrex.SPACE & ildt.field(index).ptype & conrex.SPACE & ildt.field(index).name & conrex.SPACE
            End If
            add_il_code(lcode)
        Next
        newline()
    End Sub
    Public Sub imp_func(funcdt As ilformat._ilmethodcollection)
        Dim headfuncdt As String = ".method static"
        If funcdt.accessible = ilformat._accessiblemethod.PUBLIC Then
            headfuncdt &= " public "
        Else
            headfuncdt &= " private "
        End If

        If funcdt.returntype = "void" Or funcdt.returntype = Nothing Then
            headfuncdt &= "void"
        Else
            If servinterface.is_cil_common_data_type(funcdt.returntype) Then
                headfuncdt &= funcdt.returntype
            Else
                'other types
            End If
        End If

        headfuncdt &= Space(1) & funcdt.name
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
            If funcdt.returntype <> conrex.NULL AndAlso funcdt.returntype.ToLower <> "void" Then
                add_il_code("ldnull")
            End If
            add_il_code("ret")
        End If
        add_en_block()
    End Sub

    Private Sub imp_parameter(funcdt As ilformat._ilmethodcollection)
        add_inline_code("(")
        newline()
        For index = 0 To funcdt.parameter.Length - 1
            Dim cildatatype As String = String.Empty
            If servinterface.is_common_data_type(funcdt.parameter(index).datatype, cildatatype) Then
                If funcdt.parameter(index).ispointer Then cildatatype &= "&"
                add_inline_code(cildatatype)
            Else
                'Other Types ...
            End If

            add_inline_code(conrex.SPACE)
            add_inline_code(funcdt.parameter(index).name)

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
            Dim classref As String = String.Empty
            Dim dllref As String = String.Empty
            If funcdt.locallinit(index).datatype = conrex.NULL Then Continue For
            If funcdt.locallinit(index).iscommondatatype = False Then
                classref = "class "
                dllref = "[mscorlib]"
            End If

            If funcdt.locallinit.Length = index + 1 Then
                add_il_code("[" & islot & "] " & classref & dllref & funcdt.locallinit(index).datatype & " " & funcdt.locallinit(index).name)
            Else
                add_il_code("[" & islot & "] " & classref & dllref & funcdt.locallinit(index).datatype & " " & funcdt.locallinit(index).name & " , ")
            End If
            If funcdt.locallinit(index).hasdefaultvalue Then
                If funcdt.locallinit(index).iscommondatatype Then
                    '    assignmentcommondatatype.set_value(funcdt, index)
                Else
                    'Other Type...
                End If

            End If
            islot += 1
        Next
        add_il_code(")")
    End Sub
    Private Sub imp_body(funcdt As ilformat._ilmethodcollection, ByRef impretopt As Boolean)
        Dim linecode As String = String.Empty
        For index = 0 To funcdt.codes.Count - 1
            linecode = funcdt.codes(index).ToString.Trim
            If linecode = conrex.NULL Then Continue For
            If linecode = "ret" Then
                impretopt = False
            Else
                impretopt = True
            End If
            add_il_code(linecode)
        Next
    End Sub
    Private Sub imp_module(name As String)
        'check name
        Dim checkfieldinit As String = conrex.SPACE
        If IsNothing(ildt.instancector) = False AndAlso ildt.instancector.Count > 0 OrElse IsNothing(ildt.staticctor) = False AndAlso ildt.staticctor.Count > 0 Then
            checkfieldinit = " beforefieldinit "
        End If

        Dim heri As String = conrex.NULL
        If attribute._app._issealed Then
            heri = " sealed "
        End If
        If attribute._app._namespace <> String.Empty Then
            add_il_code(".class public auto ansi" & heri & checkfieldinit & attribute._app._namespace & conrex.DOT & name)
        Else
            add_il_code(".class public auto ansi" & heri & checkfieldinit & name)
        End If
        add_il_code("extends [mscorlib]System.Object")
        add_st_block()
        imp_field()
    End Sub

    Public Sub add_st_block()
        add_il_code("{")
    End Sub
    Public Sub add_en_block()
        add_il_code("}")
    End Sub

    Public Sub newline()
        add_il_code("")
    End Sub
    Public Sub add_assembly(assemblydt As ilformat._ilassemblyextern)
        'check uniq assembly
        'check names
        If assemblydt.isextern Then
            add_il_code(".assembly extern " & assemblydt.name & assemblydt.assemblyproperty)
        Else
            add_il_code(".assembly " & assemblydt.name & assemblydt.assemblyproperty)
        End If
    End Sub
    Public Sub add_il_code(code As String)
        msilsource &= vbCrLf & code
    End Sub
    Public Sub add_inline_code(code As String)
        msilsource &= code
    End Sub
    Public Sub set_wait_attribute()
        add_il_code(compdt.WAITILCODE)
    End Sub
End Class
