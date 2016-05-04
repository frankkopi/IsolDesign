using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.DataAccess.Repositories;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Handlers
{
    public class GetApplicants_Handler : IGetApplicants_Handler
    {
        private ApplicationDbContext _context;
        private IApplicantRepository _applicantRepository;

        public GetApplicants_Handler()
        {
            this._context = new ApplicationDbContext();
            this._applicantRepository = new ApplicantRepository(_context);
        }

        // Get all applicants
        public IEnumerable<ApplicantModel> GetApplicants()
        {
            //var applicantModels = new List<ApplicantModel>();
            var applicantModels = new Stack<ApplicantModel>();
            var applicantsFromDB = _applicantRepository.GetAll();
            foreach(var item in applicantsFromDB)
            {
                var applicantModel = new ApplicantModel
                {
                    ApplicantId = item.ApplicantId,
                    Name = item.Name,
                    Address = item.Address,
                    City = item.City,
                    Country = item.Country,
                    Phone = item.Phone,
                    Email = item.Email,
                    ProfileImagePath = item.ProfileImagePath,
                    Description = item.Description,
                    SkypeLink = item.SkypeLink,
                    Facebook = item.Facebook,
                    LinkedIn = item.LinkedIn,
                    Homepage = item.Homepage
                };
                //applicantModels.Add(applicantModel);
                applicantModels.Push(applicantModel);
            }
            return applicantModels;
        }

        // Get one applicant
        public ApplicantModel GetApplicant(int id)
        {
            var item = _applicantRepository.Get(id);
            var applicantModel = new ApplicantModel()
            {
                ApplicantId = item.ApplicantId,
                Name = item.Name,
                Address = item.Address,
                City = item.City,
                Country = item.Country,
                Phone = item.Phone,
                Email = item.Email,
                ProfileImagePath = item.ProfileImagePath,
                Description = item.Description,
                SkypeLink = item.SkypeLink,
                Facebook = item.Facebook,
                LinkedIn = item.LinkedIn,
                Homepage = item.Homepage
            };
            return applicantModel;
        }
    }
}
