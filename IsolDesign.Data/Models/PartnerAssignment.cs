using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.DataAccess.Models
{
    public class PartnerAssignment : Assignment
    {
        public int PartnerId { get; set; }  // FK

        public string Credits { get; set; } // helpers on the Assignment


        public virtual Partner Partner { get; set; }
    }
}
