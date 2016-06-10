using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;
using System.Collections.Generic;

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
                Team = null,
                Portfolio = null,
                Competencies = null
            };
            return partnerModel;
        }


        // convert Partner to PartnerModel (the project leader)
        public static PartnerModel ConvertToPartnerModel2(Partner partner)
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
                Description = null,
                SkypeLink = null,
                Facebook = null,
                LinkedIn = null,
                Homepage = null,
                TeamId = null,
                Competencies = null,
                Portfolio = null,
                Subcontractors = null,
                Assignments = null
            };
            return partnerModel;
        }

        public static IEnumerable<int> ConvertPartnerIds(string partnerIds)
        {
            List<int> ids = new List<int>();
            char[] separator = { ',' };
            string[] tempIds = partnerIds.Split(separator);

            foreach(var id in tempIds)
            {
                int numValue;
                int.TryParse(id, out numValue);
                ids.Add(numValue);
            }

            return ids;
        }

        // convert a List<Partner> to List<PartnerModels>
        public static List<PartnerModel> ConvertToPartnerModels(IEnumerable<Partner> partners)
        {
            List<PartnerModel> list = new List<PartnerModel>();

            foreach (var partner in partners)
            {
                PartnerModel partnerModel = new PartnerModel()
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
                    Team = null,
                    Portfolio = null,
                    Competencies = null
                };
                list.Add(partnerModel);
            }
            return list;
        }
    }
}
