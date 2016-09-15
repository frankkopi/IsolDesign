using IsolDesign.Data.Models;
using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Handlers
{
    public class EditCustomer_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public EditCustomer_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        public void EditCustomer(CustomerModel customerModel)
        {
            Customer customer = _unitOfWork.Customers.Get(customerModel.CustomerId);

            customer.CustomerId = customerModel.CustomerId;
            customer.Name = customerModel.Name;
            customer.Address = customerModel.Address;
            customer.Country = customerModel.Country;
            customer.Phone = customerModel.Phone;
            customer.Email = customerModel.Email;
            customer.Category = customerModel.Category;
            customer.Homepage = customerModel.Homepage;
            customer.ContactName = customerModel.ContactName;
            customer.ContactPhone = customerModel.Phone;
            customer.ContactEmail = customerModel.Email;

            Execute();
        }

        public void Execute()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
