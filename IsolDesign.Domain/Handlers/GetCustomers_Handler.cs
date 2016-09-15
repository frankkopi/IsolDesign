using System.Collections.Generic;
using IsolDesign.Domain.Interfaces;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.DataAccess;
using IsolDesign.Domain.Models;
using IsolDesign.Domain.Helpers;

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
                CustomerModel customerModel = CustomerConverter.ConvertToCustomerModel(customer);
                customerModels.Add(customerModel);
            }
            return customerModels;
        }


        public CustomerModel GetCustomerModel(int id)
        {
            var customer = _unitOfWork.Customers.Get(id);
            CustomerModel customerModel = CustomerConverter.ConvertToCustomerModel(customer);

            return customerModel;
        }

    }
}
