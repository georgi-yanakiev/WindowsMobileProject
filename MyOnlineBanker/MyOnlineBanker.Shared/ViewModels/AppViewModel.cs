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

        public CustomerViewModel SelectedAccount { get; set; }

        public AppViewModel()
        {
            this.LoadCustomers();
        }

        public async Task LoadCustomers()
        {
            var customers = await new ParseQuery<Customer>().FindAsync();
            this.Customers = customers.AsQueryable().Select(CustomerViewModel.FromCustomer);
        }
    }
}