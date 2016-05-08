using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Data.Models
{
    public class PortfolioSubject
    {
        public int PortfolioSubjectId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string ImagePath1 { get; set; }

        public string ImagePath2 { get; set; }

        public string ImagePath3 { get; set; }

        public int? PartnerId { get; set; } // FK

        public int? ApplicantId { get; set; } // Nullable FK. Entity Framework sets the child foreign key to null when the parent entity is deleted. Remember eager loading for this to work (Include all)


        public virtual Partner Partner { get; set; }
        public virtual Applicant Applicant { get; set; }

    }
}
