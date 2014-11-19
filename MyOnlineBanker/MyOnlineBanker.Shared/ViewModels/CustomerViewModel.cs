using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MyOnlineBanker.Models;
using Parse;

namespace MyOnlineBanker.ViewModels
{
    public class CustomerViewModel
    {
        public static Expression<Func<Customer, CustomerViewModel>> FromCustomer
        {
            get
            {
                return model =>
                    new CustomerViewModel()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Account = model.Account
                    };
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Account { get; set; }
    }
}
