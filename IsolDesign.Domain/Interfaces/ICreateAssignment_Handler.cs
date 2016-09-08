using IsolDesign.Data.Models;
using IsolDesign.Domain.Interfaces.Interfaces_Models;

namespace IsolDesign.Domain.Interfaces
{
    public interface ICreateAssignment_Handler
    {
        void CreatePartnerAssignment(IPartnerAssignmentModel assignmentModel, string userName);

        void CreateOrderedAssignment(IOrderedAssignmentModel assignmentModel);

        int GetPartnerId();

        void Execute(Assignment assignment);
    }
}
