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
using BL;
using BE;
using DSi;
namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for addhostingunit.xaml
    /// </summary>
    public partial class addhostingunit : Window
    {
        IBL instance = BLfactory.Instance;
        private HostingUnit Hosting = null;

        public HostingUnit hosting { get => Hosting; }
        public addhostingunit()
        {
            InitializeComponent();
            areaComboBox.SelectedIndex = 0;
            poolComboBox.SelectedIndex = 0;
            jaccuzziComboBox.SelectedIndex = 0;
            gardenComboBox.SelectedIndex = 0;
            
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.Area));
            jaccuzziComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));
            poolComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));
            hostTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.HostingType));           
            gardenComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource hostViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((childrenTextBox.Text=="")||(numAdultesTextBox.Text=="")||(descriptionTextBox.Text=="")||(phoneNumberTextBox.Text=="")||(priceTextBox.Text=="")||(hostKeyTextBox.Text=="")||(privateNameTextBox.Text=="")||(famillyNameTextBox.Text=="")||(mailAddressTextBox.Text==""))
            {
                MessageBox.Show("remplis tout les champs!");
            }
            Hosting.Children =int.Parse(childrenTextBox.Text);
            Hosting.Description = descriptionTextBox.Text;
            Hosting.Owner.FamillyName = famillyNameTextBox.Text;
            Hosting.Owner.PrivateName = privateNameTextBox.Text;
            Hosting.Owner.MailAddress = mailAddressTextBox.Text;
            Hosting.Owner.PhoneNumber = int.Parse(phoneNumberTextBox.Text);
            Hosting.Owner.HostKey = int.Parse(hostKeyTextBox.Text);
            Hosting.price = int.Parse(priceTextBox.Text);
            Hosting.NumAdultes = int.Parse(numAdultesTextBox.Text);
            if (instance.addhostingunit(Hosting) == true)
            {

                MessageBox.Show("your hosting unit has been addes successfull!");
                this.Close();
            }
            else MessageBox.Show("sry there is an error!");

             
        }
    }
}
