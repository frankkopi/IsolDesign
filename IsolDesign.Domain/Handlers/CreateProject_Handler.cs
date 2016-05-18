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
    public class CreateProject_Handler : ICreateProject_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public CreateProject_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        public void CreateProject(ProjectModel projectModel)
        {
            Project project = new Project()
            {
                ProjectId = 0,
                Name = projectModel.Name,
                Description = projectModel.Description,
                StartDate = projectModel.StartDate,
                Deadline = projectModel.Deadline,
                PartnerId = projectModel.PartnerId,
                DevMethodId = null,
                EconomyId = null,
                AssignmentId = projectModel.AssignmentId
            };
        }
    }
}
