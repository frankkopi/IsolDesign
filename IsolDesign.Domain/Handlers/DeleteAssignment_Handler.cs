using System;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess;
using IsolDesign.Data.Models;

namespace IsolDesign.Domain.Handlers
{
    public class DeleteAssignment_Handler
    {
        private IUnitOfWork _unitOfWork;
        private ApplicationDbContext _context;

        public DeleteAssignment_Handler()
        {
            _context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        public void DeleteAssignment(int id)
        {
            Assignment assignment = _unitOfWork.Assignments.Get(id);
            Execute(assignment);             
        }

        public void Execute(Assignment assignment)
        {
            _unitOfWork.Assignments.Remove(assignment);
            _unitOfWork.SaveChanges();
        }
    }
}
