# i-BSB Banking App

This is where it all started, my first application built without going through tutorial hell. The i-BSB Banking App is simple a C# application, making use of ASP.Net's Windows Form Framework. I developed this as a capstone project at UCT and it solidified my understanding in the concept of Object Oriented Programming. 
#### IMPORTANT NOTE: 
This project is quite old was not finished due to time constraints so there may be a few errors here and there. There is still major room for improvement, and the coding practices in this project are still very novice compared to my current standards.

## Features:
There are 2 types of users:
### Customers:
- Create an i-BSB Banking account.
  - Generates a unique account number that is used to login.
  - When creating an account, users can make choose an account type and make an initial deposit.
- Perform a Transaction
  - Users enter their account number and the application displays their name.
  - Users can view their current balance, make withdraws and also make deposits.
  - After each transaction, a summary of the transaction is displayed along with the time it was performed.
  - This summary can also be printed or saved as a pdf.
### Employees:
- View an Account Summary Report
  - Can only be performed after an account has been created.
  - Displays all the accounts opened for the day as well as their relevant information.
  - Calculates the sum of the balances of each account opened.

