using System.Collections.Generic;

namespace IsolDesign.Data.Models
{
    public class Competency
    {
        public int CompetencyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public virtual ICollection<Partner> Partners { get; set; }
        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
