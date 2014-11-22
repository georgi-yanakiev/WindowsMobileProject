using System;
using System.Collections.Generic;
using System.Text;

namespace MyOnlineBanker.ViewModels
{
    public interface ICustomerViewModel
    {
        IEnumerable<CustomerViewModel> Customers { get; set; }
    }
}
