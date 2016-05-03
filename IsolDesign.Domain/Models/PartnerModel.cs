using System.Collections.Generic;

namespace IsolDesign.Domain.Models
{
    public class PartnerModel
    {
        public PartnerModel()
        {
            this.Competencies = new List<CompetencyModel>();
            this.Portfolio = new List<PortfolioSubjectModel>();
            this.Subcontractors = new List<SubcontractorModel>();
            this.Assignments = new List<PartnerAssignmentModel>();
        }

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

        public ICollection<CompetencyModel> Competencies { get; set; }
        public ICollection<PortfolioSubjectModel> Portfolio { get; set; }
        public ICollection<SubcontractorModel> Subcontractors { get; set; }
        public ICollection<PartnerAssignmentModel> Assignments { get; set; }
    }
}