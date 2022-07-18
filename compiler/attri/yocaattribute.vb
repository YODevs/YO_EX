''' <summary>
''' <en>
''' Structures of attributes and their features will be in this class
''' </en>
''' <fa>
''' ساختمان و استراکچرهای مربوط به اتربیوت ها و  خواص آن ها در این کلاس جای میگیرند
''' </fa>
''' </summary>
Public Class yocaattribute
    ''' <summary>
    ''' Configure options for compiler.
    ''' </summary>
    Structure cfg
        'EN : Allows injecting Microsoft CIL codes into YOLang codes
        'FA : اجازه تزریق کد های میانی مایکروسافت در کد های یولنگ را میدهد
        Dim _cilinject As Boolean

        'EN : Improving mathematical expressions and  equations while compiling
        'FA : بهینه سازی عبارات و معادلات ریاضی حین کامپایل
        Dim _optimize_expression As Boolean

        'EN : Disabling all of the warnings while compiling
        'FA : غیرفعال سازی همه هشدارهای حین کامپایل
        Dim _disable_warnings As Boolean

        'EN : Enable or disable cache in this file 
        'FA : فعال سازی یا غیرفعال سازی کش در این فایل
        Dim _no_cache As Boolean

        'FA: مقدار حساسیت به اعشار
        Dim _decimal_accuracy As Integer

        'FA: حالت ایمنی در برابر نال
        Dim _null_safety As Boolean
    End Structure

    Structure app
        'EN : tp specify Namespace of a class
        'FA : مشخص کردن Namespace یک کلاس
        Dim _namespace As String

        'EN : to specify name of a class
        'FA : برای تعیین نام یک کلاس
        Dim _classname As String

        'EN : In case of assignment, application at its latst process will wait for user to hit ENTER then it will be closed
        'FA : در صورت مقداردهی ، نرم افزار در آخر پروسه خود منتظر یک اینتر از سوی کاربر می ماند و سپس بسته می شود
        Dim _wait As Boolean

        'EN : With this feature a class can be sealed. In other words, it won't be printed
        'FA : با این خاصیت می توان یک کلاس را مهر و موم یا به اصطلاح از پرنت شدن آن جلوگیری کنیم
        Dim _issealed As Boolean

        'FA : سربرگ پیشفرض نرم افزار
        Dim _title As String
    End Structure

    ''' <summary>
    ''' <en>
    ''' cfg:
	''' its subset as features which while compiling will help compiler to customize the applicaiton according to programmer's desire
	''' app:
	''' This feature, will deal with application's features such as class
    ''' </en>
    ''' 
    ''' <fa>
    ''' cfg :
    ''' زیر مجموعه آن به عنوان خاصیت هایی که حین کامپایل به کامپایلر کمک می کند تا طبق نظر برنامه نویس ، برنامه را سفارشی سازی کند.
    ''' app :
    ''' این خاصیت ، به ویژگی های نرم افزار همانند نام کلاس می پردازد.
    ''' </fa>
    ''' </summary>
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
