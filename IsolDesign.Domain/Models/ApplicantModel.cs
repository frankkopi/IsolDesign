using IsolDesign.Domain.Interfaces.Interfaces_Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IsolDesign.Domain.Models
{
    public class ApplicantModel : IApplicantModel
    {
        public int ApplicantId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        public string ProfileImagePath { get; set; }

        [Required]
        [Display(Name="Personal Description")]
        public string Description { get; set; }

        public string SkypeLink { get; set; }

        public string Facebook { get; set; }

        public string LinkedIn { get; set; }

        public string Homepage { get; set; }


        public ICollection<CompetencyModel> Competencies { get; set; }
        public ICollection<PortfolioSubjectModel> Portfolio { get; set; }

    }
}
