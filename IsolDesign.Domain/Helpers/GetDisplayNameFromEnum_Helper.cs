using IsolDesign.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace IsolDesign.Domain.Helpers
{
    public class GetDisplayNameFromEnum_Helper
    {
        // Gets the string from the Display(Name = "") attribute in the AssignmentType enum
        public static string GetDisplayName(AssignmentType? enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }

        // Gets the string from the Display(Name = "") attribute in the CustomerCategory enum
        public static string GetDisplayName2(CustomerCategory enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }
    }
}
