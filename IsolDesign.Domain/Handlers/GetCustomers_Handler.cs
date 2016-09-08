using System;
using System.Collections.Generic;
using IsolDesign.Domain.Interfaces;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.DataAccess;
using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Handlers
{
    public class GetCustomers_Handler : IGetCustomers_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public GetCustomers_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            var customersFromDb = _unitOfWork.Customers.GetAll();
            List<CustomerModel> customerModels = new List<CustomerModel>();

            foreach (var customer in customersFromDb)
            {
                CustomerModel customerModel = new CustomerModel
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Address = customer.Address,
                    Country = customer.Country,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    Category = customer.Category,
                    Homepage = customer.Homepage,
                    ContactName = customer.ContactName,
                    ContactPhone = customer.Phone,
                    ContactEmail = customer.Email
                };
                customerModels.Add(customerModel);
            }
            return customerModels;
        }
    }
}
