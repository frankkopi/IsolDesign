using System;
using System.Collections.Generic;

namespace IsolDesign.Data.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime Deadline { get; set; }

        public int? PartnerId { get; set; } // FK Project Leader

        public int? DevMethodId { get; set; } // FK

        public int? EconomyId { get; set; } // FK

        public int AssignmentId { get; set; } // FK

        public virtual Partner ProjectLeader { get; set; }
        public virtual DevMethod DevMethod { get; set; }
        public virtual Economy Economy { get; set; }
        public virtual ICollection<Patent> Patents { get; set; }
        public virtual Assignment Assignment { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
