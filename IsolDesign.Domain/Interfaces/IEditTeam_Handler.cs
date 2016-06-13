using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Interfaces
{
    public interface IEditTeam_Handler
    {
        void EditTeam(TeamModel teamModel, string partnerIds, int projectId, int? projectLeaderId);
    }
}
