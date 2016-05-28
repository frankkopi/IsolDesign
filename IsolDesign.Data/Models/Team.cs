using System.Collections.Generic;

namespace IsolDesign.Data.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        public string Name { get; set; }

        public int ProjectId { get; set; } // FK

        public virtual Project Project { get; set; }
        public virtual ICollection<Partner> Partners { get; set; }
    }
}
