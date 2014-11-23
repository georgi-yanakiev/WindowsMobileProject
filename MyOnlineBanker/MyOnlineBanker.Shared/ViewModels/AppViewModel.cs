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
            }
        }

        public CustomerViewModel SelectedAccount { get; set; }

        public AppViewModel()
        {
//            ParseUser.LogOut();
//            this.LoginUser();


//            ParseObject customer = new Customer();
//            customer["fullName"] = "Gosho Goshev Gogata";
//            customer["address"] = "Plovdiv, Ivan Vazov 37";
//            customer["phone"] = "+359123456789";
//            customer["IBAN"] = "CTBSF1568796332";
//            customer["accountNumber"] = "CHF3567894568";
//            customer["accountType"] = "Saving";
//            customer["currency"] = "CHF";
//            customer["balance"] = "35000.00";
//            customer["blockedAmount"] = "200.00";
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