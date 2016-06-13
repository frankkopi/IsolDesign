using IsolDesign.Domain.Interfaces;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.DataAccess;
using System.Collections.Generic;
using IsolDesign.Domain.Models;
using IsolDesign.Domain.Helpers;
using System.Linq;

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

        //public IEnumerable<PartnerModel> GetPartners()
        //{
        //    var allPartners = GetAllPartners(_unitOfWork);
        //    return allPartners;
        //}

        //public IEnumerable<PartnerModel> GetAllPartners(IUnitOfWork unitOfWork)
        //{
        //    var partnersFromDb = unitOfWork.Partners.GetAll();
        //    List<PartnerModel> partnerModels = new List<PartnerModel>();

        //    foreach (var partner in partnersFromDb)
        //    {
        //        // convert Partner to PartnerModel
        //        var partnerModel = PartnerConverter.ConvertToPartnerModel(partner);

        //        // convert List<PortfolioSubject> to List<PortfolioSubjectModel>
        //        var portfolio = PortfolioConverter.ConvertToPortfolioSubjectModels(partner.Portfolio);
        //        partnerModel.Portfolio = portfolio;

        //        // convert List<Competency> to List<CompetencyModel>
        //        var competencyModels = CompetencyConverter.ConvertToCompetencyModels(partner.Competencies);
        //        partnerModel.Competencies = competencyModels;

        //        // convert Team to TeamModel
        //        var teamModel = TeamConverter.ConvertToTeamModel(partner.Team);
        //        partnerModel.Team = teamModel;

        //        partnerModels.Add(partnerModel);
        //    }
        //    return partnerModels;
        //}



        // Testing stuff out *********************************************************************************************
        public IEnumerable<PartnerModel> GetPartners()
        {
            var allPartners = GetAllPartners(_unitOfWork);
            return allPartners;
        }

        public IEnumerable<PartnerModel> GetAllPartners(IUnitOfWork unitOfWork)
        {
            var partnersFromDb = unitOfWork.Partners.AllIncluding(x => x.Team).ToList();
            List<PartnerModel> partnerModels = new List<PartnerModel>();

            foreach (var partner in partnersFromDb)
            {
                // convert Partner to PartnerModel
                var partnerModel = PartnerConverter.ConvertToPartnerModel(partner);

                // convert List<PortfolioSubject> to List<PortfolioSubjectModel>
                var portfolio = PortfolioConverter.ConvertToPortfolioSubjectModels(partner.Portfolio);
                partnerModel.Portfolio = portfolio;

                // convert List<Competency> to List<CompetencyModel>
                var competencyModels = CompetencyConverter.ConvertToCompetencyModels(partner.Competencies);
                partnerModel.Competencies = competencyModels;

                // convert Team to TeamModel
                var teamModel = TeamConverter.ConvertToTeamModel(partner.Team);
                partnerModel.Team = teamModel;

                partnerModels.Add(partnerModel);
            }
            return partnerModels;

        }
        // testing done **************************************************************************************************

        // get a single partner
        public PartnerModel GetPartner(int partnerId)
        {
            var partner = _unitOfWork.Partners.Get(partnerId);
            var partnerModel = PartnerConverter.ConvertToPartnerModel(partner);

            var teamModel = TeamConverter.ConvertToTeamModel(partner.Team);
            partnerModel.Team = teamModel;

            return partnerModel;
        }
    }
}

