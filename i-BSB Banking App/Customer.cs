using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_BSB_Banking_App
{
    internal class Customer
    {
        public string name { get; set; }
        public string accType { get; set; }
        public string accNum { get; set; }
        public double balance { get; set; }

        public Customer()
        {

        }

        public Customer(string name, string accType, string accNum, double balance)
        {
            this.name = name;
            this.accType = accType;
            this.accNum = accNum;
            this.balance = balance;
        }

        //Lets customer view their current balance
        public void ViewBalance(TextBox textbox, double accBalance)
        {
            textbox.Text += "Current Balance: R" + accBalance.ToString() + "\r\n\r\n";
        }

        //Lets customer make a deposit
        public double MakeDeposit(double depAmount, double accBalance)
        {
            accBalance += depAmount;
            return accBalance;
        }

        //Lets customer make a withdrawal
        public double Withdrawal(double withAmount, double accBalance)
        {
            accBalance -= withAmount;
            return accBalance;
        }

        public void SetNewBalance(double newBalance)
        {
            balance = newBalance;
        }

    }
    
}
