using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.DataAccess.Repositories;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Handlers
{
    public class GetApplicants_Handler : IGetApplicants_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public GetApplicants_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        // Get all applicants
        public IEnumerable<ApplicantModel> GetApplicants()
        {
            var applicantModels = new Stack<ApplicantModel>();
            var applicantsFromDB = _unitOfWork.Applicants.GetAll();

            foreach (var applicant in applicantsFromDB)
            {
                // transform List<PortfolioSubject> til List<PortfolioSubjectModel>
                var portfolio = new List<PortfolioSubjectModel>();
                foreach (var portSubject in applicant.Portfolio)
                {
                    PortfolioSubjectModel portfolioSubjectModel = new PortfolioSubjectModel
                    {
                        Name = portSubject.Name,
                        Date = portSubject.Date,
                        Description = portSubject.Description,
                        Photo1 = portSubject.ImagePath1,
                        Photo2 = portSubject.ImagePath2,
                        Photo3 = portSubject.ImagePath3
                    };
                    portfolio.Add(portfolioSubjectModel);
                }

                // transform List<Competency> til List<CompetencyModel>
                var competencyModels = new List<CompetencyModel>();
                foreach (var competency in applicant.Competencies)
                {
                    CompetencyModel competencyModel = new CompetencyModel
                    {
                        CompetencyId = competency.CompetencyId,
                        Name = competency.Name,
                        Description = competency.Description
                    };
                    competencyModels.Add(competencyModel);
                }


                var applicantModel = new ApplicantModel
                {
                    ApplicantId = applicant.ApplicantId,
                    Name = applicant.Name,
                    Address = applicant.Address,
                    City = applicant.City,
                    Country = applicant.Country,
                    Phone = applicant.Phone,
                    Email = applicant.Email,
                    ProfileImagePath = applicant.ProfileImagePath,
                    Description = applicant.Description,
                    SkypeLink = applicant.SkypeLink,
                    Facebook = applicant.Facebook,
                    LinkedIn = applicant.LinkedIn,
                    Homepage = applicant.Homepage,
                    Portfolio = portfolio,
                    Competencies = competencyModels
                };
                applicantModels.Push(applicantModel);
            }
            return applicantModels;
        }

        // Get a single applicant
        public ApplicantModel GetApplicant(int id)
        {
            var item = _unitOfWork.Applicants.Get(id);

            var applicantModel = new ApplicantModel()
            {
                ApplicantId = item.ApplicantId,
                Name = item.Name,
                Address = item.Address,
                City = item.City,
                Country = item.Country,
                Phone = item.Phone,
                Email = item.Email,
                ProfileImagePath = item.ProfileImagePath,
                Description = item.Description,
                SkypeLink = item.SkypeLink,
                Facebook = item.Facebook,
                LinkedIn = item.LinkedIn,
                Homepage = item.Homepage
            };
            return applicantModel;
        }
    }
}
