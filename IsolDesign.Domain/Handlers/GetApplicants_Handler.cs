using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Helpers;
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

        // Get all applicants and convert them to applicantModels
        public IEnumerable<ApplicantModel> GetApplicants()
        {
            var applicantModels = new Stack<ApplicantModel>();
            var applicantsFromDB = _unitOfWork.Applicants.GetAll();

            foreach (var applicant in applicantsFromDB)
            {
                // convert Applicant to ApplicantModel
                var applicantModel = ApplicantConverter.ConvertToApplicantModel(applicant);

                // convert List<PortfolioSubject> to List<PortfolioSubjectModel>
                var portfolio = PortfolioConverter.ConvertToPortfolioSubjectModels(applicant.Portfolio);
                applicantModel.Portfolio = portfolio;

                // convert List<Competency> to List<CompetencyModel>
                var competencyModels = CompetencyConverter.ConvertToCompetencyModels(applicant.Competencies);
                applicantModel.Competencies = competencyModels;

                applicantModels.Push(applicantModel);
            }
            return applicantModels;
        }

        // Get a single applicant
        public ApplicantModel GetApplicant(int id)
        {
            var applicant = _unitOfWork.Applicants.Get(id);

            var applicantModel = ApplicantConverter.ConvertToApplicantModel(applicant);
   
            return applicantModel;
        }
    }
}


