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
