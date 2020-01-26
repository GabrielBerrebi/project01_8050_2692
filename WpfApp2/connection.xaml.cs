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
    /// Interaction logic for connection.xaml
    /// </summary>
    public partial class connection : Window
    {
        IBL instance = BLfactory.Instance;
        public connection(int identifiant)
        {
            InitializeComponent();
            List<HostingUnit> Myhosting = new List<HostingUnit>();
            foreach (HostingUnit Hosting in DataSource.hostingUn)
            {

                if (Hosting.Owner.HostKey == identifiant)//Ma liste de hosting  
                {
                    hosting_unit.Items.Add("HostingUnitKey: " + Hosting.HostingUnitKey);
                    Myhosting.Add(Hosting);
                }

            }
            var orders = (from Order order in DataSource.orders
                          from HostingUnit hosting in Myhosting

                          where order.HostingUnitKey == hosting.HostingUnitKey && order.status==Status.MailSent
                          select order);
            foreach (Order order in orders)
            {
                hosting.Items.Add("EntryDate: " + order.requete.EntryDate + "ReleaseDate: " + order.requete.ReleaseDate + "HostingUnitkey: " + "requestkey: " + order.GuestRequestKey + order.HostingUnitKey + "FullName: " + order.requete.FamillyName + " " + order.requete.PrivateName);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GuestRequest requete;
            if (guestrequestkey.Text == "") { MessageBox.Show("tu dois remplir tout les champs!"); }
            else
            
            foreach (GuestRequest request in DataSource.guestRequests)
            {
                if (request.GuestRequestKey == int.Parse(guestrequestkey.Text))
                {
                        requete = request;
                        MessageBox.Show("sent a mail to your client to the email: " + request.MailAddress);
                        
                    
                      
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            foreach  (HostingUnit hosting in DataSource.hostingUn)
            {
                if (int.Parse(delete.Text)==hosting.HostingUnitKey)
                {
                instance.releasehostingunit(hosting);
                 MessageBox.Show("delete with success!");
                    this.Close();
                    break;
                }
            }
            MessageBox.Show("hosting unit not find!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            addhostingunit add = new addhostingunit();
            add.Show();
        }
    }

  


  
}
