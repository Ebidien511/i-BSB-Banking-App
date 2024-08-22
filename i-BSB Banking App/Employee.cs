using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i_BSB_Banking_App
{
    internal class Employee
    {
        public Employee()
        {

        }

        //Lets employee display all the customers who logged in for the day.
        public void DisplayRegisteredCustomers(List<Customer> customers,ListBox list)
        {
            double totDeposit=0;
            for(int i=0; i < customers.Count; i++)
            {
                totDeposit += customers[i].balance;
                list.Items.Add($"{i+1}\t\t{customers[i].name}\t\t{customers[i].accNum}\t\t{customers[i].accType}\t\tR"+customers[i].balance.ToString());
            }
            list.Items.Add("");
            list.Items.Add("Today we opened " + customers.Count.ToString() + " accounts with a total of R" + totDeposit.ToString());
        }

        //Lets employee print the list of customers registered
        public void PrintRegisteredCustomers(List<Customer> customers, string list)
        {
            double totDeposit = 0;
            for (int i = 0; i < customers.Count; i++)
            {
                totDeposit += customers[i].balance;
                list+=($"{i + 1}\t\t{customers[i].name}\t\t{customers[i].accNum}\t\t{customers[i].accType}\t\tR" + customers[i].balance.ToString()+"\r\n");
            }

            list+=("Today we opened " + customers.Count.ToString() + " accounts with a total of R" + totDeposit.ToString());
        }
    }
}
