using System;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Interfaces.Interfaces_Models;
using System.Web;
using IsolDesign.Data.Models;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.DataAccess;

namespace IsolDesign.Domain.Handlers
{
    public class CreateAssignment_Handler : ICreateAssignment_Handler
    {
        private ImageHandler imageHandler;
        private HttpFileCollectionBase _images;
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public CreateAssignment_Handler(HttpFileCollectionBase images)
        {
            this.imageHandler = new ImageHandler();
            this._images = images;
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        // Creates a Partner Assignment
        public void CreatePartnerAssignment(IPartnerAssignmentModel assignmentModel, string userName)
        {
            PartnerAssignment partnerAssignment = new PartnerAssignment
            {
                AssignmentId = 0,
                WorkTitle = assignmentModel.WorkTitle,
                Type = AssignmentType.PartnerAssignment,
                Description = assignmentModel.Description,
                Photo = null,
                Drawing = null,
                Video = null,
                Credits = assignmentModel.Credits,
                PartnerId = assignmentModel.PartnerId // TODO Get id from logged in user and get the partnerid
            };

            Execute(partnerAssignment);
        }

        // Creates an Ordered Assignment
        public void CreateOrderedAssignment(IOrderedAssignmentModel assignmentModel)
        {
            OrderedAssignment orderedAssignment = new OrderedAssignment
            {
                AssignmentId = 0,
                WorkTitle = assignmentModel.WorkTitle,
                Type = AssignmentType.OrderedAssignment,
                Description = assignmentModel.Description,
                Photo = null,
                Drawing = null,
                Video = null,
                Deadline = assignmentModel.Deadline,
                CustomerId = assignmentModel.CustomerId
            };

            Execute(orderedAssignment);
        }

        public int GetPartnerId()
        {
            //string userId = HttpContext.Current.User.Identity.GetUserId();
            return -1;
        }

        public void Execute(Assignment assignment)
        {
            _unitOfWork.Assignments.Add(assignment);
            _unitOfWork.SaveChanges();
        }
    }
}
