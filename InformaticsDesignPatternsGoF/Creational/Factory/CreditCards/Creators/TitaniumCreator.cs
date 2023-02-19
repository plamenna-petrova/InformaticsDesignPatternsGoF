using CreditCards.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCards.Creators
{
    public class TitaniumCreator : ICreditCardCreator
    {
        public CreditCard CreateCreditCard(string model, decimal limit, decimal annualCharge)
        {
            return new Titanium(model, limit, annualCharge);
        }
    }
}
