using IsolDesign.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Domain.Models
{
    public enum AssignmentType
    {
        [Display(Name = "Partner Assignment")]
        PartnerAssignment = 1,

        [Display(Name = "Ordered Assignment")]
        OrderedAssignment = 2
    }

    public class AssignmentModel
    {
        public int AssignmentId { get; set; }

        public string WorkTitle { get; set; }

        public AssignmentType Type { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public string Drawing { get; set; }

        public string Video { get; set; }

    }
}
