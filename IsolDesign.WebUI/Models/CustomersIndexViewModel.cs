using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.WebUI.Models
{
    public class CustomersIndexViewModel
    {
        public CustomerModel CustomerModel { get; set; }

        public IEnumerable<CustomerModel> CustomerModels { get; set; } 
    }
}