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
    public partial class Customer_Transaction_Form : Form
    {
        Bank myBank = new Bank();
        Customer customer = new Customer();
        List<Customer> registeredCustomers = Bank.customers;
        public Customer_Transaction_Form()
        {
            InitializeComponent();

        }
        double balance;
        string accName;
        string accNum;
        string accType;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

                accNum = txtAccNum.Text;
                Customer customer = myBank.FindCustomer(accNum, registeredCustomers);
  

            //Check if Account Number is registered in database
            if (customer == null)
                {
                    MessageBox.Show("Account number not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    accType = customer.accType;
                    accName = customer.name;
                    balance = customer.balance;


                    btnView.Enabled = true;
                    btnPrint.Enabled = true;

                    label2.Text = $"Welcome back {customer.name}.\r\nYou may select a transaction option\r\non the right.";
                    label2.Show();
                    txtAmount.ReadOnly = false;
                }
            


        }

        private void button1_Click_1(object sender, EventArgs e)//Takes customer back to Main Form
        {
            Form1 mainform = new Form1();
            this.Hide();
            mainform.Show();
        }

        private void Customer_Transaction_Form_Load(object sender, EventArgs e)
        {
            label2.Hide();
            label2.BackColor = Color.Transparent;
            groupBox1.BackColor = Color.Transparent;
            groupBox2.BackColor = Color.Transparent;



            //Initialize transaction options
            cbTransactions.Text = "Select Transaction...";
            cbTransactions.Items.Add("Withdraw");
            cbTransactions.Items.Add("Deposit");

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            customer.ViewBalance(txtBalSum, balance);
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            double amount =Convert.ToDouble(txtAmount.Text);
            double newBalance = 0;

            if (cbTransactions.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a transaction option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cbTransactions.SelectedIndex==0)
            {
                if (balance < 0)
                {
                    MessageBox.Show("You have already overdrafted in the past and are only allowed to do this once.\r\n" +
                        "You need to make a deposit to cover your previous overdraft in order to be elligble " +
                        "for another one", "Not Elligble for Overdraft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    txtAmount.Clear();
                    balance = customer.Withdrawal(amount, balance);
                    myBank.DisplayTransactionUpdate(txtBalSum, cbTransactions, amount);
                    customer.ViewBalance(txtBalSum, balance);
                    customer.SetNewBalance(balance);
                }

            }
            else if (cbTransactions.SelectedIndex == 1)
            {
                txtAmount.Clear();
                balance=customer.MakeDeposit(amount, balance);
                myBank.DisplayTransactionUpdate(txtBalSum, cbTransactions, amount);
                customer.ViewBalance(txtBalSum, balance);
                customer.SetNewBalance(balance);
            }

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string text = $"Account Statement\r\n\r\n" +
                $" Account Holder: {accName}\r\n" +
                $"Account Type: {accType}\r\n" +
                $"Account Number: {accNum}\r\n" +
                $"Current Balance R{balance}\r\n" +
                $"Date of Issure: {DateTime.Now}";

            Font printFont = new System.Drawing.Font
            ("AOE", 35, System.Drawing.FontStyle.Regular);
            e.Graphics.DrawString(text, printFont,Brushes.Black, 10, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            this.Hide();
            main.ShowDialog();
        }
    }
}
