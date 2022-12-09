using Stx.Shared.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Stx.Shared
{
    public class Conv
    {
        #region Integer

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A integer that is equivalent to the number in value, or 0 if the value is null..</para>
        ///<para>Exceptions: s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static int TryInt(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            try { return Convert.ToInt32(s); }
            catch { }
            return 0;
        }

        public static int TryInt(string s, int returnValue)
        {
            if (string.IsNullOrWhiteSpace(s)) return returnValue;
            try { return Convert.ToInt32(s); }
            catch { }
            return returnValue;
        }

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A integer equivalent to the number contained in s.</para>
        ///<para>Exceptions: s is null | s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static int ToInt(string s)
        {
            return int.Parse(s);
        }

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A integer that is equivalent to the number in value, or Null if the value is null or error..</para>
        ///<para>Exceptions: s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static int? TryIntNullable(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            try { return Convert.ToInt32(s); }
            catch { }
            return null;
        }

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A integer equivalent to the number contained in s.</para>
        ///<para>Exceptions: s is null | s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static long ToLong(string s)
        {
            return long.Parse(s);
        }

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A integer that is equivalent to the number in value, or 0 if the value is null..</para>
        ///<para>Exceptions: s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static long TryLong(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            try { return Convert.ToInt64(s); }
            catch { }
            return 0;
        }

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A integer equivalent to the number contained in s.</para>
        ///<para>Exceptions: s is null | s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static short ToShort(string s)
        {
            return short.Parse(s);
        }

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A integer that is equivalent to the number in value, or 0 if the value is null..</para>
        ///<para>Exceptions: s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static short TryShort(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            try { return Convert.ToInt16(s); }
            catch { }
            return 0;
        }

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A byte equivalent to the number contained in s.</para>
        ///<para>Exceptions: s is null | s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static byte ToByte(string s)
        {
            return byte.Parse(s);
        }

        #endregion

        #region Decimal

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A Decimal that is equivalent to the number in value, or 0 if the value is null..</para>
        ///<para>Exceptions: s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static decimal TryDecimal(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            try { return Convert.ToDecimal(s); }
            catch { }
            return 0;
        }

        ///<summary>Summary: Return the decimal value of the nullable parameter.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A Decimal that is equivalent to the number in value, or 0 if the value is null..</para>
        ///</summary>
        public static decimal TryDecimal(decimal? s)
        {
            if (s.HasValue) return s.Value;
            else return 0;
        }

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A Decimal equivalent to the number contained in s.</para>
        ///<para>Exceptions: s is null | s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static decimal ToDecimal(string s)
        {
            return decimal.Parse(s);
        }

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A Decimal that is equivalent to the number in value, or null..</para>
        ///<para>Exceptions: s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static decimal? TryDecimalNullable(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            try { return Convert.ToDecimal(s); }
            catch { }
            return null;
        }

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A two decimal string that is equivalent to the number in value, or 0.00 if the value is null..</para>
        ///<para>Exceptions: s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static string TryFormtdDecimal(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Format("{0:0.00}", 0);
            try { return string.Format("{0:0.00}", Convert.ToDecimal(s)); }
            catch { }
            return string.Format("{0:0.00}", 0);
        }


        #endregion

        #region Double

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A Double that is equivalent to the number in value, or 0 if the value is null..</para>
        ///<para>Exceptions: s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static double TryDouble(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            try { return Convert.ToDouble(s); }
            catch { }
            return 0;
        }

        ///<summary>Summary: Converts the string representation of a number to the corresponding number format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A Double equivalent to the number contained in s.</para>
        ///<para>Exceptions: s is null | s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static double ToDouble(string s)
        {
            return double.Parse(s);
        }

        #endregion

        #region Boolean

        ///<summary>Summary: Converts the string representation of a number to the corresponding format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A Boolean that is equivalent to the number in value, or 0 if the value is null..</para>
        ///<para>Exceptions: s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static bool TryBool(string s)
        {
            int output;
            if (string.IsNullOrWhiteSpace(s)) return false;
            if (int.TryParse(s, out output))
            {
                try { return Convert.ToBoolean(output); }
                catch { }
            }
            else
            {
                try { return Convert.ToBoolean(s); }
                catch { }
            }

            return false;
        }

        ///<summary>Summary: Converts the integer representation of a number to the corresponding format.        
        ///<para>Parameters: s - A string containing a number to convert.</para>
        ///<para>Returns:    A Boolean that is equivalent to the number in value, or 0 if the value is null..</para>
        ///<para>Exceptions: s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static bool TryBool(int s)
        {
            if (s == 0) return false;
            else if (s > 0) return true;
            try { return Convert.ToBoolean(s); }
            catch { }

            return false;
        }

        ///<summary>Summary: Converts the string representation of a number to the corresponding format.        
        ///<para>Parameters: s - A string convert.</para>
        ///<para>Returns:    A Boolean equivalent to the value contained in s.</para>
        ///<para>Exceptions: s is null | s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static bool ToBool(string s)
        {
            return bool.Parse(s);
        }

        ///<summary>Summary: Converts the string representation of a number to the corresponding format.        
        ///<para>Parameters: s - A nullable bool to convert.</para>
        ///<para>Returns:    A Boolean equivalent to the value contained in s.</para>
        ///</summary>
        public static bool ToBool(bool? s)
        {
            if (!s.HasValue) return false;
            else return s.Value;
        }

        #endregion

        #region DataTime

        ///<summary>Summary: Converts the string representation of a DataTime to the corresponding DataTime format.        
        ///<para>Parameters: s - A string containing a DataTime to convert.</para>
        ///<para>Returns:    A DataTime that is equivalent to the DataTime in value, or null if the value is null or error..</para>
        ///<para>Exceptions: s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static DateTime? TryDateTimeNullable(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            try { return Convert.ToDateTime(s); }
            catch { }
            return null;
        }

        ///<summary>Summary: Converts the string representation of a DataTime to the corresponding DataTime format.        
        ///<para>Parameters: s - A string containing a DataTime to convert.</para>
        ///<para>Returns:    A DataTime that is equivalent to the DataTime in value, or DateTime.Now if the value is null or error..</para>
        ///<para>Exceptions: s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static DateTime TryDateTime(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return DateTime.Now;
            try { return Convert.ToDateTime(s); }
            catch { }
            return DateTime.Now;
        }

        ///<summary>Summary: Converts the string representation of a DataTime to the corresponding DataTime format.        
        ///<para>Parameters: s - A string containing a DataTime to convert.</para>
        ///<para>Returns:    A DataTime that is equivalent to the DataTime in value, or DataTime.MinValue if the value is null..</para>         
        ///<para>Exceptions: s is null | s is not in the correct format | s overflow the MinValue or MaxValue limit.</para>
        ///</summary>
        public static DateTime ToDateTime(string s)
        {
            return DateTime.Parse(s);
        }
        
        #endregion

        #region String
        ///<summary>Summary: Converts the string representation of a object to the corresponding string format.    
        ///<para>Parameters: o - the object to try.</para>
        ///<para>Returns:    A string that is equivalent to the string in the paremeter, or empty string if the value is null.</para>
        ///<para>Exceptions: no exception.</para>
        ///</summary>
        public static string ToString(object o)
        {
            if (o == null) return "";
            if (string.IsNullOrEmpty(o.ToString())) return "";
            else return o.ToString();
        }

        ///<summary>Summary: Converts the string representation of a object to the corresponding string format.        
        ///<para>Parameters: o - the object to try.</para>
        ///<para>Returns:    A string that is equivalent to the string in the paremeter, or Null if the value is null or error..</para>
        ///</summary>
        public static string TryStringNullable(object o)
        {
            try
            {
                if (o == null || o == DBNull.Value) return null;
                else return o.ToString();
            }
            catch { return null; }
        }

        public static string FormatDecimal(decimal s)
        {
            try { return string.Format("{0:0.00}", s); }
            catch { }
            return s.ToString();
        }

        public static string FormatDecimal(decimal? d)
        {
            if (!d.HasValue) return "0.00";
            try { return string.Format("{0:0.00}", d.Value); }
            catch { }
            return d.Value.ToString();
        }

        public static string FormatDecimal(string s)
        {
            try { return string.Format("{0:0.00}", TryDecimal(s)); }
            catch { }
            return s.ToString();
        }

        public static string FormatDecimal(string decimalPontFmt, decimal s)
        {
            try { return string.Format(decimalPontFmt, s); }
            catch { }
            return s.ToString();
        }

        public static string FormatDecimal(string decimalPontFmt, string s)
        {
            try { return FormatDecimal(decimalPontFmt, TryDecimal(s)); }
            catch { }
            return s.ToString();
        }

        public static string AddDecimalToKeyinText(string keyinVal, bool IsAutoAddDecimalPoint, bool isChkSettings = true)
        {
            keyinVal = keyinVal.Trim();
            if (IsAutoAddDecimalPoint && !keyinVal.Trim().Contains("."))
            {
                if (keyinVal.Length >= 2)
                    return keyinVal.Insert(keyinVal.Length - 2, ".");
                else
                    return keyinVal.PadLeft(3, '0').Insert(1, ".");
            }
            else
            {
                return keyinVal;
            }
        }

        #endregion 
        
        #region Comparisons

        ///<summary>Summary: Indicates whether the object is null, its string value is empty, or consists only of white-space characters.
        ///<para>Parameters: The object to test.</para>
        ///<para>Returns:    true if the parameter is null or string value is empty or if string value consists only of white-space characters.
        ///<para>Exceptions: no exception.</para>
        ///</summary>
        public static bool IsNullOrWhiteSpace(object o)
        {
            if (o == null) return true;
            if (string.IsNullOrWhiteSpace(o.ToString())) return true;
            else return false;
        }

        #endregion
        
        #region Common Convertion

        ///<summary>Summary: Calculate the GST amount for the decimal number.        
        ///<para>Parameters: s - A decimal containing a non zero or non negative number.</para>
        ///<para>Returns:    A Decimal that is equivalent to the calculated GST Amount, or 0 if the value is null or negative.</para>        
        ///</summary>
        public static decimal GetGstAmt(decimal s, decimal GSTRate)
        {
            return ((s / (100 + GSTRate)) * GSTRate);
        }

        public static decimal GetWithoutGstAmt(decimal s, decimal GSTRate)
        {
            return s - GetGstAmt(s, GSTRate);
        }

        ///////// <summary>
        ///////// Calculate the rounding amount based on app settings and return the related values.
        ///////// If Rounding Threshold is Negative: Round Down 
        ///////// If Rounding Threshold is Positve: Round Up
        ///////// </summary>
        ///////// <param name="OrgAmount">Original base amount which the rounding is calculating from</param>
        ///////// <param name="returnRoundedAmt">Out: The amount after rounding</param>
        ///////// <param name="remainderAmt">Out: The remainder (duducted rounding) amount after rounding</param>
        ///////// <param name="isOppositeRoundingForNegative">Default=false; whether to use opposite of round up/down for negative values.</param>
        //////public static void CalcRounding(decimal OrgAmount, out decimal returnRoundedAmt, out decimal remainderAmt, decimal roundingThreshold, bool isOppositeRoundingForNegative = false)
        //////{
        //////    GetRounding(OrgAmount, out returnRoundedAmt, out remainderAmt, roundingThreshold, isOppositeRoundingForNegative);
        //////}


        /// <summary>
        /// Calculate the rounding amount based on the given rounding threshold and return the related values.
        /// If Rounding Threshold is Negative: Round Down 
        /// If Rounding Threshold is Positve: Round Up
        /// </summary>
        /// <param name="OrgAmount">Original base amount which the rounding is calculating from</param>
        /// <param name="returnRoundedAmt">Out: The amount after rounding</param>
        /// <param name="remainderAmt">Out: The remainder (duducted rounding) amount after rounding</param>
        /// <param name="roundingThreshold"> The rounding Threshold to be used to calculate the rounding</param>
        /// <param name="isOppositeRoundingForNegative">Default=false; whether to use opposite of round up/down for negative values.</param>
        public static void CalcRounding(decimal OrgAmount, out decimal returnRoundedAmt, out decimal remainderAmt, decimal roundingThreshold, bool isOppositeRoundingForNegative = false)
        {
            GetRounding(OrgAmount, out returnRoundedAmt, out remainderAmt, roundingThreshold, isOppositeRoundingForNegative);
        }

        private static void GetRounding(decimal OrgAmount, out decimal returnRoundedAmt, out decimal deductedRoundingAmt, decimal roundThreshold, bool isOppositeRoundingForNegative = false)
        {
            try
            {
                if (roundThreshold == 0 || OrgAmount == 0)
                {
                    returnRoundedAmt = OrgAmount;
                    deductedRoundingAmt = 0;
                    return;
                }


                if (isOppositeRoundingForNegative && OrgAmount < 0)
                {
                    returnRoundedAmt = Math.Ceiling(OrgAmount / roundThreshold) * roundThreshold;
                    //returnRoundedAmt = Math.Ceiling(OrgAmount / (POSSetting.AppSett.Rounding * -1)) * (POSSetting.AppSett.Rounding * -1);
                }
                else
                {
                    returnRoundedAmt = Math.Ceiling(OrgAmount / roundThreshold) * roundThreshold;
                }
                deductedRoundingAmt = -(OrgAmount - returnRoundedAmt);

                //if (POSSetting.AppSett.Rounding > 0) //ROUND UP
                //{
                //    returnRoundedAmt = Math.Ceiling(OrgAmount / POSSetting.AppSett.Rounding) * POSSetting.AppSett.Rounding;
                //}
                //else //ROUND DOWN
                //{
                //    returnRoundedAmt = Math.Floor(OrgAmount / POSSetting.AppSett.Rounding) * POSSetting.AppSett.Rounding;
                //}                                   
                //if (POSSetting.AppSett.Rounding > 0) //ROUND UP
                //{
                //    if (isRndUpForNegValue && OrgAmount < 0)
                //    {
                //        returnRoundedAmt = Math.Ceiling(OrgAmount / POSSetting.AppSett.Rounding) * POSSetting.AppSett.Rounding;
                //        deductedRoundingAmt = -(OrgAmount - returnRoundedAmt);
                //    }
                //    else
                //    {
                //        returnRoundedAmt = Math.Floor(OrgAmount / POSSetting.AppSett.Rounding) * POSSetting.AppSett.Rounding;
                //        deductedRoundingAmt = -(OrgAmount - returnRoundedAmt);
                //    }
                //}                
            }
            catch
            {
                returnRoundedAmt = OrgAmount;
                deductedRoundingAmt = 0;
            }
        }

        public static void CalcAutoRoundUp(decimal OrgAmount, out decimal finalRoundedAmt, decimal numDigits)
        {
            try
            {
                if (numDigits > 0)
                {
                    finalRoundedAmt = Math.Ceiling(OrgAmount / numDigits) * numDigits;
                }
                else
                {
                    finalRoundedAmt = OrgAmount;
                }
            }
            catch
            {
                finalRoundedAmt = OrgAmount;
            }
        }


        #endregion

        #region Exceptions
        public static string GetInnerExcpMsg(Exception e)
        {
            string expMsg = "";
            try
            {
                if (e == null || string.IsNullOrWhiteSpace(e.Message)) return "";
                expMsg = e.Message;
                if (expMsg.ToLower().StartsWith("an error occurred while updating the entries") && expMsg.ToLower().EndsWith("see the inner exception for details."))
                {
                    expMsg = "";
                }
                if (e.InnerException != null && !string.IsNullOrWhiteSpace(e.InnerException.Message))
                {
                    expMsg = e.InnerException.Message;
                }
                if (e.InnerException != null && e.InnerException.InnerException != null
                    && !string.IsNullOrWhiteSpace(e.InnerException.InnerException.Message) && expMsg != e.InnerException.InnerException.Message)
                {
                    if (expMsg.ToLower().StartsWith("an error occurred while updating the entries") && expMsg.ToLower().EndsWith("see the inner exception for details."))
                    {
                        expMsg = "";
                    }
                    expMsg += e.InnerException.InnerException.Message;
                }
            }
            catch
            {
                if (e != null && !string.IsNullOrWhiteSpace(e.Message))
                    expMsg = e.Message;
            }
            return expMsg;
        }
        #endregion
    }
}
