using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.DataAccess.Models
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
