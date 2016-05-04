using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.DataAccess.Models
{
    public class Patent
    {
        public int PatentId { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public int ProjectId { get; set; } // FK


        public virtual Project Project { get; set; }
    }
}
