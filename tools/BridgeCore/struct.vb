Public Class struct

    Public Structure _method
        Dim name As String
        Dim returntype As Type
        Dim parameter() As _parameterinfo
        Dim isstatic, isvirtual, ispublic As Boolean
    End Structure
    Public Structure _parameterinfo
        Dim __type As _type
        Dim name As String
        Dim isout As Boolean
        Dim position As Integer
    End Structure
    Public Structure _type
        Dim name, _namespace, fullname, assemblyqualifiedname As String
        Dim isarray, isenum, isvaluetype, isclass As Boolean
        Dim __assembly As _assembly
    End Structure

    Public Structure _assembly
        Dim location, fullname, tostring As String
    End Structure
End Class
