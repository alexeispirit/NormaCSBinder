using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NormaCSBinder;
using StringExtender;
using Newtonsoft.Json;
using Logger;

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

            Logger.Logger.Error("AAAAAAAAAAAAAxxxAAAA", "MAIN");

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
