using IsolDesign.Data.Models;
using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Interfaces;

namespace IsolDesign.Domain.Handlers
{
    public class CreatePartner_Handler : ICreatePartner_Handler
    {
        private int _applicantId;
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public CreatePartner_Handler(int applicantId)
        {
            this._applicantId = applicantId;
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);          
        }

        public void CreatePartner() {
            var applicant = GetApplicant(_applicantId);

            Partner partner = new Partner()
            {
                PartnerId = 0,
                Name = applicant.Name,
                Address = applicant.Address,
                City = applicant.City,
                Country = applicant.Country,
                Phone = applicant.Phone,
                Email = applicant.Email,
                Photo = applicant.Phone,
                Description = applicant.Description,
                SkypeLink = applicant.SkypeLink,
                Facebook = applicant.Facebook,
                LinkedIn = applicant.LinkedIn,
                Homepage = applicant.Homepage,
                TeamId = null,
                Competencies = applicant.Competencies,
                Portfolio = applicant.Portfolio
            };
        }

        public Applicant GetApplicant(int applicantId)
        {
            var applicant = _unitOfWork.Applicants.Get(applicantId);
            return applicant;
        }
    }
}
