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

        public static string removeAutoCADFormat(this String str)
        {
            ConfigManager.ConfigManager conf = new ConfigManager.ConfigManager(ConfigManager.Default.ConfigFile);
            foreach (string pat in conf.Configuration.AutoCADPatterns)
                str = str.removePattern(pat);
            return str;
        }
    }
}
