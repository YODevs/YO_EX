# YO Lang Documentation

## Introduction

YOLang is a compiled and open source language based on .NET Core and .NET Framework.

The YO's syntax is similar to languages such as Rust, Go, and C; and YOlang is also a High-Level language, but its design seeks to retain some of the properties of low-level languages.

## Installing the compiler and tools

Click here to install the latest version of the YOLang, or check the Releases section in the YOLang repository.
DotNetFramework 4.5 is a Prerequisite for running the YOLang's compiler.
After downloading the compressed file, extract it and then run the compiler's executable file (PE) called YOCA.exe in the main path of the extracted files, after opening the console environment, Enter init command for preparation and initialization.

Congratulations! Now YOLang's compiler is ready for developing your softwares.

[rellink](https://github.com/YODevs/YO/releases)

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

### Ranges:

In YOLang, Ranges have important usages; for example, you can specify the conditions of a `For` loop by using a range. Below review a list of examples of `ranges`:

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
 
[rellink]: <https://github.com/YODevs/YO/releases>
