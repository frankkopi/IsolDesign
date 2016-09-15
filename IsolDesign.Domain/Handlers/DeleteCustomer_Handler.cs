using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Data.Models;

namespace IsolDesign.Domain.Handlers
{
    public class DeleteCustomer_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public DeleteCustomer_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        public void DeleteCustomer(int id)
        {
            var customer = _unitOfWork.Customers.Get(id);
            Execute(customer);
        }

        public void Execute(Customer customer)
        {
            _unitOfWork.Customers.Remove(customer);
            _unitOfWork.SaveChanges();
        }
    }
}
