using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSi;
using BE;

namespace WpfApp2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            textBox1.Text = "";
            // The password character is an asterisk.
            textBox1.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            textBox1.MaxLength = 14;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Host item in DataSource.hosts)
            {
                {
                    if (int.Parse(textBox1.Text) == item.HostKey)
                    {
                        int identifiant = int.Parse(textBox1.Text);
                        if (MessageBox.Show("Are You Sure To Connect?!", "Open UserAccount", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            connection connection = new connection(identifiant);
                            connection.Show();
                        }
                    }
                }
            }
            Console.Beep();
        }
    }
}
