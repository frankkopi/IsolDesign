using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Domain.Models
{
    public class TeamModel
    {
        public int TeamId { get; set; }

        public string Name { get; set; }

        public int ProjectId { get; set; } // FK

        public virtual ProjectModel Project { get; set; }
        public virtual ICollection<PartnerModel> Partners { get; set; }
    }
}
