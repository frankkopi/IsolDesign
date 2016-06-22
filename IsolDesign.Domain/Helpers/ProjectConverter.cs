using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Helpers
{
    public class ProjectConverter
    {
        public static ProjectModel ConvertToProjectModel(Project project)
        {
            ProjectModel projectModel = new ProjectModel
            {
                ProjectId = project.ProjectId,
                Description = project.Description,
                Name = project.Name,
                StartDate = project.StartDate,
                Deadline = project.Deadline,
                PartnerId = project.PartnerId,
                DevMethodId = project.DevMethodId,
                EconomyId = project.EconomyId,
                AssignmentId = project.AssignmentId,
                ProjectLeader = null,
                Teams = null
            };

            return projectModel;
        }

        // This method is used for deleting a Project
        public static ProjectModel ConvertToProjectModel2(Project project)
        {
            ProjectModel projectModel = new ProjectModel
            {
                ProjectId = project.ProjectId,
                Description = project.Description,
                Name = project.Name,
                StartDate = project.StartDate,
                Deadline = project.Deadline,
                PartnerId = project.PartnerId,
                DevMethodId = project.DevMethodId,
                EconomyId = project.EconomyId,
                Assignment = null,
                ProjectLeader = null,
                Teams = null
            };

            // getting the Assignment
            var assignmentModel = AssignmentConverter.ConvertToAssignmentModel(project.Assignment);
            projectModel.Assignment = assignmentModel;

            // PartnerId is the project leader
            if (project.PartnerId == null)
            {
                projectModel.ProjectLeader = null;
            }
            else
            {
                var partnerModel = PartnerConverter.ConvertToPartnerModel(project.ProjectLeader);
                projectModel.ProjectLeader = partnerModel;
            }

            if (project.Teams.Count == 0)
            {
                projectModel.Teams = null;
            }
            else
            {
                List<TeamModel> teamModels = new List<TeamModel>();
                foreach (var team in project.Teams)
                {
                    var teamModel = TeamConverter.ConvertToTeamModel(team);
                    teamModels.Add(teamModel);
                }
                projectModel.Teams = teamModels;
            }

            return projectModel;
        }
    }
}



//// This method is used for deleting a Project
//public static ProjectModel ConvertToProjectModel2(Project project)
//{
//    ProjectModel projectModel = new ProjectModel
//    {
//        ProjectId = project.ProjectId,
//        Description = project.Description,
//        Name = project.Name,
//        StartDate = project.StartDate,
//        Deadline = project.Deadline,
//        PartnerId = project.PartnerId,
//        DevMethodId = project.DevMethodId,
//        EconomyId = project.EconomyId,
//        AssignmentId = project.AssignmentId,
//        ProjectLeader = null,
//        Teams = null
//    };

//    // PartnerId is the project leader
//    if (project.PartnerId == null)
//    {
//        projectModel.ProjectLeader = null;
//    }
//    else
//    {
//        var partnerModel = PartnerConverter.ConvertToPartnerModel(project.ProjectLeader);
//        projectModel.ProjectLeader = partnerModel;
//    }

//    if (project.Teams.Count == 0)
//    {
//        projectModel.Teams = null;
//    }
//    else
//    {
//        List<TeamModel> teamModels = new List<TeamModel>();
//        foreach (var team in project.Teams)
//        {
//            var teamModel = TeamConverter.ConvertToTeamModel(team);
//            teamModels.Add(teamModel);
//        }
//        projectModel.Teams = teamModels;
//    }

//    return projectModel;
//}

