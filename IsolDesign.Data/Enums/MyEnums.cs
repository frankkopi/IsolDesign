using System.ComponentModel.DataAnnotations;

namespace IsolDesign.Data.Enums
{
    // enum used to describe a customers category
    public enum CustomerCategory
    {
        [Display(Name = "High Level Customer")]
        High = 1,
        [Display(Name = "Standard Level Customer")]
        Standard = 2,
        [Display(Name = "Low Level Customer")]
        Low = 3
    }

    // enum used to describe the type of assignments
    public enum AssignmentType
    {
        [Display(Name = "Partner Assignment")]
        PartnerAssignment = 1,
        [Display(Name = "Ordered Assignment")]
        OrderedAssignment = 2,
    }

    class MyEnums
    {
    }
}
