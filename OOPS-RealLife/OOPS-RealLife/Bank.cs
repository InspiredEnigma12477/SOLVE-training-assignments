using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_RealLife
{
    class Bank
    {
        int AccountNo { get; }
        String Username { get;  }
        double Balance { get; private set; }

        public Bank(int accountNo, string username, double balance)
        {
            AccountNo = accountNo;
            Username = username;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine("{0} deposited successfully. Current balance: {1}", amount, Balance);
        }

        

        public void Withdraw(double amount)
        {
            if (Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine("{0} withdrawn successfully. Current balance: {1}", amount, Balance);
            }
        }
    }
}
