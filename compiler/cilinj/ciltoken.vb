''' <summary>
''' <en>
''' In this class, a list of commands and feature of Microsoft CIL commands is kept.
''' </en>
''' 
''' <fa>
''' در این کلاس لیستی از دستورات و خاصیت دستورات میانی مایکروسافت نگهداری می شود
''' </fa>
''' </summary>
Public Class ciltoken

    Public Shared cilinstruct() As cilinstruction
    ''' <summary>
    ''' <en>
    ''' First value: CIL commands
	''' Second value: Does it supoort parameter command?
	''' Third value: CIL's datatype equal to YOlang's common datatypes
    ''' </en>
    ''' <fa>
    ''' مقدار اول : دستور زبان میانی
    ''' مقدار دوم : آیا دستور پارامتر را پشتیبانی می کند
    ''' مقدار سوم : دیتاتایپ دستور میانی به توافق دیتاتایپ های معمول یولنگ
    ''' </fa>
    ''' </summary>
    Structure cilinstruction
        Dim keyword As String
        Dim hasparam As Boolean
        Dim datatype As String
    End Structure

    Friend Shared Sub set_cil_instruct(keyword As String, Optional hasparam As Boolean = False, Optional datatype As String = "-")
        Static Dim indexarray As Int16 = 0
        Array.Resize(cilinstruct, indexarray + 1)
        cilinstruct(indexarray) = New cilinstruction
        cilinstruct(indexarray).keyword = keyword
        cilinstruct(indexarray).hasparam = hasparam
        cilinstruct(indexarray).datatype = datatype
        indexarray += 1
        Return
    End Sub

    ''' <summary>
    ''' <en>
    ''' Preparing and storing CIL commands
    ''' </en>
    ''' 
    ''' <fa>
    ''' آماده سازی و استور کردن دستورات CIL
    ''' </fa>
    ''' </summary>
    Friend Shared Sub init_cil_instruction()
        set_cil_instruct("add")
        set_cil_instruct("add.ovf")
        set_cil_instruct("add.ovf.un")
        set_cil_instruct("and")
        set_cil_instruct("arglist")

        set_cil_instruct("beq", True, "i32")
        set_cil_instruct("beq.s", True, "i8")

        set_cil_instruct("bge", True, "i32")
        set_cil_instruct("bge.s", True, "i8")
        set_cil_instruct("bge.un", True, "i32")
        set_cil_instruct("bge.un.s", True, "i8")

        set_cil_instruct("bgt", True, "i32")
        set_cil_instruct("bgt.s", True, "i8")
        set_cil_instruct("bgt.un", True, "i32")
        set_cil_instruct("bgt.un.s", True, "i8")

        set_cil_instruct("ble", True, "i32")
        set_cil_instruct("ble.s", True, "i8")
        set_cil_instruct("ble.un", True, "i32")
        set_cil_instruct("ble.un.s", True, "i8")

        set_cil_instruct("blt", True, "i32")
        set_cil_instruct("blt.s", True, "i8")
        set_cil_instruct("blt.un", True, "i32")
        set_cil_instruct("blt.un.s", True, "i8")

        set_cil_instruct("bne.un", True, "i32")
        set_cil_instruct("bne.un.s", True, "i8")

        set_cil_instruct("box", True)

        set_cil_instruct("br", True, "i32")
        set_cil_instruct("br.s", True, "i8")

        set_cil_instruct("break")

        set_cil_instruct("brfalse", True, "i32")
        set_cil_instruct("brfalse.s", True, "i8")

        set_cil_instruct("brinst", True, "i32")
        set_cil_instruct("brinst.s", True, "i8")

        set_cil_instruct("brnull", True, "i32")
        set_cil_instruct("brnull.s", True, "i8")

        set_cil_instruct("brtrue", True, "i32")
        set_cil_instruct("brtrue.s", True, "i8")

        set_cil_instruct("brzero", True, "i32")
        set_cil_instruct("brzero.s", True, "i8")

        set_cil_instruct("call", True)
        set_cil_instruct("callvirt", True)
        set_cil_instruct("calli", True)
        set_cil_instruct("castclass", True)

        set_cil_instruct("ceq")
        set_cil_instruct("cgt")
        set_cil_instruct("cgt.un")
        set_cil_instruct("ckfinite")
        set_cil_instruct("clt")
        set_cil_instruct("clt.un")
        set_cil_instruct("constrained.", True)

        set_cil_instruct("conv.i")
        set_cil_instruct("conv.i1")
        set_cil_instruct("conv.i2")
        set_cil_instruct("conv.i4")
        set_cil_instruct("conv.i8")
        set_cil_instruct("conv.ovf.i")
        set_cil_instruct("conv.ovf.i.un")
        set_cil_instruct("conv.ovf.i1")
        set_cil_instruct("conv.ovf.i1.un")
        set_cil_instruct("conv.ovf.i2")
        set_cil_instruct("conv.ovf.i2.un")
        set_cil_instruct("conv.ovf.i4")
        set_cil_instruct("conv.ovf.i4.un")
        set_cil_instruct("conv.ovf.i8")
        set_cil_instruct("conv.ovf.i8.un")

        set_cil_instruct("conv.ovf.u")
        set_cil_instruct("conv.ovf.u.un")
        set_cil_instruct("conv.ovf.u1")
        set_cil_instruct("conv.ovf.u1.un")
        set_cil_instruct("conv.ovf.u2")
        set_cil_instruct("conv.ovf.u2.un")
        set_cil_instruct("conv.ovf.u4")
        set_cil_instruct("conv.ovf.u4.un")
        set_cil_instruct("conv.ovf.u8")
        set_cil_instruct("conv.ovf.u8.un")

        set_cil_instruct("conv.r.un")
        set_cil_instruct("conv.r4")
        set_cil_instruct("conv.r8")
        set_cil_instruct("conv.u")
        set_cil_instruct("conv.u1")
        set_cil_instruct("conv.u2")
        set_cil_instruct("conv.u4")
        set_cil_instruct("conv.u8")

        set_cil_instruct("cpblk")
        set_cil_instruct("cpobj", True)
        set_cil_instruct("div")
        set_cil_instruct("div.u")
        set_cil_instruct("dup")
        set_cil_instruct("endfault")
        set_cil_instruct("endfilter")
        set_cil_instruct("endfinally")
        set_cil_instruct("initblk")
        set_cil_instruct("initobj", True)
        set_cil_instruct("isinst", True)
        set_cil_instruct("jmp", True)

        set_cil_instruct("ldarg", True, "ui16")
        set_cil_instruct("ldarg.0")
        set_cil_instruct("ldarg.1")
        set_cil_instruct("ldarg.2")
        set_cil_instruct("ldarg.3")
        set_cil_instruct("ldarg.s", True, "ui8")
        set_cil_instruct("ldarga", True, "ui16")
        set_cil_instruct("ldarga.s", True, "ui8")

        set_cil_instruct("ldc.i4", True, "i32")
        set_cil_instruct("ldc.i4.0")
        set_cil_instruct("ldc.i4.1")
        set_cil_instruct("ldc.i4.2")
        set_cil_instruct("ldc.i4.3")
        set_cil_instruct("ldc.i4.4")
        set_cil_instruct("ldc.i4.5")
        set_cil_instruct("ldc.i4.6")
        set_cil_instruct("ldc.i4.7")
        set_cil_instruct("ldc.i4.8")
        set_cil_instruct("ldc.i4.m1")
        set_cil_instruct("ldc.i4.M1")
        set_cil_instruct("ldc.i4.s", True, "i8")
        set_cil_instruct("ldc.i8", True, "i64")
        set_cil_instruct("ldc.r4", True, "f32")
        set_cil_instruct("ldc.r8", True, "f64")

        set_cil_instruct("ldelem", True)
        set_cil_instruct("ldelem.i")
        set_cil_instruct("ldelem.i1")
        set_cil_instruct("ldelem.i2")
        set_cil_instruct("ldelem.i4")
        set_cil_instruct("ldelem.i8")
        set_cil_instruct("ldelem.r4")
        set_cil_instruct("ldelem.r8")
        set_cil_instruct("ldelem.ref")
        set_cil_instruct("ldelem.u1")
        set_cil_instruct("ldelem.u2")
        set_cil_instruct("ldelem.u4")
        set_cil_instruct("ldelem.u8")
        set_cil_instruct("ldelema", True)
        set_cil_instruct("ldfld", True)
        set_cil_instruct("ldflda", True)
        set_cil_instruct("ldftn", True)

        set_cil_instruct("ldind.i")
        set_cil_instruct("ldind.i1")
        set_cil_instruct("ldind.i2")
        set_cil_instruct("ldind.i4")
        set_cil_instruct("ldind.i8")
        set_cil_instruct("ldind.r4")
        set_cil_instruct("ldind.r8")
        set_cil_instruct("ldind.ref")
        set_cil_instruct("ldind.u1")
        set_cil_instruct("ldind.u2")
        set_cil_instruct("ldind.u4")
        set_cil_instruct("ldind.u8")

        set_cil_instruct("ldlen")
        set_cil_instruct("ldloc", True, "ui16")
        set_cil_instruct("ldloc.0")
        set_cil_instruct("ldloc.1")
        set_cil_instruct("ldloc.2")
        set_cil_instruct("ldloc.3")
        set_cil_instruct("ldloc.s", True, "ui8")
        set_cil_instruct("ldloca", True, "ui16")
        set_cil_instruct("ldloca.s", True, "ui8")

        set_cil_instruct("ldnull")
        set_cil_instruct("ldobj", True)
        set_cil_instruct("ldsfld", True)
        set_cil_instruct("ldsflda", True)
        set_cil_instruct("ldstr", True)
        set_cil_instruct("ldtoken", True)
        set_cil_instruct("ldvirtftn", True)

        set_cil_instruct("leave", True, "i32")
        set_cil_instruct("leave.s", True, "i8")

        set_cil_instruct("localloc")
        set_cil_instruct("mkrefany", True)

        set_cil_instruct("mul")
        set_cil_instruct("mul.ovf")
        set_cil_instruct("mul.ovf.un")
        set_cil_instruct("neg")

        set_cil_instruct("newarr", True)
        set_cil_instruct("newobj", True)
        set_cil_instruct("no.", True)
        set_cil_instruct("nop")
        set_cil_instruct("not")
        set_cil_instruct("or")
        set_cil_instruct("pop")

        set_cil_instruct("readonly.", True)
        set_cil_instruct("refanytype")
        set_cil_instruct("refanyval", True)

        set_cil_instruct("rem")
        set_cil_instruct("rem.un")
        set_cil_instruct("ret")

        set_cil_instruct("rethrow")
        set_cil_instruct("shl")
        set_cil_instruct("shr")
        set_cil_instruct("shr.un")
        set_cil_instruct("sizeof", True)

        set_cil_instruct("starg", True, "i16")
        set_cil_instruct("starg.s", True, "i8")

        set_cil_instruct("stelem", True)
        set_cil_instruct("stelem.i")
        set_cil_instruct("stelem.i1")
        set_cil_instruct("stelem.i2")
        set_cil_instruct("stelem.i4")
        set_cil_instruct("stelem.i8")
        set_cil_instruct("stelem.r4")
        set_cil_instruct("stelem.i8")
        set_cil_instruct("stelem.ref")

        set_cil_instruct("stfld", True)
        set_cil_instruct("stind.i")
        set_cil_instruct("stind.i1")
        set_cil_instruct("stind.i2")
        set_cil_instruct("stind.i4")
        set_cil_instruct("stind.i8")
        set_cil_instruct("stind.r4")
        set_cil_instruct("stind.ref")

        set_cil_instruct("stloc", True, "ui16")
        set_cil_instruct("stloc.0")
        set_cil_instruct("stloc.1")
        set_cil_instruct("stloc.2")
        set_cil_instruct("stloc.3")
        set_cil_instruct("stloc.s", True, "ui8")

        set_cil_instruct("stobj", True)
        set_cil_instruct("stsfld", True)

        set_cil_instruct("sub")
        set_cil_instruct("sub.ovf")
        set_cil_instruct("sub.ovf.un")

        set_cil_instruct("switch", True)

        set_cil_instruct("tail.", True)
        set_cil_instruct("throw")
        set_cil_instruct("unaligned.", True)

        set_cil_instruct("unbox", True)
        set_cil_instruct("unbox.any", True)
        set_cil_instruct("volatile", True)
        set_cil_instruct("xor")

    End Sub
End Class
