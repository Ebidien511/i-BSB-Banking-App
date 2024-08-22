using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_BSB_Banking_App
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                Management_Form management = new Management_Form();
                this.Hide();
                management.ShowDialog();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer_Registration_Form register = new Customer_Registration_Form();
            this.Hide();
            register.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer_Transaction_Form transaction = new Customer_Transaction_Form();
            this.Hide();
            transaction.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
