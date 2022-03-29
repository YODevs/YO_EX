- [YOLang Documentation (English)](https://github.com/YODevs/YO/blob/master/docs/English%20docs/yo%20docs.md)
- [YOLang Documentation (Persian)](https://github.com/YODevs/YO/blob/master/docs/Persian%20docs/yo%20docs.md)
- [YO Standard Library Documentation](https://github.com/YODevs/YO/blob/master/docs/YOLib%20docs/yolib%20documents.md)

<hr>

# YO Programming Language

**YO** (pronounce like 'U') is an open-source, OOP , high-level, and statically typed programming language.
YO's syntax is modern and has a structure similar to Go, Rust and C programming languages.

<p>
    <img src="https://raw.githubusercontent.com/YODevs/YO/master/icons/github-yolang-banner.jpg?sanitize=true">
</p>

#### Hello World !
```f#
#[app::classname("myfirstapp")]
include 'ystdio'
func main()
{
 io::print('Hello World!')
}
```

## How to run & preparation YO Compiler?
First, go to the link [https://github.com/YODevs/YO/releases][rellink] and download the latest version of YO, then extract the files from the compressed zip file and locate them in a proper place.
Open the ```YOCA.exe``` executive file, type **```init```** command and hit ENTER. Now, You're all set to start coding with YO.

## How to create a new project?
In the project's folder, open the **CMD** or **POWERSHELL** and use the command :
```sh
labra new
``` 
Then select the project's attributes based on the platform and type of project.
Now your new project is created.

- Example
```bat
C:\Users\YO\route>labra new
# Assembly name [ex:myapp]: fast_api_project

# Select project type:
->Console [.exe]
Library [.dll]

# Need a bash file to compile and run fast?[y/N] > y
```
**To compile and execute the project, just use the following command:**

- **Build** (just compile)
```bat
yoca build
```
- **Build + Run**
```bat
yoca run
```

 <img src="https://raw.githubusercontent.com/YODevs/YO/master/icons/compile-project.gif">
 
> You can use the `yoca help` command to learn more about parameters and commands.
> 
#### Expression
```f#
#[app::classname("ctok")]
#[app::wait(true)]
func main()
{
  let _getkelvin : f32 = celsius_to_kelvin(25)
  System.Console::WriteLine("25 C = #{_getkelvin} K")
}

expr celsius_to_kelvin(c : f32) : f32 = [c + 273.15]
```

#### Recursive function
```f#
#[app::classname("fibonacci")]
#[app::wait(true)]
include 'ystdio'
func main()
{
  for(num in [0..=10])
  {
    let result : i32 = get_fibonacci(num)
    io::println("#{result}")
  }
}

func get_fibonacci(num:i32) : i32
{
  let aset , bset , result : i32
  bset := 1
  if(num == 0) { return 0 }
  if(num == 1) { return 1 }
  aset := get_fibonacci([num - 1])
  bset := get_fibonacci([num - 2])
  result := [aset + bset]
  return result
}
```

#### Match Statement
```f#
#[app::classname("matchst")]
#[app::wait(true)]

func main()
{
  exec_logs("start")
  System.Threading.Thread::Sleep(5000)
  exec_logs("stops")
}

func exec_logs(inf : str)
{
  match(inf)
  {
    case "start"  {
      System.Console::WriteLine("Starting service...")
    }
    case "stop"  {
    System.Console::WriteLine("Stopping service...")
    }
    default {
      System.Console::WriteLine("Command Not Found")
    }
  }
}
```
## Built-in types

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

## Tools

| Tool | Description |
| ------ | ------ |
| **YOCA** | The compiler of YO. |
| **YOAT** | It is Yo's Automatic Tester for tet projects (located in the "ctest" folder) which reviews errors and side interfaces while developing YOLANG compiler (YOCA) on previous projects. |
| **Labra** | It is YOLANG's Project Manager which has responsibilities like creating new projects, modifying project attributes, etc. |
| **YODA** | It is a structure for transferring data between applications, which currently supports "Lists" and "Hashmaps".YOLANG projects' config (labra.yoda) uses this structure. |


### What are YO projects' structures?
- ```assets```:
Required libraries and files are located in this folder.
- ```src```:
The whole of the project including the source code is located in this folder.
- ```target```:
Whatever compiler exports which have two states of ```debug``` and ```release``` will be located in this folder.
- ```labra.yoda```:
Properties and Customizations of the project will be set in this file.

### How about YO Development Environments and Extensions?
Developing and Coding **YO** is not dependent on any specific environment, but you can use editors which support YOLANG.
Link: [Extensions][ext]

### How to report bugs and vulnerabilities?
First, go to the link [Issues/New][issue] and submit a **new issue**.
Note that in the description section, do **highlight** that specific piece of code and related error.

### Repository License:
**[YO Repository][replink]** License is based on GPL-3.0; Developing and Utilizing is free.

    
   [rellink]: <https://github.com/YODevs/YO/releases>
   [replink]: <https://github.com/YODevs/YO/releases>
   [ext]: <https://github.com/YODevs/YO/tree/master/extensions/>
   [issue]:<https://github.com/YODevs/YO/issues/new>
