using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Interfaces.Interfaces_Models;
using System.Web;
using System.Web.Hosting;
using IsolDesign.Domain.Models;
using System;
using System.Collections;
using IsolDesign.Data.Models;
using System.Collections.Generic;
using IsolDesign.Domain.Helpers;
using System.Linq;

namespace IsolDesign.Domain.Handlers
{
    public class CreateApplicantHandler : ICreateApplicantHandler
    {
        private IApplicantModel _model;
        private ImageHandler _imageHandler;
        private HttpFileCollectionBase _images;
        private static Applicant _applicant;
        private static PortfolioSubject _portfolioSubject1;
        private static PortfolioSubject _portfolioSubject2;
        private IEnumerable<int> _competencyIds;

        public CreateApplicantHandler(IApplicantModel applicantModel, HttpFileCollectionBase images,
            PortfolioSubjectModel portSubj1, PortfolioSubjectModel portSubj2, IEnumerable<int> competencyIds)
        {
            this._model = applicantModel;
            this._images = images;
            this._imageHandler = new ImageHandler();
            this._competencyIds = competencyIds;

            _portfolioSubject1 = new PortfolioSubject
            {
                Name = portSubj1.Name,
                Date = portSubj1.Date,
                Description = portSubj1.Description,
                ImagePath1 = null,
                ImagePath2 = null,
                ImagePath3 = null,
            };

            _portfolioSubject2 = new PortfolioSubject
            {
                Name = portSubj2.Name,
                Date = portSubj2.Date,
                Description = portSubj2.Description,
                ImagePath1 = null,
                ImagePath2 = null,
                ImagePath3 = null,
            };

            _applicant = new Applicant
            {
                ApplicantId = 0,
                Name = _model.Name,
                Address = _model.Address,
                City = _model.City,
                Country = _model.Country,
                Phone = _model.Phone,
                Email = _model.Email,
                ProfileImagePath = null,
                Description = _model.Description,
                SkypeLink = _model.SkypeLink,
                Facebook = _model.Facebook,
                LinkedIn = _model.LinkedIn,
                Homepage = _model.Homepage,
                Portfolio = null,
                Competencies = null
            };
        }

        public void SaveProfileImage()
        {
            var profileImage = _images.Get("profileImage");
            SaveImage(profileImage, "profile", null);
        }

        // Save images for portfolioSubject1 and portfolioSubject2
        public void SavePortfolioImages()
        {
            for (int i = 1; i <= 6; i++)
            {
                var portfolioImage = _images.Get(i);
                if (!portfolioImage.HasFile()) continue;
                if (i <= 3)
                {
                    SaveImage(portfolioImage, "portfolio1", i);
                }
                else
                {
                    SaveImage(portfolioImage, "portfolio2", i);
                }

            }
        }

        public void SaveImage(HttpPostedFileBase image, string type, int? count)
        {
            string applicationPath = HostingEnvironment.ApplicationPhysicalPath;
            if(type == "profile")
            {
                _imageHandler.SaveImage(image, applicationPath, "Images\\ProfileImages\\", type, null);
            }
            else if(type == "portfolio1")
            {
                _imageHandler.SaveImage(image, applicationPath, "Images\\PortfolioImages\\", type, count);
            }
            else if (type == "portfolio2")
            {
                _imageHandler.SaveImage(image, applicationPath, "Images\\PortfolioImages\\", type, count);
            }
        }

        public void Execute()
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            IUnitOfWork _unitOfWork = new UnitOfWork(_context);

            ICollection<PortfolioSubject> portfolio = new List<PortfolioSubject>();
            portfolio.Add(_portfolioSubject1);
            portfolio.Add(_portfolioSubject2);
            _applicant.Portfolio = portfolio;

            ICollection<Competency> competencies = GetCompetencies(_unitOfWork);
            _applicant.Competencies = competencies;

            _unitOfWork.Applicants.Add(_applicant);
            _unitOfWork.SaveChanges();
            _unitOfWork.Dispose();
        }

        
        public static Applicant GetApplicant()
        {
            return _applicant;
        }

        public static PortfolioSubject GetPortfolioSubject(string type)
        {
            if(type == "portfolio1")
            {
                return _portfolioSubject1;
            }
            else if(type == "portfolio2")
            {
                return _portfolioSubject2;
            }
            return null;
        }

        public ICollection<Competency> GetCompetencies(IUnitOfWork unitOfWork)
        {
            List<Competency> checkedCompentencies = new List<Competency>();
            var competencies = unitOfWork.Competencies.GetAll();

            foreach(var comp in competencies)
            {
                if (_competencyIds.Contains(comp.CompetencyId))
                {
                    checkedCompentencies.Add(comp);
                }
            }
            return checkedCompentencies;
        }
    }
}
