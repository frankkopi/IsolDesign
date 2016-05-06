using IsolDesign.Data.Models;
using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Domain.Handlers
{
    public class GetCompetencies_Handler : IGetCompetencies_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public GetCompetencies_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        public IEnumerable<CompetencyModel> GetCompetencies()
        {
            var competencyModels = new List<CompetencyModel>();
            var competencies = _unitOfWork.Competencies.GetAll();
            _unitOfWork.Dispose();

            foreach(var competency in competencies)
            {
                CompetencyModel competencymodel = new CompetencyModel
                {
                    CompetencyId = competency.CompetencyId,
                    Name = competency.Name,
                    Description = competency.Description,
                    Applicants = null,
                    Partners = null
                };
                competencyModels.Add(competencymodel);
            }

            return competencyModels;
        }
    }
}


//var applicantModels = new List<ApplicantModel>();
//                foreach(var item in competency.Applicants)
//                {
//                    ApplicantModel applicantModel = new ApplicantModel
//                    {
//                        ApplicantId = item.ApplicantId,
//                        Name = item.Name,
//                        Address = item.Address,
//                        City = item.City,
//                        Country = item.Country,
//                        Phone = item.Phone,
//                        Email = item.Email,
//                        ProfileImagePath = item.ProfileImagePath,
//                        Description = item.Description,
//                        SkypeLink = item.SkypeLink,
//                        Facebook = item.Facebook,
//                        LinkedIn = item.LinkedIn,
//                        Homepage = item.Homepage
//                    };
//                }
