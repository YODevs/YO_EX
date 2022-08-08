# YO Standard Library
### Class List
- [chart](#chart)
- [csv](#csv)
- [dataframe](#dataframe)
- [date](#date)
- [encoding](#encoding)
- [environment](#environment)
- [font](#font)
- [map](#map)
- [interaction](#interaction)
- [iterator](#iterator)
- [list](#list)
- [math](#math)
- [tally](#tally)
- [matrix](#matrix)
- [menu](#menu)
- [http](#http)
- [range](#range)
- [rdsresult](#rdsresult)
- [progressbar](#progressbar)
- [rds](#rds)
- [yoda](#yoda)

<hr>

### chart
- Fullname : YOLIB.chart
##### formtitle
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `str`
##### enable3d
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `bool`
##### axisytitle
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `str`
##### axisxtitle
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `str`
##### remoteaccess
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `bool`
##### borderwidth
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `i32`
#### init
- Re : Constructor
- No Parameter
#### get_formtitle
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
get_formtitle() : str
```
#### set_formtitle
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
set_formtitle(value : str) : void
```
#### get_enable3d
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
```f#
get_enable3d() : bool
```
#### set_enable3d
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `bool` | False | False |

```f#
set_enable3d(value : bool) : void
```
#### get_axisytitle
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
get_axisytitle() : str
```
#### set_axisytitle
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
set_axisytitle(value : str) : void
```
#### get_axisxtitle
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
get_axisxtitle() : str
```
#### set_axisxtitle
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
set_axisxtitle(value : str) : void
```
#### get_remoteaccess
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
```f#
get_remoteaccess() : bool
```
#### set_remoteaccess
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `bool` | False | False |

```f#
set_remoteaccess(value : bool) : void
```
#### get_borderwidth
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
get_borderwidth() : i32
```
#### set_borderwidth
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `i32` | False | False |

```f#
set_borderwidth(value : i32) : void
```
#### set_remote
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | port | `i32` | False | False |
| 2 | maxpoints | `i32` | False | False |

```f#
set_remote(port : i32 ,maxpoints : i32) : void
```
#### set_custom_palette
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | colors | `str[]` | False | False |

```f#
set_custom_palette(colors : str[]) : void
```
#### new_series
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | name | `str` | False | False |

```f#
new_series(name : str) : void
```
#### new_series
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | name | `str` | False | False |
| 2 | charttypename | `str` | False | False |

```f#
new_series(name : str ,charttypename : str) : void
```
#### add_title
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | titlename | `str` | False | False |
| 2 | value | `str` | False | False |

```f#
add_title(titlename : str ,value : str) : void
```
#### add_title
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | titlename | `str` | False | False |
| 2 | value | `str` | False | False |
| 3 | font | `YOLIB.font` | False | False |
| 4 | colorname | `str` | False | False |

```f#
add_title(titlename : str ,value : str ,font : YOLIB.font ,colorname : str) : void
```
#### add_point
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | seriesname | `str` | False | False |
| 2 | xvalue | `i32` | False | False |
| 3 | yvalue | `i32` | False | False |

```f#
add_point(seriesname : str ,xvalue : i32 ,yvalue : i32) : void
```
#### add_point
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | seriesname | `str` | False | False |
| 2 | xvalue | `f64` | False | False |
| 3 | yvalue | `f64` | False | False |

```f#
add_point(seriesname : str ,xvalue : f64 ,yvalue : f64) : void
```
#### add_point
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | seriesname | `str` | False | False |
| 2 | xvalue | `f32` | False | False |
| 3 | yvalue | `f32` | False | False |

```f#
add_point(seriesname : str ,xvalue : f32 ,yvalue : f32) : void
```
#### add_point
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | seriesname | `str` | False | False |
| 2 | xvalues | `YOLIB.list` | False | False |
| 3 | yvalues | `YOLIB.list` | False | False |

```f#
add_point(seriesname : str ,xvalues : YOLIB.list ,yvalues : YOLIB.list) : void
```
#### set_axis_label
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | seriesname | `str` | False | False |
| 2 | index | `i32` | False | False |
| 3 | value | `str` | False | False |

```f#
set_axis_label(seriesname : str ,index : i32 ,value : str) : void
```
#### set_axis_label
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | seriesname | `str` | False | False |
| 2 | values | `YOLIB.list` | False | False |

```f#
set_axis_label(seriesname : str ,values : YOLIB.list) : void
```
#### set_axis_label
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |
| 2 | value | `str` | False | False |

```f#
set_axis_label(index : i32 ,value : str) : void
```
#### show
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
```f#
show() : void
```
#### save
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | path | `str` | False | False |

```f#
save(path : str) : void
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### csv
- Fullname : YOLIB.csv
##### delimiter
- Re : Field
- Modifier : Instance
- Fieldtype : `char`
##### columncount
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `i32`
##### rowcount
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `i32`
#### init
- Re : Constructor
- No Parameter
#### get_columncount
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
get_columncount() : i32
```
#### get_rowcount
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
get_rowcount() : i32
```
#### load_file
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | path | `str` | False | False |

```f#
load_file(path : str) : void
```
#### get
- Re : Method
- Modifier : Instance
- Returntype : `str[]`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | rowindex | `i32` | False | False |

```f#
get(rowindex : i32) : str[]
```
#### get
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | rowindex | `i32` | False | False |
| 2 | colindex | `i32` | False | False |

```f#
get(rowindex : i32 ,colindex : i32) : str
```
#### get_rds
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.rds`
- No Parameter
```f#
get_rds() : YOLIB.rds
```
#### to_csv
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | data | `YOLIB.rds` | False | False |

```f#
to_csv(data : YOLIB.rds) : str
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### dataframe
- Fullname : YOLIB.dataframe
##### formtitle
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `str`
##### rtl
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `bool`
##### font
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `YOLIB.font`
#### init
- Re : Constructor
- No Parameter
#### get_formtitle
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
get_formtitle() : str
```
#### set_formtitle
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
set_formtitle(value : str) : void
```
#### get_rtl
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
```f#
get_rtl() : bool
```
#### set_rtl
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `bool` | False | False |

```f#
set_rtl(value : bool) : void
```
#### get_font
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.font`
- No Parameter
```f#
get_font() : YOLIB.font
```
#### set_font
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | obj | `YOLIB.font` | False | False |

```f#
set_font(obj : YOLIB.font) : void
```
#### show
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | dt | `YOLIB.csv` | False | False |

```f#
show(dt : YOLIB.csv) : void
```
#### show
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | dt | `YOLIB.rds` | False | False |

```f#
show(dt : YOLIB.rds) : void
```
#### show
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | dt | `YOLIB.rdsresult` | False | False |

```f#
show(dt : YOLIB.rdsresult) : void
```
#### show
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | dt | `YOLIB.map` | False | False |

```f#
show(dt : YOLIB.map) : void
```
#### show
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | dt | `YOLIB.list` | False | False |

```f#
show(dt : YOLIB.list) : void
```
#### show
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | dt | `YOLIB.matrix` | False | False |

```f#
show(dt : YOLIB.matrix) : void
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### date
- Fullname : YOLIB.date
#### init
- Re : Constructor
- No Parameter
#### get_now
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | format | `str` | False | False |

```f#
get_now(format : str) : str
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### encoding
- Fullname : YOLIB.encoding
#### init
- Re : Constructor
- No Parameter
#### utf8_get_bytes
- Re : Method
- Modifier : Static
- Returntype : `u8[]`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
utf8_get_bytes(value : str) : u8[]
```
#### utf8_get_string
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `u8[]` | False | False |

```f#
utf8_get_string(value : u8[]) : str
```
#### utf32_get_bytes
- Re : Method
- Modifier : Static
- Returntype : `u8[]`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
utf32_get_bytes(value : str) : u8[]
```
#### utf32_get_string
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `u8[]` | False | False |

```f#
utf32_get_string(value : u8[]) : str
```
#### ascii_get_bytes
- Re : Method
- Modifier : Static
- Returntype : `u8[]`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
ascii_get_bytes(value : str) : u8[]
```
#### ascii_get_string
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `u8[]` | False | False |

```f#
ascii_get_string(value : u8[]) : str
```
#### unicode_get_bytes
- Re : Method
- Modifier : Static
- Returntype : `u8[]`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
unicode_get_bytes(value : str) : u8[]
```
#### unicode_get_string
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `u8[]` | False | False |

```f#
unicode_get_string(value : u8[]) : str
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### environment
- Fullname : YOLIB.environment
##### username
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `str`
##### userdomainname
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `str`
##### stacktrace
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `str`
##### osversion
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `str`
##### machinename
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `str`
##### is64bitprocess
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `str`
##### is64bitos
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `str`
##### commandline
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `str`
##### crdir
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `str`
##### appdir
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `str`
##### sysdir
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `str`
##### arglen
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `i32`
#### init
- Re : Constructor
- No Parameter
#### get_username
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
```f#
get_username() : str
```
#### get_userdomainname
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
```f#
get_userdomainname() : str
```
#### get_stacktrace
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
```f#
get_stacktrace() : str
```
#### get_osversion
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
```f#
get_osversion() : str
```
#### get_machinename
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
```f#
get_machinename() : str
```
#### get_is64bitprocess
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
```f#
get_is64bitprocess() : str
```
#### get_is64bitos
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
```f#
get_is64bitos() : str
```
#### get_commandline
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
```f#
get_commandline() : str
```
#### get_crdir
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
```f#
get_crdir() : str
```
#### get_appdir
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
```f#
get_appdir() : str
```
#### get_sysdir
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
```f#
get_sysdir() : str
```
#### get_arglen
- Re : Method
- Modifier : Static
- Returntype : `i32`
- No Parameter
```f#
get_arglen() : i32
```
#### terminate
- Re : Method
- Modifier : Static
- Returntype : `void`
- No Parameter
```f#
terminate() : void
```
#### terminate
- Re : Method
- Modifier : Static
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | exitcode | `i32` | False | False |

```f#
terminate(exitcode : i32) : void
```
#### get_env
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | envname | `str` | False | False |

```f#
get_env(envname : str) : str
```
#### set_env
- Re : Method
- Modifier : Static
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | envname | `str` | False | False |
| 2 | value | `str` | False | False |

```f#
set_env(envname : str ,value : str) : void
```
#### get_arg
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get_arg(index : i32) : str
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### font
- Fullname : YOLIB.font
##### font
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `System.Drawing.Font`
#### init
- Re : Constructor

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | fontname | `str` | False | False |
| 2 | fontsize | `i32` | False | False |

#### init
- Re : Constructor

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | fontname | `str` | False | False |
| 2 | fontsize | `f32` | False | False |

#### init
- Re : Constructor

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | fontname | `str` | False | False |
| 2 | fontsize | `f32` | False | False |
| 3 | fontstyle | `str` | False | False |

#### init
- Re : Constructor

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | fontname | `str` | False | False |
| 2 | fontsize | `i32` | False | False |
| 3 | fontstyle | `str` | False | False |

#### get_font
- Re : Method
- Modifier : Instance
- Returntype : `System.Drawing.Font`
- No Parameter
```f#
get_font() : System.Drawing.Font
```
#### set_font
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `System.Drawing.Font` | False | False |

```f#
set_font(value : System.Drawing.Font) : void
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### map
- Fullname : YOLIB.map
#### init
- Re : Constructor
- No Parameter
#### import
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | yodamap | `str` | False | False |

```f#
import(yodamap : str) : i32
```
#### clone
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
clone() : str
```
#### set
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | yodamap | `str` | False | False |

```f#
set(yodamap : str) : i32
```
#### add
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |
| 2 | value | `str` | False | False |

```f#
add(key : str ,value : str) : bool
```
#### add_unique
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |
| 2 | value | `str` | False | False |

```f#
add_unique(key : str ,value : str) : bool
```
#### contains_key
- Re : Method
- Modifier : Instance
- Returntype : `obj`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |

```f#
contains_key(key : str) : obj
```
#### contains_value
- Re : Method
- Modifier : Instance
- Returntype : `obj`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
contains_value(value : str) : obj
```
#### get
- Re : Method
- Modifier : Instance
- Returntype : `obj`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |

```f#
get(key : str) : obj
```
#### get_map
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |
| 2 | key | `System.String&` | False | True |
| 3 | value | `System.String&` | False | True |

```f#
get_map(index : i32 ,key : System.String& ,value : System.String&) : void
```
#### get_with_index
- Re : Method
- Modifier : Instance
- Returntype : `obj`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get_with_index(index : i32) : obj
```
#### get_all_keys
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.list`
- No Parameter
```f#
get_all_keys() : YOLIB.list
```
#### get_all_values
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.list`
- No Parameter
```f#
get_all_values() : YOLIB.list
```
#### remove
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |

```f#
remove(key : str) : bool
```
#### clear
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
```f#
clear() : bool
```
#### size
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
size() : i32
```
#### is_empty
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
```f#
is_empty() : bool
```
#### update
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |
| 2 | value | `str` | False | False |

```f#
update(key : str ,value : str) : bool
```
#### save
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | path | `str` | False | False |

```f#
save(path : str) : void
```
#### load
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | path | `str` | False | False |

```f#
load(path : str) : i32
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### interaction
- Fullname : YOLIB.interaction
#### init
- Re : Constructor
- No Parameter
#### inputbox
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
```f#
inputbox() : str
```
#### inputbox
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | title | `str` | False | False |
| 2 | description | `str` | False | False |

```f#
inputbox(title : str ,description : str) : str
```
#### inputbox
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | title | `str` | False | False |
| 2 | description | `str` | False | False |
| 3 | defaultresult | `str` | False | False |

```f#
inputbox(title : str ,description : str ,defaultresult : str) : str
```
#### messagebox
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | description | `str` | False | False |

```f#
messagebox(description : str) : str
```
#### messagebox
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | title | `str` | False | False |
| 2 | description | `str` | False | False |

```f#
messagebox(title : str ,description : str) : str
```
#### messagebox
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | title | `str` | False | False |
| 2 | description | `str` | False | False |
| 3 | dialogstyle | `i32` | False | False |

```f#
messagebox(title : str ,description : str ,dialogstyle : i32) : str
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### iterator
- Fullname : YOLIB.iterator
##### index
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `i32`
#### init
- Re : Constructor

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | clonelist | `YOLIB.list` | False | False |

#### get_index
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
get_index() : i32
```
#### set_index
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `i32` | False | False |

```f#
set_index(value : i32) : void
```
#### has_next
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
```f#
has_next() : bool
```
#### has_previous
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
```f#
has_previous() : bool
```
#### next
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
next() : str
```
#### previous
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
previous() : str
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### list
- Fullname : YOLIB.list
#### init
- Re : Constructor
- No Parameter
#### init
- Re : Constructor

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |
| 2 | pattern | `str` | False | False |

#### init
- Re : Constructor

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | values | `str[]` | False | False |

#### init
- Re : Constructor

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | values | `System.Collections.ArrayList` | False | False |

#### append
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
append(value : str) : i32
```
#### add
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
add(value : str) : i32
```
#### add_with_split
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | values | `str` | False | False |
| 2 | pattern | `str` | False | False |

```f#
add_with_split(values : str ,pattern : str) : i32
```
#### insert
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |
| 2 | value | `str` | False | False |

```f#
insert(index : i32 ,value : str) : i32
```
#### import
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | yodastring | `str` | False | False |

```f#
import(yodastring : str) : i32
```
#### save
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | path | `str` | False | False |

```f#
save(path : str) : void
```
#### load
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | path | `str` | False | False |

```f#
load(path : str) : void
```
#### set
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | yodastring | `str` | False | False |

```f#
set(yodastring : str) : i32
```
#### clone
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
clone() : str
```
#### iter
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | item | `str` | False | False |

```f#
iter(item : str) : i32
```
#### avg
- Re : Method
- Modifier : Instance
- Returntype : `f64`
- No Parameter
```f#
avg() : f64
```
#### count
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
count() : i32
```
#### clear
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
```f#
clear() : void
```
#### remove
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
remove(value : str) : bool
```
#### remove_at
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
remove_at(index : i32) : void
```
#### sort
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
```f#
sort() : void
```
#### reverse
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
```f#
reverse() : void
```
#### contains
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
contains(value : str) : bool
```
#### starts_with
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
starts_with(value : str) : bool
```
#### ends_with
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
ends_with(value : str) : bool
```
#### pattern
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | regexCode | `str` | False | False |

```f#
pattern(regexCode : str) : bool
```
#### get
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get(index : i32) : str
```
#### get_index
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
get_index(value : str) : i32
```
#### pop
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
pop() : str
```
#### pop_left
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
pop_left() : str
```
#### to_str
- Re : Method
- Modifier : Instance
- Returntype : `str[]`
- No Parameter
```f#
to_str() : str[]
```
#### to_arraylist
- Re : Method
- Modifier : Instance
- Returntype : `System.Collections.ArrayList`
- No Parameter
```f#
to_arraylist() : System.Collections.ArrayList
```
#### remove_duplicate
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
remove_duplicate() : i32
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### math
- Fullname : YOLIB.math
##### PI
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `f64`
##### TUA
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `f64`
##### E
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `f64`
#### init
- Re : Constructor
- No Parameter
#### get_PI
- Re : Method
- Modifier : Static
- Returntype : `f64`
- No Parameter
```f#
get_PI() : f64
```
#### get_TUA
- Re : Method
- Modifier : Static
- Returntype : `f64`
- No Parameter
```f#
get_TUA() : f64
```
#### get_E
- Re : Method
- Modifier : Static
- Returntype : `f64`
- No Parameter
```f#
get_E() : f64
```
#### factorial
- Re : Method
- Modifier : Static
- Returntype : `i64`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | number | `i32` | False | False |

```f#
factorial(number : i32) : i64
```
#### factorial_i32
- Re : Method
- Modifier : Static
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | number | `i32` | False | False |

```f#
factorial_i32(number : i32) : i32
```
#### abs
- Re : Method
- Modifier : Static
- Returntype : `i128`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `i128` | False | False |

```f#
abs(value : i128) : i128
```
#### abs
- Re : Method
- Modifier : Static
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `i32` | False | False |

```f#
abs(value : i32) : i32
```
#### abs
- Re : Method
- Modifier : Static
- Returntype : `f32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `f32` | False | False |

```f#
abs(value : f32) : f32
```
#### abs
- Re : Method
- Modifier : Static
- Returntype : `f64`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `f64` | False | False |

```f#
abs(value : f64) : f64
```
#### log
- Re : Method
- Modifier : Static
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | number | `i32` | False | False |

```f#
log(number : i32) : i32
```
#### log
- Re : Method
- Modifier : Static
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | number | `i32` | False | False |
| 2 | base | `i32` | False | False |

```f#
log(number : i32 ,base : i32) : i32
```
#### log
- Re : Method
- Modifier : Static
- Returntype : `f32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | number | `f32` | False | False |

```f#
log(number : f32) : f32
```
#### log
- Re : Method
- Modifier : Static
- Returntype : `f32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | number | `f32` | False | False |
| 2 | base | `f32` | False | False |

```f#
log(number : f32 ,base : f32) : f32
```
#### log
- Re : Method
- Modifier : Static
- Returntype : `f64`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | number | `f64` | False | False |

```f#
log(number : f64) : f64
```
#### log
- Re : Method
- Modifier : Static
- Returntype : `f64`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | number | `f64` | False | False |
| 2 | base | `f64` | False | False |

```f#
log(number : f64 ,base : f64) : f64
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### tally
- Fullname : YOLIB.tally
##### grouprange
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `i32`
#### init
- Re : Constructor
- No Parameter
#### get_grouprange
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
get_grouprange() : i32
```
#### set_grouprange
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `i32` | False | False |

```f#
set_grouprange(value : i32) : void
```
#### add
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | item | `str` | False | False |

```f#
add(item : str) : void
```
#### get
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | item | `str` | False | False |

```f#
get(item : str) : i32
```
#### get_percentage
- Re : Method
- Modifier : Instance
- Returntype : `f32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | item | `str` | False | False |

```f#
get_percentage(item : str) : f32
```
#### get_group
- Re : Method
- Modifier : Instance
- Returntype : `f32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | item | `str` | False | False |

```f#
get_group(item : str) : f32
```
#### get_single
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | item | `str` | False | False |

```f#
get_single(item : str) : i32
```
#### get_average
- Re : Method
- Modifier : Instance
- Returntype : `f32`
- No Parameter
```f#
get_average() : f32
```
#### number_of_variations
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
number_of_variations() : i32
```
#### number_of_records
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
number_of_records() : i32
```
#### sort
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.map`
- No Parameter
```f#
sort() : YOLIB.map
```
#### sort_by_percentage
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.map`
- No Parameter
```f#
sort_by_percentage() : YOLIB.map
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### matrix
- Fullname : YOLIB.matrix
##### isempty
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `bool`
##### columnsize
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `i32`
##### rowsize
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `i32`
#### init
- Re : Constructor

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | ncol | `i32` | False | False |
| 2 | nrow | `i32` | False | False |

#### get_isempty
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
```f#
get_isempty() : bool
```
#### get_columnsize
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
get_columnsize() : i32
```
#### get_rowsize
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
get_rowsize() : i32
```
#### unit_matrix
- Re : Method
- Modifier : Static
- Returntype : `YOLIB.matrix`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | nsize | `i32` | False | False |

```f#
unit_matrix(nsize : i32) : YOLIB.matrix
```
#### clear_matrix
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
```f#
clear_matrix() : void
```
#### set_zero_matrix
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
```f#
set_zero_matrix() : void
```
#### set_range_matrix
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `YOLIB.list` | False | False |

```f#
set_range_matrix(items : YOLIB.list) : void
```
#### set_unit_matrix
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
```f#
set_unit_matrix() : void
```
#### set_scalar_matrix
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | val | `i32` | False | False |

```f#
set_scalar_matrix(val : i32) : void
```
#### set_scalar_matrix
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | val | `f64` | False | False |

```f#
set_scalar_matrix(val : f64) : void
```
#### get_matrix
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
get_matrix() : str
```
#### set_item
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | columnindex | `i32` | False | False |
| 2 | rowindex | `i32` | False | False |
| 3 | value | `i32` | False | False |

```f#
set_item(columnindex : i32 ,rowindex : i32 ,value : i32) : void
```
#### set_item
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | columnindex | `i32` | False | False |
| 2 | rowindex | `i32` | False | False |
| 3 | value | `f64` | False | False |

```f#
set_item(columnindex : i32 ,rowindex : i32 ,value : f64) : void
```
#### get_item
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | columnindex | `i32` | False | False |
| 2 | rowindex | `i32` | False | False |

```f#
get_item(columnindex : i32 ,rowindex : i32) : i32
```
#### get_item_f64
- Re : Method
- Modifier : Instance
- Returntype : `f64`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | columnindex | `i32` | False | False |
| 2 | rowindex | `i32` | False | False |

```f#
get_item_f64(columnindex : i32 ,rowindex : i32) : f64
```
#### neg
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`
- No Parameter
```f#
neg() : YOLIB.matrix
```
#### transpose
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`
- No Parameter
```f#
transpose() : YOLIB.matrix
```
#### sub
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | matrix2 | `YOLIB.matrix` | False | False |

```f#
sub(matrix2 : YOLIB.matrix) : YOLIB.matrix
```
#### add
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | matrix2 | `YOLIB.matrix` | False | False |

```f#
add(matrix2 : YOLIB.matrix) : YOLIB.matrix
```
#### multiply
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | val | `i32` | False | False |

```f#
multiply(val : i32) : YOLIB.matrix
```
#### multiply
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | val | `f64` | False | False |

```f#
multiply(val : f64) : YOLIB.matrix
```
#### multiply
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | matrix2 | `YOLIB.matrix` | False | False |

```f#
multiply(matrix2 : YOLIB.matrix) : YOLIB.matrix
```
#### get_list
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.list`
- No Parameter
```f#
get_list() : YOLIB.list
```
#### avg
- Re : Method
- Modifier : Instance
- Returntype : `f64`
- No Parameter
```f#
avg() : f64
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### menu
- Fullname : YOLIB.menu
##### cursor
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `str`
##### selectindex
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `i32`
#### init
- Re : Constructor
- No Parameter
#### get_cursor
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
```f#
get_cursor() : str
```
#### set_cursor
- Re : Method
- Modifier : Static
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
set_cursor(value : str) : void
```
#### get_selectindex
- Re : Method
- Modifier : Static
- Returntype : `i32`
- No Parameter
```f#
get_selectindex() : i32
```
#### show_menu
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `YOLIB.list` | False | False |

```f#
show_menu(items : YOLIB.list) : str
```
#### show_menu
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `str` | False | False |

```f#
show_menu(items : str) : str
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### http
- Fullname : YOLIB.http
##### backupwebreq
- Re : Field
- Modifier : Instance
- Fieldtype : `System.Net.HttpWebRequest`
##### webreq
- Re : Field
- Modifier : Instance
- Fieldtype : `System.Net.HttpWebRequest`
##### webres
- Re : Field
- Modifier : Instance
- Fieldtype : `System.Net.WebResponse`
##### statuscode
- Re : Field
- Modifier : Instance
- Fieldtype : `i32`
##### charset
- Re : Field
- Modifier : Instance
- Fieldtype : `str`
##### contentencoding
- Re : Field
- Modifier : Instance
- Fieldtype : `str`
##### contentlength
- Re : Field
- Modifier : Instance
- Fieldtype : `str`
##### contenttype
- Re : Field
- Modifier : Instance
- Fieldtype : `str`
##### method
- Re : Field
- Modifier : Instance
- Fieldtype : `str`
##### server
- Re : Field
- Modifier : Instance
- Fieldtype : `str`
##### protocolversion
- Re : Field
- Modifier : Instance
- Fieldtype : `str`
##### status
- Re : Field
- Modifier : Instance
- Fieldtype : `str`
##### isfromcache
- Re : Field
- Modifier : Instance
- Fieldtype : `str`
##### referer
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `str`
##### useragent
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `str`
##### allowautorediret
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `str`
##### timeout
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `i32`
##### keepalive
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `bool`
#### init
- Re : Constructor
- No Parameter
#### add_header
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | headers | `YOLIB.map` | False | False |

```f#
add_header(headers : YOLIB.map) : void
```
#### add_header
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |
| 2 | value | `str` | False | False |

```f#
add_header(key : str ,value : str) : void
```
#### send
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | url | `str` | False | False |

```f#
send(url : str) : str
```
#### send
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | uri | `System.Uri` | False | False |

```f#
send(uri : System.Uri) : str
```
#### get_referer
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
get_referer() : str
```
#### set_referer
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
set_referer(value : str) : void
```
#### get_useragent
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
get_useragent() : str
```
#### set_useragent
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
set_useragent(value : str) : void
```
#### get_allowautorediret
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
get_allowautorediret() : str
```
#### set_allowautorediret
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
set_allowautorediret(value : str) : void
```
#### get_timeout
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
get_timeout() : i32
```
#### set_timeout
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `i32` | False | False |

```f#
set_timeout(value : i32) : void
```
#### get_keepalive
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
```f#
get_keepalive() : bool
```
#### set_keepalive
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `bool` | False | False |

```f#
set_keepalive(value : bool) : void
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### range
- Fullname : YOLIB.range
#### init
- Re : Constructor
- No Parameter
#### get_range
- Re : Method
- Modifier : Static
- Returntype : `YOLIB.list`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | startpoint | `i32` | False | False |
| 2 | endpoint | `i32` | False | False |

```f#
get_range(startpoint : i32 ,endpoint : i32) : YOLIB.list
```
#### get_range
- Re : Method
- Modifier : Static
- Returntype : `YOLIB.list`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | startpoint | `i32` | False | False |
| 2 | endpoint | `i32` | False | False |
| 3 | step | `i32` | False | False |

```f#
get_range(startpoint : i32 ,endpoint : i32 ,step : i32) : YOLIB.list
```
#### get_range
- Re : Method
- Modifier : Static
- Returntype : `YOLIB.list`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | startpoint | `i32` | False | False |
| 2 | endpoint | `i32` | False | False |
| 3 | step | `i32` | False | False |
| 4 | ignorelastpoint | `bool` | False | False |

```f#
get_range(startpoint : i32 ,endpoint : i32 ,step : i32 ,ignorelastpoint : bool) : YOLIB.list
```
#### get_range
- Re : Method
- Modifier : Static
- Returntype : `YOLIB.list`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | startpoint | `i32` | False | False |
| 2 | endpoint | `i32` | False | False |
| 3 | step | `i32` | False | False |
| 4 | ignorelastpoint | `bool` | False | False |
| 5 | expression | `str` | False | False |

```f#
get_range(startpoint : i32 ,endpoint : i32 ,step : i32 ,ignorelastpoint : bool ,expression : str) : YOLIB.list
```
#### get_range
- Re : Method
- Modifier : Static
- Returntype : `YOLIB.list`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | startpoint | `f64` | False | False |
| 2 | endpoint | `f64` | False | False |

```f#
get_range(startpoint : f64 ,endpoint : f64) : YOLIB.list
```
#### get_range
- Re : Method
- Modifier : Static
- Returntype : `YOLIB.list`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | startpoint | `f64` | False | False |
| 2 | endpoint | `f64` | False | False |
| 3 | step | `f64` | False | False |

```f#
get_range(startpoint : f64 ,endpoint : f64 ,step : f64) : YOLIB.list
```
#### get_range
- Re : Method
- Modifier : Static
- Returntype : `YOLIB.list`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | startpoint | `f64` | False | False |
| 2 | endpoint | `f64` | False | False |
| 3 | step | `f64` | False | False |
| 4 | ignorelastpoint | `bool` | False | False |

```f#
get_range(startpoint : f64 ,endpoint : f64 ,step : f64 ,ignorelastpoint : bool) : YOLIB.list
```
#### get_range
- Re : Method
- Modifier : Static
- Returntype : `YOLIB.list`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | startpoint | `f64` | False | False |
| 2 | endpoint | `f64` | False | False |
| 3 | step | `f64` | False | False |
| 4 | ignorelastpoint | `bool` | False | False |
| 5 | expression | `str` | False | False |

```f#
get_range(startpoint : f64 ,endpoint : f64 ,step : f64 ,ignorelastpoint : bool ,expression : str) : YOLIB.list
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### rdsresult
- Fullname : YOLIB.rdsresult
##### columnslist
- Re : Field
- Modifier : Instance
- Fieldtype : `YOLIB.list`
##### count
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `i32`
##### read
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `bool`
#### init
- Re : Constructor

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | data | `System.Collections.ArrayList[]` | False | False |
| 2 | columns | `System.Collections.ArrayList` | False | False |

#### get_count
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
get_count() : i32
```
#### get_read
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
```f#
get_read() : bool
```
#### next
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
```f#
next() : void
```
#### get
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | name | `str` | False | False |

```f#
get(name : str) : str
```
#### get
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get(index : i32) : str
```
#### get_i64
- Re : Method
- Modifier : Instance
- Returntype : `i64`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | name | `str` | False | False |

```f#
get_i64(name : str) : i64
```
#### get_i64
- Re : Method
- Modifier : Instance
- Returntype : `i64`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get_i64(index : i32) : i64
```
#### get_i32
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | name | `str` | False | False |

```f#
get_i32(name : str) : i32
```
#### get_i32
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get_i32(index : i32) : i32
```
#### get_f64
- Re : Method
- Modifier : Instance
- Returntype : `f64`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | name | `str` | False | False |

```f#
get_f64(name : str) : f64
```
#### get_f64
- Re : Method
- Modifier : Instance
- Returntype : `f64`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get_f64(index : i32) : f64
```
#### get_f32
- Re : Method
- Modifier : Instance
- Returntype : `f32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | name | `str` | False | False |

```f#
get_f32(name : str) : f32
```
#### get_f32
- Re : Method
- Modifier : Instance
- Returntype : `f32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get_f32(index : i32) : f32
```
#### get_bool
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | name | `str` | False | False |

```f#
get_bool(name : str) : bool
```
#### get_bool
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get_bool(index : i32) : bool
```
#### get_obj
- Re : Method
- Modifier : Instance
- Returntype : `obj`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | name | `str` | False | False |

```f#
get_obj(name : str) : obj
```
#### get_obj
- Re : Method
- Modifier : Instance
- Returntype : `obj`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get_obj(index : i32) : obj
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### progressbar
- Fullname : YOLIB.progressbar
##### progress
- Re : Field
- Modifier : Instance
- Fieldtype : `i32`
##### progresschar
- Re : Field
- Modifier : Instance
- Fieldtype : `char`
##### isenabled
- Re : Field
- Modifier : Instance
- Fieldtype : `bool`
##### spaceprogresschar
- Re : Field
- Modifier : Instance
- Fieldtype : `char`
#### init
- Re : Constructor
- No Parameter
#### show_progress
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
```f#
show_progress() : void
```
#### increase
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
```f#
increase() : void
```
#### decrease
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
```f#
decrease() : void
```
#### hide_progress
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
```f#
hide_progress() : void
```
#### reset_progress
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
```f#
reset_progress() : void
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### rds
- Fullname : YOLIB.rds
##### columncount
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `i32`
##### rowcount
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `i32`
##### getcolumns
- Re : Property
- Can Read : True
- Can Write : False
- Propertytype : `str[]`
#### init
- Re : Constructor
- No Parameter
#### get_columncount
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
get_columncount() : i32
```
#### get_rowcount
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
get_rowcount() : i32
```
#### get_getcolumns
- Re : Method
- Modifier : Instance
- Returntype : `str[]`
- No Parameter
```f#
get_getcolumns() : str[]
```
#### remove_column
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
remove_column(index : i32) : void
```
#### remove_column
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |
| 2 | count | `i32` | False | False |

```f#
remove_column(index : i32 ,count : i32) : void
```
#### set_columns
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `str` | False | False |

```f#
set_columns(items : str) : void
```
#### set_columns
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `System.Collections.ArrayList` | False | False |

```f#
set_columns(items : System.Collections.ArrayList) : void
```
#### set_command
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | state | `YOLIB.rds+commandstate` | False | False |
| 2 | columnname | `str` | False | False |
| 3 | value | `str` | False | False |

```f#
set_command(state : YOLIB.rds+commandstate ,columnname : str ,value : str) : void
```
#### insert
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `str` | False | False |

```f#
insert(items : str) : i32
```
#### insert
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `System.Collections.ArrayList` | False | False |

```f#
insert(items : System.Collections.ArrayList) : i32
```
#### insert
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `YOLIB.list` | False | False |

```f#
insert(items : YOLIB.list) : i32
```
#### insert
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `str[]` | False | False |

```f#
insert(items : str[]) : i32
```
#### delete
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
delete(index : i32) : void
```
#### delete
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
```f#
delete() : i32
```
#### update
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |
| 2 | columnname | `str` | False | False |
| 3 | value | `str` | False | False |

```f#
update(index : i32 ,columnname : str ,value : str) : void
```
#### update
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | columnname | `str` | False | False |
| 2 | value | `str` | False | False |

```f#
update(columnname : str ,value : str) : i32
```
#### select
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.rdsresult`
- No Parameter
```f#
select() : YOLIB.rdsresult
```
#### get_row_map
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.map`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get_row_map(index : i32) : YOLIB.map
```
#### get_row_list
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.list`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get_row_list(index : i32) : YOLIB.list
```
#### get_row
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get_row(index : i32) : str
```
#### get
- Re : Method
- Modifier : Instance
- Returntype : `str[]`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

```f#
get(index : i32) : str[]
```
#### get
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | rowindex | `i32` | False | False |
| 2 | colindex | `i32` | False | False |

```f#
get(rowindex : i32 ,colindex : i32) : str
```
#### get_column_items
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.list`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | colindex | `i32` | False | False |

```f#
get_column_items(colindex : i32) : YOLIB.list
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```

<hr>

### yoda
- Fullname : YOLIB.yoda
##### compress
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `bool`
#### init
- Re : Constructor
- No Parameter
#### get_compress
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
```f#
get_compress() : bool
```
#### set_compress
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `bool` | False | False |

```f#
set_compress(value : bool) : void
```
#### add
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

```f#
add(value : str) : void
```
#### add
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |
| 2 | value | `str` | False | False |

```f#
add(key : str ,value : str) : void
```
#### get_list
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
get_list() : str
```
#### get_map
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
```f#
get_map() : str
```
#### WriteYODA
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `System.Collections.ArrayList` | False | False |
| 2 | compress | `bool` | True | False |

```f#
WriteYODA(items : System.Collections.ArrayList ,compress : bool) : str
```
#### WriteYODA_Map
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | keys | `System.Collections.ArrayList` | False | False |
| 2 | values | `System.Collections.ArrayList` | False | False |
| 3 | compress | `bool` | True | False |

```f#
WriteYODA_Map(keys : System.Collections.ArrayList ,values : System.Collections.ArrayList ,compress : bool) : str
```
#### WriteYODA_Map
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `System.Collections.ArrayList` | False | False |

```f#
WriteYODA_Map(items : System.Collections.ArrayList) : str
```
#### ReadYODA
- Re : Method
- Modifier : Instance
- Returntype : `System.Collections.ArrayList`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | YODA_F | `str` | False | False |

```f#
ReadYODA(YODA_F : str) : System.Collections.ArrayList
```
#### ReadYODA_Map
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.yoda+YODAMapFormat`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | YODA_F | `str` | False | False |

```f#
ReadYODA_Map(YODA_F : str) : YOLIB.yoda+YODAMapFormat
```
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
```f#
GetType() : System.Type
```
