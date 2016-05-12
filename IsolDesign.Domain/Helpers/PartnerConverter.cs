using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Helpers
{
    public class PartnerConverter
    {
        // convert Partner to PartnerModel
        public static PartnerModel ConvertToPartnerModel(Partner partner)
        {
            var partnerModel = new PartnerModel()
            {
                PartnerId = partner.PartnerId,
                Name = partner.Name,
                Address = partner.Address,
                City = partner.City,
                Country = partner.Country,
                Phone = partner.Phone,
                Email = partner.Email,
                ProfileImagePath = partner.ProfileImagePath,
                Description = partner.Description,
                SkypeLink = partner.SkypeLink,
                Facebook = partner.Facebook,
                LinkedIn = partner.LinkedIn,
                Homepage = partner.Homepage,
                Portfolio = null,
                Competencies = null
            };
            return partnerModel;
        }
    }
}
