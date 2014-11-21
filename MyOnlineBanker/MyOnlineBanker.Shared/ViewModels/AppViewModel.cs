using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MyOnlineBanker.Models;
using Parse;

namespace MyOnlineBanker.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private ObservableCollection<CustomerViewModel> customers;

        public IEnumerable<CustomerViewModel> Customers
        {
            get
            {
                if (this.customers == null)
                {
                    this.Customers = new ObservableCollection<CustomerViewModel>();
                }
                return this.customers;
            }
            set
            {
                if (this.customers == null)
                {
                    this.customers = new ObservableCollection<CustomerViewModel>();
                }
                this.customers.Clear();
                foreach (var item in value)
                {
                    this.customers.Add(item);
                }
            }
        }

        public AppViewModel()
        {
//            ParseUser.LogOut();
//            this.LoginUser();
            
//            IList<Account> acc = new List<Account>
//            {
//                new Account("EUR21353765",200, "CXV233463476", "EUR", "Debit"),
//                new Account("USD21353765",100, "DFGKH5346376", "USD", "Deposit"),
//                new Account("BGN21353765",400, "CTWE3246572", "BGN", "Credit"),
//                new Account("EUR21353765",7800, "TYU3457548", "EUR", "Debit"),
//                new Account("JPY21353765", 300, "OPO346346734", "JPY", "Deposit")
//            };
//
//            ParseObject customer = new Customer();
//            customer["firstName"] = "Gosho";
//            customer["lastName"] = "Kirov";
//            customer["EGN"] = 8010182548;
//            customer["address"] = "Sofia, Lozenec 10";
//            customer["phone"] = 0897654321;
//            customer["email"] = "m_kirov@yahoo.com";
//            customer["account"] = acc;
//            customer.ACL = new ParseACL(ParseUser.CurrentUser);
//            customer.SaveAsync();

//            this.CreateUser();
            
            this.LoadCustomers();
        }

//        public async void CreateUser()
//        {
//            
//            var user = new ParseUser()
//            {
//                Username = "gosho",
//                Password = "gosho",
//                Email = "gosho@pesho.com"
//            };
//
//
//            await user.SignUpAsync();
//        }

        public async Task LoadCustomers()
        {
            var customers = await new ParseQuery<Customer>().FindAsync();
            this.Customers = customers.AsQueryable().Select(CustomerViewModel.FromCustomer);
        }
    }
}