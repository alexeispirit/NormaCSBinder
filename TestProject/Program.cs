﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringExtender;
using NormaCSBinder;
using Logger;
using ConfigManager;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace TestProject
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Standard s1 = new Standard("ГОСТ Р 21.1101-2009");
            Standard s2 = new Standard("ГОСТ", "2.101");
            HashSet<Standard> sl1 = new HashSet<Standard>();
            HashSet<Standard> sl2 = new HashSet<Standard>();

            sl1.Add(s1);
            sl1.Add(s2);

            string[] test = { "tesT", "best", "rest" };
            IEnumerable<string> tt = test.Take(test.Length - 1).ToList();

            ConfigManager.ConfigManager cm = ConfigManager.ConfigManager.Instance;
            HashSet<Document> s1d = s1.Check();
            Console.WriteLine(s1d.First());


            string str = "333-ГОСТ--444";
            Console.WriteLine(str.cleanAllWithWhiteList());
            NormaCS ncs = new NormaCS(sl1);
            ncs.checkStandards();

            ReportWindow.Main mn = new ReportWindow.Main(ncs.Documents);

            Application app = new Application();
            app.Run(mn);
        }
    }
}
