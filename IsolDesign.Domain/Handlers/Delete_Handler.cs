using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Data.Models;
using IsolDesign.Domain.Interfaces;
using System.Linq;
using System.Collections.Generic;

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
        // This is used if an Applicant becomes Partner
        public void DeleteApplicant(int id)
        {
            var applicant = _unitOfWork.Applicants.AllIncluding(x => x.Portfolio).ToList();
            var target = applicant.Where(x => x.ApplicantId == id).FirstOrDefault();

            _unitOfWork.Applicants.Remove(target);
            _unitOfWork.SaveChanges();

        }


        // First delete the applicants portfoliosubjects and then delete the applicant from DB 
        public void DeleteApplicantAndPortfolio(int id)
        {
            var portfolio = GetPortfolioSubjectsForTheEntity(id, "applicant");
            _unitOfWork.PortfolioSubjects.RemoveRange(portfolio);

            var applicant = _unitOfWork.Applicants.Get(id);
            _unitOfWork.Applicants.Remove(applicant);
            _unitOfWork.SaveChanges();
        }

        // First delete the Partners portfolio, then set PartnerId to null in Projects where Partner is project leader
        // then delete the Partner from DB
        public void DeletePartnerAndPortfolio(int partnerId)
        {
            var portfolio = GetPortfolioSubjectsForTheEntity(partnerId, "Partner");
            _unitOfWork.PortfolioSubjects.RemoveRange(portfolio);

            // if partner is project leader on any project, set the reference to null
            var projects = _unitOfWork.Projects.GetAll();
            foreach (var project in projects)
            {
                if (project.PartnerId == partnerId)
                {
                    project.PartnerId = null;
                }
            }

            var partner = _unitOfWork.Partners.Get(partnerId);
            _unitOfWork.Partners.Remove(partner);
            _unitOfWork.SaveChanges();
        }


        // returns the PortfolioSubjects that belongs to an Applicant or a Partner
        public IEnumerable<PortfolioSubject> GetPortfolioSubjectsForTheEntity(int id, string type)
        {
            var portfolio = _unitOfWork.PortfolioSubjects.GetAll();
            List<PortfolioSubject> targets = new List<PortfolioSubject>();

            if (type.ToLower() == "applicant")
            {
                foreach (var portfolioSubject in portfolio)
                {
                    if (portfolioSubject.ApplicantId == id)
                    {
                        targets.Add(portfolioSubject);
                    }
                }
            }
            else if (type.ToLower() == "partner")
            {
                foreach (var portfolioSubject in portfolio)
                {
                    if (portfolioSubject.PartnerId == id)
                    {
                        targets.Add(portfolioSubject);
                    }
                }
            }
            return targets;
        }


        // Delete a Team
        public void DeleteTeam(int teamId)
        {
            var teams = _unitOfWork.Teams.AllIncluding(x => x.Partners);
            var team = teams.Where(x => x.TeamId == teamId).FirstOrDefault();

            _unitOfWork.Teams.Remove(team);
            _unitOfWork.SaveChanges();
        }


        // Delete a Competency
        public void DeleteCompetency(int competencyId)
        {
            var competency = _unitOfWork.Competencies.Get(competencyId);
            _unitOfWork.Competencies.Remove(competency);
            _unitOfWork.SaveChanges();
        }
    }
}

