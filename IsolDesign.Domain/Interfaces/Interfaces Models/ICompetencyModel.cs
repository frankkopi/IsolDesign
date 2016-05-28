using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Interfaces.Interfaces_Models
{
    public interface ICompetencyModel
    {
        string Name { get; set; }
        string Description { get; set; }
        ICollection<ApplicantModel> Applicants { get; set; }
        ICollection<PartnerModel> Partners { get; set; }
    }
}
