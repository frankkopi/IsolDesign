using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.DataAccess.Models
{
    public class Partner
    {
        public int PartnerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }

        public string SkypeLink { get; set; }

        public string Facebook { get; set; }

        public string LinkedIn { get; set; }

        public string Homepage { get; set; }

        public int TeamId { get; set; } // FK


        public virtual Team Team { get; set; }
        public virtual ICollection<Competency> Competencies { get; set; }
        public virtual ICollection<PortfolioSubject> Portfolio { get; set; }
        public virtual ICollection<Subcontractor> Subcontractors { get; set; }
        public virtual ICollection<PartnerAssignment> Assignments { get; set; }
    }
}
