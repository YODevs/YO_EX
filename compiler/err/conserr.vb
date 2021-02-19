Public Class conserr
    Enum errortype
        DIRNOTFOUND
        YOFILENOTFOUND
        TYPEERRORNUMERIC
        RUNTIMEERROR
        IDENTIFIERUNKNOWN
        STRINGDUENDWITH
        STRINGCOENDWITH
        IDENTIFIEREXPECTED
        FUNCOPBRACKETEXPECTED
        BLOCKOPENEXPECTED
        SYNTAXERROR
        MISSINGESSENTIALFILES
        DECLARINGERROR
        TYPENOTFOUND
        ERRORINCONVERT
        EXPLICITCONVERSION
        CONSTANTNUMOUTOFRANGE
        CILCOMMANDSENDWITH
        CILCOMMANDSAUTH
        CILLAZYERROR
        ATTRIBUTECLASSERROR
        ATTRIBUTEPROPERTYERROR
        ATTRIBUTESTRUCTERROR
        ATTRIBUTEDISABLED
        ASSIGNCONVERT
        EXPRESSIONERROR
        INTEGRALOVERFLOW
        INVALIDCODEBLOCK
        EXPECTSYNTAX
        PARAMCLIERROR
        JMPERROR
        CONTINUEERROR
        BREAKERROR
        PROJECTSTRUCTERROR
        OPERATORUNKNOWN
        ASMERROR
        EXPECTEDERROR
        METHODERROR
        ARGUMENTERROR
        CLASSVAILDERROR
        CONSTANTVALERROR
        FIELDERROR
        BADACCESSCONTROL
        CONSTANTASSIGNMENTERROR
        RETURNERROR
        EXPRMETHODERROR
        MATCHERROR
        UNDEFINEDPARAM
        OVERLOADERROR
        INCLUDEERROR
        TARGETFRAMEWORKERROR
        CONSTRUCTORERROR
    End Enum

    Enum errorpriority
        IGNORE
        [STOP]
    End Enum
    Structure errorstruct
        Dim title As String
        Dim text As String
        Dim err As errortype
        Dim priority As errorpriority
    End Structure

    Public Shared err() As errorstruct
    Public Shared Sub set_new_error(errtype As errortype, errpriority As errorpriority, title As String, text As String)
        Static Dim indexarray As Int16 = 0
        Array.Resize(err, indexarray + 1)
        err(indexarray) = New errorstruct
        err(indexarray).err = errtype
        err(indexarray).priority = errpriority
        err(indexarray).title = title.ToUpper
        err(indexarray).text = text
        indexarray += 1
        Return
    End Sub

    Public Shared Sub init_error_struct()
        set_new_error(errortype.DIRNOTFOUND, errorpriority.STOP, "Directory not found", "Folder containing '.yo' files not found.")
        set_new_error(errortype.YOFILENOTFOUND, errorpriority.STOP, "YO file not found", "Project files [.yo] not found.")
        set_new_error(errortype.TYPEERRORNUMERIC, errorpriority.STOP, "Unknown numeric format", "Unknown numeric format found during code analysis.")
        set_new_error(errortype.RUNTIMEERROR, errorpriority.STOP, "Runtime error", "An unknown error occurred while running.")
        set_new_error(errortype.IDENTIFIERUNKNOWN, errorpriority.STOP, "Identifier unknown", "Identifier validation is ambiguous.
An identifier can contain numbers, letters, and '_'.
An identifier cannot start with a number.")
        set_new_error(errortype.STRINGDUENDWITH, errorpriority.STOP, "String constant error", "String constants must end with a double quote ("").")
        set_new_error(errortype.STRINGCOENDWITH, errorpriority.STOP, "String constant error", "String constants must end with a single quote (').")
        set_new_error(errortype.IDENTIFIEREXPECTED, errorpriority.STOP, "Critical error", "Identifier expected.")
        set_new_error(errortype.FUNCOPBRACKETEXPECTED, errorpriority.STOP, "Critical error", "Method arguments must be enclosed in parentheses.")
        set_new_error(errortype.FUNCOPBRACKETEXPECTED, errorpriority.STOP, "Critical error", "Expected '{’ ,to start a block of code.")
        set_new_error(errortype.FUNCOPBRACKETEXPECTED, errorpriority.STOP, "Critical error", "Syntax error.")
        set_new_error(errortype.MISSINGESSENTIALFILES, errorpriority.STOP, "Missing essential files", "Some software files were not found.
You can reinstall the software or email us.")
        set_new_error(errortype.DECLARINGERROR, errorpriority.STOP, "Declaring error", "This local variable is already declared in the current block.")
        set_new_error(errortype.TYPENOTFOUND, errorpriority.STOP, "Identifier unknown", "'{0}' is not declared. It may be inaccessible due to its protection level.")
        set_new_error(errortype.ERRORINCONVERT, errorpriority.STOP, "Assignment error", "Constant value '{0}' cannot be converted to a '{1}'.")
        set_new_error(errortype.EXPLICITCONVERSION, errorpriority.STOP, "Explicit conversion error", "Cannot implicitly convert type '{0}' to '{1}'.")
        set_new_error(errortype.CONSTANTNUMOUTOFRANGE, errorpriority.STOP, "Constant out of range", "'{0}' - The numeric constant is out of the data range. MAX = '{1}'  -   MIN = '{2}'")
        set_new_error(errortype.CILCOMMANDSENDWITH, errorpriority.STOP, "Cil commands error", "CIL block codes must end with a (>).")
        set_new_error(errortype.CILCOMMANDSAUTH, errorpriority.STOP, "Cil commands error", "CIL - Code block validation error.")
        set_new_error(errortype.CILLAZYERROR, errorpriority.STOP, "Cil commands error", "Intermediate grammar for injection is not valid.")
        set_new_error(errortype.ATTRIBUTECLASSERROR, errorpriority.STOP, "Attribute error", " '{0}' - This collection was not found.")
        set_new_error(errortype.ATTRIBUTEPROPERTYERROR, errorpriority.STOP, "Attribute error", " '{0}' - This property was not found.")
        set_new_error(errortype.ATTRIBUTESTRUCTERROR, errorpriority.STOP, "Attribute error", "The structure of the attribute is unknown (note that the structure has no spaces and characters like ("") or (').")
        set_new_error(errortype.ATTRIBUTEDISABLED, errorpriority.STOP, "Attribute error", "[{0}] - Access to this feature is disabled, enable it with feature {1} if needed.")
        set_new_error(errortype.ASSIGNCONVERT, errorpriority.STOP, "Assignment error", "'{0}' - Cannot be assignment to [type] -> '{1}'.")
        set_new_error(errortype.EXPRESSIONERROR, errorpriority.STOP, "Expression error", "{0}")
        set_new_error(errortype.INTEGRALOVERFLOW, errorpriority.STOP, "Integral overflow error", "'{0}' , Integral constant is too large.(overflow)")
        set_new_error(errortype.INVALIDCODEBLOCK, errorpriority.STOP, "Code block error", "Invalid code block , this block header could not be reached.")
        set_new_error(errortype.EXPECTSYNTAX, errorpriority.STOP, "Code block error", "In the {0} grammatical structure, '{1}' is expected.")
        set_new_error(errortype.PARAMCLIERROR, errorpriority.IGNORE, "CLI error", "Invalid input")
        set_new_error(errortype.JMPERROR, errorpriority.STOP, "Jump statement error", "An error occurred in the Jump Statement.")
        set_new_error(errortype.CONTINUEERROR, errorpriority.STOP, "Continue statement error", "An error occurred in the Continue Statement.")
        set_new_error(errortype.BREAKERROR, errorpriority.STOP, "Break statement error", "An error occurred in the Break Statement.")
        set_new_error(errortype.PROJECTSTRUCTERROR, errorpriority.STOP, "Project structure error", "'{0}' path not found.")
        set_new_error(errortype.OPERATORUNKNOWN, errorpriority.STOP, "Operator unknown", "'{0}' Could not be identified as an operator")
        set_new_error(errortype.ASMERROR, errorpriority.STOP, "Assembly error", "An error occurred in the assembly resources.")
        set_new_error(errortype.EXPECTEDERROR, errorpriority.STOP, "Syntax error", "'{0}' expected.")
        set_new_error(errortype.METHODERROR, errorpriority.STOP, "Method error", "{0}")
        set_new_error(errortype.ARGUMENTERROR, errorpriority.STOP, "Argument error", "{0}")
        set_new_error(errortype.CLASSVAILDERROR, errorpriority.STOP, "Class validation error", "'{0}' , This class has already been created.")
        set_new_error(errortype.CONSTANTVALERROR, errorpriority.STOP, "Constant error", "Constants must have a value.")
        set_new_error(errortype.FIELDERROR, errorpriority.STOP, "Field error", "{0}")
        set_new_error(errortype.BADACCESSCONTROL, errorpriority.STOP, "Access control error", "'{0}' , cannot be identified as an access control.")
        set_new_error(errortype.CONSTANTASSIGNMENTERROR, errorpriority.STOP, "Constant error", "'{0}' , Constant cannot be the target of an assignment.")
        set_new_error(errortype.RETURNERROR, errorpriority.STOP, "Return error", "The 'Return' command requires a value of type '{0}' to return.")
        set_new_error(errortype.EXPRMETHODERROR, errorpriority.STOP, "Expression method error", "'{0}' , Argument are not allowed for an expr method.")
        set_new_error(errortype.MATCHERROR, errorpriority.STOP, "Match error", "{0}")
        set_new_error(errortype.UNDEFINEDPARAM, errorpriority.STOP, "CIL error", "Undefined input parameters.")
        set_new_error(errortype.OVERLOADERROR, errorpriority.STOP, "Overload error", "Overload resolution failed because no accessible '{0}' is most specific for these arguments.")
        set_new_error(errortype.INCLUDEERROR, errorpriority.STOP, "Include error", "{0}")
        set_new_error(errortype.TARGETFRAMEWORKERROR, errorpriority.STOP, "Target framework error", "The target version of the framework ({0}) is not installed on this system.")
        set_new_error(errortype.CONSTRUCTORERROR, errorpriority.STOP, "Constructor error", "The initial value of the object is incorrect.")
    End Sub
End Class
