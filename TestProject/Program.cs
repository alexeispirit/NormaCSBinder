using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringExtender;
using NormaCSBinder;
using Logger;
using ConfigManager;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Standard s1 = new Standard("ГОСТ Р", "21.1101");
            Standard s2 = new Standard("ГОСТ", "2.101");
            HashSet<Standard> sl1 = new HashSet<Standard>();
            HashSet<Standard> sl2 = new HashSet<Standard>();

            sl1.Add(s1);
            sl1.Add(s2);

            ConfigManager.ConfigManager cm = new ConfigManager.ConfigManager(@"settings.json");
            Console.WriteLine(cm.Configuration.AutoCADPatterns[0]);


            string str = "333-sss";
            str.removePattern(@"\w{3}");
            NormaCS ncs = new NormaCS(sl1);
            //ncs.checkStandards();
            foreach (Document doc in ncs.Documents)
                Console.WriteLine(doc);

            Console.ReadKey();
        }


    }
}
