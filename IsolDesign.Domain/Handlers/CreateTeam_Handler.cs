﻿using IsolDesign.Data.Models;
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
    public class CreateTeam_Handler : ICreateTeam_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;
        private Team _team;

        public CreateTeam_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        public IEnumerable<PartnerModel> GetPartners()
        {
            GetPartners_Handler handler = new GetPartners_Handler();
            var allPartners = handler.GetAllPartners(_unitOfWork);

            return allPartners;
        }

        public IEnumerable<ProjectModel> GetProjects()
        {
            GetProjects_Handler handler = new GetProjects_Handler();
            var allProjects = handler.GetAllProjects(_unitOfWork);

            return allProjects;
        }

        public void CreateTeam(TeamModel teamModel, string partnerIds, int projectId)
        {
            _team = new Team
            {
                TeamId = 0,
                Name = teamModel.Name,
                ProjectId = projectId,
                Partners = AssignPartnersToTeam(partnerIds)
            };
        }

        public ICollection<Partner> AssignPartnersToTeam(string partnerIds)
        {
            IEnumerable<int> ids = PartnerConverter.ConvertPartnerIds(partnerIds);
            var partnersFromDb = _unitOfWork.Partners.GetAll();
            List<Partner> teamMembers = new List<Partner>();

            foreach (var partner in partnersFromDb)
            {
                if (ids.Contains(partner.PartnerId))
                {
                    teamMembers.Add(partner);
                }
            }
            return teamMembers;
        }

        public void Execute(int? projectLeaderId)
        {
            if (projectLeaderId != null)
            {
                var project = _unitOfWork.Projects.Get(_team.ProjectId);
                project.PartnerId = projectLeaderId; // updating the Project to have a Project Leader
            }

            _unitOfWork.Teams.Add(this._team);
            _unitOfWork.SaveChanges();
        }

    }
}

