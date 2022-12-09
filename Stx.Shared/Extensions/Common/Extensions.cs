
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;

namespace Stx.Shared.Extensions.Common
{
	public static class CommonExtensions
    {
        #region List Extensions
        public static void AddDistinctItems<T>(this System.Collections.Generic.List<T> sortedlist, T item)
        {
            if (!sortedlist.Contains(item))
            {
                sortedlist.Add(item);
                sortedlist.Sort();
            }
        }

        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
        #endregion

        #region Enum

        public static string GetEnumDescription(this Enum value)
        {
            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());

            System.ComponentModel.DescriptionAttribute[] attributes =
                (System.ComponentModel.DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(System.ComponentModel.DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        #endregion

        #region Byte Extensions
        /// <summary>
        /// Determines whether a specified byte value matches any value in the provided list
        /// </summary> 
        /// <returns>True if the specified byte value contains in the provided list, otherwise return False</returns> 
        public static bool InByets(this byte byt, params byte[] byteValueList)
        {
            if (byteValueList == null || byteValueList.Count() == 0)
            {
                return false;
            }
            else if (byteValueList.Any(x => x.Equals(byt)))
            {
                return true;
            }
            else return false;
        }
        #endregion

        #region Short Extensions
        /// <summary>
        /// Determines whether a specified short (int16) value matches any value in the provided list
        /// </summary> 
        /// <returns>True if the specified short (int16) value contains in the provided list, otherwise return False</returns> 
        public static bool InShort(this short byt, params short[] shortValueList)
        {
            if (shortValueList == null || shortValueList.Count() == 0)
            {
                return false;
            }
            else if (shortValueList.Any(x => x.Equals(byt)))
            {
                return true;
            }
            else return false;
        }
        #endregion

        #region Int Extensions
        /// <summary>
        /// Determines whether a specified integer (int32) value matches any value in the provided list
        /// </summary> 
        /// <returns>True if the specified integer (int32) value contains in the provided list, otherwise return False</returns> 
        public static bool InInteger(this int intval, params int[] intValueList)
        {
            if (intValueList == null || intValueList.Count() == 0)
            {
                return false;
            }
            else if (intValueList.Any(x => x.Equals(intval)))
            {
                return true;
            }
            else return false;
        }
        #endregion

        #region String Extensions

        /// <summary>
        /// Returns the left part of a string with the specified number of characters.
        /// </summary>
        public static string Left(this string str, int length)
        {
            if (string.IsNullOrEmpty(str) || length < 1)
                return string.Empty;
            else
                return str.Substring(0, System.Math.Min(length, str.Length));
        }

        /// <summary>
        /// Returns the right part of a string with the specified number of characters.
        /// </summary>
        public static string Right(this string str, int length)
        {
            str = (str ?? string.Empty);
            return (str.Length >= length) ? str.Substring(str.Length - length, length) : str;
        }

        /// <summary>
        /// Return the string with the prefix. If the base string is empty, no prefix will be added.
        /// </summary>
        public static string SetPrefix(this string str, string prefix)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;
            else
                return string.Concat(prefix, str);
        }

        /// <summary>
        /// Return the string with the postfix. If the base string is empty, no postfix will be added.
        /// </summary>
        public static string SetPostfix(this string str, string postfix)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;
            else
                return string.Concat(postfix, str);
        }

        /// <summary>
        /// Replaces null, white space or empty string with the specified replacement string value.
        /// </summary>
        public static string IsNothing(this string str, string replacementStr)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return replacementStr;
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNumeric(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return false;

            float output;
            return float.TryParse(s, out output);
        }

        /// <summary>
        /// Convert a camel case single text to words
        /// </summary>
        /// <param name="str">Text in camel case</param>
        /// <returns></returns>
        public static string CamelCaseToWords(this string str)
        {
            try
            {
                return System.Text.RegularExpressions.Regex.Replace(str, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
            }
            catch { }
            return str;
        }

        /// <summary>
        /// Determines whether a specified string value matches any value in the provided list
        /// </summary> 
        /// <returns>True if the specified string contains in the provided list, otherwise return False</returns> 
        public static bool In(this string str, string[] stringList, bool isIgnoreCase = true)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            else if (isIgnoreCase && stringList.Contains(str, System.StringComparer.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (stringList.Contains(str))
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Determines whether a specified string value matches (case insensitive) any value in the provided list.
        /// </summary> 
        /// <returns>True if the specified string contains in the provided list, otherwise return False</returns> 
        public static bool InIgnoreCase(this string str, params string[] stringList)
        {
            if (str == null && stringList.Contains(null))
            {
                return true;
            }
            else if (str == null || stringList == null || stringList.Count() == 0)
            {
                return false;
            }
            else if (stringList.Any(x => x != null && x.ToLower().Equals(str.ToLower())))
            {
                return true;
            }
            else return false;
        }


        /// <summary>
        /// Returns a value indicating whether a specified list of substrings occurs within this string.
        /// </summary> 
        /// <returns>true if any of the provided value parameters occurs within this string, otherwise returns false</returns> 
        public static bool ContainsSubstringIgnoreCase(this string str, params string[] stringList)
        {
            if (str == null && stringList.Contains(null))
            {
                return true;
            }
            else if (str == null || stringList == null || stringList.Count() == 0)
            {
                return false;
            }
            else if (stringList.Any(x => x != null && str.IndexOf(x, StringComparison.OrdinalIgnoreCase) >= 0))
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Determines whether all the string values in the provided stringList are empty, null or whitespaces.
        /// </summary> 
        /// <returns>True if all values in the stringList are empty, null or whitespaces, Or the list is empty. </returns> 
        public static bool AllIsNullOrWhiteSpace(this string dummyString, params string[] stringList)
        {
            if (stringList == null || stringList.Count() == 0)
            {
                return true;
            }
            else if (stringList.All(x => string.IsNullOrWhiteSpace(x)))
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Determines whether any of the string values in the provided stringList are empty, null or whitespaces.
        /// </summary> 
        /// <returns>True if any value in the stringList are empty, null or whitespaces, Or the list is empty. </returns> 
        public static bool AnyIsNullOrWhiteSpace(this string dummyString, params string[] stringList)
        {
            if (stringList == null || stringList.Count() == 0)
            {
                return true;
            }
            else if (stringList.Any(x => string.IsNullOrWhiteSpace(x)))
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Compare the string with the specified string by ignoring the case and whitespaces.
        /// </summary>
        /// <returns>True if both string values are equal, False if both string values are not equal</returns>
        public static bool Compare(this string str, string strToCompare)
        {
            str = (str ?? string.Empty);
            strToCompare = (strToCompare ?? string.Empty);
            if (str.Trim().ToLower() == strToCompare.Trim().ToLower())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Evaluates the arguments in order and returns the first non-null and non-empty string value.
        /// </summary>
        /// <param name="s">Base string value</param>
        /// <param name="secondstring">Second string value</param>
        /// <returns></returns>
        public static string Coalesce(this string s, string secondstring)
        {
            return string.IsNullOrWhiteSpace(s) ? secondstring : s;
        }

        /// <summary>
        /// Evaluates the arguments in order and returns the first non-null and non-empty string value.
        /// </summary>
        /// <param name="s">Base string value</param>
        /// <param name="secondstring">Second string value</param>
        /// <param name="thirdstring">Third string value</param>
        /// <returns></returns>
        public static string Coalesce(this string s, string secondstring, string thirdstring)
        {
            return string.IsNullOrWhiteSpace(s) ? secondstring.Coalesce(thirdstring) : s;
        }

        /// <summary>
        /// Amend the given string at begining and return the whole combined string value.
        /// </summary>
        /// <param name="s">Base string value</param>
        /// <param name="textToAmend">String to prefix </param>
        /// <returns></returns>
        public static string PrefixIfNotEmpty(this string s, string textToAmend)
        {
            if (string.IsNullOrWhiteSpace(s)) return s;
            return $"{textToAmend}{s}";
        }
        /// <summary>
        /// Amend the given string at the end and return the whole combined string value.
        /// </summary>
        /// <param name="s">Base string value</param>
        /// <param name="textToAmend">String to postfix </param>
        /// <returns></returns>
        public static string PostfixIfNotEmpty(this string s, string textToAmend)
        {
            if (string.IsNullOrWhiteSpace(s)) return s;
            return $"{s}{textToAmend}";
        }
        /// <summary>
        /// Join all the provided non-empty and non-null string values together with the separator and return the whole string value.
        /// </summary>
        /// <param name="s">Base string value</param>
        /// <param name="separator">String separator </param>
        /// <param name="stringList">List of string to amend.</param>
        /// <returns></returns>
        public static string JoinIfNotEmpty(this string s,  string separator, params string[] stringList)
        {
            if (stringList == null || stringList.Count() == 0)
            {
                return s;
            }

            var ret = stringList.ToList();
            ret.Insert(0, s);
            return string.Join(separator, ret.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        ///// <summary>
        ///// Returns the plural form of the specified word
        ///// </summary>
        ///// <param name="s">The word to be made plural.</param>
        ///// <returns></returns>
        //public static string Pluralize(this string s)
        //{
        //    if (string.IsNullOrWhiteSpace(s))
        //    {
        //        return s;
        //    }
        //    else
        //    {
        //        System.Data.Entity.Design.PluralizationServices.PluralizationService ps
        //            = System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(System.Globalization.CultureInfo.GetCultureInfo("en-us"));
        //        return ps.Pluralize(s);
        //    }
        //}


        public static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static string ToJson(this string s, bool isWriteIndentedoutput=true)
        {
            return JsonSerializer.Serialize<string>(s, new JsonSerializerOptions()
            {
                WriteIndented = isWriteIndentedoutput
            });
        }


        #endregion

        #region Decimal Extensions

        /// <summary>
        /// Count number of decimal places contains in the specified decimal value
        /// </summary> 
        /// <returns> Return Int, number of decimal places </returns> 
        public static int CountDecimalPlaces(this decimal dec)
        {
            if (dec.ToString().Length <= 1 || !dec.ToString().Contains(".") || dec.ToString().Split(new char[] { '.' }, System.StringSplitOptions.RemoveEmptyEntries).Length < 2)
            {
                return 0;
            }
            else
            {
                return dec.ToString().Split(new char[] { '.' }, System.StringSplitOptions.RemoveEmptyEntries)[1].Count();
            }
        }

        /// <summary>
        /// Get salary/amount range for two provided values.
        /// </summary>
        /// <param name="dec">First value (from value)</param>
        /// <param name="value2">Second value (to value)</param>
        /// <param name="separator">Separator</param>
        /// <param name="currencyCode">Currency symbol</param>
        /// <param name="isShowKFormat">Show amount as thousand values (1000=1k).</param>
        /// <returns></returns>
        public static string ShowSalaryRanage(this decimal? dec, decimal? value2, string separator, string currencyCode, bool isShowKFormat = false)
        {
            if (dec.GetValueOrDefault(0) <= 0)
            {
                return "";
            }
            else
            {
                string format = "#,###";
                if (isShowKFormat)
                {
                    if (dec.GetValueOrDefault(0) < 500 && value2.GetValueOrDefault(0) < 500) return "";
                    dec = dec / 1000;
                    value2 = value2.GetValueOrDefault(0) > 0 ? value2.Value/1000 : 0;
                    format = "0.#K";
                }
                return $"{currencyCode}{dec.Value.ToString(format)} {(value2.GetValueOrDefault(0) > 0 ? $"{separator} {currencyCode}{value2.Value.ToString(format)}":"")}".Trim();
            }
        }

        #endregion 

        #region TreeView Extensions

        //public static System.Collections.Generic.IEnumerable<TreeNode> All(this TreeNodeCollection nodes)
        //{
        //    foreach (TreeNode n in nodes)
        //    {
        //        yield return n;
        //        foreach (TreeNode child in n.Nodes.All())
        //            yield return child;
        //    }
        //}
        #endregion

        #region Exception Extensions

        public static string GetInnerExcpMsg(this Exception e, bool isRemoveLineBreaks = true)
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

                if (isRemoveLineBreaks)
                {
                    expMsg = expMsg.Replace('\n', ' ').Replace('\r', ' ').Replace(Environment.NewLine, " ");
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

        #region DateTime Extensions

        /// <summary>
        /// Returns the short date string with format yyyy-MM-dd.
        /// </summary>
        public static string ShortDatetimeFormat(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Returns the short date string according to the provided format or with default format yyyy-MM-dd.
        /// </summary>
        public static string ShortDatetimeFormat(this DateTime? dt, string format= null)
        {
            if (!dt.HasValue)
                return "";
            else
                return dt.Value.ToString(format.IsEmpty() ? "yyyy-MM-dd" : format);
        }

        /// <summary>
        /// Returns the short date string with format yyyy-MM-dd HH:mm:ss.
        /// </summary>
        public static string LongDatetimeFormat(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Returns the short date string with format yyyy-MM-dd HH:mm:ss.
        /// </summary>
        public static string LongDatetimeFormat(this DateTime? dt)
        {
            if (!dt.HasValue)
                return "";
            else
                return dt.Value.LongDatetimeFormat();
        }

        /// <summary>
        /// Returns the short date string with format yyyyMMddHHmmss.
        /// </summary>
        public static string LongDatetimeNumberFormat(this DateTime dt)
        {
            return dt.ToString("yyyyMMddHHmmss");
        }

        /// <summary>
        /// Returns the short date string with format yyyyMMddHHmmss.
        /// </summary>
        public static string LongDatetimeNumberFormat(this DateTime? dt)
        {
            if (!dt.HasValue)
                return "";
            else
                return dt.Value.LongDatetimeNumberFormat();
        }

        #region TimeAgo Extensions
        public static string TimeAgoNullable(this DateTime? dateTime, bool isDisplayShortCode = false)
        {
            if (!dateTime.HasValue || dateTime.Value.Year < 1950) return "";

            return dateTime.Value.TimeAgo(isDisplayShortCode);
        }

        public static string TimeAgo(this DateTime dateTime, bool isDisplayShortCode = false)
        {
            if (dateTime.Year < 1950) return "";
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (isDisplayShortCode)
            {
                if (timeSpan <= TimeSpan.FromSeconds(60) || timeSpan <= TimeSpan.FromMinutes(5))
                {
                    result = "now";
                }
                else if (timeSpan <= TimeSpan.FromMinutes(60))
                {
                    result = $"{timeSpan.Hours}m";
                }
                else if (timeSpan <= TimeSpan.FromHours(24))
                {
                    result = $"{timeSpan.Hours}h";
                }
                else if (timeSpan <= TimeSpan.FromDays(30))
                {
                    result = $"{timeSpan.Hours}d";
                }
                else if (timeSpan <= TimeSpan.FromDays(60))
                {
                    result = $"{timeSpan.Hours}d";
                }
                else
                {
                    result = $"60d+";
                }
            }
            else
            {
                if (timeSpan <= TimeSpan.FromSeconds(60))
                {
                    result = string.Format("{0} seconds ago", timeSpan.Seconds);
                }
                else if (timeSpan <= TimeSpan.FromMinutes(60))
                {
                    result = timeSpan.Minutes > 1 ?
                        String.Format("{0} minutes ago", timeSpan.Minutes) : "a minute ago";
                }
                else if (timeSpan <= TimeSpan.FromHours(24))
                {
                    result = timeSpan.Hours > 1 ?
                        String.Format("{0} hours ago", timeSpan.Hours) : "an hour ago";
                }
                else if (timeSpan <= TimeSpan.FromDays(30))
                {
                    result = timeSpan.Days > 1 ?
                        String.Format("{0} days ago", timeSpan.Days) : "yesterday";
                }
                else if (timeSpan <= TimeSpan.FromDays(365))
                {
                    result = timeSpan.Days > 30 ?
                        String.Format("{0} months ago", timeSpan.Days / 30) : "a month ago";
                }
                else
                {
                    result = timeSpan.Days > 365 ?
                        String.Format("about {0} years ago", timeSpan.Days / 365) : "about a year ago";
                }
            }

            return result;
        }

        public static int? AgeYearsNullable(this DateTime? dateTime)
        {
            if (!dateTime.HasValue) return null;
            else return dateTime.Value.AgeYears();
        }

        public static int? AgeYears(this DateTime dateTime)
        {
            int age = 0;
            DateTime today = DateTime.Today;
            if (dateTime.Date >= today) return null;
            age = today.Year - dateTime.Year;
            if (today.DayOfYear < dateTime.DayOfYear)
                age -= 1;

            return age;
        }
        #endregion
        #endregion

        #region System.Data Extensions
        public static void AddWithValue<T>(this IDbCommand command, string name, T value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }
        #endregion
    }

}
