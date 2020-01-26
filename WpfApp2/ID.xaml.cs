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
using BE;
using DSi;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for ID.xaml
    /// </summary>
    public partial class ID : Window
    {
        public ID()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (id1.Text == "")
            {
                MessageBox.Show("tu dois remplir tout les champ!");
            }
            foreach (Host item in DataSource.hosts)
            {
                {
                    if (int.Parse(id1.Text)==item.HostKey)
                    {
                        int identifiant = int.Parse(id1.Text);
                        connection connection = new connection(identifiant);
                        connection.Show();
                    }
                }
            }
        }
    }
}
