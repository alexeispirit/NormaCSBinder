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
using System.Diagnostics;
using NormaCSBinder;

namespace ReportWindow
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main 
    {
        /// <summary>
        /// Initialize window and bind data
        /// </summary>
        /// <param name="docs">NormaCSBinder.Document collection</param>
        public Main(IEnumerable<Document> docs)
        {
            InitializeComponent();
            NormaCSDocsDataGrid.DataContext = docs;
        }

        /// <summary>
        /// NormaCS Hyperlink click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = e.OriginalSource as Hyperlink;
            Process.Start(link.NavigateUri.AbsoluteUri);
        }
    }
}
