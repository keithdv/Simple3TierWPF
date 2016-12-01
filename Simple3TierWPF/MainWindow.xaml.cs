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

namespace Simple3TierWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
            this.btClose.Click += BtClose_Click;
            this.btStart.Click += BtStart_Click;
            this.btStop.Click += BtStop_Click;
        }

        private void BtStop_Click(object sender, RoutedEventArgs e)
        {
            mv.Stop();
        }

        private void BtStart_Click(object sender, RoutedEventArgs e)
        {
            mv.Start();
        }

        MainWindowViewModel mv;

        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            mv = new MainWindowViewModel();
            this.DataContext = mv;
            mv.Start();
        }
    }
}
