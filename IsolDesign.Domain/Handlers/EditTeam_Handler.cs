using IsolDesign.Data.Models;
using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Helpers;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace IsolDesign.Domain.Handlers
{
    public class EditTeam_Handler : IEditTeam_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public EditTeam_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        public void EditTeam(TeamModel teamModel, string partnerIds, int projectId, int? projectLeaderId)
        {

            ICollection<Partner> chosenPartners = new List<Partner>();
            var allPartners = _unitOfWork.Partners.GetAll();
            var ids = PartnerConverter.ConvertPartnerIds(partnerIds);

            foreach (var partner in allPartners)
            {
                if (ids.Contains(partner.PartnerId))
                {
                    chosenPartners.Add(partner);
                }
            }

            if (projectLeaderId != null)
            {
                var project = _unitOfWork.Projects.Get(projectId);
                project.PartnerId = projectLeaderId;
                //_unitOfWork.SaveChanges();
            }

            var team = _unitOfWork.Teams.Get(teamModel.TeamId);
            team.Name = teamModel.Name;
            team.ProjectId = projectId;
            team.Partners = chosenPartners;

            _unitOfWork.SaveChanges();
        }

    }
}
