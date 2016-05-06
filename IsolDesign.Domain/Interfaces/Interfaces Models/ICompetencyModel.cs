using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
