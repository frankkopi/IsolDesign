using IsolDesign.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IsolDesign.Domain.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Customer address is required")]
        [Display(Name = "Customer Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Customer country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Customer phone number is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Customer Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Customer Category is required")]
        [Display(Name = "Customer Category")]
        public CustomerCategory Category { get; set; }

        public string Homepage { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }


        public virtual ICollection<OrderedAssignmentModel> Assignments { get; set; }
    }
}
