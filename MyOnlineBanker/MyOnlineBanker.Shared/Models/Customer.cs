using System;
using System.Collections.Generic;
using System.Text;
using Parse;

namespace MyOnlineBanker.Models
{
    [ParseClassName("Customers")]
    public class Customer : ParseObject
    {
        [ParseFieldName("firstName")]
        public string FirstName
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("middleName")]
        public string MiddleName
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("lastName")]
        public string LastName
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("address")]
        public string Address
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("phone")]
        public int Phone
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }

        [ParseFieldName("IBAN")]
        public string Iban
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("accountNumber")]
        public string AccountNumber
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("accountType")]
        public string AccountType
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("currency")]
        public string Currency
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("balance")]
        public decimal Balance
        {
            get { return GetProperty<decimal>(); }
            set { SetProperty<decimal>(value); }
        }

        [ParseFieldName("blockedAmount")]
        public decimal BlockedAmount
        {
            get { return GetProperty<decimal>(); }
            set { SetProperty<decimal>(value); }
        }
    }
}