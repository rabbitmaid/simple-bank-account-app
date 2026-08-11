using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    public class SavingsAccount: BankAccount
    {
        public decimal InterestRate { get; set; cd }

        public SavingsAccount(string owner, decimal interestRate) : base(owner + " (" + interestRate + "%)") 
        {
            InterestRate = interestRate;
        }

        public override string Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("You cannot deposit $" + amount);

            if (amount > 20000)
                throw new InvalidAmountException("Amount deposit limit Reached");

            decimal interestAmount = amount * (InterestRate / 100);

            Balance += (amount + interestAmount);
            return "Deposit Completed Successfully";
        }
    }
}
