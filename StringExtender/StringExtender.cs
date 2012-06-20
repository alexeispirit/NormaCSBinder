using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace StringExtender
{
    public static class StringExtender
    {
        private static string[] patterns = {};
        public static string removePattern(this String str, string pattern)
        {
            string text = System.IO.File.ReadAllText(@"settings.json");

            string pat = @"^\d{3}";
            return Regex.Replace(str, pat, "---");            
        }
    }
}
