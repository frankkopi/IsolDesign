using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.DataAccess.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public DateTime Deadline { get; set; }

        public Partner ProjectLeader { get; set; }

        public int DevMethodId { get; set; } // FK

        public int EconomyId { get; set; } // FK

        public int AssignmentId { get; set; } // FK


        public virtual DevMethod DevMethod { get; set; }
        public virtual Economy Economy { get; set; }
        public virtual ICollection<Patent> Patents { get; set; }
        public virtual Assignment Assignment { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
