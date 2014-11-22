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
//                        MiddleName = model.MiddleName,
//                        LastName = model.LastName,
//                        Address = model.Address,
//                        Phone = model.Phone,
//                        Iban = model.Iban,
                        AccountNumber = model.AccountNumber,
//                        AccountType = model.AccountType,
                        Currency = model.Currency,
                        Balance = model.Balance,
//                        BlockedAmount = model.BlockedAmount
                    };
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Account { get; set; }

        public string AccountNumber { get; set; }

        public string MiddleName { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

        public string Iban { get; set; }

        public string AccountType { get; set; }

        public string Currency { get; set; }

        public decimal Balance { get; set; }

        public decimal BlockedAmount { get; set; }
    }
}