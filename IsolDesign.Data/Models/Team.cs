using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
