using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.DataAccess.Models;
using IsolDesign.DataAccess.Repositories;
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

            _unitOfWork.Applicants.DeleteEntity(id);
            _unitOfWork.SaveChanges();
            _unitOfWork.Dispose();

            //Applicant applicant = _unitOfWork.Applicants.Get(id);

            //_unitOfWork.Applicants.Remove(applicant);
            //_unitOfWork.SaveChanges();
            //_unitOfWork.Dispose();

        }
    }
}
