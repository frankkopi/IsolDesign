using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Data.Models
{
    // this class describes the development method used in a project
    public class DevMethod
    {
        public int DevMethodId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public virtual ICollection<Project> Projects { get; set; }
    }
}
