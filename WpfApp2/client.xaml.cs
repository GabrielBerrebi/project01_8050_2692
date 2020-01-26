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


namespace WpfApp2
{

    public partial class client : Window
    {
        IBL instance = BLfactory.Instance;
        private GuestRequest guestRequest = null;

        public GuestRequest GuestRequest { get => guestRequest; }
        public client()
        {

            InitializeComponent();

            guestRequest = new GuestRequest();

            AJD.Text = DateTime.Now.ToString();
            areaComboBox.SelectedIndex = 0;
            poolComboBox.SelectedIndex = 0;
            jaccuzziComboBox.SelectedIndex = 0;
            gardenComboBox.SelectedIndex = 0;
            childrenAttractionComboBox.SelectedIndex = 0;
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.Area));
            jaccuzziComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));
            poolComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));
            childrenAttractionComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));
            gardenComboBox.ItemsSource = Enum.GetValues(typeof(BE.CollectionClearance));

        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int error = 0;
            if (  privateNameTextBox.Text == "" || famillyNameTextBox.Text == "" || mailAddressTextBox.Text == "" || childrenTextBox.Text == "" || numAdultesTextBox.Text == "" || int.Parse(childrenTextBox.Text) < 0 || int.Parse(childrenTextBox.Text) > 10 || int.Parse(numAdultesTextBox.Text) < 0 || int.Parse(childrenTextBox.Text) > 10)

            {
                error++;
                MessageBox.Show("sorry their is an error !");
            }
            if (DateTime.Parse(registrationDateDatePicker.Text).AddDays(1) >= DateTime.Parse(releaseDateDatePicker.Text))
            {
                MessageBox.Show("the date than you pick are not correct");
                error++;
            }


            if (error==0)
            {
                guestRequest.Area = (BE.Area)Enum.Parse(typeof(BE.Area), areaComboBox.SelectedItem.ToString());
                guestRequest.Jaccuzzi = (BE.CollectionClearance)Enum.Parse(typeof(BE.CollectionClearance), jaccuzziComboBox.SelectedItem.ToString());
                guestRequest.Pool = (BE.CollectionClearance)Enum.Parse(typeof(BE.CollectionClearance), poolComboBox.SelectedItem.ToString());
                guestRequest.Garden = (BE.CollectionClearance)Enum.Parse(typeof(BE.CollectionClearance), gardenComboBox.SelectedItem.ToString());
                guestRequest.ChildrenAttraction = (BE.CollectionClearance)Enum.Parse(typeof(BE.CollectionClearance), childrenAttractionComboBox.SelectedItem.ToString());
                guestRequest.PrivateName = privateNameTextBox.Text;
                guestRequest.FamillyName = famillyNameTextBox.Text;
                guestRequest.MailAddress = mailAddressTextBox.Text;
                guestRequest.NumAdultes = int.Parse(numAdultesTextBox.Text);
                guestRequest.Children = int.Parse(childrenTextBox.Text);
                guestRequest.EntryDate = DateTime.Parse(registrationDateDatePicker.Text);
                guestRequest.ReleaseDate = DateTime.Parse(releaseDateDatePicker.Text);

                instance.addrequest(guestRequest);

                MessageBox.Show(guestRequest.ToString(), "felicitation vous etes inscris dans nos registres!");
                proposition prop = new proposition(guestRequest);

                prop.Show();

            }



        }


    }
}
