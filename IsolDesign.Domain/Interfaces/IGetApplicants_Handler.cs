using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Interfaces
{
    public interface IGetApplicants_Handler
    {
        IEnumerable<ApplicantModel> GetApplicants();

        ApplicantModel GetApplicant(int id);
    }
}
