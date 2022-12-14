using System;

namespace TDImporterXML.Core.Utilities.ExtensionMethods
{
    public static class ConvertExtensions
    {

        public static int TimeToInt(this DateTime Time)
        {
            return int.Parse(Time.ToLocalTime().Hour.ToString()) * 65536 * 256 + int.Parse(Time.ToLocalTime().Minute.ToString()) * 65536 + int.Parse(Time.ToLocalTime().Second.ToString()) * 256;
        }

        public static string ToStr(this object value, string defaultVal = "")
        {
            if (value == null)
                return defaultVal;

            return value.ToString();
        }
        public static int ToInt32(this object value, int defaultVal = 0)
        {
            if (value == null)
                return defaultVal;

            if (string.IsNullOrEmpty(value.ToString()))
                return defaultVal;

            if (value.ToString().ToLower() == "null")
                return defaultVal;

            return int.Parse(value.ToString());
        }
        public static double ToDouble(this object value, double defaultVal = 0)
        {
            if (value == null)
                return defaultVal;

            if (string.IsNullOrEmpty(value.ToString()))
                return defaultVal;

            if (value.ToString().ToLower() == "null")
                return defaultVal;

            return double.Parse(value.ToString());
        }
        public static byte ToByte(this object value, byte defaultVal = 0)
        {
            if (value == null)
                return defaultVal;

            if (string.IsNullOrEmpty(value.ToString()))
                return defaultVal;

            if (value.ToString().ToLower() == "null")
                return defaultVal;

            return byte.Parse(value.ToString());
        }
        public static bool ToBool(this object value, bool defaultVal = false)
        {
            if (value == null)
                return defaultVal;

            if (string.IsNullOrEmpty(value.ToString()))
                return defaultVal;

            if (value.ToString().ToLower() == "null")
                return defaultVal;

            return bool.Parse(value.ToString());
        }




        public static int? ToInt32orNull(this object value)
        {
            if (value == null)
                return null;

            if (string.IsNullOrEmpty(value.ToString()))
                return 0;

            if (value.ToString().ToLower() == "null")
                return 0;

            return int.Parse(value.ToString());
        }
        public static int? ToInt32orNull(this object value, string forNullValue = "0")
        {
            if (value == null)
                return null;

            if (string.IsNullOrEmpty(value.ToString()))
                return 0;

            if (value.ToString().ToLower() == "null")
                return 0;

            if (value.ToString() == forNullValue)
                return null;

            return int.Parse(value.ToString());
        }


        public static DateTime ToDateTime(this object value)
        {
            return DateTime.Parse(value.ToString());
        }

        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
        public static bool IsEmpty(this object value)
        {
            string result = string.Empty;
            if (value != null)
                result = value.ToString();

            return string.IsNullOrEmpty(result);
        }

        public static string SubstringMax(this string value, int maxLen)
        {
            if (value.Length < maxLen)
                return value;

            return value.Substring(0, maxLen);
        }









    }
}