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
    public class GetAssignments_Handler : IGetAssignments_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public GetAssignments_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        public IEnumerable<AssignmentModel> GetAssignments()
        {
            var assignmentsFromDB = _unitOfWork.Assignments.GetAllAss();
            List<AssignmentModel> assignmentModels = new List<AssignmentModel>();

            foreach (var assignment in assignmentsFromDB)
            {
                AssignmentModel assModel = new AssignmentModel
                {
                    AssignmentId = assignment.AssignmentId,
                    WorkTitle = assignment.WorkTitle,
                    Type = assignment.Type,
                    Description = assignment.Description,
                    Photo = assignment.Photo,
                    Drawing = assignment.Drawing,
                    Video = assignment.Video
                };
                assignmentModels.Add(assModel);
            }

            return assignmentModels;
        }
    }
}
