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

        // Constructor
        public BankAccount(string accountHolder, double initialBalance)
        {
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        // Method to Transfer Funds
        public void TransferFunds(double amount)
        {
            if (amount > Balance)
            {
                throw new ZeroException("Transaction Failed: Insufficient Funds!");
            }

            Balance -= amount;
            Console.WriteLine($"Transaction Successful! Transferred: ${amount}");
            Console.WriteLine($"Remaining Balance: ${Balance}");
        }
    }
}
