Public Class yocaattribute
    ''' <summary>
    ''' Configure options for compiler.
    ''' </summary>
    Structure cfg
        Dim _cilinject As Boolean
        Dim _optimize_expression As Boolean
        Dim _disable_warnings As Boolean
    End Structure

    Structure app
        Dim _namespace As String
        Dim _classname As String
        Dim _wait As Boolean
        Dim _issealed As Boolean
    End Structure
    Structure yoattribute
        Dim _cfg As cfg
        Dim _app As app
    End Structure

    Structure resultattribute
        Dim typeattribute As String
        Dim fieldattribute As String
        Dim valueattribute As String
    End Structure
End Class
