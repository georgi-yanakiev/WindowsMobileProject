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
    public class AppViewModel : ViewModelBase, ICustomerViewModel
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
//                this.SelectedAccount = this.customers.First();
            }
        }

        public CustomerViewModel SelectedAccount { get; set; }

        public AppViewModel()
        {
//            ParseUser.LogOut();
//            this.LoginUser();


//                        FirstName = model.FirstName,
//                        MiddleName = model.MiddleName,
//                        LastName = model.LastName,
//                        Address = model.Address,
//                        Phone = model.Phone,
//                        Iban = model.Iban,
//                        AccountNumber = model.AccountNumber,
//                        AccountType = model.AccountType,
//                        Currency = model.Currency,
//                        Balance = model.Balance,
//                        BlockedAmount = model.BlockedAmount

//            ParseObject customer = new Customer();
//            customer["firstName"] = "Gosho";
//            customer["middleName"] = "Ivanov";
//            customer["lastName"] = "Kirov";
//            customer["address"] = "Sofia, Lozenec 10";
//            customer["phone"] = 359897654321;
//            customer["IBAN"] = "UBBSF57645675432";
//            customer["accountNumber"] = "EUR7644516841";
//            customer["accountType"] = "Deposit";
//            customer["currency"] = "EUR";
//            customer["balance"] = 300.40;
//            customer["blockedAmount"] = 5.00;
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