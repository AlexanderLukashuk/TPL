using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookDowload
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DownloadBook(object sender, RoutedEventArgs e)
        {
            string bookName = $"{nameTextBox.Text}.pdf";
            LoadingWindow newWindow = new LoadingWindow(bookName);
            newWindow.Show();
            App.Current.MainWindow = newWindow;
            newWindow.Dowload(bookName);
            this.Close();
        }
    }
}
