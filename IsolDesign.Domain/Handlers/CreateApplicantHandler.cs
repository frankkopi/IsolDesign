using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Interfaces.Interfaces_Models;
using System.Web;
using System.Web.Hosting;
using IsolDesign.DataAccess.Models;

namespace IsolDesign.Domain.Handlers
{
    public class CreateApplicantHandler : ICreateApplicantHandler
    {
        private IApplicantModel _model;
        private ImageHandler _imageHandler;
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public CreateApplicantHandler(IApplicantModel applicantModel)
        {
            this._model = applicantModel;
            this._imageHandler = new ImageHandler();
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        public void SaveImage(HttpPostedFileBase image)
        {
            string applicationPath = HostingEnvironment.ApplicationPhysicalPath;
            _imageHandler.SaveImage(image, applicationPath, "Images\\ProfileImages\\");
        }

        public void Execute()
        {
            Applicant applicant = new Applicant
            {
                ApplicantId = 0,
                Name = _model.Name,
                Address = _model.Address,
                City = _model.City,
                Country = _model.Country,
                Phone = _model.Phone,
                Email = _model.Email,
                ProfileImagePath = _imageHandler.ProfileImagePath,
                Description = _model.Description,
                SkypeLink = _model.SkypeLink,
                Facebook = _model.Facebook,
                LinkedIn = _model.LinkedIn,
                Homepage = _model.Homepage
            };

            _unitOfWork.Applicants.Add(applicant);
            _unitOfWork.SaveChanges();
            _unitOfWork.Dispose();
        }
    }
}
