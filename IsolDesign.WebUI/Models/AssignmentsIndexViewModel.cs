using IsolDesign.Data.Enums;
using IsolDesign.Domain.Models;
using System.Collections.Generic;
using IsolDesign.Domain.Helpers;

namespace IsolDesign.WebUI.Models
{
    public class AssignmentsIndexViewModel
    {
        public AssignmentModel Assignment { get; set; }

        public IEnumerable<AssignmentModel> Assignments { get; set; }


        public string ShortString(string s)
        {
           return s.Substring(0, 20) + " ..........";
        }
    }
}