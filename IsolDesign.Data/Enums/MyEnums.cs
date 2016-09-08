using System.ComponentModel.DataAnnotations;

namespace IsolDesign.Data.Enums
{

    public enum CategoryType
    {
        //[Display(Name = "High Level")]
        High = 1,

        //[Display(Name = "Mid Level")]
        Middel = 2,
        //[Display(Name = "Low Level")]
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
