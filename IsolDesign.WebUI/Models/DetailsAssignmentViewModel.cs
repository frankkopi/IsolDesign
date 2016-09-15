using IsolDesign.Data.Enums;
using IsolDesign.Domain.Helpers;
using IsolDesign.Domain.Models;

namespace IsolDesign.WebUI.Models
{
    public class DetailsAssignmentViewModel
    {
        public AssignmentModel AssignmentModel { get; set; }

        public string DisplayName(AssignmentType? enumValue)
        {
            return GetDisplayNameFromEnum_Helper.GetDisplayName(enumValue);
        }
    }
}