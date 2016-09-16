using IsolDesign.Domain.Models;
using System.Collections.Generic;
using IsolDesign.Data.Enums;
using IsolDesign.Domain.Helpers;

namespace IsolDesign.WebUI.Models
{
    public class CustomersIndexViewModel
    {
        public CustomerModel CustomerModel { get; set; }

        public IEnumerable<CustomerModel> CustomerModels { get; set; }

    }
}