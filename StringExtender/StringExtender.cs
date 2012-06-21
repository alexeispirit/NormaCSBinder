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
    }
}
