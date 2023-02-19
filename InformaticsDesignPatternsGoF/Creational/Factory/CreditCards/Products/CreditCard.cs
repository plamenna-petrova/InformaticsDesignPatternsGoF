using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCards.Products
{
    public abstract class CreditCard
    {
        private string model;
        private decimal limit;
        private decimal annualCharge;

        protected CreditCard(string model, decimal limit, decimal annualCharge)
        {
            this.model = model;
            this.limit = limit;
            this.annualCharge = annualCharge;
        }

        public string Model { get => model; set => model = value; }

        public decimal Limit { get => limit; set => limit = value; }

        public decimal AnnualCharge { get => annualCharge; set => annualCharge = value; }

        public override string ToString()
        {
            return $"Credit Card: {this.GetType().Name} with model: {Model}, limit: {Limit} and annual charge: {AnnualCharge}";
        }
    }
}
