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
using DSi;
using BE;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for proposition.xaml
    /// </summary>
    
    public partial class proposition : Window
    {
        IBL instance = BLfactory.Instance;
        GuestRequest request;
        public proposition(GuestRequest a )
        {
            InitializeComponent();
            request = a;
         foreach (HostingUnit item in instance.proposition(a))
            {
                meschoix.Items.Add(item.HostingUnitName+"\n Description de notre hotel:"+item.Description+"\n Numero De Commande:"+item.HostingUnitKey+"\n location:"+item.Area);
             
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (chh.Text=="")
            {
                MessageBox.Show("remplis touts les champs !");
            }
          
                    instance.AddOrder(request,instance.GetHostingUnit(int.Parse(chh.Text)));
                    MessageBox.Show("your request had been sent to the host ");
                    this.Close();
             
        }
    }
}
