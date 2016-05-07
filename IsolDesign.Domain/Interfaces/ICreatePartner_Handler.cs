using IsolDesign.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Domain.Interfaces
{
    public interface ICreatePartner_Handler
    {
        void CreatePartner();

        Applicant GetApplicant(int applicantId);

        void Execute();
    }
}
