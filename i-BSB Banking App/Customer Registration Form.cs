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
    public partial class Customer_Registration_Form : Form
    {
        Bank myBank = new Bank();
         List<Customer> new_customers = new List<Customer>();

        public Customer_Registration_Form()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Takes customer back to the Main Form
        {
            Form1 mainform = new Form1();
            this.Hide();
            mainform.Show();
        }

        private void button2_Click(object sender, EventArgs e) //Takes customer to  Transaction form
        {
            Customer_Transaction_Form transaction = new Customer_Transaction_Form();
            this.Hide();
            transaction.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)

        {
            txtSum.Clear(); //clears
            try
            {
                string name = $"{txtFname.Text} {txtSurname.Text}";
                string accType;
                double deposit = Convert.ToDouble(txtDeposit.Text);
                string accNum="";

                //Check whether all Details fields have been entered.
                if (string.IsNullOrWhiteSpace(txtFname.Text)  || string.IsNullOrWhiteSpace(txtSurname.Text) || string.IsNullOrWhiteSpace(txtDeposit.Text) || cbAcctype.SelectedItem == null)
                {
                    MessageBox.Show("In order for you to register, we need you to fill in all the fields above.\r\n Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ///Does not allow 0 deposit to be entered
                else if (deposit <= 0)
                {
                    MessageBox.Show("Zero Deposits cannot be made.\r\nPlease enter a deposit amount which is more than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


                //if all fields are filled, customer is added to the database.
                else
                {
                    accType = cbAcctype.SelectedItem.ToString();
                    accNum =myBank.GenerateAccNum();
                    Customer customer = new Customer(name, accType, accNum, deposit);
                    myBank.AddCustomer(customer);//adds customer to database
                    myBank.DiplayAllCus(txtSum, customer);//displays customer details
                    new_customers = Bank.customers;
                }


            }
            catch (FormatException)
            {
                    MessageBox.Show("Please enter a valid deposit amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);               
            }


        }

        private void Customer_Registration_Form_Load(object sender, EventArgs e)
        {
            //Initialize Account Types in combobox
            cbAcctype.Text = "Select...";
            cbAcctype.Items.Add("Current Account"); 
            cbAcctype.Items.Add("Savings Account");
            cbAcctype.Items.Add("Fixed Deposit Account");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtSum.Clear();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

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
