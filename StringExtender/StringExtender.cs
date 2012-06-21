using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace StringExtender
{
    public static class StringExtender
    {
        public static string removePattern(this String str, string pattern)
        {
            return Regex.Replace(str, pattern, "");            
        }

        public static string cleanBeforeWhiteListValue(this String str, string wlValue)
        {
            int index = str.IndexOf(wlValue);
            string cleared = str;
            if (index >= 0)
                cleared = str.Substring(index);
            return cleared;
        }

        public static string cleanAllWithWhiteList(this String str)
        {
            ConfigManager.ConfigManager conf = ConfigManager.ConfigManager.Instance;
            
            foreach (string white in conf.Configuration.WhiteList)
                str = str.cleanBeforeWhiteListValue(white);
            return str;
        }

        public static string removeAutoCADFormat(this String str)
        {
            ConfigManager.ConfigManager conf = ConfigManager.ConfigManager.Instance;
            foreach (string pat in conf.Configuration.AutoCADPatterns)
                str = str.removePattern(pat);
            return str;
        }
    }
}
