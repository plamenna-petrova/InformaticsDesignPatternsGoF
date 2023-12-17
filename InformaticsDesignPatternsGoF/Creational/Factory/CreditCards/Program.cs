using CreditCards.Creators;
using CreditCards.Products;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CreditCards
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            ICreditCardCreator[] creditCardCreators = new ICreditCardCreator[]
            {
                new MoneyBackCreator(),
                new TitaniumCreator(),
                new PlatinumCreator()
            };

            List<CreditCard> creditCards = new List<CreditCard>();

            foreach (var creator in creditCardCreators)
            {
                Console.WriteLine($"Enter credit card details for type {creator.GetType().Name.Replace("Creator", "")}: ");
                string creditCardModel = Console.ReadLine();
                decimal creditCardLimit = decimal.Parse(Console.ReadLine());
                decimal creditCardAnnualCharge = decimal.Parse(Console.ReadLine());
                creditCards.Add(creator.CreateCreditCard(creditCardModel, creditCardLimit, creditCardAnnualCharge));
            }

            foreach (var creditCard in creditCards)
            {
                Console.WriteLine(creditCard.ToString());
            }
        }
    }
}
