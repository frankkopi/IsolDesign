using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsolDesign.WebUI.Models
{
    public class AssignmentsIndexViewModel
    {
        public AssignmentModel Assignment { get; set; }

        public IEnumerable<AssignmentModel> Assignments { get; set; }
    }
}