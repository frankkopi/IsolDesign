﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IsolDesign.Domain.Models
{
    public class PartnerModel
    {
        public int PartnerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        [Display(Name = "Profile Image")]
        public string ProfileImagePath { get; set; }

        public string Description { get; set; }

        public string SkypeLink { get; set; }

        public string Facebook { get; set; }

        public string LinkedIn { get; set; }

        public string Homepage { get; set; }

        public int? TeamId { get; set; } // FK

        public virtual TeamModel Team { get; set; }
        public ICollection<CompetencyModel> Competencies { get; set; }
        public ICollection<PortfolioSubjectModel> Portfolio { get; set; }
        public ICollection<SubcontractorModel> Subcontractors { get; set; }
        public ICollection<PartnerAssignmentModel> Assignments { get; set; }
    }
}