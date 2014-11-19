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

        [ParseFieldName("lastName")]
        public string LastName
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("EGN")]
        public int EGN
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
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

        [ParseFieldName("email")]
        public string Email
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("account")]
        public string Account
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
    }
}