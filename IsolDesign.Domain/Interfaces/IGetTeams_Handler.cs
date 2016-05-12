using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Interfaces
{
    public interface IGetTeams_Handler
    {
        IEnumerable<TeamModel> GetTeams();

    }
}
