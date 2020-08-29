Public Class yocaattribute
    ''' <summary>
    ''' Configure options for compiler.
    ''' </summary>
    Structure cfg
        Dim _cilinject As Boolean
    End Structure

    Structure yoattribute
        Dim _cfg As cfg
    End Structure

    Structure resultattribute
        Dim typeattribute As String
        Dim fieldattribute As String
        Dim valueattribute As String
    End Structure
End Class
