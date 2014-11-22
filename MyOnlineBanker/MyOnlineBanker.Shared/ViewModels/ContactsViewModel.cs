using System;
using System.Collections.Generic;
using System.Text;

namespace MyOnlineBanker.ViewModels
{
    public class ContactsViewModel
    {

        public ContactsViewModel()
        {
            this.Address = "Sofia 1000";
            this.CallCenter = "+359123456789";
            this.Fax = "+359123456789";
            this.Email = "mybank@mybank.com";
        }

        public string Address { get; set; }

        public string CallCenter { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }
    }
}
