using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace StringExtender
{
    /// <summary>
    /// Extension methods for String class
    /// </summary>
    public static class StringExtender
    {
        /// <summary>
        /// Remove regexp pattern from string
        /// </summary>
        /// <param name="str">string to remove pattern</param>
        /// <param name="pattern">regular expression</param>
        /// <returns>cleared string</returns>
        public static string removePattern(this String str, string pattern)
        {
            return Regex.Replace(str, pattern, "");            
        }

        /// <summary>
        /// Trim string before substring
        /// </summary>
        /// <param name="str">string to trim</param>
        /// <param name="wlValue">value to search in string</param>
        /// <returns>cleared string</returns>
        public static string cleanBeforeWhiteListValue(this String str, string wlValue)
        {
            int index = str.IndexOf(wlValue);
            string cleared = str;
            if (index >= 0)
                cleared = str.Substring(index);
            return cleared;
        }

        /// <summary>
        /// Clean string according to whitelist
        /// </summary>
        /// <param name="str">string to clean</param>
        /// <returns>cleared string</returns>
        public static string cleanAllWithWhiteList(this String str)
        {
            ConfigManager.ConfigManager conf = ConfigManager.ConfigManager.Instance;
            
            foreach (string white in conf.Configuration.WhiteList)
                str = str.cleanBeforeWhiteListValue(white);
            return str;
        }

        /// <summary>
        /// Remove AutoCAD String format symbols
        /// </summary>
        /// <param name="str">string to clean</param>
        /// <returns>cleared string</returns>
        public static string removeAutoCADFormat(this String str)
        {
            ConfigManager.ConfigManager conf = ConfigManager.ConfigManager.Instance;
            foreach (string pat in conf.Configuration.AutoCADPatterns)
                str = str.removePattern(pat);
            return str;
        }
    }
}
