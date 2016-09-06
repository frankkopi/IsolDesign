using System;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Interfaces.Interfaces_Models;
using System.Web;
using IsolDesign.Data.Models;


namespace IsolDesign.Domain.Handlers
{
    public class CreateAssignment_Handler : ICreateAssignment_Handler
    {
        private Assignment _assignment;
        private ImageHandler imageHandler;
        private HttpFileCollectionBase _images;

        public CreateAssignment_Handler(IAssignmentModel assignmentModel, HttpFileCollectionBase images)
        {
            this.imageHandler = new ImageHandler();
            this._images = images;

            CreateNewAssignment(assignmentModel);

        }

        public void CreateNewAssignment(IAssignmentModel assignmentModel)
        {
            if (assignmentModel.Type == IsolDesign.Domain.Models.AssignmentType.PartnerAssignment) // AssignmentType is an enum
            {
                CreatePartnerAssignment(assignmentModel);
            }
            else if (assignmentModel.Type == IsolDesign.Domain.Models.AssignmentType.OrderedAssignment) // AssignmentType is an enum
            {
                CreateOrderedAssignment(assignmentModel);
            }
        }

        // Creates a Partner Assignment
        public void CreatePartnerAssignment(IAssignmentModel assignmentModel)
        {
            this._assignment = new PartnerAssignment
            {
                AssignmentId = 0,
                WorkTitle = assignmentModel.WorkTitle,
                Type = AssignmentType.PartnerAssignment,
                Description = assignmentModel.Description,
                Photo = null,
                Drawing = null,
                Video = null
            };
        }

        public void CreateOrderedAssignment(IAssignmentModel assignmentModel)
        {
            this._assignment = new OrderedAssignment
            {
                AssignmentId = 0,
                WorkTitle = assignmentModel.WorkTitle,
                Type = AssignmentType.OrderedAssignment,
                Description = assignmentModel.Description,
                Photo = null,
                Drawing = null,
                Video = null
            };
        }
    }
}
