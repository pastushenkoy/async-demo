using System;
using System.Threading;
using System.Threading.Tasks;

namespace WpfDeadlock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            StartWork().Wait();
        }

        private async Task StartWork()
        {
            Text1.Text += $"\n{Thread.CurrentThread.ManagedThreadId}";
            await Task.Delay(100);
        }
    }
}