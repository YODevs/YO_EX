Imports System.Text.RegularExpressions

Public Class attr

    Private attribute As yocaattribute.yoattribute
    Private cfgattr As yocaattribute.cfg
    Private path As String
    Public Sub New(path As String)
        Me.path = path
        attribute = New yocaattribute.yoattribute
        cfgattr = New yocaattribute.cfg
        setinattr.init(attribute)
    End Sub

    Public Function parse_attribute(experssion As String) As yocaattribute.yoattribute
        If Regex.IsMatch(experssion, "\#\[\w+::\w+\(.+\)\]") Then
            Dim resultattr As yocaattribute.resultattribute = get_properties(experssion)
            set_attribute(resultattr)
        Else
            'Set error
        End If
    End Function

    Private Function get_properties(experssion As String) As yocaattribute.resultattribute
        Dim resultattr As New yocaattribute.resultattribute
        experssion = experssion.Remove(0, 2)
        Dim value As String = experssion.Remove(experssion.IndexOf("::"))
        resultattr.typeattribute = value
        experssion = experssion.Remove(0, experssion.IndexOf("::") + 2)

        value = experssion.Remove(experssion.IndexOf("("))
        resultattr.fieldattribute = value
        experssion = experssion.Remove(0, experssion.IndexOf("(") + 1)

        value = experssion.Remove(experssion.IndexOf(")"))
        resultattr.valueattribute = value

        Return resultattr
    End Function

    Public Sub set_attribute(resultattr As yocaattribute.resultattribute)
        Select Case resultattr.typeattribute.ToLower
            Case "cfg"
                set_cfg_attribute(resultattr)
            Case Else
                'Set Error
        End Select
    End Sub

    Private Sub set_cfg_attribute(resultattr As yocaattribute.resultattribute)
        Select Case resultattr.fieldattribute.ToLower
            Case "cil"
                attribute._cfg._cilinject = setinattr.get_bool_val(resultattr, path)
            Case Else
                'Set Error
        End Select
    End Sub
End Class
