﻿
using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Interfaces
{
    public interface IGetCustomers_Handler
    {
        IEnumerable<CustomerModel> GetAllCustomers();
    }
}
