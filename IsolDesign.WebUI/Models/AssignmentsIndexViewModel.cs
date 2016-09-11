using IsolDesign.Data.Enums;
using IsolDesign.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using IsolDesign.Domain.Helpers;

namespace IsolDesign.WebUI.Models
{
    public class AssignmentsIndexViewModel
    {
        public AssignmentModel Assignment { get; set; }

        public IEnumerable<AssignmentModel> Assignments { get; set; }

        
        public string DisplayName(AssignmentType? enumValue)
        {
            return GetDisplayNameFromEnum_Helper.GetDisplayName(enumValue);
        }

        //public string GetDisplayName(AssignmentType? enumValue)
        //{
        //    return enumValue.GetType().GetMember(enumValue.ToString())
        //                   .First()
        //                   .GetCustomAttribute<DisplayAttribute>()
        //                   .Name;
        //}
    }
}