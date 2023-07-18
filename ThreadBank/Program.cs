using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadBank
{
    internal class Program
    {
        public class BankAccount
        {
            private double balance = 0;
            private object lockobject = new object();

            public double Balance { get { return balance; } }

            public void Deposit(double amount)
            {
                lock (lockobject)
                {
                    balance += amount;
                }
            }

            public void Withdraw(double amount)
            {
                lock (lockobject)
                {
                    if (balance >= amount)
                    {
                        balance -= amount;
                    }
                    else
                    {
                        throw new Exception("Invalid Fund");
                    }
                }
            }

            public void Transfer(double amount, BankAccount toTransfer)
            {
                lock (lockobject)
                {
                    if (balance >= amount)
                    {
                        balance -= amount;
                        toTransfer.Deposit(amount);
                    }
                    else
                    {
                        throw new Exception("Invalid Fund");
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount();
            account1.Deposit(1000);

            BankAccount account2 = new BankAccount();
            account2.Deposit(500);

            Console.WriteLine($"Account 1 Balance: {account1.Balance}");
            Console.WriteLine($"Account 2 Balance: {account2.Balance}");

            // Transfer $200 from account1 to account2
            account1.Transfer(200, account2);

            Console.WriteLine($"Account 1 Balance after transfer: {account1.Balance}");
            Console.WriteLine($"Account 2 Balance after transfer: {account2.Balance}");

            Console.ReadLine();
        }
    }
}
