using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Data.Models;
using IsolDesign.DataAccess.Repositories;
using IsolDesign.Domain.Interfaces;
using System.Linq;

namespace IsolDesign.Domain.Handlers
{
    public class Delete_Handler : IDelete_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public Delete_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        // Delete applicant and set foreign key in PortfolioSubject to null
        public void DeleteApplicant(int id)
        {
            var applicant = _unitOfWork.Applicants.AllIncluding(x => x.Portfolio).ToList();
            var target = applicant.Where(x => x.ApplicantId == id).FirstOrDefault();

            _unitOfWork.Applicants.Remove(target);
            _unitOfWork.SaveChanges();

        }

        public void DeleteApplicantAndPortfolio(int id)
        {
            _unitOfWork.Applicants.DeleteEntity(id);
            _unitOfWork.SaveChanges();
        }
    }
}
