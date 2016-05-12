using IsolDesign.Data.Models;
using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Interfaces;
using System.Linq;

namespace IsolDesign.Domain.Handlers
{
    public class CreatePartner_Handler : ICreatePartner_Handler
    {
        private int _applicantId;
        private Applicant _applicant;
        private Partner _partner;
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public CreatePartner_Handler(int applicantId)
        {
            this._applicantId = applicantId;
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);          
        }

        public void CreatePartner()
        {
            _applicant = GetApplicant(_applicantId);

            _partner = new Partner()
            {
                PartnerId = 0,
                Name = _applicant.Name,
                Address = _applicant.Address,
                City = _applicant.City,
                Country = _applicant.Country,
                Phone = _applicant.Phone,
                Email = _applicant.Email,
                ProfileImagePath = _applicant.ProfileImagePath,
                Description = _applicant.Description,
                SkypeLink = _applicant.SkypeLink,
                Facebook = _applicant.Facebook,
                LinkedIn = _applicant.LinkedIn,
                Homepage = _applicant.Homepage,
                TeamId = null,
                Competencies = _applicant.Competencies,
                Portfolio = _applicant.Portfolio
            };
        }


        // Get applicant and all the navigation properties
        public Applicant GetApplicant(int applicantId)
        {
            var applicant = _unitOfWork.Applicants.AllIncluding(x => x.Portfolio).ToList();
            var target = applicant.Where(x => x.ApplicantId == applicantId).FirstOrDefault();

            return target;
        }


        public void Execute()
        {
            _unitOfWork.Partners.Add(_partner);
            _unitOfWork.SaveChanges();
        }
    }
}
