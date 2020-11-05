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

        For index = 0 To ildt.ilmethod.Length - 1
            newline()
            imp_func(ildt.ilmethod(index))
        Next

        newline()
        add_en_block()

        Return source
    End Function


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

        headfuncdt &= Space(1) & funcdt.name & "()"
        headfuncdt &= " cil managed"

        add_il_code(headfuncdt)
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

        imp_body(funcdt)

        If funcdt.entrypoint AndAlso attribute._app._wait Then
            set_wait_attribute()
        End If

        add_il_code("ret")
        add_en_block()
    End Sub

    Private Sub imp_locals_init(ByRef funcdt As ilformat._ilmethodcollection)
        add_il_code(".locals init(")
        For index = 0 To funcdt.locallinit.Length - 1
            Dim classref As String = String.Empty
            Dim dllref As String = String.Empty
            If funcdt.locallinit(index).iscommondatatype = False Then
                classref = "class "
                dllref = "[mscorlib]"
            End If

            If funcdt.locallinit.Length = index + 1 Then
                add_il_code("[" & index & "] " & classref & dllref & funcdt.locallinit(index).datatype & " " & funcdt.locallinit(index).name)
            Else
                add_il_code("[" & index & "] " & classref & dllref & funcdt.locallinit(index).datatype & " " & funcdt.locallinit(index).name & " , ")
            End If
            If funcdt.locallinit(index).hasdefaultvalue Then
                If funcdt.locallinit(index).iscommondatatype Then
                    '    assignmentcommondatatype.set_value(funcdt, index)
                Else
                    'Other Type...
                End If

            End If
        Next
        add_il_code(")")
    End Sub
    Private Sub imp_body(funcdt As ilformat._ilmethodcollection)
        For index = 0 To funcdt.codes.Count - 1
            add_il_code(funcdt.codes(index))
        Next
    End Sub
    Private Sub imp_module(name As String)
        'check name
        If attribute._app._namespace <> String.Empty Then
            add_il_code(".class public auto ansi sealed " & attribute._app._namespace & conrex.DOT & name)
        Else
            add_il_code(".class public auto ansi sealed " & name)
        End If
        add_st_block()
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

    Public Sub set_wait_attribute()
        add_il_code(compdt.WAITILCODE)
    End Sub
End Class
