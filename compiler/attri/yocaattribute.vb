''' <summary>
''' <en>
''' 
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
        'EN : 
        'FA : اجازه تزریق کد های میانی مایکروسافت در کد های یولنگ را میدهد
        Dim _cilinject As Boolean

        'EN : 
        'FA : بهینه سازی عبارات و معادلات ریاضی حین کامپایل
        Dim _optimize_expression As Boolean

        'EN : 
        'FA : غیرفعال سازی همه هشدارهای حین کامپایل
        Dim _disable_warnings As Boolean
    End Structure

    Structure app
        'EN : 
        'FA : مشخص کردن Namespace یک کلاس
        Dim _namespace As String

        'EN : 
        'FA : برای تعیین نام یک کلاس
        Dim _classname As String

        'EN : 
        'FA : در صورت مقداردهی ، نرم افزار در آخر پروسه خود منتظر یک اینتر از سوی کاربر می ماند و سپس بسته می شود
        Dim _wait As Boolean

        'EN : 
        'FA : با این خاصیت می توان یک کلاس را مهر و موم یا به اصطلاح از پرنت شدن آن جلوگیری کنیم
        Dim _issealed As Boolean
    End Structure

    ''' <summary>
    ''' <en>
    ''' 
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
