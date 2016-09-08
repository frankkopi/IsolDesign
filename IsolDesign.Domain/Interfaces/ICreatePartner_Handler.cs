using IsolDesign.Data.Models;

namespace IsolDesign.Domain.Interfaces
{
    public interface ICreatePartner_Handler
    {
        void CreatePartner();

        Applicant GetApplicant(int applicantId);

        void Execute();

        Partner GetPartner();
    }
}
