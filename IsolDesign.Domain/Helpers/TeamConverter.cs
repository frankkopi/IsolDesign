using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Domain.Helpers
{
    public class TeamConverter
    {
        public static TeamModel ConvertToTeamModel(Team team)
        {
            if (team != null)
            {
                TeamModel teamModel = new TeamModel
                {
                    TeamId = team.TeamId,
                    Name = team.Name,
                    ProjectId = team.ProjectId,
                    Project = null,
                    Partners = null
                };
                return teamModel;
            }

            return null;
        }
    }
}
