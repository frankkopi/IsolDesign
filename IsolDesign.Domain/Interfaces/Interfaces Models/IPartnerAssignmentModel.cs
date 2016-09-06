using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Interfaces.Interfaces_Models
{
    public interface IPartnerAssignmentModel : IAssignmentModel
    {
        int PartnerId { get; set; }  // FK
        string Credits { get; set; } // Name of people who assisted on the Assignment

        PartnerModel Partner { get; set; }
    }
}
