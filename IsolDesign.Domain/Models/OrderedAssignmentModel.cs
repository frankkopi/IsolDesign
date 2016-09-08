using System;
using System.ComponentModel.DataAnnotations;
using IsolDesign.Domain.Interfaces.Interfaces_Models;

namespace IsolDesign.Domain.Models
{
    public class OrderedAssignmentModel : AssignmentModel, IOrderedAssignmentModel
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date for Deadline")]
        public DateTime Deadline { get; set; }

        [Required]
        public int CustomerId { get; set; } // FK


        public virtual CustomerModel Customer { get; set; }
    }
}
