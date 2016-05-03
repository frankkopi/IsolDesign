using IsolDesign.Data;
using IsolDesign.Data.DBContext;
using IsolDesign.Data.Interfaces;
using IsolDesign.Data.Interfaces.IUnitOfWork;
using IsolDesign.Data.Models;
using IsolDesign.Data.Repositories;
using IsolDesign.Domain.Interfaces;

namespace IsolDesign.Domain.Handlers
{
    public class Delete_Handler : IDelete_Handler
    {
        private ApplicationDbContext _context;
        private IApplicantRepository _applicantRepository;
        private IUnitOfWork _unitOfWork;

        public Delete_Handler()
        {
            this._context = new ApplicationDbContext();
            this._applicantRepository = new ApplicantRepository(_context);
            this._unitOfWork = new UnitOfWork(_context);
        }

        public void DeleteApplicant(int id)
        {
            Applicant applicant = _unitOfWork.Applicants.Get(id);

            _unitOfWork.Applicants.Remove(applicant);
            _unitOfWork.SaveChanges();
            _unitOfWork.Dispose();
           
        }
    }
}
