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
           List<HostingUnit> temp = new List<HostingUnit>();
            temp = instance.proposition(a);

            foreach (HostingUnit item in temp)
            {
                meschoix.Items.Add("Name"+item.HostingUnitName+"     Number"+item.HostingUnitKey+"       description:"+item.Description);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (chh.Text=="")
            {
                MessageBox.Show("remplit tout les champs");
            }
            foreach (Order item in DataSource.orders)
            {
                if (item.HostingUnitKey==int.Parse(chh.Text))
                {
                    instance.StatusModify(request);
                    MessageBox.Show("your request had been sent to the host ");
                    this.Close();
                }
            }
        }
    }
}
