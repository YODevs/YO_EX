''' <summary>
''' <en>
''' This class is for initial assignment of attributes and converting their value to desired unit
''' </en>
''' <fa>
''' این کلاس برای مقدار دهی اولیه برای اتربیوت ها و تبدیل مقدار آن ها به واحد خواسته شده دارد.
''' </fa>
''' </summary>
Public Class setinattr

    ''' <summary>
    ''' <en>
    ''' Initial assignment of all defined features for compiler
    ''' </en>
    ''' <fa>
    ''' مقدار دهی اولیه تمام خواص و ویژگی های تعریف شده برای کامپایلر
    ''' </fa>
    ''' </summary>
    ''' <param name="yoattr"></param>
    Public Shared Sub init(ByRef yoattr As yocaattribute.yoattribute)
        yoattr._cfg._cilinject = False
        yoattr._cfg._optimize_expression = True
        yoattr._cfg._disable_warnings = False

        yoattr._app._namespace = Nothing
        yoattr._app._classname = compdt.YOMAINCLASS
        yoattr._app._wait = False
        yoattr._app._issealed = False
    End Sub

    ''' <summary>
    ''' <en>
    ''' Reviewing and validating value of an attribute as Boolean datatype
	''' If validation failed, returned value will be FALSE
	''' In boolean datatype, 0 & 1 can also be used
    ''' </en>
    ''' <fa>
    ''' بررسی و اعتبارسنجی مقدار یک اتربیوت به عنوان داده بولی
    ''' در صورتی که اعتبارسنجی ناموفق بود مقدار برگشتی False است .
    ''' در مقادیر بولی 0 و 1 نیز می توان استفاده کرد.
    ''' </fa>
    ''' </summary>
    ''' <param name="yoattr"></param>
    ''' <param name="path"></param>
    ''' <returns></returns>
    Public Shared Function get_bool_val(yoattr As yocaattribute.resultattribute, path As String) As Boolean
        Dim expression As String = yoattr.valueattribute.ToLower
        If expression = "0" OrElse expression = "false" Then
            Return False
        ElseIf expression = "1" OrElse expression = "true" Then
            Return True
        Else
            'Set Error
            dserr.args.Add("constant typing")
            dserr.args.Add("bool")
            dserr.new_error(conserr.errortype.EXPLICITCONVERSION, attr.lastlinecinf.line, path, authfunc.get_line_error(path, attr.lastlinecinf, yoattr.valueattribute))
        End If

        Return False
    End Function

    ''' <summary>
    ''' <en>
    ''' Reviewing and validating value of an attribute as Integer
	''' If validation failed, returned value will be FALSE
    ''' </en>
    ''' <fa>
    ''' بررسی و اعتبارسنجی مقدار یک اتربیوت به عنوان رشته
    ''' در صورتی که اعتبارسنجی ناموفق بود مقدار برگشتی False است .
    ''' </fa>
    ''' </summary>
    ''' <param name="yoattr"></param>
    ''' <param name="path"></param>
    ''' <returns></returns>
    Public Shared Function get_str_val(yoattr As yocaattribute.resultattribute, path As String) As String
        Dim expression As String = yoattr.valueattribute
        If expression.StartsWith(conrex.COSTR) AndAlso expression.EndsWith(conrex.COSTR) Then
            authfunc.rem_fr_and_en(expression)
            Return expression
        ElseIf expression.StartsWith(conrex.DUSTR) AndAlso expression.EndsWith(conrex.DUSTR) Then
            authfunc.rem_fr_and_en(expression)
            Return expression
        Else
            'Set Error
            dserr.args.Add(expression)
            dserr.args.Add("str")
            dserr.new_error(conserr.errortype.EXPLICITCONVERSION, attr.lastlinecinf.line, path, authfunc.get_line_error(path, attr.lastlinecinf, yoattr.valueattribute))
        End If

        Return False
    End Function

End Class
