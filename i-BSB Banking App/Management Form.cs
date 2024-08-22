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
    public partial class Management_Form : Form
    {
        Bank myBank = new Bank();
        Employee employee = new Employee();
        Customer customer = new Customer();
        List<Customer> customerDatabase = Bank.customers;


        public Management_Form()
        {
            InitializeComponent();
        }
        string name, accType, accNum,deposit;
        
        private void Management_Form_Load(object sender, EventArgs e)
        {
            lsbCustomers.Items.Add("\t\t\t\tCustomer Registration Report for " + DateTime.Now);
            lsbCustomers.Items.Add("");
            lsbCustomers.Items.Add("No.\t\tCustomer Name\t\tAccount Number\t\tAccount Type\t\tDeposit Amount\r\n");

            employee.DisplayRegisteredCustomers(customerDatabase, lsbCustomers);

            name = customer.name;
            accType = customer.accType;
            accNum = customer.accNum;
            deposit = customer.balance.ToString();
        }

        private void lsbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            this.Hide();
            main.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            /* string text = "\t\t\t\tCustomer Registration Report for " + DateTime.Now+"\r\n\r\n" +
                 "No.\t\tCustomer Name\t\tAccount Number\t\tAccount Type\t\tDeposit Amount\r\n\r\n";*/
            string text = "";
            foreach(string customer in lsbCustomers.Items)
            {
                text += customer.ToString()+"\r\n";
            }


            

            Font printFont = new System.Drawing.Font
            ("Arial", 15, System.Drawing.FontStyle.Regular);
            e.Graphics.DrawString(text, printFont, Brushes.Black, 10, 10);
        }
    }
}
