using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Helpers
{
    public class ApplicantConverter
    {
        // convert Applicant to ApplicantModel
        public static ApplicantModel ConvertToApplicantModel(Applicant applicant)
        {
            var applicantModel = new ApplicantModel
            {
                ApplicantId = applicant.ApplicantId,
                Name = applicant.Name,
                Address = applicant.Address,
                City = applicant.City,
                Country = applicant.Country,
                Phone = applicant.Phone,
                Email = applicant.Email,
                ProfileImagePath = applicant.ProfileImagePath,
                Description = applicant.Description,
                SkypeLink = applicant.SkypeLink,
                Facebook = applicant.Facebook,
                LinkedIn = applicant.LinkedIn,
                Homepage = applicant.Homepage,
                Portfolio = null,
                Competencies = null
            };
            return applicantModel;
        }
    }
}
