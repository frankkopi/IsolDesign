using IsolDesign.Domain.Interfaces.Interfaces_Models;

namespace IsolDesign.Domain.Models
{
    public class PartnerAssignmentModel : AssignmentModel, IPartnerAssignmentModel
    {
        public int PartnerId { get; set; }  // FK

        public string Credits { get; set; } // Name of people who assisted on the Assignment


        public virtual PartnerModel Partner { get; set; }
    }
}