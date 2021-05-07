Public Class constcli
    Friend Shared maincohelp As String = "YO Lang Compiler Version [%version%]
Copyright (C) YODevs . All rights reserved.".Replace("%version%", conrex.VER)

    Friend Shared helpheader As String = "--Select one of the menu items below : "
    Friend Const DEVQES As String = "Do you want developer mode to be enabled on the compiler?[Y/N]"
    Friend Const DEVCHARERROR As String = "The value entered is invalid."
    Friend Const DEVONCHANGED As String = "Mode successfully changed."
End Class
