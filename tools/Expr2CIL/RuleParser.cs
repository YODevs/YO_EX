using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Emit;

namespace Expr2CIL
{
   
    /// <summary>
    /// RuleParser class is an abstract class that performs the scanning and 
    /// parsing of an expression. Parsing is started by calling the Run() function.  
    /// The parser doesn't take any actions, when an operation is found it calls
    /// the  abstract method. It is up to the inheriting classes to implement functions
    /// to execute the actions that should take place. Inherited classes must also 
    /// implement the Parse function which is the public method for performeing the parse.
    /// </summary>
    public abstract class RuleParser
    {
        #region Token Types
        // Value Tokens
        const int ttVariable = 3;  // Variable #PNAN#
        const int ttValue = 2;     // Static Value (String or number)
        const int ttNot = 4;       // Unary Not
        const int ttNeg = 24;      // Unary Minus
        const int ttFunc = 25;     // Function Variable

        // Conjunction Tokens
        const int ttAnd = 5;
        const int ttOr = 6;
        const int ttXor = 7;

        //Compare Tokens
        const int ttEQ = 13;
        const int ttNE = 14;
        const int ttLT = 15;
        const int ttGT = 16;
        const int ttLE = 17;
        const int ttGE = 18;

        // Arithmetic2 Tokens
        const int ttAdd = 8;
        const int ttSub = 9;

        // Arithmetic1 Tokens
        const int ttMul = 10;
        const int ttDiv1 = 11;
        const int ttDiv2 = 12;
        const int ttMod = 23;

        const int ttLP = 19;
        const int ttRP = 20;
        const int ttDot = 26;
        const int ttCma = 27;

        // Not yet implimented
        const int ttQue = 21;
        const int ttCol = 22;

        const int ttError = 99;
        const int ttNone = 1;
        #endregion

        #region Private Variables
        private int pos = 0;
        private int startPos = 0;
        private int expressionLength = 0;
        private bool tokenHandled = false;
        private String expression = "";
        private int tokenType;
        public Variant tokenValue;
        #endregion

        #region Semantic Action Events
        // Action Event Handlers

        /* Each type of token gets an Event handler.  When the parser comes
        across this type of token, instead of handling the token in the code
        it fires off the event handler.  This allows us to attach as many
        semantic events as we want seperately and not have to embed that
        logic in the parser code */

        // Conjunction Tokens
        protected abstract void matchAnd();
        protected abstract void matchOr();
        protected abstract void matchXor();

        // Compare Tokens
        protected abstract void matchEqual();
        protected abstract void matchNotEqual();
        protected abstract void matchLT();
        protected abstract void matchGT();
        protected abstract void matchLE();
        protected abstract void matchGE();

        // Arithmetic2 Tokens
        protected abstract void matchAdd();
        protected abstract void matchSub();

        // Arithmetic1 Tokens
        protected abstract void matchMult();
        protected abstract void matchDiv();
        protected abstract void matchMod();

        // Value Tokens
        protected abstract void matchVal();
        protected abstract void matchVar();
        protected abstract void matchFunc();
        protected abstract void matchNegate();
        protected abstract void matchNeg();
        protected abstract void matchParen();
        protected abstract void matchDot();
        protected abstract void matchComma();

        // Not yet implimented
        ////const int ttQue = 21;
        ////const int ttCol = 22;      
        #endregion

        #region Constructor
        public RuleParser()
        {
        }
        #endregion

        #region Initialize & Run

        /// <summary>
        /// Executes parsing of the given expression
        /// </summary>
        /// <param name="expr">String expression to be parsed</param>
        protected void Run(string expr)
        {
            Initialize(expr);

            // Start parsing here.  This function will return 
            // when it has parsed every token
            handleLogicalOperators();
        }

        /// <summary>
        /// Initialize the variables for parsing
        /// </summary>
        /// <param name="expr">String expression to be parsed</param>
        protected void Initialize(string expr)
        {
            tokenHandled = true;
            this.expression = expr;
            expressionLength = this.expression.Length;
            tokenType = ttNone;
            pos = 0;
        }
        #endregion

        #region Parsing Functions

        /// <summary>
        /// Reads an integer or double from the expression string and sets the
        /// this.tokenValue and this.tokenType
        /// </summary>
        private void readNumberToken()
        {
            // If this is first run, tokenValue is null.
            Variant prevToken = tokenValue;

            // We knows that the first character is a digit and can skip to the next character.
            pos++;

            // Moves the "pos" one step beyond the number.
            char nextChar = ' ';
            if (pos < expressionLength)
            {
                nextChar = expression[pos];
            }
            while (pos < expressionLength && (isDigit(nextChar) || nextChar == '.'))
            {
                pos++;
                if (pos < expressionLength) { nextChar = expression[pos]; }
            }

            // Retrieves all the characters that makes up the number.
            string readString = expression.Substring(startPos, pos - startPos); // "startPos" is set by the function "nextToken" prior to the call to this function!
            //testOutput("[readNumberToken] readString='"+readString+"'");

            // Converts the string to a int or a double.
            int n = 0;
            double d = 0;

            if (Int32.TryParse(readString, out n)) { tokenValue = new Variant(n); }
            else if (Double.TryParse(readString, out d)) { tokenValue = new Variant(d); }
            else { throw new Exception("Incorrect number: " + readString); }

            /*
            try{tokenValue = new PHVariant(int.Parse(readString));}
            catch{
                try
                {tokenValue = new PHVariant(Double.Parse(readString));}
                catch{throw new Exception("Incorrect number: " + readString);}
            }
             * */
        }

        /// <summary>
        /// Reads the value of a string. The value is supposed to end with 
        /// FirstChar. This function can also handle multiple string values 
        /// that are separed by commas.
        /// </summary>
        private void readStringToken()
        {
            // If this is first run, tokenValue is null.
            Variant prevToken = tokenValue;

            //testOutput("[readStringToken] executing");
            // We know that the first two characters are /"
            char firstChar = expression[pos];
            pos += 1;

            // Moves the "pos" one step beyond the string and its ending apostrophe or quotation mark.
            while (pos < expressionLength && expression[pos] != firstChar) { pos++; }
            if (pos >= expressionLength)
                throw new Exception("String without ending " + firstChar + "-sign. " + expression);
            pos++;

            // Retrieves the values of the string.
            string readString = expression.Substring(startPos + 1, (pos - startPos - 2));
            ////testOutput("[readStringToken] Value='"+readString+"'");

            // Sets the token value to the read string.
            tokenValue = new Variant(readString);
        }

        /// <summary>
        /// Reads the value of an element of the assembly.
        /// </summary>
        private void readDataToken()
        {
            // Store a reference to the token we are on right now
            Variant prevToken = tokenValue;
            string readDataStr = expression.Substring(startPos, (pos - startPos));
            tokenValue = new Variant(readDataStr);
        }

        /// <summary>
        /// Reads Arguments for occ and part functions
        /// </summary>
        private void readFunctionArgs()
        {
            // Argument list must be enclosed in parens (arg,arg,arg).  Throw and
            // error if the first character is not an open paren
            if (expression[pos] != '(')
            {
                tokenType = ttError;
                throw new Exception("Expected '(' Function must be followed by an argument list");
            }

            int startPos = pos;

            // Move to the end of the argument list. List should be closed by a ")"
            while (pos < expressionLength && expression[pos] != ')') { pos++; }

            // If there is no ')' then throw an error
            if (pos >= expressionLength)
            {
                tokenType = ttError;
                throw new Exception("No closing parenthesis on argument list. Expected ')'.");
            }
            pos++;
        }

        /// <summary>
        /// Reads next token if last token has been handled. After this function
        /// the variable "Pos" always points to the character immidiatly after 
        /// the last character of current token.
        /// </summary>
        private void nextToken()
        {
            if (tokenHandled)
            {
                tokenValue = null;

                // Steps past any white space before the token.
                while (pos < expressionLength && isWhitespace(expression[pos]))
                    pos++;

                startPos = pos;

                // Reads the first character of the token - will be used to determine the token type.
                char firstChar = ' ';
                if (pos < expressionLength)
                    firstChar = expression[pos];

                // -- Determines the token type --
                // End of expression?
                if (pos >= expressionLength)
                {
                    //testOutput("[nextToken] All characters have been read");
                    tokenType = ttNone;
                }
                // Number?
                else if (isDigit(firstChar))
                {
                    tokenType = ttValue;
                    readNumberToken();
                }
                // String?
                else if (firstChar == '\'' || firstChar == '"')
                {
                    //testOutput("[nextToken] reading string token");
                    tokenType = ttValue;
                    readStringToken();
                }
                // Dot Operator
                else if (firstChar == '.')
                {
                    pos++;
                    tokenType = ttDot;
                }
                else if (firstChar == ',')
                {
                    pos++;
                    tokenType = ttCma;
                }
                // Equal?
                else if (firstChar == '=')
                {
                    //testOutput("[nextToken] '=' token");
                    pos++;
                    tokenType = ttEQ;
                    // Support for double equal signs.
                    //if ((pos < expressionLength) && (expression[pos] == '='))
                    //    pos++;
                }
                // Not, not equal?
                else if (firstChar == '!')
                {
                    pos++;
                    if ((pos < expressionLength) && (expression[pos] == '='))
                    {
                        //testOutput("[nextToken] '!=' token");
                        pos++;
                        tokenType = ttNE;
                    }
                    else
                    {
                        //testOutput("[nextToken] '!' token");
                        tokenType = ttNot;
                    }
                }
                // Less than, less or equal, not equal?
                else if (firstChar == '<')
                {
                    pos++;
                    if ((pos < expressionLength) && (expression[pos] == '='))
                    {
                        //testOutput("[nextToken] '<=' token");
                        pos++;
                        tokenType = ttLE;
                    }
                    else if ((pos < expressionLength) && (expression[pos] == '>'))
                    {
                        //testOutput("[nextToken] '<>' token");
                        pos++;
                        tokenType = ttNE;
                    }
                    else
                    {
                        //testOutput("[nextToken] '<' token");
                        tokenType = ttLT;
                    }
                }
                // Greater than, greater and equal?
                else if (firstChar == '>')
                {
                    pos++;
                    if ((pos < expressionLength) && (expression[pos] == '='))
                    {
                        //testOutput("[nextToken] '>=' token");
                        pos++;
                        tokenType = ttGE;
                    }
                    else
                    {
                        //testOutput("[nextToken] '>' token");
                        tokenType = ttGT;
                    }
                }
                // 3/18/06 - CO - Not handling these operators
                // Question operator?
                /*else if (firstChar == '?')
                {
                    //testOutput("[nextToken] reading ? token");
                    pos++;
                    tokenType = ttQue;
                }
                // Colon (Expression separator)?
                else if (firstChar == ':')
                {
                    //testOutput("[nextToken] reading : token");
                    pos++;
                    tokenType = ttCol;
                }
                */
                // Left paranthes?
                else if (firstChar == '(')
                {
                    //testOutput("[nextToken] '(' token");
                    pos++;
                    tokenType = ttLP;
                }
                // Right paranthes?
                else if (firstChar == ')')
                {
                    //testOutput("[nextToken] ')' token");
                    pos++;
                    tokenType = ttRP;
                }

                // Plus?
                else if (firstChar == '+')
                {
                    //testOutput("[nextToken] '+' token");
                    pos++;
                    tokenType = ttAdd;
                }
                // Minus?
                else if (firstChar == '-')
                {
                    // Figure out if this is a subtraction or a unary minus operator
                    // The '-' is a subrtraction operator if the token before it
                    // is a variable, value, or right prenthesis.
                    if (tokenType == ttVariable || tokenType == ttValue || tokenType == ttRP)
                    {
                        tokenType = ttSub;
                        pos++;
                    }
                    // Everything else means that it has to be a unary minus
                    else
                    {
                        tokenType = ttNeg;
                        pos++;
                    }
                }

                else if (firstChar == '/')
                {// Float division?
                    //testOutput("[nextToken] '/' token");
                    pos++;
                    tokenType = ttDiv1;
                }
                // Multiplication?
                else if (firstChar == '*')
                {
                    //testOutput("[nextToken] '*' token");
                    pos++;
                    tokenType = ttMul;
                }
                // Variable, and, or, not, true, false?
                else if (isAlpha(firstChar) || firstChar == '_')
                {
                    pos++;

                    char nextChar = ' ';
                    if (pos < expressionLength)
                        nextChar = expression[pos];
                    while (pos < expressionLength && (isAlpha(nextChar) || isDigit(nextChar) || nextChar == '_'))
                    {
                        pos++;
                        if (pos < expressionLength)
                            nextChar = expression[pos];
                    }

                    string readString = string.Empty;
                    //try { 
                    readString = expression.Substring(startPos, pos - startPos);
                    string ustr = readString.ToUpper();
                    //}
                    //catch { }
                    //testOutput("[nextToken] readString="+readString+" startpos= "+ startPos + " pos="+ pos);

                    if (ustr == "AND") tokenType = ttAnd;
                    else if (ustr == "OR")
                        tokenType = ttOr;
                    else if (ustr == "XOR")
                        tokenType = ttXor;
                    else if (ustr == "NOT")
                        tokenType = ttNot;
                    else if (ustr == "TRUE")
                    {
                        tokenType = ttValue;
                        tokenValue = new Variant(true);
                    }
                    else if (ustr == "FALSE")
                    {
                        tokenType = ttValue;
                        tokenValue = new Variant(false);
                    }
                    else if (ustr == "NULL")
                    {
                        tokenType = ttValue;
                        tokenValue = new Variant(null);
                    }
                    else if (ustr == "DIV")
                        tokenType = ttDiv2;
                    else if (ustr == "MOD")
                        tokenType = ttMod;

                    // Handle Function Tokens
                    else if (isFunction(readString))
                    {
                        if (pos >= expressionLength)
                        {
                            throw new Exception("No argument list after function");
                        }
                        int argStart = pos;
                        readFunctionArgs();
                        tokenType = ttFunc;
                        tokenValue = new Variant(readString);

                        string argString = expression.Substring(argStart, pos - (argStart));
                        Variant args = new Variant(argString);
                        tokenValue.addVariantToList(args);

                    }

                    // otherwise, this may be a data token; attempt to read it.
                    else
                    {
                        tokenType = ttVariable;
                        readDataToken();
                    }
                }
                else
                {
                    // Unknown token => raises an exception.
                    tokenType = ttError;
                    throw new Exception("Unknown token starting with at pos '" + pos + "'." + expression);
                }
            }
            tokenHandled = true;
        }

        /// <summary>
        /// Handles the Dot operator for variables part.att.val
        /// </summary>
        private void handleDot()
        {
            //getValue();
            nextToken();
            bool tokenMatch = true;
            while (tokenMatch)
            {
                switch (tokenType)
                {
                    case ttDot:
                        //getValue();
                        nextToken();
                        matchDot();
                        nextToken();
                        //getValue();
                        break;
                    default:
                        tokenHandled = false;
                        tokenMatch = false;
                        break;
                }

            }
        }

        /// <summary>
        /// Returns the value of the token.
        /// </summary>
        private void getValue()
        {
            nextToken();
            switch (tokenType)
            {
                case ttValue:
                    matchVal();
                    break;
                case ttFunc:
                    matchFunc();
                    break;
                case ttVariable:
                    matchVar();
                    handleDot();
                    break;
                case ttLP:
                    handleLogicalOperators();
                    nextToken();
                    if (tokenType != ttRP) throw new Exception("Expected right parenthesis." + expression);
                    matchParen();
                    handleDot();
                    break;
                case ttNot:
                    getValue();
                    matchNegate();
                    //nextToken();
                    break;
                case ttNeg:
                    getValue();
                    matchNeg();
                    //nextToken();
                    break;
                default:
                    tokenHandled = false;
                    throw new Exception("Unexpected token." + expression);
            }
        }

        /// <summary>
        /// Handles Unary Operators.
        /// </summary>
        private void handleUnaryOperators()
        {
            getValue();
            nextToken();
            bool tokenMatch = true;
            while (tokenMatch)
            {
                switch (tokenType)
                {
                    case ttCma:
                        getValue();
                        matchComma();
                        nextToken();
                        break;
                    default:
                        tokenHandled = false;
                        tokenMatch = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Handles multiplication and division.
        /// </summary>
        private void handleArithmeticOperators1()
        {
            handleUnaryOperators();
            nextToken();
            bool tokenMatch = true;
            while (tokenMatch)
            {
                switch (tokenType)
                {
                    case ttMul:
                        handleUnaryOperators();
                        matchMult();
                        nextToken();
                        break;
                    case ttDiv1:
                        handleUnaryOperators();
                        matchDiv();
                        nextToken();
                        break;
                    case ttDiv2:
                        this.handleUnaryOperators();
                        matchDiv();
                        nextToken();
                        break;
                    case ttMod:
                        handleUnaryOperators();
                        matchMod();
                        nextToken();
                        break;
                    default:
                        tokenHandled = false;
                        tokenMatch = false;
                        break;
                }

            }
        }

        /// <summary>
        /// Handles addition and subtraction.
        /// </summary>
        private void handleArithmeticOperators2()
        {
            handleArithmeticOperators1();
            nextToken();
            bool tokenMatch = true;
            while (tokenMatch)
            {
                switch (tokenType)
                {
                    case ttAdd:
                        handleArithmeticOperators1();
                        matchAdd();
                        nextToken();
                        break;
                    case ttSub:
                        handleArithmeticOperators1();
                        matchSub();
                        nextToken();
                        break;
                    default:
                        tokenHandled = false;
                        tokenMatch = false;
                        break;
                }

            }
        }

        /// <summary>
        /// Handles equality, inequality, less-than, greater-than, 
        /// less-than-or-equal-to greater-than-or-equal-to.
        /// </summary>
        private void handleRelationalOperators()
        {
            handleArithmeticOperators2();
            nextToken();
            bool tokenMatch = true;
            while (tokenMatch)
            {
                switch (tokenType)
                {
                    case ttEQ:
                        handleArithmeticOperators2();
                        matchEqual();
                        nextToken();
                        break;
                    case ttNE:
                        handleArithmeticOperators2();
                        matchNotEqual();
                        nextToken();
                        break;
                    case ttLT:
                        handleArithmeticOperators2();
                        matchLT();
                        nextToken();
                        break;
                    case ttLE:
                        handleArithmeticOperators2();
                        matchLE();
                        nextToken();
                        break;
                    case ttGT:
                        handleArithmeticOperators2();
                        matchGT();
                        nextToken();
                        break;
                    case ttGE:
                        handleArithmeticOperators2();
                        matchGE();
                        nextToken();
                        break;
                    default:
                        tokenHandled = false;
                        tokenMatch = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Handles conjuncation (and) and disjungation (or).
        /// </summary>
        private void handleLogicalOperators()
        {
            handleRelationalOperators();
            nextToken();
            bool tokenMatch = true;
            while (tokenMatch)
            {
                switch (tokenType)
                {
                    case ttAnd:
                        handleRelationalOperators();
                        matchAnd();
                        nextToken();
                        break;
                    case ttOr:
                        handleRelationalOperators();
                        matchOr();
                        nextToken();
                        break;
                    case ttXor:
                        handleRelationalOperators();
                        matchXor();
                        nextToken();
                        break;
                    default:
                        tokenHandled = false;
                        tokenMatch = false;
                        break;
                }
            }
        }

        /*********************************************************************
        Handles the ternary operator "?:".
        In the expression E1?E2:E3, E1 evaluates first. If its value is true,
        then E2 evaluates and E3 is ignored. If E1 evaluates to false, then E3
        evaluates and E2 is ignored.
        *********************************************************************
         WE are not supporting the condition operator ()? : 
        public PHVariant handleConditionOperator()
        {
            handleLogicalOperators();
            nextToken();
            if (tokenType == ttQue)
            {
                PHVariant Value1 = handleLogicalOperators();
                nextToken();
                if (tokenType != ttCol) throw new Exception("Expected colon."+ expression);
                PHVariant Value2 = handleLogicalOperators();
                tokenHandled = false;
                if ((bool)Value.Value)
                    return Value1;
                else
                    return Value2;
            }
            else
            {
                tokenHandled = false;
                return Value;
            }
        }
         */
        #endregion

        #region Utility Functions

        /// <summary>
        /// Determines if a character can be considered whitespace.  Right now
        /// we are just checking spaces, but this could include tabs and other
        /// </summary>
        private static bool isWhitespace(char c)
        {
            return (char.IsWhiteSpace(c));
        }

        /// <summary>
        /// Determines if a character can be considered a digit
        /// </summary>
        private static bool isDigit(char c)
        {
            return (c >= '0' && c <= '9');
        }

        /// <summary>
        /// Determines if a character can be considiered an alphebetic letter
        /// </summary>
        private static bool isAlpha(char c)
        {
            return (
                   (c >= 'a' && c <= 'z')
                || (c >= 'A' && c <= 'Z')
                || c == 'å' || c == 'Å'
                || c == 'ä' || c == 'Ä'
                || c == 'ö' || c == 'Ö'
                );

        }

        /// <summary>
        /// Determines if a string is a reserved function name
        /// </summary>
        private static bool isFunction(string s)
        {
            string str = s.ToUpper();
            return (false);
        }
        #endregion

    }

   
}



