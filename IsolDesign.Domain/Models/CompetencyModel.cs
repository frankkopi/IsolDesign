using IsolDesign.Domain.Interfaces.Interfaces_Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IsolDesign.Domain.Models
{
    public class CompetencyModel : ICompetencyModel
    {

        public int CompetencyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<PartnerModel> Partners { get; set; }
        public ICollection<ApplicantModel> Applicants { get; set; }
    }
}
