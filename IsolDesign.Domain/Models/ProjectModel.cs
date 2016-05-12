using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IsolDesign.Domain.Models
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Name of Project")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Project Description")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Project Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; }

        public int? PartnerId { get; set; } // FK Project Leader

        public int? DevMethodId { get; set; } // FK

        public int? EconomyId { get; set; } // FK

        public int AssignmentId { get; set; } // FK


        public virtual PartnerModel ProjectLeader { get; set; }
        //public virtual DevMethodModel DevMethod { get; set; }
        //public virtual EconomyModel Economy { get; set; }
        //public virtual ICollection<PatentModel> Patents { get; set; }
        //public virtual AssignmentModel Assignment { get; set; }
        public virtual ICollection<TeamModel> Teams { get; set; }
    }
}
