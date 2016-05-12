using System;
using IsolDesign.Domain.Interfaces;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.DataAccess;
using System.Collections.Generic;
using IsolDesign.Domain.Models;
using System.Reflection;
using IsolDesign.Data.Models;

namespace IsolDesign.Domain.Handlers
{
    public class GetPartners_Handler : IGetPartners_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public GetPartners_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);

        }

        public IEnumerable<PartnerModel> GetPartners()
        {
            var allPartners = GetAllPartners(_unitOfWork);
            return allPartners;
        }

        public IEnumerable<PartnerModel> GetAllPartners(IUnitOfWork unitOfWork)
        {
            var partnersFromDb = unitOfWork.Partners.GetAll();
            List<PartnerModel> partnerModels = new List<PartnerModel>();

            foreach (var partner in partnersFromDb)
            {
                // transform List<PortfolioSubject> til List<PortfolioSubjectModel>
                var portfolio = new List<PortfolioSubjectModel>();
                foreach (var portSubject in partner.Portfolio)
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
                foreach (var competency in partner.Competencies)
                {
                    CompetencyModel competencyModel = new CompetencyModel
                    {
                        CompetencyId = competency.CompetencyId,
                        Name = competency.Name,
                        Description = competency.Description
                    };
                    competencyModels.Add(competencyModel);
                }


                var partnerModel = new PartnerModel()
                {
                    PartnerId = partner.PartnerId,
                    Name = partner.Name,
                    Address = partner.Address,
                    City = partner.City,
                    Country = partner.Country,
                    Phone = partner.Phone,
                    Email = partner.Email,
                    ProfileImagePath = partner.ProfileImagePath,
                    Description = partner.Description,
                    SkypeLink = partner.SkypeLink,
                    Facebook = partner.Facebook,
                    LinkedIn = partner.LinkedIn,
                    Homepage = partner.Homepage,
                    Portfolio = portfolio,
                    Competencies = competencyModels
                };
                partnerModels.Add(partnerModel);
            }
            return partnerModels;

        }
    }
}


//public IEnumerable<PartnerModel> GetPartners()
//{
//    var partnersFromDb = _unitOfWork.Partners.GetAll();
//    List<PartnerModel> partnerModels = new List<PartnerModel>();

//    foreach (var partner in partnersFromDb)
//    {
//        // transform List<PortfolioSubject> til List<PortfolioSubjectModel>
//        var portfolio = new List<PortfolioSubjectModel>();
//        foreach (var portSubject in partner.Portfolio)
//        {
//            PortfolioSubjectModel portfolioSubjectModel = new PortfolioSubjectModel
//            {
//                Name = portSubject.Name,
//                Date = portSubject.Date,
//                Description = portSubject.Description,
//                Photo1 = portSubject.ImagePath1,
//                Photo2 = portSubject.ImagePath2,
//                Photo3 = portSubject.ImagePath3
//            };
//            portfolio.Add(portfolioSubjectModel);
//        }

//        // transform List<Competency> til List<CompetencyModel>
//        var competencyModels = new List<CompetencyModel>();
//        foreach (var competency in partner.Competencies)
//        {
//            CompetencyModel competencyModel = new CompetencyModel
//            {
//                CompetencyId = competency.CompetencyId,
//                Name = competency.Name,
//                Description = competency.Description
//            };
//            competencyModels.Add(competencyModel);
//        }


//        var partnerModel = new PartnerModel()
//        {
//            PartnerId = partner.PartnerId,
//            Name = partner.Name,
//            Address = partner.Address,
//            City = partner.City,
//            Country = partner.Country,
//            Phone = partner.Phone,
//            Email = partner.Email,
//            ProfileImagePath = partner.ProfileImagePath,
//            Description = partner.Description,
//            SkypeLink = partner.SkypeLink,
//            Facebook = partner.Facebook,
//            LinkedIn = partner.LinkedIn,
//            Homepage = partner.Homepage,
//            Portfolio = portfolio,
//            Competencies = competencyModels
//        };
//        partnerModels.Add(partnerModel);
//    }
//    return partnerModels;

//}
