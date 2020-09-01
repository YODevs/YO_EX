using System;
using System.Collections.Generic;
using System.Text;


namespace Expr2CIL
{
    public enum VariantType
    {
        BOOL = 1, INT, DOUBLE, STRING, VAR, NULL
    }

    /// <summary>
    /// Variant is a generic value object that handles different data types
    /// Its functions allow you to compare, multiply, divide, etc... values
    /// of different types. Data types allowed are bool, int, double and string
    /// </summary>
    public class Variant
    {
        private bool _boolVal;
        private int _intVal;
        private double _doubleVal;
        private string _stringVal;
        private VariantType _type;

        // list management variables
        public Variant next = null;
        public Variant first = null;

        // Bit mask constants for comparision results.
        public const int crLT = 1;
        public const int crEQ = 2;
        public const int crGT = 4;
        public const int crNE = 8; // Used when comparing booleans or strings.
        public const int crError = -1;

        #region Constructors
        // Constructors:  One constuctor for each type of variant
        public Variant(bool val)
        {
            _boolVal = val;
            _type = VariantType.BOOL;
        }
        public Variant(int val)
        {
            _intVal = val;
            _type = VariantType.INT;
        }
        public Variant(double val)
        {
            _doubleVal = val;
            _type = VariantType.DOUBLE;
        }
        public Variant(string val)
        {
            if (val == null || val == "")
            {
                _type = VariantType.NULL;

                _stringVal = "";

            }
            else
            {
                _stringVal = val;
                _type = VariantType.STRING;
            }
        }
        public Variant(VariantType p, string s)
        {
            if (p == VariantType.VAR)
            {
                _type = p;
                _stringVal = s;
            }
            else throw new Exception("Invalid variant type");
        }

        #endregion

        #region Accessors
        // Returns the value of the variant depending on is current type
        /***************************************************
        *                  VALUE
        ***************************************************/
        public virtual Object Value
        {
            get
            {
                switch (_type)
                {
                    case VariantType.INT:
                        return (Object)_intVal;
                    case VariantType.BOOL:
                        return (Object)_boolVal;
                    case VariantType.DOUBLE:
                        return (Object)_doubleVal;
                    case VariantType.STRING:
                    case VariantType.VAR:
                    case VariantType.NULL:
                        return (Object)_stringVal;
                    default:
                        throw new Exception("Invalid variant type");
                }
            }
        }

        /***************************************************
        *                  TYPE
        ***************************************************/
        public VariantType Type
        {
            get { return _type; }
        }
        #endregion

        /***************************************************
        *                  TO STRING
        ***************************************************/
        public override String ToString()
        {
            switch (_type)
            {
                case VariantType.BOOL:
                    return _boolVal.ToString();
                case VariantType.INT:
                    return _intVal.ToString();
                case VariantType.DOUBLE:
                    return _doubleVal.ToString();
                case VariantType.STRING:
                case VariantType.VAR:
                    return _stringVal;
                case VariantType.NULL:
                    return "null";
                default:
                    return "";
            }
        }

        /***************************************************
        *                  IS LIST TYPE
        ***************************************************/
        public bool IsListType
        {
            get { return first != null; }
        }

        # region Functions called by Arithmetic1Operation
        /// <summary>
        /// Performs multiplication on two variant objects and returns the result as
        /// a new variant. Only doubles and ints can be multiplied.
        /// </summary>
        /***************************************************
        *                  MULTIPLY
        ***************************************************/
        public static Variant Mult(Variant var1, Variant var2)
        {
            int bitComb = BitCombination(var1, var2);
            Variant result = null;

            if ((bitComb & 306) != 0)               // bool, string, Assy, Part
                throw new Exception("Could not be multiplied due to variant types.");
            else if (ConvertsToInt(var1, var2))     // all other types
                result = new Variant(Convert.ToInt32(var1.Value) * Convert.ToInt32(var2.Value));
            else if (ConvertsToDbl(var1, var2))     // all other types
                result = new Variant(Convert.ToDouble(var1.Value) * Convert.ToDouble(var2.Value));
            else
                throw new Exception("Could not be multiplied due to variant types.");

            return result;
        }
        /***************************************************
        *                  DIVIDE
        ***************************************************/
        public static Variant Div(Variant var1, Variant var2)
        {
            int bitComb = BitCombination(var1, var2);
            Variant result = null;

            if ((bitComb & 306) != 0)               // bool, string, Assy, Part
                throw new Exception("Could not be divided due to variant types.");
            else if (ConvertsToInt(var1, var2))     // all other types
                result = new Variant(Convert.ToInt32(var1.Value) / Convert.ToInt32(var2.Value));
            else if (ConvertsToDbl(var1, var2))     // all other types
                result = new Variant(Convert.ToDouble(var1.Value) / Convert.ToDouble(var2.Value));
            else
                throw new Exception("Could not be divided due to variant types.");

            return result;
        }
        /***************************************************
        *                  MODULUS
        ***************************************************/
        public static Variant Mod(Variant var1, Variant var2)
        {
            int bitComb = BitCombination(var1, var2);
            Variant result = null;

            if ((bitComb & 306) != 0)               // bool, string, Assy, Part
                throw new Exception("Unable to perform operation due to variant types.");
            else if (ConvertsToInt(var1, var2))     // all other types
                result = new Variant(Convert.ToInt32(var1.Value) % Convert.ToInt32(var2.Value));
            else if (ConvertsToDbl(var1, var2))     // all other types
                result = new Variant(Convert.ToDouble(var1.Value) % Convert.ToDouble(var2.Value));
            else
                throw new Exception("Unable to perform operation due to variant types.");

            return result;
        }
        /***************************************************
        *                  NEGATE
        ***************************************************/
        public static Variant Negate(Variant var1)
        {
            Variant result = null;
            if (var1.Type == VariantType.BOOL)
                result = new Variant(!(bool)var1.Value);
            else
                throw new Exception("Could not negate because variant was not boolean.");

            return result;
        }
        #endregion

        #region Functions called by Arithmetic2Operation
        /***************************************************
        *                  ADD
        ***************************************************/
        public static Variant Add(Variant var1, Variant var2)
        {
            int bitComb = BitCombination(var1, var2);
            Variant result = null;

            if ((bitComb & 290) != 0)               // bool, Assy, Part
                throw new Exception("Could not be added due to variant types.");
            else if (bitComb == 16)                 // strings
                result = new Variant(var1.Value.ToString() + var2.Value.ToString());
            else if (ConvertsToInt(var1, var2))     // all other types
                result = new Variant(Convert.ToInt32(var1.Value) + Convert.ToInt32(var2.Value));
            else if (ConvertsToDbl(var1, var2))     // all other types
                result = new Variant(Convert.ToDouble(var1.Value) + Convert.ToDouble(var2.Value));
            else
                throw new Exception("Could not be added due to variant types.");

            return result;
        }
        /***************************************************
        *                  SUBTRACT
        ***************************************************/
        public static Variant Sub(Variant var1, Variant var2)
        {
            int bitComb = BitCombination(var1, var2);
            Variant result = null;

            if ((bitComb & 306) != 0)               // bool, string, Assy, Part
                throw new Exception("Could not be subtracted due to variant types.");
            else if (ConvertsToInt(var1, var2))     // all other types
                result = new Variant(Convert.ToInt32(var1.Value) - Convert.ToInt32(var2.Value));
            else if (ConvertsToDbl(var1, var2))     // all other types
                result = new Variant(Convert.ToDouble(var1.Value) - Convert.ToDouble(var2.Value));
            else
                throw new Exception("Could not be subtracted due to variant types.");

            return result;
        }
        #endregion

        #region Functions called by CompareOperation
        /***************************************************
        *                  COMPARE LIST
        ***************************************************/
        private static bool compareList(Variant l, Variant r, int rslt)
        {
            // Both left and right arguments cannot be lists
            if (l.IsListType && r.IsListType)
                throw new Exception("Cannot compare a list to a list");

            // If neither are lists, just run the compare
            if (!l.IsListType && !r.IsListType)
                return (compare(l, r) == rslt);

            // Figure out which argument is the list and which is not
            Variant lst, nlst;
            lst = (l.IsListType) ? l : r;
            nlst = (l.IsListType) ? r : l;
            // Loop through each value in the list and compare it to
            // each non-list value.  If any one of the values in the
            // list are less then return true;
            while (lst != null)
            {
                int temp = compare(l, r);
                if (temp == rslt) return true;
                if (lst == l) lst = l = l.next;
                else if (lst == r) lst = r = r.next;
            }
            // None matched, so return false
            return false;
        }

        public static bool LessThan(Variant l, Variant r)
        {
            return compareList(l, r, crLT);
        }

        public static bool GreaterThan(Variant l, Variant r)
        {
            return compareList(l, r, crGT);
        }

        public static bool EqualTo(Variant l, Variant r)
        {
            return compareList(l, r, crEQ);
        }

        private static int compare(Variant lValue, Variant rValue)
        {
            int returnVal = 0;
            VariantType lType = lValue.Type;
            VariantType rType = rValue.Type;

            // BOOL and BOOL
            if (lType == VariantType.BOOL &&
                rType == VariantType.BOOL)
            {
                Console.WriteLine("BOTH SIDES BOOLEAN");
                if ((bool)lValue.Value == (bool)rValue.Value)
                    returnVal = crEQ;
                else
                    returnVal = crNE;
            }
            // BOOL and any other variant type (other than BOOL)
            else if (lType == VariantType.BOOL ||
                     rType == VariantType.BOOL)
            {
                returnVal = crNE;
            }
            // STRING and STRING
            else if (lType == VariantType.STRING &&
                     rType == VariantType.STRING)
            {
                returnVal = CompareString(lValue.Value.ToString(), rValue.Value.ToString());
            }
            // STRING and any other variant type (other than BOOL and STRING)
            else if (lType == VariantType.STRING ||
                     rType == VariantType.STRING)
            {
                Variant l = (lType == VariantType.STRING) ? lValue : rValue;
                Variant r = (lType == VariantType.STRING) ? rValue : lValue;

                if (r.Type == VariantType.INT ||
                    r.Type == VariantType.DOUBLE)
                {
                    returnVal = crNE;
                }
                else
                {
                    returnVal = CompareString(l.Value.ToString().Trim(), r.Value.ToString().Trim());
                }

                // switch return value if right param is type string
                if (rType == VariantType.STRING)
                {
                    if (returnVal == crGT)
                        returnVal = crLT;
                    else if (returnVal == crLT)
                        returnVal = crGT;
                }
            }
            // compare values as doubles
            else if (lType == VariantType.INT ||
                lType == VariantType.DOUBLE ||
                rType == VariantType.INT ||
                rType == VariantType.DOUBLE)
            {
                if (ConvertsToDbl(lValue, rValue))
                {
                    returnVal = CompareDouble(Convert.ToDouble(lValue.Value), Convert.ToDouble(rValue.Value));
                }
                else
                {
                    returnVal = crNE;
                }
            }
            // compare ASSYATTR, ASSYVALUE, PARTATTR, PARTVALUE
            else
            {
                if (ConvertsToDbl(lValue, rValue))
                {
                    returnVal = CompareDouble(Convert.ToDouble(lValue.Value), Convert.ToDouble(rValue.Value));
                }
                else
                {
                    string l = lValue.Value.ToString();
                    string r = rValue.Value.ToString();
                    returnVal = CompareString(l, r);
                }
            }

            return returnVal;
        }

        private static int CompareDouble(double l, double r)
        {
            if (l == r)
                return crEQ;
            else if (l > r)
                return crGT;
            else if (l < r)
                return crLT;
            else
                return crNE;
        }

        private static int CompareString(string l, string r)
        {
            if (System.String.Compare(l, r) == 0)
                return crEQ;
            else if (System.String.Compare(l, r) > 0)
                return crGT;
            else if (System.String.Compare(l, r) < 0)
                return crLT;
            else
                return crNE;
        }
        #endregion

        #region Functions called by ConjunctionOperation
        public static Variant And(Variant var1, Variant var2)
        {
            Variant result = null;
            if (var1.Type == VariantType.BOOL && var2.Type == VariantType.BOOL)
            {
                if (((bool)var1.Value == true) && ((bool)var2.Value == true))
                    result = new Variant(true);
                else
                    result = new Variant(false);
            }
            else
                throw new Exception("Variants must both be boolean for 'and' operation.");
            return result;
        }
        public static Variant Or(Variant var1, Variant var2)
        {
            Variant result = null;
            if (var1.Type == VariantType.BOOL && var2.Type == VariantType.BOOL)
            {
                if (((bool)var1.Value == true) || ((bool)var2.Value == true))
                    result = new Variant(true);
                else
                    result = new Variant(false);
            }
            else
                throw new Exception("Variants must both be boolean for 'or' operation.");
            return result;
        }
        public static Variant Xor(Variant var1, Variant var2)
        {
            Variant result = null;
            if (var1.Type == VariantType.BOOL && var2.Type == VariantType.BOOL)
            {
                if (((bool)var1.Value == true) ^ ((bool)var2.Value == true))
                    result = new Variant(true);
                else
                    result = new Variant(false);
            }
            else
                throw new Exception("Variants must both be boolean for xor.");
            return result;
        }
        #endregion

        #region List Management
        public void addVariantToList(Variant newVariant)
        {
            // Steps to the end of the list.
            Variant variant = this;
            while (variant.next != null)
                variant = variant.next;

            // Puts the attached object as the new end of the list.
            variant.next = newVariant;

            // If "first" is null, this shuld be the first variant in list.
            if (first == null) first = this;

            if (newVariant.IsListType)
            {
                while (newVariant.next != null)
                {
                    newVariant = newVariant.next;
                    newVariant.first = first;
                }
            }
            variant.next.first = first;
        }
        public int listCount()
        {
            if (first == null)
                return 1;

            Variant variant = first;
            int counter = 1;
            while (variant.next != null)
            {
                variant = variant.next;
                counter++;
            }
            return counter;
        }
        #endregion

        #region Helper Functions
        public static int BitCombination(Variant phv1, Variant phv2)
        {
            double lBit = Math.Pow(2, Convert.ToDouble(phv1.Type));
            double rBit = Math.Pow(2, Convert.ToDouble(phv2.Type));
            return (Convert.ToInt32(lBit) | Convert.ToInt32(rBit));
        }

        private static bool ConvertsToInt(Variant phv1, Variant phv2)
        {
            if (phv1.Value.ToString().IndexOf(".") != -1 || phv2.Value.ToString().IndexOf(".") != -1)
                return false;

            try
            {
                Convert.ToInt32(phv1.Value);
                Convert.ToInt32(phv2.Value);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static bool ConvertsToDbl(Variant phv1)
        {
            try
            {
                Convert.ToDouble(phv1.Value);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static bool ConvertsToDbl(Variant phv1, Variant phv2)
        {
            try
            {
                Convert.ToDouble(phv1.Value);
                Convert.ToDouble(phv2.Value);
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion




    }

}
