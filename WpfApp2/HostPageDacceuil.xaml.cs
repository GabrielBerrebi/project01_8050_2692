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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for HostPageDacceuil.xaml
    /// </summary>
    public partial class HostPageDacceuil : Window
    {
        public HostPageDacceuil()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HostInscription host = new HostInscription();
            host.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           Form4 id = new Form4();
           id.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
