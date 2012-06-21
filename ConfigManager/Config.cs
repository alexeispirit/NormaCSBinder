using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ConfigManager
{
    /// <summary>
    /// Config serialization class
    /// </summary>
    public class Config
    {
        public string[] AutoCADPatterns { get; set; } // AutoCAD String Format Patterns
        public string[] RevitPatterns { get; set; } // Revit String Format Patterns
        public string[] InventorPatterns { get; set; } // Inventor String Format Patterns
        public string[] WhiteList { get; set; } // Whitelist 
        public string[] BlackList { get; set; } // Blacklist
        public string RegExp { get; set; } // Regular Expression to searh for in text
    }
}
