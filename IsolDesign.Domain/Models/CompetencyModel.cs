using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Domain.Models
{
    public class CompetencyModel
    {
        public CompetencyModel()
        {
            this.Partners = new List<PartnerModel>();
            this.Applicants = new List<ApplicantModel>();
        }

        public int CompetencyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public ICollection<PartnerModel> Partners { get; private set; }
        public ICollection<ApplicantModel> Applicants { get; private set; }
    }
}
