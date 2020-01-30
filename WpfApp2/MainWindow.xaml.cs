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

namespace WpfApp2
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client client = new client();
            client.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HostPageDacceuil host = new HostPageDacceuil();
            host.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
