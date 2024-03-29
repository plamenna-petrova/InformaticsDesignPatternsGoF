﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class VendingMachine
    {
        public VendingMachine(List<Product> products)
        {
            Products = products;
            CurrentState = new IdleState(this);
        }

        public List<Product> Products { get; set; }

        public State CurrentState { get; private set; }

        public string SelectedProductCode { get; set; }

        public void SelectProduct(string productCode) => CurrentState.SelectProduct(productCode);

        public void InsertMoney(decimal amount) => CurrentState.InsertMoney(amount);

        public void DispenseProduct() => CurrentState.DispenseProduct();

        public void Refill(List<Product> products) => CurrentState.Refill(products);

        public void SetState(State state) => CurrentState = state;
    }
}
