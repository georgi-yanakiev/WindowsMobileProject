using System;
using System.Collections.Generic;
using System.Text;
using Parse;

namespace MyOnlineBanker.Models
{
    [ParseClassName("Customers")]
    public class Customer : ParseObject
    {
        [ParseFieldName("fullName")]
        public string FullName
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
        public string Phone
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
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
        public string Balance
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("blockedAmount")]
        public string BlockedAmount
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
    }
}