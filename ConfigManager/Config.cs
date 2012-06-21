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
        public string[] AutoCADPatterns { get; set; }
        public string[] RevitPatterns { get; set; }
        public string[] InventorPatterns { get; set; }
    }
}
