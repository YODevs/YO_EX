Public Class ilbodybulider

    Public ildt As ilformat.ildata
    Friend Shared path As String
    Private msilsource As String
    Public ReadOnly Property source() As String
        Get
            Return msilsource
        End Get
    End Property
    Public Sub New(ilclassdata As ilformat.ildata)
        ildt = ilclassdata
    End Sub

    Public Function conv_to_msil() As String
        For index = 0 To ildt.assemblyextern.Length - 1
            add_assembly(ildt.assemblyextern(index))
        Next

        imp_module("YO_Main")
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

        If funcdt.returntype = "[void]" Then
            headfuncdt &= "void"
        Else
            'other types
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

        If funcdt.locallinit(0).name <> conrex.NULL Then
            imp_locals_init(funcdt)
        End If

        'Test Subroutine
        imp_cil_code.import_test_code(funcdt)

        imp_body(funcdt)
        add_il_code("ret")
        add_en_block()
    End Sub

    Private Sub imp_locals_init(ByRef funcdt As ilformat._ilmethodcollection)
        add_il_code(".locals init(")
        For index = 0 To funcdt.locallinit.Length - 1
            If funcdt.locallinit.Length = index + 1 Then
                add_il_code("[" & index & "] " & funcdt.locallinit(index).datatype & " " & funcdt.locallinit(index).name)
            Else
                add_il_code("[" & index & "] " & funcdt.locallinit(index).datatype & " " & funcdt.locallinit(index).name & " , ")
            End If
            If funcdt.locallinit(index).hasdefaultvalue Then
                If funcdt.locallinit(index).iscommondatatype Then
                    assignmentcommondatatype.set_value(funcdt, index)
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
        add_il_code(".class private auto ansi sealed " & name)
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

End Class
