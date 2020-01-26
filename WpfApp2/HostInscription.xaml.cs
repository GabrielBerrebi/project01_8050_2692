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
using BL;
using DSi;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for HostInscription.xaml
    /// </summary>
    /// 
    public partial class HostInscription : Window
    {
       
        IBL instance = BLfactory.Instance;
        Host host = new Host();
        
       
        public HostInscription()
        {
            InitializeComponent();
           // Host host = new Host();
           //this.DataContext = host;
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostViewSource.Source = [generic data source]
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (famillyNameTextBox.Text==""||privateNameTextBox.Text==""||mailAddressTextBox.Text==""||phoneNumberTextBox.Text==""||hostKeyTextBox.Text=="")
            {
                MessageBox.Show("tu dois remplir tout les champ");
            }
            if (famillyNameTextBox.Text != "" || privateNameTextBox.Text != "" || mailAddressTextBox.Text != "" || phoneNumberTextBox.Text != "" || hostKeyTextBox.Text != "")
            {
                host.FamillyName = famillyNameTextBox.Text;
                host.PrivateName = privateNameTextBox.Text;
                host.MailAddress = mailAddressTextBox.Text;
                host.PhoneNumber = int.Parse(phoneNumberTextBox.Text);
                host.HostKey = int.Parse(hostKeyTextBox.Text);
                instance.AddHost(host);
                MessageBox.Show("you have been recordeed with success",host.ToString());
                this.Close();
            }
            
            // MessageBox.Show(host.ToString());
            

        }
    }
}
