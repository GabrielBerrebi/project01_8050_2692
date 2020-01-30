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
using System.Net.Mail;
namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for connection.xaml
    /// </summary>
    public partial class connection : Window
    {
        IBL instance = BLfactory.Instance;
        private Host temp;
        private List<Order> orders;

        public object txtMessage { get; private set; }

        public connection(int identifiant)

        {
            InitializeComponent();
            foreach (Host host in DataSource.hosts)
            {
                if (identifiant == host.HostKey)
                {
                    temp = host;
                }
            }

            List<HostingUnit> Myhosting = new List<HostingUnit>();
            foreach (HostingUnit Hosting in DataSource.hostingUn)
            {
                if (Hosting.Owner == temp)
                {
                    
                    hosting_unit.Items.Add("HostingUnitKey: " + Hosting.HostingUnitKey + "  " + Hosting.Description);
                    Myhosting.Add(Hosting);
                }

            }
            foreach(Order order in DataSource.orders)
            {
                if (order.unit.Owner.HostKey==temp.HostKey)
                {
                    
                    hosting.Items.Add(order.OrderKey +"  " +order.requete.EntryDate+" to "+order.requete.ReleaseDate);
                }
            }
                    
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int count = 0;
            if (delete.Text=="")
            {
                MessageBox.Show("tu dois remplir tout les champs cherri!");
            }
            if (instance.verifyunit(int.Parse(delete.Text))==true)
            {
                HostingUnit hostingUnit;
                hostingUnit = instance.GetHostingUnit(int.Parse(delete.Text));
                if (hostingUnit.Owner.HostKey == temp.HostKey)
                {
                    count++;
                    instance.releasehostingunit(hostingUnit);
                    MessageBox.Show("delete with success!");

                    this.Close();
                }

            }

            if (count == 0)
            {
                MessageBox.Show("not deleted!");
            }
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            addhostingunit add = new addhostingunit(temp);
            add.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            foreach (Order order in DataSource.orders )
            {
                if(order.OrderKey==int.Parse(guestrequestkey.Text))
                {
                    instance.AddCalendar(order.requete, order.unit);
                    order.status = Status.MailSent;
                    MailMessage mail = new MailMessage();
                    mail.To.Add("gabriel27051998@gmail.com");
                    mail.From = new MailAddress(order.unit.Owner.MailAddress);
                    mail.Subject = "mailSubject";
                    mail.Body = order.ToString();
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Credentials = new System.Net.NetworkCredential("projetpremiersemestre@gmail.com","mahonlev");
                    smtp.EnableSsl = true;
                   try
                    {
                        smtp.Send(mail);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    

                }
            }
        }
    }


}

   

  


  

