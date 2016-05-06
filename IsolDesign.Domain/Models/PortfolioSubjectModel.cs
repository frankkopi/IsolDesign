using IsolDesign.Domain.Interfaces.Interfaces_Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace IsolDesign.Domain.Models
{
    public class PortfolioSubjectModel : IPortfolioSubjectModel
    {
        [Required]
        [Display(Name = "Name of project")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date for this project")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Description of project")]
        public string Description { get; set; }

        public string Photo1 { get; set; }

        public string Photo2 { get; set; }

        public string Photo3 { get; set; }

        //public int PartnerId { get; set; } // FK

        //public int ApplicantId { get; set; } // FK
    }
}