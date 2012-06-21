using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigManager
{
    public static class Default
    {
        public static string ConfigFile {
            get 
            {
                return @"settings.json";
            }
        }
    }
}
