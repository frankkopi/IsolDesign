﻿using System.Collections.Generic;

namespace IsolDesign.Data.Models
{
    public class Applicant
    {
        public int ApplicantId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ProfileImagePath { get; set; }

        public string Description { get; set; }

        public string SkypeLink { get; set; }

        public string Facebook { get; set; }

        public string LinkedIn { get; set; }

        public string Homepage { get; set; }


        public virtual ICollection<Competency> Competencies { get; set; }
        public virtual ICollection<PortfolioSubject> Portfolio { get; set; }
        
    }
}
