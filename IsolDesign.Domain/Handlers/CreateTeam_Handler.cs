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
    public class CreateTeam_Handler : ICreateTeam_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

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
    }
}
