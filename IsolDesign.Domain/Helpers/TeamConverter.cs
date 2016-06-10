using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;

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

                var projectModel = ProjectConverter.ConvertToProjectModel(team.Project);
                teamModel.Project = projectModel;

                var partnerModels = PartnerConverter.ConvertToPartnerModels(team.Partners);
                teamModel.Partners = partnerModels;

                return teamModel;
            }

            return null;
        }



        //public static TeamModel ConvertToTeamModel(Team team)
        //{
        //    if (team != null)
        //    {
        //        TeamModel teamModel = new TeamModel
        //        {
        //            TeamId = team.TeamId,
        //            Name = team.Name,
        //            ProjectId = team.ProjectId,
        //            Project = null,
        //            Partners = null
        //        };

        //        var projectModel = ProjectConverter.ConvertToProjectModel(team.Project);
        //        teamModel.Project = projectModel;

        //        return teamModel;
        //    }

        //    return null;
        //}


    }
}
