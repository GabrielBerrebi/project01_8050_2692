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
namespace PL.WPF
{
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client :Window
       
    {
       
        private BE.GuestRequest guestRequest = null;
        IBL instance = BLfactory.Instance;
        public BE.GuestRequest GuestRequest
        {
            get { return guestRequest; }
        }

        public Client()
        {
            InitializeComponent();
           
            guestRequest = new BE.GuestRequest();
            this.DataContext = guestRequest;
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.Area));
            gardenComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));
            jaccuzziComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));
            childrenAttractionComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));
            poolComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

         
        }

        private void FamillyNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PoolComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(guestRequest.ToString());
                instance.addrequest(guestRequest);
            
        }

        private void AreaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
