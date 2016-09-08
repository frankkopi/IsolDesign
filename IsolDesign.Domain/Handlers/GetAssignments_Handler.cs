using IsolDesign.Data.Models;
using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using System.Collections.Generic;
using IsolDesign.Data.Enums;

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
                    Type = null,
                    Description = assignment.Description,
                    Photo = assignment.Photo,
                    Drawing = assignment.Drawing,
                    Video = assignment.Video
                };
                if (assignment.Type == AssignmentType.PartnerAssignment) // AssignmentType is an enum
                //if (assignment.Type == IsolDesign.Data.Models.AssignmentType.PartnerAssignment)
                //if (assignment.Type == AssignmentType.PartnerAssignment)
                {
                    assModel.Type = AssignmentType.PartnerAssignment;
                    //assModel.Type = "Partner Assignment";
                }
                else if (assignment.Type == AssignmentType.OrderedAssignment)
                {
                    assModel.Type = AssignmentType.OrderedAssignment;
                }
                else
                {
                    assModel.Type = null;
                }
                assignmentModels.Add(assModel);
            }

            return assignmentModels;
        }
    }
}
