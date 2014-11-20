using System;
using System.Collections.Generic;
using System.Text;

namespace MyOnlineBanker.Models
{
    public class Account
    {
        private string accNumber;

        private decimal balance;

        private string iban;

        private string currency;

        private string type;
        
        public Account(string accNumber, decimal balance, string iban, string currency, string type)
        {
            this.AccNumber = accNumber;
            this.Balance = balance;
            this.Iban = iban;
            this.Currency = currency;
            this.Type = type;
        }


        public string AccNumber
        {
            get { return accNumber; }
            set { accNumber = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public string Iban
        {
            get { return this.iban; }
            set { this.iban = value; }
        }

        public string Currency
        {
            get { return this.currency; }
            set { this.currency = value; }
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}
