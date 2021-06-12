 <div dir="auto">

# مستندات یولنگ

## مقدمه

**یولنگ** یک زبان کامپایلری و اوپن سورس برپایه دات نت کور و دات نت فریمورک است.

سینتکس YO به زبان هایی مانند Rust , Go و C شبیه است ، یولنگ همچنین یک زبان **High-Level** محسوب می شود اما در طراحی آن سعی شده تا بعضی از خواص زبان‌های سطح پایین تر را در خود حفظ کند.


## نصب کامپایلر و ابزار
برای نصب آخرین نسخه یولنگ ابتد 
[**اینجا**][rellink] کلیک کنید یا در ریپازیتوری یولنگ به قسمت **Releases** مراجعه کنید.

پیشنیاز اجرای کامپایلر یولنگ DotNetFramework 4.5 است.

پس از دانلود فایل فشرده شده ، آن را اکسترکت کنید و سپس فایل اجرایی (PE) کامپایلر با نام `YOCA.exe` در مسیر اصلی فایل های اکستراکت شده را اجرا کنید ، بعد از باز شدن محیط کنسول دستور `init` برای آماده سازی و مقداردهی های اولیه وارد کنید.

**تبریک میگیم ! الان کامپایلر یولنگ آماده برای توسعه نرم افزارهای شماست**
 
 ## ساخت اولین پروژه
 کامپایلر YO از ساختار متفاوتی در پروژه‌ها پشتیبانی می کند، که این ساختار را می توان با نرم افزار **LABRA** ایجاد کرد.
 
 **لابرا**(Labra) یک مدیریت پروژه(Project Manager) اختصاصی یولنگ است ، که در ایجاد انواع ساختارهای پروژه یولنگ و تغییرات تنظیمات آن به توسعه دهنده کمک می کند.
 
 برای ایجاد اولین پروژه یولنگ کافیست دستور `labra new` را در CMD یا Powershell وارد کنید.
 <p>
    <img src="https://raw.githubusercontent.com/YODevs/YO/master/docs/labra1.png?sanitize=true">
</p>
 
 
 **توجه !!!! برای ایجاد پروژه در مسیر دلخواه حتما باید خط فرمان در آن مسیر باشد ، در غیر این صورت مانند تصویر از دستور `cd` استفاده کنید.**
 
 بعد از انتخاب نام پروژه باید نوع پروژه را مشخص کنید.
برای مثال می توان از منو گزینه `Console` را انتخاب کرد تا یک پروژه کنسول را بسازد.
 
 حالا می توانید به پوشه پروژه ساخته شده و زیر شاخه `src` بروید و فایل main.yo را به عنوان یک فایل یولنگ ادیت کنید 
<div dir="ltr">
 
```f#
#[app::classname("myfirstapp")]
include 'ystdio'
func main()
{
 io::print('Hello World!')
}
```
 
 </div>
 
 سپس برای کامپایل پروژه کافیست از مسیر اصلی پروژه CMD یا Powershell را باز کنید و دستور زیر را وارد کنید :
 - **کامپایل پروژه**
 
 <div dir="ltr">
 
 ```bat
yoca build
```
 </div>
 
 - **کامپایل + اجرا**

 <div dir="ltr">
 
 ```bat
yoca run
```
  
 </div>
 
 برای نمونه مانند تصویر زیر صورت می گیرد :
 
<img src="https://raw.githubusercontent.com/YODevs/YO/master/icons/compile-project.gif">

 > خروجی های کامپایل شده در مسیر `target>debug|release` تولید می شوند.
 
 ## ساختار پروژه در یولنگ
 | نام پوشه/فایل | توضیح |
| ------ | ------  |
| **`assets`** | تمامی کتابخانه‌ها و فایل‌های مربوط به پروژه در این مسیر قرار می گیرند. |
| **`src`** | فایل‌های بدنه پروژه که عموما به فرمت `yo.` هستند ، در این پوشه قرار می گیرند. |
| **`target`** | خروجی‌های کامپایل شده در این  پوشه و زیر مجموعه `release` یا `debug` ذخیره می کند. |
| **`labra.yoda`** | تنظیمات عمومی پروژه و اطلاعات کلی در مورد پروژه را به کامپایلر معرفی می کند. |

 ## کامنت ها و توضیحات

 
 <div dir="ltr">
  
```
#> This is a single-line comment.
  
#-
This is a multi-line comment.
...
...
-#
  
```
 </div>
 
 ## توابع
  
   <div dir="ltr">

 ```f#
#[app::classname("function_sample")]
#[app::wait(true)]

include "ystdio"
func main()
{
 say_hello()
 io::newline()
 add(7,4)
}

func say_hello()
{
 io::print("Welcome to myapp .")
}

func add(a : i32 , b : i32)
{
  let c : i32 = [a + b]
  io::println("#{a} + #{b} = #{c} ")
}
```
    
  </div>
 
  توابع در یولنگ ، می توانند به صورت `overloading` نیز نوشته شود.
   
   <div dir="ltr">

 ```f#
func main()
{
 let result : i32 = 0
 result := pow(5)
 system.console::writeline(result)
 result := pow(5,3)
 system.console::writeline(result)
}

func pow(base : i32) : i32
{
  return [base * base]
}

func pow(base : i32 , power : i32) : i32
{
  let result : i32 = 1
  to(power)
  {
    result *= base
  }
  return result
}

```
    
  </div>
 
</div>

  

[rellink]: <https://github.com/YODevs/YO/releases>
