# YO Lang Documentation

## Introduction

YOLang is a compiled and open source language based on .NET Core and .NET Framework.

The YO's syntax is similar to languages such as Rust, Go, and C; and YOlang is also a High-Level language, but its design seeks to retain some of the properties of low-level languages.

## Installing the compiler and tools

[Click here](https://github.com/YODevs/YO/releases) to install the latest version of the YOLang, or check the Releases section in the YOLang repository.
DotNetFramework 4.5 is a Prerequisite for running the YOLang's compiler.
After downloading the compressed file, extract it and then run the compiler's executable file (PE) called YOCA.exe in the main path of the extracted files, after opening the console environment, Enter init command for preparation and initialization.

Congratulations! Now YOLang's compiler is ready for developing your softwares.

## Building the first project:

The YO's compiler supports various structures in projects, which can be created with **LABRA** software.

Labra is a proprietary project manager for YOLang, which helps the developer to create a variety of YOLang project structures and change their configuration.

[![BuildingYOProject](https://raw.githubusercontent.com/YODevs/YO/master/docs/labra1.png?sanitize=true)](.)

**Note:
To create a project in the desired path, the command line must be in that path, otherwise use the `cd` command as shown above.**

After choosing the project's name, you must specify the project's type. For example, you can select the `Console` option from the menu to create a console project.

You can now go to the created project folder under the `src` directory and edit the main.yo file as a YOLang file.

```f#
#[app::classname("myfirstapp")]
include 'ystdio'
func main()
{
 io::print('Hello World!')
}
```

Then for compiling the project, open `CMD` or `Powershell` from the main directory and use below command:

- **Compiling Project**

```bat
yoca build
```

- **Compile + Execution**

```bat
yoca run
```

Outcome, for example, shall be as below:

[![CompilingYOProject](https://raw.githubusercontent.com/YODevs/YO/master/icons/compile-project.gif)](.)

> Compiled outputs will be generated in this path: `target> debug | release`.

## Project's structure in YOLang:

| Folder/file name | description                                                                        |
| ---------------- | ---------------------------------------------------------------------------------- |
| **`assets`**     | All libraries and files related to the project are located in this folder.         |
| **`src`**        | Project's body files, usually in `.yo` format, are located in this folder.         |
| **`target`**     | Saves the compiled output(s) ‌in this folder as subset of the `Release` or `Debug` |
| **`labra.yoda`** | Introduces general settings and total information of the project to the compiler.  |

## Comments and explanations:

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

## Functions:

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

Functions in YOLang can also be programmed as `overloading`.

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

### Return functions:

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


  ### Required condition function

  If you need to check parameters before executing the body, you can use the following command:
  
<div dir="ltr">
 
```f#
func sum(...) : i32 ? (CONDITION)
{
 ...
}
 ```
 </div>
 
For example ,if parameter value of `number` was negative, function does not run and `NULL` value will be returned. 
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

### Pass by reference:

To use the `byref` property in functions, just use `"&"` after typing the parameter. In the example below, the values of the two variables are swapped together.

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

### Data formats:

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

### Variables:

The datatypes of the previous section are known as `Primitive types` or `Common data-types`.

To define a variable, just use the form `let varname: vartype`.

<div dir="ltr">

```f#
let color : str = "Red"
let age : i32 = 30
let isset : bool = True
const PI : f32 = 3.14
```

</div>

### Type Casting:

YOLang is a `Static Type` and `Stronge Type` language, in which it is not possible to convert `implicitly` (implicit automatically). This feature allows the programmer to be sure of the values assigned to a variable while calling it، though a kind of explicity or `explicit` method conversion is available.

<div dir="ltr">

```f#
let i : i32 = 52
let v : str = [str]v
let f : f32
f := [f32]i
```

</div>

### Formatted string literals:

Formatted string literals or `f-strings` for short, are supported in the YOLang. To use this feature, just fill in the values like `"Hello # {name}"`. Note that the quotation does not support the feature.

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
 
When you do not need the `f-string` feature, you can use quotation marks for strings, which saves very partial time of compilation.

### If-Else conditional structure:

The conditional structure of If-Else is the same as for other programming languages.

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

### Match conditional statement:

The structure of this conditional statement is the same as `Switch` in C programming language.

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

### Infinite Loop:

YOLang supports different types of loops; The infinite `loop` is the simplest loop that does not contain any conditional structure. In this loop, program's flow control can be done by using the `break` and `continue` commands.

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

### To loop:

In some cases you can code the `For` or `While` loops more easily. In this loop, it is enough to specify the number of circlutation times of the loop. This loop does not support the index.

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
  
In a more advanced way, you can calculate the power of numbers with the `To` loop.
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

### While loop:

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

### For loop:

The `For` loop is another loop in the YOLang. To use this loop, you must use `ranges`.
For instance:

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

 
 
### Foreach loop:

Unlike other languages, the structure of this loop is written with the `for` statement. This loop is used for circulation and repetition between collections and arrays.

   <div dir="ltr">

```f#

let colors[] : str = {'Red','Green','Blue','Black','White','Yellow'}
for(color in colors)
{
  io::println(color)
}

```

```f#

Red
Green
Blue
Black
White
Yellow

```

    
  </div>
 
### Ranges:

In YOLang, Ranges have important usages; for example, you can specify the conditions of a `For` loop by using a range.
 
 Below review a list of examples of `ranges`:

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

### Jump through codes:

The `jmp` statement is known in other languages by names like `goto`. To specify the destination point of the jump, just create a `label`. For creating it, you must use the format: `$LABELNAME` :

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

 
   
 ### Branching - Multi-thread
  
Branching is the easiest way to create multi-thread software. Using this command, by creating a branch, one can execute a method as a thread.
It does not support return type, and functions for this call must not have parameters.
  
  ```f#
 
 func main()
{
  io::println("Start Process ...")
  br method1()
  br method2()
  io::println("End ...")
}

func method2()
{
  to(10)
  {
    io::println("Hello")
    io::sleep(5)
  }
}

func method1()
{
  to(10)
  {
    io::println("Bye")
    io::sleep(5)
  }
}
 
  ```
 
 
 ```
Start Process ...
End ...
Bye
Hello
Bye
Hello
Hello
Bye
Bye
Hello
Hello
Bye
Hello
Bye
Bye
Hello
Hello
Bye
Bye
Hello
Hello
Bye
 ```
 
 
### YODA data format:

YODA or YO Data Format is a data structure which is used in YOLang's classes such as `list`, `map`, `rds`, `menu`, `etc`.

#### YODA list structure:

  <div dir="ltr">

```f#
!["item1","item2","item3","item4"]

```

  </div>

#### Map structure or Key-Value:

  <div dir="ltr">

```f#
!![
  "key1" = "value1" ,
  "key2" = "value2" ,
  "key3" = "value3" ,
  "key4" = "value4"  ]

```

  </div>
  
  You can use the `yolib.yoda` class to generate the above mentioned data structures. So to use the YODA format, you must first call the `yolib` standard library.

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
  
### Lists - One-Dimensional Data
 The `list` class in the `yolib` standard library is used for one-dimesional data.
 
 This class also can import or export its data in`yoda` format.
 
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
   
### Maps
 The `map` class is a **`key-value`** structure which in lots of languages is knows by other names such as `dictionary` or `hashmap`. 
 
 For instance, we create a map which its `key` values include cars' names and its values include manufacturing countries:
  
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
  
 We also can search a key and get the value.
 
  <div dir="ltr">

 
```f#
  let getorigin : str = [str]map::get("Audi 100 LS")
  io::print(getorigin)
  ```
     
 ```
Europe
 ```
  </div>  
  
     
### Iterator
 With `iterator` class we are allowed to iterate the values of calsses like `map` or `list`.
 
 This class uses 4 simple methods for iterating the values.
  
  
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
  
  For iterating previous values, the `previous` method is usable.
  We also can change current iteration number manually by changing the `index` property.
 
  ### RDS (Run-time Datastore)
 The `rds` class in `yolib` is for creating a **`run-time datastore`** in the application. Its structure is similar to relational databases which have rows and columns.
 
 This class also supports a query in the form of `objective`.
  
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
   
  ### Matrix
 The `matrix` class is one of the most used structures in math, data science, telecommunication, AI and etc. The matrix class exists in the YOLANG's standard library which simplifies the calculations and increases the development speed.
 
 This class supports matrixes such as `scalar_matrxi`, `zero_matrix`, `unit_matrix`, etc. And includes functions for four main mathematical operations (Addition/Subtraction/Multiplication/Division), Transpose of Matrix, Negative Matrix, etc.
  
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
  
   
  ### CSV (Comma-Separated Values)
 The `csv` class is used for working with CSV files and datasets, that can write and read them.
 
 This class is based on `rds` class, so it can send object-oriented queries and can have full access to items like updating data, categorizing data, searching through data and so on.
 
 If the CSV file uses a `delimiter` other than a comma to separate, change the delimiter value.
  
  
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
  
Another `overload` of the `get` method can obtain whole of the row as `str` from inside of the array.  
 
    
  ### Dataframes
 The `dataframe` class is usable for illustrating a structure's data. The YOLANG unlike the other languages such as R and Python, does not print the dataframe in a `Console` environment but also does in a graphical environment with some abilities like `sort` operation, changing default font, or exporting the data.
 
 The `dataframe` class in YOLANG also supports other standard classes such as `list`, `map`, `csv`, `rds`, etc.
  
<div dir="ltr">

 
```f#
 let csv : init yolib.csv()
 csv::delimiter := ";"
 csv::load_file('D:\YO Workout directory\...\cars.csv')
 let df : init YOLIB.dataframe()
 df::show(csv)
  ```

  
<p align="center">
    <img src="https://raw.githubusercontent.com/YODevs/YO/master/docs/dataframe.png?sanitize=true">
</p>
  
 </div>  
  
     
  ### Charts
 In YOLANG by using the `chart` Class, more than 20 types of charts like Pie, Column, Pyramid, Funnel, Point, Line, Spline, Bar, Area and so on are available.
 
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
  dt::set_axis_label('browser',labels)
  dt::show()
}
  ```

  
<p align="center" >
    <img src="https://raw.githubusercontent.com/YODevs/YO/master/docs/pie-chart.png?sanitize=true">
</p>
   
 </div>  
   
     
  ### Menus
 The `menu` class shows a list of selectable items in the console (Like creating a new project in Labra)
  
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
  
    
  ### ProgressBar
 The `Progressbar` class similar to the `menu` class is usable in the console. In graphical environments, we can use independent progressbars.
 
 This progressbar has the ability of reverse iteration and customizing shapes by using the field of `progresschar`.
  
 
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
     
  ### Interaction With User
 The `interaction` class is usable for drawing different types of `dialogbox` such as MessageBox or InputBox.
  
 <div dir="ltr">

 
```f#
  let name : str = yolib.interaction::inputbox('Information','Enter your name:')
  yolib.interaction::messagebox('Information',"Your name is #{name}")
  ```

  </div> 
       
  ### Date & Time
 The `date` class is a subset of `yolib` which is based on `System.DateTime` and only supports current time.
 
 To work with the future or past time, The main class should be used for.
 
  
 | Summary Code | Time Value | Summary Code | Time Value | Summary Code | Time Value |
|:-:|:-:|:-:|---|---|---|
| **Y** | Year | **M** | Month |  **D** | Day  | 
| **h** | Hour | **m** | Minute |  **s** | Second  |
| **t** | Millisecond | **DY** | Day Count in Year |  **DW** | Day count in Week  |


  
  
 <div dir="ltr">

 
```f#
  let currenttime : str = yolib.date::get_now("{Y}/{M}/{D} - {h}:{m}:{s}")
  io::println(currenttime)
  ```
     
 ```
2022/3/22 - 19:25:47
 ```

  </div>
        
  ### Environment
 This class is based on `system.environment` and includes functions like obtaining input arguments of application, obtaining and changing systemic variables, obtaining directory of application and process, etc.
 
 For instance, in the code below we obtain `CommandLineArg`s from the process.
 
  
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
        
  ### Encoding
 This class wrapped from the `System.Text.Encoding` class is developed in order to facilitate the usage in YOLANG
 
 
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
           
 
  ### Font
 The Font class is usable for styling and customizing in GUI environments such as `chart`, `dataframe`, etc.
 
 
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
 
  
  ### Ranges
 We already learnt about general structure of ranges in the loops section. By using `range` class, we can produce flexible numerical ranges and obtain its output in an array or in a list.
 
 
<div dir="ltr">

 
```f#
include 'yolib'
include 'ydbg'
func main()
{
  let ls : yolib.list = yolib.range::get_range(0,3)
  dbg::print(ls)
}
  ```

```
0
1
2
 ```
  </div>
  

 Regarding to the above code, if the last value of the range is needed, we can set the `ignorelastpoint` parameter as `false` in order to produce a range containing values from 0 to 3.
 
 As mentioned, within the YOLang, flexible domains can be produced by using this class.
 For instance, in the below code, one can convert the centigrade temperature into the kelvin temperature.

 
<div dir="ltr">

```f#
include 'yolib'
include 'ydbg'
func main()
{
  let ls : yolib.list = yolib.range::get_range(0,5,1,false,"x + 273")
  dbg::print(ls)
}
  ```

```
273
274
275
276
277
278
 ```
  </div>
  
  
 In the phrase, `x` is used as current point, `y` as previous point, and `z` as a response the the previous phrase.
 
 
[rellink]: <https://github.com/YODevs/YO/releases>
