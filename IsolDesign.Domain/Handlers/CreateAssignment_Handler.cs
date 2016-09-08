using System;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Interfaces.Interfaces_Models;
using System.Web;
using IsolDesign.Data.Models;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.DataAccess;
using IsolDesign.Data.Enums;
using System.Web.Hosting;

namespace IsolDesign.Domain.Handlers
{
    public class CreateAssignment_Handler : ICreateAssignment_Handler
    {
        private ImageHandler _imageHandler;
        private HttpFileCollectionBase _images;
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;
        private static Assignment _assignment;

        public CreateAssignment_Handler(HttpFileCollectionBase images)
        {
            this._imageHandler = new ImageHandler();
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
                PartnerId = GetPartnerId(userName)
            };
            _assignment = partnerAssignment;
            SaveImages();
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
            _assignment = orderedAssignment;
            SaveImages();
            Execute(orderedAssignment);
        }

        // Get Id from partner which is currently logged in as user. userName is the email.
        public int GetPartnerId(string userName)
        {
            GetPartners_Handler handler = new GetPartners_Handler();
            int id = handler.GetPartnerId(userName);
            return id;
        }

        public void SaveImages()
        {
            string applicationPath = HostingEnvironment.ApplicationPhysicalPath;

            for (int i = 0; i < _images.Count; i++)
            {
                var image = _images.Get(i);
                if (i == 0)
                {
                    _imageHandler.SaveImage(image, applicationPath, "Images\\AssignmentsImages\\", "assignmentPhoto", null);
                }
                else if (i == 1)
                {
                    _imageHandler.SaveImage(image, applicationPath, "Images\\AssignmentsImages\\", "assignmentDrawing", null);
                }
                else if (i == 2)
                {
                    _imageHandler.SaveImage(image, applicationPath, "Images\\AssignmentsVideos\\", "assignmentVideo", null);
                }
                else
                {
                    return;  // TODO **************************************************************************************
                }
            }
        }

        public static Assignment GetAssignment()
        {
            return _assignment;
        }

        public void Execute(Assignment assignment)
        {
            _unitOfWork.Assignments.Add(assignment);
            _unitOfWork.SaveChanges();
        }
    }
}
