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
        private HostingUnit HostingUnit=null;
        Host host;
        public HostingUnit hosting { get => HostingUnit; }
        public addhostingunit(Host b)
        {
            HostingUnit = new HostingUnit();
            InitializeComponent();
            host = b;
            childrenAttractionComboBox.SelectedIndex = 0;
            areaComboBox.SelectedIndex = 0;
            poolComboBox.SelectedIndex = 0;
            jaccuzziComboBox.SelectedIndex = 0;
            gardenComboBox.SelectedIndex = 0;
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.Area));
            jaccuzziComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));
            poolComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));
            hostTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.HostingType));           
            gardenComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));
            childrenAttractionComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));

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
            int error = 0;
            if ((childrenTextBox.Text=="")||(numAdultesTextBox.Text=="")||(descriptionTextBox.Text=="")||(priceTextBox.Text==""))
            {
                MessageBox.Show("remplis tout les champs!");
                error++;
            }
            if (error == 0)
            {


                HostingUnit.Children = int.Parse(childrenTextBox.Text);
                HostingUnit.Description = descriptionTextBox.Text;
                HostingUnit.price = int.Parse(priceTextBox.Text);
                HostingUnit.NumAdultes = int.Parse(numAdultesTextBox.Text);
                HostingUnit.Owner = host;
               
                if (instance.addhostingunit(HostingUnit) == true)
                {

                    
                    MessageBox.Show("your hosting unit has been addes successfull!");
                    this.Close();
                    
                }
                else MessageBox.Show("sry there is an error!");

            }
        }
    }
}
