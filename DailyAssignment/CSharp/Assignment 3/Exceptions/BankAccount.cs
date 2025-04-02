using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class BankAccount
    {
        public string AccountHolder;
        public double Balance;

        public BankAccount(string accountHolder, double initialBalance)
        {
            this.AccountHolder = accountHolder;
            this.Balance = initialBalance;
        }

        
        public void TransferFunds(double amount)
        {
            if (amount > Balance)
            {
                throw new ZeroException("Transaction Failed: Insufficient Funds!");
            }

            if(amount <= 0)
            {
                throw new ZeroException("Transaction Failed : Please enter amount Greater than zero ");
            }

            Balance -= amount;
            Console.WriteLine($"Transaction Successful! Transferred: ${amount}");
            Console.WriteLine($"Remaining Balance: ${Balance}");
        }
    }
}
