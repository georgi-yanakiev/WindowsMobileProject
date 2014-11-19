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
//            ParseObject customer = new ParseObject("Customers");
//            customer["firstName"] = "Ivan";
//            customer["lastName"] = "Petrov";
//            customer["EGN"] = 8010182548;
//            customer["address"] = "Sofia, Lozenec 10";
//            customer["phone"] = 0897654321;
//            customer["email"] = "i_petrov@gmail.com";
//            customer["account"] = "EUR1234567765";
//
//            customer.SaveAsync();

            this.LoadCustomers();
        }

        public async Task LoadCustomers()
        {
            var customers = await new ParseQuery<Customer>().FindAsync();
            this.Customers = customers.AsQueryable().Select(CustomerViewModel.FromCustomer);

//            this.Customers =
//                (IEnumerable<CustomerViewModel>) customers.AsQueryable().Select(CustomerViewModel.FromParseObject);
        }
    }
}