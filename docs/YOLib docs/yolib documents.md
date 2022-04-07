# YO Standart Library
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
- [matrix](#matrix)
- [menu](#menu)
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
##### asixytitle
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `str`
##### asixxtitle
- Re : Property
- Can Read : True
- Can Write : True
- Propertytype : `str`
#### init
- Re : Constructor
- No Parameter
#### get_formtitle
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
#### set_formtitle
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### get_enable3d
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
#### set_enable3d
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `bool` | False | False |

#### get_asixytitle
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
#### set_asixytitle
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### get_asixxtitle
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
#### set_asixxtitle
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### new_series
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | name | `str` | False | False |

#### new_series
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | name | `str` | False | False |
| 2 | charttypename | `str` | False | False |

#### add_point
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | seriesname | `str` | False | False |
| 2 | xvalue | `i32` | False | False |
| 3 | yvalue | `i32` | False | False |

#### add_point
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | seriesname | `str` | False | False |
| 2 | xvalue | `f64` | False | False |
| 3 | yvalue | `f64` | False | False |

#### add_point
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | seriesname | `str` | False | False |
| 2 | xvalue | `f32` | False | False |
| 3 | yvalue | `f32` | False | False |

#### add_point
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | seriesname | `str` | False | False |
| 2 | xvalues | `YOLIB.list` | False | False |
| 3 | yvalues | `YOLIB.list` | False | False |

#### set_asix_label
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | seriesname | `str` | False | False |
| 2 | index | `i32` | False | False |
| 3 | value | `str` | False | False |

#### set_asix_label
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | seriesname | `str` | False | False |
| 2 | values | `YOLIB.list` | False | False |

#### set_asix_label
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |
| 2 | value | `str` | False | False |

#### show
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
#### save
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | path | `str` | False | False |

#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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
#### get_rowcount
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
#### load_file
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | path | `str` | False | False |

#### get
- Re : Method
- Modifier : Instance
- Returntype : `str[]`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | rowindex | `i32` | False | False |

#### get
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | rowindex | `i32` | False | False |
| 2 | colindex | `i32` | False | False |

#### get_rds
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.rds`
- No Parameter
#### to_csv
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | data | `YOLIB.rds` | False | False |

#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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
#### set_formtitle
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### get_rtl
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
#### set_rtl
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `bool` | False | False |

#### get_font
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.font`
- No Parameter
#### set_font
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | obj | `YOLIB.font` | False | False |

#### show
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | dt | `YOLIB.csv` | False | False |

#### show
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | dt | `YOLIB.rds` | False | False |

#### show
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | dt | `YOLIB.map` | False | False |

#### show
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | dt | `YOLIB.list` | False | False |

#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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

#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

<hr>

### encoding
- Fullname : YOLIB.encoding
#### init
- Re : Constructor
- No Parameter
#### utf8_get_bytes
- Re : Method
- Modifier : Static
- Returntype : `System.Byte[]`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### utf8_get_string
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `System.Byte[]` | False | False |

#### utf32_get_bytes
- Re : Method
- Modifier : Static
- Returntype : `System.Byte[]`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### utf32_get_string
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `System.Byte[]` | False | False |

#### ascii_get_bytes
- Re : Method
- Modifier : Static
- Returntype : `System.Byte[]`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### ascii_get_string
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `System.Byte[]` | False | False |

#### unicode_get_bytes
- Re : Method
- Modifier : Static
- Returntype : `System.Byte[]`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### unicode_get_string
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `System.Byte[]` | False | False |

#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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
#### get_userdomainname
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
#### get_stacktrace
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
#### get_osversion
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
#### get_machinename
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
#### get_is64bitprocess
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
#### get_is64bitos
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
#### get_commandline
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
#### get_crdir
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
#### get_appdir
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
#### get_sysdir
- Re : Method
- Modifier : Static
- Returntype : `str`
- No Parameter
#### get_arglen
- Re : Method
- Modifier : Static
- Returntype : `i32`
- No Parameter
#### terminate
- Re : Method
- Modifier : Static
- Returntype : `void`
- No Parameter
#### terminate
- Re : Method
- Modifier : Static
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | exitcode | `i32` | False | False |

#### get_env
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | envname | `str` | False | False |

#### set_env
- Re : Method
- Modifier : Static
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | envname | `str` | False | False |
| 2 | value | `str` | False | False |

#### get_arg
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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
#### set_font
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `System.Drawing.Font` | False | False |

#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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

#### clone
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
#### set
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | yodamap | `str` | False | False |

#### add
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |
| 2 | value | `str` | False | False |

#### add_unique
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |
| 2 | value | `str` | False | False |

#### contains_key
- Re : Method
- Modifier : Instance
- Returntype : `obj`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |

#### contains_value
- Re : Method
- Modifier : Instance
- Returntype : `obj`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### get
- Re : Method
- Modifier : Instance
- Returntype : `obj`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |

#### get_map
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |
| 2 | key | `System.String&` | False | True |
| 3 | value | `System.String&` | False | True |

#### get_with_index
- Re : Method
- Modifier : Instance
- Returntype : `obj`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

#### remove
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |

#### clear
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
#### size
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
#### is_empty
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
#### update
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |
| 2 | value | `str` | False | False |

#### save
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | path | `str` | False | False |

#### load
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | path | `str` | False | False |

#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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
#### inputbox
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | title | `str` | False | False |
| 2 | description | `str` | False | False |

#### inputbox
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | title | `str` | False | False |
| 2 | description | `str` | False | False |
| 3 | defaultresult | `str` | False | False |

#### messagebox
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | description | `str` | False | False |

#### messagebox
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | title | `str` | False | False |
| 2 | description | `str` | False | False |

#### messagebox
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | title | `str` | False | False |
| 2 | description | `str` | False | False |
| 3 | dialogstyle | `i32` | False | False |

#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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
#### set_index
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `i32` | False | False |

#### has_next
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
#### has_previous
- Re : Method
- Modifier : Instance
- Returntype : `bool`
- No Parameter
#### next
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
#### previous
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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

#### append
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### add
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### add_with_split
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | values | `str` | False | False |
| 2 | pattern | `str` | False | False |

#### insert
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |
| 2 | value | `str` | False | False |

#### import
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | yodastring | `str` | False | False |

#### save
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | path | `str` | False | False |

#### load
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | path | `str` | False | False |

#### set
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | yodastring | `str` | False | False |

#### clone
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
#### iter
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | item | `str` | False | False |

#### count
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
#### clear
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
#### remove
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### remove_at
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

#### sort
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
#### reverse
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
#### contains
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### starts_with
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### ends_with
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### pattern
- Re : Method
- Modifier : Instance
- Returntype : `bool`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | regexCode | `str` | False | False |

#### get
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

#### get_index
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### pop
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
#### pop_left
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
#### to_str
- Re : Method
- Modifier : Instance
- Returntype : `str[]`
- No Parameter
#### to_arraylist
- Re : Method
- Modifier : Instance
- Returntype : `System.Collections.ArrayList`
- No Parameter
#### remove_duplicate
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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
#### get_columnsize
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
#### get_rowsize
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
#### clear_matrix
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
#### set_zero_matrix
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
#### set_unit_matrix
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
#### set_scalar_matrix
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | val | `i32` | False | False |

#### set_scalar_matrix
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | val | `f64` | False | False |

#### get_matrix
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
#### set_item
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | columnindex | `i32` | False | False |
| 2 | rowindex | `i32` | False | False |
| 3 | value | `i32` | False | False |

#### set_item
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | columnindex | `i32` | False | False |
| 2 | rowindex | `i32` | False | False |
| 3 | value | `f64` | False | False |

#### get_item
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | columnindex | `i32` | False | False |
| 2 | rowindex | `i32` | False | False |

#### get_item_f64
- Re : Method
- Modifier : Instance
- Returntype : `f64`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | columnindex | `i32` | False | False |
| 2 | rowindex | `i32` | False | False |

#### neg
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`
- No Parameter
#### transpose
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`
- No Parameter
#### sub
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | matrix2 | `YOLIB.matrix` | False | False |

#### add
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | matrix2 | `YOLIB.matrix` | False | False |

#### multiply
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | val | `i32` | False | False |

#### multiply
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | val | `f64` | False | False |

#### multiply
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.matrix`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | matrix2 | `YOLIB.matrix` | False | False |

#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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
#### set_cursor
- Re : Method
- Modifier : Static
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### get_selectindex
- Re : Method
- Modifier : Static
- Returntype : `i32`
- No Parameter
#### show_menu
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `YOLIB.list` | False | False |

#### show_menu
- Re : Method
- Modifier : Static
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `str` | False | False |

#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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
#### increase
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
#### decrease
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
#### hide_progress
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
#### reset_progress
- Re : Method
- Modifier : Instance
- Returntype : `void`
- No Parameter
#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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
#### get_rowcount
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
#### get_getcolumns
- Re : Method
- Modifier : Instance
- Returntype : `str[]`
- No Parameter
#### set_columns
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `str` | False | False |

#### set_columns
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `System.Collections.ArrayList` | False | False |

#### set_command
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | state | `YOLIB.rds+commandstate` | False | False |
| 2 | columnname | `str` | False | False |
| 3 | value | `str` | False | False |

#### insert
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `str` | False | False |

#### insert
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `System.Collections.ArrayList` | False | False |

#### insert
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `YOLIB.list` | False | False |

#### insert
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `str[]` | False | False |

#### delete
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

#### delete
- Re : Method
- Modifier : Instance
- Returntype : `i32`
- No Parameter
#### update
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |
| 2 | columnname | `str` | False | False |
| 3 | value | `str` | False | False |

#### update
- Re : Method
- Modifier : Instance
- Returntype : `i32`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | columnname | `str` | False | False |
| 2 | value | `str` | False | False |

#### get_row_map
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.map`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

#### get_row_list
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.list`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

#### get_row
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

#### get
- Re : Method
- Modifier : Instance
- Returntype : `str[]`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | index | `i32` | False | False |

#### get
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | rowindex | `i32` | False | False |
| 2 | colindex | `i32` | False | False |

#### get_column_items
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.list`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | colindex | `i32` | False | False |

#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter

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
#### set_compress
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `bool` | False | False |

#### add
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | value | `str` | False | False |

#### add
- Re : Method
- Modifier : Instance
- Returntype : `void`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | key | `str` | False | False |
| 2 | value | `str` | False | False |

#### get_list
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
#### get_map
- Re : Method
- Modifier : Instance
- Returntype : `str`
- No Parameter
#### WriteYODA
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `System.Collections.ArrayList` | False | False |
| 2 | compress | `bool` | True | False |

#### WriteYODA_Map
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | keys | `System.Collections.ArrayList` | False | False |
| 2 | values | `System.Collections.ArrayList` | False | False |
| 3 | compress | `bool` | True | False |

#### WriteYODA_Map
- Re : Method
- Modifier : Instance
- Returntype : `str`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | items | `System.Collections.ArrayList` | False | False |

#### ReadYODA
- Re : Method
- Modifier : Instance
- Returntype : `System.Collections.ArrayList`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | YODA_F | `str` | False | False |

#### ReadYODA_Map
- Re : Method
- Modifier : Instance
- Returntype : `YOLIB.yoda+YODAMapFormat`

| # | name | type |  Is Optional | Is Byref |
|--|--|--|--|--|
| 1 | YODA_F | `str` | False | False |

#### GetType
- Re : Method
- Modifier : Instance
- Returntype : `System.Type`
- No Parameter
