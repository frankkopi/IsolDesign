using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Handlers
{
    public class CreateCustomer_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public CreateCustomer_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);

        }

        public void CreateCustomer(CustomerModel model)
        {
            Customer customer = new Customer
            {
                CustomerId = 0,
                Name = model.Name,
                Address = model.Address,
                Country = model.Country,
                Phone = model.Phone,
                Email = model.Email,
                Category = model.Category,
                Homepage = model.Homepage,
                ContactName = model.ContactName,
                ContactPhone = model.ContactPhone,
                ContactEmail = model.ContactEmail,
                Assignments = null
            };
            Execute(customer);
        }

        public void Execute(Customer customer)
        {
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.SaveChanges();
        }
    }
}
