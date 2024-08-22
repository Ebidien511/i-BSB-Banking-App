using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_BSB_Banking_App
{
    internal class Bank
    {
        public static List<Customer> customers;
        public static List<Customer> Customers
        {
            get { return customers; }
            set { customers = value; }
        }

        public Bank()
        {

        }

        //Adds customer to the database
        public void AddCustomer(Customer customer)
        {
            if (customers == null)
            {
                customers = new List<Customer>();
            }
            customers.Add(customer);
        }

        //Displays new customer details
        public void DiplayAllCus(TextBox txtSummary, Customer customer)
        {
            txtSummary.Text += $"Your account has been created successfully, Great!\r\n\r\n" +
                                $"These are the details below:\r\n" +
                                $"Name of Holder: {customer.name}\r\n" +
                                $"Account Type: {customer.accType}\r\n" +
                                $"Initial Deposit: R{customer.balance}\r\n\r\n" +
                                $"Your account number is: {customer.accNum}";
        }

        //Method to generate a new Account Number for customer that has registered
        public string GenerateAccNum()
        {
            string accountNumber = "";
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                accountNumber += r.Next(0, 9).ToString();
            }

            return accountNumber;
        }

        //Method which checks the customer database to see if the account number matches.       
        public Customer FindCustomer(string numSearch, List<Customer> list)
        {
            foreach (Customer customer in list)
            {
                if (customer.accNum == numSearch)
                {
                    return customer;
                }
            }
            return null;
        }


    //Displays how the custoemers balance has changed and what there current balance is
    public void DisplayTransactionUpdate(TextBox textbox, ComboBox comboBox, double amount)
        {
            if (comboBox.SelectedIndex == 0)
            {
                textbox.Text += "Amount Withdrawm: R" + amount.ToString() + "\r\non " + DateTime.Now + "\r\n";
            }
            else if (comboBox.SelectedIndex == 1)
            {
                textbox.Text += "Amount Deposited: R" + amount.ToString() + "\r\non " + DateTime.Now + "\r\n";
            }
        }
    }
}
