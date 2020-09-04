using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;

namespace Expr2CIL
{
    /// <summary>
    /// Expr2CIL implements the abstract RuleParser class and compiles 
    /// the statement to a dynamic method
    /// </summary>
    public class Expr2CIL : RuleParser
    {
       private  string ILCode , datatype;
        public delegate TReturn ExpressionInvoker<TReturn>();
       
        /// <summary>
        /// This is just a test function that supplies variables with values
        /// </summary>
        public static double GetVar(string var)
        {
            switch (var)
            {
                case "a": return 100;
                case "b": return 200;
                case "c": return 300;
                case "d": return 400;
                default: return 500;
            }
        }
        
        /// <summary>
        /// Builds and returns a dynamic assembly
        /// </summary>
        public string  CompileMsil(string expression , string datatype)
        {
            // Parse the expression.  This will insert MSIL instructions
            this.datatype = datatype;
            this.Run(expression);
            return ILCode;
        }

        #region Semantic Actions for Parse Functions
        
        protected override void matchAnd()
        {
            throw new NotImplementedException();
        }

        protected override void matchOr()
        {
            throw new NotImplementedException();
        }

        protected override void matchAdd()
        {
            insertILCode("add");
        }

        protected override void matchComma()
        {
            throw new NotImplementedException();
        }

        protected override void matchDiv()
        {
            insertILCode("div");
        }

        protected override void matchDot()
        {
            throw new NotImplementedException();
        }

        protected override void matchEqual()
        {
            throw new NotImplementedException();
        }

        protected override void matchFunc()
        {
            throw new NotImplementedException();
        }

        protected override void matchGE()
        {
            throw new NotImplementedException();
        }

        protected override void matchGT()
        {
            throw new NotImplementedException();
        }

        protected override void matchLE()
        {
            throw new NotImplementedException();
        }

        protected override void matchLT()
        {
            throw new NotImplementedException();
        }

        protected override void matchMod()
        {
            throw new NotImplementedException();
        }

        protected override void matchMult()
        {
            insertILCode("mul");
        }

        protected override void matchNeg()
        {
            throw new NotImplementedException();
        }

        protected override void matchNegate()
        {
            throw new NotImplementedException();
        }

        protected override void matchNotEqual()
        {
            throw new NotImplementedException();
        }

        protected override void matchParen()
        {
            // No action required
        }

        protected override void matchSub()
        {
            insertILCode("sub");
          //  this.il.Emit(OpCodes.Sub);
        }

        protected override void matchVal()
        {
            switch (this.tokenValue.Type)
            {
                case VariantType.DOUBLE:
                    if (this.datatype == "i32")
                    {
                        if (Convert.ToDecimal(this.tokenValue.Value) > Int32.MaxValue || Convert.ToDecimal(this.tokenValue.Value) < Int32.MinValue)
                        {
                            insertILCode("ldc.i8 " + Convert.ToInt64 (this.tokenValue.Value));
                        }
                        else {
                            insertILCode("ldc.i4 " + Convert.ToInt32 (this.tokenValue.Value));
                        }
                    }
                    else {
                        insertILCode("ldc.r8 " + Convert.ToDouble(this.tokenValue.Value));
                    }
                    break;
                case VariantType.INT:

                    if (this.datatype == "i32")
                    {
                        if (Convert.ToDecimal(this.tokenValue.Value) > Int32.MaxValue || Convert.ToDecimal(this.tokenValue.Value) < Int32.MinValue)
                        {
                            insertILCode("ldc.i8 " + Convert.ToInt64(this.tokenValue.Value));
                        }
                        else
                        {
                            insertILCode("ldc.i4 " + Convert.ToInt32(this.tokenValue.Value));
                        }
                    }
                    else
                    {
                        insertILCode("ldc.r8 " + Convert.ToDouble(this.tokenValue.Value));
                    }

                    break;
                default:
                    throw new Exception("Invalid TokenType");
            }
        }

        protected override void matchVar()
        {
            string name = tokenValue.ToString();
                insertILCode(">" + name);
        }

        protected override void matchXor()
        {
            throw new NotImplementedException();
        }
        #endregion

        protected  void insertILCode(string ilcode)
        {
            ILCode += "\n" + ilcode;
        }
    }
}