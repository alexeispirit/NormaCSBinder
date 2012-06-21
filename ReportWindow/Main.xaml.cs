using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReportWindow
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main 
    {
        public Main(IEnumerable<Pair> col)
        {
            InitializeComponent();
            NormaCSDocsDataGrid.DataContext = col;
            //DataGrid dg = (DataGrid) this.FindName("NormaCSDocsDataGrid");
            //dg.DataContext = col;

        }
    }

    public class Pair
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
