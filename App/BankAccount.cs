using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountApp.Exceptions;

namespace BankAccountApp.App
{
    public class BankAccount
    {
        public string Owner { get; set; }
        public Guid AccountNumber { get; set; }
        public decimal Balance { get; protected set; }

        public BankAccount (string owner)
        {
            Owner = owner;
            AccountNumber = Guid.NewGuid();
            Balance = 0;
        }

        public virtual string Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("You cannot deposit $" + amount);

            if (amount > 20000)
                throw new InvalidAmountException("Amount deposit limit Reached");

            Balance += amount;
            return "Deposit Completed Successfully";     
        }

        public string Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("ou cannot withdraw $" + amount);
            if (amount > Balance)
                throw new InvalidAmountException("You don't have enough money");

            Balance -= amount;
            return "Withdraw Completed Successfully";
        }

        public void RestoreBalance(decimal balance)
        {
            Balance = balance;
        }


    }
}
