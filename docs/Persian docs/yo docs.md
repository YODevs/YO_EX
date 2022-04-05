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
 
 ### توابع برگشتی
 
  <div dir="ltr">

```f#
include 'ystdio'
func main()
{
 let result : i32 = sum(5,7)
 io::println("5 + 7 = #{result}")
}

func sum(a : i32 , b : i32) : i32
{
  return [a + b]
}
 ```
 </div>
 
  ### شروط اجرای تابع
  در صورتی که نیاز به بررسی پارامترها قبل از اجرای بدنه دارید ، می توانید از این دستور استفاده کنید.
  
  
<div dir="ltr">
 
```f#
func sum(...) : i32 ? (CONDITION)
{
 ...
}
 ```
 </div>
 
 برای نمونه در صورتی که مقدار پارامتر `number` عدد منفی باشد ، تابع اجرا نمی شود و مقدار `NULL` برگشت داده خواهد شد.
 
 <div dir="ltr">
 
```f#

func main()
{
    let fc : i32 = factorial(5)
    System.Console::WriteLine(fc)
    fc := factorial(-2)
    System.Console::WriteLine(fc)
}

func factorial(number:i32) : i32 ? (number >= 0)
{
  if(number == 0)
  {
    return 1
  }
  let result : i32 = number
  result *= factorial([number-1])
  return result
}
 ```
  
```
125
0
``` 
 </div>
 
  ### ارجاع از طریق منبع - pass by reference
  برای استفاده از خاصیت `byref` در توابع کافیست بعد از تایپ پارامتر از `&` استفاده کنیم.
 در مثال پایین مقادیر دو متغیر باهم جا به جا می شوند.
  <div dir="ltr">

```f#
include 'ystdio'
func main()
{
 let team1 , team2 : str
 team1 := "Chelsea"
 team2 := "Barcelona"
 io::println("Team1 : #{team1} Team2 : #{team2}")
 swap(team1,team2)
 io::println("Team1 : #{team1} Team2 : #{team2}")
}

func swap(val1 : str& , val2 : str&)
{
 let midval : str = val1
 val1 := val2
 val2 := midval
}
 ```
 </div>
 
 ### فرمت های داده
 
   <div dir="ltr">
    
| Type | Description | Range | Reference |
| ------ | ------ |------ |------ |
| **`i8`** |  8-bit signed integer   | -128 to 127 |  SByte |
| **`u8`** | 8-bit unsigned integer | 0 to 255 |  Byte  |
| **`i16`** |  16-bit signed integer  |  -32,768 to 32,767  | Int16|
| **`u16`** |  16-bit unsigned integer |  0 to 65,535  | UInt16|
| **`i32`** |  32-bit signed integer  | -2,147,483,648 to 2,147,483,647| Int32|
| **`u32`** | 32-bit unsigned integer|  0 to 4,294,967,295  | UInt32|
| **`i64`** |  64-bit signed integer | -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807  | Int64|
| **`u64`** | 64-bit unsigned integer|  	0 to 18,446,744,073,709,551,615 | UInt64|
| **`i128`** Soon|  128-bit signed integer  | (+ or -)1.0 x 10e-28 to 7.9 x 10e28 | Decimal|
| **`f32`** |  32-bit Single-precision floating point type  | -3.402823e38 to 3.402823e38 | Single|
| **`f64`** |  64-bit Double-precision floating point type  |  	-1.79769313486232e308 to 1.79769313486232e308 | Double|
| **`bool`** |  8-bit logical true/false value | True / False | Boolean |
| **`char`** | 16-bit single Unicode character  | * | Char|
| **`str`** |  A sequence of Unicode characters  | * | String |
| **`obj`** |  Base type of all other types.  | * | Object |
    
 </div>

### متغیرها - Variables
 دیتاتایپ های بخش قبل به عنوان `Primitive types` یا `Common data-types` شناخته می شوند.
 
 برای تعریف یک متغیر کافیست از فرم `let varname : vartype` استفاده کنید.
 
 
<div dir="ltr">

     
 ```f#
 let color : str = "Red"
 let age : i32 = 30
 let isset : bool = True
 const PI : f32 = 3.14
 ```
     


</div>

 
### تبدیل نوع متغیرها - Type Casting
یولنگ یک زبان `Static Type` و `Stronge Type` است ، که در آن امکان تبدیل خودکار یا ضمنی `implicit` وجود ندارد.
این خاصیت باعث می شود تا برنامه نویس از مقادیر انتساب داده شده به یک متغیر در هنگام فراخانی مطمئن باشد.
البته تبدیل نوع از روش صریح یا `explicit` وجود دارد.
<div dir="ltr">

 ```f#
 let i : i32 = 52
 let v : str = [str]v
 let f : f32
 f := [f32]i
 ```
     


</div>
  

###  رشته‌های فرمت دار شده - formatted string literals
رشته‌های فرمت دار یا به اختصار `f-string` در یولنگ  پشتیبانی می شود.
برای استفاده از این قابلیت کافیست مقادیر را مثل `"Hello #{name}"` تکمیل کنید.
 توجه کنید که کوتیشن از قابلیت پشتیبانی نمی کند.
<div dir="ltr">

 ```f#
include 'ystdio'
func main()
{
 let name : str
 let age : i32 = 30
 name := "Ruzes"
 io::print("My name is #{name} and im #{age} years old.")
}
 
```
 
```
 My name is Ruzes and im 30 years old.
``` 

 
Ascii code 
```f#
 io::print("My name is #[82]#[117]#[122]#[101]#[115]")
```
 
```
 My name is Ruzes
``` 
 
 
 
 New Feed / Line
```f#
 io::print("Hello World#nlWelcome to myapp.")
```
 
```
Hello World
Welcome to myapp.
 ``` 
</div>
 
 در مواقعی که نیاز به قابلیت `f-string` ندارید ، می توانید برای رشته‌ها از کوتیشن استفاده کنید ، این کار به صورت خیلی جزئی در زمان کامپایل ، صرفه جویی می کند.

 ### ساختار شرطی If-Else
ساختار شرطی If-Else همانند بقیه زبان‌های برنامه نویسی است.
<div dir="ltr">

 ```f#
 let i : i32 = 12
 if(i >> 0)
 {
   io::print("#{i} is positive.")
 }elseif(i << 0)
 {
   io::print("#{i} is negative.")
 }else {
   io::print("#{i} is zero.")
 }
 ```
     
 </div>
 
 ### دستور شرطی Match
ساختار این دستور شرطی همانند `Switch` در زبان C است.
 
<div dir="ltr">

 ```f#
func main()
{
  exec_logs("start")
  system.threading.thread::sleep(5000)
  exec_logs("stop")
}

func exec_logs(inf : str)
{
  match(inf)
  {
    case "start"  {
      io::println("Starting service...")
    }
    case "stop"  {
      io::println("Stopping service...")
    }
    default {
      io::println("Command Not Found")
    }
  }
}
 ```
 ```
Starting service...
Stopping service...
```
     

</div>
 
 
  ### حلقه بینهایت Loop
  یولنگ ، از حلقه‌های متفاوتی پشتیبانی کند ، حلقه بینهایت `loop` ساده ترین حلقه که بدون هیچگونه ساختار شرطی است.
  کنترل جریان برنامه در این حلقه با استفاده از دستورات `break` و `continue` انجام می گیرد.
 
 <div dir="ltr">

 ```f#
 let index : i32 = 0
 loop {
   index += 1
   if(index == 3) {continue loop}
   io::println("#{index}")
   if(index >= 5) {break loop}
 }
 ```
 
 ```
1
2
4
5
 ```
 </div>
 
 
   ### حلقه To
در مواردی می توانید حلقه `for` یا `while` را ساده‌تر بنویسید.
 در این حلقه کافیست تعداد گردش حلقه را مشخص کنید.
 این حلقه از ایندکس پشتیبانی نمی کند.
 <div dir="ltr">

 ```f#
 let i : i32 = 5
 to(i)
 {
   io::print("*")
 }
 ```
  
 ```
*****
 ```
 </div>
  
 در شکلی پیشرفته‌تر می توانید توان اعداد را با حلقه `to` محاسبه کنید.
  <div dir="ltr">

 ```f#
func pow(base : i32 , power : i32) : i32
{
  let result : i32 = base
  to(power)
  {
    result *= base
  }
  return result
}
   
 ```
 </div>
 

 ### حلقه While
 
 
 <div dir="ltr">

```f#
let index : i32 = 0
while(index <> 5 )
{
  index += 1
  if(index == 3)
  {
    continue while
  }
  system.console::writeline(index)
}
  
```
 
```
 1
 2
 4
 5
 ```
 </div>
  
   ### حلقه For
 حلقه `for` یکی دیگر از حلقه‌ها در یولنگ است.برای استفاده از این حلقه باید از `range`ها استفاده کنیم.
  برای مثال 
  
   <div dir="ltr">

  ```f#
    
  for(i in [0..5])
  {
    io::println("index => #{i}")
  }
    
  ```
    

   
  ```f#
    
index => 0
index => 1
index => 2
index => 3
index => 4
    
  ```
        
  </div>
  
   ### بازه‌ها - Range
  
    
  
در یولنگ بازه‌ها کاربردهای مهم دارند ، برای مثال شما با استفاده از یک بازه می توانید شرایط حلقه `for` را مشخص کنید.
    در پایین لیستی از مثال‌های `range`ها آمده است .
  
<div dir="ltr">

  ```f#
  [START..END;STEP]
  ```
 
  ```f#
  [0..5] => 0,1,2,3,4
  ```
 
  ```f#
  [0..=5] => 0,1,2,3,4,5
  ```
   
  ```f#
  [0..10;2] => 0,2,4,6,8
  ```
 
  ```f#
  [0..=10;2] => 0,2,4,6,8,10
  ```
 
  ```f#
  [10..2;-2] => 10,8,6,4,2
  [10..=2;-2] => 10,8,6,4,2
  ```
  </div>
  
  
   
   ### پرش در کدها - Jmp
  
  دستور `jmp` در زبان‌های دیگر با نام‌هایی مثل `goto` شناخته می شود.
  برای مشخص کردن نقطه مقصد پرش کافیست یک برچسب یا `label` بسازید ، برای ساخت برچسب باید به فرمت `:LABELNAME$` عمل کنید.
<div dir="ltr">

 
  ```f#
 
  $startprocess:
  let user , password : str
  io::setin(user,"User : ")
  io::setin(password,"Password : ")
  if(user == "admin" && password == "12345")
  {
    io::println("You have logged in successfully.")
    jmp $endprocess
  }else
  {
    io::println("Input information is incorrect.")
    jmp $startprocess
  }
  $endprocess:
 
  ```
 
  </div>
  
  
  ### فرمت ساختاری یودا - YODA
  
  یودا یا YO Data Format یک ساختار داده است ، که در کلاس‌های یولنگ مثل `list` , `map` , `rds` , `menu` , ... استفاده می شود.
  
  #### ساختار لیستی یودا
  <div dir="ltr">

  ```f#
  !["item1","item2","item3","item4"]

  ```
 
  </div>
  
  #### ساختار مپ یا key-value
  <div dir="ltr">

  ```f#
  !![
    "key1" = "value1" , 
    "key2" = "value2" , 
    "key3" = "value3" , 
    "key4" = "value4"  ]

  ```
 
  </div>
  
  برای تولید ساختارهای داده فوق می توانید از کلاس `yolib.yoda` استفاده کنید.
  بنابراین برای استفاده از فرمت YODA ابتدا باید کتابخانه استاندارد `yolib` را فراخانی کنید.
  

<div dir="ltr">

 
```f#
include 'ystdio'
include 'yolib'
func main()
{
  let mydata : init yolib.yoda()
  mydata::compress := true
  for(i in [0..10])
  {
    let result : i32 = [i * 5]
    mydata::add("#{result}")
  }
  let getformat : str = mydata::get_list()
  io::println(getformat)
}

  ```
     
 ```
!["0","5","10","15","20","25","30","35","40","45"]
 ```
 
 
 
 ```f#
include 'ystdio'
include 'yolib'
func main()
{
  let mydata : init yolib.yoda()
  mydata::add("Chelsea","England")
  mydata::add("Bayern Munich","Germany")
  mydata::add("Manchester City","England")
  mydata::add("Paris Saint-Germain","France")
  let getformat : str = mydata::get_map()
  io::println(getformat)
}

  ```
     
 ```
!![
"Chelsea"   =   "England"   ,
"Bayern Munich"   =   "Germany"   ,
"Manchester City"   =   "England"   ,
"Paris Saint-Germain"   =   "France"
]
 ```
  </div>
 
  
   
 ### لیست ها - داده های تک بعدی
 کلاس `list` در کتابخانه استاندارد `yolib` است که برای لیست های تک بعدی استفاده می شود.
همچنین این کلاس می تواند از داده های خود خروجی یا ورودی های به فرمت `yoda` بگیرد.
 
 
 
 
 
<div dir="ltr">

 
```f#
include 'ystdio'
include 'yolib'
func main()
{
 let list : init yolib.list()
 list::add("Item 1")
 list::add_with_split("Item 2#Item 3#Item 4","#")
 list::append("Item 0") #> Add to the first list
 let countoflist : i32 = list::count()
 for(i in [0..countoflist])
 {
   let foo : str = list::get(i)
   io::println(foo)
 }
}
  ```
     
 ```
Item 0
Item 1
Item 2
Item 3
Item 4
 ```
  </div>
  
  ### مپ ها
کلاس `map` یک ساختار **`key-value`** است ، که در بسیاری از زبان ها با نام های دیگری مانند `hashmap` ، `dictionary` شناخته می شود.
برای مثال یک map ایجاد می کنیم که مقادیر `key` آن اسامی ماشین ها و مقادیر آن کشورهای سازنده آن باشد.
  
<div dir="ltr">

 
```f#
  let map : init YOLib.map()
  map::add('Ford Torino','UK')
  map::add('Toyota Corolla Mark ii','Japan')
  map::add('Audi 100 LS','Europe')
  map::add('Mercedes-Benz 280s','Europe')
  map::add('Ford Thunderbird','US')

  let count : i32 = map::size()
  for(index in [0..count])
  {
    let getcar , getorigin : str
    map::get_map(index, getcar,getorigin)
    io::println("Car : #{getcar} , Origin : #{getorigin}")
  }
  ```
     
 ```
Car : Ford Torino , Origin : UK
Car : Toyota Corolla Mark ii , Origin : Japan
Car : Audi 100 LS , Origin : Europe
Car : Mercedes-Benz 280s , Origin : Europe
Car : Ford Thunderbird , Origin : US
 ```
  </div>  
  همچنین می توان یک key را جستجو کنید و value را بگیرید.
  <div dir="ltr">

 
```f#
  let getorigin : str = [str]map::get("Audi 100 LS")
  io::print(getorigin)
  ```
     
 ```
Europe
 ```
  </div>  
  
  
  ### تکرارگر - Iterator
  با کلاس `iterator` امکان پیمایش مقادیر کلاس هایی مانند `list` ، `map` را دارید ؛ این کلاس از 4 متد ساده برای پیمایش مقادیر استفاده می کند.
  
  
<div dir="ltr">

 
```f#
  let carbrands : init yolib.list()
  carbrands::add_with_split('Nissan@Opel@Lexus@Kia@Honda@Jaguar@Hummer','@')
  let iter : init yolib.iterator(carbrands)
  let hasnext : bool = iter::has_next()
  while(hasnext == true)
  {
    let item : str = iter::next()
    io::println(item)
    hasnext := iter::has_next()
  }
  ```
     
 ```
Nissan
Opel
Lexus
Kia
Honda
Jaguar
Hummer
 ```
  </div> 
  
  برای پیمایش مقادیر قبلی از متد `previous` استفاده می شود.
  
  همچنین می توان با تغییر پروپرتی `index` به صورت دستی شماره فعلی پیمایش را تغییر داد.

  
 ### ذخیره داده پویا - rds
  کلاس `rds` در `yolib` به منظور ایجاد یک **`run-time datastore`** در نرم افزار است ، ساختار آن همانند دیتابیس های رابطه ای است که ستون و ردیف دارد.
  
  این کلاس از کوئری به صورت `objective` نیز پشتیبانی می کند.
  
  
  
  <div dir="ltr">

 
```f#
include 'yolib'
include 'ystdio'

func main()
{
  let db : init yolib.rds()
  db::set_columns("!['id','name','score']")
  let students : init yolib.map()
  students::add("Ana","70")
  students::add("Charlie","80")
  students::add("John","95")
  let size : i32 = students::size()
  let name, score: str
  for(index in [0..size])
  {
    students::get_map(index,name,score)
    db::insert("!['#{index}','#{name}','#{score}']"))
  }
  db::update(1,"score","55")
  io::println("Number of students: #{size} people")
  let list : init yolib.list()
  for(index in [0..size])
  {
    let row : str = db::get_row(index)
    list::set(row)
    name := list::get(1)
    score := list::get(2)
    io::println("#{index}- #{name} -> #{score}")
  }
}
  ```
     
 ```
Number of students: 3 people
0- Ana -> 70
1- Charlie -> 55
2- John -> 95
 ```
  </div> 
  
  
### ماتریس ها
  
  ماتریس - `matrix` یکی از پرکاربردترین ساختارها در ریاضی ، علوم داده ، مخابرات ، هوش مصنوعی و ... است. در کتابخانه استاندارد یولنگ کلاس ماتریس وجود دارد ، که محاسبات را بسیار ساده و سرعت توسعه را افزایش می دهد.
این کلاس از ماتریس هایی مانند `unit_matrix` , `zero_matrix`  , `scalar_matrix` و ... پشتیبانی می کند و توابعی برای چهار عمل اصلی ، ماتریس ترانهاده ، ماتریس منفی و ... را داراست.
 
  
<div dir="ltr"> 
 
 
 ```f#
public static let index : i32 = 1
public static let mt : yolib.matrix

func initialize()
{
  mt := init yolib.matrix(3,3)
  mt::set_zero_matrix()
  print_matrix('Zero matrix',mt)
  mt::set_item(0,0,1) #>*Notice : set_item(Column,Row,Value)
  mt::set_item(1,0,2)
  mt::set_item(2,0,3)
  mt::set_item(0,1,4)
  mt::set_item(1,1,5)
  mt::set_item(2,1,6)
  mt::set_item(0,2,7)
  mt::set_item(1,2,8)
  mt::set_item(2,2,9)
  print_matrix('Primary matrix',mt)
}

func main()
{
  initialize()
  let tranmatrix : yolib.matrix = mt::transpose()
  print_matrix('Transpose matrix',tranmatrix)

  let negmatrix : yolib.matrix = mt::neg()
  print_matrix('Negative matrix',negmatrix)

  mt := mt::multiply(3)
  print_matrix('Multiply scalar matrix',mt)
}

func print_matrix(title : str ,matrix : yolib.matrix)
{
  let matrixframe : str = matrix::get_matrix()
  io::println("#{index}-#{title} #nl#{matrixframe}")
  io::newline()
  index += 1
}
  ```
     
 ```
1-Zero matrix
0  0  0
0  0  0
0  0  0

2-Primary matrix
1  2  3
4  5  6
7  8  9

3-Transpose matrix
1  4  7
2  5  8
3  6  9

4-Negative matrix
-1  -2  -3
-4  -5  -6
-7  -8  -9

5-Multiply scalar matrix
3   6   9
12  15  18
21  24  27

 ```
  </div>  
  
  
  ### مقادیر جداشده با ویرگول - CSV
  
  کلاس `csv` برای کار با فایل ها و دیتاست های csv است ، امکان نوشتن و خواندن آن ها را دارد.
 این کلاس براساس کلاس `rds` است ، بنابراین امکان ارسال کوئری های شی گرایی را دارد و می توان دسترسی کامل به مواردی مانند بروزرسانی داده ها ، دسته بندی آن ، جستجو بین داده ها و ... داشت.
  
  در صورتی که فایل csv از یک `delimiter` غیر از ویرگول برای جدا سازی استفاده کرده باشد ، مقدار delimiter را تغییر دهید.
  
  
  
<div dir="ltr">

 
```f#
 let csv : init yolib.csv()
 csv::delimiter := ";"
 csv::load_file('D:\...\...\data.csv')
 let val : str = csv::get(5,2)
 io::print(val)
  ```
     
 ```
Charlie
 ```
  </div> 
  
با اورلود(`overload`) دیگر متد `get` می توان کل ردیف را درون یک ارایه از جنس `str` گرفت. 
  
  
  ### چارچوب داده - Dataframe
  
  برای نمایش داده های یک ساختار می توان از کلاس `dataframe` استفاده کرد ، در یولنگ برخلاف دیگر زبان ها همانند R و Python دیتافریم را در محیط `Console` چاپ نمی کند بلکه در یک محیط گرافیکی با قابلیت عملیات `sort` و تغییر فونت پیشفرض یا گرفتن خروجی از داده ها را دارد.
  
  کلاس `dataframe` در یولنگ از دیگر کلاس های استاندارد مانند `rds` , `csv` , `map` , `list` نیز پشتیبانی می کند.
  
<div dir="ltr">

 
```f#
 let csv : init yolib.csv()
 csv::delimiter := ";"
 csv::load_file('D:\YO Workout directory\...\cars.csv')
 let df : init YOLIB.dataframe()
 df::show(csv)
  ```

  
<p>
    <img src="https://raw.githubusercontent.com/YODevs/YO/master/docs/dataframe.png?sanitize=true">
</p>
  
 </div>  
  
  
  ### نمودار ها
  
در یولنگ با استفاده از کلاس `chart` می توان به راحتی به بیش از 20 نوع نمودار از جمله
  pie,column,pyramid,funnel,point,line,spline,bar,area و ... دسترسی داشته باشید.

 
  <div dir="ltr">

 
```f#
include 'yolib'
func main()
{
  let dt : init yolib.chart()
  let xpoint : init yolib.list("1,2,3,4,5,6",",")
  let ypoint : init yolib.list("64.02,12.55,8.47,6.08,4.29,4.29",",")
  let labels : init yolib.list("Chrome,Firefox,IE,Safari,Edge,Other",",")
  dt::formtitle := "Usage Share of Desktop Browsers"
  dt::new_series("browser" , 'pie')
  dt::enable3d := true
  dt::add_point('browser',xpoint,ypoint)
  dt::set_asix_label('browser',labels)
  dt::show()
}
  ```

  
<p>
    <img src="https://raw.githubusercontent.com/YODevs/YO/master/docs/pie-chart.png?sanitize=true">
</p>
   
 </div>  
  
  ### منوها
  
  کلاس `menu` ، یک لیست قابل انتخاب از آیتم ها درون کنسول نمایش می دهد (همانند ایجاد پروژه جدید در لابرا).
  
  <div dir="ltr">

 
```f#
include 'ystdio'
include 'yolib'
func main()
{
  let items : init yolib.list('Item1,Item2,Item3,Item4',',')
  io::print("Select an item:")
  let result : str =  yolib.menu::show_menu(items)
  io::newline()
  io::print("#{result} was selected.")
}
  ```
     
 ```
Select an item:
Item1
Item2
->Item3
Item4

Item3 was selected.
 ```
  </div> 
  
  
  ### نوار پیشرفت - Progressbar
  
  کلاس `progressbar` همانند `menu` فقط در کنسول قابل استفاده است ، در محیط های گرافیکی می توان از پروگرس بار های مستقل استفاده کرد.

  این پروگرس بار قابلیت پیمایش معکوس و تغییر نوع را با استفاده از فیلد `progresschar` را دارد.
  
  
 
<div dir="ltr">

 
```f#
  let rnd : init System.Random()
  let ms : i32 = 0
  let progress : init YOLIB.progressbar()
  progress::show_progress()
  to(100)
  {
    progress::increase()
    ms := rnd::next(1,100) #> Random interval
    System.Threading.Thread::sleep(ms)
  }
  to(100)
  {
    progress::decrease()
    ms := rnd::next(1,100) #> Random interval
    System.Threading.Thread::sleep(ms)
  }
  progress::hide_progress()
  ```
     
 ```
[==============================--------------------]- 59%
 ```
  </div> 
  
### تعامل با کاربر
  
  برای نمایش `dialogbox` هایی مانند MessageBox یا InputBox می توان از کلاس `interaction` استفاده کرد.

  
 <div dir="ltr">

 
```f#
  let name : str = yolib.interaction::inputbox('Information','Enter your name:')
  yolib.interaction::messagebox('Information',"Your name is #{name}")
  ```

  </div> 
  
  
  ### تاریخ و زمان
  
  کلاس `date` یک کلاس از زیر مجموعه `yolib` است ، که بر پایه `System.DateTime` است و فقط از زمان حال پشتیبانی می کند.
برای کار با زمان در آینده یا گذشته می توانید از کلاس اصلی استفاده کنید.
  
 | کد اختصار | مقدار زمانی | کد اختصار | مقدار زمانی | کد اختصار | مقدار زمانی |
|:-:|:-:|:-:|---|---|---|
| **Y** | سال | **M** | ماه |  **D** | روز  | 
| **h** | ساعت | **m** | دقیقه |  **s** | ثانیه  |
| **t** | میلی ثانیه | **DY** | شماره روز در سال |  **DW** | شماره روز در هفته  |


  
  
 <div dir="ltr">

 
```f#
  let currenttime : str = yolib.date::get_now("{Y}/{M}/{D} - {h}:{m}:{s}")
  io::println(currenttime)
  ```
     
 ```
2022/3/22 - 19:25:47
 ```

  </div>
  
  
  ### کار با Environment
  
  این کلاس بر پایه `system.environment` است و توابعی مثل دریافت آرگومان های ورودی نرم افزار ، دریافت و ایجاد متغیرهای سیستمی ، دریافت دایرکتوری نرم افزار و پروسه و ... را شامل می شود.
برای مثال در کد زیر `CommandLineArg` ها را از پروسه دریافت می کنیم.
  
  
<div dir="ltr">

 
```f#
func main()
{
  let arglen : i32 = yolib.environment::arglen
  if(arglen >> 1)
  {
    for(index in [1..arglen])
    {
      let param : str = yolib.environment::get_arg(index)
      io::println("#{index} -> #{param}")
    }
  }else{
    io::print("There are no parameters.")
  }
}
  ```
     
 ```
D:\...\...>"D:\...\...\release\environment_sample.exe" --log=ON --ignoreerror=On --executefile=Off

1 -> --log=ON
2 -> --ignoreerror=On
3 -> --executefile=Off
 ```

  </div>

 ### رمزگذاری - encoding
  
  این کلاس ، wrapper شده ، کلاس `System.Text.Encoding` است ، که جهت سهولت استفاده در یولنگ ایجاد شده است.
 
<div dir="ltr">

 
```f#
func main()
{
  let unicodestr : str = "Hello World ! ψ"
  let unicodebyte[] : u8 = yolib.encoding::unicode_get_bytes(unicodestr)
  let output : str = yolib.encoding::unicode_get_string(unicodebyte)
  System.IO.File::writealltext("D:\...\t.txt",output)
}
  ```
     
 ```
Hello World ! Ïˆ
 ```

  </div>
  
  
  ### فونت
  
  کلاس فونت برای استایل دهی به متون در محیط gui ، همانند کلاس های `dataframe` , `chart` استفاده می شود.

  <div dir="ltr">

 
```f#
let csv : init yolib.csv()
csv::load_file('C:\...\a.csv')
let df : init yolib.dataframe()
let font : init yolib.font('consolas',10,'bold')
df::font := font
df::show(csv)
  ```

  </div>
  
[rellink]: <https://github.com/YODevs/YO/releases>
