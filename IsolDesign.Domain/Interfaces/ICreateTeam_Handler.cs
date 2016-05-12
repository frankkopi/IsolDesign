using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Interfaces
{
    public interface ICreateTeam_Handler
    {
        IEnumerable<PartnerModel> GetPartners();

        IEnumerable<ProjectModel> GetProjects();

        void CreateTeam(TeamModel teamModel, IEnumerable<int> partnerIds);

        ICollection<Partner> AssignPartnersToTeam(IEnumerable<int> partnerIds);

        void Execute();
    }
}
