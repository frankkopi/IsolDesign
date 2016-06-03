using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Interfaces
{
    public interface ICreateTeam_Handler
    {
        IEnumerable<PartnerModel> GetPartners();

        IEnumerable<ProjectModel> GetProjects();

        void CreateTeam(TeamModel teamModel, string partnerIds, int projectId);

        ICollection<Partner> AssignPartnersToTeam(string partnerIds);

        void Execute(int? projectLeaderId);
    }
}
