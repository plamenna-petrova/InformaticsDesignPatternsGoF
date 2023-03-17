using System;

namespace Mortgage
{
    public class Customer
    {
        private string name;

        public Customer(string name)
        {
            this.name = name;
        }

        public string Name { get { return name; } }
    }

    public class Bank
    {
        public bool HasSufficientSavings(Customer customer, int amount)
        {
            Console.WriteLine($"Check bank for {customer.Name}");
            return true;
        }
    }

    public class Credit
    {
        public bool HasGoodCredit(Customer customer)
        {
            Console.WriteLine($"Check credit for {customer.Name}");
            return true;
        }
    }

    public class Loan
    {
        public bool HasNoBadLoands(Customer customer)
        {
            Console.WriteLine($"Check loans for {customer.Name}");
            return true;
        }
    }

    public class Mortgage
    {
        Bank bank = new Bank();
        Loan loan = new Loan();
        Credit credit = new Credit();

        public bool IsEligible(Customer customer, int amount)
        {
            Console.WriteLine($"{customer.Name} applies for {amount:C} loan \n");

            bool isEligible = true;

            if (!bank.HasSufficientSavings(customer, amount))
            {
                isEligible = false;
            }
            else if (!loan.HasNoBadLoands(customer))
            {
                isEligible = false;
            }
            else if (!credit.HasGoodCredit(customer))
            {
                isEligible = false;
            }

            return isEligible;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Mortgage mortgage = new Mortgage();

            Customer customer = new Customer("Ann McKinsey");
            bool isEligibleForMortgage = mortgage.IsEligible(customer, 1250000);

            Console.WriteLine($"\nCustomer {customer.Name} has been {(isEligibleForMortgage ? "Approved" : "Rejected")}");

            Console.ReadKey();
        }
    }
}
