using IsolDesign.Data.Enums;
using IsolDesign.Domain.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IsolDesign.Domain.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Customer address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Customer country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Customer phone number is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Customer Email is required")]
        public string Email { get; set; }

        [Range(1, 3, ErrorMessage = "Customer Category is required")]
        [Display(Name = "Customer Category")]
        public CustomerCategory Category { get; set; }

        public string Homepage { get; set; }

        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }

        [Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }


        public virtual ICollection<OrderedAssignmentModel> Assignments { get; set; }

        // Gets the string from the Display(Name = "") attribute in the CustomerCategory enum
        public string DisplayName2(CustomerCategory enumValue)
        {
            return GetDisplayNameFromEnum_Helper.GetDisplayName2(enumValue);
        }
    }
}
