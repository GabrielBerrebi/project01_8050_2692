using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DSi;
using BE;
namespace WpfApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Connect To Gmail","Open Gmail",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Process.Start("mspaint");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
               listView1.Clear();
                foreach (Order order in DataSource.orders)
                {
                   listView1.Items.Add(order.ToString());
                }
                
            }
            if (comboBox1.SelectedIndex == 1)
            {
               listView1.Clear();
                foreach (Host host in DataSource.hosts)
                {
                   listView1.Items.Add(host.ToString());
                }

            }
            if (comboBox1.SelectedIndex == 2)
            {
                listView1.Clear();
                foreach (GuestRequest request in DataSource.guestRequests)
                {
                    listView1.Items.Add(request.ToString());
                }

            }
            if (comboBox1.SelectedIndex == 3)
            {
                listView1.Clear();
                foreach (HostingUnit hosting in DataSource.hostingUn)
                {
                  listView1.Items.Add(hosting.ToString());
                }

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           listView1.Clear();
        }

      

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("");
        }
    }
  
}
