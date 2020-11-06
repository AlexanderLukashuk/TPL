using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookDowload
{
    /// <summary>
    /// Логика взаимодействия для LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        private CancellationTokenSource tokenSource;
        private WebClient client;
        public LoadingWindow(string bookName)
        {
            InitializeComponent();
            client = new WebClient();

            tokenSource = new CancellationTokenSource();
        }

        public void Dowload(string bookName)
        {
            var task = Task.Run(() =>
            {
                client.DownloadFile(new Uri("https://codernet.ru/media/%D0%AF%D0%B7%D1%8B%D0%BA%20%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F%20C%23%207/yazyk_programmirovaniya_c_7_i_platformy_net_i_net_core.pdf"), bookName);

                if (!client.IsBusy)
                {
                    Dispatcher.Invoke(() =>
                    {
                        progressBar.Value = 100;
                        progressBar.IsIndeterminate = false;
                        this.Close();
                    });
                }

                MessageBox.Show("Книга загружена");

            }, tokenSource.Token);
        }

        private void CancelDowload(object sender, RoutedEventArgs e)
        {
            tokenSource.Cancel();
            client.Dispose();
            this.Close();
            MessageBox.Show("Загрузка отменена");
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.Dispose();
        }
    }
}
